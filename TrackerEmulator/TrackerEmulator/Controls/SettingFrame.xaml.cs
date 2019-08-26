using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackerEmulator.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingFrame : Frame
    {
        #region Fields
        #region Fields.BindableProperties
        public static readonly BindableProperty PopupMenuProperty =
            BindableProperty.Create(
                nameof(PopupMenu),
                typeof(ContentView),
                typeof(SettingFrame),
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (SettingFrame)bindable;
                    ctrl.PopupMenu = (ContentView)newValue;
                }
            );
        #endregion

        private ContentView _popupMenu;
        #endregion


        #region Constructors
        public SettingFrame()
        {
            InitializeComponent();
        }
        #endregion


        #region Properties
        public ContentView PopupMenu
        {
            get => _popupMenu;
            set
            {
                _popupMenu = value;
                AddPopupHandler();
                OnPropertyChanged();
            }
        }
        #endregion


        #region Methods
        private void AddPopupHandler()
        {
            var (primary, popup) = (Content, PopupMenu);

            var isPrimary = true;

            var tapGestureRecognizer = new TapGestureRecognizer();

            tapGestureRecognizer.Tapped += (_, e) =>
            {
                if (isPrimary)
                {
                    primary = Content;
                    Content = popup;
                }
                else
                {
                    Content = primary;
                }

                isPrimary = !isPrimary;
                HasShadow = !isPrimary;
            };

            GestureRecognizers.Add(tapGestureRecognizer);
        }
        #endregion
    }
}
