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
    public class Circle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public Circle(Ball ball)
        {
            ball.PropertyChanged += OnPropertyChanged;
            X_Center = ball.X;
            Y_Center = ball.Y;
            Radius = (int)ball.GetRadius();
        
        }

        private int x_center;
        private int y_center;
        private int radius;


        public int Radius
        {
            get { return radius; }
            set { 
                radius = value;
                RaisePropertyChanged("Radius");
            }
        }

        public float X_Center
        {
            get { return x_center; }
            set 
            { 
                x_center = (int)value;
                RaisePropertyChanged("X_Center");
            }
        }

        public float Y_Center
        {
            get { return y_center; }
            set
            {
                x_center = (int)value;
                RaisePropertyChanged("Y_Center");
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            //Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
            //{
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //}));

        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Ball b = (Ball)sender;

            switch (e.PropertyName)
            {
                case "X":
                    X_Center = b.X;
                    break;
                case "Y":
                    Y_Center = b.Y;
                    break;
            }
        }
        static void Main()
        {

        }
    }
}
