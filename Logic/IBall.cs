using System.ComponentModel;

namespace Logic
{
    public interface IBall : INotifyPropertyChanged
    {
        float X { get; }
        float Y { get; }
        int Radius { get; }

        void RaisePropertyChanged(string propertyName = null);
    }
}
