using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private String name;
        private float x;
        private float y;
        private int radius;
        private float speedx;
        private float speedy;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public float GetX()
        {
            return this.x;
        }

        public float X
        {
            get => this.x;
            set
            {
                this.x = value;
                RaisePropertyChanged(nameof(X));
            }
        }
        public float Y
        {
            get => this.y;
            set
            {
                this.y = value;
                RaisePropertyChanged(nameof(Y)); 
            }
        }

        public float GetY()
        {
            return this.y;
        }

        public float GetRadius()
        {
            return this.radius;
        }

        public float GetSpeedX()
        {
            return this.speedx;
        }

        public float GetSpeedY()
        {
            return this.speedy;
        }

        public Ball(int radius, float speedx, float speedy, String name)
        {
            Random rand = new Random();
            this.radius = radius;
            this.x = rand.Next(0 + this.radius, 700 - this.radius);
            this.y = rand.Next(0 + this.radius, 400 - this.radius);
            this.speedx = speedx;
            this.speedy = speedy;
            this.name = name;
        }

        public Ball(int radius, float speedx, float speedy)
        {
            Random rand = new Random();
            this.radius = radius;
            this.x = rand.Next(0 + this.radius, 700 - this.radius);
            this.y = rand.Next(0 + this.radius, 400 - this.radius);
            this.speedx = speedx;
            this.speedy = speedy;
        }

        public void Movement()
        {
            float tempx, tempy;

            while(this.speedy > 0)
            {
                tempx = this.x + speedx;
                tempy = this.y + speedy;
                if (this.BorderCheckX(tempx))
                {
                    //Console.WriteLine("Name:" + this.name + " x:" + this.x + " y:" + this.y);
                    return;
                }
                if (this.BorderCheckY(tempy))
                {
                    //Console.WriteLine("Name:" + this.name + " x:" + this.x + " y:" + this.y);
                    return;
                }
                this.x = tempx;
                this.y = tempy;
                //Console.WriteLine("Name:" + this.name + " x:" + this.x + " y:" + this.y);
                Thread.Sleep(1);
            }

        }

        public Boolean BorderCheckX(float testX)
        {
            if (testX + this.radius >= 700)
            {
                this.x = 700 - this.radius;
                this.speedx = 0;
                this.speedy = 0;
                return true;
            }
            if (testX - radius <= 0)
            {
                this.x = 0 + this.radius;
                this.speedx = 0;
                this.speedy = 0;
                return true;
            }
            return false;
        }

        public Boolean BorderCheckY(float testY)
        {
            if (testY + this.radius >= 400)
            {
                this.y = 400 - this.radius;
                this.speedx = 0;
                this.speedy = 0;
                return true;
            }
            if (testY - this.radius <= 0)
            {
                this.y = 0 + this.radius;
                this.speedx = 0;
                this.speedy = 0;
                return true;
            }
            return false;
        }

        static void Main()
        {
        }
    }

}