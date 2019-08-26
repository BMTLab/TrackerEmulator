using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackerEmulator.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingFrame : Frame
    {
        public static readonly BindableProperty PopupMenuProperty =
            BindableProperty.Create(nameof(PopupMenu),
                                    typeof(ContentView),
                                    typeof(ContentView));

        internal SettingFrame()
        {
            InitializeComponent();

            PopupMenu = new PopupMenuIp();

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
            };

            GestureRecognizers.Add(tapGestureRecognizer);
        }

        public ContentView PopupMenu
        {
            get => (ContentView)GetValue(PopupMenuProperty);
            set => SetValue(PopupMenuProperty, value);
        }
    }
}
