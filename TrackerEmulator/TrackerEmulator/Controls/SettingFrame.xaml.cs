using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackerEmulator.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingFrame : Frame
    {
        public static readonly BindableProperty PopupMenuProperty =
            BindableProperty.Create(
                nameof(PopupMenu),
                typeof(ContentView),
                typeof(SettingFrame),
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (SettingFrame)bindable;
                    ctrl.PopupMenu = (ContentView) newValue;
                }
                );

        private ContentView _popupMenu;

        public SettingFrame()
        {
            InitializeComponent();
        }

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
    }
}
