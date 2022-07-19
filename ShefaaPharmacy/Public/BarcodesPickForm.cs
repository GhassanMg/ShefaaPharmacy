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

namespace ShefaaPharmacy.Public
{
    public partial class BarcodesPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        List<Barcode> barcodes;
        Barcode barcode;
        public BarcodesPickForm()
        {
            InitializeComponent();
        }
        public BarcodesPickForm(List<Barcode> barcodes)
        {
            this.barcodes = barcodes;
            InitializeComponent();
        }
        public BarcodesPickForm(Barcode barcode)
        {
            this.barcode = barcode;
            InitializeComponent();
        }
        public static Barcode PickBarcodes(List<Barcode> barcodes, FormOperation formOperation = FormOperation.Show)
        {
            BarcodesPickForm fmPick = new BarcodesPickForm(barcodes);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض الباركودات";
                fmPick.ShowDialog();
                fmPick.PickGridView.AllowUserToAddRows = true;
                return (Barcode)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static List<Barcode> PickCreateBarcodes(List<Barcode> barcodes, FormOperation formOperation = FormOperation.Show)
        {
            BarcodesPickForm fmPick = new BarcodesPickForm(barcodes);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إدخال الباركودات";
                fmPick.PickGridView.AllowUserToAddRows = true;
                fmPick.ShowDialog();
                return (List<Barcode>)fmPick.PickBindingSource.DataSource;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        protected override void Rebinding()
        {
            if (barcodes == null)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Barcodes.ToList();
            else
                PickBindingSource.DataSource = barcodes;
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (Barcode)PickBindingSource.Current;
        }
        protected override void AdjustmentGridColumns()
        {
            base.AdjustmentGridColumns();
            PickGridView.Refresh();
        }
        protected override void PickGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var cell = PickGridView[e.ColumnIndex, e.RowIndex];
            string cellName = cell.OwningColumn.Name;
            if (cellName == "Barcode")
            {
                var recCount = (PickBindingSource.DataSource as List<Barcode>).Where(x => x.Code == e.FormattedValue.ToString()).Count();
                if (recCount > 1)
                {
                    e.Cancel = true;
                }
            }
            //else if (cellName == "CompanyIdDesrc")
            //{
            //    Company result = CompanyPickForm.PickCompany(e.FormattedValue.ToString().Trim(), null, true);
            //    if (result != null)
            //    {
            //        ((Barcodes)PickBindingSource.Current).CompanyId = result.Id;
            //    }
            //}
        }
        protected override void PickGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (PickGridView.CurrentRow.DataBoundItem == null)
                return;
            string cellName = "Barcode";
            var recCount = (PickBindingSource.DataSource as List<Barcode>)
                .Where(x => x.Code == PickGridView.Rows[e.RowIndex].Cells[cellName].Value.ToString()).Count();
            if (recCount > 1)
            {
                _MessageBoxDialog.Show("رقم الباركود متكرر", MessageBoxState.Warning);
                PickGridView.Rows[e.RowIndex].Cells[cellName].Value = "";
                DataGridViewCell cell = PickGridView["Barcode", e.RowIndex];
                PickGridView.CurrentCell = cell;
                PickGridView.BeginEdit(true);
                e.Cancel = true;
            }
        }
    }
}
