using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.Text;

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
