using DataLayer;
using DataLayer.Services;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class PriceTagDetailEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        PriceTagDetail PriceTagDetail = new PriceTagDetail();
        PriceTagDetail priceTagDetail { get; set; }
        public int ArticleId { get; set; }
        public PriceTagDetailEditForm()
        {

        }
        public PriceTagDetailEditForm(int articleId, PriceTagDetail priceTagDetail)
        {
            InitializeComponent();
            ArticleId = articleId;
            this.priceTagDetail = priceTagDetail;
            tbArticleName.Text = DescriptionFK.GetArticaleName(articaleId: articleId);
            tbUnitName.Text = priceTagDetail.UnitIdDescr;
            tbBuyPrice.Text = priceTagDetail.BuyPrice.ToString();
            tbSellPrice.Text = priceTagDetail.SellPrice.ToString();
        }
        public PriceTagDetailEditForm(Article myart)
        {
            InitializeComponent();
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            tbArticleName.Text = myart.Name;
            List<PriceTagMaster> priceTagMasters = context.PriceTagMasters.Where(x => x.ArticleId == myart.Id &&
            x.CountAllItem == 0 && x.CountGiftItem == 0
            && x.CountSoldItem == 0)
                .Include(x => x.PriceTagDetails).ToList();

            ArticleId = myart.Id;
            this.priceTagDetail = priceTagMasters.FirstOrDefault().PriceTagDetails.FirstOrDefault();
            tbArticleName.Text = DescriptionFK.GetArticaleName(articaleId: myart.Id);
            tbUnitName.Text = priceTagDetail.UnitIdDescr;
            tbBuyPrice.Text = priceTagDetail.BuyPrice.ToString();
            tbSellPrice.Text = priceTagDetail.SellPrice.ToString();
        }
        public static void EditNewPrice(int articleId, PriceTagDetail priceTagDetail)
        {
            PriceTagDetailEditForm editPriceTag = new PriceTagDetailEditForm(articleId, priceTagDetail);
            editPriceTag.ShowDialog();
        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                priceTagDetail.SellPrice = Convert.ToInt32(tbSellPrice.Text);
                priceTagDetail.BuyPrice = Convert.ToInt32(tbBuyPrice.Text);
                context.PriceTagDetails.Update(priceTagDetail);
                context.SaveChanges();
                _MessageBoxDialog.Show("تم تحديث السعر", MessageBoxState.Done);
                Close();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                Close();
            }

        }
    }
}
