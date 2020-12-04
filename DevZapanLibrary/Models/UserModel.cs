using System.Data.Common;
using ZapanControls.Databases;

namespace DevZapanLibrary.Models
{
    public class UserModel : ModelBase<UserModel>
    {
        #region Variables

        private int _n_user = 0;
        private string _login = string.Empty;
        private string _nom = string.Empty;
        private string _prenom = string.Empty;
        private string _admin = string.Empty;
        private string _email = string.Empty;
        private string _initiales = string.Empty;
        private string _service = string.Empty;

        #endregion

        #region Properties

        public int N_User
        {
            get { return _n_user; }
            set { Set(ref _n_user, value); }
        }

        public string Login
        {
            get { return _login; }
            set { Set(ref _login, value); }
        }

        public string Nom
        {
            get { return _nom; }
            set { Set(ref _nom, value); }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { Set(ref _prenom, value); }
        }

        public string Admin
        {
            get { return _admin; }
            set { Set(ref _admin, value); }
        }

        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        public string Initiales
        {
            get { return _initiales; }
            set { Set(ref _initiales, value); }
        }

        public string Service
        {
            get { return _service; }
            set { Set(ref _service, value); }
        }

        #endregion

        #region Constructors

        public UserModel() { }
        public UserModel(DbDataReader reader) : base(reader) { }

        #endregion
    }
}
