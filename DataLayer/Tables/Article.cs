
using DataLayer.Helper;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Tables
{

    public class Article : BaseModel
    {
        [DisplayName("اسم الصنف")]
        public string Name { get; set; } = "";
        [DisplayName("English Name")]
        public string EnglishName { get; set; } = "";
        [DisplayName("شرح")]
        public string Description { set; get; } = "";
        [DisplayName("شرح 2")]
        public string Description2 { set; get; } = "";
        [DisplayName("الصنف الرئيسي")]
        [Browsable(false)]
        public int? ArticleIdGeneral { get; set; }
        [DisplayName("الصنف الرئيسي")]
        public string ArticleIdGeneralDescr
        {
            set {; }
            get
            {
                if (ArticleIdGeneral == null)
                {
                    return "";
                }
                return DescriptionFK.GetArticaleName((int)ArticleIdGeneral);
            }
        }
        [ForeignKey("ArticleIdGeneral")]
        [Browsable(false)]
        public Article ArticleGeneral { get; set; }
        [NotMapped]
        [Browsable(false)]
        public List<Article> ArticlesChild { get; set; }
        [DisplayName("رئيسي")]
        public bool ItsGeneral { get; set; }
        [DisplayName("ملاحظة")]
        public string Note { set; get; }
        [DisplayName("ملاحظة 2")]
        public string Note2 { set; get; }
        [DisplayName("الاسم العلمي")]
        public string ScientificName { get; set; } // الاسم العلمي
        [DisplayName("المكونات")]
        public string ActiveIngredients { get; set; }// المكونات
        [DisplayName("الجرعة")]
        public string Dosage { get; set; } // الجرعة
        [DisplayName("أعراض جانبية")]
        public string SideEffects { get; set; } // أعراض جانبية
        [DisplayName("تدخلات دوائية")]
        public string Interactions { get; set; } //تداخلات دوائية
        [DisplayName("الاحتياطات")]
        public string Precautions { get; set; } // الاحتياطات   
        [DisplayName("الحد الأعلى")]
        public int LimitUp { get; set; }
        [DisplayName("الحد الأدنى")]
        public int LimitDown { get; set; }
        [DisplayName("للتصفية")]
        public bool DontUseAnymore { get; set; }
        [NotMapped]
        [DisplayName("الكمية المتبقية")]
        public string CountLeft
        {
            get
            {
                try
                {
                    return InventoryService.GetQuantityOfArticleAllPriceTag(artId: Id);
                }
                catch (Exception ex)
                {
                    return "";
                }
            }

            set
            {
                return;
            }
        }
        /// <summary>
        ///  حجم الصنف
        /// </summary>
        [DisplayName("حجم")]
        public string Size { get; set; }
        /// <summary>
        /// عيار الصنف
        /// </summary>
        [DisplayName("عيار")]
        public string Caliber { get; set; }
        [DisplayName("الشكل")]
        public string FormatIdDescr
        {
            set {; }
            get
            {
                return DescriptionFK.GetFormatName(FormatId);
            }
        }
        [DisplayName("صنف أجنبي")]
        public bool IsForeign { get; set; } = false;
        [Browsable(false)]
        public int ArticleCategoryId { set; get; }
        [NotMapped]
        [DisplayName("نوع الصنف")]
        public string ArticleCategoryIdDescr
        {
            set {; }
            get
            {
                return DescriptionFK.GetArticaleCategoryName(ArticleCategoryId);
            }
        }
        [DisplayName("رمز الباركود")]
        public string Barcode { get; set; } = "";
        [DisplayName("الشركة")]
        [NotMapped]
        public string CompanyIdDescr
        {
            set {; }
            get
            {
                return DescriptionFK.GetCompanyName(CompanyId);
            }
        }
        [Browsable(false)]
        public int? CompanyId { set; get; }
        [ForeignKey("CompanyId")]
        [Browsable(false)]
        public Company Company { set; get; }
        #region Relation
        [Browsable(false)]
        public int? FormatId { get; set; }
        [ForeignKey("FormatId")]
        [Browsable(false)]
        public Format Format { set; get; }
        [ForeignKey("ArticleCategoryId")]
        [Browsable(false)]

        public ArticleCategory ArticleCategory { set; get; }
        [Browsable(false)]
        public List<BillDetail> BillDetails { get; set; }
        [Browsable(false)]
        public List<Barcode> Barcodes { set; get; }
        [Browsable(false)]
        public List<PriceTagMaster> PriceTagMasters { get; set; }
        [Browsable(false)]
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ArticleUnits> ArticleUnits { get; set; }
        #endregion
    }
}
