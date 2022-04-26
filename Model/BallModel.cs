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
        
        public BallModel(IBall ball)
        {
            ball.PropertyChanged += OnPropertyChanged;
            X = ball.X;
            Y = ball.Y;
            Radius = (int)ball.Radius;
        
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
                RaisePropertyChanged("Radius");
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
                RaisePropertyChanged("X");
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
                RaisePropertyChanged("Y");
            }
        }

        public int DoubleRadius
        {
            get => Radius * 2;
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IBall b = (IBall)sender;

            switch (e.PropertyName)
            {
                case "X":
                    X = b.X;
                    break;
                case "Y":
                    Y = b.Y;
                    break;
            }
        }
    }
}
