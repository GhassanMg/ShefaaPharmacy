using DataLayer;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using MetroFramework.Forms;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.Articles;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ShefaaPharmacy
{
    public partial class FirstDurationEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        public List<BalanceFirstDurationViewModel> _BalanceFirstDurationViewModels { get; set; }
        public List<SupplierDepthViewModel> _SupplierDepthViewModels { get; set; }
        public List<CustomerDepthViewModel> _CustomerDepthViewModels { get; set; }
        public List<BankDepthViewModel> _BankCashViewModel { get; set; }
        public List<ExistStuffViewModel> _ExistStuffViewModel { get; set; }
        public List<ExistStuffViewModel> _AllExistStuffViewModel { get; set; }
        public List<FirstTimeArticles> _FirstTimeArticles { get; set; }
        public List<CustomerDepthViewModel> _AllCustomerModel { get; set; }
        public List<SupplierDepthViewModel> _AllSupplierModels { get; set; }
        public List<FullPriceViewModel> _TotalPriceForAll { get; set; }

        public int AccountProfitId = 18;
        public int AccountAssetId = 19;
        public int AccountCashId = 12;
        public int AccountCustomerId { get; set; }
        public int AccountSupplierId { get; set; }
        public double TotalPrice { get; set; }
        List<int> mydepitIds = new List<int>();

        string CurrDate;

        public FirstDurationEditForm()
        {
            InitializeComponent();
        }

        private void TryFirstDuration_Load(object sender, EventArgs e)
        {
            LoadGrid();
            ChangeStyleOfGrid(dgvArticles);
            ChangeStyleOfGrid(dgvSuplier);
            ChangeStyleOfGrid(dgvCustomer);
            ChangeStyleOfGrid(dgvAll);
            ChangeStyleOfGrid(dgvBankCash);
            ChangeStyleOfGrid(ExistStuffdatagrid);
            ChangeStyleOfGrid(dgvAllStuff);
            ChangeStyleOfGrid(dgvAllCustomers);
            ChangeStyleOfGrid(dgvAllSuppliers);
            ChangeStyleOfGrid(dgvTotalPrice);
            dgvArticles.Columns["Total"].ReadOnly = true;

            dgvArticles.Visible = true;
        }
        private void LoadGrid()
        {
            if (_BalanceFirstDurationViewModels == null)
            {
                _BalanceFirstDurationViewModels = new List<BalanceFirstDurationViewModel>();
            }
            if (_SupplierDepthViewModels == null)
            {
                _SupplierDepthViewModels = new List<SupplierDepthViewModel>();
            }
            if (_CustomerDepthViewModels == null)
            {
                _CustomerDepthViewModels = new List<CustomerDepthViewModel>();
            }
            if (_ExistStuffViewModel == null)
            {
                _ExistStuffViewModel = new List<ExistStuffViewModel>();//الموجودات الثابتة
            }
            if (_AllExistStuffViewModel == null)
            {
                _AllExistStuffViewModel = new List<ExistStuffViewModel>();//جميع الموجودات المضافة سابقاً
            }
            if (_FirstTimeArticles == null)
            {
                _FirstTimeArticles = new List<FirstTimeArticles>();//مواد أول المدة
            }
            if (_BankCashViewModel == null)
            {
                _BankCashViewModel = new List<BankDepthViewModel>();//رصيد الصندوق
            }
            if (_AllCustomerModel == null)
            {
                _AllCustomerModel = new List<CustomerDepthViewModel>();//عرض ديون الزبائن
            }
            if (_AllSupplierModels == null)
            {
                _AllSupplierModels = new List<SupplierDepthViewModel>();
            }
            if (_TotalPriceForAll == null)
            {
                _TotalPriceForAll = new List<FullPriceViewModel>();
            }
            EditBindingSource.DataSource = _BalanceFirstDurationViewModels;
            dgvArticles.DataSource = EditBindingSource;

            SupplierBindingSource.DataSource = _SupplierDepthViewModels;
            dgvSuplier.DataSource = SupplierBindingSource;

            CustomerBindingSource.DataSource = _CustomerDepthViewModels;
            dgvCustomer.DataSource = CustomerBindingSource;

            BankCashBindingSource.DataSource = _BankCashViewModel;
            dgvBankCash.DataSource = BankCashBindingSource;

            ExistStuffBindingSource.DataSource = _ExistStuffViewModel;
            ExistStuffdatagrid.DataSource = ExistStuffBindingSource;

            AllStuffbindingSource.DataSource = _AllExistStuffViewModel;
            dgvAllStuff.DataSource = AllStuffbindingSource;

            FirstTimeBindingSource.DataSource = _FirstTimeArticles;
            dgvAll.DataSource = FirstTimeBindingSource;

            AllCustomerBindingSource.DataSource = _AllCustomerModel;
            dgvAllCustomers.DataSource = AllCustomerBindingSource;

            AllSuppliersBindingSource.DataSource = _AllSupplierModels;
            dgvAllSuppliers.DataSource = AllSuppliersBindingSource;

            TotalPricebindingSource.DataSource = _TotalPriceForAll;
            dgvTotalPrice.DataSource = TotalPricebindingSource;

            panelAdd.Visible = true;
            lblAdd.Text = "إضافة موجودات";
            LoadAllExisitStuff();
        }
        private void Loaddgarticale()
        {
            //if (_BalanceFirstDurationViewModels == null)
            //{
                _BalanceFirstDurationViewModels = new List<BalanceFirstDurationViewModel>();
            //}
            ChangeStyleOfGrid(dgvArticles);
            dgvArticles.Columns["Total"].ReadOnly = true;
            EditBindingSource.DataSource = _BalanceFirstDurationViewModels;
            dgvArticles.DataSource = EditBindingSource;
        }
        private void LoadTotalPrice()
        {
            FullPriceViewModel FullPrice = new FullPriceViewModel();

            foreach (DataRowView myrow in FirstTimeBindingSource)
            {
                FullPrice.FullPrice += Convert.ToInt32(myrow.Row.ItemArray[4]);
            }
            TotalPricebindingSource.DataSource = FullPrice;
            dgvTotalPrice.Refresh();
        }
        private void LoadDgvCustomer()
        {
            //if (_CustomerDepthViewModels == null)
            //{
                _CustomerDepthViewModels = new List<CustomerDepthViewModel>();
            //}
            ChangeStyleOfGrid(dgvCustomer);
            CustomerBindingSource.DataSource = _CustomerDepthViewModels;
            dgvCustomer.DataSource = CustomerBindingSource;

        }
        private void LoadDgvSupplier()
        {
            //if (_SupplierDepthViewModels == null)
            //{
                _SupplierDepthViewModels = new List<SupplierDepthViewModel>();
            //}
            ChangeStyleOfGrid(dgvSuplier);
            SupplierBindingSource.DataSource = _SupplierDepthViewModels;
            dgvSuplier.DataSource = SupplierBindingSource;
            dgvSuplier.Refresh();
        }
        void ChangeStyleOfGrid(DataGridView dataGridView)
        {
            dataGridView.Refresh();
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dataGridView.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void CheckLastRowForFirstTimeStuff()
        {
            if ( ExistStuffdatagrid.Rows[ExistStuffdatagrid.Rows.Count - 1].Cells["price"].Value == null ||
               ExistStuffdatagrid.Rows[ExistStuffdatagrid.Rows.Count - 1].Cells["count"].Value == null)
            {
                return;
            }
           else if (Convert.ToInt32(ExistStuffdatagrid.Rows[ExistStuffdatagrid.Rows.Count - 1].Cells["price"].Value) == 0 &&
                Convert.ToInt32(ExistStuffdatagrid.Rows[ExistStuffdatagrid.Rows.Count - 1].Cells["count"].Value) == 0)
           {
                _ExistStuffViewModel.RemoveAt(ExistStuffdatagrid.Rows.Count - 1);
           }
        }
        private void CheckLastRowForBankCash()
        {
            if (dgvBankCash.Rows[dgvBankCash.Rows.Count - 1].Cells[1].Value == null)
            {
                return;
            }
            if (Convert.ToDouble(dgvBankCash.Rows[dgvBankCash.Rows.Count - 1].Cells[1].Value) == 0)
            {
                BankCashBindingSource.RemoveAt(dgvBankCash.Rows.Count - 1);
            }
        }
        private void CheckLastRow()
        {
            if (dgvArticles.Rows[dgvArticles.Rows.Count - 1].Cells["Price"].Value == null ||
                dgvArticles.Rows[dgvArticles.Rows.Count - 1].Cells["ArticleIdDescr"].Value == null ||
                dgvArticles.Rows[dgvArticles.Rows.Count - 1].Cells["Quantity"].Value == null)
            {
                return;
            }
            if (Convert.ToDouble(dgvArticles.Rows[dgvArticles.Rows.Count - 1].Cells["Price"].Value) == 0 &&
                Convert.ToString(dgvArticles.Rows[dgvArticles.Rows.Count - 1].Cells["ArticleIdDescr"].Value) == "" &&
                Convert.ToInt32(dgvArticles.Rows[dgvArticles.Rows.Count - 1].Cells["Quantity"].Value) == 0)
            {
                _BalanceFirstDurationViewModels.RemoveAt(dgvArticles.Rows.Count -1);
            }
        }

        private void CheckLastRowForSupplier()
        {
            if (dgvSuplier.Rows[dgvSuplier.Rows.Count - 1].Cells["AccountIdDescr"].Value == null ||
                dgvSuplier.Rows[dgvSuplier.Rows.Count - 1].Cells["Credit"].Value == null)
            {
                return;
            }
            if (Convert.ToDouble(dgvSuplier.Rows[dgvSuplier.Rows.Count - 1].Cells["Credit"].Value) == 0 &&
                Convert.ToString(dgvSuplier.Rows[dgvSuplier.Rows.Count - 1].Cells["AccountIdDescr"].Value) == "" &&
                Convert.ToInt32(dgvSuplier.Rows[dgvSuplier.Rows.Count - 1].Cells["Credit"].Value) == 0)
            {
                _SupplierDepthViewModels.RemoveAt(dgvSuplier.Rows.Count - 1);
            }
        }
        private void CheckLastRowForCustomer()
        {
            if (dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells["AccountIdDescr"].Value == null ||
                dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells["Debit"].Value == null)
            {
                return;
            }
            if (Convert.ToString(dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells["AccountIdDescr"].Value) == "" &&
                Convert.ToInt32(dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells["Debit"].Value) == 0)
            {
                _CustomerDepthViewModels.RemoveAt(dgvCustomer.Rows.Count - 1);
            }
        }
        private void FirstTimeStuff()
        {
            if (ExistStuffTotal == 0)
            {
                return;
            }
            try
            {
                AccountProfitId = 18;
                AccountAssetId = 21;
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Convert.ToDouble(ExistStuffTotal), Convert.ToDouble(ExistStuffTotal), kindOperation: KindOperation.GoodFirstTime);
                entryMaster.EntryDetails = new List<EntryDetail>();
                entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, 0, Convert.ToDouble(ExistStuffTotal), kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountAssetId, Convert.ToDouble(ExistStuffTotal), 0, kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                context.EntryMasters.Add(entryMaster);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void GoodFirstTime()
        {
            foreach (var detail in EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>)
            {
                if (detail.ArticleId == 0 || detail.Price == 0)
                {
                    continue;
                }
                else
                {
                    if (tbTotalPrice == 0)
                    {
                        return;
                    }
                    try
                    {
                        AccountProfitId = 18;
                        AccountAssetId = 19;
                        ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                        EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Convert.ToDouble(detail.Total), Convert.ToDouble(detail.Total), kindOperation: KindOperation.GoodFirstTime);
                        entryMaster.EntryDetails = new List<EntryDetail>();
                        entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, 0, Convert.ToDouble(detail.Total), kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                        entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountAssetId, Convert.ToDouble(detail.Total), 0, kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                        context.EntryMasters.Add(entryMaster);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        _MessageBoxDialog.Show("حصل خطأ يرجى اعادة العملية", MessageBoxState.Error);
                        //throw ex;
                    }
                }
            }
            
        }
        private void SupplierMoney()
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            try
            {
                foreach (var item in _SupplierDepthViewModels)
                {
                    if (item.Credit > 0)
                    {
                        AccountProfitId = 18;
                        EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Convert.ToDouble(item.Credit), Convert.ToDouble(item.Credit), kindOperation: KindOperation.GoodFirstTime);
                        entryMaster.EntryDetails = new List<EntryDetail>();
                        entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, item.Credit, 0, kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                        entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(item.AccountId, 0, item.Credit, kindOperation: KindOperation.GoodFirstTime, 0, "حساب المورد - رصيد أول مدة"));
                        context.EntryMasters.Add(entryMaster);
                        mydepitIds.Add(entryMaster.Id);
                        context.SaveChanges();
                    }
                }
                if (mydepitIds.Count == 0) { _MessageBoxDialog.Show("لم يتم اختيار حساب أو الحساب غير صالح", MessageBoxState.Warning); }
                else _MessageBoxDialog.Show("تم تخزين ديون الموردين بنجاح", MessageBoxState.Done);
            }
            catch
            {
                _MessageBoxDialog.Show("حصل خطأ يرجى اعادة العملية", MessageBoxState.Error);
            }

        }
        private void CustomerMoney()
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            try
            {
                foreach (var item in _CustomerDepthViewModels)
                {
                    if(item.AccountIdDescr == "")
                    {
                        continue;
                    }
                    if (item.Debit > 0)
                    {
                        AccountProfitId = 18;
                        EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Convert.ToDouble(item.Debit), Convert.ToDouble(item.Debit), kindOperation: KindOperation.GoodFirstTime);
                        entryMaster.EntryDetails = new List<EntryDetail>();
                        entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(item.AccountId, item.Debit, 0, kindOperation: KindOperation.GoodFirstTime, 0, "حساب الزبون - رصيد أول مدة"));
                        entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, 0, item.Debit, kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                        context.EntryMasters.Add(entryMaster);
                        mydepitIds.Add(entryMaster.Id);
                        context.SaveChanges();
                    }
                }
                if(mydepitIds.Count == 0) { _MessageBoxDialog.Show("لم يتم اختيار حساب أو الحساب غير صالح", MessageBoxState.Warning); }
                else _MessageBoxDialog.Show("تم تخزين ديون الزبائن بنجاح", MessageBoxState.Done);
            }
            catch
            {
                _MessageBoxDialog.Show("حصل خطأ يرجى اعادة العملية", MessageBoxState.Error);
            }
            
        }
        private void CashFirstTimeMoney()
        {
            AccountProfitId = 18;
            try
            {
                if (dgvBankCash.Rows.Count < 0||BankCashBindingSource.Current == null)
                {
                    _MessageBoxDialog.Show("لا يمكن ان يكون الرصيد 0", MessageBoxState.Error);
                    BankCashBindingSource.DataSource = new List<BankDepthViewModel>();
                    panelAdd.Visible = true;
                    return;
                }
                double Cash = Convert.ToDouble(dgvBankCash.Rows[0].Cells[1].Value);
                if (HelperUI.CheckDouble(Cash))
                {
                    ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    if (Convert.ToDouble(dgvBankCash.Rows[0].Cells[1].Value) > 0)
                    {
                        EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Cash, Cash, kindOperation: KindOperation.GoodFirstTime);
                        entryMaster.EntryDetails = new List<EntryDetail>();
                        entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountCashId, Cash, 0, kindOperation: KindOperation.GoodFirstTime, 0, "حساب الصندوق - رصيد أول مدة"));
                        entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, 0, Cash, kindOperation: KindOperation.GoodFirstTime, 0, "حساب رأس المال"));
                        context.EntryMasters.Add(entryMaster);
                        context.SaveChanges();

                        _MessageBoxDialog.Show("تم تخزين رصيد الصندوق بنجاح", MessageBoxState.Done);
                        BankCashBindingSource.DataSource = new List<BankDepthViewModel>();
                        panelAdd.Visible = pictureBox1.Visible = lblAdd.Visible  = true;
                        
                    }
                }
            }
            catch (Exception)
            {
                _MessageBoxDialog.Show("حصل خطأ يرجى اعادة العملية", MessageBoxState.Error);

                //throw;
            }
        }

        protected override void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                base.btOk_Click(sender, e);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    if (EditBindingSource.Count < 1)
                    {
                        _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Alert);
                        return;
                    }
                    else if(EditBindingSource.Count == 1 && dgvArticles.CurrentRow.Cells["ArticleIdDescr"].Value.ToString()=="")
                    {
                        _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Alert);
                        return;
                    }
                    foreach (DataGridViewRow item in dgvArticles.Rows)
                    {
                        var x = item.Cells["ArticleIdDescr"].Value.ToString();
                        if (item.Cells["ArticleIdDescr"].Value.ToString() != "")
                        {
                            if (item.Cells["ExpiryDate"].Value.ToString() == "" || DateTime.Parse(item.Cells["ExpiryDate"].Value.ToString()).ToShortDateString() == "01/01/0001" || item.Cells["ExpiryDate"].Value.ToString() == null)
                            {
                                string n = item.Cells["ArticleIdDescr"].Value.ToString();
                                _MessageBoxDialog.Show("لا يمكن أن يكون تاريخ الصلاحية فارغاً", MessageBoxState.Warning);
                                SetFocus("ExpiryDate");
                                return;
                            }
                        }
                    }
                    if (CheckinvalidArticles())
                    {
                        _MessageBoxDialog.Show("لم يتم تحديد مادة أو المادة غير موجودة", MessageBoxState.Alert);
                        return;
                    }
                    if (CheckArticleExist()) 
                    {
                        return;   
                    }
                    CalcTotal();
                    GoodFirstTime();
                    CheckLastRow();
                    InventoryService.UpdateInventory(EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, InvoiceKind.GoodFirstTime);
                    SaveNewFirstTimeArticale(EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>);
                    _MessageBoxDialog.Show("تم تخزين الرصيد بنجاح", MessageBoxState.Done);
                    dgvArticles.Rows.Clear();
                    EditBindingSource.DataSource = new List<BalanceFirstDurationViewModel>();
                    dgvArticles.Refresh();
                    dgvArticles.Visible = false;
                    dgvAll.Visible = true;
                    dgvTotalPrice.Visible = true;

                }
                else if (tabControl1.SelectedTab == tabPage2)
                {
                    
                    if (CustomerBindingSource.Count < 1)
                    {
                        _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Alert);
                        return;
                    }
                    else if (CustomerBindingSource.Count == 1 && dgvCustomer.CurrentRow.Cells["AccountIdDescr"].Value.ToString() == "")
                    {
                        _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Alert);
                        return;
                    }
                    foreach (DataGridViewRow item in dgvCustomer.Rows)
                    {
                        if (dgvCustomer.Rows[item.Index].Cells["AccountIdDescr"].Value.ToString() != "")
                        {
                            if (!DescriptionFK.IsRightAccount(dgvCustomer.Rows[item.Index].Cells["AccountIdDescr"].Value.ToString(), ConstantDataBase.AC_Customer))
                            {
                                _MessageBoxDialog.Show("الحساب " + dgvCustomer.Rows[item.Index].Cells["AccountIdDescr"].Value.ToString() + " ليس من حسابات الزبائن ", MessageBoxState.Error);
                                return;
                            }
                        }
                        
                    }
                    
                    SendKeys.SendWait("{ENTER}");
                    CheckLastRowForCustomer();
                    CustomerMoney();
                    dgvCustomer.Rows.Clear();
                    CustomerBindingSource.DataSource = new List<CustomerDepthViewModel>();
                    dgvCustomer.Refresh();
                    dgvCustomer.Visible = false;
                    dgvAllCustomers.Visible = true;
                    LoadAllCustomerDepits();
                }
                else if (tabControl1.SelectedTab == tabPage3)
                {
                    if (SupplierBindingSource.Count < 1)
                    {
                        _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Alert);
                        return;
                    }
                    else if (SupplierBindingSource.Count == 1 && dgvSuplier.CurrentRow.Cells["AccountIdDescr"].Value.ToString() == "")
                    {
                        _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Alert);
                        return;
                    }
                    foreach (DataGridViewRow item in dgvSuplier.Rows)
                    {
                        if (dgvSuplier.Rows[item.Index].Cells["AccountIdDescr"].Value.ToString() != "")
                        {
                            if (!DescriptionFK.IsRightAccount(dgvSuplier.Rows[item.Index].Cells["AccountIdDescr"].Value.ToString(), ConstantDataBase.AC_Supplier))
                            {
                                _MessageBoxDialog.Show("الحساب " + dgvSuplier.Rows[item.Index].Cells["AccountIdDescr"].Value.ToString() + " ليس من حسابات الموردين ", MessageBoxState.Error);
                                return;
                            }
                        }
                    }
                    
                    SendKeys.SendWait("{ENTER}");
                    CheckLastRowForSupplier();
                    SupplierMoney();
                    dgvSuplier.Rows.Clear();
                    SupplierBindingSource.DataSource = new List<SupplierDepthViewModel>();
                    dgvSuplier.Refresh();
                    dgvSuplier.Visible = false;
                    dgvAllSuppliers.Visible = true;
                    LoadAllSupplierDepits();
                }
                else if (tabControl1.SelectedTab == tabPage4)
                {
                    if (BankCashBindingSource.Count < 1)
                    {
                        _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Alert);
                        return;
                    }
                    CheckLastRowForBankCash();
                    if (isfirst)
                    {
                        CashFirstTimeMoney();
                    }
                    else
                    {
                        var context = ShefaaPharmacyDbContext.GetCurrentContext();
                        EntryMaster CurrentMaster = context.EntryMasters.Where(x => x.Id == bankcashDetail.EntryMasterId).FirstOrDefault();
                        CurrentMaster.TotalCredit = bankcashDetail.Credit;
                        CurrentMaster.TotalDebit = bankcashDetail.Debit;
                        CurrentMaster.EntryDetails = context.EntryDetails.Where(x => x.EntryMasterId == CurrentMaster.Id).ToList();
                        for (int i = 0; i < CurrentMaster.EntryDetails.Count; i++)
                        {
                            if (CurrentMaster.EntryDetails[i].AccountId == 12)
                            {
                                CurrentMaster.EntryDetails[i].Credit = bankcashDetail.Credit;
                                CurrentMaster.EntryDetails[i].Debit = bankcashDetail.Debit;
                            }
                            else/* if(CurrentMaster.EntryDetails[i].AccountId == 18)*/
                            {
                                CurrentMaster.EntryDetails[i].Credit = bankcashDetail.Debit;
                                CurrentMaster.EntryDetails[i].Debit = bankcashDetail.Credit;
                            }
                        }
                        context.SaveChanges();
                        _MessageBoxDialog.Show("تم تعديل رصيد الصندوق بنجاح", MessageBoxState.Done);
                        panelAdd.Visible = true;
                        //pictureBox1.Visible.Enabled = lblDelete.Enabled = true;
                    }

                }
                else if (tabControl1.SelectedTab == tabPage5)
                {
                    SendKeys.SendWait("{ENTER}");
                    if (ExistStuffBindingSource.Count < 1)
                    {
                        _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Alert);
                        return;
                    }
                    else if (ExistStuffBindingSource.Count == 1 && ExistStuffdatagrid.CurrentRow.Cells["Name"].Value==null)
                    {
                        _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Alert);
                        return;
                    }
                    CheckLastRowForFirstTimeStuff();
                    CalcTotalForFirstStuff();
                    FirstTimeStuff();
                    SaveFirstTimeGoods(ExistStuffBindingSource.DataSource as List<ExistStuffViewModel>);
                    ExistStuffdatagrid.Rows.Clear();
                    ExistStuffBindingSource.DataSource = new List<ExistStuffViewModel>();
                    ExistStuffdatagrid.Refresh();
                    ExistStuffdatagrid.Visible = false;
                    dgvAllStuff.Visible = true;
                }

                AccountAssetId = 0;
                AccountProfitId = 0;
                //tbTotalPrice.Text = "";
                TotalPrice = 0;

                if (tabControl1.SelectedTab == tabPage1)
                {
                    LoadFirstArts();
                    Loaddgarticale();
                    LoadTotalPrice();
                }
                if (tabControl1.SelectedTab == tabPage5)
                {
                    LoadAllExisitStuff();
                    LoaddgvAllStuff();
                }
                if (tabControl1.SelectedTab == tabPage4)
                {
                    LoadPharmacyBankCash();
                    dgvBankCash.Columns["AccountIdDescr"].Visible = true;
                    dgvBankCash.Columns["KindOperation"].Visible = true;
                    dgvBankCash.Columns["Debit"].ReadOnly = true;
                    dgvBankCash.AllowUserToAddRows = false;
                }
                pictureBoxDelete.Enabled = lblDelete.Enabled = false;

            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ يرجى اعادة العملية", MessageBoxState.Error);
                pictureBoxDelete.Enabled = lblDelete.Enabled = false;

                return;
            }
        }
        private bool CheckinvalidArticles()
        {
            try
            {
                int validArt = 0;
                foreach (DataGridViewRow row in dgvArticles.Rows)
                {
                    if (row.Cells["ArticleIdDescr"].Value.ToString()!= "")
                    {
                       validArt++;
                    }
                }
                if (validArt == 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                return false;
            }
        }
        private bool Checkinvalid()
        {
            try
            {
                foreach (DataGridViewRow lastrow in dgvCustomer.Rows)
                {
                    foreach (DataGridViewRow row in dgvCustomer.Rows)
                    {
                        if (row.Cells["الصنف"].Value.ToString().Equals(lastrow.Cells["ArticleIdDescr"].Value.ToString()) && row.Cells["تاريخ الصلاحية"].Value.ToString().Equals(lastrow.Cells["ExpiryDate"].Value.ToString()))
                        {
                            _MessageBoxDialog.Show("المادة '" + lastrow.Cells["ArticleIdDescr"].Value.ToString() + "'موجودة سابقاً , يرجى التعديل عليها", MessageBoxState.Warning);
                            dgvCustomer.CurrentCell = dgvCustomer["الصنف", row.Index];

                            dgvCustomer.BeginEdit(true);
                            return true;
                            //This will only pick up the first match not multiple…
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                return false;
            }
        }

        private bool CheckArticleExist()
        {
            try
            {
                foreach (DataGridViewRow lastrow in dgvArticles.Rows)
                {
                    foreach (DataGridViewRow row in dgvAll.Rows)
                    {
                        if (row.Cells["الصنف"].Value.ToString().Equals(lastrow.Cells["ArticleIdDescr"].Value.ToString()) && row.Cells["تاريخ الصلاحية"].Value.ToString().Equals(lastrow.Cells["ExpiryDate"].Value.ToString())) 
                        {
                            _MessageBoxDialog.Show("المادة '" + lastrow.Cells["ArticleIdDescr"].Value.ToString() + "'موجودة سابقاً , يرجى التعديل عليها", MessageBoxState.Warning);
                            dgvAll.CurrentCell = dgvAll["الصنف", row.Index];

                            dgvAll.BeginEdit(true);
                            return true;
                            //This will only pick up the first match not multiple…
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                return true;
            }
        }
        private void LoadAllExisitStuff()
        {
            panelDelete.Visible = true;
            SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select name as المادة,price as السعر,Count as العدد,description as الوصف from ExistStuff order by name asc", con);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            //ds.Tables.Add("Medicines");
            da.Fill(ds, "ExistStuff");
            if (ds.Tables["ExistStuff"].Rows.Count == 0)
            {
                lblNoExistStuff.Visible = true;
            }
            else
            {
                AllStuffbindingSource.DataSource = ds.Tables["ExistStuff"];

                cmd.ExecuteNonQuery();
                dgvAllStuff.Refresh();
                lblNoExistStuff.Visible = false;
            }
        }
        private void LoaddgvAllStuff()
        {
            if (_ExistStuffViewModel == null)
            {
                _ExistStuffViewModel = new List<ExistStuffViewModel>();
            }
            ChangeStyleOfGrid(ExistStuffdatagrid);
            //ExistStuffdatagrid.Columns["Total"].ReadOnly = true;
            ExistStuffBindingSource.DataSource = _ExistStuffViewModel;
            ExistStuffdatagrid.DataSource = ExistStuffBindingSource;
            //dgvAllStuff.Rows.Clear();
            //dgvAllStuff.Refresh();
        }
        private void SaveFirstTimeGoods(List<ExistStuffViewModel> mystaff)
        {
            List<ExistStuffViewModel> newArt = new List<ExistStuffViewModel>();
            SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
            con.Open();
            
            foreach (var item in mystaff)
            {
                if (item.Name == "0" || item.Count == 0 || item.Price == 0)
                {
                    _MessageBoxDialog.Show("لايمكن ادخال قيمة الصفر في حقول (المادة ,العدد ,السعر)", MessageBoxState.Warning);
                    continue;
                }
                newArt.Add(new ExistStuffViewModel
                {
                    Name = item.Name,
                    Price = item.Price,
                    Count=item.Count,
                    Description=item.Description
                });
            }
            con.Close();
            if (newArt.Count > 0)
            {
                InsertStuff(newArt);
                _MessageBoxDialog.Show("تم تخزين الموجودات بنجاح", MessageBoxState.Done);
            }
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        private void InsertStuff(List<ExistStuffViewModel> mylist)
        {
            using (var copy = new SqlBulkCopy(ShefaaPharmacyDbContext.ConStr))
            {
                DataTable dt = new DataTable();
                copy.DestinationTableName = "dbo.ExistStuff";
                // Add mappings so that the column order doesn't matter
                copy.ColumnMappings.Add(nameof(ExistStuffViewModel.Name), "name");
                copy.ColumnMappings.Add(nameof(ExistStuffViewModel.Count), "count");
                copy.ColumnMappings.Add(nameof(ExistStuffViewModel.Price), "price");
                copy.ColumnMappings.Add(nameof(ExistStuffViewModel.Description), "description");

                dt = ToDataTable(mylist);
                copy.WriteToServer(dt);
            }
        }
        SqlDateTime sqltime; 
        private void SaveNewFirstTimeArticale(List<BalanceFirstDurationViewModel> mybalance)
        {
            List<FirstTimeArticles> newArt = new List<FirstTimeArticles>();
            SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
            con.Open();
            SqlCommand second = new SqlCommand("select count(*) from Articale", con);
            second.CommandType = CommandType.Text;
            var myid = second.ExecuteScalar();
            foreach (var item in mybalance)
            {
                newArt.Add(new FirstTimeArticles
                {
                    id = Convert.ToInt32(myid)+1,
                    InvoiceKind= "رصيد أول مدة",
                    UnitId = item.UnitId,
                    Name = item.ArticleIdDescr,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Total=item.Total,
                    Expirydate = item.ExpiryDate,
                }) ;
                myid = newArt.LastOrDefault().id;
            }
            Insert(newArt);
        }
        public void Insert(List<FirstTimeArticles> list)
        {
            using (var copy = new SqlBulkCopy(ShefaaPharmacyDbContext.ConStr))
            {
                DataTable dt = new DataTable();
                copy.DestinationTableName = "dbo.FirstTimeArticles";
                // Add mappings so that the column order doesn't matter
                copy.ColumnMappings.Add(nameof(FirstTimeArticles.id), "id");
                copy.ColumnMappings.Add(nameof(FirstTimeArticles.Name), "name");
                copy.ColumnMappings.Add(nameof(FirstTimeArticles.InvoiceKind), "InvoiceKind");
                copy.ColumnMappings.Add(nameof(FirstTimeArticles.UnitIdDescr), "UnitIdDescr");
                copy.ColumnMappings.Add(nameof(FirstTimeArticles.Price), "Price");
                copy.ColumnMappings.Add(nameof(FirstTimeArticles.Quantity), "Quantity");
                copy.ColumnMappings.Add(nameof(FirstTimeArticles.Total), "Total");
                copy.ColumnMappings.Add(nameof(FirstTimeArticles.Expirydate), "ExpiryDate");

                dt = ToDataTable(list);
                copy.WriteToServer(dt);
            }
        }
        BillMaster billMaster = new BillMaster();
        private bool SaveNewFirstTimeBill()
        {
            List<BillDetail> _billDetails = new List<BillDetail>();
            foreach (var detail in EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>)
            {
                if (detail.ArticleId == 0 || detail.Quantity == 0)
                {
                    continue;
                }
                _billDetails.Add(new BillDetail()
                {
                    ArticaleId = detail.ArticleId,
                    Barcode = DescriptionFK.GetArticaleBarcodeForBalanceFirstTime(detail.ArticleIdDescr),
                    Discount = 0,
                    InvoiceKind = InvoiceKind.GoodFirstTime,
                    Quantity = detail.Quantity,
                    QuantityGift = 0,
                    Price = Convert.ToInt32(detail.Price),
                    UnitTypeId = detail.UnitId,
                    UnitTypeIdBasic = 0,
                    TotalPrice = Convert.ToInt32(detail.Total),
                    PriceTag = new PriceTagMaster()
                    {
                        ArticleId = detail.ArticleId,
                        UnitId = InventoryService.GetSmallestArticleUnit(detail.ArticleId),
                        CountGiftItem = 0,
                        CountSoldItem = 0,
                        CountAllItem = detail.Quantity,
                        BranchId = UserLoggedIn.User.BranchId,
                        ExpiryDate = detail.ExpiryDate,
                        PriceTagDetails = ArticleService.MakeNewPriceTagDetailForArticle(detail.ArticleId, detail.UnitId, detail.Price),
                    },
                });
            }
            billMaster.BillDetails = _billDetails;
            billMaster.CalcTotal();
            BillService billService = new BillService(billMaster);
            bool result = billService.BuyBill();
            if (!result)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء تخزين الفاتورة", MessageBoxState.Error);
                return false;
            }
            return result;
        }
        private void dgvArticles_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvArticles.CurrentRow.DataBoundItem == null)
                return;
            try
            {
                var cell = dgvArticles[e.ColumnIndex, e.RowIndex];
                string cellName = cell.OwningColumn.Name;
                if (cellName == "ArticleIdDescr" && (e.FormattedValue.ToString() != "") && (EditBindingSource.Current as BalanceFirstDurationViewModel).ArticleIdDescr != e.FormattedValue.ToString())
                {
                    FillWithArticleName(e.FormattedValue.ToString());
                }
                else if (cellName == "UnitIdDescr" && (e.FormattedValue.ToString() != "") && (EditBindingSource.Current as BalanceFirstDurationViewModel).UnitIdDescr != e.FormattedValue.ToString())
                {
                    PriceTagMaster priceTag = DescriptionFK.PriceTagExists((EditBindingSource.Current as BalanceFirstDurationViewModel).ArticleId);
                    var currentRow = (EditBindingSource.Current as BalanceFirstDurationViewModel);
                    if (priceTag != null)
                    {
                        int unitId = DescriptionFK.GetUnitId(e.FormattedValue.ToString());
                        currentRow.UnitId = unitId;
                        currentRow.UnitIdDescr = e.FormattedValue.ToString();
                        currentRow.Price = priceTag.PriceTagDetails.FirstOrDefault(x => x.UnitId == unitId).SellPrice;
                    }
                    else
                    {
                        if (ShefaaPharmacyDbContext.GetCurrentContext()
                            .ArticleUnits
                            .FirstOrDefault(x => x.ArticleId == currentRow.ArticleId && x.UnitTypeId == DescriptionFK.GetUnitId(e.FormattedValue.ToString())) != null)
                        {
                            int unitId = DescriptionFK.GetUnitId(e.FormattedValue.ToString());
                            currentRow.UnitId = unitId;
                            currentRow.UnitIdDescr = e.FormattedValue.ToString();
                            currentRow.Price = 0;
                        }
                    }
                }
                if (cellName == "ExpiryDate")
                {
                    string DateValue;
                    DateTime DateFormated;
                    DateValue = e.FormattedValue.ToString();
                    CurrDate = DateValue;
                    if (!DateTime.TryParseExact(DateValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateFormated) && !DateTime.TryParseExact(DateValue, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateFormated))
                    {
                        _MessageBoxDialog.Show("يجب ادخال تنسيق تاريخ صحيح بالشكل \n 01/01/2000", MessageBoxState.Error);
                        e.Cancel = true; // The important part
                        SetFocus("ExpiryDate");
                        return;
                    }
                    else if (Convert.ToDateTime(e.FormattedValue) <= DateTime.Now.Date)
                    {
                        _MessageBoxDialog.Show("يجب وضع تاريخ صلاحية غير منتهي", MessageBoxState.Warning);
                        e.Cancel = true;
                        SetFocus("ExpiryDate");
                        return;
                    }
                }
                CalcTotal();
            }
            catch (Exception ex)
            {

            }

        }
        private void FillWithArticleName(string value)
        {
            Article result = DescriptionFK.ArticleExistsNameOrBarcode(value);
            if(result == null)
            {
                if(_MessageBoxDialog.Show("هل تريد اختيار صنف أو إضافة مادة جديدة ؟", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                {
                    try
                    {
                        result = ArticlePicker.PickArticale("", 0, FormOperation.Pick);
                        Article choosedres = DescriptionFK.ArticleExistsNameOrBarcode(result.Name);

                        if (result != null)
                        {
                          FillRow(choosedres);
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                FillRow(result);
            }
        }
        private void FillRow(Article article)
        {
            try
            {
                var dataRow = (EditBindingSource.Current as BalanceFirstDurationViewModel);
                if (article != null)
                {
                    var context = ShefaaPharmacyDbContext.GetCurrentContext();
                    try
                    {
                        var pricetag = context.PriceTagMasters.Where(x => x.ArticleId == article.Id).FirstOrDefault();
                        var tagdetail = context.PriceTagDetails.Where(x => x.PriceTagId == pricetag.Id).FirstOrDefault();
                        var priceTagForArt = DescriptionFK.GetOldestExpiryDate(article.Id);
                        if (priceTagForArt != null && article.PriceTagMasters.Count > 0)
                        {
                            var lastPriceTag = priceTagForArt.OrderByDescending(x => x.CreationDate).FirstOrDefault();
                            dataRow.UnitId = DescriptionFK.GetPrimaryUnit(article.Id);
                            try
                            {
                                dataRow.Price = tagdetail.BuyPrice;
                            }
                            catch
                            {
                                dataRow.Price = 0;
                            }
                        }
                        else
                        {
                            dataRow.UnitId = DescriptionFK.GetPrimaryUnit(article.Id);
                            dataRow.Price = 0;
                            //dataRow.PriceTag = new PriceTag();
                        }

                        dataRow.ArticleId = article.Id;
                        dataRow.ArticleIdDescr = article.Name;
                        dataRow.Quantity = 1;
                    }
                    catch
                    {
                        dataRow.UnitId = DescriptionFK.GetPrimaryUnit(article.Id);
                        dataRow.Price = 0;
                        dataRow.ArticleId = article.Id;
                        dataRow.ArticleIdDescr = article.Name;
                        dataRow.Quantity = 1;
                    }
                }
                CalcTotal();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }
        int tbTotalPrice = 0;
        private void CalcTotal()
        {
            double total = 0;
            (EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>).ForEach(x => total += x.Total);
            TotalPrice = total;
            tbTotalPrice = Convert.ToInt32(total);
        }
        int ExistStuffTotal = 0;
        private void CalcTotalForFirstStuff()
        {
            double total = 0;
            (ExistStuffBindingSource.DataSource as List<ExistStuffViewModel>).ForEach(x => total += x.Price);
            ExistStuffTotal = Convert.ToInt32(total);
        }
        private void EditBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            try
            {
                CalcTotal();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvSuplier_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvSuplier.CurrentRow.DataBoundItem == null)
                return;
            try
            {
                var cell = dgvSuplier[e.ColumnIndex, e.RowIndex];
                string cellName = cell.OwningColumn.Name;
                if (cellName == "AccountIdDescr" && (e.FormattedValue.ToString() != "") && (SupplierBindingSource.Current as SupplierDepthViewModel).AccountIdDescr != e.FormattedValue.ToString())
                {
                    string account = e.FormattedValue.ToString().Trim();
                    if (account == "" || DescriptionFK.AccountExists(true, account, 0) == null)
                    {
                        if (_MessageBoxDialog.Show("حساب خاطئ هل تريد استخدام الاستعراض", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                        {
                            Account result = AccountPickForm.PickAccount("", new int[1] { ConstantDataBase.AC_Supplier }, null, FormOperation.Pick);
                            if (result != null)
                            {
                                (SupplierBindingSource.Current as SupplierDepthViewModel).AccountId = result.Id;
                                (SupplierBindingSource.Current as SupplierDepthViewModel).AccountIdDescr = result.Name;
                            }
                        }
                        else
                        {
                            dgvSuplier.CurrentCell = dgvSuplier["AccountIdDescr", e.RowIndex];
                            dgvSuplier.BeginEdit(true);
                            //e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvCustomer_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvCustomer.CurrentRow.DataBoundItem == null)
                return;
            try
            {
                var cell = dgvCustomer[e.ColumnIndex, e.RowIndex];
                string cellName = cell.OwningColumn.Name;
                if (cellName == "AccountIdDescr" && (e.FormattedValue.ToString() != "") && (CustomerBindingSource.Current as CustomerDepthViewModel).AccountIdDescr != e.FormattedValue.ToString())
                {
                    string account = e.FormattedValue.ToString().Trim();
                    if (account == "" || DescriptionFK.AccountExists(true, account, 0) == null)
                    {
                        if (_MessageBoxDialog.Show("حساب خاطئ هل تريد استخدام الاستعراض", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                        {
                            Account result = AccountPickForm.PickAccount("", new int[1] { ConstantDataBase.AC_Customer }, null, FormOperation.Pick);
                            if (result != null)
                            {
                                (CustomerBindingSource.Current as CustomerDepthViewModel).AccountId = result.Id;
                                (CustomerBindingSource.Current as CustomerDepthViewModel).AccountIdDescr = result.Name;
                            }
                        }
                        else
                        {
                            dgvCustomer.CurrentCell = dgvCustomer["AccountIdDescr", e.RowIndex];
                            dgvCustomer.BeginEdit(true);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected override void btCancel_Click(object sender, EventArgs e)
        {
            try
            {
                base.btCancel_Click(sender, e);
                dgvArticles.Visible = false;
                dgvAll.Visible = true;
                dgvTotalPrice.Visible = true;
            }
            catch (Exception ex)
            {
                ;
            }
        }
        private void DgvSuplier_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvSuplier.CurrentRow.DataBoundItem == null)
                return;
            try
            {
                var currentRow = dgvSuplier.Rows[e.RowIndex];
                //Debit And Credit Check 
                if (Convert.ToDouble(currentRow.Cells["Credit"].Value) != 0)
                {
                    _MessageBoxDialog.Show("يجب أن يكون الحساب إما مدين أو دائن", MessageBoxState.Warning);
                    e.Cancel = true;
                    dgvSuplier.CurrentCell = dgvSuplier["Credit", e.RowIndex];
                    dgvSuplier.BeginEdit(true);
                    return;
                }
                else if (Convert.ToDouble(currentRow.Cells["Credit"].Value) == 0)
                {
                    _MessageBoxDialog.Show("يجب أن يكون الحساب إما مدين أو دائن", MessageBoxState.Warning);
                    e.Cancel = true;
                    dgvSuplier.CurrentCell = dgvSuplier["Credit", e.RowIndex];
                    dgvSuplier.BeginEdit(true);
                    return;
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ يرجى اعادة العملية", MessageBoxState.Error);

            }
        }
        private void DgvArticles_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dgvArticles.CurrentCell.ColumnIndex;
            string headerText = dgvArticles.Columns[column].Name;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            if (headerText.Equals("UnitIdDescr") && (EditBindingSource.Current as BalanceFirstDurationViewModel).ArticleId != 0)
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    var d = UnitTypeService.GetAllUnitForArticle((EditBindingSource.Current as BalanceFirstDurationViewModel).ArticleId);
                    List<string> data = d.Select(x => x.UnitTypeIdDescr).ToList();
                    AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                    data.ForEach(x => autoCompleteStringCollection.Add(x));
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tb.AutoCompleteCustomSource = autoCompleteStringCollection;
                }
            }
            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (headerText.Equals("Price")|| headerText.Equals("Quantity") || headerText.Equals("Total") && (EditBindingSource.Current as BalanceFirstDurationViewModel).ArticleId != 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        }
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        int count = 0;
        private void LoadFirstArts()
        {
            if (count == 0)
                dgvAll.Columns.Clear();
            count++;
            SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select name as الصنف,UnitIdDescr as الواحدة,price as السعر,quantity as [كمية أول المدة] ,Total as الإجمالي,Expirydate as [تاريخ الصلاحية] from FirstTimeArticles order by name asc", con);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            //ds.Tables.Add("Medicines");
            da.Fill(ds, "FirstTimeArticles");
            FirstTimeBindingSource.DataSource = ds.Tables["FirstTimeArticles"];
            lblCenter.Visible = false;
            dgvAll.Refresh();
            dgvTotalPrice.Refresh();
        }
        bool isfirst = true;
        private void ChangeAddBtnEvent()
        {
            if (tabControl1.SelectedTab==tabPage1)
            {
                dgvAll.Visible = false;
                dgvTotalPrice.Visible = false;
                dgvArticles.Visible = true;
                BackPictureBox.Enabled = true;
                if (lblCenter.Visible == true)
                {
                    lblCenter.Visible = false;
                }
                pictureBoxDelete.Enabled = lblDelete.Enabled = true;
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                dgvAllCustomers.Visible = false;
                dgvCustomer.Visible = true;
                BackPictureBox.Enabled = true;
                LoadDgvCustomer();
                lblNoCustomerDepits.Visible = false;
                pictureBoxDelete.Enabled = lblDelete.Enabled = true;

            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                dgvAllSuppliers.Visible = false;
                dgvSuplier.Visible = true;
                BackPictureBox.Enabled = true;
                LoadDgvSupplier();
                lblNoSupplierDepits.Visible = false;
                pictureBoxDelete.Enabled = lblDelete.Enabled = true;

            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                dgvBankCash.Columns["AccountIdDescr"].Visible = false;
                dgvBankCash.Columns["KindOperation"].Visible = false;
                dgvBankCash.Columns["Debit"].ReadOnly = false;
                
                BackPictureBox.Enabled = true;
                if (dgvBankCash.Rows.Count >= 1)
                {
                   isfirst = false;
                }else BankCashBindingSource.AddNew();
                panelAdd.Visible = false;
                lblNoBankCash.Visible = false;
                pictureBoxDelete.Enabled = lblDelete.Enabled = true;

            }
            else if(tabControl1.SelectedTab == tabPage5)
            {
                LoaddgvAllStuff();   
                dgvAllStuff.Visible = false;
                ExistStuffdatagrid.Visible = true;
                BackPictureBox.Enabled = true;
                lblNoExistStuff.Visible = false;
                pictureBoxDelete.Enabled = lblDelete.Enabled = true;

            }
        }
        UserParameters userParameters= new UserParameters();
        public void LoadAllCustomerDepits( )
        {
            userParameters.Acc_AccountId = 2;
            userParameters.BranchId = 1;
            string date = "01/01/2000";
            DateTime firstdate = Convert.ToDateTime(date);
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@AccountId", 2),
                new SqlParameter("@FromDate", firstdate),
                new SqlParameter("@ToDate", userParameters.ToDate),
                new SqlParameter("@CreationBy", userParameters.UserId)
            };
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetAccountMovmement",
                                                parameters.ToArray());
            List<EntryDetail> resultReport = DataBaseService.ConvertDataTable<EntryDetail>(result);
            List<EntryDetail> finalresult = new List<EntryDetail>();

            foreach (EntryDetail item in resultReport)
            {
                if (item.Id == item.Id - 1)
                {
                    if (count == 2) continue;
                    finalresult.Add(item);
                    count++;
                }
                if (item.KindOperation == KindOperation.GoodFirstTime && item.Debit != 0)
                {
                    finalresult.Add(item);
                }
            }
            AllCustomerBindingSource.DataSource = finalresult;
            dgvAllCustomers.DataSource = AllCustomerBindingSource;
            dgvAll.Refresh();
            dgvTotalPrice.Refresh();

            dgvAllCustomers.Columns["credit"].Visible = false;
            dgvAllCustomers.Columns["Description"].Visible = false;
            dgvAllCustomers.Columns["CreationByDescr"].Visible = false;
            dgvAllCustomers.Columns["CreationDate"].Visible = false;
            dgvAllCustomers.Columns["KindOperation"].HeaderText = "البيان";
            dgvAllCustomers.Columns["KindOperation"].DisplayIndex = 2;
            if (dgvAllCustomers.Rows.Count==0)
            {
                lblNoCustomerDepits.Visible = true;
            }
            else
            {
                lblNoCustomerDepits.Visible = false;
            }
        }
        private void LoadAllSupplierDepits( )
        {
            userParameters.Acc_AccountId = 6;
            userParameters.BranchId = 1;
            string date = "01/01/2000";
            DateTime firstdate = Convert.ToDateTime(date);
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@AccountId", 6),
                new SqlParameter("@FromDate", firstdate),
                new SqlParameter("@ToDate", userParameters.ToDate),
                new SqlParameter("@CreationBy", userParameters.UserId)
            };
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetAccountMovmement",
                                                parameters.ToArray());
            List<EntryDetail> resultReport = DataBaseService.ConvertDataTable<EntryDetail>(result);
            List<EntryDetail> finalresult = new List<EntryDetail>();

            foreach (EntryDetail item in resultReport)
            {
                if (item.Id == item.Id - 1)
                {
                    if (count == 2) continue;
                    finalresult.Add(item);
                    count++;
                }
                if (item.KindOperation == KindOperation.GoodFirstTime && item.Credit != 0)
                {
                    finalresult.Add(item);
                }
            }
            AllSuppliersBindingSource.DataSource = finalresult;
            dgvAllSuppliers.DataSource = AllSuppliersBindingSource;

            dgvAllSuppliers.Columns["Debit"].Visible = false;
            dgvAllSuppliers.Columns["Debit"].HeaderText = "ملاحظة";
            dgvAllSuppliers.Columns["Description"].Visible = false;
            dgvAllSuppliers.Columns["CreationByDescr"].Visible = false;
            dgvAllSuppliers.Columns["CreationDate"].Visible = false;
            dgvAllSuppliers.Columns["KindOperation"].HeaderText = "البيان";
            dgvAllSuppliers.Columns["KindOperation"].DisplayIndex = 3;
            if (dgvAllSuppliers.Rows.Count == 0)
            {
                lblNoSupplierDepits.Visible = true;
            }
            else
            {
                lblNoSupplierDepits.Visible = false;
            }
        }
        EntryDetail bankcashDetail = new EntryDetail();
        private void LoadPharmacyBankCash()
        {
            userParameters.Acc_AccountId = 3;
            userParameters.BranchId = 1;
            string date = "01/01/2000";
            DateTime firstdate = Convert.ToDateTime(date);
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@AccountId", 3),
                new SqlParameter("@FromDate", firstdate),
                new SqlParameter("@ToDate", userParameters.ToDate),
                new SqlParameter("@CreationBy", userParameters.UserId)
            };
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetAccountMovmement",
                                                parameters.ToArray());
            List<EntryDetail> resultReport = DataBaseService.ConvertDataTable<EntryDetail>(result);
            List<EntryDetail> finalresult = new List<EntryDetail>();

            foreach (EntryDetail item in resultReport)
            {
                if (item.Id == item.Id - 1)
                {
                    if (count == 2) continue;
                    finalresult.Add(item);
                    count++;
                }
                if (item.KindOperation == KindOperation.GoodFirstTime)
                {
                    finalresult.Add(item);
                    bankcashDetail = item;
                }
            }
            BankCashBindingSource.DataSource = finalresult;
            dgvBankCash.DataSource = BankCashBindingSource;
            dgvBankCash.Refresh();
            dgvBankCash.Columns["id"].Visible = false;
            dgvBankCash.Columns["credit"].Visible = false;
            dgvBankCash.Columns["Description"].Visible = false;
            dgvBankCash.Columns["CreationByDescr"].Visible = false;
            dgvBankCash.Columns["CreationDate"].Visible = false;
            dgvBankCash.Columns["KindOperation"].HeaderText = "البيان";
            dgvBankCash.Columns["KindOperation"].DisplayIndex = 5;
            dgvBankCash.Columns["Debit"].ReadOnly = true;
            dgvBankCash.AllowUserToAddRows = false;
            if (dgvBankCash.Rows.Count == 0)
            {
                lblNoBankCash.Visible = true; 
            }
            else
            {
                lblNoBankCash.Visible = false; 
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                LoadFirstArts();
                LoadTotalPrice();
                panelAdd.Visible = true;
                lblAdd.Text = "إضافة مادة";
                panelDelete.Visible = true;
            }
            else if(tabControl1.SelectedTab==tabPage2)
            {
                LoadAllCustomerDepits();
                panelAdd.Visible = true;
                lblAdd.Text ="إضافة دين";
                panelDelete.Visible = true;
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                LoadAllSupplierDepits();
                panelAdd.Visible = true;
                lblAdd.Text = "إضافة دين";
                panelDelete.Visible = true;
            }
            if (tabControl1.SelectedTab == tabPage4)
            {
                LoadPharmacyBankCash();
                pictureBox2.Visible = false;

                lblAdd.Text = "تعديل الرصيد";
            }
            if (tabControl1.SelectedTab == tabPage5)
            {
                LoadAllExisitStuff();
                panelAdd.Visible = true;
                lblAdd.Text = "إضافة موجودات";
                panelDelete.Visible = true;
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            FirstTimeReport frm = new FirstTimeReport(new EntryMaster(),"FirstTime");
            frm.ShowDialog();
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            ChangeAddBtnEvent();
        }
        private void dgvAll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var g = sender as DataGridView;
            var p = g.PointToClient(MousePosition);
            var hti = g.HitTest(p.X, p.Y);
            if (hti.Type == DataGridViewHitTestType.ColumnHeader)
            {
                var columnIndex = hti.ColumnIndex;
                return;
                //You handled a double click on column header
                //Do what you need
            }
            EntryDetail detail = new EntryDetail();
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            BalanceFirstDurationViewModel myrow = new BalanceFirstDurationViewModel();
            myrow.ArticleId = DescriptionFK.GetArticaleNameForBalanceFirst(dgvAll.CurrentRow.Cells[0].Value.ToString());
            myrow.ArticleIdDescr = DescriptionFK.GetArticaleName(myrow.ArticleId);
            myrow.UnitId = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.FirstOrDefault(x => x.Name == dgvAll.CurrentRow.Cells[1].Value.ToString()).Id;
            myrow.Price = Convert.ToInt32(dgvAll.CurrentRow.Cells["السعر"].Value);
            myrow.Quantity = Convert.ToInt32(dgvAll.CurrentRow.Cells["كمية أول المدة"].Value);
            int quant = InventoryService.ConvertArticleUnitToSmallestUnit(myrow.ArticleId,myrow.UnitId,myrow.Quantity);
            myrow.PriceTagId = context.PriceTagMasters.FirstOrDefault(x => x.ArticleId == myrow.ArticleId && x.CountAllItem == quant).Id;
            string dt = Convert.ToDateTime(dgvAll.CurrentRow.Cells["تاريخ الصلاحية"].Value).ToString("yyyy-MM-dd HH:mm:ss.fff");
            string dateString = dgvAll.CurrentRow.Cells["تاريخ الصلاحية"].Value.ToString();
            DateTime date = Convert.ToDateTime(dt, System.Globalization.CultureInfo.GetCultureInfo("ur-PK").DateTimeFormat);  
            myrow.ExpiryDate = date;

            detail.AccountId =19;detail.Credit =0;detail.Debit =myrow.Total;detail.Id = context.EntryDetails.FirstOrDefault(x => x.AccountId == 19 && x.Debit == myrow.Total).Id;
            detail.EntryMasterId = context.EntryDetails.FirstOrDefault(x => x.AccountId == 19 && x.Debit == myrow.Total).EntryMasterId;
            FirstDurationArticlesEditForm editForm = new FirstDurationArticlesEditForm(myrow, "Edit",detail);
            editForm.ShowDialog();
            LoadFirstArts();
            LoadTotalPrice();
        }
        public void RefreshAfterEditQuantity()
        {
            pictureBox2_Click(this, new EventArgs());
        }

        private void BackPictureBox_Click(object sender, EventArgs e)
        {   
            if (tabControl1.SelectedTab == tabPage1)
            {
                BackPictureBox.Enabled = false;
                dgvAll.Visible = true;
                dgvTotalPrice.Visible = true;
                dgvArticles.Visible = false;
                LoadFirstArts();
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                BackPictureBox.Enabled = false;
                dgvAllCustomers.Visible = true;
                dgvCustomer.Visible = false;
                LoadAllCustomerDepits();
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                BackPictureBox.Enabled = false;
                dgvAllSuppliers.Visible = true;
                dgvSuplier.Visible = false;
                LoadAllSupplierDepits();
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                BackPictureBox.Enabled = false;
                dgvBankCash.Columns["AccountIdDescr"].Visible = true;
                dgvBankCash.Columns["KindOperation"].Visible = true;
                dgvBankCash.Columns["Debit"].ReadOnly = true;
                dgvBankCash.AllowUserToAddRows = false;
                LoadPharmacyBankCash();
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                BackPictureBox.Enabled = false;
                dgvAllStuff.Visible = true;
                ExistStuffdatagrid.Visible = false;
                LoadAllExisitStuff();
            }
            pictureBoxDelete.Enabled = lblDelete.Enabled = false;
        }
        private void Mymethod(int columnIndex)
        {
            if (dgvArticles.CurrentRow == null)
            {
                FirstTimeBindingSource.AddNew();
            }
            dgvArticles.CurrentCell = dgvArticles.CurrentRow.Cells[columnIndex];
            dgvArticles.BeginEdit(true);
        }
        delegate void SetColumnIndex(int i);
        public void SetFocus(string col = "")
        {
            if (col == "")
            {
                col = "BarcodeDescr";
            }
            if (dgvArticles.Rows.Count > 0)
            {
                SetColumnIndex method = new SetColumnIndex(Mymethod);
                dgvArticles.BeginInvoke(method, dgvArticles.Columns[col].Index);
            }
        }

        private void dgvArticles_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (ActiveControl == null || !ActiveControl.Name.Contains("dgvArticles"))
            {
                return;
            }
            if (dgvArticles.CurrentRow.DataBoundItem == null)
                return;
            try
            {
                if(dgvArticles.Rows[e.RowIndex].Cells["ArticleIdDescr"].Value.ToString() != "")
                {
                    if (DateTime.Parse(dgvArticles.Rows[e.RowIndex].Cells["ExpiryDate"].Value.ToString()).ToShortDateString() == "01/01/0001" || dgvArticles.Rows[e.RowIndex].Cells["ExpiryDate"].Value.ToString() == null || dgvArticles.Rows[e.RowIndex].Cells["ExpiryDate"].Value.ToString() == "")
                    {
                        _MessageBoxDialog.Show("يرجى إدخال تاريخ صلاحية", MessageBoxState.Warning);
                        dgvArticles.Rows[e.RowIndex].Cells["ExpiryDate"].Value = "";
                        e.Cancel = true;
                        SetFocus("ExpiryDate");
                        return;
                    }
                    else
                    {
                        string DateValue;
                        DateTime DateFormated;
                        DateValue = CurrDate;
                        if (!DateTime.TryParseExact(DateValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateFormated) && !DateTime.TryParseExact(DateValue, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateFormated))
                        {
                            _MessageBoxDialog.Show("يجب ادخال تنسيق تاريخ صحيح بالشكل \n 01/01/2000", MessageBoxState.Error);
                            e.Cancel = true; // The important part
                            SetFocus("ExpiryDate");
                            
                        }
                    }
                }
            }
            catch
            {
              _MessageBoxDialog.Show("لم يتم تنفيذ التحقق", MessageBoxState.Error);
            }
        }
        EntryDetail mydetail1 = new EntryDetail();
        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            try
            {
                if (tabControl1.SelectedTab == tabPage1)//المواد
                {
                    if (dgvArticles.Rows.Count == 0) return;

                    dgvArticles.Rows.RemoveAt(dgvArticles.CurrentRow.Index);
                    dgvArticles.Refresh();
                }
                else if (tabControl1.SelectedTab == tabPage5)//الموجودات الثابتة
                {
                    if (ExistStuffdatagrid.Rows.Count == 0) return;
                    ExistStuffdatagrid.Rows.RemoveAt(ExistStuffdatagrid.CurrentRow.Index);
                    ExistStuffdatagrid.Refresh();
                }
                else if (tabControl1.SelectedTab == tabPage2)//ديون الزبائن
                {
                    if (dgvCustomer.Rows.Count == 0) return;
                    dgvCustomer.Rows.RemoveAt(dgvCustomer.CurrentRow.Index);
                    dgvCustomer.Refresh();

                }
                else if (tabControl1.SelectedTab == tabPage3)//ديون الموردين
                {
                    if (dgvSuplier.Rows.Count == 0) return;
                    dgvSuplier.Rows.RemoveAt(dgvSuplier.CurrentRow.Index);
                    dgvSuplier.Refresh();

                }
                else if (tabControl1.SelectedTab == tabPage4)
                {
                    if (dgvBankCash.Rows.Count == 0) return;
                    dgvBankCash.Rows[0].Cells[1].Value = "0";
                }
            }
            catch
            {
                ;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                LoadFirstArts();
            }
            if (tabControl1.SelectedTab == tabPage2)
            {
                LoadAllCustomerDepits();
            }
            if (tabControl1.SelectedTab == tabPage3)
            {
                LoadAllSupplierDepits();
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                LoadAllExisitStuff();
            }
        }
        private void dgvAllSuppliers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var g = sender as DataGridView;
            var p = g.PointToClient(MousePosition);
            var hti = g.HitTest(p.X, p.Y);
            if (hti.Type == DataGridViewHitTestType.ColumnHeader)
            {
                var columnIndex = hti.ColumnIndex;
                return;
                //You handled a double click on column header
                //Do what you need
            }
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            EntryDetail detail = new EntryDetail();
            Account CurrentAccount = context.Accounts.Where(x => x.Name == dgvAllSuppliers.CurrentRow.Cells["AccountIdDescr"].Value.ToString()).FirstOrDefault();
            detail.AccountId = CurrentAccount.Id;
            detail.AccountIdDescr = CurrentAccount.Name;
            detail.Credit = Convert.ToDouble(dgvAllSuppliers.CurrentRow.Cells["Credit"].Value);
            detail.Id = Convert.ToInt32(dgvAllSuppliers.CurrentRow.Cells["Id"].Value);
            detail.EntryMasterId = context.EntryDetails.FirstOrDefault(x => x.Id == detail.Id).EntryMasterId;
            //foreach (DataGridViewRow item in dgvAllSuppliers.Rows)
            //{
                if (dgvAllSuppliers.CurrentCell.Selected == true)
                {
                    //detail.EntryMasterId = (item.DataBoundItem as EntryDetail).EntryMasterId;
                }
            //}
            FirstTimeSupplierEditForm editForm = new FirstTimeSupplierEditForm(detail);
            editForm.ShowDialog();
            LoadAllSupplierDepits();
        }

        private void dgvAllCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var g = sender as DataGridView;
            var p = g.PointToClient(MousePosition);
            var hti = g.HitTest(p.X, p.Y);
            if (hti.Type == DataGridViewHitTestType.ColumnHeader)
            {
                var columnIndex = hti.ColumnIndex;
                return;
                //You handled a double click on column header
                //Do what you need
            }
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            EntryDetail detail = new EntryDetail();
            Account CurrentAccount = context.Accounts.Where(x => x.Name == dgvAllCustomers.CurrentRow.Cells["AccountIdDescr"].Value.ToString()).FirstOrDefault();
            detail.AccountId = CurrentAccount.Id;
            detail.AccountIdDescr = CurrentAccount.Name;
            detail.Debit = Convert.ToDouble(dgvAllCustomers.CurrentRow.Cells["Debit"].Value);
            detail.Id = Convert.ToInt32(dgvAllCustomers.CurrentRow.Cells["Id"].Value);
            foreach (DataGridViewRow item in dgvAllCustomers.Rows)
            {
                if (dgvAllCustomers.CurrentCell.Selected == true)
                {
                    detail.EntryMasterId = (item.DataBoundItem as EntryDetail).EntryMasterId;
                }
            }
            FirstTimeCustomerEditForm editForm = new FirstTimeCustomerEditForm(detail);
            editForm.ShowDialog();
            LoadAllCustomerDepits();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvAllStuff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var g = sender as DataGridView;
                var p = g.PointToClient(MousePosition);
                var hti = g.HitTest(p.X, p.Y);
                if (hti.Type == DataGridViewHitTestType.ColumnHeader)
                {
                    var columnIndex = hti.ColumnIndex;
                    return;
                    //You handled a double click on column header
                    //Do what you need
                }
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                EntryDetail detail = new EntryDetail();
                ExistStuffViewModel myrow = new ExistStuffViewModel();
                myrow.Name = dgvAllStuff.CurrentRow.Cells[0].Value.ToString();
                myrow.Count = Convert.ToDouble(dgvAllStuff.CurrentRow.Cells[2].Value);
                myrow.Price = Convert.ToDouble(dgvAllStuff.CurrentRow.Cells[1].Value);
                myrow.Description = dgvAllStuff.CurrentRow.Cells[3].Value.ToString();
                detail.AccountId = 21; detail.Debit = myrow.Price; detail.Id = context.EntryDetails.FirstOrDefault(x => x.AccountId == 21 && x.Debit == myrow.Price).Id;
                detail.EntryMasterId = context.EntryDetails.FirstOrDefault(x => x.AccountId == 21 && x.Debit == myrow.Price).EntryMasterId;
                ExistStuffEditForm editForm = new ExistStuffEditForm(myrow, detail);
                editForm.ShowDialog();
                LoadAllExisitStuff();
            }
            catch
            {
                _MessageBoxDialog.Show("هناك مشكلة في بيانات الحقل المحدد", MessageBoxState.Error);
            }
            
        }

        private void dgvBankCash_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dgvBankCash.CurrentCell.ColumnIndex;
            string headerText = dgvBankCash.Columns[column].Name;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (headerText.Equals("Debit"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        } 

        private void pBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvAllStuff_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = ExistStuffdatagrid.CurrentCell.ColumnIndex;
            string headerText = dgvBankCash.Columns[column].Name;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (headerText.Equals("السعر")|| headerText.Equals("العدد"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        }
        private void ExistStuffdatagrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = ExistStuffdatagrid.CurrentCell.ColumnIndex;
            string headerText = ExistStuffdatagrid.Columns[column].Name;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (headerText.Equals("Price") || headerText.Equals("Count"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        }
    }
}
