using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataLayer;
using DataLayer.Services;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;

namespace ShefaaPharmacy.Articale
{
    public partial class ArticalePickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        Article articale;
        public ArticalePickForm()
        {
            InitializeComponent();
        }
        public ArticalePickForm(Article articale)
        {
            this.articale = articale;
            InitializeComponent();
        }
        protected override void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            PickBindingNavigator.DeleteItem = null;
            if (CurrentEntity != null)
            {
                ShefaaPharmacyDbContext shefaaPharmacyDbContext = ShefaaPharmacyDbContext.GetCurrentContext();
                if (shefaaPharmacyDbContext.BillDetails.Any(x => x.ArticaleId == (CurrentEntity as Article).Id))
                {
                    _MessageBoxDialog.Show("يوجد سجلات مرتبطة بهذا الصنف لا يمكن حذفه", MessageBoxState.Error);
                }
            }
        }
        public static Article PickArticale(Article articale, FormOperation formOperation = FormOperation.Show)
        {
            ArticalePickForm fmPick = new ArticalePickForm(articale);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض المواد";
                fmPick.ShowDialog();
                return (Article)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static Article PickArticale(string textFilter, Article articale, FormOperation formOperation = FormOperation.Show)
        {
            if (textFilter.Trim() != "")
            {
                Article tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => !x.ItsGeneral && x.Name == textFilter).FirstOrDefault();
                if (tmpAcc != null)
                {
                    return tmpAcc;
                }
            }
            ArticalePickForm fmPick = new ArticalePickForm(articale);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر مادة";
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
        }
        protected override void Rebinding()
        {
            if (articale == null || articale.Id == 0)
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => !x.ItsGeneral).ToList();
            }
            else
            {
                if (articale.ItsGeneral)
                {
                    DescriptionFK.articlesForPicker = new List<Article>();
                    DescriptionFK.GetAllChild(articale.Id);
                    PickBindingSource.DataSource = DescriptionFK.articlesForPicker;
                    tsddlSearch.ComboBox.SelectedValue = articale.Id;
                }
                else
                {
                    PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => !x.ItsGeneral && x.Id == articale.Id).ToList();
                }
            }
            HiddenColumn = new string[] { "Description", "ArticleCategoryId", "Description2", "Note", "Note2", "ArticaleSubCategoryId", "CreationDate", "Id", "CreationByDescr", "FormatId" };
            StyledColumn = new GridStyle[] { new GridStyle() { Width = 120, ColName = "Name" }, new GridStyle() { Width = 120, ColName = "EnglishName" }, new GridStyle() { Width = 120, ColName = "ArticleIdGeneralDescr" } };

            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (Article)PickBindingSource.Current;
        }
        protected override void tsRefresh_Click(object sender, EventArgs e)
        {
            base.tsRefresh_Click(sender, e);
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            ArticaleEditForm articaleEditForm = new ArticaleEditForm((PickBindingSource.Current as Article), FormOperation.EditFromPicker);
            articaleEditForm.ShowDialog();
            Rebinding();
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            ArticaleEditForm articaleEditForm = new ArticaleEditForm(null, FormOperation.NewFromPicker);
            articaleEditForm.ShowDialog();
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            SetCurrentEntity();
            if (FormOperation != FormOperation.Pick)
            {
                ArticaleEditForm edForm = new ArticaleEditForm(CurrentEntity as Article, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                Rebinding();
            }
            else
            {
                Close();
            }
        }

        private void ArticalePickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation != FormOperation.Pick)
            {
                this.Text = "إختر مادة";
            }
            else
            {
                this.Text = "إستعراض المواد";
            }

            tsddlSearch.Visible = true;
            var articleCategoryData = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ItsGeneral).ToList();
            articleCategoryData.Add(new Article() { Id = 0, Name = "جميع المواد" });
            tsddlSearch.ComboBox.DataSource = articleCategoryData.OrderBy(x => x.Id).ToList();
            tsddlSearch.ComboBox.ValueMember = "Id";
            tsddlSearch.ComboBox.DisplayMember = "Name";

            tsddlSearch2.Visible = true;
            var companyData = ShefaaPharmacyDbContext.GetCurrentContext().Companys.ToList();
            companyData.Add(new Company() { Id = 0, Name = "جميع المستودعات" });
            tsddlSearch2.ComboBox.DataSource = companyData.OrderBy(x => x.Id).ToList();
            tsddlSearch2.ComboBox.ValueMember = "Id";
            tsddlSearch2.ComboBox.DisplayMember = "Name";

            this.tsddlSearch.SelectedIndexChanged += new EventHandler(this.tsddlSearch_SelectedIndexChanged);
            this.tsddlSearch2.SelectedIndexChanged += new EventHandler(this.tsddlSearch2_SelectedIndexChanged);

            Rebinding();
        }
        protected override void tsddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((int)tsddlSearch.ComboBox.SelectedValue == 0)
                {
                    DescriptionFK.articlesForPicker = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => !x.ItsGeneral).ToList();
                }
                else
                {
                    DescriptionFK.articlesForPicker = new List<Article>();
                    DescriptionFK.GetAllChild((int)tsddlSearch.ComboBox.SelectedValue);
                }
                if ((int)tsddlSearch2.ComboBox.SelectedValue != 0)
                {
                    DescriptionFK.GetAllArticleInCompany((int)tsddlSearch2.ComboBox.SelectedValue);
                }
                PickBindingSource.DataSource = DescriptionFK.articlesForPicker.ToList();
                PickGridView.Refresh();
            }
            catch (Exception ex)
            {
                ;
            }
        }
        protected override void tsddlSearch2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((int)tsddlSearch2.ComboBox.SelectedValue == 0)
                {
                    DescriptionFK.articlesForPicker = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => !x.ItsGeneral).ToList();
                }
                else
                {
                    DescriptionFK.GetAllArticleInCompany((int)tsddlSearch2.ComboBox.SelectedValue);
                }
                if ((int)tsddlSearch.ComboBox.SelectedValue != 0)
                {
                    DescriptionFK.GetArticlesForCompany((int)tsddlSearch2.ComboBox.SelectedValue);
                }
                PickBindingSource.DataSource = DescriptionFK.articlesForPicker.ToList();
                PickGridView.Refresh();
            }
            catch (Exception ex)
            {
                ;
            }
        }
    }
}
