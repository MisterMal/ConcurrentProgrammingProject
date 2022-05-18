using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Data
{
    public class Ball : INotifyPropertyChanged
    {
        private float xValue;
        private float yValue;
        private int radiusValue = 10;
        private float xSpeedValue = (float)1;
        private float ySpeedValue = (float)1;
        private int mass = 10;
        private int count = 0;
        private bool collision = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Ball(int radius, int mass)
        {
            Random rand = new Random();
            this.radiusValue = radius;
            this.xValue = rand.Next(0 + Radius, 700 - Radius);
            this.yValue = rand.Next(0 + Radius, 400 - Radius);
            this.mass = mass;
        }

        public void Move()
        {
            X += xSpeedValue;
            Y += ySpeedValue;
            count++;
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

        public int Mass
        {
            get => this.Mass;
            set
            {
                this.Mass = value;
                RaisePropertyChanged(nameof(mass));
            }
        }

        public int Count
        {
            get => this.Count;
            set
            {
                this.Count = value;

            }
        }

        public bool Collision
        {
            get => this.Collision;
            set { this.Collision = value; }
        }
    }
}
