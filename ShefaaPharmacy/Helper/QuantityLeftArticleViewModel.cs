using System.ComponentModel;

namespace ShefaaPharmacy.Helper
{
    public class QuantityLeftArticleViewModel
    {
        [Browsable(false)]
        public int ArticleId { get; set; }
        [DisplayName("اسم المنتج")]
        public string ArticleIdDescr { get; set; }
        [DisplayName("الكمية المتبقية")]
        public string ArticleLeftAsString { get; set; }
        [DisplayName("الحد الأدنى")]
        public int ArticleMinCount { get; set; }
        [DisplayName("الحد الأعلى")]
        public int ArticleMaxCount { get; set; }
    }
}
