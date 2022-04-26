using Data;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Logic
{
    public abstract class LogicApi
    {
        private List<Thread> threadsList = new List<Thread>();
        private List<Ball> ballList = new List<Ball>();
        private static DataApi dataApi;

        public abstract void BallsCreating(float xSpeed, float ySpeed, int radius, int howMany);
        public abstract void Start();

        public static LogicApi CreateApi(DataApi data = default)
        {
            return new LogicLayer(data ?? DataApi.CreateAPI());
        }
        

        public class LogicLayer : LogicApi
        {
            public LogicLayer(DataApi data)
            {
                dataApi = data;
            }

            public override void BallsCreating(float xSpeed, float ySpeed, int radius, int howMany)
            {
                for (int i = 0; i < howMany; i++)
                {
                    Ball ball = new Ball(radius, xSpeed, ySpeed);
                    this.ballList.Add(ball);
                }

                foreach (Ball ball in ballList)
                {
                    this.threadsList.Add(new Thread(new ThreadStart(ball.Movement)));
                }
            }

            public override void Start()
            {
                foreach(Thread thread in threadsList)
                {
                    thread.Start();
                }
            }
        }

        static public void Main()
        {

        }
    }

    
}
