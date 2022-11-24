using DataLayer.Helper;
using System.ComponentModel;

namespace DataLayer.Tables
{
    public class PharmacyInformation : BaseModel
    {
        [DisplayName("اسم الصيدلية")]
        public string PharmacyName { get; set; }
        [DisplayName("اسم المالك")]
        public string OwnerName { get; set; }
        [DisplayName("رقم السجل التجاري")]
        public string CommercialRegisterNumber { get; set; }
        [DisplayName("رقم الهاتف")]
        public string Tel { get; set; }
        [DisplayName("العنوان")]
        public string Address { get; set; }
        [DisplayName("معلومات إضافية")]
        public string Description { get; set; }

    }
}
