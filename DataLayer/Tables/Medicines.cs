using System.ComponentModel;

namespace DataLayer.Tables
{
    public class Medicines 
    {
        //[name][nvarchar](600) NULL,[company][nvarchar](600) NULL,[scientific_name][nvarchar](600) NULL,[caliber][nvarchar](600) NULL,[format_id_descr][nvarchar](600) NULL,[size][nvarchar](600) NULL,[BuyPrice][nvarchar](600) NULL,[SellPrice][nvarchar](600) NULL,[barcode][nvarchar](600) NULL) ON[PRIMARY];";
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
