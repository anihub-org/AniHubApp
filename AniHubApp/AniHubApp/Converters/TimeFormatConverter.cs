using System;
using System.Globalization;
using Xamarin.Forms;

namespace AniHubApp.Converters
{
    public class TimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var MillisecondsDuration = System.Convert.ToDouble(value);
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(MillisecondsDuration);

            return string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
