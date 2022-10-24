using System;
using System.ComponentModel;

namespace DataLayer.ViewModels
{
    public class TaxReportViewModel
    {
        [DisplayName("قيمة الفاتورة")]
        public double billValue { set; get; }
        [DisplayName("رقم الفاتورة")]
        public String billNumber { set; get; }
        [DisplayName("تاريخ الفاتورة")]
        public String code { set; get; }
        [DisplayName("العملة")]
        public string currency { set; get; }
        [DisplayName("التطبيق المصدر للفاتورة")]
        public string exProgram { set; get; } = "ShefaaPharmacy";
        [DisplayName("تاريخ الفاتورة")]
        public DateTime date { set; get; }
    }
}
