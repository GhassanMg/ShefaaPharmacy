using DataLayer;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Invoice;
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
    public partial class InputForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public ShefaaForms FormsType { get; set; }
        public string FormText { get; set; }
        public InputForm()
        {
            InitializeComponent();
        }
        public InputForm(ShefaaForms formsType, string formText)
        {
            InitializeComponent();
            this.FormsType = formsType;
            this.FormText = formText;
        }
        private void InputForm_Load(object sender, EventArgs e)
        {
            RenameLabelAndText();
        }
        public static void OpenInputNumber(ShefaaForms formsType, string formText)
        {
            InputForm inputForm = new InputForm(formsType, formText);
            inputForm.ShowDialog();
        }
        private void RenameLabelAndText()
        {
            switch (FormsType)
            {
                case ShefaaForms.Entry:
                case ShefaaForms.EditEntry:
                case ShefaaForms.DeleteEntry:
                    lbNumber.Text = "سند قيد رقم";
                    break;
                default:
                    lbNumber.Text = "فاتورة رقم";
                    break;
            }
            Text = this.FormText;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbNumber.Text))
            {
                switch (FormsType)
                {
                    case ShefaaForms.EditSellInvoice:
                        break;
                    case ShefaaForms.EditPurchaseInvoice:
                        break;
                    case ShefaaForms.ReturnPurchaseInvoice:
                    case ShefaaForms.ReturnSellInvoice:
                    case ShefaaForms.ReturnBill:
                        CheckBillNumber(Convert.ToInt32(tbNumber.Text));
                        break;
                    case ShefaaForms.EditEntry:
                        CheckEntryNumber(Convert.ToInt32(tbNumber.Text));
                        break;
                    case ShefaaForms.DeleteEntry:
                        CheckEntryNumberForDelete(Convert.ToInt32(tbNumber.Text));
                        break;
                    case ShefaaForms.DeleteBill:
                        CheckBillNumberForDelete(Convert.ToInt32(tbNumber.Text));
                        break;
                    default:
                        break;
                }
            }
        }
        private void CheckBillNumber(int id)
        {
            var result = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.Id == id).Include(x => x.BillDetails).FirstOrDefault();
            if (result != null)
            {
                if (result.IsReturned)
                {
                    _MessageBoxDialog.Show("هذه الفاتورة مرتجعة", MessageBoxState.Warning);
                }
                else
                {
                    if (result.InvoiceKind == InvoiceKind.Buy)
                    {
                        BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm(result, FormOperation.Return);
                        buyInvoiceEditForm.ShowDialog();
                        Close();
                    }
                    else
                    {
                        GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(result, result.InvoiceKind, FormOperation.Return);
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
        private void CheckBillNumberForDelete(int id)
        {
            var result = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.Id == id).Include(x => x.BillDetails).FirstOrDefault();
            if (result != null)
            {
                if (result.InvoiceKind == InvoiceKind.Sell || result.InvoiceKind == InvoiceKind.ReturnSell)
                {
                    GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(result, result.InvoiceKind, FormOperation.Delete);
                    generalInvoiceEditForm.ShowDialog();
                    Close();
                }
                else if (result.InvoiceKind == InvoiceKind.Buy || result.InvoiceKind == InvoiceKind.ReturnBuy)
                {
                    BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm(result, FormOperation.Delete);
                    buyInvoiceEditForm.ShowDialog();
                    Close();
                }
            }
            else
            {
                _MessageBoxDialog.Show("فاتورة غير موجودة", MessageBoxState.Error);
            }
        }
        private void CheckEntryNumber(int id)
        {
            var result = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.Where(x => x.Id == id).Include(x => x.EntryDetails).FirstOrDefault();
            if (result != null)
            {
                if (result.KindOperation == KindOperation.Buy)
                {
                    var bill = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.Id == result.RelatedDocument).Include(x => x.BillDetails).FirstOrDefault();
                    BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm(bill, FormOperation.Return);
                    buyInvoiceEditForm.ShowDialog();
                    Close();
                }
                else if (result.KindOperation == KindOperation.Sell)
                {
                    var bill = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.Id == result.RelatedDocument).Include(x => x.BillDetails).FirstOrDefault();
                    GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(bill, bill.InvoiceKind, FormOperation.Return);
                    generalInvoiceEditForm.ShowDialog();
                    Close();
                }
                else
                {
                    EntryEditForm entryEditForm = new EntryEditForm(result, result.KindOperation, FormOperation.EditFromPicker);
                    entryEditForm.ShowDialog();
                }
            }
            else
            {
                _MessageBoxDialog.Show("فاتورة غير موجودة", MessageBoxState.Error);
            }
        }
        private void CheckEntryNumberForDelete(int id)
        {
            var result = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.Where(x => x.Id == id).Include(x => x.EntryDetails).FirstOrDefault();
            if (result != null)
            {
                if (result.KindOperation == KindOperation.Buy)
                {
                    var bill = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.Id == result.RelatedDocument).Include(x => x.BillDetails).FirstOrDefault();
                    BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm(bill, FormOperation.Delete);
                    buyInvoiceEditForm.ShowDialog();
                    Close();
                }
                else if (result.KindOperation == KindOperation.Sell)
                {
                    var bill = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.Id == result.RelatedDocument).Include(x => x.BillDetails).FirstOrDefault();
                    GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(bill, bill.InvoiceKind, FormOperation.Delete);
                    generalInvoiceEditForm.ShowDialog();
                    Close();
                }
                else
                {
                    EntryEditForm entryEditForm = new EntryEditForm(result, result.KindOperation, FormOperation.Delete);
                    entryEditForm.ShowDialog();
                }
            }
            else
            {
                _MessageBoxDialog.Show("سند قيد أو فاتورة غير موجودة", MessageBoxState.Error);
            }
        }

        private void TbNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnOk_Click(sender, e);
            }
        }
    }
}
