using System.ComponentModel;

namespace DataLayer.Tables
{
    public class Medicines 
    {
        [DisplayName("الرقم")]
        public string Id { get; set; }
        [DisplayName("اسم الصنف")]
        public string Name { get; set; }
        [DisplayName("الشركة")]
        public string Company { get; set; }
        [DisplayName("الاسم العلمي")]
        public string ScientificName { get; set; }
        [DisplayName("العيار")]
        public string Caliber { get; set; }
        [DisplayName("الشكل الصيدلي")]
        public string FormatIdDescr { get; set; }
        [DisplayName("الحجم")]
        public string Size { get; set; }
        [DisplayName("سعر الشراء")]
        public string BuyPrice { get; set; }
        [DisplayName("سعر المبيع")]
        public string SellPrice { get; set; }
        [DisplayName("باركود")]
        public string Barcode { get; set; }
    }
}
