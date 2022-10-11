using DataLayer;
using DataLayer.Tables;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataLayer.Enums;

namespace ShefaaPharmacy.Accounting
{
    public partial class AccountBaseCategoryPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        AccountBaseCategory accountBaseCategory;
        public AccountBaseCategoryPickForm()
        {
            InitializeComponent();
        }
        public AccountBaseCategoryPickForm(AccountBaseCategory accountBaseCategory)
        {
            this.accountBaseCategory = accountBaseCategory;
            InitializeComponent();
        }
        public static AccountBaseCategory PickAccountCategory(AccountBaseCategory accountBaseCategory, FormOperation formOperation = FormOperation.Pick)
        {
            AccountBaseCategoryPickForm fmPick = new AccountBaseCategoryPickForm(accountBaseCategory);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض أنواع الحسابات";
                fmPick.ShowDialog();
                return (AccountBaseCategory)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static AccountBaseCategory PickAccountCategory(string textFilter, AccountBaseCategory accountBaseCategory, FormOperation formOperation = FormOperation.Pick)
        {
            AccountBaseCategory tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().AccountBaseCategorys.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            AccountBaseCategoryPickForm fmPick = new AccountBaseCategoryPickForm(accountBaseCategory);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر نوع الحساب";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (AccountBaseCategory)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        protected override void AdjustmentGridColumns()
        {
            base.AdjustmentGridColumns();
            HiddenColumn = new string[] { "Id" };
        }
        protected override void Rebinding()
        {
            if (accountBaseCategory == null || accountBaseCategory.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().AccountBaseCategorys.ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().AccountBaseCategorys.Where(x => x.Id == accountBaseCategory.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (AccountBaseCategory)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            shefaaPharmacyDbContext.AccountBaseCategorys.Remove(CurrentEntity as AccountBaseCategory);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            AccountBaseCategoryEditForm.CreateAccountBaseCategory(CurrentEntity as AccountBaseCategory, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (!(FormOperation == FormOperation.Pick))
            {
                AccountBaseCategoryEditForm edForm = new AccountBaseCategoryEditForm(CurrentEntity as AccountBaseCategory, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            if (!(FormOperation == FormOperation.Pick))
            {
                SetCurrentEntity();
                AccountBaseCategoryEditForm edForm = new AccountBaseCategoryEditForm(CurrentEntity as AccountBaseCategory, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
    }
}
