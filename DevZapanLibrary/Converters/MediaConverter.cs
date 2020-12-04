using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using ZapanControls.Converters;

namespace DevZapanLibrary.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class MediaConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int n_media = (int)value;

            if (n_media > 0)
                return ((App)Application.Current).Medias.FirstOrDefault(m => m.N_Media == n_media).Nom;
            else
                return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
