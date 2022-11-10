using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articale
{
    public partial class ArticaleCategoryEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        ArticleCategory articaleCategory;
        public ArticaleCategoryEditForm()
        {
            InitializeComponent();
        }
        public ArticaleCategoryEditForm(ArticleCategory entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            articaleCategory = entity;
            FormOperation = formOperation;
            EditBindingSource.DataSource = articaleCategory;
        }
        public static ArticleCategory CreateArticaleCategory(ArticleCategory articaleCategorys, FormOperation formOperation = FormOperation.New)
        {
            ArticaleCategoryEditForm fmEdit = new ArticaleCategoryEditForm(articaleCategorys, formOperation);
            try
            {
                fmEdit.Text = "تعريف صنف رئيسي ";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return fmEdit.articaleCategory;
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
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                {
                    context.ArticleCategorys.Add(articaleCategory);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة صنف رئيسي جديد", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    context.ArticleCategorys.Update(articaleCategory);
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
            articaleCategory = new ArticleCategory();
            e.NewObject = articaleCategory;
        }
        private void ArticaleCategoryEditForm_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                this.Text = "تعريف صنف رئيسي";
            }
            else
            {
                this.Text = "تعديل صنف رئيسي";
            }
        }
    }
}
