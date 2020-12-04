using DevZapanLibrary.Converters;
using System;
using System.ComponentModel;
using System.Data.Common;
using System.Globalization;
using ZapanControls.Databases;

namespace DevZapanLibrary.Models
{
    public class ActionModel : ModelBase<ActionModel>, IDataErrorInfo
    {
        #region Variables

        private bool _isEnabled = false;
        private int _nb_conversations = 0;
        private int _nb_piecesjointes = 0;

        private int _n_action = 0;
        private DateTime _date = DateTime.Now;
        private int _n_media = -1;
        private string _contactClient = string.Empty;
        private int _n_utilisateur = 0;
        private string _transfert = "Non";
        private int _n_userTransfert = -1;
        private string _action = string.Empty;
        private double _duree = 0;
        private string _telemaintenance = "Non";
        private int _n_echange = 0;
        private string _echange = string.Empty;
        private DateTime? _dateTelemaintenance = null;
        private string _contactFournisseur = string.Empty;
        private string _rappelClient = string.Empty;
        private double _dureeTrajet = 0;
        private DateTime? _heureDebut = new DateTime(2000, 01, 01, 0, 0, 0);
        private DateTime? _heureFin = new DateTime(2000, 01, 01, 0, 0, 0);
        private double _dureeIntervention = 0;
        private string _decomptePackHeure = string.Empty;

        #endregion

        #region Properties

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { Set(ref _isEnabled, value); }
        }

        public int Nb_Conversations
        {
            get { return _nb_conversations; }
            set { Set(ref _nb_conversations, value); }
        }

        public int Nb_PiecesJointes
        {
            get { return _nb_piecesjointes; }
            set { Set(ref _nb_piecesjointes, value); }
        }

        public int N_Action
        {
            get { return _n_action; }
            set { Set(ref _n_action, value); }
        }

        public DateTime Date
        {
            get { return _date; }
            set { Set(ref _date, value); }
        }

        public int N_Media
        {
            get { return _n_media; }
            set
            {
                Set(ref _n_media, value);

                RaisePropertyChanged("Date");
                RaisePropertyChanged("HeureDebut");
                RaisePropertyChanged("HeureFin");
                RaisePropertyChanged("DureeIntervention");
            }
        }

        public string ContactClient
        {
            get { return _contactClient; }
            set
            {
                Set(ref _contactClient, value);
                RaisePropertyChanged("ContactFournisseur");
            }
        }

        public int N_Utilisateur
        {
            get { return _n_utilisateur; }
            set { Set(ref _n_utilisateur, value); }
        }

        public string Transfert
        {
            get { return _transfert; }
            set
            {
                Set(ref _transfert, value);

                if (_transfert == "Oui" && Action == string.Empty)
                    Action = "transfert";
                else if (_transfert == "Non" && Action == "transfert")
                    Action = string.Empty;
            }
        }

        public int N_UserTransfert
        {
            get { return _n_userTransfert; }
            set { Set(ref _n_userTransfert, value); }
        }

        public string Action
        {
            get { return _action; }
            set
            {
                Set(ref _action, value);
            }
        }

        public double Duree
        {
            get { return _duree; }
            set { Set(ref _duree, value); }
        }

        public string Telemaintenance
        {
            get { return _telemaintenance; }
            set
            {
                Set(ref _telemaintenance, value);

                if (_telemaintenance == "Oui")
                    DateTelemaintenance = DateTime.Now;
                else
                    DateTelemaintenance = null;
            }
        }

        public int N_Echange
        {
            get { return _n_echange; }
            set { Set(ref _n_echange, value); }
        }

        public string Echange
        {
            get { return _echange; }
            set
            {
                Set(ref _echange, value);
                RaisePropertyChanged("DureeTrajet");
            }
        }

        public DateTime? DateTelemaintenance
        {
            get { return _dateTelemaintenance; }
            set { Set(ref _dateTelemaintenance, value); }
        }

        public string ContactFournisseur
        {
            get { return _contactFournisseur; }
            set
            {
                Set(ref _contactFournisseur, value);
                RaisePropertyChanged("ContactClient");
            }
        }

        public string RappelClient
        {
            get { return _rappelClient; }
            set { Set(ref _rappelClient, value); }
        }

        public double DureeTrajet
        {
            get { return _dureeTrajet; }
            set { Set(ref _dureeTrajet, value); }
        }

        public DateTime? HeureDebut
        {
            get { return _heureDebut; }
            set { Set(ref _heureDebut, value); }
        }

        public DateTime? HeureFin
        {
            get { return _heureFin; }
            set { Set(ref _heureFin, value); }
        }

        public double DureeIntervention
        {
            get { return _dureeIntervention; }
            set { Set(ref _dureeIntervention, value); }
        }

        public string DecomptePackHeure
        {
            get { return _decomptePackHeure; }
            set { Set(ref _decomptePackHeure, value); }
        }

        #endregion

        #region Constructors

        public ActionModel() { }
        public ActionModel(DbDataReader reader) : base(reader) { }

        #endregion

        #region IDataErrorInfo Implementation

        public override string this[string columnName]
        {
            get
            {
                MediaConverter mediaConverter = new MediaConverter();
                string media = mediaConverter.Convert(this.N_Media, typeof(string), null, CultureInfo.CurrentCulture).ToString();
                string heure = string.Empty;

                switch (columnName)
                {
                    case "Date":
                        if (Date == null)
                            return " - Veuillez sélectionner la date de l'action.\r\n";
                        break;
                    case "ContactFournisseur":
                    case "ContactClient":
                        if ((ContactClient == null || ContactClient == string.Empty)
                            && (ContactFournisseur == null || ContactFournisseur == string.Empty))
                            return " - Veuillez sélectionner un ou plusieurs contact client ou contact fournisseur.\r\n";
                        break;
                    case "Action":
                        if (Action == null || Action == string.Empty)
                        {
                            if (RappelClient == "Oui")
                                return " - Indiquer vers quelle heure le client compte rappeler ou si un RDV fixe a été convenu.\r\n";
                            else
                                return " - Veuillez décrire les actions effectuées.\r\n";
                        }
                        break;
                    case "Echange":
                        if (Echange == null || Echange == string.Empty)
                            return " - Veuillez sélectionner un type d'échange.\r\n";
                        break;
                    case "N_Media":
                        if (N_Media <= 0)
                            return " - Veuillez sélectionner un type de média.\r\n";
                        break;
                    // Cas pour les interventions physique
                    case "HeureDebut":
                        heure = HeureDebut.HasValue ? HeureDebut.Value.ToString("HH:mm") : "00:00";
                        if (media == "Physique" && heure == "00:00")
                            return " - Veuillez saisir l'heure de début d'intervention.\r\n";
                        break;
                    case "HeureFin":
                        heure = HeureFin.HasValue ? HeureFin.Value.ToString("HH:mm") : "00:00";
                        if (media == "Physique" && heure == "00:00")
                            return " - Veuillez saisir l'heure de fin d'intervention.\r\n";
                        break;
                    case "DureeTrajet":
                        if (media == "Physique" && Echange == "Sortant" && DureeTrajet == 0)
                            return " - Veuillez saisir la durée de trajet.\r\n";
                        break;
                    case "DureeIntervention":
                        if (media == "Physique" && DureeIntervention == 0)
                            return " - Veuillez saisir la durée d'intervention.\r\n";
                        break;
                }
                return null;
            }
        }

        #endregion
    }
}
