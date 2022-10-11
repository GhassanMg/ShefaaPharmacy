using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Definition
{
    public partial class BranchPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        Branch branch;
        public BranchPickForm()
        {
            InitializeComponent();
        }
        public BranchPickForm(Branch branch)
        {
            this.branch = branch;
            InitializeComponent();
        }
        public static Branch PickBranch(Branch branch, FormOperation formOperation = FormOperation.Show)
        {
            BranchPickForm fmPick = new BranchPickForm(branch);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض الفروع";
                fmPick.ShowDialog();
                return (Branch)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static Branch PickBranch(string textFilter, Branch branch, FormOperation formOperation = FormOperation.Show)
        {
            Branch tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().Branches.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            BranchPickForm fmPick = new BranchPickForm(branch);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر فرع";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (Branch)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        protected override void AdjustmentGridColumns()
        {
            base.AdjustmentGridColumns();
            PickGridView.Refresh();
        }
        protected override void Rebinding()
        {
            if (branch == null || branch.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Branches.ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Branches.Where(x => x.Id == branch.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (Branch)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            shefaaPharmacyDbContext.Branches.Remove(CurrentEntity as Branch);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            BranchEditForm.CreateBranch(CurrentEntity as Branch, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (FormOperation != FormOperation.Pick)
            {
                BranchEditForm edForm = new BranchEditForm(CurrentEntity as Branch, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            if (FormOperation != FormOperation.Pick)
            {
                SetCurrentEntity();
                BranchEditForm edForm = new BranchEditForm(CurrentEntity as Branch, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }

        private void BranchPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Pick)
            {
                this.Text = "إختر فرع";
            }
            else
            {
                this.Text = "إستعراض الفروع";
            }
        }
    }
}
