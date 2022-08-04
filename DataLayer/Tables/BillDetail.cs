using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataLayer.Tables
{
    public class BillDetail : BaseModel
    {
        public delegate void UpdateForm();
        public event UpdateForm onUpdateForm;
        public BillDetail()
        {
        }
        public BillDetail(BillMaster billMaster)
        {
            if (billMaster != null)
            {
                this.BillMaster = billMaster;
                InvoiceKind = billMaster.InvoiceKind;
                if (InvoiceKind == InvoiceKind.Buy)
                {
                    PriceTag = new PriceTagMaster();
                }
            }
            else
            {
                InvoiceKind = InvoiceKind.Sell;
            }
        }
        [Browsable(false)]
        public string Barcode { set; get; }
        [DisplayName("الباركود")]
        [NotMapped]
        public string BarcodeDescr { get { return Barcode; } set {; } }
        [DisplayName("نوع الفاتورة")]
        public InvoiceKind InvoiceKind { get; set; }
        [DisplayName("الصنف")]
        [NotMapped]
        public string ArticaleIdDescr
        {
            get
            {
                //return DescriptionFK.GetArticaleName(ArticaleId);
                return this.context == null ? DescriptionFK.GetArticaleName(ArticaleId) : DescriptionFK.GetArticaleNameMobile(context, ArticaleId);
            }
            set {; }
        }
        //                    ======================================
        [Browsable(false)]
        [NotMapped]
        public string UnitTypeIdDescrMobile
        {
            get
            {
                return context != null ? DescriptionFK.GetUnitNameMobile(context, UnitTypeId) : null;
            }
            set {; }
        }
        //                    =======================================
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
        [Browsable(false)]
        public int UnitTypeIdBasic { get; set; }
        [NotMapped]
        [Browsable(false)]
        int quentity;
        [DisplayName("الكمية")]
        public int Quantity
        {
            get { return quentity; }
            set
            {
                quentity = value;
                TotalPrice = value * Price;
                if (discount != 0)
                    TotalPrice -= discount;
                onUpdateForm?.Invoke();
                //BillMaster.CalcTotal();
            }
        }
        [DisplayName("كمية الهدايا")]
        public int QuantityGift { get; set; }
        [NotMapped]
        [DisplayName("الكمية المتبقية")]
        public string CountLeft
        {
            get
            {
                try
                {
                    if (ArticaleId != 0)
                    {
                        //Format("{0:0.##}", InventoryService.GetQuantityOfArticleAllPriceTag(artId: ArticaleId, unitId: UnitTypeId));
                        //return InventoryService.GetQuantityOfArticleAllPriceTag(artId: ArticaleId, unitId: UnitTypeId);
                        string x = context != null ? String.Format("{0:0.##}", Convert.ToDouble(InventoryService.GetQuantityOfArticleAllPriceTagMobile(context, artId: ArticaleId, unitId: UnitTypeId))) : String.Format("{0:0.##}", Convert.ToDouble(InventoryService.GetQuantityOfArticleAllPriceTag(artId: ArticaleId, unitId: UnitTypeId)));
                        double dres =double.Parse(x);
                        //int ires = Convert.ToInt32(dres);
                        return dres.ToString();
                    }
                    else
                        return "";

                    //if (ArticaleId != 0)
                    //    return ArticleService.ItemLeftFromInventory(artId: ArticaleId);
                    //else
                    //    return "";
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
        [NotMapped]
        [Browsable(false)]
        double price;
        [DisplayName("السعر")]
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                TotalPrice = value * Quantity;
                if (discount != 0)
                    TotalPrice -= discount;
                //BillMaster.CalcTotal();
                onUpdateForm?.Invoke();
            }
        }
        [NotMapped]
        [Browsable(false)]
        double discount;
        [DisplayName("الحسم")]
        public double Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                TotalPrice = Quantity * price;
                TotalPrice -= value;
                //BillMaster.CalcTotal();
                onUpdateForm?.Invoke();
            }
        }
        [DisplayName("اجمالي السعر")]
        public double TotalPrice { get; set; }
        [Browsable(false)]
        public int PriceTagId { get; set; }
        public Article AddArticleByMobile(ShefaaPharmacyDbContext context, string barcode)
        {
            try
            {
                Article ttp = context.Articles.Where(x => (x.Barcode == barcode)).FirstOrDefault();
                return ttp;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #region Relation
        [Browsable(false)]
        public int ArticaleId { get; set; }
        [Browsable(false)]
        [ForeignKey("ArticaleId")]
        public Article Articale { get; set; }
        [Browsable(false)]
        public int UnitTypeId { get; set; }
        [Browsable(false)]
        [ForeignKey("UnitTypeId")]
        public UnitType UnitType { get; set; }
        [Browsable(false)]
        public int BillMasterId { get; set; }
        [Browsable(false)]
        [ForeignKey("BillMasterId")]
        public BillMaster BillMaster { get; set; }
        [Browsable(false)]
        [ForeignKey("PriceTagId")]
        public PriceTagMaster PriceTag { get; set; }
        #endregion
    }
}
