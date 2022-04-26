using System;
using System.ComponentModel;

namespace Model
{
    public interface IBallModel : INotifyPropertyChanged
    {
        int X { get; }
        int Y { get; }
        int Radius { get; }
        int DoubleRadius { get; }

        void INotifyPropertyChanged(string propertyName = null);
    }
}
