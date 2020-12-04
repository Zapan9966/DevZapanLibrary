using System.Data.Common;
using ZapanControls.Databases;

namespace DevZapanLibrary.Models
{
    public class FrequenceModel : ModelBase<FrequenceModel>
    {
        #region Variables

        private int _n_frequence = 0;
        private string _nom = string.Empty;
        private int _valeur = 0;

        #endregion

        #region Properties

        public int N_Frequence
        {
            get { return _n_frequence; }
            set { Set(ref _n_frequence, value); }
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

        public FrequenceModel() { }
        public FrequenceModel(DbDataReader reader) : base(reader) { }

        #endregion
    }
}
