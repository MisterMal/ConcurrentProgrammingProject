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
            MyModel = ModelAbstractAPI.CreateAPI();
            Start = new RelayCommand(() => start());
            Stop = new RelayCommand(() => stop());
            _numberOfBalls = 5;
            _startButton = "Start";
        }

        private ModelAbstractAPI MyModel { get; set; }


        private int _numberOfBalls;
        private int _height = 400;
        private int _width = 700;
        private string _startButton;

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

        public ObservableCollection<Circle> Circles
        {
            get => MyModel.Circles;
            set => MyModel.Circles = value;
        }

        public int NumberOfBalls
        {
            get => _numberOfBalls;
            set => _numberOfBalls = value;
        }

        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }

        public void start()
        {
            MyModel.generateBallsRepresentative(Height, Width, NumberOfBalls, 15);
            StartButton = "Restart";
        }

        public void stop()
        {
            MyModel.stopSimulation();
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
