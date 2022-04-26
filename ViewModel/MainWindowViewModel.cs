<<<<<<< HEAD
﻿using System;
using Model;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int numberOfBalls;
        private int height = 400;
        private int width = 700;
        private string startButton;

        public MainWindowViewModel()
        {
            MyModel = ModelApi.CreateApi();
            Start = new RelayCommand(() => VisualisationStart());
            numberOfBalls = 5;
            startButton = "Start";
        }

        private ModelApi MyModel { get; set; }

        public string StartButton
        {
            get => startButton;
            set
            {
                startButton = value;
                RaisePropertyChanged("StartButton");
            }

        }

        public int Width
        {
            get => width;
            set
            {
                width = value;
                RaisePropertyChanged("Width");
            }
        }


        public int Height
        {
            get => height;
            set
            {
                height = value;
                RaisePropertyChanged("Height");
            }
        }

        public ObservableCollection<IBallModel> BallModelsCollection
        {
            get => MyModel.BallModelsCollection;
            set => MyModel.BallModelsCollection = value;
        }

        public int NumberOfBalls
        {
            get => numberOfBalls;
            set => numberOfBalls = value;
        }

        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }

        public void VisualisationStart()
        {
            MyModel.Visualisation(Height, Width, NumberOfBalls, 35);
            StartButton = "In progress";
        }


        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        static public void Main()
        {

        }
    }
}
=======
﻿using System;
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
>>>>>>> 4884d2ec8e4cfd94eb8daa6223aa275d4f88f2a7
