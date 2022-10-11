using DataLayer.Helper;
using DataLayer.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class ArticleUnits : BaseModel
    {
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
        public int UnitTypeId { get; set; }
        [Browsable(false)]
        [ForeignKey("UnitTypeId")]
        public UnitType UnitType { get; set; }
        [NotMapped]
        [DisplayName("الواحدة")]
        public string UnitTypeIdDescr
        {
            get
            {
                return DescriptionFK.GetUnitName(UnitTypeId);
            }
            set {; }
        }
        [DisplayName("رئيسية")]
        public bool IsPrimary { get; set; }
        [DisplayName("الكمية من الوحدة الأساسية")]
        public int QuantityForPrimary { get; set; }
    }
}
