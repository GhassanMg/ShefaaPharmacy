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
using DataLayer.ViewModels;
using DataLayer.Helper;
using DataLayer.Services;
using System.Threading;

namespace ShefaaPharmacy.Invoice
{
    public partial class InvoicDayPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        BillMaster billMaster;
        public InvoicDayPickForm()
        {
            InitializeComponent();
        }
        public InvoicDayPickForm(BillMaster billMaster)
        {
            InitializeComponent();
            this.billMaster = billMaster;
        }
        public static BillMaster PickBill(BillMaster billMaster, FormOperation formOperation = FormOperation.Show)
        {
            InvoicDayPickForm fmPick = new InvoicDayPickForm(billMaster);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض فواتير اليوم";
                fmPick.ShowDialog();
                return (BillMaster)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static BillMaster PickBill(int textFilter, BillMaster billMaster, FormOperation formOperation = FormOperation.Show)
        {
            BillMaster tmp = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.Id == textFilter).FirstOrDefault();
            if (tmp != null)
            {
                return tmp;
            }
            InvoicDayPickForm fmPick = new InvoicDayPickForm(billMaster);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر الفاتورة";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return billMaster;
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
            var firstTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1);
            var LastTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            dtCreationDate.Value = DateTime.Now;
            if (billMaster == null || billMaster.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.CreationDate >= firstTime && x.CreationDate <= LastTime).ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.Id == billMaster.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (BillMaster)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            return;
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(new BillMaster() { InvoiceKind = InvoiceKind.Sell }, InvoiceKind.Sell, FormOperation.NewFromPicker);
            generalInvoiceEditForm.ShowDialog();
            Rebinding();
        }
        protected override void tsRefresh_Click(object sender, EventArgs e)
        {
            base.tsRefresh_Click(sender, e);
            dtCreationDate.Value = DateTime.Now;
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            if ((PickBindingSource.Current as BillMaster).InvoiceKind == InvoiceKind.ReturnSell || (PickBindingSource.Current as BillMaster).InvoiceKind == InvoiceKind.ReturnBuy)
            {
                _MessageBoxDialog.Show("لا يمكن التعديل على فاتورة مرتجعة", MessageBoxState.Error);
                return;
            }
            else if ((PickBindingSource.Current as BillMaster).InvoiceKind == InvoiceKind.Sell)
            {
                GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm((PickBindingSource.Current as BillMaster), (PickBindingSource.Current as BillMaster).InvoiceKind, FormOperation.EditFromPicker);
                generalInvoiceEditForm.ShowDialog();
            }
            else if ((PickBindingSource.Current as BillMaster).InvoiceKind == InvoiceKind.Buy)
            {
                BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm((PickBindingSource.Current as BillMaster), FormOperation.EditFromPicker);
                buyInvoiceEditForm.ShowDialog();
            }
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (FormOperation != FormOperation.Pick)
            {
                if ((PickBindingSource.Current as BillMaster).InvoiceKind == InvoiceKind.ReturnSell)
                {
                    _MessageBoxDialog.Show("لا يمكن التعديل على فاتورة مرتجعة", MessageBoxState.Error);
                    return;
                }
                if ((PickBindingSource.Current as BillMaster).InvoiceKind == InvoiceKind.ReturnSell || (PickBindingSource.Current as BillMaster).InvoiceKind == InvoiceKind.ReturnBuy)
                {
                    _MessageBoxDialog.Show("لا يمكن التعديل على فاتورة مرتجعة", MessageBoxState.Error);
                    return;
                }
                else if ((PickBindingSource.Current as BillMaster).InvoiceKind == InvoiceKind.Sell)
                {
                    GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm((PickBindingSource.Current as BillMaster), (PickBindingSource.Current as BillMaster).InvoiceKind, FormOperation.EditFromPicker);
                    generalInvoiceEditForm.ShowDialog();
                }
                else if ((PickBindingSource.Current as BillMaster).InvoiceKind == InvoiceKind.Buy)
                {
                    BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm((PickBindingSource.Current as BillMaster), FormOperation.EditFromPicker);
                    //buyInvoiceEditForm.MyValidate();
                    //buyInvoiceEditForm.MySecondValidate();
                    buyInvoiceEditForm.ShowDialog();
                }
                Rebinding();
            }
        }

        private void InvoicDayPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Pick)
            {
                Text = "إختر فاتورة";
            }
            else
            {
                Text = "إستعراض فواتير اليوم";
            }
            //tsddlSearch.Visible = true;
            //tsddlSearch.ComboBox.DataSource = MonthViewModel.GetAllMonth();
            //tsddlSearch.ComboBox.ValueMember = "Id";
            //tsddlSearch.ComboBox.DisplayMember = "Name";
            //tsddlSearch.ComboBox.SelectedValue = DateTime.Now.Month;

            //tsddlSearch2.Visible = true;
            //tsddlSearch2.ComboBox.DataSource = DayViewModel.GetAllDayInMont(Convert.ToInt32(YearService.GetYear().Name), 1);
            //tsddlSearch2.ComboBox.ValueMember = "Id";
            //tsddlSearch2.ComboBox.DisplayMember = "Name";
            //tsddlSearch2.ComboBox.SelectedValue = DateTime.Now.Day;

            //tsddlSearch.SelectedIndexChanged += tsddlSearch_SelectedIndexChanged;
            //tsddlSearch2.SelectedIndexChanged += tsddlSearch2_SelectedIndexChanged;


        }
        protected override void tsddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Month
            var firstTime = new DateTime(2021, Convert.ToInt32(tsddlSearch.ComboBox.SelectedValue), Convert.ToInt32(tsddlSearch2.ComboBox.SelectedValue), 0, 0, 1);
            var LastTime = new DateTime(2021, Convert.ToInt32(tsddlSearch.ComboBox.SelectedValue), Convert.ToInt32(tsddlSearch2.ComboBox.SelectedValue), 23, 59, 59);

            PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.CreationDate >= firstTime && x.CreationDate <= LastTime).ToList();
            base.Rebinding();
        }
        protected override void tsddlSearch2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Day
            var firstTime = new DateTime(2021, Convert.ToInt32(tsddlSearch.ComboBox.SelectedValue), Convert.ToInt32(tsddlSearch2.ComboBox.SelectedValue), 0, 0, 1);
            var LastTime = new DateTime(2021, Convert.ToInt32(tsddlSearch.ComboBox.SelectedValue), Convert.ToInt32(tsddlSearch2.ComboBox.SelectedValue), 23, 59, 59);

            PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.CreationDate >= firstTime && x.CreationDate <= LastTime).ToList();
            base.Rebinding();
        }

        private void dtCreationDate_ValueChanged(object sender, EventArgs e)
        {
            var firstTime = new DateTime(Convert.ToInt32(dtCreationDate.Value.Year), Convert.ToInt32(dtCreationDate.Value.Month), Convert.ToInt32(dtCreationDate.Value.Day), 0, 0, 0);
            var LastTime = new DateTime(Convert.ToInt32(dtCreationDate.Value.Year), Convert.ToInt32(dtCreationDate.Value.Month), Convert.ToInt32(dtCreationDate.Value.Day), 23, 59, 59);

            PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.CreationDate >= firstTime && x.CreationDate <= LastTime).ToList();
            base.Rebinding();
        }
    }
}
