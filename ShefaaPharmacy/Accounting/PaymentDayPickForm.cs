using DataLayer.Enums;
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

namespace ShefaaPharmacy.Accounting
{
    public partial class PaymentDayPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        EntryMaster entry;
        public PaymentDayPickForm()
        {
            InitializeComponent();
        }
        public PaymentDayPickForm(EntryMaster entry)
        {
            this.entry = entry;
            InitializeComponent();
        }
        public static EntryMaster PickEntry(EntryMaster entry, FormOperation formOperation = FormOperation.Show)
        {
            PaymentDayPickForm fmPick = new PaymentDayPickForm(entry);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض الدفعات اليومية";
                fmPick.ShowDialog();
                return entry;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static EntryMaster PickEntry(int textFilter, EntryMaster entry, FormOperation formOperation = FormOperation.Show)
        {
            EntryMaster tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.Where(x => x.Id == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            PaymentDayPickForm fmPick = new PaymentDayPickForm(entry);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر سند القيد";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return entry;
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
            PickGridView.Refresh();
        }
        protected override void Rebinding()
        {
            var firstTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1);
            var LastTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            if (entry == null || entry.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters
                    .Where(x => x.KindOperation == KindOperation.Payment && x.CreationDate >= firstTime && x.CreationDate <= LastTime).ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.Where(x => x.Id == entry.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = entry;
        }
        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            if (Auth.IsDataEntry())
            {
                AccountPaymentEditForm accountPaymentEditForm = new AccountPaymentEditForm(PayingCashState.InComing, "NewPayment");
                accountPaymentEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
            Rebinding();
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            EntryEditForm entryEditForm = new EntryEditForm((PickBindingSource.Current as EntryMaster), (PickBindingSource.Current as EntryMaster).KindOperation, FormOperation.EditFromPicker);
            entryEditForm.ShowDialog();
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if ((FormOperation != FormOperation.EditFromPicker))
            {
                if (PickBindingSource.Current == null)
                    return;
                EntryEditForm entryEditForm = new EntryEditForm((PickBindingSource.Current as EntryMaster), (PickBindingSource.Current as EntryMaster).KindOperation, FormOperation.EditFromPicker);
                entryEditForm.ShowDialog();
                Rebinding();
            }
        }

        private void PaymentDayPickForm_Load(object sender, EventArgs e)
        {

        }
    }
}
