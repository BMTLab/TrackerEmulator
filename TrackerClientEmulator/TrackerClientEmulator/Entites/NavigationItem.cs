#define BACKGROUND_COLOR

using System.Windows.Input;
using TrackerClientEmulator.Helpers.Extension;
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
        private Color _backgroundColor = new Color().LightBackgroundColor();

        private Color _borderColor = new Color().LightBackgroundColor();
        #endif

        private bool _isActive;

        private BasePageViewModel _contentPageViewModel;
        #endregion


        #region Properties
        #if BACKGROUND_COLOR
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                OnPropertyChanged();
            }
        }

        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                OnPropertyChanged();
            }
        }
        #endif

        public string CommandParameter
        {
            get => _commandParameter;
            set
            {
                _commandParameter = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public ICommand Command
        {
            get => _command;
            set
            {
                _command = value;
                OnPropertyChanged();
            }
        }

        public BasePageViewModel ContentPageViewModel
        {
            get => _contentPageViewModel;
            set
            {
                _contentPageViewModel = value;
                OnPropertyChanged();
            }
        }

        public bool IsActive
        {
            get => _isActive;
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
