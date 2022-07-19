using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLayer.Tables
{
    public class ExpiryTransfeerDetail
    {
        [Browsable(false)]
        public int Id { set; get; }
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
        //[Browsable(false)]
        //[DisplayName("رقم سند القيد")]
        //public int EntryDetailId { set; get; }
    }
}
