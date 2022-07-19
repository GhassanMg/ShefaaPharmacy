using DataLayer.Enums;
using DataLayer;
using DataLayer.Enums;
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

namespace ShefaaPharmacy.Definition
{
    public partial class UserEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        User user;
        public UserEditForm()
        {
            InitializeComponent();
        }
        public UserEditForm(User entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            user = entity;
            FormOperation = formOperation;
            if (entity.Id == 0)
            {
                this.Text = "إضافة مستخدم";
            }
            else
            {
                this.Text = "تعديل مستخدم ";
            }
            EditBindingSource.DataSource = user;
        }
        public static User CreateUser(User User, FormOperation formOperation = FormOperation.New)
        {
            UserEditForm fmEdit = new UserEditForm(User, formOperation);
            try
            {
                fmEdit.Text = "إضافة مستخدم";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return fmEdit.user;
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
            tbPassword.DataBindings.Add("text", EditBindingSource, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
            cbFreezed.DataBindings.Add("checked", EditBindingSource, "Freez", false, DataSourceUpdateMode.OnPropertyChanged);
            HelperUI.ConfigrationComboBox<Store>(cbStore, ShefaaPharmacyDbContext.GetCurrentContext().Stores.ToList()
                , user.Store, "Name", "Id", FormOperation);
            HelperUI.ConfigrationComboBox<Branch>(cbBranch, ShefaaPharmacyDbContext.GetCurrentContext().Branches.ToList()
                , user.Branch, "Name", "Id", FormOperation);
            cbPosition.DataSource = Enum.GetValues(typeof(Position));
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                cbPosition.SelectedIndex = 0;
            }
            else
            {
                cbPosition.SelectedItem = (int)user.Position;
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
                throw;
            }
            try
            {
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                {
                    User newUser = user;
                    newUser.Position =(Position)cbPosition.SelectedItem;
                    newUser.BranchId = Convert.ToInt32(cbBranch.SelectedValue);
                    newUser.StoreId = Convert.ToInt32(cbStore.SelectedValue);
                    newUser.UserPermissions =new UserPermissions
                    {
                        CanBuyBill = true,
                        CanDeleteBill = true,
                        CanDeleteEntry = true,
                        CanInsertEntry = true,
                        CanSellBill = true,
                        CustomerAccountId = 11,
                        CashAccountId = 12,
                        SellAccountId = 13,
                        BuyAccountId = 14,
                        UserDesktopUI = UserDesktopUI.Icons
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();

                    _MessageBoxDialog.Show("تم إضافة مستخدم جديد", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    context.Users.Update(user);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات المستخدم", MessageBoxState.Done);
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
            user = new User();
            e.NewObject = user;
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                this.Text = "إضافة مستخدم";
            }
            else
            {
                this.Text = "تعديل مستخدم";
            }
        }
    }
}
