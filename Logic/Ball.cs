using System;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic
{
    public class Ball : INotifyPropertyChanged
    {
        private float xValue;
        private float yValue;
        private int radiusValue = 10;
        private float xSpeedValue = (float)0.5;
        private float ySpeedValue = (float)0.5;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
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

            while(this.YSpeed > 0 || this.XSpeed > 0)
            {
                tempx = X + XSpeed;
                tempy = X + YSpeed;
                if (this.BorderCheckX(tempx))
                {
                    return;
                }
                if (this.BorderCheckY(tempy))
                {
                    return;
                }
                X = tempx;
                Y = tempy;
                
                Thread.Sleep(1);
            }
        }

        public Boolean BorderCheckX(float testX)
        {
            if (testX + Radius >= 700)
            {
                X = 700 - Radius;
                XSpeed = 0;
                YSpeed = 0;
                return true;
            }
            if (testX - radiusValue <= 0)
            {
                X = 0 + Radius;
                XSpeed = 0;
                YSpeed = 0;
                return true;
            }
            return false;
        }

        public Boolean BorderCheckY(float testY)
        {
            if (testY + Radius >= 400)
            {
                Y = 400 - Radius;
                XSpeed = 0;
                YSpeed = 0;
                return true;
            }
            if (testY - Radius <= 0)
            {
                Y = 0 + Radius;
                XSpeed = 0;
                YSpeed = 0;
                return true;
            }
            return false;
        }
    }

}