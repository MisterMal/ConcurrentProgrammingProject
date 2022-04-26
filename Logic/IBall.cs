using System.ComponentModel;

namespace Logic
{
    public interface IBall : INotifyPropertyChanged
    {
        int X { get; }
        int Y { get; }
        int Radius { get; }

        void RaiseProperyChanged(string propertyName = null);
    }
}
