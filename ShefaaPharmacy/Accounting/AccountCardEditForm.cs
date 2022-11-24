using DataLayer.Enums;
using DataLayer;
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
using System.Text.RegularExpressions;

namespace ShefaaPharmacy.Accounting
{
    public partial class AccountCardEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        Account account;
        public AccountCardEditForm()
        {
            InitializeComponent();
        }
        public AccountCardEditForm(Account entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            account = entity;
            FormOperation = formOperation;
            if (entity.Id == 0)
            {
                Text = "تعريف بطاقة حساب";
            }
            else
            {
                Text = "تعديل بطاقة حساب";
            }
            EditBindingSource.DataSource = account;
        }
        public static Account CreateAccount(Account account, FormOperation formOperation = FormOperation.New)
        {
            AccountCardEditForm fmEdit = new AccountCardEditForm(account);
            try
            {
                fmEdit.Text = "تعريف بطاقة حساب";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return fmEdit.account;
            }
            finally
            {
                fmEdit.Dispose();
            }
        }

        private void EditBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            BindingEntityToControls();
        }
        private bool AccountNameValidating()
        {
            Account acc = DescriptionFK.AccountExists(true, tbName.Text.Trim(), 0);
            if (acc != null && acc.Name != "")
            {
                _MessageBoxDialog.Show("الحساب معرف مسبقا", MessageBoxState.Warning);
                return false;
            }
            return true;
        }
        private void BindingEntityToControls()
        {
            tbName.DataBindings.Add("text", EditBindingSource, "Name");
            tbLastName.DataBindings.Add("text", EditBindingSource, "LastName");
            tbTel.DataBindings.Add("text", EditBindingSource, "Tel");
            tbTel2.DataBindings.Add("text", EditBindingSource, "Tel2");
            tbAddress.DataBindings.Add("text", EditBindingSource, "Address");
            tbAddress2.DataBindings.Add("text", EditBindingSource, "Address2");
            tbAccountParent.DataBindings.Add("text", EditBindingSource, "AccountGeneralIdDescr");
            tbDescription.DataBindings.Add("text", EditBindingSource, "Description");

            List<string> data = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(x => x.General).Select(x => x.Name).ToList();
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            data.ForEach(x => autoCompleteStringCollection.Add(x));
            tbAccountParent.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbAccountParent.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbAccountParent.AutoCompleteCustomSource = autoCompleteStringCollection;

            AccountBaseCategory accountBaseCategory = account == null ? null : ShefaaPharmacyDbContext.GetCurrentContext().AccountBaseCategorys.FirstOrDefault(x => x.Id == account.CategoryId);
            HelperUI.ConfigrationComboBox<AccountBaseCategory>(cbCategory, ShefaaPharmacyDbContext.GetCurrentContext().AccountBaseCategorys.ToList(),
                accountBaseCategory, "Name", "Id", FormOperation);

            HelperUI.BindToEnum<AccountState>(cbAccountState);
            if (FormOperation == FormOperation.New || FormOperation == FormOperation.NewFromPicker)
            {
                cbAccountState.SelectedIndex = 2;
                cbAccountState.Enabled = false;
                rbChild.Checked = true;
            }
            else
            {
                cbAccountState.SelectedItem = (int)account.AccountState;
                rbChild.Checked = account.General;
            }
        }
        public void AssignedAccountCategory(string value)
        {
            Account result = AccountPickForm.PickAccount(value, null, null, FormOperation.Pick, true);
            if (result != null)
            {
                (EditBindingSource.Current as Account).AccountGeneralId = result.Id;
                tbAccountParent.Text = result.Name;
                (EditBindingSource.Current as Account).AccountGeneralIdDescr = result.Name;
            }
        }
        private void cbAccountState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                (EditBindingSource.Current as Account).AccountState = (AccountState)(cbAccountState.SelectedValue);
            }
            catch (Exception)
            {
                (EditBindingSource.Current as Account).AccountState = ((AccountState)((KeyValuePair<string, object>)cbAccountState.SelectedValue).Value);
            }
        }
        private void rbChild_CheckedChanged(object sender, EventArgs e)
        {
            tbTel.Enabled = true;
            tbTel2.Enabled = true;
            tbAddress.Enabled = true;
            tbAddress2.Enabled = true;
            account.General = rbParent.Checked;
            if (rbChild.Checked)
            {

                lbCategory.Visible = false;
                cbCategory.Visible = false;

                tbAccountParent.Visible = true;
                lbAccountParent.Visible = true;
            }
            else
            {
                lbCategory.Visible = true;
                cbCategory.Visible = true;

                tbAccountParent.Visible = false;
                lbAccountParent.Visible = false;

            }
        }
        private void tbAccountParent_Validating(object sender, CancelEventArgs e)
        {
            Account acc = DescriptionFK.AccountExists(true, tbAccountParent.Text.Trim(), 0);
            if (acc != null && acc.Name != "")
            {
                account.AccountGeneralId = acc.Id;
            }
        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            if (!DescriptionFK.IsValid((EditBindingSource.Current as Account).Name))
            {
                _MessageBoxDialog.Show("يرجى إدخال اسم للحساب!!", MessageBoxState.Warning);
                //NameValidateBox.Visible = true;
                return;

            }
            try
            {
                base.btOk_Click(sender, e);
            }
            catch (Exception)
            {
                return;
            }
            tbName.Focus();
            tbAddress.Focus();
            try
            {
                if (!AccountNameValidating())
                {
                    return;
                }
                if (!(EditBindingSource.Current as Account).General && ((EditBindingSource.Current as Account).AccountGeneralId == 0 || (EditBindingSource.Current as Account).AccountGeneralId == null))
                {
                    _MessageBoxDialog.Show("يجب إختيار حساب رئيسي", MessageBoxState.Error);
                    return;
                }
                if (!(EditBindingSource.Current as Account).General)
                {
                    (EditBindingSource.Current as Account).CategoryId = DescriptionFK.GetAccountCategory((EditBindingSource.Current as Account).AccountGeneralId);
                }
                else
                {
                    (EditBindingSource.Current as Account).CategoryId = (int)cbCategory.SelectedValue;
                }
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (FormOperation==FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                {
                    context.Accounts.Add(EditBindingSource.Current as Account);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة بطاقة حساب جديدة", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                        return;
                    }
                }
                else
                {
                    context.Accounts.Update(EditBindingSource.Current as Account);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات بطاقة الحساب", MessageBoxState.Done);
                    if (FormOperation == FormOperation.EditFromPicker)
                    {
                        Close();
                        return;
                    }
                }
                EditBindingSource.AddNew();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
            }
        }

        private void lbAccountParent_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AssignedAccountCategory("");
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                (EditBindingSource.Current as Account).CategoryId = (int)cbCategory.SelectedValue;
            }
            catch (Exception)
            {
                ;
            }
        }
        private void CheckKeys(object sender, KeyPressEventArgs e)
        {
            Regex phoneNumpattern = new Regex(@"\+[0-9]{3}\s+[0-9]{3}\s+[0-9]{5}\s+[0-9]{3}");
            if (phoneNumpattern.IsMatch(tbTel.Text)|| phoneNumpattern.IsMatch(tbTel2.Text))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbParent_CheckedChanged(object sender, EventArgs e)
        {
            tbTel.Enabled = false;
            tbTel2.Enabled = false;
            tbAddress.Enabled = false;
            tbAddress2.Enabled = false;
        }

        private void AllAccounts_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    AccountPickForm accountPickForm = new AccountPickForm(new Account());
                    accountPickForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void tbTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // only allow one plus char
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbTel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // only allow one plus char
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            {
                e.Handled = true;
            }
        }

        //private void tbTel_Validating(object sender, CancelEventArgs e)
        //{
        //    Account acc = DescriptionFK.AccountExists(true, tbName.Text.Trim(), 0);
        //    if (acc != null && acc.Name != "")
        //    {
        //        _MessageBoxDialog.Show("الحساب معرف مسبقا", MessageBoxState.Warning);
        //        return false;
        //    }
        //    return true;
        //}
    }
}
