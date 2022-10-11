using DataLayer;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class NewPriceTag : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        PriceTagMaster priceTagMaster { get; set; }
        string status; int mynewprice;
        public int ArticleId { get; set; }
        public NewPriceTag()
        {

        }
        public NewPriceTag(int articleId)
        {
            InitializeComponent();
            ArticleId = articleId;
            priceTagMaster = new PriceTagMaster();
            priceTagMaster.PriceTagDetails = new List<PriceTagDetail>();
            tbArticleName.Text = DescriptionFK.GetArticaleName(articaleId: articleId);
            HelperUI.ConfigrationComboBox<UnitType>(cbUnitTypeId, UnitArticleService.GetArticleUnits(ArticleId), null, "Name", "Id");
            cbUnitTypeId.SelectedValue = DescriptionFK.GetPrimaryUnit(articleId);
        }
        public NewPriceTag(int articleId, int pricetagId, int NewPrice)
        {
            InitializeComponent();
            status = "Edit"; mynewprice = NewPrice;
            ArticleId = articleId;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            priceTagMaster = context.PriceTagMasters.FirstOrDefault(x => x.Id == pricetagId);
            priceTagMaster.PriceTagDetails = context.PriceTagDetails.Where(x => x.PriceTagId == priceTagMaster.Id).ToList();
            tbArticleName.Text = DescriptionFK.GetArticaleName(articaleId: articleId);
            HelperUI.ConfigrationComboBox<UnitType>(cbUnitTypeId, UnitArticleService.GetArticleUnits(ArticleId), null, "Name", "Id");
            cbUnitTypeId.SelectedValue = DescriptionFK.GetPrimaryUnit(articleId);
            tbBuyPrice.Text = priceTagMaster.PriceTagDetails.FirstOrDefault().BuyPrice.ToString();
            tbSellPrice.Text = priceTagMaster.PriceTagDetails.FirstOrDefault().SellPrice.ToString();
            cbUnitTypeId.Enabled = false;

        }
        public void UpdateCurrentPrice()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<ArticleUnits> articleUnits = context.ArticleUnits.Where(x => x.ArticleId == ArticleId).ToList();
            PriceTagMaster editprice = context.PriceTagMasters.FirstOrDefault(x => x.Id == priceTagMaster.Id);
            editprice.PriceTagDetails = priceTagMaster.PriceTagDetails;
            List<PriceTagDetail> mylist = new List<PriceTagDetail>();
            foreach (PriceTagDetail item in editprice.PriceTagDetails)
            {
                int UnitId = DescriptionFK.GetUnitId(cbUnitTypeId.Text);
                if (item.UnitId == UnitId)
                {
                    item.BuyPrice = Convert.ToDouble(tbBuyPrice.Text);
                    item.SellPrice = Convert.ToDouble(tbSellPrice.Text);
                    mylist.Add(item);
                }
                else
                {
                    int quantityofprimery = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == ArticleId && x.UnitTypeId == item.UnitId).QuantityForPrimary;
                    if (item.UnitId > UnitId)
                    {
                        item.BuyPrice = Convert.ToDouble(tbBuyPrice.Text) / quantityofprimery;
                        item.SellPrice = Convert.ToDouble(tbSellPrice.Text) / quantityofprimery;
                    }
                    else if (item.UnitId < UnitId)
                    {
                        item.BuyPrice = Convert.ToDouble(tbBuyPrice.Text) * quantityofprimery;
                        item.SellPrice = Convert.ToDouble(tbSellPrice.Text) * quantityofprimery;
                    }
                    mylist.Add(item);
                }
            }
            editprice.PriceTagDetails = mylist;
            context.PriceTagMasters.Update(editprice);
            context.SaveChanges();
        }

        public void UpdatePriceFromBuyInvoice(double buyprice)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<ArticleUnits> articleUnits = context.ArticleUnits.Where(x => x.ArticleId == ArticleId).ToList();
            PriceTagMaster editprice = context.PriceTagMasters.FirstOrDefault(x => x.Id == priceTagMaster.Id);
            editprice.PriceTagDetails = priceTagMaster.PriceTagDetails;
            List<PriceTagDetail> mylist = new List<PriceTagDetail>();
            foreach (PriceTagDetail item in editprice.PriceTagDetails)
            {
                int UnitId = DescriptionFK.GetPrimaryUnit(ArticleId);
                if (item.UnitId == UnitId)
                {
                    item.BuyPrice = Convert.ToDouble(buyprice);
                    mylist.Add(item);
                }
                else
                {
                    int quantityofprimery = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == ArticleId && x.UnitTypeId == item.UnitId).QuantityForPrimary;
                    if (item.UnitId > UnitId)
                    {
                        item.BuyPrice = Convert.ToDouble(buyprice) / quantityofprimery;
                    }
                    else if (item.UnitId < UnitId)
                    {
                        item.BuyPrice = Convert.ToDouble(buyprice) * quantityofprimery;
                    }
                    mylist.Add(item);
                }
            }
            editprice.PriceTagDetails = mylist;
            context.PriceTagMasters.Update(editprice);
            context.SaveChanges();
        }
        public static PriceTagMaster CreateNewPrice(int articleId)
        {
            NewPriceTag newPriceTag = new NewPriceTag(articleId);

            newPriceTag.ShowDialog();
            return newPriceTag.priceTagMaster;

        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            if (tbSellPrice.Text == "" || tbBuyPrice.Text == "")
            {
                _MessageBoxDialog.Show("لا يمكن ترك سعر المبيع أو سعر الشراء فارغاً", MessageBoxState.Error);
                return;
            }
            try
            {
                if (status == "Edit")
                {
                    UpdateCurrentPrice();
                    _MessageBoxDialog.Show("تم تعديل بطاقة السعر", MessageBoxState.Done);
                    Close();
                }
                else
                {
                    var context = ShefaaPharmacyDbContext.GetCurrentContext();
                    var prtagDetail = DescriptionFK.GetLastPriceTagForArticle(priceTagMaster.ArticleId);
                    var ExpiryDate = DateTime.Now.AddYears(2);
                    if (prtagDetail != null)
                    {
                        ExpiryDate = prtagDetail.ExpiryDate;
                    }
                    PriceTagMaster price = new PriceTagMaster()
                    {
                        ArticleId = ArticleId,
                        UnitId = InventoryService.GetSmallestArticleUnit(ArticleId),
                        CountGiftItem = 0,
                        CountSoldItem = 0,
                        CountAllItem = 0,
                        BranchId = UserLoggedIn.User.BranchId,
                        ExpiryDate = ExpiryDate,
                        PriceTagDetails = ArticleService.MakeNewPriceTagDetailForArticle(ArticleId, Convert.ToInt32(cbUnitTypeId.SelectedValue), Convert.ToInt64(tbBuyPrice.Text), Convert.ToInt64(tbSellPrice.Text), 0),
                    };
                    context.PriceTagMasters.Add(price);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إنشاء بطاقة سعر جديدة للمادة", MessageBoxState.Done);
                    priceTagMaster = price;
                    Close();
                }
            }
            catch
            {
                _MessageBoxDialog.Show("حصل خطأ في الإدخال يرجى إعادة العملية", MessageBoxState.Error);
                return;
            }


        }
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbSellPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
