using DataLayer;
using DataLayer.Enums;
using DataLayer.Tables;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.Definition;
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

namespace ShefaaPharmacy.UserSetting
{
    public partial class UserPermissionEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        List<UserPermissions> userPermissions;
        public UserPermissionEditForm()
        {
            InitializeComponent();
        }
        public UserPermissionEditForm(List<UserPermissions> entity)
        {
            InitializeComponent();
            userPermissions = entity.Where(x => x.Id != 1).ToList();
            EditBindingSource.DataSource = userPermissions;
        }
        protected override void BindingEntityToControls()
        {
            try
            {
                base.BindingEntityToControls();
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                tbCashAccountDescr.DataBindings.Add("text", EditBindingSource, "CashAccountIdDescr");
                tbCustomerAccountDescr.DataBindings.Add("text", EditBindingSource, "CustomerAccountIdDescr");
                tbSellAccountDescr.DataBindings.Add("text", EditBindingSource, "SellAccountIdDescr");
                tbBuyAccountDescr.DataBindings.Add("text", EditBindingSource, "BuyAccountIdDescr");
                tbUserIdDescr.DataBindings.Add("text", EditBindingSource, "UserIdDescr");
                cbCanBuyBill.DataBindings.Add("checked", EditBindingSource, "CanBuyBill");
                cbCanSellBill.DataBindings.Add("checked", EditBindingSource, "CanSellBill");
                cbCanInsertEntry.DataBindings.Add("checked", EditBindingSource, "CanInsertEntry");
                cbCanDeleteBill.DataBindings.Add("checked", EditBindingSource, "CanDeleteBill");
                cbCanDeleteEntry.DataBindings.Add("checked", EditBindingSource, "CanDeleteEntry");
                if ((EditBindingSource.Current as UserPermissions).UserDesktopUI == UserDesktopUI.Icons)
                {
                    rbIcons.Checked = true;
                }
                else
                {
                    rbTabs.Checked = true;
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void tbUserIdDescr_Validating(object sender, CancelEventArgs e)
        {
            User result = UserPickForm.PickUser((sender as TextBox).Text.Trim(), null, FormOperation.Pick);
            if (result != null)
            {
                int userPermissionsIndex = (EditBindingSource.DataSource as List<UserPermissions>).FindIndex(x => x.UserId == result.Id);
                if (userPermissionsIndex == -1)
                {
                    (EditBindingSource.Current as UserPermissions).UserId = result.Id;
                    tbUserIdDescr.Text = result.Name;
                    (EditBindingSource.Current as UserPermissions).UserIdDescr = result.Name;
                }
                else
                {
                    EditBindingSource.Position = userPermissionsIndex;
                }
            }
        }
        private void tbCashAccountDescr_Validating(object sender, CancelEventArgs e)
        {
            Account result = AccountPickForm.PickAccount((sender as TextBox).Text.Trim(), null, FormOperation.Pick);
            if (result == null)
            {
                e.Cancel = true;
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
            }
            else
            {
                (EditBindingSource.Current as UserPermissions).CashAccountId = result.Id;
                tbCashAccountDescr.Text = result.Name;
                (EditBindingSource.Current as UserPermissions).CashAccountIdDescr = result.Name;
            }
        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                base.btOk_Click(sender, e);
            }
            catch (Exception)
            {
                ;
            }
            try
            {
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                if ((EditBindingSource.Current as UserPermissions).UserIdDescr.Trim() == "" || (EditBindingSource.Current as UserPermissions).CashAccountIdDescr.Trim() == "")
                {
                    _MessageBoxDialog.Show("خطأ بتعبئة الحقول", MessageBoxState.Error);
                    return;
                }
                if (rbIcons.Checked)
                {
                    (EditBindingSource.Current as UserPermissions).UserDesktopUI = UserDesktopUI.Icons;
                }
                else
                {
                    (EditBindingSource.Current as UserPermissions).UserDesktopUI = UserDesktopUI.Tabs;
                }
                (EditBindingSource.Current as UserPermissions).CanBuyBill = cbCanBuyBill.Checked;
                (EditBindingSource.Current as UserPermissions).CanSellBill = cbCanSellBill.Checked;
                (EditBindingSource.Current as UserPermissions).CanInsertEntry = cbCanInsertEntry.Checked;
                (EditBindingSource.Current as UserPermissions).CanDeleteBill = cbCanDeleteBill.Checked;
                (EditBindingSource.Current as UserPermissions).CanDeleteEntry = cbCanDeleteEntry.Checked;
                if ((EditBindingSource.Current as UserPermissions).Id == 0 || (EditBindingSource.Current as UserPermissions).Id == null)
                {
                    var newMaster = context.UserPermissions.Add(EditBindingSource.Current as UserPermissions);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل بيانات المستخدم", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    context.UserPermissions.Update(EditBindingSource.Current as UserPermissions);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل بيانات المستخدم", MessageBoxState.Done);
                    if (FormOperation == FormOperation.EditFromPicker)
                    {
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
            }
        }
        private void EditBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if ((EditBindingSource.Current as UserPermissions).UserDesktopUI == UserDesktopUI.Icons)
            {
                rbIcons.Checked = true;
            }
            else
            {
                rbTabs.Checked = true;
            }
        }

        private void rbTabs_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UserPermissionEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
