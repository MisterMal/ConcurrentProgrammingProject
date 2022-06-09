using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace Data
{
    internal class Log
    {
        private static List<Ball> balls;
        private bool isLogging = true;
        private Stopwatch startTime;
        internal Log(List<Ball> BallList)
        {
            balls = BallList;

            Thread thread = new Thread(() => StartLogging(10));

            thread.IsBackground = true;
            thread.Start();

        }

        private void StartLogging(int measureInterval)
        {
            startTime = Stopwatch.StartNew();

            while (isLogging)
            {
                if (startTime.ElapsedMilliseconds >= measureInterval)
                {
                    StringWriter whatToWrite = new StringWriter();
                    startTime.Restart();
                    string time = ($"{ DateTime.Now:o}");
                    foreach (Ball ball in balls)
                    {
                        whatToWrite.WriteLine(time + " : " + JsonSerializer.Serialize(ball));
                    }
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\..\\log.txt", true))
                    {
                        file.Write(whatToWrite.ToString());
                    }
                }
            }
        }

        internal void StopLogging()
        {
            isLogging = false;
        }

    }
}
