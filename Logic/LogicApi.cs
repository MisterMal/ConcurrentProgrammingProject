using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Logic
{
    public abstract class LogicApi
    {

        private List<LogicBall> logicBalls;
        public abstract void BallsCreating(int radius, int mass, int numberOfBalls);
        public abstract void Start();
        public abstract void Stop();
        public abstract List<LogicBall> GetBalls();



        public static LogicApi CreateApi(DataApi data = default)
        {
            return new LogicLayer(data ?? DataApi.CreateAPI());
        }


        internal class LogicLayer : LogicApi
        {
            private readonly DataApi DataLayer;
            internal LogicLayer(DataApi dataApi)
            {
                DataLayer = dataApi;
            }

            public override void BallsCreating(int radius, int mass, int numberOfBalls)
            {
                logicBalls = new List<LogicBall>();
                DataLayer.CreateBalls(radius, mass, numberOfBalls);
                DataLayer.createThreads();

                foreach (Ball ball in DataLayer.GetBalls())
                {
                    logicBalls.Add(new LogicBall(ball));
                    ball.PropertyChanged += ChangeCords;
                }
            }

            private void ChangeCords(object sender, PropertyChangedEventArgs e)
            {
                Ball ball = (Ball)sender;
                if (e.PropertyName == "Cords")
                {
                    ChangingSpeeds(ball);
                    ball.Flag = false;
                }
            }

            private void ChangingSpeeds(Ball ball1)
            {
                BorderCheckX(ball1);
                BorderCheckY(ball1);
                Ball ball2 = WhichBallCollided(ball1);
                if (ball2 != null)
                {
                    float ball1x = (ball1.XSpeed * (ball1.Mass - ball2.Mass) / (ball1.Mass + ball2.Mass) + (2 * ball2.Mass * ball2.XSpeed) / (ball1.Mass + ball2.Mass));
                    float ball2x = (ball2.XSpeed * (ball2.Mass - ball1.Mass) / (ball1.Mass + ball2.Mass) + (2 * ball1.Mass * ball1.XSpeed) / (ball1.Mass + ball2.Mass));

                    float ball1y = (ball1.YSpeed * (ball1.Mass - ball2.Mass) / (ball1.Mass + ball2.Mass) + (2 * ball2.Mass * ball2.YSpeed) / (ball1.Mass + ball2.Mass));
                    float ball2y = (ball2.YSpeed * (ball2.Mass - ball1.Mass) / (ball1.Mass + ball2.Mass) + (2 * ball1.Mass * ball1.YSpeed) / (ball1.Mass + ball2.Mass));

                    ball1.XSpeed = ball1x;
                    ball1.YSpeed = ball1y;
                    ball2.XSpeed = ball2x;
                    ball2.YSpeed = ball2y;
                }

                
            }

            private void BorderCheckX(Ball ball)
            {
                if (ball.X + ball.XSpeed >= 700 - ball.Radius * 2)
                {
                    ball.X = 700 - ball.Radius * 2;
                    ball.XSpeed *= -1;
                }
                else if (ball.X + ball.XSpeed <= 0)
                {
                    ball.X = 0;
                    ball.XSpeed *= -1;
                }
                else
                {
                    ball.X = ball.X + ball.XSpeed;
                }
            }

            private void BorderCheckY(Ball ball)
            {
                if (ball.Y + ball.YSpeed >= 700 - ball.Radius * 2)
                {
                    ball.Y = 700 - ball.Radius * 2;
                    ball.YSpeed *= -1;
                }
                else if (ball.Y + ball.YSpeed <= 0)
                {
                    ball.Y = 0;
                    ball.YSpeed *= -1;
                }
                else
                {
                    ball.Y = ball.Y + ball.YSpeed;
                }
            }

            private Ball WhichBallCollided(Ball ball)
            {
                foreach (Ball collidingBall in DataLayer.GetBalls())
                {
                    if (collidingBall == ball)
                        continue;

                    float distance = (float)Math.Sqrt((ball.X - collidingBall.X) * (ball.X - collidingBall.X) + (ball.Y - collidingBall.Y) * (ball.Y - collidingBall.Y));

                    if (distance <= ball.Radius + collidingBall.Radius)
                        return collidingBall;
                }
                return null;
            }

            public override List<LogicBall> GetBalls()
            {
                return logicBalls;
            }

            public override void Start()
            {
                DataLayer.StartBalls();
            }

            public override void Stop()
            {
                DataLayer.StopBalls();
            }
        }

    }

    
}
