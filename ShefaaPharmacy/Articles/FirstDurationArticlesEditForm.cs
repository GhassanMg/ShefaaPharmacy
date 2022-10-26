using DataLayer;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class FirstDurationArticlesEditForm : GeneralEditForm
    {
        EntryDetail MyDetail = new EntryDetail();
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        public List<BalanceFirstDurationViewModel> _BalanceFirstDurationViewModels { get; set; }
        public double TotalPrice { get; set; }
        string status = "";
        DateTime expiarydate;
        List<FirstTimeArticles> myart = new List<FirstTimeArticles>();
        public FirstDurationArticlesEditForm()
        {
            InitializeComponent();
        }
        public FirstDurationArticlesEditForm(BalanceFirstDurationViewModel k, string status, EntryDetail detail)
        {
            this.status = status;
            MyDetail = detail;
            InitializeComponent();
            LoadGrid();
            ChangeStyleOfGrid(dgvArticles);
            dgvArticles.Columns["Total"].ReadOnly = true;
            if (k.UnitId == 0)
            {
                k.UnitId = 3;
            }

            EditBindingSource.DataSource = k;
            dgvArticles.Refresh();
            expiarydate = Convert.ToDateTime(dgvArticles.Rows[0].Cells["ExpiryDate"].Value);
        }

        private void LoadGrid()
        {
            _BalanceFirstDurationViewModels = new List<BalanceFirstDurationViewModel>();

            EditBindingSource.DataSource = _BalanceFirstDurationViewModels;
            dgvArticles.DataSource = EditBindingSource;
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
        private void FillWithArticleName(string value)
        {
            Article result = DescriptionFK.ArticleExistsNameOrBarcode(value);
            if (result == null)
            {
                if (_MessageBoxDialog.Show("هل تريد اختيار صنف أو إضافة مادة جديدة ؟", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                {
                    result = ArticlePicker.PickArticale("", 0, FormOperation.Pick);
                    Article choosedres = DescriptionFK.ArticleExistsNameOrBarcode(result.Name);
                    if (result != null)
                    {
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
                var dataRow = (EditBindingSource.DataSource as BalanceFirstDurationViewModel);
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
        private void CalcTotal()
        {
            double total = 0;
            (EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>).ForEach(x => total += x.Total);
            TotalPrice = total;
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
                dgvArticles.Rows.RemoveAt(dgvArticles.Rows.Count - 1);
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
            if (status == "Edit")
            {
                btnOk.Select();

                try
                {
                    if (dgvArticles.CurrentRow.Cells["ExpiryDate"].Value == null || Convert.ToDateTime(dgvArticles.CurrentRow.Cells["ExpiryDate"].Value).Date <= DateTime.Now.Date)
                    {
                        _MessageBoxDialog.Show("تاريخ الصلاحية غير صحيح", MessageBoxState.Warning);
                        dgvArticles.CurrentCell = dgvArticles.CurrentRow.Cells["ExpiryDate"];
                        dgvArticles.BeginEdit(true);
                        return;
                    }

                    List<BalanceFirstDurationViewModel> mylist = new List<BalanceFirstDurationViewModel>();
                    mylist.Add(EditBindingSource.DataSource as BalanceFirstDurationViewModel);
                    CheckLastRow();
                    PriceTagService.SaveFirstTimeBalancePriceTag(EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>);
                    UpdateInventory(mylist, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, InvoiceKind.GoodFirstTime);
                    EditFirstTimeArticale(mylist);
                    UpdateEntry();
                    _MessageBoxDialog.Show("تم تعديل المادة بنجاح", MessageBoxState.Done);
                    this.Dispose();

                }
                catch (Exception ex)
                {
                    _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
                }
            }
            else
            {
                btnOk.Select();

                try
                {
                    CheckLastRow();
                    PriceTagService.SaveFirstTimeBalancePriceTag(EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>);
                    InventoryService.UpdateInventory(EditBindingSource.DataSource as List<BalanceFirstDurationViewModel>, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, InvoiceKind.GoodFirstTime);
                    _MessageBoxDialog.Show("تم تخزين الرصيد بنجاح", MessageBoxState.Done);
                    dgvArticles.Rows.Clear();

                    EditBindingSource.DataSource = new List<BalanceFirstDurationViewModel>();

                    dgvArticles.Refresh();
                }
                catch (Exception ex)
                {
                    _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
                }
            }

        }
        public static void UpdateInventory(List<BalanceFirstDurationViewModel> balanceFirstDurationViewModels, int branchId, int storeId, InvoiceKind invoiceKind)
        {
            foreach (var item in balanceFirstDurationViewModels)
            {
                UpdateInventory(item.ArticleId, branchId, storeId, item.UnitId, item.PriceTagId, item.Quantity, invoiceKind, item.ExpiryDate, item.Price);
            }
        }

        private static void UpdateInventory(int artId, int branchId, int storeId, int unitId, int priceTagId, int quantity, InvoiceKind invoiceKind, DateTime expiryDate, double purchasePrice)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var priceTag = context.PriceTagMasters.FirstOrDefault(x => x.Id == priceTagId);
            priceTag.CountAllItem = InventoryService.ConvertArticleUnitToSmallestUnit(artId, unitId, quantity);
            PriceTagDetail details = context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == priceTag.Id);
            context.PriceTagDetails.Remove(details);
            context.SaveChanges();
            priceTag.PriceTagDetails = ArticleService.MakeNewPriceTagDetailForArticle(artId, unitId, purchasePrice);
            priceTag.PriceTagDetails.FirstOrDefault().PriceTagMaster = priceTag;
            priceTag.PriceTagDetails.FirstOrDefault().PriceTagId = priceTag.Id;
            context.PriceTagMasters.Update(priceTag);
            context.SaveChanges();
        }
        private void UpdateEntry()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            context.EntryMasters.FirstOrDefault(x => x.Id == MyDetail.EntryMasterId).TotalCredit = Convert.ToInt32(dgvArticles.Rows[dgvArticles.Rows.Count - 1].Cells["total"].Value);
            context.EntryMasters.FirstOrDefault(x => x.Id == MyDetail.EntryMasterId).TotalDebit = Convert.ToInt32(dgvArticles.Rows[dgvArticles.Rows.Count - 1].Cells["total"].Value);
            context.EntryDetails.Where(x => x.Id == MyDetail.Id).FirstOrDefault().Debit = Convert.ToInt32(dgvArticles.Rows[dgvArticles.Rows.Count - 1].Cells["total"].Value);
            context.EntryDetails.Where(x => x.Id == MyDetail.Id - 1).FirstOrDefault().Credit = Convert.ToInt32(dgvArticles.Rows[dgvArticles.Rows.Count - 1].Cells["total"].Value);
            context.SaveChanges();
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
                    if (!DateTime.TryParseExact(DateValue, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateFormated) && !DateTime.TryParseExact(DateValue, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateFormated))
                    {
                        _MessageBoxDialog.Show("يجب ادخال تنسيق تاريخ صحيح", MessageBoxState.Error);
                        e.Cancel = true; // The important part
                        return;
                    }
                    else if (dgvArticles.Rows[e.RowIndex].Cells["ExpiryDate"].Value.ToString() == "01/01/0001 00:00:00" || dgvArticles.Rows[e.RowIndex].Cells["ExpiryDate"].Value.ToString() == null)
                    {
                        _MessageBoxDialog.Show("يرجى إدخال تاريخ صلاحية", MessageBoxState.Warning);
                        dgvArticles.Rows[e.RowIndex].Cells["ExpiryDate"].Value = "";
                        e.Cancel = true;
                        return;
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
            }
            catch (Exception ex)
            {
                ;
            }
        }
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void EditFirstTimeArticale(List<BalanceFirstDurationViewModel> mybalance)
        {
            FirstTimeArticles newArt = new FirstTimeArticles();
            foreach (var item in mybalance)
            {
                //newArt.id = item.ArticleId;
                newArt.UnitId = item.UnitId;
                newArt.Name = item.ArticleIdDescr;
                newArt.Price = item.Price;
                newArt.Quantity = item.Quantity;
                newArt.Expirydate = item.ExpiryDate;
            }
            Update(newArt);
        }
        public void Update(FirstTimeArticles myart)
        {
            int quant = myart.Quantity;
            int myprice = Convert.ToInt32(myart.Price);
            string myolddate = expiarydate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string dateString = myart.Expirydate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            int MyTotal = quant * myprice;
            SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("update FirstTimeArticles set Quantity = '" + quant + "' , Price='" + myprice + "',Total='" + MyTotal + "',ExpiryDate='" + dateString + "' WHERE name ='" + myart.Name + "'and Expirydate ='" + myolddate + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }
        private void dgvArticles_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
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
            if (headerText.Equals("Price") || headerText.Equals("Quantity") || headerText.Equals("Total") && (EditBindingSource.Current as BalanceFirstDurationViewModel).ArticleId != 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        }

        private void dgvArticles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvArticles.Columns[e.ColumnIndex].Name)
            {
                case "Column2":
                    _Rectangle = dgvArticles.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;
                    break;
            }
        }
        private void dgvArticles_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dgvArticles_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }
    }
}
