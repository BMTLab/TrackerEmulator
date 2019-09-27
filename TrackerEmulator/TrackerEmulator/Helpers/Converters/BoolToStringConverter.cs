//      TrackerEmulator.TrackerEmulator
//      Created by Nikita Neverov at 29.08.2019 14:35

using System;
using System.Globalization;

using Xamarin.Forms;


namespace TrackerEmulator.Helpers.Converters
{
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isBool = value is bool;

            return isBool
                ? value.ToString()
                : string.Empty;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string o)
            {
                return o == "true";
            }

            return false;
        }
    }
}