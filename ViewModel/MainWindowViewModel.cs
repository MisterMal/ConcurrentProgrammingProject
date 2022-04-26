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
