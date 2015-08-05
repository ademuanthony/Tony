using System;
using System.Globalization;
using System.Windows.Data;

namespace Tony.Common.Infrastructure.Converters
{
    public class TimeStampToDateConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var timeStamp = (long)value;
                var ts = new TimeStamp(timeStamp);
                return ts.Date;
            }
            catch
            {
                return new DateTime();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var dt = (DateTime)value;
                var ts = new TimeStamp(dt);
                return ts.ToLong();
            }
            catch
            {
                return new TimeStamp(new DateTime()).ToLong();
            }
        }
    }

    public class TimeStampToDateStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var timeStamp = (long)value;
                var ts = new TimeStamp(timeStamp);
                return ts.Date.ToShortDateString();
            }
            catch
            {
                return new DateTime().ToShortDateString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TimeStampToTimeStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var timeStamp = (long)value;
                var ts = new TimeStamp(timeStamp);
                return ts.Date.ToLongTimeString();
            }
            catch
            {
                return new DateTime().ToLongTimeString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
