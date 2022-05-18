using System.ComponentModel;
using Data;

namespace Logic
{
    
    public class LogicBall : INotifyPropertyChanged
    {
        private readonly Ball ball;

        public  LogicBall(Ball ball)
        {
            this.ball = ball;
            ball.PropertyChanged += CordsChange;
        }

        public void CordsChange(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged("Coordinates");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public float X
        {
            get => ball.X;
            set
            {
                ball.X = value;
                RaisePropertyChanged(nameof(X));
            }
        }

        public float Y
        {
            get => ball.Y;
            set
            {
                ball.Y = value;
                RaisePropertyChanged(nameof(Y));
            }

        }

        public int Radius
        {
            get => ball.Radius;
            set
            {
                if (value > 0)
                {
                    ball.Radius = value;
                }

                else
                {
                    throw new System.ArgumentException("Panie, to dodatnie ma byc");
                }

            }
        }

        public float XSpeed
        {
            get => ball.XSpeed;
            set
            {
                ball.XSpeed = value;
            }
        }

        public float YSpeed
        {
            get => ball.YSpeed;
            set
            {
                ball.YSpeed = value;
            }
        }

        public int Mass
        {
            get
            {
                return ball.Mass;
            }
        }
    }
}
