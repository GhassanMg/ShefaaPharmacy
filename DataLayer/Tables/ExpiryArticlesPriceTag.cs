using System.ComponentModel;

namespace DataLayer.Tables
{
    public class ExpiryArticlesPriceTag
    {
        public PriceTagMaster MyPriceTag { get; set; }

        [DisplayName("كمية الترحيل")]
        public int Quantity { get; set; }
    }
}
