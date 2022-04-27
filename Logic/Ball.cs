using System;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : IBall
    {
        private float xValue;
        private float yValue;
        private int radiusValue = 10;
        private float xSpeedValue = (float)1;
        private float ySpeedValue = (float)1;

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public float X
        {
            get => this.xValue;
            set
            {
                this.xValue = value;
                RaisePropertyChanged(nameof(X));
            }
        }
        public float Y
        {
            get => this.yValue;
            set
            {
                this.yValue = value;
                RaisePropertyChanged(nameof(Y)); 
            }
        }

        public float XSpeed
        {
            get => this.xSpeedValue;
            set
            {
                this.xSpeedValue = value;
                RaisePropertyChanged(nameof(XSpeed));
            }
        }

        public float YSpeed
        {
            get => this.ySpeedValue;
            set
            {
                this.ySpeedValue = value;
                RaisePropertyChanged(nameof(YSpeed));
            }
        }

        public int Radius
        {
            get => this.radiusValue;
            set
            {
                this.Radius = value;
                RaisePropertyChanged(nameof(radiusValue));
            }
        }

        public Ball(int radius, float speedx, float speedy)
        {
            Random rand = new Random();
            this.radiusValue = radius;
            this.xValue = rand.Next(0 + Radius, 700 - Radius);
            this.yValue = rand.Next(0 + Radius, 400 - Radius);
            this.xSpeedValue = speedx;
            this.ySpeedValue = speedy;
            
        }

        public void Movement()
        {
            float tempx, tempy;

            while(true)
            {
                tempx = X + XSpeed;
                tempy = Y + YSpeed;
                this.BorderCheckX(tempx);
                this.BorderCheckY(tempy);
                Thread.Sleep(10);
            }
        }

        public void BorderCheckX(float testX)
        {
            if (testX >= 700 - Radius*2)
            {
                X = 700 - Radius * 2;
                XSpeed *= -1;
            }
            else if (testX <= 0)
            {
                X = 0;
                XSpeed *= -1;
            }
            else
            {
                X = X + XSpeed;
            }
        }

        public void BorderCheckY(float testY)
        {
            if (testY + Radius * 2 >= 400)
            {
                Y = 400 - Radius * 2;
                YSpeed *= -1;
            }
            else if (testY <= 0)
            {
                Y = 0;
                YSpeed *= -1;
            }
            else
            {
                Y = Y + YSpeed;
            }
        }
    }

}