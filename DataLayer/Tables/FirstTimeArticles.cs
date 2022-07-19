using DataLayer.Enums;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLayer.Tables
{
    public class FirstTimeArticles
    {
        
        public int id { get; set; }
        [DisplayName("المنتج")]
        public string Name { get; set; }
        [DisplayName("نوع الفاتورة")]
        public string InvoiceKind { get; set; }
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
        [DisplayName("السعر")]
        public double Price { get; set; }
        [DisplayName("كمية أول المدة")]
        public int Quantity { get; set; }
        [DisplayName("الإجمالي")]
        public double Total { get; set; }

        [DisplayName("تاريخ ")]
        public DateTime Expirydate { get; set; }
    }
}
