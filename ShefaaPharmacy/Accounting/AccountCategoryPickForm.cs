using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Accounting
{
    public partial class AccountCategoryPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        AccountCategory accountCategory;
        public AccountCategoryPickForm()
        {
            InitializeComponent();
        }
        public AccountCategoryPickForm(AccountCategory accountCategory)
        {
            this.accountCategory = accountCategory;
            InitializeComponent();
        }
        public static AccountCategory PickAccountCategory(AccountCategory accountCategory, FormOperation formOperation = FormOperation.Pick)
        {
            AccountCategoryPickForm fmPick = new AccountCategoryPickForm(accountCategory);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض الحسابات الرئيسية";
                fmPick.ShowDialog();
                return (AccountCategory)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static AccountCategory PickAccountCategory(string textFilter, AccountCategory AccountCategory, FormOperation formOperation = FormOperation.Pick)
        {
            AccountCategory tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().AccountCategorys.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            AccountCategoryPickForm fmPick = new AccountCategoryPickForm(AccountCategory);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر حساب رئيسي";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (AccountCategory)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        protected override void AdjustmentGridColumns()
        {
            base.AdjustmentGridColumns();
            HiddenColumn = new string[] { "Id", "AccountBaseCategoryId" };
        }
        protected override void Rebinding()
        {
            if (accountCategory == null || accountCategory.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().AccountCategorys.ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().AccountCategorys.Where(x => x.Id == accountCategory.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (AccountCategory)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            shefaaPharmacyDbContext.AccountCategorys.Remove(CurrentEntity as AccountCategory);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            AccountCategoryEditForm.CreateAccountCategory(CurrentEntity as AccountCategory, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (!(FormOperation == FormOperation.Pick))
            {
                AccountCategoryEditForm edForm = new AccountCategoryEditForm(CurrentEntity as AccountCategory, FormOperation.EditFromPicker);
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
                AccountCategoryEditForm edForm = new AccountCategoryEditForm(CurrentEntity as AccountCategory, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }

        private void AccountCategoryPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Pick)
            {
                this.Text = "إختر نوع حساب";
            }
            else
            {
                this.Text = "إستعراض أنواع الحسابات";
            }
        }
    }
}
