using DataLayer.Enums;
using DataLayer;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using MetroFramework.Controls;
using ShefaaPharmacy.Definition;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShefaaPharmacy.Articles;

namespace ShefaaPharmacy.Articale
{
    public partial class ArticaleEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        Article article;
        bool formNotValid = false;
        public ArticaleEditForm()
        {
            InitializeComponent();
        }

        public ArticaleEditForm(Article entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            FormOperation = formOperation;
            article = entity;
            CurrentEntity = article;
            if (entity == null || entity.Id == 0)
            {
                article = new Article();
                this.Text = "إضافة مادة";
                lbPriceTag.Visible = false;
            }
            else
            {
                this.Text = "تعديل مادة";
                lbPriceTag.Visible = true;
            }
            EditBindingSource.DataSource = article;
        }

        protected override void BindingEntityToControls()
        {
            base.BindingEntityToControls();
            tbName.DataBindings.Add("text", EditBindingSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            tbEnglishName.DataBindings.Add("text", EditBindingSource, "EnglishName", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSideEffects.DataBindings.Add("text", EditBindingSource, "SideEffects", false, DataSourceUpdateMode.OnPropertyChanged);
            tbDosage.DataBindings.Add("text", EditBindingSource, "Dosage", false, DataSourceUpdateMode.OnPropertyChanged);
            tbActiveIngredients.DataBindings.Add("text", EditBindingSource, "ActiveIngredients", false, DataSourceUpdateMode.OnPropertyChanged);
            tbInteractions.DataBindings.Add("text", EditBindingSource, "Interactions", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPrecautions.DataBindings.Add("text", EditBindingSource, "Precautions", false, DataSourceUpdateMode.OnPropertyChanged);
            tbScientificName.DataBindings.Add("text", EditBindingSource, "ScientificName", false, DataSourceUpdateMode.OnPropertyChanged);
            tbDescription.DataBindings.Add("text", EditBindingSource, "Description", false, DataSourceUpdateMode.OnPropertyChanged);
            tbNote.DataBindings.Add("text", EditBindingSource, "Note", false, DataSourceUpdateMode.OnPropertyChanged);
            tbArticleGeneral.DataBindings.Add("text", EditBindingSource, "ArticleIdGeneralDescr", true, DataSourceUpdateMode.OnPropertyChanged);
            tbSize.DataBindings.Add("text", EditBindingSource, "Size", false, DataSourceUpdateMode.OnPropertyChanged);
            tbCaliber.DataBindings.Add("text", EditBindingSource, "Caliber", false, DataSourceUpdateMode.OnPropertyChanged);
            tbFormatIdDescr.DataBindings.Add("text", EditBindingSource, "FormatIdDescr", true, DataSourceUpdateMode.OnPropertyChanged);
            tbLimitUp.DataBindings.Add("text", EditBindingSource, "LimitUp", false, DataSourceUpdateMode.OnPropertyChanged);
            tbLimitDown.DataBindings.Add("text", EditBindingSource, "LimitDown", false, DataSourceUpdateMode.OnPropertyChanged);
            cbIsForeign.DataBindings.Add("checked", EditBindingSource, "IsForeign", false, DataSourceUpdateMode.OnPropertyChanged);
            tbBarcode.DataBindings.Add("text", EditBindingSource, "Barcode", true, DataSourceUpdateMode.OnPropertyChanged);
            tbCompany.DataBindings.Add("text", EditBindingSource, "CompanyIdDescr", false, DataSourceUpdateMode.OnPropertyChanged);

            List<string> dataArticleCategory = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ItsGeneral).Select(x => x.Name).ToList();
            AutoCompleteStringCollection autoCompleteStringCollectionCat = new AutoCompleteStringCollection();
            dataArticleCategory.ForEach(x => autoCompleteStringCollectionCat.Add(x));
            tbArticleGeneral.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbArticleGeneral.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbArticleGeneral.AutoCompleteCustomSource = autoCompleteStringCollectionCat;


            List<string> dataCompany = ShefaaPharmacyDbContext.GetCurrentContext().Companys.ToList().Select(x => x.Name).ToList();
            AutoCompleteStringCollection autoCompleteCompany = new AutoCompleteStringCollection();
            dataCompany.ForEach(x => autoCompleteCompany.Add(x));
            tbCompany.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbCompany.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbCompany.AutoCompleteCustomSource = autoCompleteCompany;
        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                tbName.Focus();
                if (formNotValid)
                {
                    return;
                }
                if (!RDSFECXA__WEWDSA.Ree())
                {
                    _MessageBoxDialog.Show("النسخة غير مسجلة يجب التسجيل للإكمال", MessageBoxState.Warning);
                    return;
                }
                if (!DescriptionFK.IsValid((EditBindingSource.Current as Article).Name))
                {
                    _MessageBoxDialog.Show("لا يمكن ترك الاسم فارغاً يرجى إدخال اسم للمادة", MessageBoxState.Error);
                    NameValidateBox.Visible = true;
                    return;

                }
                if (!ValidatingArticleGeneral(false))
                {
                    _MessageBoxDialog.Show("لا يمكن ترك الصنف فارغاً يرجى إختيار صنف للمادة", MessageBoxState.Error);
                    TypeValidateBox.Visible = true;
                    return;
                }
                
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                {
                    (EditBindingSource.Current as Article).ItsGeneral = false;
                    var articleIdGeneral = (EditBindingSource.Current as Article).ArticleIdGeneral;
                    if (articleIdGeneral != null && DescriptionFK.GetArticleCategory(articleIdGeneral).ArticleCategoryId != 0)
                        (EditBindingSource.Current as Article).ArticleCategoryId = DescriptionFK.GetArticleCategory((EditBindingSource.Current as Article).ArticleIdGeneral).ArticleCategoryId;
                    var newArticale = context.Articles.Add(EditBindingSource.Current as Article);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة مادة جديدة", MessageBoxState.Done);
                    if (_MessageBoxDialog.Show("هل تريد إدخال واحدات للمادة ؟", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                    {
                        ArticleUnitsEditForm articleUnitsEditForm = new ArticleUnitsEditForm(new ArticleUnits() { ArticleId = newArticale.Entity.Id });
                        articleUnitsEditForm.ShowDialog();
                    }
                    else
                    {
                        ArticleUnits articleUnits = new ArticleUnits
                        {
                            UnitTypeId = context.UnitTypes.FirstOrDefault(x => x.Name.Contains("علبة")).Id,
                            ArticleId = newArticale.Entity.Id,
                            QuantityForPrimary = 0,
                            IsPrimary = true,
                            CreationDate = DateTime.Now,
                            CreationBy = UserLoggedIn.User.Id,
                        };
                        context.ArticleUnits.Add(articleUnits);
                        context.SaveChanges();
                    }
                    if (_MessageBoxDialog.Show("يجب إدخال بطاقة سعر للمادة ", MessageBoxState.Alert) == MessageBoxAnswer.Ok)
                    {
                        NewPriceTag articlePriceTagEditForm = new NewPriceTag(newArticale.Entity.Id);
                        articlePriceTagEditForm.ShowDialog();
                    }
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    if ((EditBindingSource.Current as Article).ArticleIdGeneral != null)
                    {
                        (EditBindingSource.Current as Article).ArticleCategoryId = DescriptionFK.GetArticleCategory((EditBindingSource.Current as Article).ArticleIdGeneral).ArticleCategoryId;
                    }
                    var newArticale = context.Articles.Update(EditBindingSource.Current as Article);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات المادة", MessageBoxState.Done);
                    if (FormOperation == FormOperation.EditFromPicker)
                    {
                        Close();
                    }
                }
                EditBindingSource.AddNew();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء التخزين", MessageBoxState.Error);
            }
        }
        private bool ValidatingArticleGeneral(bool pick = false)
        {
            if (pick)
            {

                Article result = ArticleGeneralPickForm.PickArticleGeneral("", null, FormOperation.Pick);
                if (result == null)
                {
                    return false;
                }
                else
                {
                    (EditBindingSource.Current as Article).ArticleIdGeneral = result.Id;
                    tbArticleGeneral.Text = result.Name;
                    (EditBindingSource.Current as Article).ArticleIdGeneralDescr = result.Name;
                    return true;
                }
            }
            else
            {
                if (String.IsNullOrEmpty(tbArticleGeneral.Text))
                {
                    return false;
                }
                Article result = DescriptionFK.ExistsArticleCategory(true, tbArticleGeneral.Text, 0);
                if (result != null)
                {
                    (EditBindingSource.Current as Article).ArticleCategoryId = result.Id;
                    (EditBindingSource.Current as Article).ArticleCategoryIdDescr = result.Name;
                    return true;
                }
            }
            return false;
        }

        private void lbArticaleSubCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Article result = ArticleGeneralPickForm.PickArticleGeneral("", null, FormOperation.Pick);
            if (result != null)
            {
                (EditBindingSource.Current as Article).ArticleIdGeneral = result.Id;
                tbArticleGeneral.Text = result.Name;
                (EditBindingSource.Current as Article).ArticleIdGeneralDescr = result.Name;
            }
        }

        private void lbFormatIdDescr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Format result = FormatPickForm.PickFormat("", null, FormOperation.Pick);
            if (result != null)
            {
                (EditBindingSource.Current as Article).FormatId = result.Id;
                tbFormatIdDescr.Text = result.Name;
                (EditBindingSource.Current as Article).FormatIdDescr = result.Name;
            }
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

        private void tbFormatIdDescr_Validating(object sender, CancelEventArgs e)
        {
            Format result = DescriptionFK.FormatExists(true, tbFormatIdDescr.Text, 0);
            if (result == null)
            {
                result = FormatPickForm.PickFormat("", null, FormOperation.Pick);
            }
            if (result != null)
            {
                (EditBindingSource.Current as Article).FormatId = result.Id;
                tbFormatIdDescr.Text = result.Name;
                (EditBindingSource.Current as Article).FormatIdDescr = result.Name;
            }
        }

        private void lbCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Company result = CompanyPickForm.PickCompany("", null, FormOperation.Pick);
            if (result != null)
            {
                (EditBindingSource.Current as Article).CompanyId = result.Id;
                (EditBindingSource.Current as Article).CompanyIdDescr = result.Name;
                tbCompany.Text = result.Name;
            }
        }

        private void tbBarcode_Validating(object sender, CancelEventArgs e)
        {
            if (tbBarcode.Text.Trim() != "")
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var bar = context.Articles.Where(x => x.Barcode == tbBarcode.Text.Trim() && x.Id!= (EditBindingSource.Current as Article).Id).FirstOrDefault();
                if (bar != null)
                {
                    _MessageBoxDialog.Show("لا يمكن تكرار الباركود لصنفين", MessageBoxState.Error);
                    var oldbarcode = context.Articles.Where(x => x.Id == (EditBindingSource.Current as Article).Id).FirstOrDefault().Barcode;
                    tbBarcode.Text = oldbarcode.ToString();
                    e.Cancel = true;
                    formNotValid = true;
                    return;
                }
                formNotValid = false;
            }
            else
            {
                formNotValid = false;
            }
        }

        private void LbPriceTag_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PriceTagEditForm articlePriceTagEditForm = new PriceTagEditForm(article);
            articlePriceTagEditForm.ShowDialog();
        }

        private void tbArticleGeneral_Enter(object sender, EventArgs e)
        {
            TypeValidateBox.Visible = false;
        }

        private void tbName_Enter(object sender, EventArgs e)
        {
            NameValidateBox.Visible = false;
        }
    }
}
