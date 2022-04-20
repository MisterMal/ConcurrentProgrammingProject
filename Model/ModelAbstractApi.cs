using Logic;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace Model
{
    public abstract class ModelAbstractAPI
    {

        public static ModelAbstractAPI CreateAPI(LogicAbstractAPI logicLayer = default)
        {
            return new ModelLayer(logicLayer ?? LogicAbstractAPI.CreateAPI());
        }

        public abstract void generateBallsRepresentative(int height, int width, int numberOfBalls, int radiusOfBalls);
        public abstract void startSimulation();
        public abstract void stopSimulation();

        public ObservableCollection<Circle> Circles
        {
            get => circles;
            set => circles = value;
        }

        private ObservableCollection<Circle> circles = new ObservableCollection<Circle>();



        public class ModelLayer : ModelAbstractAPI
        {
            public ModelLayer(LogicAbstractAPI logicLayer)
            {
                MyLogicLayer = logicLayer;
            }


            public override void generateBallsRepresentative(int height, int width, int numberOfBalls, int radiusOfBalls)
            {
                MyLogicLayer.DestroyThreads();

                Box box = MyLogicLayer.CreateBox(height, width, numberOfBalls, radiusOfBalls);

                circles.Clear();
                foreach (Ball ball in box.Balls)
                {
                    circles.Add(new Circle(ball));
                }

                startSimulation();
            }
            public override void startSimulation()
            {
                MyLogicLayer.StartMovingBalls();
            }

            public override void stopSimulation()
            {
                MyLogicLayer.DestroyThreads();
            }


            private readonly LogicAbstractAPI MyLogicLayer;

        }





















        /*        static void Main()
                {
                    var ball1 = new Ball(10, 1, 1, "b1");
                    var ball2 = new Ball(10, 1, 1, "b2");
                    var ball3 = new Ball(10, 1, 1, "b3");
                    var ball4 = new Ball(10, 1, 1, "b4");


                    Thread first = new Thread(new ThreadStart(ball1.Movement));
                    Thread second = new Thread(new ThreadStart(ball2.Movement));
                    Thread third = new Thread(new ThreadStart(ball3.Movement));
                    Thread forth = new Thread(new ThreadStart(ball4.Movement));

                    first.Start();
                    second.Start();
                    third.Start();
                    forth.Start();


                }*/
    }
}
