using DataLayer.Enums;
using DataLayer.Services;
using DataLayer.ViewModels;
using System.Collections.Generic;

namespace ShefaaPharmacy.Articles
{
    public partial class PriceTagPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        ArticleRemaningAmount articleRemaningAmount;
        List<ArticleRemaningAmount> tags;
        int articleId;
        public PriceTagPickForm()
        {
            InitializeComponent();
        }
        public PriceTagPickForm(List<ArticleRemaningAmount> articleRemaningAmount, int articleId)
        {
            InitializeComponent();
            tags = articleRemaningAmount;
            this.articleId = articleId;
        }
        public static ArticleRemaningAmount PickPriceTag(List<ArticleRemaningAmount> articleRemaningAmount, int articleId, FormOperation formOperation = FormOperation.Show)
        {
            PriceTagPickForm fmPick = new PriceTagPickForm(articleRemaningAmount, articleId);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض بطاقات الأسعار المتاحة للصنف";
                fmPick.ShowDialog();
                return (ArticleRemaningAmount)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        protected override void AdjustmentGridColumns()
        {
            base.AdjustmentGridColumns();
            PickGridView.Refresh();
        }
        protected override void Rebinding()
        {
            if (tags == null || tags.Count < 1)
            {
                PickBindingSource.DataSource = InventoryService.GetArticleAllPriceTags(articleId);
            }
            else
            {
                PickBindingSource.DataSource = tags;
            }
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (ArticleRemaningAmount)PickBindingSource.Current;
        }
    }
}
