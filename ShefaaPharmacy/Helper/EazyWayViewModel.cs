using System;
using System.ComponentModel;

namespace ShefaaPharmacy.Helper
{
    public class EazyWayViewModel
    {
        [DisplayName("رمز الباركود")]
        public string Barcode { get; set; }
        [DisplayName("مقبوضات")]
        public double InComing { get; set; }
        [DisplayName("مدفوعات")]
        public double OutComing { get; set; }
        [DisplayName("الذمم")]
        public double Payable { get; set; }
        [DisplayName("اسم المادة")]
        public string ArticleIdDescr { get; set; }
        public int ArticleId { get; set; }
        [DisplayName("الداخل")]
        public int CountIn { get; set; }
        [DisplayName("الخارج")]
        public int CountOut { get; set; }
        [DisplayName("السعر الإفرادي")]
        public double OneItemPrice { get; set; }
        [DisplayName("الحساب")]
        public string AccountIdDescr { get; set; }
        public int AccountId { get; set; }
        [DisplayName("مسلسل")]
        public int Id { get; set; }
        [DisplayName("البيان")]
        public string Describtion { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
