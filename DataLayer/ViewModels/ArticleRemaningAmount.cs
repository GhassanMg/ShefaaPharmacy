using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLayer.ViewModels
{
    public class ArticleRemaningAmount
    {
        [Browsable(false)]
        public int PriceTagId { get; set; }
        [Browsable(false)]
        public int ArticleId { get; set; }
        [DisplayName("الصنف")]
        public string ArticaleIdDescr { get; set; }
        [Browsable(false)]
        public int UnitId { get; set; }
        [DisplayName("الواحدة الأساسية")]
        public string UnitIdDescr { get; set; }
        [DisplayName("الإجمالي")]
        public int CountItem { get; set; }
        [Browsable(false)]
        [DisplayName("المباع")]
        public int CountSoldItem { get; set; }
        [DisplayName("المتبقي")]
        public int CountLeft { get; set; }
        [DisplayName("تاريخ الصلاحية")]
        public DateTime ExpiryDate { get; set; }
    }
}
