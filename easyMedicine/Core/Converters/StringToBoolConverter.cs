using System;
using System.Globalization;
using Xamarin.Forms;

namespace easyMedicine.Core.Converters
{
    public class StringToBoolConverter : IValueConverter
    {
        public StringToBoolConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return false;
            }

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
