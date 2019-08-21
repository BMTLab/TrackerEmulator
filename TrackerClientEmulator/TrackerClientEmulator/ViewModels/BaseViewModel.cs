using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TrackerClientEmulator.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Events
        public static event PropertyChangedEventHandler StaticPropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Invocator
        protected static void OnStaticPropertyChanged([CallerMemberName] string propertyName = "")
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
