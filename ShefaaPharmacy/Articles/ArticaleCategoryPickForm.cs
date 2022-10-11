using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articale
{
    public partial class ArticaleCategoryPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        ArticleCategory articaleCategory;
        public ArticaleCategoryPickForm()
        {
            InitializeComponent();
        }
        public ArticaleCategoryPickForm(ArticleCategory articaleCategory)
        {
            this.articaleCategory = articaleCategory;
            InitializeComponent();
        }
        public static ArticleCategory PickArticaleCategory(ArticleCategory articaleCategory, FormOperation formOperation = FormOperation.Show)
        {
            ArticaleCategoryPickForm fmPick = new ArticaleCategoryPickForm(articaleCategory);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض الأصناف الرئيسية";
                fmPick.ShowDialog();
                return (ArticleCategory)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static ArticleCategory PickArticaleCategory(string textFilter, ArticleCategory articaleCategory, FormOperation formOperation = FormOperation.Show)
        {
            ArticleCategory tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().ArticleCategorys.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            ArticaleCategoryPickForm fmPick = new ArticaleCategoryPickForm(articaleCategory);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر صنف رئيسي";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (ArticleCategory)fmPick.CurrentEntity;
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
            if (articaleCategory == null || articaleCategory.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().ArticleCategorys.ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().ArticleCategorys.Where(x => x.Id == articaleCategory.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (ArticleCategory)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            shefaaPharmacyDbContext.ArticleCategorys.Remove(articaleCategory);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            ArticaleCategoryEditForm.CreateArticaleCategory(CurrentEntity as ArticleCategory, FormOperation.Pick);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if ((FormOperation != FormOperation.Pick))
            {
                ArticaleCategoryEditForm edForm = new ArticaleCategoryEditForm(PickBindingSource.Current as ArticleCategory, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            if ((FormOperation != FormOperation.Pick))
            {
                ArticaleCategoryEditForm edForm = new ArticaleCategoryEditForm(PickBindingSource.Current as ArticleCategory, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }

        private void ArticaleCategoryPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Pick)
            {
                this.Text = "إختر صنفاَ رئيسياً";
            }
            else
            {
                this.Text = "إستعراض الأصناف الرئيسية";
            }
        }
    }
}
