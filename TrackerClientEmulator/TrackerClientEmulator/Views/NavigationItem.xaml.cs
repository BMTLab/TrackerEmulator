using System;
using System.Windows.Input;
using TrackerClientEmulator.ViewModels;
using Xamarin.Forms;


namespace TrackerClientEmulator.Views
{
    public partial class NavigationItem
    {
        #region Fields
        public static readonly BindableProperty ContentPageViewModelProperty = BindableProperty.Create(
            nameof(ContentPageViewModel),
            typeof(BasePageViewModel),
            typeof(NavigationItem),
            null,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationItem)bindable;
                ctrl.ContentPageViewModel = (BasePageViewModel)newValue;
            });


        //public static new readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
        //    nameof(BackgroundColor),
        //    typeof(Color),
        //    typeof(NavigationItem),
        //    Color.Yellow, //TODO: Set normal default value!
        //    propertyChanging: (bindable, oldValue, newValue) =>
        //    {
        //        var ctrl = (NavigationItem)bindable;
        //        ctrl.BackgroundColor = (Color)newValue;
        //    });


        public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(
            nameof(IsActive),
            typeof(bool),
            typeof(NavigationItem),
            false,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationItem)bindable;
                ctrl.IsActive = (bool)newValue;
            });


        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(string),
            typeof(NavigationItem),
            string.Empty,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationItem)bindable;
                ctrl.CommandParameter = (string)newValue;
            });

        public static readonly BindableProperty IconProperty = BindableProperty.Create(
            nameof(Icon),
            typeof(string),
            typeof(NavigationItem),
            string.Empty,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationItem)bindable;
                ctrl.Icon = (string)newValue;
            });

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(NavigationItem),
            string.Empty,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationItem)bindable;
                ctrl.Title = (string)newValue;
            });

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(NavigationItem),
            null,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationItem)bindable;
                ctrl.Command = (ICommand)newValue;
            });

        private ICommand _command;

        private string _commandParameter;

        private string _icon;

        private string _title;

       // private Color _backgroundColor;

        private bool _isActive;

        private BasePageViewModel _contentPageViewModel;
        #endregion


        #region Constructors
        public NavigationItem()
        {
            InitializeComponent();
        }

        public NavigationItem(BasePageViewModel pageViewModel)
        {
            InitializeComponent();

            Title = pageViewModel.Title;
            Command = pageViewModel.PageNavigationCommand;
            ContentPageViewModel = pageViewModel;
            BackgroundColor = Color.Green;
        }
        #endregion


        #region Properties

        //public new Color BackgroundColor
        //{
        //    get { return _backgroundColor; }
        //    set
        //    {
        //        _backgroundColor = value;
        //        OnPropertyChanged();
        //    }
        //}

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


        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
           BackgroundColor = Color.Brown;
        }
    }
}
