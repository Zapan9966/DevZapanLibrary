using System.Data.Common;
using ZapanControls.Databases;

namespace DevZapanLibrary.Models
{
    public class QualificationModel : ModelBase<QualificationModel>
    {
        #region Variables

        private int _n_qualification = 0;
        private string _nom = string.Empty;

        #endregion

        #region Properties

        public int N_Qualification
        {
            get { return _n_qualification; }
            set { Set(ref _n_qualification, value); }
        }

        public string Nom
        {
            get { return _nom; }
            set { Set(ref _nom, value); }
        }

        #endregion

        #region Constructors

        public QualificationModel() { }
        public QualificationModel(DbDataReader reader) : base(reader) { }

        #endregion
    }
}
