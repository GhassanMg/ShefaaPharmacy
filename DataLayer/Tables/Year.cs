using DataLayer.Helper;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataLayer.Tables
{
    public class Year:BaseModel
    {
        [DisplayName("السنة المالية")]
        public string Name { get; set; }
        #region Relation
        [Browsable(false)]
        public IList<EntryMaster> EntryMasters { set; get; }
        [Browsable(false)]
        public IList<BillMaster> BillMasters { set; get; }
        [Browsable(false)]
        public IList<PriceTagMaster> PriceTags { set; get; }
        #endregion
    }
}
