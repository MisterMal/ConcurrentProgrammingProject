using System;
using System.ComponentModel;

namespace Model
{
    public interface IBallModel : INotifyPropertyChanged
    {
        float X { get; }
        float Y { get; }
        int Radius { get; }
        int DoubleRadius { get; }

        void RaisePropertyChanged(string propertyName = null);
    }
}
