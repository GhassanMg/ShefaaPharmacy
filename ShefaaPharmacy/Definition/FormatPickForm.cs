using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
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
    public partial class FormatPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        Format format;
        public FormatPickForm()
        {
            InitializeComponent();
        }
        public FormatPickForm(Format format)
        {
            this.format = format;
            InitializeComponent();
        }
        public static Format PickAccount(Format format, FormOperation formOperation = FormOperation.Show)
        {
            FormatPickForm fmPick = new FormatPickForm(format);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض الأشكال";
                fmPick.ShowDialog();
                return (Format)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static Format PickFormat(string textFilter, Format format, FormOperation formOperation = FormOperation.Show)
        {
            Format tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().Formats.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            FormatPickForm fmPick = new FormatPickForm(format);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر شكل";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (Format)fmPick.CurrentEntity;
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
            if (format == null || format.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Formats.ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Formats.Where(x => x.Id == format.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (Format)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            shefaaPharmacyDbContext.Formats.Remove(CurrentEntity as Format);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            FormatEditForm.CreateFormat(CurrentEntity as Format, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (FormOperation != FormOperation.Pick)
            {
                FormatEditForm edForm = new FormatEditForm(CurrentEntity as Format, FormOperation.EditFromPicker);
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
                FormatEditForm edForm = new FormatEditForm(CurrentEntity as Format, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void tsFilterdText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tsFilterdText.Text))
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Formats.ToList();
            }
            else
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Formats.Where(x => x.Name.Contains(tsFilterdText.Text)).ToList();
            }

            base.Rebinding();
        }
        private void FormatPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Pick)
            {
                this.Text = "إختر شكل";
            }
            else
            {
                this.Text = "إستعراض الأشكال";
            }
        }
    }
}
