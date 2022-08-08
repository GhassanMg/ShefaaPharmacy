using DataLayer.Enums;
using DataLayer.Enums;
using DataLayer;
using DataLayer.Services;
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
    public partial class ArticleGeneralEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        Article article;
        public ArticleGeneralEditForm()
        {
            InitializeComponent();
        }
        public ArticleGeneralEditForm(Article entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            article = entity;
            FormOperation = formOperation;
            if (entity.Id == 0)
            {
                this.Text = "تعريف صنف رئيسي ";
            }
            else
            {
                this.Text = "تعديل صنف رئيسي ";
            }
            EditBindingSource.DataSource = article;
        }
        public static Article CreateArticleGeneral(Article article, FormOperation formOperation = FormOperation.New)
        {
            ArticleGeneralEditForm fmEdit = new ArticleGeneralEditForm(article, formOperation);
            try
            {
                fmEdit.Text = "تعريف صنف رئيسي ";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return fmEdit.article;
            }
            finally
            {
                fmEdit.Dispose();
            }
        }
        protected override void BindingEntityToControls()
        {
            base.BindingEntityToControls();

            tbName.DataBindings.Add("text", EditBindingSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            tbEnglishName.DataBindings.Add("text", EditBindingSource, "EnglishName", false, DataSourceUpdateMode.OnPropertyChanged);
            tbArticleGeneral.DataBindings.Add("text", EditBindingSource, "ArticleIdGeneralDescr", true, DataSourceUpdateMode.OnPropertyChanged);
            tbInteractions.DataBindings.Add("text", EditBindingSource, "Interactions", false, DataSourceUpdateMode.OnPropertyChanged);
            tbNote.DataBindings.Add("text", EditBindingSource, "Note", false, DataSourceUpdateMode.OnPropertyChanged);
            tbActiveIngredients.DataBindings.Add("text", EditBindingSource, "ActiveIngredients", false, DataSourceUpdateMode.OnPropertyChanged);


            ArticleCategory articaleCategory = article == null ? null : ShefaaPharmacyDbContext.GetCurrentContext().ArticleCategorys.FirstOrDefault(x => x.Id == article.ArticleCategoryId);
            HelperUI.ConfigrationComboBox<ArticleCategory>(cbArticaleCategory, ShefaaPharmacyDbContext.GetCurrentContext().ArticleCategorys.ToList(),
                articaleCategory, "Name", "Id", FormOperation);

        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                base.btOk_Click(sender, e);
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                if (!DescriptionFK.IsValid(article.Name))
                {
                    _MessageBoxDialog.Show("تأكد من تعبئة الحقول", MessageBoxState.Error);
                    return;
                }
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                {
                    article.ArticleCategoryId = (int)cbArticaleCategory.SelectedValue;
                    article.ItsGeneral = true;
                    context.Articles.Add(article);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة صنف رئيسي", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    context.Articles.Update(article);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات الصنف الرئيسي", MessageBoxState.Done);
                    if (FormOperation == FormOperation.EditFromPicker)
                    {
                        Close();
                    }
                }
                EditBindingSource.AddNew();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
            }
        }

        private void EditBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            article = new Article();
            article.ItsGeneral = true;
            e.NewObject = article;
        }

        private void ArticaleSubCategoryEditForm_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                this.Text = "تعريف صنف رئيسي ";
            }
            else
            {
                this.Text = "تعديل صنف رئيسي ";
            }
        }

        private void cbArticaleCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbCategory_Click(object sender, EventArgs e)
        {

        }

        private void tbArticleGeneral_Validating(object sender, CancelEventArgs e)
        {

            Article result = DescriptionFK.ExistsArticleCategory(true, tbArticleGeneral.Text, 0);
            if (result == null)
            {
                result = ArticleGeneralPickForm.PickArticleGeneral("", null, FormOperation.Pick);
            }
            if (result != null)
            {
                (EditBindingSource.Current as Article).ArticleIdGeneral = result.Id;
                tbArticleGeneral.Text = result.Name;
                (EditBindingSource.Current as Article).ArticleIdGeneralDescr = result.Name;
            }
        }

        private void lbArticaleGeneral_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Article result = ArticleGeneralPickForm.PickArticleGeneral("", null, FormOperation.Pick);
            if (result != null)
            {
                (EditBindingSource.Current as Article).ArticleIdGeneral = result.Id;
                tbArticleGeneral.Text = result.Name;
                (EditBindingSource.Current as Article).ArticleIdGeneralDescr = result.Name;
            }
        }
    }
}
