using System;
using System.ComponentModel;
using System.Data.Common;
using ZapanControls.Databases;

namespace DevZapanLibrary.Models
{
    public class EchangeModel : ModelBase<EchangeModel>, IDataErrorInfo
    {
        #region Variables

        private int _n_echange = 0;
        private string _service = string.Empty;
        private DateTime _dateCreation = DateTime.Now;
        private DateTime? _dateCloture = null;
        private double _dureeTotale = 0;
        private int _n_qualification = -1;
        private string _titre = string.Empty;
        private int _n_client = 0;
        private int _n_typologie = -1;
        private int _n_siteClient = -1;
        private string _infoBulle = string.Empty;
        private string _initialesDernierUtilisateur = string.Empty;
        private DateTime? _dateDernierContact = null;
        private int _nombreActions = 0;

        #endregion

        #region Properties

        public int N_Echange
        {
            get { return _n_echange; }
            set { Set(ref _n_echange, value); }
        }

        public string Service
        {
            get { return _service; }
            set { Set(ref _service, value); }
        }

        public DateTime DateCreation
        {
            get { return _dateCreation; }
            set { Set(ref _dateCreation, value); }
        }

        public DateTime? DateCloture
        {
            get { return _dateCloture; }
            set { Set(ref _dateCloture, value); }
        }

        public double DureeTotale
        {
            get { return _dureeTotale; }
            set { Set(ref _dureeTotale, value); }
        }

        public int N_Qualification
        {
            get { return _n_qualification; }
            set { Set(ref _n_qualification, value); }
        }

        public string Titre
        {
            get { return _titre; }
            set { Set(ref _titre, value); }
        }

        public int N_Client
        {
            get { return _n_client; }
            set { Set(ref _n_client, value); }
        }

        public int N_Typologie
        {
            get { return _n_typologie; }
            set { Set(ref _n_typologie, value); }
        }

        public int N_SiteClient
        {
            get { return _n_siteClient; }
            set { Set(ref _n_siteClient, value); }
        }

        public string InfoBulle
        {
            get { return _infoBulle; }
            set { Set(ref _infoBulle, value); }
        }

        public string InitialesDernierUtilisateur
        {
            get { return _initialesDernierUtilisateur; }
            set { Set(ref _initialesDernierUtilisateur, value); }
        }

        public DateTime? DateDernierContact
        {
            get { return _dateDernierContact; }
            set { Set(ref _dateDernierContact, value); }
        }

        public int NombreActions
        {
            get { return _nombreActions; }
            set { Set(ref _nombreActions, value); }
        }

        #endregion

        #region Constructors

        public EchangeModel() { }
        public EchangeModel(DbDataReader reader) : base(reader) { }

        #endregion

        #region IDataErrorInfo Implementation

        public new string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Service":
                        if (Service == null || Service == string.Empty)
                            return " - Veuillez sélectionner un service.\r\n";
                        break;
                    case "N_Qualification":
                        if (N_Qualification <= 0)
                            return " - Veuillez sélectionner une qualification.\r\n";
                        break;
                    case "Titre":
                        if (Titre == null || Titre == string.Empty)
                            return " - Veuillez entrer un titre pour cet échange.\r\n";
                        break;
                    case "N_Typologie":
                        if (N_Typologie <= 0)
                            return " - Veuillez sélectionner une typologie.\r\n";
                        break;
                    case "N_SiteClient":
                        if (N_SiteClient <= 0)
                            return " - Veuillez sélectionner un site client.\r\n";
                        break;
                }
                return null;
            }
        }

        #endregion
    }
}
