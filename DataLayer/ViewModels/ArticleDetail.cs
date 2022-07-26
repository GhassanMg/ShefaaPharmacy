﻿using DataLayer.Services;
using System;
using System.ComponentModel;

namespace DataLayer.ViewModels
{
    public class ArticleDetail
    {
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
