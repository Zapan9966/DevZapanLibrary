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
    public class ClientNomUsageConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ClientModel client = ((App)Application.Current).Clients.Where(c => c.N_Client == (int)value).FirstOrDefault();
            return client != null ? client.Nom_Usage : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
