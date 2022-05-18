using Data;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Logic
{
    public abstract class LogicApi
    {
        private List<Thread> threadsList = new List<Thread>();
        private List<IBall> ballList = new List<IBall>();
        private static DataApi dataApi;

        public abstract void BallsCreating(float xSpeed, float ySpeed, int radius, int howMany);
        public abstract void Start();

        public abstract List<IBall> GetBallList();

        public static LogicApi CreateApi(DataApi data = default)
        {
            return new LogicLayer(data ?? DataApi.CreateAPI());
        }
        

        public class LogicLayer : LogicApi
        {
            public override List<IBall> GetBallList()
            {
                return this.ballList;
            }

            public LogicLayer(DataApi data)
            {
                dataApi = data;
            }

            public override void BallsCreating(float xSpeed, float ySpeed, int radius, int howMany)
            {
                for (int i = 0; i < howMany; i++)
                {
                    this.ballList.Add(new Ball(radius, xSpeed, ySpeed));
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

    }

    
}
