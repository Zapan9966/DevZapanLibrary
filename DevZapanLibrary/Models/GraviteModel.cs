using System.Data.Common;
using ZapanControls.Databases;

namespace DevZapanLibrary.Models
{
    public class GraviteModel : ModelBase<GraviteModel>
    {
        #region Variables

        private int _n_gravite = 0;
        private string _nom = string.Empty;
        private int _valeur = 0;

        #endregion

        #region Properties

        public int N_Gravite
        {
            get { return _n_gravite; }
            set { Set(ref _n_gravite, value); }
        }

        public string Nom
        {
            get { return _nom; }
            set { Set(ref _nom, value); }
        }

        public int Valeur
        {
            get { return _valeur; }
            set { Set(ref _valeur, value); }
        }

        #endregion

        #region Constructors

        public GraviteModel() { }
        public GraviteModel(DbDataReader reader) : base(reader) { }

        #endregion
    }
}
