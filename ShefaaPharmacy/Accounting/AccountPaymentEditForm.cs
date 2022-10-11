using DataLayer;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Accounting
{
    public partial class AccountPaymentEditForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        int accountId;
        int accountCashId;
        PayingCashState payingCashState;
        //string Status;
        public AccountPaymentEditForm()
        {
            InitializeComponent();
            btnMaximaizing.Enabled = false;
        }
        public AccountPaymentEditForm(PayingCashState payingCashState, string status)
        {
            InitializeComponent();
            this.payingCashState = payingCashState;
            //this.Status = status;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            if (tbAccountCash.Text == "")
            {
                _MessageBoxDialog.Show("يجب اختيار حساب صندوق", MessageBoxState.Error);
                return;
            }
            if (tbAccountId.Text == "")
            {
                _MessageBoxDialog.Show("يجب اختيار حساب الزبون", MessageBoxState.Error);
                return;
            }
            if (tbAmount.Text == "")
            {
                _MessageBoxDialog.Show("يجب تعبئة مبلغ", MessageBoxState.Error);
                return;
            }
            if (tbAccountId.Text == tbAccountCash.Text)
            {
                _MessageBoxDialog.Show("يجب وضع حسابين مختلفين", MessageBoxState.Error);
                return;
            }
            if (context.EntryMasters.FirstOrDefault(x => x.Id == Convert.ToInt32(tbId.Text)) == null)
            {
                bool result = EntryService.PaymentAccount(accountCashId, accountId, Convert.ToDouble(tbAmount.Text), dtDate.Value, tbDescription.Text ?? "دفعة حساب", payingCashState);
                if (result)
                {
                    _MessageBoxDialog.Show("تم إضافة دفعة حساب", MessageBoxState.Done);
                    tbAccountCash.Text = "";
                    tbAccountId.Text = "";
                    tbAmount.Text = "";
                    accountCashId = 0;
                    accountId = 0;
                    tbDescription.Text = "";
                    tbId.Text = (ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.ToList().LastOrDefault().Id + 1).ToString();
                }
                else
                {
                    _MessageBoxDialog.Show("خطأ في حفظ الدفعة", MessageBoxState.Error);
                    return;
                }
            }
        }

        private void AccountPaymentEditForm_Load(object sender, EventArgs e)
        {
            dtDate.Value = DateTime.Now;
            List<string> data = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.
                Where(x => x.CategoryId == ConstantDataBase.AC_Supplier || x.CategoryId == ConstantDataBase.AC_Customer).ToList().Select(x => x.Name).ToList();
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            data.ForEach(x => autoCompleteStringCollection.Add(x));
            tbAccountId.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbAccountId.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbAccountId.AutoCompleteCustomSource = autoCompleteStringCollection;

            List<string> dataCashes = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.
                Where(x => x.CategoryId == ConstantDataBase.AC_Cash).ToList().Select(x => x.Name).ToList();
            AutoCompleteStringCollection autoCompleteStringCollection2 = new AutoCompleteStringCollection();
            dataCashes.ForEach(x => autoCompleteStringCollection2.Add(x));
            tbAccountCash.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbAccountCash.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbAccountCash.AutoCompleteCustomSource = autoCompleteStringCollection2;
            try
            {
                tbId.Text = (ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.ToList().LastOrDefault().Id + 1).ToString();

            }
            catch
            {
                return;
            }
            if (payingCashState == PayingCashState.InComing)
            {
                rbCashIn.Checked = true;
            }
            else
            {
                rbCashOut.Checked = true;
            }
        }

        private void pbAccountPick_Click(object sender, EventArgs e)
        {
            if (tbAccountId.Text != "")
            {
                tbAccountId.Clear();
            }
            Account result = AccountPickForm.PickAccount(tbAccountId.Text.ToString().Trim(), null, null, FormOperation.Pick, false);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
            }
            else
            {
                tbAccountId.Text = result.Name;
                accountId = result.Id;
            }
        }
        private void pbAccountCashPick_Click(object sender, EventArgs e)
        {
            if (tbAccountCash.Text != "")
            {
                tbAccountCash.Clear();
            }
            Account result = AccountPickForm.PickAccount(tbAccountCash.Text.ToString().Trim(), new int[1] { ConstantDataBase.AC_Cash }, null, FormOperation.Pick);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
            }
            else
            {
                tbAccountCash.Text = result.Name;
                accountCashId = result.Id;
            }
        }

        private void tbAccountId_TextChanged(object sender, EventArgs e)
        {
            if (tbAccountId.Text.Trim() != "")
            {
                Account account = DescriptionFK.AccountExists(true, tbAccountId.Text, 0);
                if (account != null)
                {
                    accountId = account.Id;
                }
            }
        }

        private void tbAccountCash_TextChanged(object sender, EventArgs e)
        {
            if (tbAccountCash.Text.Trim() != "")
            {
                Account account = DescriptionFK.AccountExists<Account>(x => x.CategoryId == ConstantDataBase.AC_Cash && x.Name == tbAccountCash.Text);
                if (account != null)
                {
                    accountCashId = account.Id;
                }
            }
        }

        private void rbCashOut_CheckedChanged(object sender, EventArgs e)
        {
            payingCashState = PayingCashState.OutComing;
        }

        private void rbCashIn_CheckedChanged(object sender, EventArgs e)
        {
            payingCashState = PayingCashState.InComing;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void BindEditData(EntryDetail Entry)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            tbId.Text = Entry.EntryMasterId.ToString();
            tbAccountCash.Text = DescriptionFK.GetAccountName(Entry.AccountId);
            tbAccountId.Text = DescriptionFK.GetAccountName(context.EntryDetails.FirstOrDefault(x => x.Id == (Entry.Id + 1)).AccountId);
            dtDate.Value = Entry.CreationDate;
            tbDescription.Text = Entry.Description;
            if (Entry.Debit != 0)
            {
                rbCashIn.Checked = true;
                tbAmount.Text = Entry.Debit.ToString();
            }
            else
            {
                rbCashOut.Checked = true;
                tbAmount.Text = Entry.Credit.ToString();

            }
        }
        private void ClearData()
        {
            tbAccountCash.Text = "";
            tbAccountId.Text = "";
            tbAmount.Text = "";
            tbDescription.Text = "";
            dtDate.Value = DateTime.Now;
        }
        private void tbId_TextChanged(object sender, EventArgs e)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            try
            {
                var myMasterEntryId = context.EntryMasters.FirstOrDefault(x => x.Id == Convert.ToInt32(tbId.Text)).Id;
                var myEntryDetail = context.EntryDetails.Where(x => x.EntryMasterId == myMasterEntryId).ToList().FirstOrDefault();
                if (myEntryDetail.KindOperation == KindOperation.Payment)
                {
                    BindEditData(myEntryDetail);
                    btnEdit.Visible = true;
                    btnOk.Visible = false;
                }
                else
                {
                    ClearData();
                    btnOk.Visible = true;
                    btnEdit.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ClearData();
                return;
            }
        }

        private void tbId_Validating(object sender, CancelEventArgs e)
        {
            if (tbId.Text == "")
            {
                tbId.Text = (ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.ToList().LastOrDefault().Id + 1).ToString();
                tbAccountCash.Text = "";
                tbAccountId.Text = "";
                tbAmount.Text = "";
                accountCashId = 0;
                accountId = 0;
                tbDescription.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            try
            {
                EntryMaster CurrentMaster = context.EntryMasters.FirstOrDefault(x => x.Id == Convert.ToInt32(tbId.Text));
                EntryDetail CurrentDetail = context.EntryDetails.Where(x => x.EntryMasterId == CurrentMaster.Id).ToList().FirstOrDefault();

                CurrentMaster.TotalCredit = Convert.ToInt32(tbAmount.Text);
                CurrentMaster.TotalDebit = Convert.ToInt32(tbAmount.Text);
                CurrentMaster.CreationDate = dtDate.Value;
                context.EntryMasters.Update(CurrentMaster);
                context.SaveChanges();

                List<EntryDetail> entryDetails = new List<EntryDetail>();
                if (payingCashState == PayingCashState.InComing)
                {
                    EntryService.EditEntryDetail(CurrentDetail.Id, accountCashId, Convert.ToDouble(tbAmount.Text), 0, dtDate.Value, tbDescription.Text == "" ? "دفعة حساب" : tbDescription.Text);

                    EntryService.EditEntryDetail(CurrentDetail.Id + 1, accountId, 0, Convert.ToDouble(tbAmount.Text), dtDate.Value, tbDescription.Text == "" ? "دفعة حساب" : tbDescription.Text);
                }
                else
                {
                    EntryService.EditEntryDetail(CurrentDetail.Id, accountCashId, 0, Convert.ToDouble(tbAmount.Text), dtDate.Value, tbDescription.Text == "" ? "دفعة حساب" : tbDescription.Text);

                    EntryService.EditEntryDetail(CurrentDetail.Id + 1, accountId, Convert.ToDouble(tbAmount.Text), 0, dtDate.Value, tbDescription.Text == "" ? "دفعة حساب" : tbDescription.Text);
                }
            }
            catch
            {
                _MessageBoxDialog.Show("خطأ في حفظ الدفعة", MessageBoxState.Error);
                return;
            }
            _MessageBoxDialog.Show("تم تعديل دفعة الحساب", MessageBoxState.Done);
            tbAccountCash.Text = "";
            tbAccountId.Text = "";
            tbAmount.Text = "";
            accountCashId = 0;
            accountId = 0;
            tbDescription.Text = "";
            tbId.Text = (ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.ToList().LastOrDefault().Id + 1).ToString();
        }
    }
}
