using DataLayer;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.Articale;
using ShefaaPharmacy.Articles;
using ShefaaPharmacy.CustomeControls;
using ShefaaPharmacy.Definition;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Invoice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ShefaaPharmacy.GeneralUI
{
    public partial class GeneralInvoiceEditForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        BillMaster billMaster;
        InvoiceKind invoiceKind;
        BillMaster lastOp, prevLastOp, prevPrevLastOp;
        bool AbortAddNewRow = false;
        bool IsInMinus = false;
        double RemainingAmoungIfBigger = 0;
        private void GeneralInvoiceEditForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }
        private void ChangeImageButton()
        {
            if (FormOperation == FormOperation.New || FormOperation == FormOperation.NewFromPicker)
            {
                pbOk.Image = Properties.Resources.SaveButton;
            }
            if (FormOperation == FormOperation.Return)
            {
                pbOk.Image = Properties.Resources.ReturnButton;
            }
            else if (FormOperation == FormOperation.Delete)
            {
                pbOk.Image = Properties.Resources.DeleteButton;
                dgDetail.AllowUserToAddRows = false;
            }
            else if (FormOperation == FormOperation.Edit || FormOperation == FormOperation.EditFromPicker)
            {
                pbOk.Image = Properties.Resources.EditButton;
            }

            dgDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        //SellFormTabs sellFormTabs;
        public GeneralInvoiceEditForm()
        {
            InitializeComponent();

            //sellFormTabs = new SellFormTabs();
            //FillPanelMaster(sellFormTabs);
            //sellFormTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            //sellFormTabs.BringToFront();
            //sellFormTabs.LoadTabs();
            //sellFormTabs.Show();

            //sellFormTabs.assinged();
        }
        private void InitEntity_onUpdateForm()
        {
            EditBindingSource.ResetCurrentItem();
        }
        private void LastThreeOperation()
        {
            if (!(FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New))
            {
                pLastOp.Visible = false;
                pPrevLast.Visible = false;
                pPrevPrevLast.Visible = false;
                lbReturnBill.Visible = false;
                lbDeleteBill.Visible = false;
            }
            else
            {
                pLastOp.Visible = false;
                pPrevLast.Visible = false;
                pPrevPrevLast.Visible = false;
                var xx = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Where(x => x.InvoiceKind == invoiceKind).OrderByDescending(x => x.CreationDate).Take(3).Include("BillDetails").ToList();
                if (xx.Count > 0)
                {
                    for (int i = 0; i < xx.Count; i++)
                    {
                        if (i == 0)
                        {
                            pLastOp.Visible = true;
                            lbLastOp.Text = "أخر فاتورة رقم" + "\t" + xx[i].Id;
                            lastOp = xx[i];
                        }
                        else if (i == 1)
                        {
                            pPrevLast.Visible = true;
                            lbPrevLast.Text = "فاتورة رقم" + "\t" + xx[i].Id;
                            prevLastOp = xx[i];
                        }
                        else if (i == 2)
                        {
                            pPrevPrevLast.Visible = true;
                            lbPrevPrevLast.Text = "فاتورة رقم" + "\t" + xx[i].Id;
                            prevPrevLastOp = xx[i];
                        }
                    }
                }
            }
        }
        public GeneralInvoiceEditForm(BillMaster entity, InvoiceKind invoiceKind, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            //radioButton2.Checked = true;
            billMaster = entity;
            this.invoiceKind = invoiceKind;
            FormOperation = formOperation;
            if (FormOperation == FormOperation.DestructionBill)
            {
                this.billMaster.BillDetails = new List<BillDetail>();
                this.billMaster.InvoiceKind = this.invoiceKind;
                if (invoiceKind == InvoiceKind.ExpiryArticles)
                {
                    billMaster.AccountId = 20;
                }
                else if (invoiceKind == InvoiceKind.Sell && UserLoggedIn.User.UserPermissions.CustomerAccountId != 0)
                {
                    billMaster.AccountId = UserLoggedIn.User.UserPermissions.CustomerAccountId;
                }
            }
            else if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                this.billMaster.BillDetails = new List<BillDetail>();
                this.billMaster.InvoiceKind = this.invoiceKind;
                if (invoiceKind == InvoiceKind.Sell && UserLoggedIn.User.UserPermissions.CustomerAccountId != 0)
                {
                    billMaster.AccountId = UserLoggedIn.User.UserPermissions.CustomerAccountId;
                }

            }
            else if (FormOperation == FormOperation.ReturnEmpty || FormOperation == FormOperation.ReturnArticles)
            {
                this.billMaster.BillDetails = new List<BillDetail>();
                this.billMaster.InvoiceKind = this.invoiceKind;
                if (UserLoggedIn.User.UserPermissions.CustomerAccountId != 0)
                {
                    billMaster.AccountId = UserLoggedIn.User.UserPermissions.CustomerAccountId;
                }
            }
            ChangeImageButton();
            #region Assigned To Binding Source
            EditBindingSource.DataSource = billMaster;
            if (billMaster.BillDetails == null && !(FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New || FormOperation == FormOperation.ReturnEmpty || FormOperation == FormOperation.DestructionBill))
            {
                billMaster.BillDetails = ShefaaPharmacyDbContext.GetCurrentContext().BillDetails.Where(x => x.BillMasterId == billMaster.Id).ToList();
            }
            DetailBindingSource.DataSource = billMaster.BillDetails;
            //((BillMaster)EditBindingSource.DataSource).onUpdateForm += InitEntity_onUpdateForm;
            billMaster.onUpdateForm += InitEntity_onUpdateForm;
            #endregion
            #region Data Grid View Detail
            dgDetail.AutoGenerateColumns = true;
            dgDetail.Columns["InvoiceKind"].Visible = false;
            dgDetail.Columns["Id"].Visible = false;
            ////dgDetail.Columns["PriceTagId"].Visible = false;
            ////dgDetail.Columns["UnitTypeIdBasic"].Visible = false;
            dgDetail.Columns["QuantityGift"].Visible = false;
            dgDetail.Columns["CreationDate"].Visible = false;
            dgDetail.Columns["CreationByDescr"].Visible = false;
            dgDetail.Columns["Discount"].Visible = false;

            #endregion
            #region Name Of Form
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                switch (invoiceKind)
                {
                    case InvoiceKind.Sell:
                        this.Text = "فاتورة مبيع";
                        break;
                    case InvoiceKind.Buy:
                        this.Text = "فاتورة شراء";
                        break;
                    case InvoiceKind.ReturnSell:
                        this.Text = "مرتجع فاتورة";
                        break;
                    default:
                        break;
                }
            #endregion
            if (formOperation == FormOperation.Delete)
            {
                this.Text = "حذف فاتورة مبيع";
            }
            if (formOperation == FormOperation.Delete || formOperation == FormOperation.Edit || formOperation == FormOperation.EditFromPicker)
            {
                lbDeleteBill.Visible = lbReturnBill.Visible = false;
            }
            else if (formOperation == FormOperation.Return || formOperation == FormOperation.ReturnEmpty)
            {
                lbDeleteBill.Visible = lbReturnBill.Visible = true;
                this.Text = "إرجاع فاتورة";
            }
            else if (formOperation == FormOperation.ReturnArticles)
            {
                lbDeleteBill.Visible = lbReturnBill.Visible = true;
                this.Text = "فاتورة مرتجع مبيعات";
            }
            else if (formOperation == FormOperation.DestructionBill)
            {
                lbDeleteBill.Visible = lbReturnBill.Visible = false;
                this.Text = "إهلاك فاتورة";
            }
            LastThreeOperation();
            cbPaymentMethod.SelectedIndexChanged += new EventHandler(this.cbPaymentMethod_SelectedIndexChanged);
            dgItemLeft.DataSource = new List<ArticleRemaningAmount>();
        }
        public double calcSum()
        {
            double sum = 0;
            for (int i = 0; i < dgDetail.Rows.Count - 1; i++)
            {
                sum += double.Parse(dgDetail.Rows[i].Cells[9].Value.ToString());
                //SendKeys.SendWait("{ENTER}");
                // sum += Convert.ToInt32(dgDetail.CurrentRow.Cells[7].Value) * Convert.ToInt32(dgDetail.CurrentRow.Cells[4].Value);
                // if (tbDiscount.Text != "") sum -= Convert.ToInt32(tbDiscount.Text);
                //else  sum -= double.Parse(tbDiscount.Text);
            }
            return Convert.ToInt32(sum);
        }
        public GeneralInvoiceEditForm(BillMaster entity, InvoiceKind invoiceKind, FormOperation formOperation, bool loadTabs)
        {
            InitializeComponent();
            billMaster = entity;
            this.invoiceKind = invoiceKind;
            FormOperation = formOperation;
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                this.billMaster.BillDetails = new List<BillDetail>();
                this.billMaster.InvoiceKind = this.invoiceKind;
                if (invoiceKind == InvoiceKind.Sell && UserLoggedIn.User.UserPermissions.CustomerAccountId != 0)
                {
                    billMaster.AccountId = UserLoggedIn.User.UserPermissions.CustomerAccountId;
                }
            }
            ChangeImageButton();
            #region Assigned To Binding Source
            EditBindingSource.DataSource = billMaster;
            if (billMaster.BillDetails == null && !(FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New))
            {
                billMaster.BillDetails = ShefaaPharmacyDbContext.GetCurrentContext().BillDetails.Where(x => x.BillMasterId == billMaster.Id).ToList();
            }
            DetailBindingSource.DataSource = billMaster.BillDetails;
            //((BillMaster)EditBindingSource.DataSource).onUpdateForm += InitEntity_onUpdateForm;
            ((BillMaster)EditBindingSource.DataSource).onUpdateForm += InitEntity_onUpdateForm;
            #endregion
            #region Data Grid View Detail
            dgDetail.AutoGenerateColumns = true;
            dgDetail.Columns["InvoiceKind"].Visible = false;
            dgDetail.Columns["Id"].Visible = false;
            //dgDetail.Columns["PriceTagId"].Visible = false;
            //dgDetail.Columns["UnitTypeIdBasic"].Visible = false;
            dgDetail.Columns["CreationDate"].Visible = false;
            dgDetail.Columns["CreationByDescr"].Visible = false;
            dgDetail.Columns["QuantityGift"].Visible = false;
            #endregion
            #region Name Of Form
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                switch (invoiceKind)
                {
                    case InvoiceKind.Sell:
                        this.Text = "فاتورة مبيع";
                        break;
                    case InvoiceKind.Buy:
                        this.Text = "فاتورة شراء";
                        break;
                    case InvoiceKind.ReturnSell:
                        this.Text = "مرتجع فاتورة";
                        break;
                    default:
                        break;
                }
            #endregion
            #region Disable Enable Contorls
            switch (invoiceKind)
            {
                case InvoiceKind.ReturnSell:
                    dgDetail.ReadOnly = true;
                    dgDetail.AllowUserToAddRows = false;
                    dgDetail.AllowUserToDeleteRows = false;
                    cbPaymentMethod.Enabled = false;
                    dtCreationDate.Enabled = false;
                    tbAccountIdDescr.Enabled = false;
                    break;
                default:
                    break;
            }
            #endregion
            #region Last 3 Operation 
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                LastThreeOperation();
            if (loadTabs)
            {
                TopLevel = false;
                FormBorderStyle = FormBorderStyle.None;
                Dock = DockStyle.Fill;
                ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
                pHelperButton.Visible = false;
                DisplayHeader = false;
                Movable = false;
                Resizable = false;
                //splitter1.Visible = false;
                pBottomLastOperation.Visible = false;
            }
            #endregion
            billMaster.CalcTotal();
            this.cbPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cbPaymentMethod_SelectedIndexChanged);
            this.Resize += new EventHandler(GeneralInvoiceEditForm_Resize);
        }
        public void DeleteRow()
        {
            try
            {
                if (dgDetail.Rows.Count > 0 && DetailBindingSource.Current != null)
                {
                    dgDetail.Rows.RemoveAt(dgDetail.CurrentRow.Index);
                    billMaster.CalcTotal();
                    object sender = new object();
                    CancelEventArgs ee = new CancelEventArgs();
                    tbDiscount_Validating(sender, ee);
                    //billMaster.CalcTotal();
                    dgDetail.Refresh();
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }
        public void DecreseQuantity()
        {
            if (dgDetail.Rows.Count > 0 && DetailBindingSource.Current != null)
            {
                if ((DetailBindingSource.Current as BillDetail).Quantity > 1)
                {
                    (DetailBindingSource.Current as BillDetail).Quantity -= 1;
                }
                CancelEventArgs ee = new CancelEventArgs();
                object sender = new object();
                tbDiscount_Validating(sender, ee);
                dgDetail.Refresh();

            }
        }
        public void InecreseQuantity()
        {
            if (dgDetail.Rows.Count > 0 && DetailBindingSource.Current != null)
            {
                (DetailBindingSource.Current as BillDetail).Quantity += 1;
                CancelEventArgs ee = new CancelEventArgs();
                object sender = new object();
                tbDiscount_Validating(sender, ee);
                dgDetail.Refresh();
            }
        }
        public void SetFocus()
        {
            if (dgDetail.Rows.Count > 0)
            {
                SetColumnIndex method = new SetColumnIndex(Mymethod);
                dgDetail.BeginInvoke(method, dgDetail.Columns["BarcodeDescr"].Index);
            }
        }
        private void Mymethod(int columnIndex)
        {
            if (dgDetail.CurrentRow == null)
            {
                DetailBindingSource.AddNew();
            }
            dgDetail.CurrentCell = dgDetail.CurrentRow.Cells[columnIndex];
            dgDetail.BeginEdit(true);
        }
        delegate void SetColumnIndex(int i);
        public void BindingEntityToControls()
        {
            tbId.DataBindings.Add("text", EditBindingSource, "Id", false, DataSourceUpdateMode.OnPropertyChanged);
            dtCreationDate.DataBindings.Add("text", EditBindingSource, "CreationDate", true, DataSourceUpdateMode.OnPropertyChanged);
            tbAccountIdDescr.DataBindings.Add("text", EditBindingSource, "AccountIdDescr", true, DataSourceUpdateMode.OnPropertyChanged);

            tbPayment.DataBindings.Add("text", EditBindingSource, "Payment", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N");
            tbRemainingAmount.DataBindings.Add("text", EditBindingSource, "RemainingAmount", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N");
            tbTotalPrice.DataBindings.Add("text", EditBindingSource, "TotalPrice", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N");
            tbDiscount.DataBindings.Add("text", EditBindingSource, "Discount", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N");

            cbPaymentMethod.DataSource = Enum.GetValues(typeof(PaymentMethod));
            cbPaymentMethod.SelectedIndex = (int)((BillMaster)EditBindingSource.Current).PaymentMethod;
            //cbStore.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Stores.ToList();
            //cbStore.ValueMember = "Id";
            //cbStore.DisplayMember = "Name";
            //cbStore.SelectedValue = UserLoggedIn.User.StoreId;

            List<string> data = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.ToList().Select(x => x.Name).ToList();
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            data.ForEach(x => autoCompleteStringCollection.Add(x));
            tbAccountIdDescr.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbAccountIdDescr.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbAccountIdDescr.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        private void EditBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            BindingEntityToControls();
        }

        private void dgDetail_BindingContextChanged(object sender, EventArgs e)
        {
            CancelEventArgs ee = new CancelEventArgs();
            tbDiscount_Validating(sender, ee);
            dgDetail.Refresh();
        }
        private void DetailBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            if (AbortAddNewRow)
                return;
            e.NewObject = new BillDetail(billMaster);
            AbortAddNewRow = false;
        }

        private void EditBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            billMaster = new BillMaster();
            billMaster.onUpdateForm += InitEntity_onUpdateForm;
            billMaster.InvoiceKind = this.invoiceKind;
            if (invoiceKind == InvoiceKind.Sell && UserLoggedIn.User.UserPermissions.CustomerAccountId != 0)
            {
                billMaster.AccountId = UserLoggedIn.User.UserPermissions.CustomerAccountId;
            }
            billMaster.BillDetails = new List<BillDetail>();
            e.NewObject = billMaster;
            //dgDetail.DataBindings.Clear();
            //DetailBindingSource.Clear();
            DetailBindingSource.DataSource = billMaster.BillDetails;
            dgDetail.DataSource = DetailBindingSource;
            dgDetail.Refresh();
            dgItemLeft.DataSource = new List<ArticleRemaningAmount>();
            dgItemLeft.Refresh();
            CancelEventArgs ee = new CancelEventArgs();
            //object sender = new object();
            tbDiscount_Validating(sender, ee);
            tbPayment_Validating(sender, ee);
        }
        private void checkpricetagforminus()
        {
            if (IsInMinus)
            {
                BillDetail mybill = billMaster.BillDetails.FirstOrDefault();
                mybill.PriceTag = new PriceTagMaster()
                {
                    ArticleId = mybill.ArticaleId,
                    UnitId = InventoryService.GetSmallestArticleUnit(mybill.ArticaleId),
                    CountGiftItem = 0,
                    CountSoldItem = 0,
                    CountAllItem = -1 * InventoryService.ConvertArticleUnitToSmallestUnit(mybill.ArticaleId, mybill.UnitTypeId, mybill.Quantity),
                    BranchId = UserLoggedIn.User.BranchId,
                    ExpiryDate = DateTime.Now.AddYears(1),
                    PriceTagDetails = ArticleService.MakeNewPriceTagDetailForArticle(mybill),
                };
                billMaster.BillDetails.RemoveAt(index: 0);
                billMaster.BillDetails.Add(mybill);
            }
        }
        private bool SaveNewBill()
        {
            if (billMaster.PaymentMethod == PaymentMethod.Cash && FormOperation != FormOperation.Edit)
            {
                if (RemainingAmoungIfBigger > Convert.ToDouble(tbTotalPrice.Text))
                {
                    billMaster.payment = (int)RemainingAmoungIfBigger;
                    billMaster.discount = -1 * (billMaster.payment - billMaster.TotalPrice);
                }
            }
            BillService billService = new BillService(billMaster);

            bool result = false;
            switch (invoiceKind)
            {
                case InvoiceKind.Sell:
                    if (IsInMinus == true) result = billService.SellInMinusBill();
                    else result = billService.SellBill();
                    LastThreeOperation();
                    break;
                case InvoiceKind.Buy:
                    result = billService.BuyBill();
                    LastThreeOperation();
                    break;
                case InvoiceKind.ReturnSell:
                    result = billService.ReturnBill(InvoiceKind.ReturnSell);
                    LastThreeOperation();
                    break;
                case InvoiceKind.ExpiryArticles:
                    result = billService.DestructionBill();
                    break;
                default:
                    break;
            }
            if (!result)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء تخزين الفاتورة", MessageBoxState.Error);
                return false;
            }
            return result;
        }
        private bool DeleteBill()
        {
            BillService billService = new BillService(billMaster);
            if (billMaster.InvoiceKind == InvoiceKind.Sell)
            {
                return billService.DeleteBill(InvoiceKind.DeleteSell);
            }
            else if (billMaster.InvoiceKind == InvoiceKind.ReturnSell)
            {
                return billService.DeleteBill(InvoiceKind.DeleteReturnSell);
            }
            else if (billMaster.InvoiceKind == InvoiceKind.ReturnBuy)
            {
                return billService.DeleteBill(InvoiceKind.ReturnBuy);
            }
            else
            {
                return false;
            }
        }
        private bool ReturnBill()
        {
            //var CurentGridItems = DetailBindingSource.DataSource as List<BillDetail>;

            //foreach (var detail in billMaster.BillDetails.ToList())
            //{
            //    bool has = CurentGridItems.Any(cus => cus.ArticaleId == detail.ArticaleId);
            //    if (!has)
            //    {
            //        billMaster.BillDetails.Remove(detail);
            //    }
            //}
            if (FormOperation == FormOperation.ReturnArticles)
            {
                BillService billService1 = new BillService(billMaster);
                return billService1.ReturnBill(InvoiceKind.ReturnSellArticles);
            }
            else
            {
                BillService billService2 = new BillService(billMaster);
                return billService2.ReturnBill(InvoiceKind.ReturnSell);
            }
        }
        private bool EditBill()
        {
            BillService billService = new BillService(billMaster);
            return billService.EditBill();
        }
        private void tbAccountIdDescr_MouseHover(object sender, EventArgs e)
        {
        }

        private void cbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbPaymentMethod.SelectedIndex == 0)
            {
                tbPayment.Enabled = false;
                billMaster.PaymentMethod = PaymentMethod.Cash;
                CancelEventArgs ee = new CancelEventArgs();
                tbDiscount_Validating(sender, ee);
            }
            else
            {
                billMaster.paymentMethod = PaymentMethod.Debit;
                CancelEventArgs ee = new CancelEventArgs();

                tbDiscount_Validating(sender, ee);
                tbPayment.Enabled = true;
                tbPayment.Text = "0";
            }
            //(EditBindingSource.Current as BillMaster).PaymentMethod = (PaymentMethod)cbPaymentMethod.SelectedValue;
            //if ((PaymentMethod)cbPaymentMethod.SelectedValue == PaymentMethod.Debit)
            //{
            //    (EditBindingSource.Current as BillMaster).RemainingAmount = (EditBindingSource.Current as BillMaster).TotalPrice;
            //    (EditBindingSource.Current as BillMaster).Payment = 0;
            //    (EditBindingSource.Current as BillMaster).Discount = 0;
            //}
            //else if ((PaymentMethod)cbPaymentMethod.SelectedValue == PaymentMethod.Cash)
            //{
            //    (EditBindingSource.Current as BillMaster).RemainingAmount = 0;
            //    (EditBindingSource.Current as BillMaster).Payment = (EditBindingSource.Current as BillMaster).TotalPrice;
            //    (EditBindingSource.Current as BillMaster).Discount = 0;
            //}
            //EditBindingSource.ResetCurrentItem();
        }

        private void dgDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgDetail.CurrentRow.DataBoundItem == null)
                return;
            try
            {
                var cell = dgDetail[e.ColumnIndex, e.RowIndex];
                string cellName = cell.OwningColumn.Name;
                if ((DetailBindingSource.Current as BillDetail).BillMaster == null)
                {
                    (DetailBindingSource.Current as BillDetail).BillMaster = billMaster;
                }

                if ((cellName == "BarcodeDescr") && (e.FormattedValue.ToString() != "") && (DetailBindingSource.Current as BillDetail).Barcode != e.FormattedValue.ToString())
                {
                    var context = ShefaaPharmacyDbContext.GetCurrentContext();
                    var articleBarcode = context.Articles.Where(x => x.Barcode == e.FormattedValue.ToString()).FirstOrDefault();
                    if (articleBarcode != null)
                    {
                        foreach (DataGridViewRow item in dgDetail.Rows)
                        {
                            try
                            {
                                if (dgDetail.Rows.Count > 2 && item.Index != dgDetail.Rows.Count - 1 && item.Cells[0].Value.ToString() == e.FormattedValue.ToString())
                                {
                                    if (this.FormOperation != FormOperation.ReturnArticles && Convert.ToInt32(item.Cells["quantity"].Value) + 1 > Convert.ToInt32(item.Cells["CountLeft"].Value))
                                    {
                                        int quant = Convert.ToInt32(item.Cells["CountLeft"].Value);
                                        string msg = " الكمية المطلوبة أكبر من الكمية الموجودة" + "\n" + "علماً أن الكمية الإجمالية المتبقية هي " + quant + "\n" + "سوف يتم بيع النقص بالسالب";
                                        IsInMinus = true;
                                        _MessageBoxDialog.Show(msg, MessageBoxState.Warning);
                                        item.Cells["quantity"].Value = Convert.ToInt32(item.Cells["quantity"].Value) + 1;
                                    }
                                    else
                                    {
                                        item.Cells["quantity"].Value = Convert.ToInt32(item.Cells["quantity"].Value) + 1;
                                    }

                                    e.Cancel = true;
                                    dgDetail.Rows[item.Index].Selected = true;
                                    dgDetail.CurrentRow.Cells[0].Value = "";
                                    dgDetail.CurrentRow.Selected = false;
                                    return;
                                }
                            }
                            catch
                            {
                                ;
                            }
                        }

                        var pricetag = DescriptionFK.GetOldestExpiryDate(articleBarcode.Id);
                        if (pricetag == null)
                        {
                            if (DescriptionFK.GetLastPriceTagForArt(articleBarcode.Id) == null)
                            {
                                _MessageBoxDialog.Show("لا يوجد بطاقة سعر للمنتج", MessageBoxState.Error);
                                e.Cancel = true;
                                return;
                            }
                            else
                            {
                                //Do Something
                            }
                        }
                        else
                        {
                            articleBarcode.PriceTagMasters = pricetag;
                            if (this.FormOperation != FormOperation.ReturnArticles && CheckExpiryDate(articleBarcode))
                            {
                                _MessageBoxDialog.Show("يوجد كمية منتهية المدة من هذه المادة", MessageBoxState.Alert);
                            }
                            if (!CheckQuantityOnSell(articleBarcode))
                            {
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        string message = "باركود غير موجود هل تريد إختيار صنف ؟";
                        MessageBoxAnswer dialogResult;
                        dialogResult = _MessageBoxDialog.Show(message, MessageBoxState.Answering);
                        if (dialogResult == MessageBoxAnswer.Yes)
                        {
                            Article result = ArticlePicker.PickArticale("", 0, FormOperation.Pick);
                            if (result == null)
                            {
                                (DetailBindingSource.Current as BillDetail).BarcodeDescr = "";
                                e.Cancel = true;
                            }
                            else
                            {
                                foreach (DataGridViewRow item in dgDetail.Rows)
                                {
                                    try
                                    {
                                        if (dgDetail.Rows.Count > 2 && item.Index != dgDetail.Rows.Count - 1 && item.Cells[0].Value.ToString() == result.Barcode)
                                        {
                                            if (this.FormOperation != FormOperation.ReturnArticles && Convert.ToInt32(item.Cells["quantity"].Value) + 1 > Convert.ToInt32(item.Cells["CountLeft"].Value))
                                            {
                                                int quant = Convert.ToInt32(item.Cells["CountLeft"].Value);
                                                string msg = " الكمية المطلوبة أكبر من الكمية الموجودة" + "\n" + "علماً أن الكمية الإجمالية المتبقية هي " + quant + "\n" + "سوف يتم بيع النقص بالسالب";
                                                IsInMinus = true;
                                                _MessageBoxDialog.Show(msg, MessageBoxState.Warning);
                                                item.Cells["quantity"].Value = Convert.ToInt32(item.Cells["quantity"].Value) + 1;
                                            }
                                            else
                                            {
                                                item.Cells["quantity"].Value = Convert.ToInt32(item.Cells["quantity"].Value) + 1;
                                            }

                                            e.Cancel = true;
                                            dgDetail.Rows[item.Index].Selected = true;
                                            dgDetail.CurrentRow.Cells[0].Value = "";
                                            dgDetail.CurrentRow.Selected = false;
                                            return;
                                        }
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                }


                                result.PriceTagMasters = DescriptionFK.GetOldestExpiryDate(articleId: result.Id);
                                if (invoiceKind == InvoiceKind.Sell)
                                {
                                    if (!CheckQuantityOnSell(result))
                                        e.Cancel = true;
                                    return;
                                }
                            }
                        }
                    }
                    try
                    {
                        Article Articale = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Id == (DetailBindingSource.Current as BillDetail).ArticaleId);
                        int remainingamount = InventoryService.GetAllArticleAmountRemaningInAllPrices(Articale.Id, (DetailBindingSource.Current as BillDetail).UnitTypeId);
                        if (this.FormOperation != FormOperation.ReturnArticles && remainingamount < Articale.LimitDown)
                        {
                            _MessageBoxDialog.Show("المادة قد تجاوزت الحد الأدنى للكمية" + "\n" + "الحد الأدنى : " + Articale.LimitDown + "", MessageBoxState.Warning);
                        }
                    }
                    catch
                    {
                        ;
                    }

                }
                else if (cellName == "Price" && (e.FormattedValue.ToString() != "") && (DetailBindingSource.Current as BillDetail).Price != Convert.ToDouble(e.FormattedValue))
                {
                    var context = ShefaaPharmacyDbContext.GetCurrentContext();
                    var lastPriceTage = DescriptionFK.GetLastPriceTagForArt((DetailBindingSource.Current as BillDetail).ArticaleId);
                    //var lastSellPrice = UnitTypeService.GetLastSellPrice((DetailBindingSource.Current as BillDetail).ArticaleId, (DetailBindingSource.Current as BillDetail).UnitTypeId, lastPriceTage.Id);
                    //if (Convert.ToDouble(e.FormattedValue) != lastSellPrice)
                    //{
                    //    string message = "سعر الصنف في هذه البطاقة " + lastSellPrice + "\n هل تريد إضافة سعر جديد";
                    //    MessageBoxAnswer dialogResult;
                    //    dialogResult = _MessageBoxDialog.Show(message, MessageBoxState.Answering);
                    //    if (dialogResult == MessageBoxAnswer.Yes)
                    //    {
                    //        context.PriceTags.Add(
                    //            new PriceTag()
                    //            {
                    //                ExpiryDate = lastPriceTage.ExpiryDate,
                    //                ArticaleId = lastPriceTage.ArticaleId,
                    //                UnitTypeId = lastPriceTage.UnitTypeId,
                    //                Unit2TypeId = lastPriceTage.Unit2TypeId,
                    //                Unit3TypeId = lastPriceTage.Unit3TypeId,
                    //                SellPrimary = lastPriceTage.UnitTypeId == (DetailBindingSource.Current as BillDetail).UnitTypeId ? Convert.ToDouble(e.FormattedValue) : lastPriceTage.SellPrimary,
                    //                SellSecondary = lastPriceTage.Unit2TypeId == (DetailBindingSource.Current as BillDetail).UnitTypeId ? Convert.ToDouble(e.FormattedValue) : lastPriceTage.SellSecondary,
                    //                SellTertiary = lastPriceTage.Unit3TypeId == (DetailBindingSource.Current as BillDetail).UnitTypeId ? Convert.ToDouble(e.FormattedValue) : lastPriceTage.SellTertiary,
                    //                BuyPrimary = lastPriceTage.BuyPrimary,
                    //                BuySecondary = lastPriceTage.BuySecondary,
                    //                BuyTertiary = lastPriceTage.BuyTertiary,
                    //                CreationBy = UserLoggedIn.User.Id,
                    //                CreationDate = DateTime.Now,
                    //                Every = lastPriceTage.Every,
                    //                Present = lastPriceTage.Present,
                    //                CountItem = lastPriceTage.CountItem,
                    //                CountPresent = lastPriceTage.CountPresent,
                    //                Discount = lastPriceTage.Discount,
                    //                PharmacyOperator1 = lastPriceTage.PharmacyOperator1 ?? "",
                    //                PharmacyOperator2 = lastPriceTage.PharmacyOperator2 ?? ""
                    //            });
                    //        context.SaveChanges();
                    //    }
                    //}
                }
                else if (cellName == "ArticaleIdDescr" && (e.FormattedValue.ToString() != "") && (DetailBindingSource.Current as BillDetail).ArticaleIdDescr != e.FormattedValue.ToString())
                {
                    Article result = DescriptionFK.ArticaleExists(true, e.FormattedValue.ToString(), 0);
                    if (result != null)
                    {
                        foreach (DataGridViewRow item in dgDetail.Rows)
                        {
                            try
                            {
                                if (dgDetail.Rows.Count > 2 && item.Index != dgDetail.Rows.Count - 1 && item.Cells[2].Value.ToString() == result.Name)
                                {
                                    //(DetailBindingSource.DataSource as BillDetail).BarcodeDescr = "";
                                    if (this.FormOperation != FormOperation.ReturnArticles && Convert.ToInt32(item.Cells["quantity"].Value) + 1 > Convert.ToInt32(item.Cells["CountLeft"].Value))
                                    {
                                        int quant = Convert.ToInt32(item.Cells["CountLeft"].Value);
                                        string msg = " الكمية المطلوبة أكبر من الكمية الموجودة" + "\n" + "علماً أن الكمية الإجمالية المتبقية هي " + quant + "\n" + "سوف يتم بيع النقص بالسالب";
                                        IsInMinus = true;
                                        _MessageBoxDialog.Show(msg, MessageBoxState.Warning);
                                        item.Cells["quantity"].Value = Convert.ToInt32(item.Cells["quantity"].Value) + 1;
                                    }
                                    else
                                    {
                                        item.Cells["quantity"].Value = Convert.ToInt32(item.Cells["quantity"].Value) + 1;
                                    }

                                    e.Cancel = true;
                                    dgDetail.Rows[item.Index].Selected = true;
                                    dgDetail.CurrentRow.Cells[0].Value = "";
                                    dgDetail.CurrentRow.Selected = false;
                                    return;
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }

                        result.PriceTagMasters = DescriptionFK.GetOldestExpiryDate(articleId: result.Id);
                        if (!CheckQuantityOnSell(result))
                            e.Cancel = true;
                    }
                    else
                    {
                        result = ArticlePicker.PickArticale("", 0, FormOperation.Pick);
                        if (result == null)
                        {
                            dgDetail[e.ColumnIndex, e.RowIndex].Value = "";
                            (DetailBindingSource.Current as BillDetail).ArticaleIdDescr = "";
                        }
                        else
                        {
                            foreach (DataGridViewRow item in dgDetail.Rows)
                            {
                                try
                                {
                                    if (dgDetail.Rows.Count > 2 && item.Index != dgDetail.Rows.Count - 1 && item.Cells[2].Value.ToString() == result.Name)
                                    {
                                        if (this.FormOperation != FormOperation.ReturnArticles && Convert.ToInt32(item.Cells["quantity"].Value) + 1 > Convert.ToInt32(item.Cells["CountLeft"].Value))
                                        {
                                            int quant = Convert.ToInt32(item.Cells["CountLeft"].Value);
                                            string msg = " الكمية المطلوبة أكبر من الكمية الموجودة" + "\n" + "علماً أن الكمية الإجمالية المتبقية هي " + quant + "\n" + "سوف يتم بيع النقص بالسالب";
                                            IsInMinus = true;
                                            _MessageBoxDialog.Show(msg, MessageBoxState.Warning);
                                            item.Cells["quantity"].Value = Convert.ToInt32(item.Cells["quantity"].Value) + 1;
                                        }
                                        else
                                        {
                                            item.Cells["quantity"].Value = Convert.ToInt32(item.Cells["quantity"].Value) + 1;
                                        }

                                        e.Cancel = true;
                                        dgDetail.Rows[item.Index].Selected = true;
                                        dgDetail.CurrentRow.Cells[0].Value = "";
                                        dgDetail.CurrentRow.Selected = false;
                                        return;
                                    }
                                }
                                catch
                                {
                                    break;
                                }
                            }

                            result.PriceTagMasters = DescriptionFK.GetOldestExpiryDate(articleId: result.Id);
                            if (!CheckQuantityOnSell(result))
                                e.Cancel = true;
                        }
                    }
                }
                else if (cellName == "UnitTypeIdDescr" && (e.FormattedValue.ToString() != "") && (DetailBindingSource.Current as BillDetail).UnitTypeIdDescr != e.FormattedValue.ToString())
                {
                    ArticleUnits articleUnits = DescriptionFK.ArticleUnitExists((DetailBindingSource.Current as BillDetail).ArticaleId, e.FormattedValue.ToString());
                    if (articleUnits == null)
                    {
                        e.Cancel = true;
                        _MessageBoxDialog.Show("واحدة غير منتمية لهذا الصنف", MessageBoxState.Error);
                        return;
                    }

                    PriceTagMaster priceTag = DescriptionFK.PriceTagExists((DetailBindingSource.Current as BillDetail).ArticaleId);
                    var currentRow = (DetailBindingSource.Current as BillDetail);
                    if (priceTag != null)
                    {
                        int unitId = DescriptionFK.GetUnitId(e.FormattedValue.ToString());
                        currentRow.UnitTypeId = unitId;
                        currentRow.UnitTypeIdDescr = e.FormattedValue.ToString();
                        currentRow.Price = Convert.ToInt32(priceTag.PriceTagDetails.FirstOrDefault(x => x.UnitId == unitId).SellPrice);/*ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x=> x.ArticleId==currentRow.ArticaleId).OrderBy(x => x.CreationDate).FirstOrDefault().PriceTagDetails.OrderBy(x => x.CreationBy).FirstOrDefault().;*/
                        currentRow.Quantity = 1;
                        currentRow.Discount = 0;
                        currentRow.TotalPrice = Convert.ToInt32((currentRow.Price * currentRow.Quantity) - currentRow.Discount);
                    }
                }

                else if (cellName == "Quantity")
                {
                    try
                    {
                        Article Articale = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Id == (DetailBindingSource.Current as BillDetail).ArticaleId);
                        int remainingamount = InventoryService.GetAllArticleAmountRemaningInAllPrices(Articale.Id, (DetailBindingSource.Current as BillDetail).UnitTypeId);
                        int qu = InventoryService.GetAllArticleAmountRemaningInAllPrices((DetailBindingSource.Current as BillDetail).ArticaleId, (DetailBindingSource.Current as BillDetail).UnitTypeId);
                        if ((!int.TryParse(e.FormattedValue.ToString(), out int i) || Convert.ToInt32(e.FormattedValue.ToString()) <= 0))
                        {
                            e.Cancel = true;
                            _MessageBoxDialog.Show("يجب إدخال رقم أكبر من الصفر", MessageBoxState.Error);
                            return;
                        }
                        else if (this.FormOperation != FormOperation.ReturnArticles && Convert.ToInt32(e.FormattedValue.ToString()) > qu && (FormOperation != FormOperation.ReturnEmpty && FormOperation != FormOperation.Return))
                        {
                            string message = " الكمية المطلوبة أكبر من الكمية الموجودة" + "\n" + "علماً أن الكمية الإجمالية المتبقية هي " + qu + "\n" + "سوف يتم بيع النقص بالسالب";
                            IsInMinus = true;
                            _MessageBoxDialog.Show(message, MessageBoxState.Warning);
                        }
                        else if (this.FormOperation != FormOperation.ReturnArticles && remainingamount - int.Parse(e.FormattedValue.ToString()) < Articale.LimitDown)
                        {
                            _MessageBoxDialog.Show("ببيعك هذه الكمية ستتجاوز الحد الأدنى للمادة" + "\n" + "الحد الأدنى : " + Articale.LimitDown + "", MessageBoxState.Warning);
                        }
                    }
                    catch
                    {
                        return;
                    }

                }

                CancelEventArgs ee = new CancelEventArgs();
                //object sender = new object();
                tbDiscount_Validating(sender, ee);
                tbPayment_Validating(sender, ee);
                billMaster.CalcTotalMobile();
                //InitEntity_onUpdateForm();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ في الادخال يرجى اعادة المحاولة", MessageBoxState.Error);
            }
        }
        private bool CheckExpiryDate(Article articale)
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var dbConfig = context.DataBaseConfigurations.FirstOrDefault();
                List<PriceTagMaster> PriceTagsForArticleInStore = context.PriceTagMasters.Include(x => x.Article.Id == articale.Id).ToList();
                List<PriceTagMaster> expired = PriceTagsForArticleInStore.Where(x => (DateTime.Now/*.AddDays(dbConfig.DayForExpiry)*/ >= x.ExpiryDate)).ToList();
                List<PriceTagMaster> mylist = new List<PriceTagMaster>();
                List<PriceTagMaster> NewList = new List<PriceTagMaster>();

                for (int i = 0; i < expired.Count; i++)
                {
                    if (expired[i].ExpiryDate == DateTime.Parse("01/01/0001"))
                    {
                        continue;
                    }
                    else
                    {
                        mylist.Add(expired[i]);
                    }
                }
                mylist = mylist.GroupBy(i => new { i.ExpiryDate, i.ArticleId }).Select(g => new PriceTagMaster
                {
                    ExpiryDate = g.Key.ExpiryDate,
                    ArticleId = g.Key.ArticleId, // join better than taking First()
                    CountAllItem = g.Sum(i => i.CountAllItem - (i.CountSoldItem + i.CountGiftItem))
                }).ToList();
                int Count = mylist.Select(x => new { x.ArticleIdDescr, x.UnitIdDescr, x.CountAllItem, x.ExpiryDate }).Where(x => x.CountAllItem != 0).Count();

                if (Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private bool CheckQuantityOnSell(Article articale)
        {
            var currentRow = (DetailBindingSource.Current as BillDetail);
            var Selectedunit = DescriptionFK.GetPrimaryUnit(articale.Id);
            var CheckRemainingAmount = InventoryService.GetQuantityOfArticleAllPriceTag(articale.Id);
            if (Convert.ToDouble(CheckRemainingAmount) <= 0)
            {
                if (this.FormOperation != FormOperation.ReturnArticles && FormOperation == FormOperation.ReturnEmpty)
                {
                    _MessageBoxDialog.Show("لا يوجد أي قطعة من هذا الصنف", MessageBoxState.Warning);
                    currentRow.ArticaleId = articale.Id;
                    currentRow.ArticaleIdDescr = articale.Name;
                    var lastPriceTage = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                    .Where(x => x.ArticleId == articale.Id)
                    .Include(x => x.PriceTagDetails)
                    .OrderByDescending(x => x.CreationDate)
                    .LastOrDefault();
                    if (lastPriceTage.PharmacyOperator1 != null && lastPriceTage.PharmacyOperator1.Trim() != "")
                    {
                        _MessageBoxDialog.Show(" يوجد تصنيف صيدلية أول :" + lastPriceTage.PharmacyOperator1, MessageBoxState.Alert);
                    }
                    if (lastPriceTage.PharmacyOperator2 != null && lastPriceTage.PharmacyOperator2.Trim() != "")
                    {
                        _MessageBoxDialog.Show(" يوجد تصنيف صيدلية ثاني :" + lastPriceTage.PharmacyOperator2, MessageBoxState.Alert);
                    }
                    currentRow.PriceTagId = lastPriceTage.Id;
                    currentRow.UnitTypeId = DescriptionFK.GetPrimaryUnit(articale.Id);
                    currentRow.UnitTypeIdBasic = DescriptionFK.GetPrimaryUnit(articale.Id);
                    currentRow.UnitTypeIdDescr = DescriptionFK.GetUnitName(lastPriceTage.UnitId);
                    if (lastPriceTage.PriceTagDetails.Count > 0)
                    {
                        currentRow.Price = lastPriceTage.PriceTagDetails.FirstOrDefault(x => x.UnitId == DescriptionFK.GetPrimaryUnit(articale.Id)).SellPrice;
                    }
                    else
                    {
                        currentRow.Price = 0;
                    }
                    currentRow.Quantity = 1;
                    currentRow.Barcode = articale.Barcode;
                    currentRow.BarcodeDescr = articale.Barcode;
                    dgItemLeft.DataSource = InventoryService.GetArticleAmountRemaning(articale.Id);
                    return true;
                }
                if (this.FormOperation == FormOperation.ReturnArticles)
                {
                    currentRow.ArticaleId = articale.Id;
                    currentRow.ArticaleIdDescr = articale.Name;
                    var lastPriceTage = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                    .Where(x => x.ArticleId == articale.Id)
                    .Include(x => x.PriceTagDetails)
                    .OrderByDescending(x => x.CreationDate).FirstOrDefault();

                    if (lastPriceTage.PharmacyOperator1 != null && lastPriceTage.PharmacyOperator1.Trim() != "")
                    {
                        _MessageBoxDialog.Show(" يوجد تصنيف صيدلية أول :" + lastPriceTage.PharmacyOperator1, MessageBoxState.Alert);
                    }
                    if (lastPriceTage.PharmacyOperator2 != null && lastPriceTage.PharmacyOperator2.Trim() != "")
                    {
                        _MessageBoxDialog.Show(" يوجد تصنيف صيدلية ثاني :" + lastPriceTage.PharmacyOperator2, MessageBoxState.Alert);
                    }
                    currentRow.PriceTagId = lastPriceTage.Id;
                    currentRow.UnitTypeId = DescriptionFK.GetPrimaryUnit(articale.Id);
                    currentRow.UnitTypeIdBasic = DescriptionFK.GetPrimaryUnit(articale.Id);
                    currentRow.UnitTypeIdDescr = DescriptionFK.GetUnitName(lastPriceTage.UnitId);
                    var context = ShefaaPharmacyDbContext.GetCurrentContext();
                    var quentityofprimary = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == articale.Id && x.UnitTypeId == lastPriceTage.UnitId).QuantityForPrimary;
                    if (lastPriceTage.PriceTagDetails.Count > 0)
                    {
                        currentRow.Price = lastPriceTage.PriceTagDetails.FirstOrDefault(x => x.UnitId == DescriptionFK.GetPrimaryUnit(articale.Id)).SellPrice;
                    }
                    else
                    {
                        currentRow.Price = 0;
                    }

                    currentRow.Quantity = 1;
                    currentRow.Barcode = articale.Barcode;
                    currentRow.BarcodeDescr = articale.Barcode;
                    dgItemLeft.DataSource = InventoryService.GetArticleAmountRemaning(articale.Id);
                    return true;
                }
                else
                {
                    string message = "لا يوجد أي قطعة من هذا الصنف هل تريد المبيع بالسالب ؟";
                    MessageBoxAnswer dialogResult;
                    dialogResult = _MessageBoxDialog.Show(message, MessageBoxState.Answering);
                    if (dialogResult == MessageBoxAnswer.Yes)
                    {
                        IsInMinus = true;
                        currentRow.ArticaleId = articale.Id;
                        currentRow.ArticaleIdDescr = articale.Name;
                        var lastPriceTage = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                        .Where(x => x.ArticleId == articale.Id)
                        .Include(x => x.PriceTagDetails)
                        .OrderByDescending(x => x.CreationDate).FirstOrDefault();

                        if (lastPriceTage.PharmacyOperator1 != null && lastPriceTage.PharmacyOperator1.Trim() != "")
                        {
                            _MessageBoxDialog.Show(" يوجد تصنيف صيدلية أول :" + lastPriceTage.PharmacyOperator1, MessageBoxState.Alert);
                        }
                        if (lastPriceTage.PharmacyOperator2 != null && lastPriceTage.PharmacyOperator2.Trim() != "")
                        {
                            _MessageBoxDialog.Show(" يوجد تصنيف صيدلية ثاني :" + lastPriceTage.PharmacyOperator2, MessageBoxState.Alert);
                        }
                        currentRow.PriceTagId = lastPriceTage.Id;
                        currentRow.UnitTypeId = DescriptionFK.GetPrimaryUnit(articale.Id);
                        currentRow.UnitTypeIdBasic = DescriptionFK.GetPrimaryUnit(articale.Id);
                        currentRow.UnitTypeIdDescr = DescriptionFK.GetUnitName(lastPriceTage.UnitId);
                        var context = ShefaaPharmacyDbContext.GetCurrentContext();
                        var quentityofprimary = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == articale.Id && x.UnitTypeId == lastPriceTage.UnitId).QuantityForPrimary;
                        if (lastPriceTage.PriceTagDetails.Count > 0)
                        {
                            currentRow.Price = lastPriceTage.PriceTagDetails.FirstOrDefault(x => x.UnitId == DescriptionFK.GetPrimaryUnit(articale.Id)).SellPrice;
                        }
                        else
                        {
                            currentRow.Price = 0;
                        }

                        currentRow.Quantity = 1;
                        currentRow.Barcode = articale.Barcode;
                        currentRow.BarcodeDescr = articale.Barcode;
                        dgItemLeft.DataSource = InventoryService.GetArticleAmountRemaning(articale.Id);
                        return true;
                    }
                    return false;
                }
            }
            else
            {
                currentRow.ArticaleId = articale.Id;
                currentRow.ArticaleIdDescr = articale.Name;
                currentRow.UnitTypeId = DescriptionFK.GetPrimaryUnit(articale.Id);
                currentRow.UnitTypeIdBasic = DescriptionFK.GetPrimaryUnit(articale.Id);
                currentRow.UnitTypeIdDescr = DescriptionFK.GetUnitName(DescriptionFK.GetPrimaryUnit(articale.Id));
                int tagId = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == articale.Id).FirstOrDefault().Id;
                double firstsell = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagDetails.Where(x => x.PriceTagId == tagId).FirstOrDefault().SellPrice;
                currentRow.Price = firstsell;
                currentRow.Quantity = 1;
                currentRow.Barcode = articale.Barcode;
                currentRow.BarcodeDescr = articale.Barcode;
                currentRow.PriceTagId = articale.PriceTagMasters.OrderBy(x => x.ExpiryDate).LastOrDefault().Id;
                currentRow.CountLeft = CheckRemainingAmount;
                if (articale.PriceTagMasters.LastOrDefault().PharmacyOperator1 != null && articale.PriceTagMasters.LastOrDefault().PharmacyOperator1 != "")
                {
                    _MessageBoxDialog.Show(" يوجد تصنيف صيدلية أول :" + articale.PriceTagMasters.LastOrDefault().PharmacyOperator1, MessageBoxState.Alert);
                }
                if (articale.PriceTagMasters.LastOrDefault().PharmacyOperator2 != null && articale.PriceTagMasters.LastOrDefault().PharmacyOperator2 != "")
                {
                    _MessageBoxDialog.Show(" يوجد تصنيف صيدلية ثاني :" + articale.PriceTagMasters.LastOrDefault().PharmacyOperator2, MessageBoxState.Alert);
                }
                dgItemLeft.DataSource = InventoryService.GetArticleAmountRemaning(articale.Id);
                dgItemLeft.Refresh();
                return true;
            }
        }
        private void dgDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (FormOperation == FormOperation.Return)
            {
                dgDetail.ReadOnly = true;
                tbPayment.ReadOnly = true;
                return;
            }
            int column = dgDetail.CurrentCell.ColumnIndex;
            string headerText = dgDetail.Columns[column].Name;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            if (headerText.Equals("UnitTypeIdDescr") && (DetailBindingSource.Current as BillDetail).ArticaleId != 0)
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    var d = UnitTypeService.GetAllUnitForArticle((DetailBindingSource.Current as BillDetail).ArticaleId);
                    List<string> data = d.Select(x => x.UnitTypeIdDescr).ToList();
                    AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                    data.ForEach(x => autoCompleteStringCollection.Add(x));
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tb.AutoCompleteCustomSource = autoCompleteStringCollection;
                }
            }
            if (headerText.Equals("ArticaleIdDescr"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    List<string> data = context.Articles.Select(x => x.Name).ToList();
                    AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                    data.ForEach(x => autoCompleteStringCollection.Add(x));
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tb.AutoCompleteCustomSource = autoCompleteStringCollection;
                }
            }
        }
        /// <summary>
        /// الفاتورة الأخيرة
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pLastOp_Click(object sender, EventArgs e)
        {
            GeneralInvoiceEditForm generalInvoiceEditFormEdit = new GeneralInvoiceEditForm(lastOp, lastOp.InvoiceKind, FormOperation.EditFromPicker);
            generalInvoiceEditFormEdit.Show();
            LastThreeOperation();
        }
        private void CheckLastRow()
        {
            if (dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["Price"].Value == null ||
                dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["ArticaleIdDescr"].Value == null ||
                dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["Quantity"].Value == null)
            {
                return;
            }
            if (Convert.ToDouble(dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["Price"].Value) == 0 &&
                Convert.ToString(dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["ArticaleIdDescr"].Value) == "" &&
                Convert.ToInt32(dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["Quantity"].Value) == 0)
            {
                billMaster.BillDetails.RemoveAt(dgDetail.Rows.Count - 1);
            }

        }
        /// <summary>
        /// الفاتورة قبل الأخيرة
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(prevLastOp, prevLastOp.InvoiceKind, FormOperation.EditFromPicker);
            generalInvoiceEditForm.Show();
            LastThreeOperation();
        }
        public void CheckNumbers()
        {
            billMaster.CalcTotal();
            billMaster.TotalPrice = Convert.ToInt32(DescriptionFK.RoundInMath(billMaster.TotalPrice, ShefaaPharmacyDbContext.GetCurrentContext().DataBaseConfigurations.FirstOrDefault().CountNumberAfterComma));
            billMaster.Payment = Convert.ToInt32(DescriptionFK.RoundInMath(billMaster.Payment, ShefaaPharmacyDbContext.GetCurrentContext().DataBaseConfigurations.FirstOrDefault().CountNumberAfterComma));
        }
        /// <summary>
        /// إرجاع فاتورة أو حفظها
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pOk_Click(object sender, EventArgs e)
        {
            tbDiscount.Select();
            tbId.Select();
            tbId.Focus();
            try
            {
                //if (RDSFECXA__WEWDSA.ReeD())
                //{
                //    if (ShefaaPharmacyDbContext.IsItMoreThanMonth())
                //    {
                //        _MessageBoxDialog.Show("انتهت النسخة التجريبية لديك", MessageBoxState.Warning);
                //        return;
                //    }
                //}
                if (!RDSFECXA__WEWDSA.Ree())
                {
                    _MessageBoxDialog.Show("النسخة غير مسجلة يجب التسجيل للإكمال", MessageBoxState.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {
                return;
            }
            CheckNumbers();
            CheckLastRow();
            if (dgDetail.Rows[0].Cells[0].Value == null)
            {
                _MessageBoxDialog.Show("لا يجب أن يكون السطر الأول فارغا", MessageBoxState.Error);
                dgDetail.Rows.Remove(dgDetail.CurrentRow);
                return;
            }
            if (dgDetail.Rows[dgDetail.Rows.Count - 2].Cells[0].Value == null || dgDetail.Rows[dgDetail.Rows.Count - 2].Cells[1].Value == null)
            {
                dgDetail.Rows.Remove(dgDetail.Rows[dgDetail.Rows.Count - 2]);
                dgDetail.Rows[0].Selected = true;

                //return;
            }
            if (DetailBindingSource.Count < 1)
            {
                _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Error);
                return;
            }
            if (invoiceKind == InvoiceKind.Buy && billMaster.AccountId == 0)
            {
                _MessageBoxDialog.Show("يجب وضع حساب لإتمام العملية", MessageBoxState.Error);
                return;
            }
            if (this.cbPaymentMethod.SelectedIndex == 0)
                if (tbPayment.Text == "0" || tbPayment.Text == "0.00")
                {
                    _MessageBoxDialog.Show("لايمكن أن تكون قيمة الفاتورة صفر", MessageBoxState.Error);
                    return;
                }
            bool res;
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                res = SaveNewBill();
                if (res)
                {

                    _MessageBoxDialog.Show("تم حفظ الفاتورة", MessageBoxState.Done);
                    EditBindingSource.AddNew();
                    cbPaymentMethod.SelectedIndex = 0;
                    tbPayment.Text = "0";
                    tbDiscount.Text = "0";
                    SetFocus();
                    AddInvoiveToTaxSystem();
                }
            }
            else if (FormOperation == FormOperation.Delete)
            {
                try
                {
                    res = DeleteBill();
                    if (res)
                    {
                        dgDetail.DataSource = null;
                        _MessageBoxDialog.Show("تم حذف الفاتورة", MessageBoxState.Done);
                        Close();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
            else if (FormOperation == FormOperation.Return)
            {
                if (billMaster.IsReturned == true)
                {
                    _MessageBoxDialog.Show("هذه الفاتورة لها فاتورة إرجاع ", MessageBoxState.Error);
                    return;
                }
                res = ReturnBill();
                if (res)
                {
                    _MessageBoxDialog.Show("تم إرجاع الفاتورة", MessageBoxState.Done);
                    Close();
                }
            }
            else if (FormOperation == FormOperation.ReturnEmpty)
            {
                res = ReturnBill();
                if (res)
                {
                    _MessageBoxDialog.Show("تم إرجاع الفاتورة", MessageBoxState.Done);
                    Close();
                }
            }
            else if (FormOperation == FormOperation.ReturnArticles)
            {
                res = ReturnBill();
                if (res)
                {
                    _MessageBoxDialog.Show("تم إرجاع الفاتورة", MessageBoxState.Done);
                    Close();
                }
            }
            else if (FormOperation == FormOperation.Edit || FormOperation == FormOperation.EditFromPicker)
            {
                res = EditBill();
                if (res)
                {
                    _MessageBoxDialog.Show("تم تعديل الفاتورة", MessageBoxState.Done);
                    Close();
                    LastThreeOperation();
                }
            }
            else if (FormOperation == FormOperation.DestructionBill)
            {
                res = SaveNewBill();
                if (res)
                {
                    _MessageBoxDialog.Show("تمت العملية بنجاح", MessageBoxState.Done);
                    Close();
                    LastThreeOperation();
                }
            }
            IsInMinus = false;
        }
        private void AddInvoiveToTaxSystem()
        {
            string url = String.Format("http://213.178.227.75/Taxapi/api/Bill/AddFullBill");
            WebRequest requestPost = WebRequest.Create(url);
            requestPost.Method = "POST";
            requestPost.ContentType = "application/json";
            requestPost.Headers.Add("Authorization", "Bearer " + ShefaaPharmacyDbContext.GetCurrentContext().TaxAccount.FirstOrDefault().Token);
            TaxReportViewModel newObj = new TaxReportViewModel
            {
                billValue = 1000,
                billNumber= "2",
                code = "9373de8d-6e10-49b8-85b3-58ddf7f843d4",
                currency = Currency.SP,
                exProgram = "test",
                date = DateTime.Now.Date,
            };

            var postData = JsonConvert.SerializeObject(newObj);
            using (var streamWriter = new StreamWriter(requestPost.GetRequestStream()))
            {
                streamWriter.Write(postData);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)requestPost.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                int code = (int)httpResponse.StatusCode;
            }
        }
        /// <summary>
        /// حذف الفاتورة أو إلغاء العملية
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pCancel_Click(object sender, EventArgs e)
        {
            tbDiscount.Select();
            tbId.Select();
            tbId.Focus();
            CheckLastRow();
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                string message = "هل تريد إغلاق الواجهة";
                MessageBoxAnswer dialogResult = _MessageBoxDialog.Show(message, MessageBoxState.Answering);
                if (dialogResult == MessageBoxAnswer.Yes)
                {
                    Close();
                }
                else
                {
                    EditBindingSource.AddNew();
                    LastThreeOperation();
                    SetFocus();
                }
            }
            else
            {
                if (DetailBindingSource.Count < 1)
                {
                    _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Error);
                    return;
                }
                bool res = DeleteBill();
                if (res)
                {
                    _MessageBoxDialog.Show("تم حذف الفاتورة", MessageBoxState.Done);
                    Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Account result = AccountPickForm.PickAccount("", null, FormOperation.Pick);
            if (result != null)
            {
                (EditBindingSource.Current as BillMaster).AccountId = result.Id;
                (EditBindingSource.Current as BillMaster).AccountIdDescr = result.Name;
                tbAccountIdDescr.Text = result.Name;
            }
        }
        public static GeneralInvoiceEditForm[] EazyForms;
        public static CustomeAutoCompleteGrid customeAutoCompleteGrid;
        private void tcSell_Selected(object sender, TabControlEventArgs e)
        {
            if (EazyForms[e.TabPageIndex] == null)
            {
                EazyForms[e.TabPageIndex] = new GeneralInvoiceEditForm(new BillMaster(), InvoiceKind.Sell, FormOperation.New, true);
            }
            e.TabPage.Controls.Add(EazyForms[e.TabPageIndex]);
            EazyForms[e.TabPageIndex].Show();
        }
        private void GeneralInvoiceEditForm_Load(object sender, EventArgs e)
        {
            //dgvQueryArticle.CellDoubleClick += DgvQueryArticle_CellDoubleClick;
            //dgvQueryArticle.KeyDown += DgvQueryArticle_KeyDown;
            customeAutoCompleteGrid = new CustomeAutoCompleteGrid();
            EazyForms = new GeneralInvoiceEditForm[6];
            SetFocus();
            if (FormOperation == FormOperation.Delete)
            {
                Text = "حذف فاتورة";
            }
            else if (FormOperation == FormOperation.Return)
            {
                Text = "إرجاع فاتورة";
            }
            else if (FormOperation == FormOperation.New || FormOperation == FormOperation.NewFromPicker)
            {
                Text = "فاتورة مبيع (جديد)";
            }
            else if (FormOperation == FormOperation.Edit || FormOperation == FormOperation.EditFromPicker)
            {
                Text = "فاتورة مبيع (تعديل)";
            }
            dgItemLeft.AutoGenerateColumns = true;
            WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// الفاتورة قبل قبل الأخيرة
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(prevPrevLastOp, prevPrevLastOp.InvoiceKind, FormOperation.EditFromPicker);
            generalInvoiceEditForm.Show();
            LastThreeOperation();
        }
        private void ToolStripMenuItem_ClickAccFainanReport(object sender, EventArgs e)
        {
            AccountFainancialReportForm accountFainancialReportForm = new AccountFainancialReportForm(new UserParameters() { Acc_AccountId = (EditBindingSource.Current as BillMaster).AccountId });
            accountFainancialReportForm.ShowDialog();
        }

        private void ToolStripMenuItem_ClickArtDetailReport(object sender, EventArgs e)
        {
            ArticleDetailReportForm articleDetailReportForm = new ArticleDetailReportForm(new UserParameters() { ArticleId = (DetailBindingSource.Current as BillDetail).ArticaleId });
            articleDetailReportForm.ShowDialog();
        }

        private void dgDetail_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }
        private void lbAccount_Click(object sender, EventArgs e)
        {
            Account result = AccountPickForm.PickAccount("", new int[1] { ConstantDataBase.AC_Customer }, null, FormOperation.Pick);
            if (result != null)
            {
                (EditBindingSource.Current as BillMaster).AccountId = result.Id;
                (EditBindingSource.Current as BillMaster).AccountIdDescr = result.Name;
                tbAccountIdDescr.Text = result.Name;
            }
        }
        private void tbPayment_Validating(object sender, CancelEventArgs e)
        {
            if (tbTotalPrice.Text != "0.00" && tbTotalPrice.Text != "")
            {
                if (Convert.ToDouble(tbPayment.Text) > Convert.ToDouble(tbTotalPrice.Text))
                {
                    RemainingAmoungIfBigger = Convert.ToDouble(tbPayment.Text);
                }
            }

            if (tbPayment.Text == "")
            {
                return;
            }
            var bill = billMaster;
            tbPayment.Text = tbPayment.Text == "" ? "0" : tbPayment.Text;
            bill.payment = Convert.ToInt32(tbPayment.Text == "" ? 0 : double.Parse(tbPayment.Text));
            bill.RemainingAmount = bill.TotalPrice - bill.payment - bill.discount;
            //if (bill.Discount == 0.0)
            //{
            //    if ((int)cbPaymentMethod.SelectedValue == (int)PaymentMethod.Cash)
            //    {
            //        //tbPayment.Enabled = false;
            //        if (Convert.ToDouble((bill.TotalPrice - (Convert.ToDouble(tbPayment.Text))) / bill.TotalPrice * 100) / 100 > ShefaaPharmacyDbContext.GetCurrentContext().DataBaseConfigurations.FirstOrDefault().DiscountPercentage
            //       && Auth.DataEntryAndDown())
            //        {
            //            _MessageBoxDialog.Show("ليس من صلاحياتك الخصم بهذه القيمة", MessageBoxState.Warning);
            //            if (bill.PaymentMethod == PaymentMethod.Cash)
            //            {
            //                bill.Payment = bill.TotalPrice;
            //                bill.Discount = 0;
            //                bill.RemainingAmount = 0;
            //            }
            //            else
            //            {
            //                bill.RemainingAmount = bill.TotalPrice;
            //                bill.Discount = 0;
            //                bill.Payment = 0;
            //            }
            //        }
            //        else
            //        {
            //            bill.Discount = ((bill.TotalPrice - (Convert.ToDouble(tbPayment.Text))) / bill.TotalPrice * 100);
            //            //bill.discount = 0.0;
            //            bill.RemainingAmount = 0;
            //        }
            //    }
            //    else
            //    {

            //        bill.RemainingAmount = bill.TotalPrice - (Convert.ToDouble(tbPayment.Text));
            //    }
            //}
            //else// discount !=0
            //{
            //    if ((int)cbPaymentMethod.SelectedValue == (int)PaymentMethod.Cash)
            //    {
            //        if (((bill.TotalPrice - (Convert.ToDouble(tbPayment.Text))) / bill.TotalPrice * 100) / 100 > ShefaaPharmacyDbContext.GetCurrentContext().DataBaseConfigurations.FirstOrDefault().DiscountPercentage
            //       && Auth.DataEntryAndDown())
            //        {
            //            _MessageBoxDialog.Show("ليس من صلاحياتك الخصم بهذه القيمة", MessageBoxState.Warning);
            //            if (bill.PaymentMethod == PaymentMethod.Cash)
            //            {
            //                bill.Payment = bill.TotalPrice;
            //                tbPayment.Text = bill.Payment + "";
            //                bill.Discount = 0;
            //                bill.RemainingAmount = 0;
            //            }
            //            else
            //            {
            //                bill.RemainingAmount = bill.TotalPrice;
            //                bill.Discount = 0;
            //                bill.Payment = 0;
            //            }
            //        }
            //        else
            //        {
            //            // bill.Discount = 0;
            //            //bill.Discount = ((bill.TotalPrice - (Convert.ToDouble(tbPayment.Text))) / bill.TotalPrice * 100);
            //            bill.payment = bill.TotalPrice;
            //            bill.RemainingAmount = bill.TotalPrice - bill.payment;
            //        }
            //    }
            //    else//debit
            //    {
            //        bill.RemainingAmount = bill.TotalPrice - (Convert.ToDouble(tbPayment.Text));
            //    }
            //}
            tbPayment.Text = bill.Payment + "";
            tbDiscount.Text = bill.Discount + "";
            tbRemainingAmount.Text = bill.RemainingAmount + "";
        }

        private void tbDiscount_Validating(object sender, CancelEventArgs e)
        {
            if (tbTotalPrice.Text != "" && tbTotalPrice.Text != "0")
            {
                if (Convert.ToDouble(tbPayment.Text) > Convert.ToDouble(tbTotalPrice.Text))
                {
                    RemainingAmoungIfBigger = Convert.ToDouble(tbPayment.Text);
                }
            }
            //double sum = calcSum();
            //billMaster.TotalPrice = sum;
            ////var bill = (EditBindingSource.Current as BillMaster);
            ////billMaster.TotalPrice = 
            //billMaster.payment= billMaster.TotalPrice - double.Parse(tbDiscount.Text);
            //billMaster.Discount = double.Parse(tbDiscount.Text);
            //if (this.cbPaymentMethod.SelectedIndex == 0)
            //{
            //    billMaster.payment = billMaster.TotalPrice-billMaster.Discount;
            //    billMaster.RemainingAmount = 0;
            //}
            //else
            //{
            //    //billMaster.payment = 0.0;
            //    billMaster.RemainingAmount = billMaster.TotalPrice - billMaster.payment;
            //}
            //tbPayment.Text = billMaster.Payment + "";
            //tbRemainingAmount.Text ="0";

            //double tot = calcSum();
            //double dis = tbDiscount.Text == "" ? 0.0 : double.Parse(tbDiscount.Text);
            //double per = (dis / tot) * 100;
            //tbDiscount.Text = per.ToString();

            double sum = calcSum();
            billMaster.TotalPrice = sum;

            var bill = (EditBindingSource.Current as BillMaster);
            if (billMaster.paymentMethod == PaymentMethod.Cash)
            {
                billMaster.payment = billMaster.TotalPrice - double.Parse(tbDiscount.Text);
            }
            else
            {
                if (billMaster.payment == 0)
                    billMaster.payment = 0;
            }
            if (this.cbPaymentMethod.SelectedIndex == 0)
            {
                billMaster.payment = billMaster.TotalPrice - billMaster.discount;
                billMaster.RemainingAmount = 0;
            }
            else
            {
                billMaster.RemainingAmount = billMaster.TotalPrice - billMaster.payment;
            }
            tbPayment.Text = bill.Payment + "";
            tbRemainingAmount.Text = billMaster.RemainingAmount + "";
        }
        private void tbDiscount_MouseDown(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbDiscount.Text))
            {
                tbDiscount.SelectionStart = 0;
                tbDiscount.SelectionLength = tbDiscount.Text.Length;
            }
        }

        private void dgDetail_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if ((EditBindingSource.DataSource as BillMaster) != null)
            {
                CancelEventArgs ee = new CancelEventArgs();
                tbDiscount_Validating(sender, ee);
                billMaster.CalcTotalMobile();
                tbPayment.Text = billMaster.Payment + "";
                tbDiscount.Text = billMaster.Discount + "";
                tbRemainingAmount.Text = billMaster.RemainingAmount + "";
            }
        }

        private void miEditArticleInfo_Click(object sender, EventArgs e)
        {
            var currentRow = (DetailBindingSource.Current as BillDetail);
            if (currentRow != null)
            {
                var art = DescriptionFK.ArticaleExists(false, "", currentRow.ArticaleId);
                if (art != null)
                {
                    ArticaleEditForm edForm = new ArticaleEditForm(art, FormOperation.Pick);
                    edForm.ShowDialog();
                    edForm.Dispose();
                    currentRow.Barcode = art.Barcode;
                    dgDetail.Refresh();
                }
            }
            else
            {
                _MessageBoxDialog.Show("يوجد خطأ في تحديد الصنف", MessageBoxState.Error);
            }
        }
        public Control FindFocusedControl(Control control)
        {
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }
        private void dgDetail_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (ActiveControl == null || !ActiveControl.Name.Contains("dgDetail"))
            {
                return;
            }
            if (dgDetail.CurrentRow.DataBoundItem == null)
                return;
            try
            {
                string artVal = dgDetail.Rows[e.RowIndex].Cells["ArticaleIdDescr"].Value.ToString().Trim();
                Article result = DescriptionFK.ArticaleExists(artVal);
                if (result == null)
                {

                    _MessageBoxDialog.Show("يجب وضع مادة", MessageBoxState.Warning);
                    e.Cancel = true;
                    SetFocus();

                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ في الادخال يرجى اعادة المحاولة", MessageBoxState.Error);
            }
        }

        private void dgDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbPayment.Focus();
                tbPayment.Select();
            }
        }

        private void tbPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pOk_Click(sender, e);
            }
        }
        private void DgDetail_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetail.CurrentRow.DataBoundItem == null)
                return;
            CancelEventArgs ee = new CancelEventArgs();
            //object sender = new object();
            tbDiscount_Validating(sender, ee);
            tbPayment_Validating(sender, ee);
            billMaster.CalcTotalMobile();
            InitEntity_onUpdateForm();
        }

        private void LbDeleteBill_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (((UserLoggedIn.User.UserPermissions.CanDeleteBill) || ((int)UserLoggedIn.User.Position <= (int)Position.manager)))
            {
                InputForm.OpenInputNumber(ShefaaForms.DeleteBill, "حذف فاتورة مبيع");
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }

        }

        private void LbReturnBill_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(new BillMaster(), InvoiceKind.Sell, FormOperation.ReturnEmpty);
            generalInvoiceEditForm.Show();
        }

        private void MiChoosePriceTag_Click(object sender, EventArgs e)
        {
            var currentRow = (DetailBindingSource.Current as BillDetail);
            if (currentRow != null)
            {
                var pricetag = PriceTagPickForm.PickPriceTag(InventoryService.GetArticleAmountRemaning(currentRow.ArticaleId), currentRow.ArticaleId, FormOperation.Pick);
                if (pricetag == null)
                {
                    return;
                }
                currentRow.PriceTagId = pricetag.PriceTagId;
            }
            else
            {
                _MessageBoxDialog.Show("يوجد خطأ في تحديد السطر", MessageBoxState.Error);
            }
        }

        private void tbPayment_TextChanged(object sender, EventArgs e)
        {
            billMaster.payment = tbPayment.Text == "" ? 0 : double.Parse(tbPayment.Text);
            billMaster.RemainingAmount = billMaster.TotalPrice - billMaster.payment - billMaster.discount;
        }

        private void AllBills_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Auth.IsReportReader())
            {

                InvoicDayPickForm invoicDayPickForm = new InvoicDayPickForm(null);
                invoicDayPickForm.ShowDialog();

            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }

        private void dtCreationDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = this.dtCreationDate.Value;
            billMaster.CreationDate = date;
            //this.dtCreationDate.Text = date.ToString("yyyy-mm-dd");
        }


        private void tbDiscount_TextChanged(object sender, EventArgs e)
        {
            //if (radioButton1.Checked == true)
            //{
            //    double tot = calcSum();
            //    double dis = tbDiscount.Text == "" ? 0.0 : double.Parse(tbDiscount.Text);
            //    double per = (tot * dis) / 100;
            //    tbDiscount.Text = per.ToString();
            //}
            //else
            //{  
            if (billMaster.paymentMethod == PaymentMethod.Debit)
            {
                billMaster.RemainingAmount = billMaster.TotalPrice - billMaster.Payment - (tbDiscount.Text == "" ? 0 : double.Parse(tbDiscount.Text));
                //tbRemainingAmount.Text = billMaster.RemainingAmount.ToString();
            }

            //double tot = calcSum();
            //double dis = tbDiscount.Text == "" ? 0.0 : double.Parse(tbDiscount.Text);
            ////double per = (dis / tot) * 100;
            //tbDiscount.Text = billMaster.discount.ToString();

            ////}
            //double sum = calcSum();
            //billMaster.TotalPrice = sum;
            //if (tbDiscount.Text == "")
            //{
            //    return;
            //}
            //var bill = (EditBindingSource.Current as BillMaster);
            //billMaster.TotalPrice = billMaster.TotalPrice - double.Parse(tbDiscount.Text);
            //if (this.cbPaymentMethod.SelectedIndex == 0)
            //{
            //    billMaster.payment = billMaster.TotalPrice;
            //    billMaster.RemainingAmount = 0;
            //}
            //else
            //{
            //    // billMaster.payment = 0.0;
            //    billMaster.RemainingAmount = billMaster.TotalPrice - billMaster.payment;
            //}
            //tbPayment.Text = bill.Payment + "";
            //tbDiscount.Text = bill.Discount + "";
            //tbRemainingAmount.Text = bill.RemainingAmount + "";
        }

        /// <summary>
        /// تعديل فاتورة أو تحديث الصفحة
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pRefresh_Click(object sender, EventArgs e)
        {
            //tbDiscount.Select();
            tbId.Select();
            tbId.Focus();
            CheckLastRow();
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {

                EditBindingSource.AddNew();
                LastThreeOperation();
                SetFocus();

            }
            else
            {
                if (DetailBindingSource.Count < 1)
                {
                    _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Error);
                    return;
                }
                bool res = EditBill();
                if (res)
                {
                    _MessageBoxDialog.Show("تم تعديل الفاتورة", MessageBoxState.Done);
                    Close();
                    LastThreeOperation();
                }
            }

        }

        public void AddArticle(Article article)
        {
            BillDetail currentBillDetail;
            if (dgDetail.Rows.Count > 0 && DetailBindingSource.Current != null)
            {
                currentBillDetail = (DetailBindingSource.Current as BillDetail);
                if (currentBillDetail.ArticaleId != 0)
                {
                    DetailBindingSource.AddNew();
                    dgDetail.Refresh();
                    CheckQuantityOnSell(article);
                    SetFocus();
                }
                else
                {
                    dgDetail.Refresh();
                    CheckQuantityOnSell(article);
                    SetFocus();
                }
            }
        }
    }
}
