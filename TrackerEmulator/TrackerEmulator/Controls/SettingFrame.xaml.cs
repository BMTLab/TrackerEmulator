using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TrackerEmulator.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingFrame : Frame
    {
        #region Constructors
        public SettingFrame()
        {
            InitializeComponent();
        }
        #endregion


        #region Methods
        private void AddPopupHandler()
        {
            var isPrimary = true;
            var (popup, grid) = (PopupMenu, SettingGrid);

            grid.RowDefinitions[1].Height = 0;
            popup.ScaleY = 0;

            var tapGestureRecognizer = new TapGestureRecognizer();

            tapGestureRecognizer.Tapped += (_, e) =>
            {
                if (isPrimary)
                {
                    grid.RowDefinitions[1].Height = popup.HeightRequest;
                    popup.ScaleY = 1;
                }
                else
                {
                    grid.RowDefinitions[1].Height = 0;
                    popup.ScaleY = 0;
                }

                isPrimary = !isPrimary;
                HasShadow = !isPrimary;
            };

            GestureRecognizers.Add(tapGestureRecognizer);
        }
        #endregion


        #region Fields
        #region Fields.BindableProperties
        public static readonly BindableProperty PopupMenuProperty =
            BindableProperty.Create(
                nameof(PopupMenu),
                typeof(VisualElement),
                typeof(SettingFrame),
                propertyChanging: (bindable, _, newValue) =>
                {
                    var ctrl = (SettingFrame) bindable;
                    ctrl.PopupMenu = (VisualElement) newValue;
                }
            );

        public static readonly BindableProperty ContentMenuProperty =
            BindableProperty.Create(
                nameof(ContentMenu),
                typeof(VisualElement),
                typeof(SettingFrame),
                propertyChanging: (bindable, _, newValue) =>
                {
                    var ctrl = (SettingFrame) bindable;
                    ctrl.ContentMenu = (VisualElement) newValue;
                }
            );
        #endregion


        private VisualElement _popupMenu;
        private VisualElement _contentMenu;
        #endregion


        #region Properties
        public VisualElement PopupMenu
        {
            get => _popupMenu;
            set
            {
                if (value == null)
                    return;

                _popupMenu = value;
                AddPopupHandler();
                OnPropertyChanged();
            }
        }

        public VisualElement ContentMenu
        {
            get => _contentMenu;
            set
            {
                if (value == null)
                    return;

                _contentMenu = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}