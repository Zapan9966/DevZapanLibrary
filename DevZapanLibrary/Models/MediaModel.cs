using System.Data.Common;
using ZapanControls.Databases;

namespace DevZapanLibrary.Models
{
    public class MediaModel : ModelBase<MediaModel>
    {
        #region Variables

        private int _n_media = 0;
        private string _nom = string.Empty;
        private int _ordre = 0;

        #endregion

        #region Properties

        public int N_Media
        {
            get { return _n_media; }
            set { Set(ref _n_media, value); }
        }

        public string Nom
        {
            get { return _nom; }
            set { Set(ref _nom, value); }
        }

        public int Ordre
        {
            get { return _ordre; }
            set { Set(ref _ordre, value); }
        }

        #endregion

        #region Constructors

        public MediaModel() { }
        public MediaModel(DbDataReader reader) : base(reader) { }

        #endregion
    }
}
