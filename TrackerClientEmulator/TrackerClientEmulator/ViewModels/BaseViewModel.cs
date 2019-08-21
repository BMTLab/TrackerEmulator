using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TrackerClientEmulator.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public static event PropertyChangedEventHandler StaticPropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        protected static void OnStaticPropertyChanged([CallerMemberName] string propertyName = "")
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(/*[CallerMemberName] */string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
