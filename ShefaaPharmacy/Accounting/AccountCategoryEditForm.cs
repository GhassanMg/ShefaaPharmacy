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
using DataLayer.Enums;

namespace ShefaaPharmacy.Accounting
{
    public partial class AccountCategoryEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        AccountCategory accountCategory;
        public AccountCategoryEditForm()
        {
            InitializeComponent();
        }
        public AccountCategoryEditForm(AccountCategory entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            accountCategory = entity;
            FormOperation = formOperation;
            if (entity.Id == 0)
            {
                this.Text = "تعريف حساب رئيسي";
            }
            else
            {
                this.Text = "تعديل حساب رئيسي";
            }
            EditBindingSource.DataSource = accountCategory;
        }
        public static AccountCategory CreateAccountCategory(AccountCategory accountCategory, FormOperation formOperation = FormOperation.New)
        {
            AccountCategoryEditForm fmEdit = new AccountCategoryEditForm(accountCategory, formOperation);
            try
            {
                fmEdit.Text = "تعريف نوع حساب";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return fmEdit.accountCategory;
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
            cbAccountBaseCategory.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().AccountBaseCategorys.ToList();
            cbAccountBaseCategory.DisplayMember = "Name";
            cbAccountBaseCategory.ValueMember = "Id";
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
                    accountCategory.AccountBaseCategoryId = (int)cbAccountBaseCategory.SelectedValue;
                    context.AccountCategorys.Add(accountCategory);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة حساب رئيسي جديد", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    context.AccountCategorys.Update(accountCategory);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات الحساب الرئيسي", MessageBoxState.Done);
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
            accountCategory = new AccountCategory();
            e.NewObject = accountCategory;
        }

        private void AccountCategoryEditForm_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                this.Text = "تعريف نوع حساب جديد";
            }
            else
            {
                this.Text = "تعديل نوع حساب";
            }
        }

        private void cbAccountBaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
