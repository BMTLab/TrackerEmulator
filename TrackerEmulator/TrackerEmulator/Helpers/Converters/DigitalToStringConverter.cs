//      TrackerEmulator.TrackerEmulator
//      Created by Nikita Neverov at 29.08.2019 14:35

using System;
using System.Globalization;
using Xamarin.Forms;

namespace TrackerEmulator.Helpers.Converters
{
    public class DigitalToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isDigital = value is sbyte
                            || value is byte
                            || value is short
                            || value is ushort
                            || value is int
                            || value is uint
                            || value is long
                            || value is ulong
                            || value is float
                            || value is double
                            || value is decimal;

            return isDigital
                ? value.ToString()
                : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object result = 0;
            try
            {
                result = System.Convert.ChangeType(value, targetType);
            }
            catch
            {
                ;
            }
            return result;
        }
    }
}
