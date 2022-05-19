
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
        private ModelApi ModelLayer { get; set; }


        public MainWindowViewModel()
        {
            ModelLayer = ModelApi.CreateApi();
            Start = new RelayCommand(() => VisualisationStart());
            Stop = new RelayCommand(() => StopVisualisation());
            numberOfBalls = 10;
            startButton = "Start";
        }

        

        public string StartButton
        {
            get => startButton;
            set
            {
                startButton = value;
                RaisePropertyChanged(nameof(StartButton));
            }

        }

        public int Width
        {
            get => width;
            set
            {
                width = value;
                RaisePropertyChanged(nameof(Width));
            }
        }

        public int Height
        {
            get => height;
            set
            {
                height = value;
                RaisePropertyChanged(nameof(Height));
            }
        }

        public ObservableCollection<BallModel> BallModelsCollection
        {
            get => ModelLayer.BallModelsCollection;
            set => ModelLayer.BallModelsCollection = value;
        }

        public string NumberOfBalls
        {
            get => numberOfBalls.ToString();
            set
            {
                if (int.TryParse(value, out int n) && n != 0)
                    numberOfBalls = Math.Abs(n);
                RaisePropertyChanged(nameof(NumberOfBalls));
            }
        }

        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }

        public void VisualisationStart()
        {
            ModelLayer.Visualisation(1, 1, 30, 10, numberOfBalls);
        }

        private void StopVisualisation()
        {
            ModelLayer.Stop();
        }


        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

