using System;
using DataLayer.Helper;
using DataLayer.Services;
using System.ComponentModel;

namespace DataLayer.Tables
{
    public class LastTimeArticles : BaseModel
    {
        [Browsable(false)]
        public int ArticleId { get; set; }
        [DisplayName("الدواء")]
        public string Name
        {
            get
            {
                return DescriptionFK.GetArticaleName(ArticleId);
            }
            set {; }
        }
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
        [DisplayName("الكمية المتبقية")]
        public double QuantityLeft { get; set; }
        [DisplayName("إجمالي السعر")]
        public int TotalPrice { get; set; }
    }
}

