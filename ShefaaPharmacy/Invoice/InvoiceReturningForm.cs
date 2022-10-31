using DataLayer;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Invoice
{
    public partial class InvoiceReturningForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public InvoiceReturningForm()
        {
            InitializeComponent();
        }
        public InvoiceReturningForm(string formName, FormOperation formOperation)
        {
            InitializeComponent();
            FormName = formName;
            FormOperation = formOperation;
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (tbBillMasterId.Text == "")
            {
                _MessageBoxDialog.Show("يرجى اختيار فاتورة", MessageBoxState.Warning);
                return;
            }
            var result = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.Id == Convert.ToInt32(tbBillMasterId.Text)).Include(x => x.BillDetails).FirstOrDefault();
            if (result != null)
            {
                if (result.IsReturned)
                {
                    _MessageBoxDialog.Show("هذه الفاتورة مرتجعة", MessageBoxState.Warning);
                }
                else if ((result.InvoiceKind == InvoiceKind.ReturnBuy || result.InvoiceKind == InvoiceKind.ReturnSell) && FormOperation == FormOperation.EditFromPicker)
                {
                    _MessageBoxDialog.Show("لا يمكن تعديل فاتورة إرجاع", MessageBoxState.Warning);
                }
                else
                {
                    if (result.InvoiceKind == InvoiceKind.Buy)
                    {
                        BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm(result, FormOperation);
                        buyInvoiceEditForm.ShowDialog();
                        Close();
                    }
                    else
                    {
                        GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(result, result.InvoiceKind, FormOperation);
                        generalInvoiceEditForm.ShowDialog();
                        Close();
                    }
                }
            }
            else
            {
                _MessageBoxDialog.Show("فاتورة غير موجودة", MessageBoxState.Error);
            }
        }
        private void pbNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbBillMasterId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReturn_Click(sender, e);
            }
        }
        private void InvoiceReturningForm_Load(object sender, EventArgs e)
        {
            this.Text = FormName;
        }
        private void LbBillNumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Auth.IsReportReader())
            {
                var bill = InvoicDayPickForm.PickBill(null, FormOperation.Pick);
                if (bill != null)
                {
                    tbBillMasterId.Text = bill.Id.ToString();
                    btnReturn_Click(sender, e);
                }
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
    }
}
