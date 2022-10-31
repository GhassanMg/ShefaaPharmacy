using DataLayer;
using DataLayer.Enums;
using DataLayer.Tables;
using DataLayer.Services;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Articale;
using ShefaaPharmacy.GeneralUI;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShefaaPharmacy.Articles
{
    public partial class ArticlePicker : AbstractForm
    {
        List<Article> Articles { set; get; }
        public string TextFilter { get; set; } = "";
        public int GeneralId { get; set; } = 0;
        public Article SelectedArticle { get; set; }
        public static string[] ShowColumn = new string[] { "EnglishName", "Name", "ArticleCategoryIdDescr", "ArticleIdGeneralDescr", "FormatIdDescr", "Barcode", "CompanyIdDescr" };
        public ArticlePicker()
        {
            InitializeComponent();
        }
        public ArticlePicker(List<Article> articles)
        {
            this.Articles = articles;
            InitializeComponent();
        }
        public ArticlePicker(string textFilter = "", int generalId = 0, FormOperation formOperation = FormOperation.Show)
        {
            TextFilter = textFilter;
            GeneralId = generalId;
            FormOperation = formOperation;
            InitializeComponent();
        }
        private void dataGridView1_BindingContextChanged(object sender, EventArgs e)
        {
            dtArticlesTable.Refresh();
        }
        private void LoadGridView()
        {
            if (GeneralId != 0)
            {
                Articles = ShefaaPharmacyDbContext.GetCurrentContext().Articles
                    .Where(x => x.ArticleIdGeneral == GeneralId)
                    .Select(x =>
                        new Article()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            EnglishName = x.EnglishName,
                            ArticleCategoryId = x.ArticleCategoryId,
                            ArticleIdGeneral = x.ArticleIdGeneral,
                            FormatId = x.FormatId,
                            CompanyId = x.CompanyId,
                            Barcode = x.Barcode
                        })
                    .ToList();
            }
            else
            {
                if (TextFilter.Trim() != "")
                {
                    if (tsddlSearch2.Text == "جميع المستودعات")
                    {
                        Articles = ShefaaPharmacyDbContext.GetCurrentContext().Articles
                        .Where(x => x.Name.Contains(TextFilter) || x.EnglishName.Contains(TextFilter))
                        .Select(x =>
                            new Article()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                EnglishName = x.EnglishName,
                                ArticleCategoryId = x.ArticleCategoryId,
                                ArticleIdGeneral = x.ArticleIdGeneral,
                                FormatId = x.FormatId,
                                CompanyId = x.CompanyId,
                                Barcode = x.Barcode
                            })
                        .ToList();
                    }
                    else
                    {
                        Articles = ShefaaPharmacyDbContext.GetCurrentContext().Articles
                        .Where(x => x.Name.Contains(TextFilter) || x.EnglishName.Contains(TextFilter))
                        .Where(x => x.Company == tsddlSearch2.SelectedItem)
                        .Select(x =>
                            new Article()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                EnglishName = x.EnglishName,
                                ArticleCategoryId = x.ArticleCategoryId,
                                ArticleIdGeneral = x.ArticleIdGeneral,
                                FormatId = x.FormatId,
                                CompanyId = x.CompanyId,
                                Barcode = x.Barcode
                            })
                        .ToList();
                    }
                }
                else
                {
                    if (tsddlSearch2.Text == "جميع المستودعات")
                    {
                        Articles = ShefaaPharmacyDbContext.GetCurrentContext().Articles
                        .Where(x => !x.ItsGeneral)
                        .Select(x =>
                            new Article()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                EnglishName = x.EnglishName,
                                ArticleCategoryId = x.ArticleCategoryId,
                                ArticleIdGeneral = x.ArticleIdGeneral,
                                FormatId = x.FormatId,
                                CompanyId = x.CompanyId,
                                Barcode = x.Barcode
                            })
                        .ToList();
                    }
                    else
                    {
                        Articles = ShefaaPharmacyDbContext.GetCurrentContext().Articles
                        .Where(x => !x.ItsGeneral)
                        .Where(x => x.Company == tsddlSearch2.SelectedItem)
                        .Select(x =>
                            new Article()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                EnglishName = x.EnglishName,
                                ArticleCategoryId = x.ArticleCategoryId,
                                ArticleIdGeneral = x.ArticleIdGeneral,
                                FormatId = x.FormatId,
                                CompanyId = x.CompanyId,
                                Barcode = x.Barcode
                            })
                        .ToList();
                    }
                }
                bsGridView.DataSource = Articles.ToList();
                dtArticlesTable.DataSource = bsGridView;
            }
        }
        public static Article PickArticale(string textFilter, int generalId, FormOperation formOperation = FormOperation.Show)
        {
            ArticlePicker fmPick = new ArticlePicker(textFilter, generalId, formOperation);
            try
            {
                fmPick.TextFilter = textFilter;
                fmPick.GeneralId = generalId;
                fmPick.FormOperation = formOperation;
                fmPick.ShowDialog();
                return fmPick.SelectedArticle;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        private void ConnectWithBinding()
        {
            tbSize.DataBindings.Add("text", bsControls, "Size", false, DataSourceUpdateMode.OnPropertyChanged);
            tbCaliber.DataBindings.Add("text", bsControls, "Caliber", false, DataSourceUpdateMode.OnPropertyChanged);
            tbLimitUp.DataBindings.Add("text", bsControls, "LimitUp", false, DataSourceUpdateMode.OnPropertyChanged);
            tbLimitDown.DataBindings.Add("text", bsControls, "LimitDown", false, DataSourceUpdateMode.OnPropertyChanged);
            cbIsForeign.DataBindings.Add("checked", bsControls, "IsForeign", false, DataSourceUpdateMode.OnPropertyChanged);
            tbScientificName.DataBindings.Add("text", bsControls, "ScientificName", false, DataSourceUpdateMode.OnPropertyChanged);
            tbSideEffects.DataBindings.Add("text", bsControls, "SideEffects", false, DataSourceUpdateMode.OnPropertyChanged);
            tbDosage.DataBindings.Add("text", bsControls, "Dosage", false, DataSourceUpdateMode.OnPropertyChanged);
            tbActiveIngredients.DataBindings.Add("text", bsControls, "ActiveIngredients", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void ArticlePicker_Load(object sender, EventArgs e)
        {
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

            tsddlSearch.SelectedIndexChanged += tsddlSearch_SelectedIndexChanged;
            tsddlSearch2.SelectedIndexChanged += tsddlSearch2_SelectedIndexChanged;
            LoadGridView();
            ShowAndHideColumn();
            if (Articles.Count > 0)
            {
                ConnectWithBinding();
            }
            if (FormOperation == FormOperation.Pick)
            {
                Text = "إختر مادة";
            }
            else
            {
                Text = "إستعراض المواد";
            }
        }
        public void ShowAndHideColumn()
        {
            foreach (DataGridViewColumn item in dtArticlesTable.Columns)
            {
                if (ShowColumn == null || !ShowColumn.Contains(item.Name))
                {
                    item.Visible = false;
                }
                else
                {
                    item.Visible = true;
                }
            }
            dtArticlesTable.Refresh();
        }
        private void tsddlSearch_SelectedIndexChanged(object sender, EventArgs e)
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
                bsGridView.DataSource = DescriptionFK.articlesForPicker.ToList();
            }
            catch (Exception ex)
            {
                ;
            }
        }
        private void tsddlSearch2_SelectedIndexChanged(object sender, EventArgs e)
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
                bsGridView.DataSource = DescriptionFK.articlesForPicker.ToList();
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (bsGridView.Current == null)
                return;
            if (Auth.IsDataEntry())
            {
                ArticaleEditForm articaleEditForm = new ArticaleEditForm((bsGridView.Current as Article), FormOperation.EditFromPicker);
                articaleEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void SetCurrentEntity()
        {
            if (bsGridView.Current != null)
            {
                SelectedArticle = ShefaaPharmacyDbContext.GetCurrentContext().Articles.AsNoTracking().FirstOrDefault(x => x.Id == (bsGridView.Current as Article).Id);
            }
        }
        private void dtArticlesTable_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            SetCurrentEntity();
            if (FormOperation != FormOperation.Pick)
            {
                if (Auth.IsDataEntry())
                {
                    var art = ShefaaPharmacyDbContext.GetCurrentContext();
                    ArticaleEditForm edForm = new ArticaleEditForm(art.Articles.FirstOrDefault(x => x.Id == SelectedArticle.Id), FormOperation.EditFromPicker);
                    edForm.ShowDialog();
                    edForm.Dispose();
                    LoadGridView();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            else
            {
                Close();
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                ArticaleEditForm articaleEditForm = new ArticaleEditForm(null, FormOperation.NewFromPicker);
                articaleEditForm.ShowDialog();
                LoadGridView();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }

        private void bsGridView_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (bsGridView.Current != null)
                {
                    var data = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Id == (bsGridView.Current as Article).Id);
                    if (data != null)
                        bsControls.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void tsFilterdText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GeneralId = 0;
                TextFilter = tsFilterdText.Text;
                LoadGridView();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void DtArticlesTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (FormOperation == FormOperation.Pick)
                {
                    SetCurrentEntity();
                    Close();
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtArticlesTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsFilterdText_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (bsGridView.Current == null)
                return;
            if (Auth.IsDataEntry())
            {
                ShefaaPharmacyDbContext context = new ShefaaPharmacyDbContext();

                context.Articles.Remove(bsGridView.Current as Article);
                context.SaveChanges();

                _MessageBoxDialog.Show("تم حذف المادة", MessageBoxState.Done);
                dtArticlesTable.Rows.Remove(dtArticlesTable.CurrentRow);
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
    }
}
