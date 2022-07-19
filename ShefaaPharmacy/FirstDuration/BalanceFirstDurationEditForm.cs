using DataLayer;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.Articale;
using ShefaaPharmacy.Articles;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy
{
    public partial class BalanceFirstDurationEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        public List<BalanceFirstDurationViewModel> _BalanceFirstDurationViewModels { get; set; }
        public List<SupplierDepthViewModel> _SupplierDepthViewModels { get; set; }
        public List<SupplierDepthViewModel> _CustomerDepthViewModels { get; set; }
        public int AccountProfitId { get; set; }
        public int AccountAssetId { get; set; }
        public int AccountCashId { get; set; }
        public int AccountCustomerId { get; set; }
        public int AccountSupplierId { get; set; }
        public double TotalPrice { get; set; }
        public BalanceFirstDurationEditForm()
        {
            InitializeComponent();
        }
        public BalanceFirstDurationEditForm(List<BalanceFirstDurationViewModel> balanceFirstDurationViewModels)
        {
            _BalanceFirstDurationViewModels = balanceFirstDurationViewModels;
            InitializeComponent();
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
                _CustomerDepthViewModels = new List<SupplierDepthViewModel>();
            }

            EditBindingSource.DataSource = _BalanceFirstDurationViewModels;
            dgvArticles.DataSource = EditBindingSource;

            SupplierBindingSource.DataSource = _SupplierDepthViewModels;
            dgvSuplier.DataSource = SupplierBindingSource;

            CustomerBindingSource.DataSource = _CustomerDepthViewModels;
            dgvCustomer.DataSource = CustomerBindingSource;

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
        private void BalanceFirstDurationEditForm_Load(object sender, EventArgs e)
        {

            if (FormOperation == FormOperation.EditFromPicker || FormOperation == FormOperation.Edit)
            {
                Text = "تعديل رصيد أول مدة";
            }
            else
            {
                Text = "رصيد أول مدة";
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                tbAssetAccountId.Text = DescriptionFK.GetAccountName((int?)20);
                AccountAssetId = 20;
                tbProfitAccount.Text = DescriptionFK.GetAccountName((int?)19);
                AccountProfitId = 19;
                tbCashId.Text = DescriptionFK.GetAccountName((int?)12);
                AccountCashId = 12;
            }

            LoadGrid();
            ChangeStyleOfGrid(dgvArticles);
            ChangeStyleOfGrid(dgvSuplier);
            ChangeStyleOfGrid(dgvCustomer);
            WindowState = FormWindowState.Maximized;
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
                _BalanceFirstDurationViewModels.RemoveAt(dgvArticles.Rows.Count - 1);
            }
        }
        private void CheckLastRowForSupplier()
        {
            if (dgvSuplier.Rows[dgvSuplier.Rows.Count - 1].Cells["AccountIdDescr"].Value == null ||
                dgvSuplier.Rows[dgvSuplier.Rows.Count - 1].Cells["Debit"].Value == null ||
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
                dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells["Debit"].Value == null ||
                dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells["Credit"].Value == null)
            {
                return;
            }
            if (Convert.ToDouble(dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells["Credit"].Value) == 0 &&
                Convert.ToString(dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells["AccountIdDescr"].Value) == "" &&
                Convert.ToInt32(dgvCustomer.Rows[dgvCustomer.Rows.Count - 1].Cells["Credit"].Value) == 0)
            {
                _CustomerDepthViewModels.RemoveAt(dgvCustomer.Rows.Count - 1);
            }
        }
        private void GoodFirstTime()
        {
            if (tbTotalPrice.Text.ToString().Trim() == "")
            {
                return;
            }
            try
            {
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Convert.ToDouble(tbTotalPrice.Text), Convert.ToDouble(tbTotalPrice.Text), kindOperation: KindOperation.GoodFirstTime);
                entryMaster.EntryDetails = new List<EntryDetail>();
                entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, 0, Convert.ToDouble(tbTotalPrice.Text), kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountAssetId, Convert.ToDouble(tbTotalPrice.Text), 0, kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                context.EntryMasters.Add(entryMaster);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SupplierMoney()
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            foreach (var item in _SupplierDepthViewModels)
            {
                //if (item.Debit > 0)
                //{
                //    EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Convert.ToDouble(item.Debit), Convert.ToDouble(item.Debit), kindOperation: KindOperation.GoodFirstTime);
                //    entryMaster.EntryDetails = new List<EntryDetail>();
                //    entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(item.AccountId, item.Debit, 0, kindOperation: KindOperation.GoodFirstTime, 0, "حساب المورد - رصيد أول مدة"));
                //    entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, 0, item.Debit, kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                //    context.EntryMasters.Add(entryMaster);
                //    context.SaveChanges();
                //}
                //else if (item.Credit > 0)
                //{
                //    EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Convert.ToDouble(item.Credit), Convert.ToDouble(item.Credit), kindOperation: KindOperation.GoodFirstTime);
                //    entryMaster.EntryDetails = new List<EntryDetail>();
                //    entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, item.Credit, 0, kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                //    entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(item.AccountId, 0, item.Credit, kindOperation: KindOperation.GoodFirstTime, 0, "حساب المورد - رصيد أول مدة"));
                //    context.EntryMasters.Add(entryMaster);
                //    context.SaveChanges();
                //}
            }
        }
        private void CustomerMoney()
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            foreach (var item in _CustomerDepthViewModels)
            {
                //if (item.Debit > 0)
                //{
                //    EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Convert.ToDouble(item.Debit), Convert.ToDouble(item.Debit), kindOperation: KindOperation.GoodFirstTime);
                //    entryMaster.EntryDetails = new List<EntryDetail>();
                //    entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(item.AccountId, item.Debit, 0, kindOperation: KindOperation.GoodFirstTime, 0, "حساب الزبون - رصيد أول مدة"));
                //    entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, 0, item.Debit, kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                //    context.EntryMasters.Add(entryMaster);
                //    context.SaveChanges();
                //}
                //else if (item.Credit > 0)
                //{
                //    EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Convert.ToDouble(item.Credit), Convert.ToDouble(item.Credit), kindOperation: KindOperation.GoodFirstTime);
                //    entryMaster.EntryDetails = new List<EntryDetail>();
                //    entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, item.Credit, 0, kindOperation: KindOperation.GoodFirstTime, 0, "رأس مال"));
                //    entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(item.AccountId, 0, item.Credit, kindOperation: KindOperation.GoodFirstTime, 0, "حساب الزبون - رصيد أول مدة"));
                //    context.EntryMasters.Add(entryMaster);
                //    context.SaveChanges();
                //}
            }

        }
        private void CashFirstTimeMoney()
        {
            try
            {
                if (tbCashValue.Text.ToString().Trim() == "")
                {
                    return;
                }
                if (HelperUI.CheckDouble(Convert.ToDouble(tbCashValue.Text)))
                {
                    ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    if (Convert.ToDouble(tbCashValue.Text) > 0)
                    {
                        EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Convert.ToDouble(tbCashValue.Text), Convert.ToDouble(tbCashValue.Text), kindOperation: KindOperation.GoodFirstTime);
                        entryMaster.EntryDetails = new List<EntryDetail>();
                        entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountCashId, Convert.ToDouble(tbCashValue.Text), 0, kindOperation: KindOperation.GoodFirstTime, 0, "حساب الصندوق - رصيد أول مدة"));
                        entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(AccountProfitId, 0, Convert.ToDouble(tbCashValue.Text), kindOperation: KindOperation.GoodFirstTime, 0, "حساب رأس المال"));
                        context.EntryMasters.Add(entryMaster);
                        context.SaveChanges();
                    }
                }
            }

            catch (Exception)
            {
                throw;
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

                tbTotalPrice.Focus();
                tbTotalPrice.Select();
                CalcTotal();

                CheckLastRow();
                CheckLastRowForSupplier();
                CheckLastRowForCustomer();

                GoodFirstTime();
                SupplierMoney();
                CashFirstTimeMoney();
                CustomerMoney();

                PriceTagService.SaveFirstTimeBalancePriceTag(EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>);
                InventoryService.UpdateInventory(EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, InvoiceKind.GoodFirstTime);
                _MessageBoxDialog.Show("تم تخزين الرصيد بنجاح", MessageBoxState.Done);
                dgvArticles.Rows.Clear();
                dgvCustomer.Rows.Clear();
                dgvSuplier.Rows.Clear();
                EditBindingSource.DataSource = new List<BalanceFirstDurationViewModel>();
                SupplierBindingSource.DataSource = new List<SupplierDepthViewModel>();
                CustomerBindingSource.DataSource = new List<SupplierDepthViewModel>();
                dgvArticles.Refresh();
                dgvCustomer.Refresh();
                dgvSuplier.Refresh();

                tbAssetAccountId.Text = "";
                tbProfitAccount.Text = "";
                AccountAssetId = 0;
                AccountProfitId = 0;
                tbTotalPrice.Text = "";
                TotalPrice = 0;
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
            }
        }

        private void lbProfitAccount_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            Account result = AccountPickForm.PickAccount(tbProfitAccount.Text.ToString().Trim(), new int[1] { ConstantDataBase.AC_Profits }, null, FormOperation.Pick);
            if (result == null)
            {

                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);

            }
            else
            {

                tbProfitAccount.Text = result.Name;
                AccountProfitId = result.Id;

            }

        }

        private void lbAssetAccountId_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            Account result = AccountPickForm.PickAccount(tbAssetAccountId.Text.ToString().Trim(), new int[1] { ConstantDataBase.AC_Asset }, null, FormOperation.Pick);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
            }
            else
            {
                tbAssetAccountId.Text = result.Name;
                AccountAssetId = result.Id;
            }
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
                CalcTotal();
            }
            catch (Exception ex)
            {

            }
        }
        private void FillWithArticleName(string value)
        {
            Article result = DescriptionFK.ArticleExistsNameOrBarcode(value);
            if (result == null)
            {
                if (_MessageBoxDialog.Show("هل تريد اختيار صنف ؟", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                {
                    result = ArticlePicker.PickArticale("", 0, FormOperation.Pick);
                    Article choosedres = DescriptionFK.ArticleExistsNameOrBarcode(result.Name);
                    if (result != null)
                    {
                        //result.PriceTags = ShefaaPharmacyDbContext.GetCurrentContext().PriceTags.Where(x => x.ArticaleId == result.Id).ToList();
                        FillRow(choosedres);
                    }
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
                CalcTotal();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }
        private void CalcTotal()
        {
            double total = 0;
            (EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>).ForEach(x => total += x.Total);
            TotalPrice = total;
            tbTotalPrice.Text = total + "";
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

        private void pbDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticles.Rows.Count > 0 && EditBindingSource.Current != null)
                {
                    var index = dgvArticles.CurrentRow.Index;
                    dgvArticles.Rows.RemoveAt(index);
                    dgvArticles.Refresh();
                    CalcTotal();
                }
            }
            catch (Exception ex)
            {
                ;
            }

        }

        private void pbDecresQuantity_Click(object sender, EventArgs e)
        {
            if (dgvArticles.Rows.Count > 0 && EditBindingSource.Current != null)
            {
                if ((EditBindingSource.Current as BalanceFirstDurationViewModel).Quantity > 1)
                {
                    (EditBindingSource.Current as BalanceFirstDurationViewModel).Quantity -= 1;
                }
                dgvArticles.Refresh();
            }

        }

        private void pbIncreseQuantity_Click(object sender, EventArgs e)
        {
            if (dgvArticles.Rows.Count > 0 && EditBindingSource.Current != null)
            {
                (EditBindingSource.Current as BalanceFirstDurationViewModel).Quantity += 1;
                dgvArticles.Refresh();
            }
        }

        private void lbCashId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Account result = AccountPickForm.PickAccount(tbAssetAccountId.Text.ToString().Trim(), new int[1] { ConstantDataBase.AC_Cash }, null, FormOperation.Pick);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
            }
            else
            {
                tbCashId.Text = result.Name;
                AccountCashId = result.Id;
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
                if (cellName == "AccountIdDescr" && (e.FormattedValue.ToString() != "") && (CustomerBindingSource.Current as SupplierDepthViewModel).AccountIdDescr != e.FormattedValue.ToString())
                {
                    string account = e.FormattedValue.ToString().Trim();
                    if (account == "" || DescriptionFK.AccountExists(true, account, 0) == null)
                    {
                        if (_MessageBoxDialog.Show("حساب خاطئ هل تريد استخدام الاستعراض", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                        {
                            Account result = AccountPickForm.PickAccount("", new int[1] { ConstantDataBase.AC_Customer }, null, FormOperation.Pick);
                            if (result != null)
                            {
                                (CustomerBindingSource.Current as SupplierDepthViewModel).AccountId = result.Id;
                                (CustomerBindingSource.Current as SupplierDepthViewModel).AccountIdDescr = result.Name;
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

        private void DgvCustomer_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvCustomer.CurrentRow.DataBoundItem == null)
                return;
            try
            {
                var currentRow = dgvCustomer.Rows[e.RowIndex];
                //Debit And Credit Check 
                if (Convert.ToDouble(currentRow.Cells["Debit"].Value) != 0 && Convert.ToDouble(currentRow.Cells["Credit"].Value) != 0)
                {
                    _MessageBoxDialog.Show("يجب أن يكون الحساب إما مدين أو دائن", MessageBoxState.Error);
                    //e.Cancel = true;
                    dgvCustomer.CurrentCell = dgvCustomer["Debit", e.RowIndex];
                    dgvCustomer.BeginEdit(true);
                    return;
                }

                else if (Convert.ToDouble(currentRow.Cells["Debit"].Value) == 0 && Convert.ToDouble(currentRow.Cells["Credit"].Value) == 0)
                {
                    _MessageBoxDialog.Show("يجب أن يكون الحساب إما مدين أو دائن", MessageBoxState.Error);
                    //e.Cancel = true;
                    dgvCustomer.CurrentCell = dgvCustomer["Debit", e.RowIndex];
                    dgvCustomer.BeginEdit(true);
                    return;
                }

            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }
        protected override void btCancel_Click(object sender, EventArgs e)
        {
            try
            {
                base.btCancel_Click(sender, e);
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
                if (Convert.ToDouble(currentRow.Cells["Debit"].Value) != 0 && Convert.ToDouble(currentRow.Cells["Credit"].Value) != 0)
                {
                    _MessageBoxDialog.Show("يجب أن يكون الحساب إما مدين أو دائن", MessageBoxState.Error);
                    e.Cancel = true;
                    dgvSuplier.CurrentCell = dgvSuplier["Debit", e.RowIndex];
                    dgvSuplier.BeginEdit(true);
                    return;
                }
                else if (Convert.ToDouble(currentRow.Cells["Debit"].Value) == 0 && Convert.ToDouble(currentRow.Cells["Credit"].Value) == 0)
                {
                    _MessageBoxDialog.Show("يجب أن يكون الحساب إما مدين أو دائن", MessageBoxState.Error);
                    e.Cancel = true;
                    dgvSuplier.CurrentCell = dgvSuplier["Debit", e.RowIndex];
                    dgvSuplier.BeginEdit(true);
                    return;
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
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
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click_1(object sender, EventArgs e)
        {

        }

        private void CustomerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
