using DataLayer.Helper;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class PriceTagMaster : BaseModel
    {
        public int ArticleId { get; set; }
        [NotMapped]
        [DisplayName("الصنف")]
        public string ArticleIdDescr { get { return DescriptionFK.GetArticaleName(ArticleId); } set {; } }

        public int BranchId { get; set; }
        [NotMapped]
        public string BranchIdDescr { get { return DescriptionFK.GetBranchName(BranchId); } set {; } }

        public int UnitId { get; set; }
        [NotMapped]
        [DisplayName("الواحدة")]
        public string UnitIdDescr { get { return DescriptionFK.GetUnitName(UnitId); } set {; } }
        [DisplayName("المباع")]
        public int CountSoldItem { get; set; }
        [DisplayName("الهدايا")]
        public int CountGiftItem { get; set; }
        [DisplayName("المشترى")]
        public int CountAllItem { get; set; }
        [DisplayName("الصلاحية")]
        public DateTime ExpiryDate { get; set; }
        [DisplayName("تصنيف 1")]
        public string PharmacyOperator1 { get; set; } = "";
        [DisplayName("تصنيف 2")]
        public string PharmacyOperator2 { get; set; } = "";
        #region Relation
        [ForeignKey("ArticleId ")]
        [Browsable(false)]
        public Article Article { get; set; }
        [Browsable(false)]
        public List<PriceTagDetail> PriceTagDetails { get; set; }
    
        [ForeignKey("UnitId")]
        [Browsable(false)]
        public UnitType UnitType { set; get; }

        [ForeignKey("BranchId")]
        [Browsable(false)]
        public Branch Branch { get; set; }
        #endregion
    }
}
