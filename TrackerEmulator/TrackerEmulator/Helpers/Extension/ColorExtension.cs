using Xamarin.Forms;

namespace TrackerEmulator.Helpers.Extension
{
    public static class ColorExtension
    {
        public static Color Primary(this Color @this)
        {
            return (Color) Application.Current.Resources[nameof(Primary)];
        }

        public static Color PrimaryDark(this Color @this)
        {
            return (Color)Application.Current.Resources[nameof(PrimaryDark)];
        }

        public static Color LightBackgroundColor(this Color @this)
        {
            return (Color)Application.Current.Resources[nameof(LightBackgroundColor)];
        }

        public static Color DarkBackgroundColor(this Color @this)
        {
            return (Color)Application.Current.Resources[nameof(LightBackgroundColor)];
        }

        public static Color LightTextColor(this Color @this)
        {
            return (Color)Application.Current.Resources[nameof(LightTextColor)];
        }

        public static Color RedTextColor(this Color @this)
        {
            return (Color)Application.Current.Resources[nameof(RedTextColor)];
        }

        public static Color DarkTextColor(this Color @this)
        {
            return (Color)Application.Current.Resources[nameof(DarkTextColor)];
        }
    }
}
