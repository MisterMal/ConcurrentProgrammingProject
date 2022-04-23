using System;
using Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            MyModel = ModelApi.CreateApi();
            Start = new RelayCommand(() => start());
            _numberOfBalls = 5;
            _startButton = "Start";
        }

        private ModelApi MyModel { get; set; }


        private int _numberOfBalls;
        private int _height = 400;
        private int _width = 700;
        private string _startButton;

        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }

        public string StartButton
        {
            get => _startButton;
            set
            {
                _startButton = value;
                RaisePropertyChanged("StartButton");
            }

        }

        public int Width
        {
            get => _width;
            set => _width = value;
        }

        public int Height
        {
            get => _height;
            set => _height = value;
        }

        public int NumberOfBalls
        {
            get => _numberOfBalls;
            set => _numberOfBalls = value;
        }



        public void start()
        {
   
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        static void Main()
        {

        }
    }
}
