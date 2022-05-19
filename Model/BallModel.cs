using Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private float xValue;
        private float yValue;
        private int radiusValue;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public BallModel(LogicBall ball)
        {
            ball.PropertyChanged += OnPropertyChanged;
            X = ball.X;
            Y = ball.Y;
            Radius = ball.Radius;
        
        }

        public int Radius
        {
            get 
            {
                return radiusValue;
            }
            set 
            { 
                radiusValue = value;
                RaisePropertyChanged(nameof(Radius));
            }
        }

        public float X
        {
            get 
            { 
                return xValue;
            }
            set 
            { 
                xValue = value;
                RaisePropertyChanged(nameof(X));
            }
        }

        public float Y
        {
            get 
            { 
                return yValue;
            }
            set
            {
                yValue = value;
                RaisePropertyChanged(nameof(Y));
            }
        }

        public float DoubleRadius
        {
            get => 2 * Radius;
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            LogicBall b = (LogicBall)sender;

            X = b.X;
            Y = b.Y;
        }
    }
}
