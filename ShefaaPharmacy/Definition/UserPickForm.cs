using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.Helper;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Definition
{
    public partial class UserPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        User user;
        public UserPickForm()
        {
            InitializeComponent();
        }
        public UserPickForm(User user)
        {
            this.user = user;
            this.Text = "إستعراض المستخدمين";
            InitializeComponent();
        }
        public static User PickUser(User user, FormOperation formOperation = FormOperation.Show)
        {
            UserPickForm fmPick = new UserPickForm(user);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض المستخدمين";
                fmPick.ShowDialog();
                return (User)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static User PickUser(string textFilter, User user, FormOperation formOperation = FormOperation.Show)
        {
            User tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().Users.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            UserPickForm fmPick = new UserPickForm(user);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر مستخدم";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (User)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        protected override void AdjustmentGridColumns()
        {
            base.AdjustmentGridColumns();
            HiddenColumn = new string[] { "Id", "BranchId", "StoreId", "UserPermissions", "Password" };
            PickGridView.Refresh();
        }
        protected override void Rebinding()
        {
            if (user == null || user.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Users.ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Users.Where(x => x.Id == user.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (User)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            shefaaPharmacyDbContext.Users.Remove(CurrentEntity as User);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            UserEditForm.CreateUser(CurrentEntity as User, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (FormOperation != FormOperation.Pick)
            {
                if (Auth.IsAdmin())
                {
                    UserEditForm edForm = new UserEditForm(CurrentEntity as User, FormOperation.EditFromPicker);
                    edForm.ShowDialog();
                    edForm.Dispose();
                    //PickBindingSource.ResetBindings(false);
                    Rebinding();
                }
            }
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            if (FormOperation != FormOperation.Pick)
            {
                if (Auth.IsAdmin())
                {
                    SetCurrentEntity();
                    UserEditForm edForm = new UserEditForm(CurrentEntity as User, FormOperation.EditFromPicker);
                    edForm.ShowDialog();
                    edForm.Dispose();
                    //PickBindingSource.ResetBindings(false);
                    Rebinding();
                }
            }
        }
        protected override void tsFilterdText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tsFilterdText.Text))
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Users.ToList();
            }
            else
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Users.Where(x => x.Name.Contains(tsFilterdText.Text)).ToList();
            }

            base.Rebinding();
        }
        private void UserPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Pick)
            {
                this.Text = "إختر مستخدم";
            }
            else
            {
                this.Text = "إستعراض المستخدمين";
            }
        }
    }
}
