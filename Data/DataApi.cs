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

        public abstract void CreateBalls(float x, float y, int radius, int mass);
        public abstract void StartBalls();

        public abstract void StopBalls();

        public abstract bool IsCreationPossible(float x, float y, int radius);

        internal class DataLayer : DataApi
        {
            private List<Ball> balls;
            private List<Thread> threads;
            private object myLock = new object();
            private object barrier = new object();
            private int count = 0;
            private int totalBalls = 0;
            private bool started = false;

            public DataLayer()
            {

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

            public override void CreateBalls(float x, float y, int radius, int mass)
            {
                Ball firstBall = new Ball(radius, mass);
                balls.Add(firstBall);

                while(balls.Capacity < totalBalls)
                {
                    Ball ball = new Ball(radius, mass);

                    if (this.IsCreationPossible(ball.X, ball.Y, radius))
                    {
                        balls.Add(ball);

                        Thread t = new Thread(() =>
                        {

                            while (started)
                            {
                                
                                lock (myLock)
                                {
                                    ball.Move();
                                }

                                if (Interlocked.CompareExchange(ref count, 1, 0) == 0)
                                {
                                    Monitor.Enter(barrier);
                                    while (count != totalBalls && started == true) { }
                                    Interlocked.Decrement(ref count);
                                    Monitor.Exit(barrier);
                                }
                                else
                                {
                                    Interlocked.Increment(ref count);
                                    Monitor.Enter(barrier);
                                    Interlocked.Decrement(ref count);
                                    Monitor.Exit(barrier);
                                }

                                Thread.Sleep(1);
                            }

                            System.Diagnostics.Debug.WriteLine(ball.Count);

                        });

                        threads.Add(t);
                    }
                }

                
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
        }

        
        static public void Main()
        {

        }


    }


}