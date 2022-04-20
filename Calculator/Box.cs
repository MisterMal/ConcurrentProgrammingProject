using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Box
    {
        private readonly int _width;
        private readonly int _height;
        private readonly List<Ball> balls = new List<Ball>();

        public Box(int ballsAmount, int ballRadius, int height, int width)
        {
            generateBalls(ballsAmount, ballRadius);     
        }

        private void generateBalls(int number, int radius)
        {
            for (int i = 0; i < number; i++)
            {
                balls.Add(new Ball(radius, 1, 1));         
            }
        }

        public int Width{ get { return _width; }}
        public int Height { get { return _height; }}

        public List<Ball> Balls { get { return balls; } }
    }
}
