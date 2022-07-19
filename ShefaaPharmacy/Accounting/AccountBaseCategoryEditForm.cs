using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataLayer.Enums;
namespace ShefaaPharmacy.Accounting
{
    public partial class AccountBaseCategoryEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        AccountBaseCategory accountBaseCategory;
        public AccountBaseCategoryEditForm()
        {
            InitializeComponent();
        }
        public AccountBaseCategoryEditForm(AccountBaseCategory entity, FormOperation formOperation)
        {
            InitializeComponent();
            accountBaseCategory = entity;
            FormOperation = formOperation;
            if (entity.Id == 0)
            {
                this.Text = "تعريف نوع حساب";
            }
            else
            {
                this.Text = "تعديل نوع حساب";
            }
            EditBindingSource.DataSource = accountBaseCategory;
        }
        public static AccountBaseCategory CreateAccountBaseCategory(AccountBaseCategory accountBaseCategory, FormOperation formOperation = FormOperation.New)
        {
            AccountBaseCategoryEditForm fmEdit = new AccountBaseCategoryEditForm(accountBaseCategory, formOperation);
            try
            {
                fmEdit.Text = "تعريف نوع حساب";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return fmEdit.accountBaseCategory;
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
                if (FormOperation == FormOperation.New)
                {
                    context.AccountBaseCategorys.Add(accountBaseCategory);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة نوع حساب جديد", MessageBoxState.Done);
                    if (FormOperation == FormOperation.Pick)
                    {
                        Close();
                    }
                }
                else
                {
                    context.AccountBaseCategorys.Update(accountBaseCategory);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات نوع الحساب", MessageBoxState.Done);
                    if (FormOperation == FormOperation.Pick)
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
            accountBaseCategory = new AccountBaseCategory();
            e.NewObject = accountBaseCategory;
        }
    }
}
