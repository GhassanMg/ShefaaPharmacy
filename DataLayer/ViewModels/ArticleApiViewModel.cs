using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLayer.ViewModels
{
    public class ArticleApiViewModel
    {
        [Browsable(false)]
        public int id { get; set; }
        [DisplayName("اسم الصنف")]
        public string name { get; set; }
        [DisplayName("الاسم الأجنبي")]
        public string english_name { get; set; }
        [DisplayName("الوصف")]
        [DataGridViewField(isShow: false)]
        public string Description { get; set; }
        [DisplayName("الوصف2")]
        [DataGridViewField(isShow: false)]
        public string description2 { get; set; }
        [DataGridViewField(isShow: false)]
        [DisplayName("ملاحظة 1")]
        public string note { get; set; }
        [DataGridViewField(isShow: false)]
        [DisplayName("ملاحظة 2")]
        public string note2 { get; set; }
        [DataGridViewField(isShow: false)]
        [DisplayName("الاسم العلمي")]
        public string scientific_name { get; set; }
        [DisplayName("المكونات")]
        public string active_ingredients { get; set; }
        [DisplayName("الجرعة")]
        [DataGridViewField(isShow: false)]
        public string dosage { get; set; }
        [DisplayName("أعراض جانبية")]
        [DataGridViewField(isShow: false)]
        public string side_effects { get; set; }
        [DataGridViewField(isShow: false)]
        [DisplayName("تدخلات دوائية")]
        public string interactions { get; set; }
        [DataGridViewField(isShow: false)]
        [DisplayName("الاحتياطات")]
        public string precautions { get; set; }
        [DisplayName("حجم")]
        public string size { get; set; }
        [DisplayName("عيار")]
        public string caliber { get; set; }
        [DisplayName("باركود")]
        public string barcode { get; set; }
        [DisplayName("سعر الشراء")]
        public double BuyPrice { get { return last_price_tag.buy_price; } set {; } }
        [DisplayName("سعر المبيع")]
        public double SellPrice { get { return last_price_tag.sale_price; } set {; } }
        [Browsable(false)]
        [DataGridViewField(false)]
        public int company_id { get; set; }
        [DisplayName("اسم الشركة")]
        public string company_id_descr { get { return company.Name; } set {; } }
        [DisplayName("الشكل الصيدلي")]
        public string format_id_descr { get { return format.name; } set {; } }
        [Browsable(false)]
        public int format_id { get; set; }
        [DisplayName("استيراد")]
        public bool Checked { get; set; }

        #region Relation
        [Browsable(false)]
        public PriceTagViewModel last_price_tag { get; set; }
        [Browsable(false)]
        public CompanyApiViewModel company { get; set; }
        [Browsable(false)]
        public FormatApiViewModel format { get; set; }
        #endregion
    }
}
