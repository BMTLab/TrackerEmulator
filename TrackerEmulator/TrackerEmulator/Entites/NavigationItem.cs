#define BACKGROUND_COLOR

using System.Windows.Input;
using TrackerEmulator.ViewModels;
using TrackerEmulator.ViewModels.Pages;
using Xamarin.Forms;

namespace TrackerEmulator.Entites
{
    public class NavigationItem : BaseViewModel
    {
        #region Fields

        public static Color ItemSelectedColor = Color.Blue;

        public static Color ItemNonSelectedColor = Color.Brown;

        public static Color TextColorDefault = Color.Black;


        private ICommand _command;

        private string _commandParameter;

        private string _icon;

        private string _title;

        #if BACKGROUND_COLOR
        private Color _backgroundColor = ItemNonSelectedColor;

        private Color _borderColor = ItemNonSelectedColor;

        private Color _textColor = TextColorDefault;
        #endif

        private bool _isActive;

        private BasePageViewModel _contentPageViewModel;
        #endregion


        #region Constructors
        public NavigationItem(BasePageViewModel pageViewModel)
        {
            Title = pageViewModel.Title;
            Command = pageViewModel.PageNavigationCommand;
            ContentPageViewModel = pageViewModel;
        }
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

        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
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
                if (value == null)
                    return;

                _contentPageViewModel = value;
                OnPropertyChanged();
            }
        }

        public virtual bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                if (_isActive)
                {
                    BorderColor = BackgroundColor =  ItemSelectedColor;
                }
                else
                {
                    BorderColor = BackgroundColor = ItemNonSelectedColor;
                }

                OnPropertyChanged();
            }
        }

        #endregion


        #region Methods
        #endregion
    }
}
