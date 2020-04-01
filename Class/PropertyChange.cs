using System.Runtime.CompilerServices;
using System.ComponentModel;
namespace SmartSorage
{
    abstract class PropertyChange : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChangr([CallerMemberName]string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }
    }
}
