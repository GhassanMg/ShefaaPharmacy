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
    public partial class YearPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        Year year;
        public YearPickForm()
        {
            InitializeComponent();
        }
        public YearPickForm(Year year)
        {
            this.year = year;
            this.Text = "إستعراض السنوات المالية";
            InitializeComponent();
        }
        public static Year PickYear(Year year, FormOperation formOperation = FormOperation.Show)
        {
            YearPickForm fmPick = new YearPickForm(year);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض السنوات المالية";
                fmPick.ShowDialog();
                return (Year)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static Year PickYear(string textFilter, Year year, FormOperation formOperation = FormOperation.Show)
        {
            Year tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().Years.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            YearPickForm fmPick = new YearPickForm(year);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر سنة مالية";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (Year)fmPick.CurrentEntity;
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
            if (year == null || year.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Years.ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Years.Where(x => x.Id == year.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (Year)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            shefaaPharmacyDbContext.Years.Remove(CurrentEntity as Year);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            YearEditForm.CreateYear(CurrentEntity as Year, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (FormOperation != FormOperation.Pick)
            {
                YearEditForm edForm = new YearEditForm(CurrentEntity as Year, FormOperation.EditFromPicker);
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
                YearEditForm edForm = new YearEditForm(CurrentEntity as Year, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }

        private void YearPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Pick)
            {
                this.Text = "إختر سنة مالية";
            }
            else
            {
                this.Text = "إستعراض السنوات المالية";
            }
        }
    }
}
