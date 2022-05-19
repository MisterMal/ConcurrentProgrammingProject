using System.ComponentModel;
using Data;

namespace Logic
{
    
    public class LogicBall : INotifyPropertyChanged
    {
        private readonly Ball myBall;

        public Ball Ball { get => myBall; }

        public  LogicBall(Ball ball)
        {
            myBall = ball;
            ball.PropertyChanged += CordsChange;
        }

        public void CordsChange(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged("Cords");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public float X
        {
            get => myBall.X;
            set
            {
                myBall.X = value;
                RaisePropertyChanged(nameof(X));
            }
        }

        public float Y
        {
            get => myBall.Y;
            set
            {
                myBall.Y = value;
                RaisePropertyChanged(nameof(Y));
            }

        }

        public int Radius
        {
            get => myBall.Radius;
            set
            {
                if (value > 0)
                {
                    myBall.Radius = value;
                }

                else
                {
                    throw new System.ArgumentException("Panie, to dodatnie ma byc");
                }

            }
        }

        public float XSpeed
        {
            get => myBall.XSpeed;
            set
            {
                myBall.XSpeed = value;
            }
        }

        public float YSpeed
        {
            get => myBall.YSpeed;
            set
            {
                myBall.YSpeed = value;
            }
        }

        public int Mass
        {
            get
            {
                return myBall.Mass;
            }
            set
            {
                myBall.Mass = value;
            }
        }
    }
}
