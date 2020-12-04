using System.Data.Common;
using ZapanControls.Databases;

namespace DevZapanLibrary.Models
{
    public class TypologieModel : ModelBase<TypologieModel>
    {
        #region Variables

        private int _n_typologie = 0;
        private string _nom = string.Empty;
        private string _service = string.Empty;
        private string _actif = string.Empty;

        #endregion

        #region Properties

        public int N_Typologie
        {
            get { return _n_typologie; }
            set { Set(ref _n_typologie, value); }
        }

        public string Nom
        {
            get { return _nom; }
            set { Set(ref _nom, value); }
        }

        public string Service
        {
            get { return _service; }
            set { Set(ref _service, value); }
        }

        public string Actif
        {
            get { return _actif; }
            set { Set(ref _actif, value); }
        }

        #endregion

        #region Constructors

        public TypologieModel() { }
        public TypologieModel(DbDataReader reader) : base(reader) { }

        #endregion
    }
}
