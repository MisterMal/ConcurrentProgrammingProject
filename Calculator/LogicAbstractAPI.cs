using System;
using Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI CreateAPI(DataAbstractAPI data = default)
        {
            return new LogicLayer(data ?? DataAbstractAPI.CreateAPI());
        }

        public abstract Ball CreateBall(int radius, float speedx, float speedy);
        public abstract Box CreateBox(int height, int width, int numberOfBalls, int radiusOfBalls);
        public abstract void StartMovingBalls();
        public abstract void DestroyThreads();


        private List<Thread> threads;
        private bool isMoving = false;


        public class LogicLayer : LogicAbstractAPI
        {
            public LogicLayer(DataAbstractAPI dataLayerAbstractAPI)
            {
                MyDataLayer = dataLayerAbstractAPI;
            }

            public override Ball CreateBall(int radius, float speedx, float speedy)
            {
                return new Ball(radius, speedx, speedy);
            }

            public override Box CreateBox(int height, int width, int numberOfBalls, int radiusOfBalls)
            {

                Box box = new Box(height, width, numberOfBalls, radiusOfBalls);

                threads = new List<Thread>();

                foreach (Ball ball in box.Balls)
                {

                    Thread t = new Thread(() =>
                    {
                        while (isMoving)
                        {
                            ball.Movement();
                        }
                    });

                    threads.Add(t);
                }

                return box;
            }


            public override void StartMovingBalls()
            {
                if (!isMoving)
                {
                    isMoving = true;
                    foreach (Thread t in threads) 
                    { 
                        t.Start();
                    }
                }

            }

            public override void DestroyThreads()
            {
                isMoving = false;
            }


            private readonly DataAbstractAPI MyDataLayer;
        }
    }
}
