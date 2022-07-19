using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLayer.Tables
{
    public class ExpiryArticlesPriceTag
    {
        public PriceTagMaster MyPriceTag { get; set; }

        [DisplayName("كمية الترحيل")]
        public int Quantity { get; set; }
    }
}
