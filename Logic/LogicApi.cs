using System;
using System.Collections.Generic;
using System.Threading;

namespace Logic
{
    public abstract class LogicApi
    {
        private List<Thread> threadsList;
        private List<Ball> ballList;

        public abstract void BallsCreating(float xSpeed, float ySpeed, int radius, int howMany);
        public abstract void Start();

        

        public class LogicLayer : LogicApi
        {
            public override void BallsCreating(float xSpeed, float ySpeed, int radius, int howMany)
            {
                threadsList = new List<Thread>();
                ballList = new List<Ball>();

                for (int i = 0; i < howMany; i++)
                {
                    ballList.Add(new Ball(radius ,xSpeed, ySpeed));
                }

                foreach (Ball ball in ballList)
                {
                    threadsList.Add(new Thread(new ThreadStart(ball.Movement)));
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
    }

    
}
