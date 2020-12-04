using DevZapanLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ZapanControls.Converters;

namespace DevZapanLibrary.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class QualificationConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var task = Task.Run(async () =>
            {
                QualificationModel qualif = await ((App)Application.Current).Database
                    .ProcedureExecuteReaderAsyncSingleResult(r => new QualificationModel(r), "OCEA_CRM_SELECT_QUALIFICATION",
                    new Dictionary<string, object>() { { "@N_Qualification", value } });

                return qualif != null ? qualif.Nom : (new QualificationModel()).Nom;
            });
            return task.Result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
