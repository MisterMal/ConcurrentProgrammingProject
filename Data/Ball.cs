using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Data
{
    public class Ball : INotifyPropertyChanged
    {
        private int ballID;
        private float xValue;
        private float yValue;
        private int radiusValue = 10;
        private float xSpeedValue = (float)1;
        private float ySpeedValue = (float)1;
        private int mass = 10;
        public bool flag = false;
        

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Ball(int radius, int mass, int ballID)
        {
            Random rand = new Random();
            this.radiusValue = radius;
            this.xValue = rand.Next(0 + Radius, 700 - Radius);
            this.yValue = rand.Next(0 + Radius, 400 - Radius);
            this.mass = mass;
            this.ballID = ballID;
        }

        public void RerollCords()
        {
            Random rand = new Random();
            this.xValue = rand.Next(0 + Radius, 700 - Radius);
            this.yValue = rand.Next(0 + Radius, 400 - Radius);
        }
        public void Move()
        {
            X += xSpeedValue;
            Y += ySpeedValue;
            flag = true;
            RaisePropertyChanged("Cords");
        }

        public int ID
        {
            get { return ballID; }
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

        

        [JsonIgnore]
        public bool Flag
        {
            get => this.flag;
            set
            {
                this.flag = value;
            }
        }

        [JsonIgnore]
        public float XSpeed
        {
            get => this.xSpeedValue;
            set
            {
                this.xSpeedValue = value;
                RaisePropertyChanged(nameof(XSpeed));
            }
        }

        [JsonIgnore]
        public float YSpeed
        {
            get => this.ySpeedValue;
            set
            {
                this.ySpeedValue = value;
                RaisePropertyChanged(nameof(YSpeed));
            }
        }

        [JsonIgnore]
        public int Radius
        {
            get => this.radiusValue;
            set
            {
                this.radiusValue = value;
                RaisePropertyChanged(nameof(radiusValue));
            }
        }

        [JsonIgnore]
        public int Mass
        {
            get => this.mass;
            set
            {
                this.mass = value;
                RaisePropertyChanged(nameof(mass));
            }
        }
    }
}
