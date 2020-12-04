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
    public class ClientConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ClientModel client = null;

            if (value is int n_client)
            {
                client = ((App)Application.Current).Clients.FirstOrDefault(c => c.N_Client == (int)value);
            }
            else if (value is EchangeModel echange)
            {
                client = ((App)Application.Current).Clients.FirstOrDefault(c => c.N_Client == echange.N_Client);
            }

            return client != null ? client.Nom_Client + " " + client.Prenom_Client : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
