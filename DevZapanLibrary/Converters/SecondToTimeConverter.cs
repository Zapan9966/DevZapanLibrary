using System;
using System.Globalization;
using System.Windows.Data;
using ZapanControls.Converters;

namespace DevZapanLibrary.Converters
{
    [ValueConversion(typeof(double), typeof(string))]
    public class SecondToTimeConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = "00:00:00";

            if (value != null)
            {
                TimeSpan t = TimeSpan.FromSeconds((double)value);
                if (parameter is String)
                    text = t.ToString(parameter.ToString());
                else
                    text = String.Format("{0}:{1}:{2}", (int)t.TotalHours > 9 ? ((int)t.TotalHours).ToString() : "0" + ((int)t.TotalHours).ToString(), 
                        t.Minutes > 9 ? t.Minutes.ToString() : "0" + t.Minutes.ToString(),
                        t.Seconds > 9 ? t.Seconds.ToString() : "0" + t.Seconds.ToString());
            }
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double seconds = 0;

            if (value != null)
                seconds = TimeSpan.Parse((string)value).TotalSeconds;

            return seconds;
        }
    }
}
