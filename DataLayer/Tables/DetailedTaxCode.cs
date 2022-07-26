﻿using DataLayer.Enums;
using DataLayer.Helper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string DateTime { set; get; }
        [DisplayName("قيمة الفاتورة")]
        public double BillValue { set; get; }
        /// <summary>
        /// العملة {SP , USD }
        /// </summary>
        [DisplayName("العملة")]
        public string Currency { set; get; }
        [DisplayName("اسم التطبيق")]
        public string BillExporterApp { set; get; } = "ShefaaPharmacy";
        /// <summary>
        /// نوع الفاتورة {All, Buy , Sell }
        /// </summary>
        [DisplayName("نوع الفاتورة ")]
        public InvoiceKind InvoiceKind { set; get; }
        [DisplayName("رمز الفاتورة")]
        public string RandomCode { set; get; }
        [DisplayName("تم ترحيلها")]
        public bool IsTransfeered { set; get; }

        #region Relation
        [Browsable(false)]
        public int YearId { get; set; }
        [Browsable(false)]
        [ForeignKey("YearId")]
        public Year Year { get; set; }
        #endregion
    }
}
