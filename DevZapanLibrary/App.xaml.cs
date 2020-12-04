using DevZapanLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ZapanControls.Databases.ODBC;

namespace DevZapanLibrary
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public OdbcDatabase Database { get; private set; }

        public ObservableCollection<TypologieModel> Typologies { get; private set; }
        public ObservableCollection<MediaModel> Medias { get; private set; }
        public ObservableCollection<FrequenceModel> Frequences { get; private set; }
        public ObservableCollection<GraviteModel> Gravites { get; private set; }
        public ObservableCollection<QualificationModel> Qualifications { get; private set; }
        public ObservableCollection<UserModel> Users { get; private set; }
        public ObservableCollection<ClientModel> Clients { get; set; }

        public List<string> Services
        {
            get { return new List<string>() { "", "Administratif", "Commercial", "Technique" }; }
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            Database = new OdbcDatabase("OCEATECH_TEST", "sa", "D4silv499");

            Typologies = new ObservableCollection<TypologieModel>(await Database.ProcedureExecuteReaderAsync(r => new TypologieModel(r), "OCEA_CRM_LISTE_TYPOLOGIE"));
            Medias = new ObservableCollection<MediaModel>(await Database.ProcedureExecuteReaderAsync(r => new MediaModel(r), "OCEA_CRM_LISTE_MEDIA"));
            Medias.Insert(0, new MediaModel() { N_Media = -1, Nom = string.Empty });
            Frequences = new ObservableCollection<FrequenceModel>(await Database.ProcedureExecuteReaderAsync(r => new FrequenceModel(r), "OCEA_CRM_LISTE_FREQUENCE"));
            Frequences.Insert(0, new FrequenceModel() { N_Frequence = -1, Nom = string.Empty });
            Gravites = new ObservableCollection<GraviteModel>(await Database.ProcedureExecuteReaderAsync(r => new GraviteModel(r), "OCEA_CRM_LISTE_GRAVITE"));
            Gravites.Insert(0, new GraviteModel() { N_Gravite = -1, Nom = string.Empty });
            Qualifications = new ObservableCollection<QualificationModel>(await Database.ProcedureExecuteReaderAsync(r => new QualificationModel(r), "OCEA_CRM_LISTE_QUALIFICATION"));
            Users = new ObservableCollection<UserModel>(await Database.ProcedureExecuteReaderAsync(r => new UserModel(r), "OCEA_CRM_LISTE_USER"));
            Clients = new ObservableCollection<ClientModel>(await Database.ProcedureExecuteReaderAsync(r => new ClientModel(r), "OCEA_CRM_LISTE_CLIENT"));

            base.OnStartup(e);  
        }

    }
}
