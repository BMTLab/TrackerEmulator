//      TrackerEmulator.TrackerEmulator
//      Created by Nikita Neverov at 29.08.2019 14:35

using System;
using System.Globalization;
using System.Net;

using Xamarin.Forms;


namespace TrackerEmulator.Helpers.Converters
{
    public class IpAddressToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IPAddress address)
                return address.ToString();

            return string.Empty;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !IPAddress.TryParse(value as string ?? string.Empty, out var ip)
                ? null
                : ip;
        }
    }
}