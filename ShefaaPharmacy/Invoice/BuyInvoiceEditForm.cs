using DataLayer;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.Articale;
using ShefaaPharmacy.Articles;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Invoice
{
    public partial class BuyInvoiceEditForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        BillMaster billMaster;
        bool EdittedPrice = false;
        bool CheckEditPrice = false;
        List<PurchesBillViewModel> purchesBillViewModels;
        public BuyInvoiceEditForm()
        {
            InitializeComponent();
        }

        private void BuyInvoiceEditForm_Load(object sender, EventArgs e)
        {
            //pHelperButton.Location = new Point(this.Size.Width - 96, 7);
            btnMaximaizing.Enabled = false;
            dgDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.Columns["sellprice"].ReadOnly = true;
            SetFocus();
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
            }
            else if (FormOperation == FormOperation.Edit || FormOperation == FormOperation.EditFromPicker)
            {
                pbOk.Image = Properties.Resources.EditButton;
            }
        }
        private void InitEntity_onUpdateForm()
        {
            MasterBindingSource.ResetCurrentItem();
        }
        public BuyInvoiceEditForm(BillMaster entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            this.billMaster = entity;
            FormOperation = formOperation;
            if (FormOperation == FormOperation.New)
            {
                purchesBillViewModels = new List<PurchesBillViewModel>();
            }
            else if ((this.FormOperation != FormOperation.New))
            {
                if (this.billMaster.BillDetails == null || this.billMaster.BillDetails.Count == 0)
                {
                    this.billMaster.BillDetails = ShefaaPharmacyDbContext.GetCurrentContext().BillDetails
                    .Where(x => x.BillMasterId == this.billMaster.Id).ToList();
                }
                purchesBillViewModels = DescriptionFK.ConvertBillDetailToPurchesBill(this.billMaster.BillDetails.ToList());
            }
            #region Assigned To Binding Source
            billMaster.InvoiceKind = InvoiceKind.Buy;
            MasterBindingSource.DataSource = billMaster;
            DetailBindingSource.DataSource = purchesBillViewModels;
            billMaster.onUpdateForm += InitEntity_onUpdateForm;
            #endregion
            #region Data Grid View Detail
            dgDetail.AutoGenerateColumns = true;
            dgDetail.Columns["ExpiryDate"].Visible = false;
            dgDetail.Columns["BaseUnitIdDescr"].Visible = false;
            dgDetail.Columns["RemainingAmount"].Visible = false;
            dgDetail.Columns["Gift"].Visible = false;
            #endregion
            BindingControl();
            if (formOperation == FormOperation.ReturnArticles)
            {
                this.Text = "فاتورة مرتجع مشتريات";
                billMaster.InvoiceKind = InvoiceKind.ReturnBuy;
            }
            billMaster.CalcTotal();
            ChangeImageButton();
            this.cbPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cbPaymentMethod_SelectedIndexChanged);
            this.tbDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.TbDiscount_Validating);
            this.tbPayment.Validating += new System.ComponentModel.CancelEventHandler(this.TbPayment_Validating);
            tbPayment.Text = billMaster.Payment.ToString();
            tbDiscount.Text = billMaster.Discount.ToString();
            tbRemainingAmount.Text = billMaster.RemainingAmount.ToString();
            if(this.FormOperation == FormOperation.EditFromPicker)
            {
                pbDeleteRow.Enabled = false;
            }
        }
        public void DeleteRow()
        {
            try
            {
                if (dgDetail.Rows.Count > 0 && DetailBindingSource.Current != null)
                {
                    dgDetail.Rows.RemoveAt(dgDetail.CurrentRow.Index);
                    dgDetail.Refresh();

                }
            }
            catch (Exception ex)
            {
                ;
            }
        }
        public void AddRow()
        {
            DetailBindingSource.AddNew();
            SetFocus();
        }
        public void DecreseQuantity()
        {
            if (dgDetail.Rows.Count > 0 && DetailBindingSource.Current != null)
            {
                if ((DetailBindingSource.Current as PurchesBillViewModel).Quantity > 1)
                {
                    (DetailBindingSource.Current as PurchesBillViewModel).Quantity -= 1;
                }
                dgDetail.Refresh();
            }
        }

        public void InecreseQuantity()
        {
            if (dgDetail.Rows.Count > 0 && DetailBindingSource.Current != null)
            {
                (DetailBindingSource.Current as PurchesBillViewModel).Quantity += 1;
                dgDetail.Refresh();
            }
        }

        public void SetFocus(string col = "")
        {
            if (col == "")
            {
                col = "BarcodeDescr";
            }
            if (dgDetail.Rows.Count > 0)
            {
                SetColumnIndex method = new SetColumnIndex(Mymethod);
                dgDetail.BeginInvoke(method, dgDetail.Columns[col].Index);
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
            if (EdittedPrice)
            {
                double total = 0;
                List<PurchesBillViewModel> purchesBillViewModel = DetailBindingSource.DataSource as List<PurchesBillViewModel>;
                purchesBillViewModel.ForEach(x => total += (x.PurchasePrice * x.Quantity));
                billMaster.TotalPrice = total;
                tbTotalPrice.Text = billMaster.TotalPrice.ToString();
                tbPayment.Text = billMaster.Payment.ToString();
            }
        }
        delegate void SetColumnIndex(int i);
        public void BindingEntityToControls()
        {
            tbId.DataBindings.Add("text", MasterBindingSource, "Id", false, DataSourceUpdateMode.OnPropertyChanged);
            dtCreationDate.DataBindings.Add("text", MasterBindingSource, "CreationDate", false, DataSourceUpdateMode.OnPropertyChanged);
            tbAccountIdDescr.DataBindings.Add("text", MasterBindingSource, "AccountIdDescr", false, DataSourceUpdateMode.OnPropertyChanged);

            tbPayment.DataBindings.Add("text", MasterBindingSource, "Payment", true, DataSourceUpdateMode.OnPropertyChanged);
            tbRemainingAmount.DataBindings.Add("text", MasterBindingSource, "RemainingAmount", true, DataSourceUpdateMode.OnPropertyChanged);
            tbTotalPrice.DataBindings.Add("text", MasterBindingSource, "TotalPrice", true, DataSourceUpdateMode.OnPropertyChanged);
            tbDiscount.DataBindings.Add("text", MasterBindingSource, "Discount", true, DataSourceUpdateMode.OnPropertyChanged);
            tbCreatedBy.DataBindings.Add("text", MasterBindingSource, "CreatedBy", false, DataSourceUpdateMode.OnPropertyChanged);

            cbPaymentMethod.DataSource = Enum.GetValues(typeof(PaymentMethod));
            cbPaymentMethod.SelectedIndex = (int)(billMaster).PaymentMethod;

            cbStore.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Stores.ToList();
            cbStore.ValueMember = "Id";
            cbStore.DisplayMember = "Name";
            cbStore.SelectedValue = UserLoggedIn.User.StoreId;

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
        private void BindingControl()
        {
            tbCountPresent.DataBindings.Add("text", DetailBindingSource, "Gift", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N");
            tbCountItem.DataBindings.Add("text", DetailBindingSource, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N");
            tbBaseUnit.DataBindings.Add("text", DetailBindingSource, "RemainingAmount", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N");
            dtExpiryDate.DataBindings.Add("text", DetailBindingSource, "ExpiryDate", true, DataSourceUpdateMode.OnPropertyChanged, 0);
            dtExpiryDate.MinDate = DateTime.Now;
        }
        private void dgDetail_BindingContextChanged(object sender, EventArgs e)
        {
            dgDetail.Refresh();
        }
        private void DetailBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            PurchesBillViewModel purchesBillViewModel = new PurchesBillViewModel();
            purchesBillViewModel.ExpiryDate = DateTime.Now.AddYears(1);
            e.NewObject = purchesBillViewModel;
            SetFocus();
        }

        private void MasterBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            billMaster = new BillMaster();
            billMaster.onUpdateForm += InitEntity_onUpdateForm;
            billMaster.InvoiceKind = InvoiceKind.Buy;
            billMaster.BillDetails = new List<BillDetail>();
            purchesBillViewModels = new List<PurchesBillViewModel>();
            e.NewObject = billMaster;
            dgDetail.DataBindings.Clear();
            DetailBindingSource.Clear();
            DetailBindingSource.DataSource = purchesBillViewModels;
            dgDetail.DataSource = DetailBindingSource;
        }

        private bool SaveNewBill()
        {
            List<BillDetail> _billDetails = new List<BillDetail>();
            foreach (var detail in DetailBindingSource.DataSource as List<PurchesBillViewModel>)
            {
                if (detail.ArticleId == 0 || detail.Quantity == 0)
                {
                    continue;
                }
                _billDetails.Add(new BillDetail()
                {
                    ArticaleId = detail.ArticleId,
                    Barcode = detail.BarcodeDescr,
                    Discount = 0,
                    InvoiceKind = InvoiceKind.Buy,
                    Quantity = detail.Quantity,
                    QuantityGift = detail.Gift,
                    Price = Convert.ToInt32(detail.PurchasePrice),
                    UnitTypeId = detail.UnitId,
                    UnitTypeIdBasic = detail.BaseUnitId,
                    TotalPrice = Convert.ToInt32((detail.Quantity) * detail.PurchasePrice),
                    PriceTag = new PriceTagMaster()
                    {
                        ArticleId = detail.ArticleId,
                        UnitId = InventoryService.GetSmallestArticleUnit(detail.ArticleId),
                        CountGiftItem = InventoryService.ConvertArticleUnitToSmallestUnit(detail.ArticleId, detail.UnitId, detail.Gift),
                        CountSoldItem = 0,
                        CountAllItem = InventoryService.ConvertArticleUnitToSmallestUnit(detail.ArticleId, detail.UnitId, detail.Quantity),
                        BranchId = UserLoggedIn.User.BranchId,
                        ExpiryDate = detail.ExpiryDate,
                        PriceTagDetails = ArticleService.MakeNewPriceTagDetailForArticle(detail),
                    },
                });
            }
            billMaster.BillDetails = _billDetails;
            billMaster.CalcTotal();
            if (Convert.ToInt32(tbPayment.Text) > Convert.ToInt32(tbTotalPrice.Text) && FormOperation != FormOperation.Edit)
            {
                billMaster.payment = Convert.ToInt32(tbPayment.Text);
                billMaster.discount = -1 * (billMaster.payment - billMaster.TotalPrice);
            }
            BillService billService = new BillService(billMaster);
            bool result = billService.BuyBill();
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
            if (billMaster.InvoiceKind == InvoiceKind.ReturnBuy)
            {
                return billService.DeleteBill(InvoiceKind.DeleteReturnBuy);
            }
            return billService.DeleteBill(InvoiceKind.DeleteBuy);
        }

        private bool ReturnBill()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            if(FormOperation == FormOperation.ReturnArticles)
            {
                var newmasterbill = new BillMaster()
                {
                    AccountId = billMaster.AccountId,
                    TotalItem = billMaster.TotalItem,
                    TotalPrice = billMaster.TotalPrice,
                    BranchId = billMaster.BranchId,
                    CreationBy = billMaster.CreationBy,
                    InvoiceKind = InvoiceKind.ReturnBuy,
                    CreationDate = DateTime.Now,
                    Payment = billMaster.Payment,
                    PaymentMethod = billMaster.PaymentMethod,
                    RemainingAmount = billMaster.RemainingAmount,
                    YearId = billMaster.YearId,
                    Discount = billMaster.Discount
                };
                context.BillMasters.Add(newmasterbill);
                context.SaveChanges();
                foreach (var detail in DetailBindingSource.DataSource as List<PurchesBillViewModel>)
                {
                    var newdetailbil = new List<BillDetail>();

                    newdetailbil.Add(new BillDetail(newmasterbill)
                    {
                        ArticaleId = detail.ArticleId,
                        Barcode = detail.Barcode,
                        BillMasterId = newmasterbill.Id,
                        CreationBy = billMaster.CreationBy,
                        CreationDate = DateTime.Now,
                        Discount = billMaster.Discount,
                        InvoiceKind = InvoiceKind.ReturnBuy,
                        Price = detail.PurchasePrice,
                        Quantity = detail.Quantity,
                        TotalPrice = detail.PurchasePrice * detail.Quantity,
                        UnitTypeId = detail.UnitId,
                        PriceTag = new PriceTagMaster()
                        {
                            ArticleId = detail.ArticleId,
                            UnitId = InventoryService.GetSmallestArticleUnit(detail.ArticleId),
                            CountGiftItem = InventoryService.ConvertArticleUnitToSmallestUnit(detail.ArticleId, detail.UnitId, detail.Gift),
                            CountSoldItem = InventoryService.ConvertArticleUnitToSmallestUnit(detail.ArticleId, detail.UnitId, detail.Quantity),
                            CountAllItem = 0,
                            BranchId = UserLoggedIn.User.BranchId,
                            ExpiryDate = detail.ExpiryDate,
                            PriceTagDetails = ArticleService.MakeNewPriceTagDetailForArticle(detail),
                        },
                    });
                    context.BillDetails.AddRange(newdetailbil);
                    context.SaveChanges();
                }
            }
            else
            {
                var CurentGridItems = DetailBindingSource.DataSource as List<PurchesBillViewModel>;

                foreach (var detail in billMaster.BillDetails.ToList())
                {
                    bool has = CurentGridItems.Any(cus => cus.ArticleId == detail.ArticaleId);
                    if (!has)
                    {
                        billMaster.BillDetails.Remove(detail);
                    }
                }
            }

            BillService billService = new BillService(billMaster);
            return billService.ReturnBuyBill(InvoiceKind.ReturnBuy);
        }

        private bool EditBill()
        {
            List<BillDetail> _billDetails = new List<BillDetail>();
            foreach (var detail in DetailBindingSource.DataSource as List<PurchesBillViewModel>)
            {
                if (detail.ArticleId == 0)
                {
                    continue;
                }
                _billDetails.Add(new BillDetail()
                {
                    ArticaleId = detail.ArticleId,
                    Barcode = detail.BarcodeDescr,
                    Discount = 0,
                    InvoiceKind = InvoiceKind.Buy,
                    Quantity = detail.Quantity,
                    QuantityGift = detail.Gift,
                    Price = detail.PurchasePrice,
                    UnitTypeId = detail.UnitId,
                    UnitTypeIdBasic = detail.BaseUnitId,
                    TotalPrice = (detail.Quantity) * detail.PurchasePrice,
                });
            }
            billMaster.BillDetails = _billDetails;
            billMaster.CalcTotal();
            if (Convert.ToInt32(tbPayment.Text) > Convert.ToInt32(tbTotalPrice.Text))
            {
                billMaster.payment = Convert.ToInt32(tbPayment.Text);
                billMaster.discount = -1 * (billMaster.payment - billMaster.TotalPrice);
            }
            BillService billService = new BillService(billMaster);
            return billService.EditBill(DetailBindingSource.DataSource as List<PurchesBillViewModel>);
        }

        private void cbPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            billMaster.PaymentMethod = (PaymentMethod)cbPaymentMethod.SelectedValue;
            billMaster.PaymentMethod = (PaymentMethod)cbPaymentMethod.SelectedValue;
            if ((PaymentMethod)cbPaymentMethod.SelectedValue == PaymentMethod.Debit)
            {

                billMaster.RemainingAmount = billMaster.TotalPrice;
                billMaster.Payment = 0;
                billMaster.Discount = 0;

            }
            else if ((PaymentMethod)cbPaymentMethod.SelectedValue == PaymentMethod.Cash)
            {
                billMaster.RemainingAmount = 0;
                billMaster.Payment = billMaster.TotalPrice - billMaster.Discount; ;
                billMaster.Discount = 0;
            }
            MasterBindingSource.ResetCurrentItem();
        }
        private void dgDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgDetail.CurrentRow.DataBoundItem == null)
                return;
            try
            {
                var cell = dgDetail[e.ColumnIndex, e.RowIndex];
                string cellName = cell.OwningColumn.Name;
                if ((cellName == "BarcodeDescr") && (e.FormattedValue.ToString() != "") && (DetailBindingSource.Current as PurchesBillViewModel).Barcode != e.FormattedValue.ToString())
                {
                    FillWithBarcode(e.FormattedValue.ToString());
                    CheckEditPrice = true;
                }
                else if (cellName == "PurchasePrice" && (e.FormattedValue.ToString() != "") && (DetailBindingSource.Current as PurchesBillViewModel).PurchasePrice != Convert.ToDouble(e.FormattedValue))
                {
                    if (_MessageBoxDialog.Show("هل تريد تثبيت هذا السعر وتعديل بطاقة سعر المادة", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                    {

                        int artId = (DetailBindingSource.Current as PurchesBillViewModel).ArticleId;
                        var context = ShefaaPharmacyDbContext.GetCurrentContext();
                        int pricetagId = context.PriceTagMasters.FirstOrDefault(x => x.ArticleId == artId).Id;
                        NewPriceTag editprice = new NewPriceTag(artId, pricetagId, 0);
                        editprice.UpdatePriceFromBuyInvoice(Convert.ToDouble(e.FormattedValue));
                        PriceTagMaster pricetagmaster = context.PriceTagMasters.FirstOrDefault(x => x.Id == pricetagId);
                        pricetagmaster.PriceTagDetails = context.PriceTagDetails.Where(s => s.PriceTagId == pricetagId).ToList();
                        buy = pricetagmaster.PriceTagDetails.FirstOrDefault().BuyPrice;
                        _MessageBoxDialog.Show("تم تعديل بطاقة السعر", MessageBoxState.Done);
                        billMaster.Payment = 0;
                        CheckEditPrice = true;
                    }
                    else
                    {
                        buy = Convert.ToDouble(e.FormattedValue);
                    }

                }
                else if (cellName == "ArticleIdDescr" && (e.FormattedValue.ToString() != "") && (DetailBindingSource.Current as PurchesBillViewModel).ArticleIdDescr != e.FormattedValue.ToString())
                {
                    FillWithArticleName(e.FormattedValue.ToString());
                    CheckEditPrice = true;
                }
                else if (cellName == "UnitIdDescr" && (e.FormattedValue.ToString() != "") && (DetailBindingSource.Current as PurchesBillViewModel).UnitIdDescr != e.FormattedValue.ToString())
                {
                    ArticleUnits articleUnits = DescriptionFK.ArticleUnitExists((DetailBindingSource.Current as PurchesBillViewModel).ArticleId, e.FormattedValue.ToString());
                    if (articleUnits == null)
                    {
                        e.Cancel = true;
                        _MessageBoxDialog.Show("واحدة غير منتمية لهذا الصنف", MessageBoxState.Error);
                        return;
                    }

                    else ChangeUnitType(e.FormattedValue.ToString());
                }
                else if (cellName == "Quantity")
                {
                    Article CurrentArticle = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Id == (DetailBindingSource.Current as PurchesBillViewModel).ArticleId);
                    int remainingamount = InventoryService.GetAllArticleAmountRemaningInAllPrices(CurrentArticle.Id, (DetailBindingSource.Current as PurchesBillViewModel).UnitId);
                    //int qu = InventoryService.GetAllArticleAmountRemaningInAllPrices((DetailBindingSource.Current as BillDetail).ArticaleId, (DetailBindingSource.Current as BillDetail).UnitTypeId);
                    if (FormOperation == FormOperation.ReturnArticles && Convert.ToDouble(remainingamount) == 0)
                    {
                        _MessageBoxDialog.Show("لايوجد كمية من هذا الصنف", MessageBoxState.Error);
                        e.Cancel = true;
                        return;
                    }
                    else if (this.FormOperation == FormOperation.ReturnArticles && Convert.ToInt32(e.FormattedValue.ToString()) > remainingamount )
                    {
                        string message = " الكمية المطلوبة أكبر من الكمية الموجودة" + "\n" + "علماً أن الكمية الإجمالية المتبقية هي " + remainingamount + "";
                        _MessageBoxDialog.Show(message, MessageBoxState.Error);
                        e.Cancel = true;
                        return;
                    }

                    int LimitUp = CurrentArticle.LimitUp;
                    int LimitDown = CurrentArticle.LimitDown;
                    if (LimitUp != 0 || LimitDown != 0)
                    {
                        if (this.FormOperation != FormOperation.ReturnArticles && FormOperation == FormOperation.Edit || FormOperation == FormOperation.EditFromPicker)
                        {
                            if (int.Parse(e.FormattedValue.ToString()) > LimitUp)
                            {
                                _MessageBoxDialog.Show("بشرائك هذه الكمية ستتجاوز الحد الأعلى للمادة" + "\n" + "الحد الأعلى : " + LimitUp + "", MessageBoxState.Warning);
                            }
                            else if (int.Parse(e.FormattedValue.ToString()) < LimitDown)
                            {
                                _MessageBoxDialog.Show("بشرائك هذه الكمية ستبقى تحت الحد الأدنى للمادة" + "\n" + "الحد الأدنى : " + LimitDown + "", MessageBoxState.Warning);
                            }
                        }
                        else
                        {
                            if (this.FormOperation != FormOperation.ReturnArticles && int.Parse(e.FormattedValue.ToString()) + remainingamount > LimitUp)
                            {
                                _MessageBoxDialog.Show("بشرائك هذه الكمية ستتجاوز الحد الأعلى للمادة" + "\n" + "الحد الأعلى : " + LimitUp + "", MessageBoxState.Warning);
                            }
                            else if (this.FormOperation != FormOperation.ReturnArticles && int.Parse(e.FormattedValue.ToString()) + remainingamount < LimitDown)
                            {
                                _MessageBoxDialog.Show("بشرائك هذه الكمية ستبقى تحت الحد الأدنى للمادة" + "\n" + "الحد الأدنى : " + LimitDown + "", MessageBoxState.Warning);
                            }
                        }
                    }

                    if ((!int.TryParse(e.FormattedValue.ToString(), out int i) || Convert.ToInt32(e.FormattedValue.ToString()) <= 0))
                    {
                        e.Cancel = true;
                        _MessageBoxDialog.Show("يجب إدخال رقم وأكبر من الصفر", MessageBoxState.Error);
                        return;
                    }
                    CheckEditPrice = true;
                }
                if (!CheckEditPrice)
                {
                    billMaster.CalcTotalForPurches(DetailBindingSource.DataSource as List<PurchesBillViewModel>);
                }
                else
                {
                    billMaster.CalcTotalForPurchesWhenUpdatePrice(DetailBindingSource.DataSource as List<PurchesBillViewModel>);
                }
                InitEntity_onUpdateForm();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("يرجى التأكد من صحة البيانات المدخلة ومكانها المناسب", MessageBoxState.Error);

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
            if (headerText.Equals("UnitIdDescr") && (DetailBindingSource.Current as PurchesBillViewModel).ArticleId != 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    var d = UnitTypeService.GetAllUnitForArticle((DetailBindingSource.Current as PurchesBillViewModel).ArticleId);
                    if (d != null)
                    {
                        List<string> data = d.Select(x => x.UnitTypeIdDescr).ToList();
                        AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                        data.ForEach(x => autoCompleteStringCollection.Add(x));
                        tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        tb.AutoCompleteCustomSource = autoCompleteStringCollection;
                    }
                }
            }
            if (headerText.Equals("ArticleIdDescr"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    List<string> data = context.Articles.Where(x => !x.ItsGeneral).Select(x => x.Name).ToList();
                    AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                    data.ForEach(x => autoCompleteStringCollection.Add(x));
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tb.AutoCompleteCustomSource = autoCompleteStringCollection;
                }
            }
        }
        private void CheckLastRow()
        {
            if (dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["PurchasePrice"].Value == null ||
                dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["SellPrice"].Value == null ||
                dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["Quantity"].Value == null)
            {
                return;
            }
            if (Convert.ToDouble(dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["PurchasePrice"].Value) == 0 &&
                Convert.ToDouble(dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["SellPrice"].Value) == 0 &&
                Convert.ToInt32(dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["Quantity"].Value) == 0 &&
                !dgDetail.Rows[dgDetail.Rows.Count - 1].IsNewRow)
            {
                dgDetail.Rows.RemoveAt(dgDetail.Rows.Count - 1);
            }
        }
        /// <summary>
        /// إرجاع فاتورة أو حفظها
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbOk_Click(object sender, EventArgs e)
        {
            pbOk.Select();
            try
            {
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
            CheckLastRow();
            if (DetailBindingSource.Count < 1)
            {
                _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Error);
                return;
            }
            if (billMaster.AccountId == 0)
            {
                _MessageBoxDialog.Show("يجب وضع حساب لإتمام العملية", MessageBoxState.Error);
                return;
            }
            bool res;
            if (FormOperation == FormOperation.New || FormOperation == FormOperation.NewFromPicker)
            {
                res = SaveNewBill();
                if (res)
                {
                    _MessageBoxDialog.Show("تم حفظ الفاتورة", MessageBoxState.Done);
                    MasterBindingSource.AddNew();
                    cbPaymentMethod.SelectedIndex = 0;
                }
            }
            else if (FormOperation == FormOperation.Edit || FormOperation == FormOperation.EditFromPicker)
            {
                res = EditBill();
                if (res)
                {
                    _MessageBoxDialog.Show("تم تعديل الفاتورة", MessageBoxState.Done);
                    Close();
                }
            }
            else if (FormOperation == FormOperation.Delete)
            {
                res = DeleteBill();
                if (res)
                {
                    _MessageBoxDialog.Show("تم حذف الفاتورة", MessageBoxState.Done);
                    Close();
                }
            }
            else if (FormOperation == FormOperation.Return)
            {
                if (billMaster.IsReturned == true)
                {
                    _MessageBoxDialog.Show(" هذه الفاتورة لها فاتورة إرجاع ", MessageBoxState.Error);
                    return;
                }
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
        }

        private void lbAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Account result = AccountPickForm.PickAccount("", new int[1] { ConstantDataBase.AC_Supplier }, null, FormOperation.Pick);
            if (result != null)
            {
                billMaster.AccountId = result.Id;
                billMaster.AccountIdDescr = result.Name;
                tbAccountIdDescr.Text = result.Name;
            }
        }
        int count = 0;
        private void FillWithBarcode(string value)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var articleBarcode = context.Articles.Include(x => x.PriceTagMasters).Where(x => x.Barcode == value).FirstOrDefault();
            if (articleBarcode != null)
            {
                var RemainingAmount = InventoryService.GetQuantityOfArticleAllPriceTag(articleBarcode.Id);
                if (FormOperation == FormOperation.ReturnArticles && Convert.ToDouble(RemainingAmount) == 0)
                {
                    _MessageBoxDialog.Show("لايوجد كمية من هذا الصنف", MessageBoxState.Error);
                    return;
                }
                else
                {
                    FillRow(articleBarcode);
                    count++;
                }
            }
            else
            {
                if (_MessageBoxDialog.Show("باركود غير موجود هل تريد إختيار صنف ؟", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                {
                    Article result = ArticlePicker.PickArticale("", 0, FormOperation.Pick);
                    if (result != null)
                    {
                        var RemainingAmount = InventoryService.GetQuantityOfArticleAllPriceTag(result.Id);
                        if (FormOperation == FormOperation.ReturnArticles && Convert.ToDouble(RemainingAmount) == 0)
                        {
                            _MessageBoxDialog.Show("لايوجد كمية من هذا الصنف", MessageBoxState.Warning);
                            return;
                        }
                        else
                        {
                            FillRow(result);
                            count++;
                        }
                    }
                }
            }
        }
        private void FillWithArticleName(string value)
        {
            Article result = DescriptionFK.ArticaleExists(true, value, 0);
            if (result == null)
            {
                if (_MessageBoxDialog.Show("هل تريد اختيار صنف ؟", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                {
                    result = ArticlePicker.PickArticale("", 0, FormOperation.Pick);
                    if (result != null)
                    {
                        result.PriceTagMasters = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == result.Id).ToList();
                        FillRow(result);
                    }
                }
            }
            else
            {
                FillRow(result);
            }
        }
        private void ChangeBuyPrice(string currentPrice)
        {
            buy = Convert.ToDouble(currentPrice);
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            PriceTagMaster lastPriceTage = context.PriceTagMasters.FirstOrDefault(x => x.ArticleId == (DetailBindingSource.Current as PurchesBillViewModel).ArticleId); /*DescriptionFK.GetLastPriceTagForArt((DetailBindingSource.Current as PurchesBillViewModel).ArticleId);*/
            int quantityOfPrimary = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == (DetailBindingSource.Current as PurchesBillViewModel).ArticleId && x.UnitTypeId == lastPriceTage.UnitId).QuantityForPrimary;
            context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == lastPriceTage.Id).BuyPrice = Convert.ToDouble(currentPrice);
            context.SaveChanges();

        }
        private void ChangePrice(string value)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var lastPriceTage = DescriptionFK.GetLastPriceTagForArt((DetailBindingSource.Current as PurchesBillViewModel).ArticleId);
            var lastSellPrice = UnitTypeService.GetLastSellPrice((DetailBindingSource.Current as PurchesBillViewModel).ArticleId, (DetailBindingSource.Current as PurchesBillViewModel).UnitId);
            if (Convert.ToDouble(value) != lastSellPrice)
            {
                string message = "سعر الصنف في هذه البطاقة " + lastSellPrice + "\n هل تريد إضافة سعر جديد";
                MessageBoxAnswer dialogResult;
                dialogResult = _MessageBoxDialog.Show(message, MessageBoxState.Answering);
                if (dialogResult == MessageBoxAnswer.Yes)
                {
                    context.SaveChanges();
                }
            }
        }

        private void ChangeUnitType(string value)
        {
            PriceTagMaster priceTag = DescriptionFK.PriceTagExists((DetailBindingSource.Current as PurchesBillViewModel).ArticleId);

            double buy2 = 0;
            double sell2 = 0;
            try
            {

                if (priceTag != null)
                {
                    int unitId = DescriptionFK.GetUnitId(value);
                    var currentRow = (DetailBindingSource.Current as PurchesBillViewModel);
                    currentRow.UnitId = unitId;
                    currentRow.UnitIdDescr = value;
                    buy2 = priceTag.PriceTagDetails.FirstOrDefault(x => x.UnitId == unitId).BuyPrice;
                    sell2 = priceTag.PriceTagDetails.FirstOrDefault(x => x.UnitId == unitId).SellPrice;
                    currentRow.PurchasePrice = Convert.ToInt32(buy2);
                    currentRow.SellPrice = Convert.ToInt32(sell2);
                    buy = Convert.ToInt32(buy2);
                    sell = Convert.ToInt32(sell2);
                    CheckEditPrice = true;

                }
                else
                {
                    int unitId = DescriptionFK.GetUnitId(value);
                    (DetailBindingSource.Current as PurchesBillViewModel).UnitId = unitId;
                    (DetailBindingSource.Current as PurchesBillViewModel).UnitIdDescr = value;
                    (DetailBindingSource.Current as PurchesBillViewModel).PurchasePrice = Convert.ToInt32(buy2);
                    (DetailBindingSource.Current as PurchesBillViewModel).SellPrice = Convert.ToInt32(sell2);
                    buy = Convert.ToInt32(buy2);
                    sell = Convert.ToInt32(sell2);
                    CheckEditPrice = true;
                }
            }
            catch
            {
                _MessageBoxDialog.Show("اختيار واحدة غير معرفة لهذه المادة", MessageBoxState.Error);
            }
        }

        double buy, sell;
        private void FillRow(Article articale)
        {
            var lastPriceTage = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                    .Where(x => x.ArticleId == articale.Id)
                    .Include(x => x.PriceTagDetails)
                    .OrderByDescending(x => x.CreationDate)
                    .LastOrDefault();

            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var dataRow = (DetailBindingSource.Current as PurchesBillViewModel);
                if (articale != null)
                {
                    var baseunit = context.ArticleUnits.FirstOrDefault(x => x.IsPrimary && x.ArticleId == articale.Id).UnitTypeId;
                    dataRow.UnitId = baseunit;
                    dataRow.BaseUnitId = dataRow.UnitId;
                    dataRow.UnitIdDescr = DescriptionFK.GetUnitName(dataRow.UnitId);
                    try
                    {
                        var FirstPriceTagToGetPricesOnley = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                            .Where(x => x.ArticleId == articale.Id && x.CountAllItem == 0 && x.CountGiftItem == 0 && x.CountSoldItem == 0)
                            .Include(x => x.PriceTagDetails)
                            .OrderByDescending(x => x.CreationDate)
                            .LastOrDefault();

                        buy = FirstPriceTagToGetPricesOnley.PriceTagDetails.FirstOrDefault(x => x.UnitId == dataRow.UnitId).BuyPrice;
                        sell = FirstPriceTagToGetPricesOnley.PriceTagDetails.FirstOrDefault(x => x.UnitId == dataRow.UnitId).SellPrice;

                        if (dataRow.UnitId != baseunit)
                        {
                            int quantityOfPrimary = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == articale.Id && x.UnitTypeId == dataRow.UnitId).QuantityForPrimary;
                            if (dataRow.UnitId < baseunit)
                            {
                                buy = buy * quantityOfPrimary;
                                sell = sell * quantityOfPrimary;
                            }
                            else if (dataRow.UnitId > baseunit)
                            {
                                buy = Convert.ToInt32(buy / quantityOfPrimary);
                                sell = Convert.ToInt32(sell / quantityOfPrimary);
                            }
                        }
                    }
                    catch { buy = 0; sell = 0; }
                    dataRow.PurchasePrice = buy;
                    dataRow.SellPrice = sell;
                    dataRow.BarcodeDescr = articale.Barcode;
                    dataRow.Barcode = articale.Barcode;

                    dataRow.ArticleId = articale.Id;
                    dataRow.ArticleIdDescr = articale.Name;
                    dataRow.Quantity = 1;
                    dataRow.BarcodeDescr = articale.Barcode;
                    dataRow.Barcode = articale.Barcode;
                    try
                    {
                        HelperUI.ConfigrationComboBox<UnitType>(cbUnitName, UnitArticleService.GetArticleUnits(articale.Id), null, "Name", "Id", FormOperation);
                        cbUnitName.SelectedValue = DescriptionFK.GetPrimaryUnit(articale.Id);
                        dataRow.RemainingAmount = InventoryService.GetAllArticleAmountRemaningInAllPrices(articale.Id, (int)cbUnitName.SelectedValue);
                        if (dataRow.RemainingAmount < 0)
                        {
                            _MessageBoxDialog.Show("هذا الصنف بيع بالسالب", MessageBoxState.Warning);
                        }
                        tbBaseUnit.Text = dataRow.RemainingAmount.ToString();
                    }
                    catch (Exception ex)
                    {
                        ;
                    }
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("هناك خطأ في الإدخال يرجى اعادة العملية", MessageBoxState.Error);

                //_MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }
        private void DetailBindingSource_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DetailBindingSource.Current == null)
                    return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgDetail_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 != 0)
            {
                dgDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 247, 248);
            }
            else
            {
                dgDetail.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void pbDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
            billMaster.CalcTotalForPurchesWhenUpdatePrice(DetailBindingSource.DataSource as List<PurchesBillViewModel>);
            InitEntity_onUpdateForm();
        }

        private void pbAddQuantity_Click(object sender, EventArgs e)
        {
            InecreseQuantity();
        }

        private void pbDecresedQuantity_Click(object sender, EventArgs e)
        {
            DecreseQuantity();
        }

        private void dgDetail_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (ActiveControl == null || !ActiveControl.Name.Contains("dgDetail"))
            {
                return;
            }
            try
            {
                if (dgDetail.CurrentRow.DataBoundItem == null)
                    return;
            }catch(Exception ex)
            {
                return;
            }
            try
            {
                string artVal = dgDetail.Rows[e.RowIndex].Cells["ArticleIdDescr"].Value.ToString().Trim();
                Article result = DescriptionFK.ArticaleExists(artVal);
                if (result == null)
                {
                    _MessageBoxDialog.Show("يجب وضع مادة", MessageBoxState.Warning);
                    dgDetail.Rows[e.RowIndex].Cells["ArticleIdDescr"].Value = "";
                    e.Cancel = true;
                    SetFocus("ArticleIdDescr");
                }
                if (buy != 0 && sell != 0)
                {
                    dgDetail.Rows[e.RowIndex].Cells["SellPrice"].Value = sell;
                    dgDetail.Rows[e.RowIndex].Cells["PurchasePrice"].Value = buy;
                    SetFocus();
                }
                if (Convert.ToDouble(dgDetail.Rows[e.RowIndex].Cells["SellPrice"].Value.ToString()) <= 0 && dgDetail.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    _MessageBoxDialog.Show("يجب وضع سعر مبيع", MessageBoxState.Warning);
                    dgDetail.Rows[e.RowIndex].Cells["SellPrice"].Value = sell;
                    e.Cancel = true;
                    SetFocus("SellPrice");
                    return;
                }
                if (Convert.ToDouble(dgDetail.Rows[e.RowIndex].Cells["PurchasePrice"].Value.ToString()) <= 0 && dgDetail.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    _MessageBoxDialog.Show("يجب وضع سعر شراء", MessageBoxState.Warning);
                    dgDetail.Rows[e.RowIndex].Cells["PurchasePrice"].Value = buy;
                    e.Cancel = true;
                    SetFocus("PurchasePrice");
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("هناك خطأ في الإدخال يرجى اعادة العملية", MessageBoxState.Error);

                //_MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void miArticleQuantity_Click(object sender, EventArgs e)
        {
            var currentRow = (DetailBindingSource.Current as PurchesBillViewModel);
            if (currentRow != null)
            {
                ArticleDetailReportForm articleDetailReportForm = new ArticleDetailReportForm(new UserParameters() { ArticleId = (DetailBindingSource.Current as PurchesBillViewModel).ArticleId });
                articleDetailReportForm.ShowDialog();
            }
        }

        private void dgDetail_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Items["miArticleQuantity"].Visible = true;
                contextMenuStrip1.Items["miAccountFainancial"].Visible = false;
                contextMenuStrip1.Items["miEditArticleInfo"].Visible = true;
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void miEditArticleInfo_Click(object sender, EventArgs e)
        {
            var currentRow = (DetailBindingSource.Current as PurchesBillViewModel);
            if (currentRow != null)
            {
                var art = DescriptionFK.ArticaleExists(false, "", currentRow.ArticleId);
                if (art != null)
                {
                    ArticaleEditForm edForm = new ArticaleEditForm(art, FormOperation.EditFromPicker);
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

        private void tbAccountIdDescr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Items["miArticleQuantity"].Visible = false;
                contextMenuStrip1.Items["miEditArticleInfo"].Visible = false;
                contextMenuStrip1.Items["miAccountFainancial"].Visible = true;
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void miAccountFainancial_Click(object sender, EventArgs e)
        {
            var currentRow = billMaster;
            if (currentRow != null)
            {
                AccountFainancialReportForm accountFainancialReportForm = new AccountFainancialReportForm(new UserParameters() { Acc_AccountId = billMaster.AccountId });
                accountFainancialReportForm.ShowDialog();
            }
        }
        public void MyValidate()
        {
            if (String.IsNullOrEmpty(tbDiscount.Text) || Convert.ToDouble(tbDiscount.Text) == 0)
            {
                return;
            }
            if (billMaster.PaymentMethod == PaymentMethod.Cash)
            {
                billMaster.Payment = billMaster.TotalPrice - Convert.ToInt32(tbDiscount.Text);
                billMaster.RemainingAmount = 0;
            }
            else
            {
                billMaster.RemainingAmount = billMaster.TotalPrice - Convert.ToInt32(tbDiscount.Text);
                billMaster.Payment = 0;
            }
            tbPayment.Text = billMaster.Payment + "";
            tbDiscount.Text = billMaster.Discount + "";
            tbRemainingAmount.Text = billMaster.RemainingAmount + "";
        }
        public void MySecondValidate()
        {
            if (tbPayment.Text == "" || Convert.ToDouble(tbPayment.Text) == 0)
            {
                return;
            }
            if (String.IsNullOrEmpty(tbPayment.Text) || String.IsNullOrWhiteSpace(tbPayment.Text))
            {
                if (billMaster.PaymentMethod == PaymentMethod.Cash)
                {
                    _MessageBoxDialog.Show("لا يمكن أن يكون حقل القيمة المدفوعة فارغا في حالة النقدي", MessageBoxState.Warning);
                    return;
                }
            }
            else
            {
                if (billMaster.Discount == 0)
                {
                    if ((int)cbPaymentMethod.SelectedValue == (int)PaymentMethod.Cash)
                    {
                        if (Convert.ToDouble((billMaster.TotalPrice - (Convert.ToDouble(tbPayment.Text))) / billMaster.TotalPrice * 100) / 100 > ShefaaPharmacyDbContext.GetCurrentContext().DataBaseConfigurations.FirstOrDefault().DiscountPercentage
                       && Auth.DataEntryAndDown())
                        {
                            _MessageBoxDialog.Show("ليس من صلاحياتك الخصم بهذه القيمة", MessageBoxState.Warning);
                            if (billMaster.PaymentMethod == PaymentMethod.Cash)
                            {
                                billMaster.Payment = billMaster.TotalPrice;
                                billMaster.Discount = 0;
                                billMaster.RemainingAmount = 0;
                            }
                            else
                            {
                                billMaster.RemainingAmount = billMaster.TotalPrice;
                                billMaster.Discount = 0;
                                billMaster.Payment = 0;
                            }
                        }
                        else
                        {
                            billMaster.Discount = Convert.ToDouble(tbDiscount.Text);
                            billMaster.RemainingAmount = 0;
                        }
                    }
                    else
                    {
                        billMaster.RemainingAmount = billMaster.TotalPrice - (Convert.ToDouble(tbPayment.Text));
                    }
                }
                else
                {
                    if ((int)cbPaymentMethod.SelectedValue == (int)PaymentMethod.Cash)
                    {
                        if (((billMaster.TotalPrice - (Convert.ToDouble(tbPayment.Text))) / billMaster.TotalPrice * 100) / 100 > ShefaaPharmacyDbContext.GetCurrentContext().DataBaseConfigurations.FirstOrDefault().DiscountPercentage
                       && Auth.DataEntryAndDown())
                        {
                            _MessageBoxDialog.Show("ليس من صلاحياتك الخصم بهذه القيمة", MessageBoxState.Warning);
                            if (billMaster.PaymentMethod == PaymentMethod.Cash)
                            {
                                billMaster.Payment = billMaster.TotalPrice;
                                tbPayment.Text = billMaster.Payment + "";
                                billMaster.Discount = 0;
                                billMaster.RemainingAmount = 0;
                            }
                            else
                            {
                                billMaster.RemainingAmount = billMaster.TotalPrice;
                                billMaster.Discount = 0;
                                billMaster.Payment = 0;
                            }
                        }
                        else
                        {
                            billMaster.Discount = 0;
                            billMaster.Discount = Convert.ToDouble(tbDiscount.Text);
                            billMaster.RemainingAmount = 0;
                        }
                    }
                    else
                    {
                        billMaster.RemainingAmount = billMaster.TotalPrice - (Convert.ToDouble(tbPayment.Text));
                    }
                }
                tbPayment.Text = billMaster.Payment + "";
                tbDiscount.Text = billMaster.Discount + "";
                tbRemainingAmount.Text = billMaster.RemainingAmount + "";
            }
        }
        private void TbDiscount_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(tbDiscount.Text) || Convert.ToDouble(tbDiscount.Text) == 0)
            {
                return;
            }
            if (billMaster.PaymentMethod == PaymentMethod.Cash)
            {
                billMaster.Payment = billMaster.TotalPrice - Convert.ToInt32(tbDiscount.Text);
                billMaster.RemainingAmount = 0;
            }
            else
            {
                billMaster.RemainingAmount = billMaster.TotalPrice - billMaster.payment - Convert.ToInt32(tbDiscount.Text);
            }
            tbPayment.Text = billMaster.Payment + "";
            tbDiscount.Text = billMaster.Discount + "";
            tbRemainingAmount.Text = billMaster.RemainingAmount + "";
            if (FormOperation == FormOperation.EditFromPicker && billMaster.PaymentMethod == PaymentMethod.Cash)
            {
                billMaster.Payment = billMaster.TotalPrice;
                tbPayment.Text = billMaster.Payment.ToString();
            }
        }

        private void TbPayment_Validating(object sender, CancelEventArgs e)
        {
            if (tbPayment.Text == "" || Convert.ToDouble(tbPayment.Text) == 0)
            {
                return;
            }
            if (String.IsNullOrEmpty(tbPayment.Text) || String.IsNullOrWhiteSpace(tbPayment.Text))
            {
                if (billMaster.PaymentMethod == PaymentMethod.Cash)
                {
                    _MessageBoxDialog.Show("لا يمكن أن يكون حقل القيمة المدفوعة فارغا في حالة النقدي", MessageBoxState.Warning);
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                if (billMaster.Discount == 0)
                {
                    if ((int)cbPaymentMethod.SelectedValue == (int)PaymentMethod.Cash)
                    {
                        if (Convert.ToDouble((billMaster.TotalPrice - (Convert.ToDouble(tbPayment.Text))) / billMaster.TotalPrice * 100) / 100 > ShefaaPharmacyDbContext.GetCurrentContext().DataBaseConfigurations.FirstOrDefault().DiscountPercentage
                       && Auth.DataEntryAndDown())
                        {
                            _MessageBoxDialog.Show("ليس من صلاحياتك الخصم بهذه القيمة", MessageBoxState.Warning);
                            if (billMaster.PaymentMethod == PaymentMethod.Cash)
                            {
                                billMaster.Payment = billMaster.TotalPrice;
                                billMaster.Discount = 0;
                                billMaster.RemainingAmount = 0;
                            }
                            else
                            {
                                billMaster.RemainingAmount = billMaster.TotalPrice;
                                billMaster.Discount = 0;
                                billMaster.Payment = 0;
                            }
                        }
                        else
                        {
                            billMaster.Discount = Convert.ToDouble(tbDiscount.Text);
                            billMaster.RemainingAmount = 0;
                        }
                    }
                    else
                    {
                        billMaster.RemainingAmount = billMaster.TotalPrice - (Convert.ToDouble(tbPayment.Text));
                    }
                }
                else
                {
                    if ((int)cbPaymentMethod.SelectedValue == (int)PaymentMethod.Cash)
                    {
                        if (((billMaster.TotalPrice - (Convert.ToDouble(tbPayment.Text))) / billMaster.TotalPrice * 100) / 100 > ShefaaPharmacyDbContext.GetCurrentContext().DataBaseConfigurations.FirstOrDefault().DiscountPercentage
                       && Auth.DataEntryAndDown())
                        {
                            _MessageBoxDialog.Show("ليس من صلاحياتك الخصم بهذه القيمة", MessageBoxState.Warning);
                            if (billMaster.PaymentMethod == PaymentMethod.Cash)
                            {
                                billMaster.Payment = billMaster.TotalPrice;
                                tbPayment.Text = billMaster.Payment + "";
                                billMaster.Discount = 0;
                                billMaster.RemainingAmount = 0;
                            }
                            else
                            {
                                billMaster.RemainingAmount = billMaster.TotalPrice;
                                billMaster.Discount = 0;
                                billMaster.Payment = 0;
                            }
                        }
                        else
                        {
                            billMaster.Discount = 0;
                            billMaster.Discount = Convert.ToDouble(tbDiscount.Text);
                            billMaster.RemainingAmount = 0;
                        }
                    }
                    else
                    {
                        billMaster.RemainingAmount = billMaster.TotalPrice - Convert.ToDouble(tbPayment.Text) - Convert.ToInt32(tbDiscount.Text);
                    }
                }
                tbPayment.Text = billMaster.Payment + "";
                tbDiscount.Text = billMaster.Discount + "";
                tbRemainingAmount.Text = billMaster.RemainingAmount + "";
                if (FormOperation == FormOperation.EditFromPicker && billMaster.PaymentMethod == PaymentMethod.Cash)
                {
                    billMaster.Payment = billMaster.TotalPrice;
                    tbPayment.Text = billMaster.Payment.ToString();
                }
            }
        }

        private void DgDetail_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetail.CurrentRow.DataBoundItem == null)
                return;
            if (!CheckEditPrice)
                billMaster.CalcTotalForPurches(DetailBindingSource.DataSource as List<PurchesBillViewModel>);
            else
                billMaster.CalcTotalForPurchesWhenUpdatePrice(DetailBindingSource.DataSource as List<PurchesBillViewModel>);
            if (EdittedPrice == true)
            {
                double total = 0;
                List<PurchesBillViewModel> purchesBillViewModel = DetailBindingSource.DataSource as List<PurchesBillViewModel>;
                purchesBillViewModel.ForEach(x => total += (x.PurchasePrice * x.Quantity));
                if (FormOperation == FormOperation.EditFromPicker)
                {
                    billMaster.Payment = billMaster.TotalPrice;
                    tbPayment.Text = billMaster.Payment.ToString();
                }
                tbPayment.Text = billMaster.Payment.ToString();
            }
            //if(dgDetail.CurrentRow.Cells["Quantity"].Value>)
            InitEntity_onUpdateForm();
        }

        private void CbUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbUnitName.SelectedValue != null)
                {
                    var currentRow = (DetailBindingSource.Current as PurchesBillViewModel);
                    if (currentRow == null)
                        return;
                    currentRow.RemainingAmount = InventoryService.GetAllArticleAmountRemaningInAllPrices(currentRow.ArticleId, (int)cbUnitName.SelectedValue);
                    tbBaseUnit.Text = currentRow.RemainingAmount.ToString();
                }
            }
            catch (Exception)
            {
                ;
            }
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

        private void dgDetail_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtCreationDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = this.dtCreationDate.Value;
            billMaster.CreationDate = date;
        }

        private void tbPayment_TextChanged(object sender, EventArgs e)
        {

        }

        private void MiAddArticleUnit_Click(object sender, EventArgs e)
        {
            var currentRow = (DetailBindingSource.Current as PurchesBillViewModel);
            if (currentRow != null)
            {
                ArticleUnitsEditForm articleUnitsEditForm = new ArticleUnitsEditForm(new ArticleUnits() { ArticleId = currentRow.ArticleId });
                articleUnitsEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("يوجد خطأ في تحديد الصنف", MessageBoxState.Error);
            }
        }
    }
}
