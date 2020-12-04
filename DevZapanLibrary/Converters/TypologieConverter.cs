using DevZapanLibrary.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using ZapanControls.Converters;

namespace DevZapanLibrary.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class TypologieConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EchangeModel echange)
            {
                if (echange.N_Typologie > 0)
                    return ((App)Application.Current).Typologies.Where(t => t.N_Typologie == echange.N_Typologie).FirstOrDefault().Nom;
            }
            else if (value is int n_typologie)
            {
                if (n_typologie > 0)
                    return ((App)Application.Current).Typologies.Where(t => t.N_Typologie == n_typologie).FirstOrDefault().Nom;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
