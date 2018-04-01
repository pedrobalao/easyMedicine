using System;
using System.Globalization;
using Xamarin.Forms;

namespace easyMedicine.Core.Converters
{
    public class UnitVariableString : IValueConverter
    {
        public UnitVariableString()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((string)value).Equals("NA"))
            {
                return String.Empty;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
