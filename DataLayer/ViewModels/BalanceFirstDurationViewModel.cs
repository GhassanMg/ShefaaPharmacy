using DataLayer.Services;
using DataLayer.Tables;
using System;
using System.ComponentModel;

namespace DataLayer.ViewModels
{
    public class BalanceFirstDurationViewModel
    {
        [Browsable(false)]
        public int ArticleId { get; set; }
        [DisplayName("المنتج")]
        public string ArticleIdDescr
        {
            get
            {
               return DescriptionFK.GetArticaleName(ArticleId);
            }
            set {; }
        }
        [Browsable(false)]
        public int UnitId { get; set; }
        [DisplayName("نوع الكمية")]
        public string UnitIdDescr
        {
            get
            {
                return DescriptionFK.GetUnitName(UnitId);
            }
            set {; }
        }
        private double price;
        [DisplayName("السعر")]
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                if (Price > 0 && quantity > 0)
                {
                    Total = Price * quantity;
                }

            }
        }
        [Browsable(false)]
        private int quantity;
        //[DisplayName("الكمية الموجودة")]
        //public int LeftQuantity
        //{
        //     get; set; 

        //}
        [DisplayName("العدد")]
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                if (Price > 0 && quantity > 0)
                {
                    Total = Price * quantity;
                }

            }
        }
        [Browsable(false)]
        private double total;
        [DisplayName("الإجمالي")]
        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        [Browsable(false)]
        public int PriceTagId { get; set; }
        [Browsable(false)]
        public PriceTagMaster PriceTag { get; set; }
        [DisplayName("تاريخ الصلاحية")]
        public DateTime ExpiryDate { get; set; }
    }
}
