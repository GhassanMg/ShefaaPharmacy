using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Tables
{
    public class Inventory
    {
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")]
        public Article Article { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store Store { get; set; }
        public int PriceTagId { get; set; }
        [ForeignKey("PriceTagId")]
        public PriceTagMaster PriceTag { get; set; }
        public int UnitTypeId { get; set; }
        [ForeignKey("UnitTypeId")]
        public UnitType UnitType { get; set; }
        [DisplayName("نوع الكمية")]
        [NotMapped]
        public string UnitTypeIdDescr
        {
            get
            {
                return DescriptionFK.GetUnitName(UnitTypeId);
            }
            set {; }
        }
        public int Quantity { get; set; }
    }
}
