using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace ShefaaPharmacy.Public
{
    public partial class CompanyPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        Company Company;
        public CompanyPickForm()
        {
            InitializeComponent();
        }
        public CompanyPickForm(Company company)
        {
            this.Company = company;
            this.Text = "إستعراض الشركات الدوائية";
            InitializeComponent();
        }
        public static Company PickAccount(Company company, FormOperation formOperation = FormOperation.Show)
        {
            CompanyPickForm fmPick = new CompanyPickForm(company);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض الشركات الدوائية";
                fmPick.ShowDialog();
                return (Company)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static Company PickCompany(string textFilter, Company company, FormOperation formOperation = FormOperation.Show)
        {
            Company tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().Companys.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            CompanyPickForm fmPick = new CompanyPickForm(company);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر شركة دوائية";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (Company)fmPick.CurrentEntity;
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
            if (Company == null || Company.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Companys.ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Companys.Where(x => x.Id == Company.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (Company)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            shefaaPharmacyDbContext.Companys.Remove(CurrentEntity as Company);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            CompanyEditForm.CreateCompany(CurrentEntity as Company, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (FormOperation != FormOperation.Pick)
            {
                CompanyEditForm edForm = new CompanyEditForm(CurrentEntity as Company, FormOperation.EditFromPicker);
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
                CompanyEditForm edForm = new CompanyEditForm(CurrentEntity as Company, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void tsFilterdText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tsFilterdText.Text))
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Companys.ToList();
            }
            else
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Companys.Where(x => x.Name.Contains(tsFilterdText.Text)).ToList();
            }

            base.Rebinding();
        }
        private void CompanyPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Pick)
            {
                this.Text = "إختر شركة دوائية";
            }
            else
            {
                this.Text = "إستعراض الشركات الدوائية";
            }
        }
    }
}
