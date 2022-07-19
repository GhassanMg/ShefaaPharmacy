using DataLayer.Helper;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Tables
{
    public class OrderDetail : BaseModel
    {
        // Article Order
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public Article Articale { get; set; }
        [NotMapped]
        [DisplayName("اسم الصنف")]
        public string ArticleIdDescr
        {
            get
            {
                return DescriptionFK.GetArticaleName(ArticleId);
            }
            set {; }
        }
        [NotMapped]
        [DisplayName("الكمية المتبقية")]
        public string QuantityLeft
        {
            get
            {
                if (ArticleId != 0)
                    return InventoryService.GetQuantityOfArticleAllPriceTag(artId: ArticleId);
                else
                    return "";
            }
            set {; }
        }
        [DisplayName("الكمية المطلوبة")]
        public int Quantity { get; set; }
        //-----------------------------------

        // Order Master
        public int OrderMasterId { get; set; }
        [ForeignKey("OrderMasterId")]
        public OrderMaster OrderMaster { get; set; }
        //-----------------------------------
    }
}
