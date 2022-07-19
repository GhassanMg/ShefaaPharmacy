using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.ViewModels
{
    public class ArticleDetail
    {
        //[DisplayName("الكمية المباعة")]
        //public int CountSell { get; set; }
        //[DisplayName("الكمية المشتراه")]
        //public int CountBuy { get; set; }
        [DisplayName("الكمية المتبقية")]
        public string CountLeft { get; set; }
        [DisplayName("آخر سعر شراء")]
        public double LastBuyPrimary { get; set; }
        [DisplayName("آخر سعر مبيع")]
        public double LastSellPrimary { get; set; }
        
    }
    public class ArticleExpiryDay
    {
        [Browsable(false)]
        public int ArticleId { get; set; }
        [DisplayName("الصنف")]
        public string ArticaleIdDescr
        {
            get
            {
                return DescriptionFK.GetArticaleName(ArticleId);
            }
            set {; }
        }
        [DisplayName("الكمية المتبقية من هذا الصنف")]
        public int QuantityLeft { get; set; }
        [DisplayName("تاريخ الصلاحية")]
        public DateTime ExpiryDate { get; set; }
    }
}
