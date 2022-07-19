using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShefaaPharmacy.Helper
{
    public class ExcelArticleViewModel
    {
        [DisplayName("إختيار")]
        public bool Selected { get; set; } = false;
        [DisplayName("تاريخ تعديل السعر")]
        public DateTime? LastUpdate { get; set; }
        [DisplayName("اسم الدواء")]
        public string Name { get; set; }
        [DisplayName("الشكل")]
        public string FormatName { get; set; }
        [DisplayName("الحجم")]
        public string Size { get; set; }
        [DisplayName("العدد")]
        public string Count { get; set; }
        [DisplayName("السعة")]
        public string Caliber { get; set; }
        [DisplayName("سعر الشراء")]
        public double? BuyPrice { get; set; }
        [DisplayName("سعر المبيع")]
        public double? SellPrice { get; set; }
        [DisplayName("اسم المستودع")]
        public string CompanyName { get; set; }
        [DisplayName("رمز الباركود")]
        public string Barcode { get; set; }
        [DisplayName("2 رمز الباركود")]
        public string Barcode2 { get; set; }
        [DisplayName("المكونات")]
        public string ActiveIngredients { get; set; }// المكونات
    }
}
