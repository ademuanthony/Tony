using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Tony.Common.Infrastructure.Converters
{
    public class BoolToVissibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((bool?)value)
            {
                case true:
                    return Visibility.Visible; 
                case false:
                    return Visibility.Hidden;
                default:
                    return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Visibility)value)
            {
                case Visibility.Hidden:
                    return false;
                case Visibility.Visible:
                    return true;
                default :
                    return null;
            }
        }
    }
}
