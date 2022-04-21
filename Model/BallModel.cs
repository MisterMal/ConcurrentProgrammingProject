using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Logic;
using System.Runtime.CompilerServices;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private float xValue;
        private float yValue;
        private int radiusValue;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public BallModel(Ball ball)
        {
            ball.PropertyChanged += OnPropertyChanged;
            x = ball.x;
            y = ball.y;
            Radius = (int)ball.radius;
        
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

        public float x
        {
            get 
            { 
                return xValue;
            }
            set 
            { 
                xValue = value;
                RaisePropertyChanged("xValue");
            }
        }

        public float y
        {
            get 
            { 
                return yValue;
            }
            set
            {
                yValue = value;
                RaisePropertyChanged("yValue");
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Ball b = (Ball)sender;

            switch (e.PropertyName)
            {
                case "X":
                    x = b.x;
                    break;
                case "Y":
                    y = b.y;
                    break;
            }
        }
    }
}
