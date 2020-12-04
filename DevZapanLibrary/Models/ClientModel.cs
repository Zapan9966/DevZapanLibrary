using System;
using System.ComponentModel;
using System.Data.Common;
using ZapanControls.Databases;

namespace DevZapanLibrary.Models
{
    public class ClientModel : ModelBase<ClientModel>, IDataErrorInfo
    {
        #region Variables

        private int _n_liaison = 0;
        private int _n_client = 0;
        private int _n_clientAdr = 0;
        private string _civilite = string.Empty;
        private string _nom_client = string.Empty;
        private string _prenom_client = string.Empty;
        private string _specialite = string.Empty;
        private string _nom_usage = string.Empty;
        private string _lieu = string.Empty;
        private string _adresse1 = string.Empty;
        private string _adresse2 = string.Empty;
        private string _adresse3 = string.Empty;
        private string _nom_ville = string.Empty;
        private string _code_postal = string.Empty;
        private string _email = string.Empty;
        private string _standard = string.Empty;
        private string _portable = string.Empty;
        private string _famille = string.Empty;
        //private string _livraison = string.Empty;
        private string _contrat = string.Empty;
        private string _packHeure = "Non";
        private int _soldePackHeure = 0;
        private DateTime? _echeancePackHeure = null;
        private string _siteActif = "Oui";

        #endregion

        #region Properties

        public int N_Liaison
        {
            get { return _n_liaison; }
            set { Set(ref _n_liaison, value); }
        }

        public int N_Client
        {
            get { return _n_client; }
            set { Set(ref _n_client, value); }
        }

        public int N_ClientAdr
        {
            get { return _n_clientAdr; }
            set { Set(ref _n_clientAdr, value); }
        }

        public string Civilite
        {
            get { return _civilite; }
            set { Set(ref _civilite, value); }
        }

        public string Nom_Client
        {
            get { return _nom_client; }
            set { Set(ref _nom_client, value); }
        }

        public string Prenom_Client
        {
            get { return _prenom_client; }
            set { Set(ref _prenom_client, value); }
        }

        public string Specialite
        {
            get { return _specialite; }
            set { Set(ref _specialite, value); }
        }

        public string Nom_Usage
        {
            get { return _nom_usage; }
            set { Set(ref _nom_usage, value); }
        }

        public string Lieu
        {
            get { return _lieu; }
            set { Set(ref _lieu, value); }
        }

        public string Adresse1
        {
            get { return _adresse1; }
            set { Set(ref _adresse1, value); }
        }

        public string Adresse2
        {
            get { return _adresse2; }
            set { Set(ref _adresse2, value); }
        }

        public string Adresse3
        {
            get { return _adresse3; }
            set { Set(ref _adresse3, value); }
        }

        public string Nom_Ville
        {
            get { return _nom_ville; }
            set { Set(ref _nom_ville, value); }
        }

        public string Code_Postal
        {
            get { return _code_postal; }
            set { Set(ref _code_postal, value); }
        }

        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        public string Standard
        {
            get { return _standard; }
            set { Set(ref _standard, value); }
        }

        public string Portable
        {
            get { return _portable; }
            set { Set(ref _portable, value); }
        }

        public string Famille
        {
            get { return _famille; }
            set { Set(ref _famille, value); }
        }

        //public string Livraison
        //{
        //    get { return _livraison; }
        //    set { Set(ref _livraison, value); }
        //}

        public string Contrat
        {
            get { return _contrat; }
            set { Set(ref _contrat, value); }
        }

        public string PackHeure
        {
            get { return _packHeure; }
            set { Set(ref _packHeure, value); }
        }

        public int SoldePackHeure
        {
            get { return _soldePackHeure; }
            set { Set(ref _soldePackHeure, value); }
        }

        public DateTime? EcheancePackHeure
        {
            get { return _echeancePackHeure; }
            set { Set(ref _echeancePackHeure, value); }
        }

        public string SiteActif
        {
            get { return _siteActif; }
            set { Set(ref _siteActif, value); }
        }

        #endregion

        #region Constructors

        public ClientModel() { }
        public ClientModel(DbDataReader reader) : base(reader) { }

        #endregion

        #region Implementation IDataErrorInfo

        public new string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Nom_Client":
                        if (Nom_Client == null || Nom_Client == string.Empty)
                            return " - Veuillez entrer un nom le nom du client.\r\n";
                        break;
                    case "Adresse1":
                        if (Adresse1 == null || Adresse1 == string.Empty)
                            return " - Veuillez entrer l'adresse du client.\r\n";
                        break;
                    case "Code_Postal":
                        if (Code_Postal == null || Code_Postal == string.Empty)
                            return " - Veuillez entrer le code postal.\r\n";
                        break;
                    case "Nom_Ville":
                        if (Nom_Ville == null || Nom_Ville == string.Empty)
                            return " - Veuillez entrer la ville.\r\n";
                        break;
                    case "Email":
                        if (Email == null || Email == string.Empty)
                            return " - Veuillez entrer l'adresse mail du client.\r\n";
                        break;
                    case "Standard":
                        if (Standard == null || Standard == string.Empty)
                            return " - Veuillez entrer le n° du standard du client.\r\n";
                        break;
                }
                return null;
            }
        }

        #endregion
    }
}
