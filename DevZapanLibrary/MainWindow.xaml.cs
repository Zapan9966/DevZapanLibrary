using DevZapanLibrary.Converters;
using DevZapanLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ZapanControls.Controls;
using ZapanControls.Databases.ODBC;
using ZapanControls.Libraries;

namespace DevZapanLibrary
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ZapWindow
    {
        private readonly BackgroundWorker _filterWorker;

        public bool Test { get; set; } = true;

        private AsyncObservableCollection<object> _echanges;

        public AsyncObservableCollection<object> Echanges
        {
            get { return _echanges; }
            set { Set(ref _echanges, value); }
        }

        public List<string> Services
        {
            get { return ((App)Application.Current).Services; }
        }

        public ObservableCollection<TypologieModel> Typologies
        {
            get { return ((App)Application.Current).Typologies; }
        }

        public ObservableCollection<UserModel> Users
        {
            get { return ((App)Application.Current).Users; }
        }

        public MainWindow()
        {
            //Echanges = new AsyncObservableCollection<object>()
            //{
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //    new EchangeModel { Service = "Technique", Titre = "Test", DateCreation = DateTime.Now },
            //};

            InitializeComponent();

            // Worker de recherche des échanges
            _filterWorker = new BackgroundWorker();
            _filterWorker.DoWork += EchangeFilterWorker;

            var t = new ZapScrollBar();
            t.Orientation = Orientation.Vertical;


            //dgEchanges.Filtering += () => { return _filterWorker; };
            //lvEchanges.Filtering += () => { return _filterWorker; };

            //Task.Run(async () =>
            //{
            //    Dispatcher.Invoke(() => { dgEchanges.ToggleLoadingScreen(true); });

            //    Echanges = new AsyncObservableCollection<object>(
            //        await (((App)Application.Current).Database).ExecuteReaderAsync(ech => new EchangeModel(ech), "EXEC OCEA_CRM_LISTE_ECHANGE"));

            //    Dispatcher.Invoke(() => { dgEchanges.ToggleLoadingScreen(); });
            //});


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //dgEchanges.FilterDataGrid();
            //lvEchanges.FilterListView();
        }

        public async void EchangeFilterWorker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            List<object> args = (List<object>)e.Argument;
            Dictionary<string, KeyValuePair<object, IValueConverter>> filters = (Dictionary<string, KeyValuePair<object, IValueConverter>>)args[0];
            bool replace = (bool)args[1];

            AsyncObservableCollection<object> echanges = new AsyncObservableCollection<object>();
            List<OdbcParameter> parameters = new List<OdbcParameter>();

            string query = "EXEC OCEA_CRM_LISTE_ECHANGE";

            if (filters != null)
            {
                if (filters.Count > 0)
                {
                    int count = 0;
                    foreach (KeyValuePair<string, KeyValuePair<object, IValueConverter>> filter in filters)
                    {
                        if (worker.CancellationPending)
                            break;

                        if (filter.Value.Key != null)
                        {
                            if (filter.Value.Key.ToString() == string.Empty)
                                continue;

                            if (count > 0)
                                query += ",";

                            if (filter.Value.Value is ClientNomUsageConverter)
                                query += " @NomUsage=?";
                            else
                                query += replace ? " @" + Regex.Replace(filter.Key.Replace("N_", ""), "[0-9]", string.Empty) + "=?" : " @" + filter.Key + "=?";

                            parameters.Add(new OdbcParameter()
                            {
                                Value = filter.Key == "Titre" || filter.Key == "N_Client" || filter.Key == "N_SiteClient" || filter.Key == "ActionsContiennent" || filter.Key == "ClientNomUsageSite" ?
                                    filter.Value.Key.ToString().Replace("'", "''") : filter.Value.Key.ToString()
                            });

                            count++;
                        }
                    }
                }
            }

            //echanges = new AsyncObservableCollection<object>(await (((App)Application.Current).Database).ExecuteReaderAsync(r => new EchangeModel(r), query, parameters));

            if (worker.CancellationPending)
                e.Cancel = true;
            else
                e.Result = echanges;
        }

    }
}
