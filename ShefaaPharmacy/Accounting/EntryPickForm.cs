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

namespace ShefaaPharmacy.Accounting
{
    public partial class EntryPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        EntryMaster entry;
        public EntryPickForm()
        {
            InitializeComponent();
            PickBindingNavigator.AddNewItem.Enabled = false;

        }
        public EntryPickForm(EntryMaster entry)
        {
            this.entry = entry;
            InitializeComponent();
            PickBindingNavigator.AddNewItem.Enabled = false;
        }
        public static EntryMaster PickEntry(EntryMaster entry, FormOperation formOperation = FormOperation.Show)
        {
            EntryPickForm fmPick = new EntryPickForm(entry);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض سندات القيد";
                fmPick.ShowDialog();
                
                return entry;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static EntryMaster PickEntry(int textFilter, EntryMaster entry, FormOperation formOperation = FormOperation.Show)
        {
            EntryMaster tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.Where(x => x.Id == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            EntryPickForm fmPick = new EntryPickForm(entry);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر سند القيد";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return entry;
            }
            finally
            {

                fmPick.Dispose();

            }
        }
        protected override void AdjustmentGridColumns()
        {
            base.AdjustmentGridColumns();
            try
            {
                HiddenColumn = new string[] { "Id" };
            }
            catch (Exception)
            {
                ;
            }

            PickGridView.Refresh();
        }
        protected override void Rebinding()
        {
            //if (entry == null || entry.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.ToList();
            //else
                //PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.Where(x => x.KindOperation == KindOperation.GoodFirstTime).ToList();

            HiddenColumn = new string[] { "Balance" };
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = entry;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            //base.DeleteCurrentItem(shefaaPharmacyDbContext);
            //if (Auth.IsManager())
            //{
            //    if (_MessageBoxDialog.Show("هل أنت متأكد من حذف هذا السند", "انتبه", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        shefaaPharmacyDbContext.EntryDetails.RemoveRange(shefaaPharmacyDbContext.EntryDetails.Where(x=>x.EntryMasterId==entry));
            //    } 
            //}

        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //base.bindingNavigatorAddNewItem_Click(sender, e);
            //EntryEditForm.CreateEntry(new EntryMaster(), FormOperation.NewFromPicker);
            //Rebinding();
        }

        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            EntryEditForm entryEditForm = new EntryEditForm((PickBindingSource.Current as EntryMaster), (PickBindingSource.Current as EntryMaster).KindOperation, FormOperation.EditFromPicker);
            entryEditForm.ShowDialog();
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            SetCurrentEntity();
            if (FormOperation != FormOperation.Pick)
            {
                if (PickBindingSource.Current == null)
                    return;
                EntryEditForm entryEditForm = new EntryEditForm((PickBindingSource.Current as EntryMaster), (PickBindingSource.Current as EntryMaster).KindOperation, FormOperation.EditFromPicker);
                entryEditForm.ShowDialog();
                Rebinding();
            }
            else
            {
                Close();
            }
        }
    }
}
