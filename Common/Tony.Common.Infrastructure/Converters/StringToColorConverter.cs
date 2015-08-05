using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Tony.Common.Infrastructure.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
            }
            catch
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000"));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
