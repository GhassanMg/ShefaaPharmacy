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

namespace ShefaaPharmacy.Public
{
    public partial class MedicineMasterDetailEditForm : ShefaaPharmacy.GeneralUI.DialogForm
    {
        DataLayer.Tables.Article articale;
        public MedicineMasterDetailEditForm()
        {
            InitializeComponent();
        }
        protected override void btOK_Click(object sender, EventArgs e)
        {
            if (_MessageBoxDialog.Show("هل انت متاكد ؟ ", MessageBoxState.Answering) == MessageBoxAnswer.No)
                throw new Exception("");
            else
            {
                _MessageBoxDialog.Show("حفظ", MessageBoxState.Done);
            }
        }
        public MedicineMasterDetailEditForm(DataLayer.Tables.Article articale)
        {
            if (articale == null || articale.Id == 0)
            {
                NewRecord = true;
                articale = new DataLayer.Tables.Article();
                this.Text = "إضافة منتج جديد";
            }
            else
            {
                this.Text = "المنتج" + ".." + articale.Name;
            }
            this.articale = articale;
            InitializeComponent();
            bsMaster.DataSource = articale;
            bsDetail.DataSource = articale.Barcodes;
            PickGridView.AutoGenerateColumns = true;
            PickGridView.AllowUserToAddRows = true;
        }
        private void BindingEntityToControls()
        {
            tbName.DataBindings.Add("text", bsMaster, "Name");
            tbPublicPrice.DataBindings.Add("text", bsMaster, "PublicPrice");
            tbPharmacistPrice.DataBindings.Add("text", bsMaster, "PharmacistPrice");
            tbSideEffects.DataBindings.Add("text", bsMaster, "SideEffects");
            tbDosage.DataBindings.Add("text", bsMaster, "Dosage");
            tbActiveIngredients.DataBindings.Add("text", bsMaster, "ActiveIngredients");
            tbInteractions.DataBindings.Add("text", bsMaster, "PublicPrice");
            tbCompany.DataBindings.Add("text", bsMaster, "Company");
            tbPrecautions.DataBindings.Add("text", bsMaster, "Precautions");
            tbScientificName.DataBindings.Add("text", bsMaster, "ScientificName");
        }
        private void bsMaster_DataSourceChanged(object sender, EventArgs e)
        {
            BindingEntityToControls();
        }

        private void dgDetail_BindingContextChanged(object sender, EventArgs e)
        {
            //if (medicine.Barcodes == null)
            //{
            //    medicine.Barcodes = new List<Barcodes>();
            //}
            //bsDetail.DataSource = medicine.Barcodes;
            //PickGridView.Refresh();
        }

        private void PickGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var cell = PickGridView[e.ColumnIndex, e.RowIndex];
            string cellName = cell.OwningColumn.Name;
            if (cellName == "Barcode")
            {
                var recCount = (bsDetail.DataSource as List<Barcode>).Where(x => x.Code == e.FormattedValue.ToString()).Count();
                if (recCount > 1)
                {
                    e.Cancel = true;
                }
            }
            else if (cellName == "CompanyIdDesrc")
            {
                Company result = CompanyPickForm.PickCompany(e.FormattedValue.ToString().Trim(), null, FormOperation.Pick);
                //if (result != null)
                //{
                //    //((Barcode)bsDetail.Current).CompanyId = result.Id;
                //}
            }
        }

        private void PickGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (PickGridView.CurrentRow.DataBoundItem == null)
                return;
            string cellName = "Barcode";
            var recCount = (bsDetail.DataSource as List<Barcode>)
                .Where(x => x.Code == PickGridView.Rows[e.RowIndex].Cells[cellName].Value.ToString()).Count();
            if (recCount > 1)
            {
                _MessageBoxDialog.Show("رقم الباركود متكرر", MessageBoxState.Error);
                PickGridView.Rows[e.RowIndex].Cells[cellName].Value = "";
                DataGridViewCell cell = PickGridView["Barcode", e.RowIndex];
                PickGridView.CurrentCell = cell;
                PickGridView.BeginEdit(true);
                e.Cancel = true;
                return;
            }
            if (PickGridView.Rows[e.RowIndex].Cells["CompanyIdDesrc"].Value.ToString() == "")
            {
                DataGridViewCell cell = PickGridView["CompanyIdDesrc", e.RowIndex];
                PickGridView.CurrentCell = cell;
                PickGridView.BeginEdit(true);
                e.Cancel = true;
                return;
            }
        }

        private void bsDetail_AddingNew(object sender, AddingNewEventArgs e)
        {
            Barcode lastRec=null;
            if (((List<Barcode>)bsDetail.DataSource).Count > 0)
            {
                lastRec = ((List<Barcode>)bsDetail.DataSource).Last();
            }
            //if (lastRec != null && lastRec.CompanyId != 0)
            //{
            //    e.NewObject = new Barcodes() { CompanyId = lastRec.CompanyId };
            //}
        }

        private void PickGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                return;
            }
        }

        private void MedicineMasterDetailEditForm_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode==Keys.D6)
            //{
            //    _MessageBoxDialog.Show("Barcode");
            //}
        }
    }
}
