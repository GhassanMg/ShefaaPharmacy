using DataLayer.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class DataBaseConfiguration
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("رقم النسخة")]
        public string VersionNumber { get; set; }
        public int AccountTaxId { get; set; }
        [DisplayName("حساب الضريبة")]
        [NotMapped]
        public string AccountTaxIdDescr
        {
            get
            {
                return DescriptionFK.GetAccountName(AccountTaxId);
            }
            set {; }
        }
        [DisplayName("قيمة الضريبة")]
        public double TaxValue { get; set; }
        [DisplayName("نسبة الزيادة على سعر المبيع")]
        public double ValueSellPrice { get; set; }
        [DisplayName("قيمة الحسم على الأكثر")]
        public double DiscountPercentage { get; set; }
        [DisplayName("تنبيه عدم تحديث الأسعار")]
        public int DateIfNotUpdatedLocal { get; set; }
        [DisplayName("تنبيه عدم تسعير الأسعار الخارجية")]
        public int DateIfNotUpdatedExternal { get; set; }
        [DisplayName("تنبيه عدد الأيام لانتهاء الصلاحية")]
        public int DayForExpiry { get; set; }
        [ForeignKey("AccountTaxId")]
        public Account Account { get; set; }
        [DisplayName("عدد الأرقام بعد الفاصلة")]
        public int CountNumberAfterComma { get; set; }
        [DisplayName("التقريب إلى أقرب")]
        public int RoundToNearest { get; set; }
        public string PharmacyName { get; set; }
    }
}
