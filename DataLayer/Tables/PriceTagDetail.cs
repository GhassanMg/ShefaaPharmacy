using DataLayer.Helper;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Tables
{
    public class PriceTagDetail : BaseModel
    {
        public int PriceTagId { get; set; }
        public int UnitId { get; set; }
        [NotMapped]
        [DisplayName("الواحدة")]
        public string UnitIdDescr { get { return DescriptionFK.GetUnitName(UnitId); } set {; } }
        [DisplayName("مبيع")]
        public double SellPrice { get; set; }
        [DisplayName("شراء")]
        public double BuyPrice { get; set; }
        #region Relation
        [ForeignKey("PriceTagId")]
        [Browsable(false)]
        public PriceTagMaster PriceTagMaster { set; get; }
        [ForeignKey("UnitId")]
        [Browsable(false)]
        public UnitType UnitType { set; get; }
        #endregion
    }
}
