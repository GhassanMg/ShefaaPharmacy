using DataLayer.Helper;
using System.Collections.Generic;

namespace DataLayer.Tables
{
    public class UnitType : BaseModel
    {
        public string Name { get; set; }
        #region Relation
        public List<BillDetail> BillDetails { get; set; }
        public List<ArticleUnits> ArticleUnits { get; set; }
        #endregion
    }
}
