using Logic;
using System;
using System.Threading;

namespace Model
{
    public abstract class ModelAbstractApi
    {
        static void Main()
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


        }
    }
}
