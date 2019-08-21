#if DEBUG
#define BACKGROUND_COLOR
#endif

using System.Windows.Input;
using TrackerClientEmulator.ViewModels;
using Xamarin.Forms;

namespace TrackerClientEmulator.Entites
{
    public class NavigationItem : BaseViewModel
    {
        #region Constructors
        public NavigationItem(BasePageViewModel pageViewModel)
        {
            Title = pageViewModel.Title;
            Command = pageViewModel.PageNavigationCommand;
            ContentPageViewModel = pageViewModel;
        }
        #endregion

        #region Fields
        private ICommand _command;

        private string _commandParameter;

        private string _icon;

        private string _title;

        #if BACKGROUND_COLOR
        private Color _backgroundColor = (Color)Application.Current.Resources["LightBackgroundColor"];
        #endif

        private bool _isActive;

        private BasePageViewModel _contentPageViewModel;
        #endregion


        #region Properties
        #if BACKGROUND_COLOR
        public Color BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                OnPropertyChanged();
            }
        }
        #endif

        public string CommandParameter
        {
            get { return _commandParameter; }
            set
            {
                _commandParameter = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public ICommand Command
        {
            get { return _command; }
            set
            {
                _command = value;
                OnPropertyChanged();
            }
        }

        public BasePageViewModel ContentPageViewModel
        {
            get { return _contentPageViewModel; }
            set
            {
                _contentPageViewModel = value;
                OnPropertyChanged();
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnPropertyChanged();
            }
        }
        #endregion


        #region Methods
        #endregion
    }
}
