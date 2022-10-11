using DataLayer.Services;
using System.ComponentModel;

namespace DataLayer.ViewModels
{
    public class ArticleDetailQuantity
    {
        [Browsable(false)]
        public int ArticleId { get; set; }
        [DisplayName("المنتج")]
        public string ArticaleIdDescr
        {
            get
            {
                return DescriptionFK.GetArticaleName(ArticleId);
            }
            set {; }
        }
        [Browsable(false)]
        public int Unit1 { get; set; }
        [Browsable(false)]
        public int Unit2 { get; set; }
        [Browsable(false)]
        public int Unit3 { get; set; }
        [DisplayName("الوحدة الأساسية")]
        public string Unit1Descr
        {
            get
            {
                return DescriptionFK.GetUnitName(Unit1);
            }
            set {; }
        }
        [DisplayName("الكمية من الوحدة الأساسية")]
        public int Unit1Quantity { get; set; }
        [DisplayName("الوحدة الثانية")]
        public string Unit2Descr
        {
            get
            {
                return DescriptionFK.GetUnitName(Unit2);
            }
            set {; }
        }
        [DisplayName("الكمية من الوحدة الثانية")]
        public int Unit2Quantity { get; set; }
        [DisplayName("الكمية الثالثة")]
        public string Unit3Descr
        {
            get
            {
                return DescriptionFK.GetUnitName(Unit3);
            }
            set {; }
        }
        [DisplayName("الكمية من الوحدة الثالثة")]
        public int Unit3Quantity { get; set; }
        [DisplayName("الحد الأعلى")]
        public int LimitUp { get; set; }
        [DisplayName("الحد الأدنى")]
        public int LimitDown { get; set; }
    }
}
