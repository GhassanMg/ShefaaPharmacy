using DataLayer.Enums;
using DataLayer;
using DataLayer.Helper;
using DataLayer.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShefaaPharmacy.Helper;

namespace ShefaaPharmacy.Accounting
{
    public partial class AccountPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        Account account;
        int DestinationAccountId;
        BindingSource temp;
        int[] category;
        bool general;
        public AccountPickForm()
        {
            InitializeComponent();
        }
        public AccountPickForm(Account account)
        {
            this.account = account;
            InitializeComponent();
        }
        //public AccountPickForm(Account account,int AccountGenId)
        //{
        //    DestinationAccountId = AccountGenId;
        //    this.account = account;
        //    InitializeComponent();
        //    temp = new BindingSource();
        //    temp.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(x => x.Name.Contains(tsFilterdText.Text) && x.General == general&&x.AccountGeneralId== AccountGenId).ToList();
        //    PickBindingSource.DataSource = temp;
        //    PickGridView.Refresh();
        //}
        public static Account PickAccount(Account account, FormOperation formOperation = FormOperation.Show)
        {
            AccountPickForm fmPick = new AccountPickForm(account);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض الفروع";
                fmPick.ShowDialog();
                return (Account)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static Account PickAccount(string textFilter, Account account, FormOperation formOperation = FormOperation.Show)
        {
            Account tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            AccountPickForm fmPick = new AccountPickForm(account);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر حساب";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (Account)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static Account PickAccount(string textFilter, Account account, int[] category, FormOperation formOperation = FormOperation.Show, bool general = false)
        {
            Account tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            AccountPickForm fmPick = new AccountPickForm(account);
            try
            {
                fmPick.general = general;
                fmPick.FormOperation = formOperation;
                if (fmPick.FormOperation == FormOperation.Pick)
                {
                    fmPick.Text = "إختر حساب";
                }
                else
                {
                    fmPick.Text = "إستعراض الحسابات";
                }
                if (category != null)
                {
                    fmPick.category = category;
                }
                fmPick.ShowDialog();
                return (Account)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static Account PickAccount(string textFilter, int[] category, Account account, FormOperation formOperation = FormOperation.Show)
        {
            Account tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            AccountPickForm fmPick = new AccountPickForm(account);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر حساب";
                fmPick.ForeColor = Color.Green;
                if (category != null)
                {
                    fmPick.category = category;
                }
                fmPick.ShowDialog();
                return (Account)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        protected override void AdjustmentGridColumns()
        {
            base.AdjustmentGridColumns();
            HiddenColumn = new string[] { "CategoryId", "CreationByDescr", "CreationDate", "AccountGeneralId", "Address2", "Tel2", "Description" };
        }
        protected override void Rebinding()
        {
            if (account == null || account.Id == 0)
            {
                if (category != null && category.Length != 0)
                {
                    PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(x => category.Contains(x.CategoryId) && x.General == general).ToList();
                }
                else
                {
                    if (general)
                    {
                        PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.ToList();
                    }
                    else
                    {
                        PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(x => x.General == false).ToList();
                    }
                }
            }
            else
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(x => x.Id == account.Id).ToList();
            }
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (Account)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            shefaaPharmacyDbContext.Accounts.Remove(CurrentEntity as Account);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            AccountCardEditForm.CreateAccount(CurrentEntity as Account, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (PickBindingSource.Current == null)
                return;
            if (FormOperation != FormOperation.Pick)
            {
                AccountCardEditForm edForm = new AccountCardEditForm(CurrentEntity as Account, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            SetCurrentEntity();
            if (FormOperation != FormOperation.Pick)
            {
                AccountCardEditForm edForm = new AccountCardEditForm(CurrentEntity as Account, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void PickGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            base.PickGridView_PreviewKeyDown(sender, e);
        }
        protected override void tsFilterdText_TextChanged(object sender, EventArgs e)
        {
            temp = new BindingSource();
            temp.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(x => x.Name.Contains(tsFilterdText.Text) && x.General == general).ToList();
            PickBindingSource.DataSource = temp;

            PickGridView.Refresh();
            PickGridView.Columns[1].Visible = false;
            PickGridView.Columns[2].Visible = false;
            PickGridView.Columns[3].Visible = false;
            PickGridView.Columns[4].Visible = false;
            PickGridView.Columns[5].Visible = false;
            PickGridView.Columns[6].Visible = false;
            PickGridView.Columns[7].Visible = false;
            PickGridView.Columns[9].Visible = false;
            PickGridView.Columns[10].Visible = false;
            PickGridView.Columns[11].Visible = false;
            PickGridView.Columns[12].Visible = false;
            PickGridView.Columns[13].Visible = false;
            PickGridView.Columns[14].Visible = false;
            PickGridView.Refresh();

        }

        private void AccountPickForm_Load(object sender, EventArgs e)
        {
            PickGridView.Columns[1].Visible = false;
            PickGridView.Columns[2].Visible = false;
            PickGridView.Columns[3].Visible = false;
            PickGridView.Columns[4].Visible = false;
            PickGridView.Columns[5].Visible = false;
            PickGridView.Columns[6].Visible = false;
            PickGridView.Columns[7].Visible = false;
            PickGridView.Columns[9].Visible = false;
            PickGridView.Columns[10].Visible = false;
            PickGridView.Columns[11].Visible = false;
            PickGridView.Columns[12].Visible = false;
            PickGridView.Columns[13].Visible = false;
            PickGridView.Columns[14].Visible = false;


        }
    }
}
