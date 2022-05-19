using System;
using System.Collections.Generic;
using System.Threading;

namespace Data
{
    public abstract class DataApi
    {
        public static DataApi CreateAPI()
        {
            return new DataLayer();
        }

        public abstract void CreateBalls(int radius, int mass, int numberOfBalls);
        public abstract void StartBalls();
        public abstract void StopBalls();
        public abstract bool IsCreationPossible(float x, float y, int radius);
        public abstract List<Ball> GetBalls();

        public abstract void createThreads();

        internal class DataLayer : DataApi
        {
            private List<Ball> balls = new List<Ball>();
            private List<Thread> threads = new List<Thread>();
            private object myLock = new object();
            private bool started = false;

            public DataLayer()
            {

            }

            public override void CreateBalls(int radius, int mass, int numberOfBalls)
            {
                for (int i = 0; i < numberOfBalls; i++)
                {
                    Ball ball = new Ball(radius, mass);
                    while (!IsCreationPossible(ball.X, ball.Y, ball.Radius))
                    {
                        ball.RerollCords();
                    }
                    balls.Add(ball);
                }
            }

            public override void createThreads()
            {
                foreach (Ball ball in balls)
                {
                    Thread t = new Thread(() =>
                    {

                        while (started)
                        {

                            lock (myLock)
                            {
                                ball.Move();
                            }

                            Thread.Sleep(10);
                        }

                    });
                    t.IsBackground = true;

                    threads.Add(t);
                }
            }

            public override bool IsCreationPossible(float x, float y, int radius)
            {
                foreach (Ball ball in balls)
                {
                    float d = (float)Math.Sqrt((x - ball.X) * (x - ball.X) + (y - ball.Y) * (y - ball.Y));
                    if (d <= radius + ball.Radius + 1)
                        return false;
                }
                return true;
            }

            public override void StartBalls()
            {
                started = true;

                foreach (Thread thread in threads)
                {
                    thread.Start();
                }
            }

            public override void StopBalls()
            {
                started = false;
            }

            public override List<Ball> GetBalls() => this.balls;
         
        }

    }
}