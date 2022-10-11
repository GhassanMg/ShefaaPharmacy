using DataLayer.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class Barcode : BaseModel
    {
        public string Code { set; get; }
        #region Relation
        public int ArticaleId { set; get; }
        [ForeignKey("ArticaleId")]
        public Article Articale { set; get; }
        #endregion

    }
}
