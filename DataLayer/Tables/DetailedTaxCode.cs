using DataLayer.Enums;
using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Tables
{
    public class DetailedTaxCode : BaseModel
    {
        [DisplayName("الرقم الضريبي")]
        public string taxNumber { set; get; }
        [DisplayName("اسم الصيدلية")]
        public string FacilityName { get; set; }
        [DisplayName("رقم المركز")]
        public int PosNumber { get; set; }
        [DisplayName("رقم الفاتورة")]
        public String BillNumber { set; get; }
        [DisplayName("تاريخ الفاتورة")]
        public DateTime DateTime { set; get; }
        [DisplayName("قيمة الفاتورة")]
        public double BillValue { set; get; }
        /// <summary>
        /// العملة {SP , USD }
        /// </summary>
        [DisplayName("العملة")]
        public Currency Currency { set; get; }
        [DisplayName("التطبيق المصدر للفاتورة")]
        public string BillExporterApp { set; get; } = "ShefaaPharmacy";
        /// <summary>
        /// نوع الفاتورة {Buy , Sell }
        /// </summary>
        [DisplayName("نوع الفاتورة ")]
        public InvoiceKind InvoiceKind { set; get; }
        [DisplayName("رمز عشوائي مميز للفاتورة")]
        public string RandomCode { set; get; }
        [DisplayName("تم ترحيلها")]
        public bool IsTransfeered { set; get; }
    }
}
