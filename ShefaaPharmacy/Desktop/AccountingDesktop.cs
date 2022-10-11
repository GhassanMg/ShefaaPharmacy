using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Tables;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.Articale;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Invoice;
using ShefaaPharmacy.Public;
using System;
using System.Windows.Forms;

namespace ShefaaPharmacy.Desktop
{
    public partial class AccountingDesktop : UserControl
    {
        public AccountingDesktop()
        {
            InitializeComponent();
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED

        //        if (this.IsXpOr2003 == true)
        //            cp.ExStyle |= 0x00080000;  // Turn on WS_EX_LAYERED

        //        return cp;
        //    }
        //}
        ////Check os version
        //private Boolean IsXpOr2003
        //{
        //    get
        //    {
        //        OperatingSystem os = Environment.OSVersion;
        //        Version vs = os.Version;

        //        if (os.Platform == PlatformID.Win32NT)
        //            if ((vs.Major == 5) && (vs.Minor != 0))
        //                return true;
        //            else
        //                return false;
        //        else
        //            return false;
        //    }
        //}
        public void VisibleDesktop(bool visible)
        {
            //pbBillPick.Visible = visible;
            //pbCashAccountReport.Visible = visible;
            //pbEntry.Visible = visible;
            //pbEntryForAccount.Visible = visible;
            //pbInvoiceBuy.Visible = visible;
            //pbInvoiceSell.Visible = visible;
            //pictureBox1.Visible = visible;
            //pictureBox2.Visible = visible;
        }

        private void pbInvoiceSell_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry() && ((UserLoggedIn.User.UserPermissions.CanSellBill) || ((int)UserLoggedIn.User.Position <= (int)Position.manager)))
                {
                    GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(new BillMaster(), InvoiceKind.Sell, FormOperation.New);
                    generalInvoiceEditForm.Show();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void pbInvoiceBuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry() && ((UserLoggedIn.User.UserPermissions.CanBuyBill) || ((int)UserLoggedIn.User.Position <= (int)Position.manager)))
                {
                    BuyInvoiceEditForm generalInvoiceEditForm = new BuyInvoiceEditForm(new BillMaster(), FormOperation.New);
                    generalInvoiceEditForm.Show();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لفتح الواجهة", MessageBoxState.Error);

                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void pbDeleteBill_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Auth.IsManager() && ((UserLoggedIn.User.UserPermissions.CanInsertEntry) || ((int)UserLoggedIn.User.Position <= (int)Position.manager)))
            //    {
            //        EntryEditForm entryEditForm = new EntryEditForm(new EntryMaster(), KindOperation.Entry, FormOperation.New);
            //        entryEditForm.ShowDialog();
            //    }
            //    else
            //    {
            //        _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            //}
            ////if (Auth.IsDataEntry() && ((UserLoggedIn.User.UserPermissions.CanDeleteBill) || ((int)UserLoggedIn.User.Position <= (int)Position.manager)))
            ////{
            ////    InvoiceReturningForm invoiceReturningForm = new InvoiceReturningForm("حذف فاتورة", FormOperation.Delete);
            ////    invoiceReturningForm.ShowDialog();
            ////}
            ////else
            ////{
            ////    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            ////}
            if (Auth.IsManager())
            {
                FirstDurationEditForm frm = new FirstDurationEditForm();
                frm.ShowDialog();
                //BalanceFirstDurationEditForm balanceFirstDurationEditForm = new BalanceFirstDurationEditForm();
                //balanceFirstDurationEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }

        private void pbCashAccountReport_Click(object sender, EventArgs e)
        {
            //AccountCashMovementReportForm accountCashMovementReportForm = new AccountCashMovementReportForm();
            //accountCashMovementReportForm.ShowDialog();
            try
            {
                if (Auth.IsReportReader())
                {
                    AccountFainancialReportForm accountFainancialReportForm = new AccountFainancialReportForm();
                    accountFainancialReportForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("لا يوجد صلاحية للوصول لهذه الواجهة", MessageBoxState.Error);
                }

            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry())
                {
                    ArticaleEditForm articaleEditForm = new ArticaleEditForm(new DataLayer.Tables.Article());
                    articaleEditForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry())
                {
                    //ArticlePriceTagEditForm articlePriceTagEditForm = new ArticlePriceTagEditForm(new DataLayer.Tables.Article());
                    //articlePriceTagEditForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void pbPaymentAccount_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                AccountPaymentEditForm accountPaymentEditForm = new AccountPaymentEditForm(PayingCashState.InComing,"NewPayment");
                accountPaymentEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }

        private void pbDefCompany_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    CompanyEditForm companyEditForm = new CompanyEditForm(new Company());
                    companyEditForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void pbDefAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    AccountCardEditForm accountCardEditForm = new AccountCardEditForm(new Account(), FormOperation.New);
                    accountCardEditForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void pbArticleDetailReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    ArticleDetailReportForm articleDetailReportForm = new ArticleDetailReportForm();
                    articleDetailReportForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void pbReturnBill_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                InvoiceReturningForm invoiceReturningForm = new InvoiceReturningForm("إرجاع فاتورة", FormOperation.Return);
                invoiceReturningForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
            //try
            //{
            //    if (Auth.IsManager())
            //    {
            //        BranchEditForm storeEditForm = new BranchEditForm(new Branch());
            //        storeEditForm.ShowDialog();
            //    }
            //    else
            //    {
            //        _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            //}
        }

        private void pbEditBill_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                InvoiceReturningForm invoiceReturningForm = new InvoiceReturningForm("تعديل فاتورة", FormOperation.EditFromPicker);
                invoiceReturningForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
            //try
            //{
            //    if (Auth.IsManager())
            //    {
            //        ArticleGeneralEditForm articaleSubCategory = new ArticleGeneralEditForm(new Article());
            //        articaleSubCategory.ShowDialog();
            //    }
            //    else
            //    {
            //        _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            //}
        }

        private void pbBillPick_Click_1(object sender, EventArgs e)
        {
            InvoicDayPickForm invoicDayPickForm = new InvoicDayPickForm(null);
            invoicDayPickForm.ShowDialog();
        }

        private void AccountingDesktop_Load(object sender, EventArgs e)
        {
            //ScrollBar vScrollBar1 = new VScrollBar();
            //vScrollBar1.Dock = DockStyle.Right;
            //vScrollBar1.Scroll += (sender2, e2) => { panel4.VerticalScroll.Value = vScrollBar1.Value; };
            //panel4.Controls.Add(vScrollBar1);
        }
    }
}
