using DataLayer.Services;
using System;
using System.ComponentModel;

namespace DataLayer.ViewModels
{
    public class PurchesBillViewModel
    {
        [DisplayName("الباركود")]
        public string BarcodeDescr { get { return Barcode; } set {; } }


        [Browsable(false)]
        public int ArticleId { get; set; }
        [DisplayName("الصنف")]
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
        [DisplayName("الواحدة")]
        public string UnitIdDescr
        {
            get
            {
                return DescriptionFK.GetUnitName(UnitId);
            }
            set {; }
        }

        [DisplayName("الكمية")]
        public int Quantity { get; set; }


        [Browsable(false)]
        public string Barcode { get; set; }


        [DisplayName("سعر الشراء")]
        public double PurchasePrice { get; set; }

        [DisplayName("سعر المبيع")]
        public double SellPrice { get; set; }

        [DisplayName("الهدايا")]
        public int Gift { get; set; }

        [DisplayName("صالح لغاية")]
        public DateTime ExpiryDate { get; set; }

        [Browsable(false)]
        public int BaseUnitId { get; set; }
        [DisplayName("الواحدة الأساسية")]
        public string BaseUnitIdDescr
        {
            get
            {
                return DescriptionFK.GetUnitName(BaseUnitId);
            }
            set {; }
        }
        [DisplayName("الكمية المتبقية")]
        public int RemainingAmount { get; set; }
    }
}
