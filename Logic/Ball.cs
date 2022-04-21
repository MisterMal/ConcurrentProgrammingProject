using System;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private String name;
        private float xValue;
        private float yValue;
        private int radiusValue;
        private float xSpeedValue;
        private float ySpeedValue;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public float x
        {
            get => this.xValue;
            set
            {
                this.xValue = value;
                RaisePropertyChanged(nameof(x));
            }
        }
        public float y
        {
            get => this.yValue;
            set
            {
                this.yValue = value;
                RaisePropertyChanged(nameof(y)); 
            }
        }

        public float xSpeed
        {
            get => this.xSpeedValue;
            set
            {
                this.yValue = value;
                RaisePropertyChanged(nameof(xSpeed));
            }
        }

        public int radius
        {
            get => this.radiusValue;
            set
            {
                this.radius = value;
                RaisePropertyChanged(nameof(radiusValue));
            }
        }

        public Ball(int radius, float speedx, float speedy, String name)
        {
            Random rand = new Random();
            this.radiusValue = radius;
            this.xValue = rand.Next(0 + this.radiusValue, 700 - this.radiusValue);
            this.yValue = rand.Next(0 + this.radiusValue, 400 - this.radiusValue);
            this.xSpeedValue = speedx;
            this.ySpeedValue = speedy;
            this.name = name;
        }

        public Ball(int radius, float speedx, float speedy)
        {
            Random rand = new Random();
            this.radiusValue = radius;
            this.xValue = rand.Next(0 + this.radiusValue, 700 - this.radiusValue);
            this.yValue = rand.Next(0 + this.radiusValue, 400 - this.radiusValue);
            this.xSpeedValue = speedx;
            this.ySpeedValue = speedy;
        }

        public void Movement()
        {
            float tempx, tempy;

            while(this.ySpeedValue > 0 || this.xSpeedValue > 0)
            {
                tempx = this.xValue + xSpeedValue;
                tempy = this.yValue + ySpeedValue;
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
                x = tempx;
                y = tempy;
                //Console.WriteLine("Name:" + this.name + " x:" + this.x + " y:" + this.y);
                Thread.Sleep(1);
            }
        }

        public Boolean BorderCheckX(float testX)
        {
            if (testX + this.radiusValue >= 700)
            {
                x = 700 - this.radiusValue;
                this.xSpeedValue = 0;
                this.ySpeedValue = 0;
                return true;
            }
            if (testX - radiusValue <= 0)
            {
                x = 0 + this.radiusValue;
                this.xSpeedValue = 0;
                this.ySpeedValue = 0;
                return true;
            }
            return false;
        }

        public Boolean BorderCheckY(float testY)
        {
            if (testY + this.radiusValue >= 400)
            {
                y = 400 - this.radiusValue;
                this.xSpeedValue = 0;
                this.ySpeedValue = 0;
                return true;
            }
            if (testY - this.radiusValue <= 0)
            {
                y = 0 + this.radiusValue;
                this.xSpeedValue = 0;
                this.ySpeedValue = 0;
                return true;
            }
            return false;
        }
    }

}