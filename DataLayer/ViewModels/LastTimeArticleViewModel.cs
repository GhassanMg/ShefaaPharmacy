using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLayer.ViewModels
{
    public class LastTimeArticleViewModel
    {
        [Browsable(false)]
        public int ArticleId { get; set; }
        [DisplayName("الدواء")]
        public string Name
        {
            get
            {
                return DescriptionFK.GetArticaleName(ArticleId);
            }
            set {; }
        }
        [Browsable(false)]
        public int UnitId { get; set; }
        [DisplayName("الواحدة")]
        public string UnitIdDescr
        {
            get
            {
                return DescriptionFK.GetUnitName(UnitId);
            }
            set {; }
        }
        [DisplayName("الكمية المتبقية")]
        public double QuantityLeft { get; set; }
        [DisplayName("إجمالي السعر")]
        public int TotalPrice { get; set; }
        [Browsable(false)]
        [DisplayName("تاريخ الإنشاء")]
        public DateTime CreationDate { get; set; }
        [Browsable(false)]
        [DisplayName("تاريخ الصلاحية")]
        public DateTime ExpiryDate { get; set; }
    }
}
