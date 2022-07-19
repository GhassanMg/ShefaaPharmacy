using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
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

namespace ShefaaPharmacy.Articale
{
    public partial class ArticleGeneralPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        Article article;
        public ArticleGeneralPickForm()
        {
            InitializeComponent();
        }
        public ArticleGeneralPickForm(Article article)
        {
            this.article = article;
            InitializeComponent();
        }
        public static Article PickArticleGeneral(Article article, FormOperation formOperation = FormOperation.Show)
        {
            ArticleGeneralPickForm fmPick = new ArticleGeneralPickForm(article);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض التصنيفات";
                fmPick.ShowDialog();
                return (Article)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static Article PickArticleGeneral(string textFilter, Article article, FormOperation formOperation = FormOperation.Show)
        {
            Article tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ItsGeneral && x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            ArticleGeneralPickForm fmPick = new ArticleGeneralPickForm(article);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر صنف";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (Article)fmPick.CurrentEntity;
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
            if (article == null || article.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ItsGeneral).ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ItsGeneral && x.Id == article.Id).ToList();

            HiddenColumn = new string[] { "Description", "Barcode", "CompanyIdDescr", "Caliber", "Size", "CountLeft", "DontUseAnymore", "LimitDown", "LimitUp", "Precautions", "ArticleCategoryId", "Description2", "Note", "Note2", "ArticaleSubCategoryId", "CreationDate", "Id", "CreationByDescr", "FormatId" };
            StyledColumn = new GridStyle[] { new GridStyle() { Width = 120, ColName = "Name" }, new GridStyle() { Width = 120, ColName = "EnglishName" }, new GridStyle() { Width = 120, ColName = "ArticleIdGeneralDescr" } };
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (Article)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            _MessageBoxDialog.Show("لا يمكن حذف صنف رئيسي", MessageBoxState.Error);
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            ArticleGeneralEditForm.CreateArticleGeneral(CurrentEntity as Article, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            if (FormOperation != FormOperation.Pick)
            {
                SetCurrentEntity();
                ArticleGeneralEditForm edForm = new ArticleGeneralEditForm(CurrentEntity as Article, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (PickBindingSource.Current == null)
                return;
            if (FormOperation != FormOperation.Pick)
            {
                SetCurrentEntity();
                ArticleGeneralEditForm edForm = new ArticleGeneralEditForm(CurrentEntity as Article, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void tsFilterdText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tsFilterdText.Text))
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ItsGeneral).ToList();
            }
            else
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ItsGeneral && x.Name.Contains(tsFilterdText.Text)).ToList();
            }
            base.Rebinding();
        }
        private void ArticaleSubCategoryPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Show)
            {
                this.Text = "إختر صنفاَ";
            }
            else
            {
                this.Text = "إستعراض التصنيفات";
            }
        }
    }
}
