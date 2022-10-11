using System;
using DataLayer.Helper;
using System.ComponentModel;

namespace DataLayer.Tables
{
    public class ExpiryTransfeerDetail : BaseModel
    {
        [DisplayName("المادة")]
        public string ArticleIdDescr { set; get; }
        [DisplayName("الواحدة")]
        public string UnitIdDescr { set; get; }
        [DisplayName("الكمية")]
        public int LeftQuantity { set; get; }
        [DisplayName("تاريخ انتهاء الصلاحية")]
        public DateTime ExpiryDate { set; get; }
        [DisplayName("الكمية المحولة")]
        public int TransQuantity { set; get; }
        //[DisplayName("تحويل")]
        //public bool Checked { set; get; }
    }
}
