using DataLayer;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class TransfeerExpiryArticlesToStore : AbstractForm
    {
        List<ExpiryTransfeerDetail> TransfeerList = new List<ExpiryTransfeerDetail>();
        public TransfeerExpiryArticlesToStore()
        {
            InitializeComponent();
            ChangeStyleOfGrid(dgMaster);

        }
        private void ExpireArticlesReport_Load(object sender, EventArgs e)
        {
            pHelperButton.Location = new Point(this.Size.Width - pHelperButton.Width, 7);
            GetExpiredArticle();

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
        void EditGridStyle()
        {
            dgMaster.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
            dgMaster.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.ReadOnly = true);

            dgMaster.Columns["ArticleIdDescr"].Visible = true;
            dgMaster.Columns["UnitIdDescr"].Visible = true;
            dgMaster.Columns["CountAllItem"].Visible = true;
            dgMaster.Columns["ExpiryDate"].Visible = true;

            dgMaster.Columns["ArticleIdDescr"].HeaderText = "اسم المنتج";
            dgMaster.Columns["UnitIdDescr"].HeaderText = "الواحدة";
            dgMaster.Columns["CountAllItem"].HeaderText = "الكمية منتهية الصلاحية";
            dgMaster.Columns["ExpiryDate"].HeaderText = "تاريخ انتهاء الصلاحية";
            dgMaster.Columns.Add("TransfeerQuantity", "الكمية المراد ترحيلها");
            dgMaster.Columns.Add("LeftDays", "الأيام المتبقية");
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "ترحيل للمخزن";
            checkBoxColumn.Name = "Checked";
            dgMaster.Columns.Insert(dgMaster.Columns.Count, checkBoxColumn);

            dgMaster.Columns["TransfeerQuantity"].ReadOnly = false;
            dgMaster.Columns["Checked"].ReadOnly = false;
            dgMaster.Columns["UnitIdDescr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["CountAllItem"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["LeftDays"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["Checked"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["TransfeerQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            FillTransQuant();
        }
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void FillTransQuant()
        {
            foreach (DataGridViewRow item in dgMaster.Rows)
            {
                try
                {
                    dgMaster.Rows[item.Index].Cells["TransfeerQuantity"].Value = dgMaster.Rows[item.Index].Cells["CountAllItem"].Value;
                }
                catch
                {
                    dgMaster.Rows[item.Index].Cells["TransfeerQuantity"].Value = "0";
                }
            }
        }

        List<PriceTagMaster> mylist = new List<PriceTagMaster>();
        private void GetExpiredArticle()
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var dbConfig = context.DataBaseConfigurations.FirstOrDefault();
                List<PriceTagMaster> PriceTagsForArticleInStore = context.PriceTagMasters.Include(x => x.Article).ToList();
                List<PriceTagMaster> articles = PriceTagsForArticleInStore.Where(x => (DateTime.Now.AddDays(dbConfig.DayForExpiry) >= x.ExpiryDate)).ToList();

                for (int i = 0; i < articles.Count; i++)
                {
                    if (articles[i].ExpiryDate == DateTime.Parse("01/01/0001"))
                    {
                        continue;
                    }
                    else
                    {

                        mylist.Add(articles[i]);
                    }
                }
                mylist = mylist.GroupBy(i => new { i.ExpiryDate, i.ArticleId, i.UnitId }).Select(g => new PriceTagMaster
                {
                    ExpiryDate = g.Key.ExpiryDate,
                    ArticleId = g.Key.ArticleId, // join better than taking First()
                    CountAllItem = InventoryService.QuantityForPrimaryUnit(g.Key.ArticleId, g.Key.UnitId, g.Sum(i => i.CountAllItem - (i.CountSoldItem + i.CountGiftItem))),
                    UnitId = DescriptionFK.GetPrimaryUnit(g.Key.ArticleId)
                }).ToList();

                var bindingList = new BindingList<PriceTagMaster>();
                foreach (var item in mylist)
                {
                    if (item.CountAllItem != 0)
                    {
                        var lastPriceTage = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                                            .Where(x => x.ArticleId == item.ArticleId && x.ExpiryDate == item.ExpiryDate)
                                            .Include(x => x.PriceTagDetails)
                                            .OrderByDescending(x => x.CreationDate)
                                            .LastOrDefault();
                        item.Id = lastPriceTage.Id;
                        bindingList.Add(item);
                    }

                }
                dgMaster.DataSource = bindingList;

                EditGridStyle();

                dgMaster.Refresh();
                CheckLeftDays();
            }
            catch
            {
                dgMaster.Rows.Clear(); dgMaster.Columns.Clear();
                _MessageBoxDialog.Show("لا يوجد منتجات تجاوزت تاريخ صلاحيتها", MessageBoxState.Warning);
                this.Close();
            }
        }
        private void CheckLeftDays()
        {
            int Ldays = 0;
            foreach (DataGridViewRow MyRow in dgMaster.Rows)
            {
                Ldays = (int)(Convert.ToDateTime(MyRow.Cells["ExpiryDate"].Value) - DateTime.Now).TotalDays;
                if (Ldays <= 0)
                {
                    dgMaster.Rows[MyRow.Index].Cells["LeftDays"].Value = 0;
                    dgMaster.Rows[MyRow.Index].Cells["LeftDays"].Style.BackColor = Color.Red;
                }
                else
                {
                    dgMaster.Rows[MyRow.Index].Cells["LeftDays"].Value = Ldays;
                    dgMaster.Rows[MyRow.Index].Cells["LeftDays"].Style.BackColor = Color.Orange;
                }
            }
            dgMaster.Refresh();
        }
        private List<ExpiryArticlesPriceTag> ConvertToList()
        {
            List<ExpiryArticlesPriceTag> NewPrice = new List<ExpiryArticlesPriceTag>();
            foreach (DataGridViewRow item in dgMaster.Rows)
            {
                if (Convert.ToBoolean(item.Cells["Checked"].Value))
                {
                    NewPrice.Add(new ExpiryArticlesPriceTag
                    {
                        MyPriceTag = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.FirstOrDefault(x => x.Id == Convert.ToInt32(dgMaster.Rows[item.Index].Cells["Id"].Value)),
                        Quantity = Convert.ToInt32(dgMaster.Rows[item.Index].Cells["TransfeerQuantity"].Value)
                    });
                }
            }
            return NewPrice;
        }
        private void btOk_Click(object sender, EventArgs e)
        {
            btOk.Select();
            try
            {
                if (dgMaster.Rows.Count != 0)
                {
                    UpdateInventoryForExpiryArticles();
                    SaveEntryDetailWithArticle();
                    _MessageBoxDialog.Show("تم التحويل بنجاح", MessageBoxState.Done);
                    this.Close();
                    ExpiryAerticlesStore frm = new ExpiryAerticlesStore();
                    frm.ShowDialog();
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حدثت مشكلةأثناءالتحويل", MessageBoxState.Error);
                return;
            }
        }
        private void SetExpiryEntry(double BuyPrice, int Quantity)
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            double Price = Quantity * BuyPrice;
            try
            {
                EntryMaster entryMaster = EntryService.MakeEntryMaster(0, Price, Price, KindOperation.Expired);
                entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                entryMaster.EntryDetails = new List<EntryDetail>();
                entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(20, Price, 0, kindOperation: KindOperation.Expired, 0, "مواد منتهية الصلاحية"));
                entryMaster.EntryDetails.Add(EntryService.MakeEntryDetail(14, 0, Price, kindOperation: KindOperation.Expired, 0, "المشتريات"));

                context.EntryMasters.Add(entryMaster);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        void SaveEntryDetailWithArticle()
        {
            List<ExpiryTransfeerDetail> Mylist = new List<ExpiryTransfeerDetail>();
            foreach (DataGridViewRow Row in dgMaster.Rows)
            {
                if (Convert.ToBoolean(Row.Cells["Checked"].Value))
                {
                    Mylist.Add(new ExpiryTransfeerDetail()
                    {
                        ArticleIdDescr = Row.Cells["ArticleIdDescr"].Value.ToString(),
                        UnitIdDescr = Row.Cells["UnitIdDescr"].Value.ToString(),
                        LeftQuantity = Convert.ToInt32(Row.Cells["CountAllItem"].Value),
                        ExpiryDate = Convert.ToDateTime(Row.Cells["ExpiryDate"].Value),
                        TransQuantity = Convert.ToInt32(Row.Cells["TransfeerQuantity"].Value)
                    });
                }
            }
            Insert(Mylist);
        }
        public void Insert(List<ExpiryTransfeerDetail> list)
        {
            using (var copy = new SqlBulkCopy(ShefaaPharmacyDbContext.ConStr))
            {
                DataTable dt = new DataTable();
                copy.DestinationTableName = "dbo.ExpiryTransfeerDetail";
                // Add mappings so that the column order doesn't matter
                copy.ColumnMappings.Add(nameof(ExpiryTransfeerDetail.ArticleIdDescr), "ArticleIdDescr");
                copy.ColumnMappings.Add(nameof(ExpiryTransfeerDetail.UnitIdDescr), "UnitIdDescr");
                copy.ColumnMappings.Add(nameof(ExpiryTransfeerDetail.LeftQuantity), "LeftQuantity");
                copy.ColumnMappings.Add(nameof(ExpiryTransfeerDetail.ExpiryDate), "ExpiryDate");
                copy.ColumnMappings.Add(nameof(ExpiryTransfeerDetail.TransQuantity), "TransQuantity");

                dt = ToDataTable(list);
                copy.WriteToServer(dt);
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
        void UpdateInventoryForExpiryArticles()
        {
            List<ExpiryArticlesPriceTag> MyNewList = ConvertToList();

            foreach (var item in MyNewList)
            {
                item.MyPriceTag.PriceTagDetails = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagDetails.Where(x => x.PriceTagId == item.MyPriceTag.Id).ToList();
                int unitid = DescriptionFK.GetPrimaryUnit(item.MyPriceTag.ArticleId);
                UpdateInventoryExpiry(item.MyPriceTag.ArticleId, unitid, item.MyPriceTag.Id, item.Quantity, InvoiceKind.ExpiryArticles, DateTime.Now, item.MyPriceTag.PriceTagDetails.FirstOrDefault().BuyPrice);
                SetExpiryEntry(item.MyPriceTag.PriceTagDetails.FirstOrDefault().BuyPrice, item.Quantity);
            }
        }

        public static void UpdateInventoryExpiry(int artId, int unitId, int priceTagId, int quantity, InvoiceKind invoiceKind, DateTime expiryDate, double purchasePrice)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var priceTag = context.PriceTagMasters.FirstOrDefault(x => x.Id == priceTagId);
            if (invoiceKind == InvoiceKind.ExpiryArticles)
            {
                var quantitySmallest = InventoryService.ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                if (quantitySmallest > (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem)
                {
                    var quantity1 = (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem;
                    var res = quantitySmallest - quantity1;

                    priceTag.CountSoldItem += quantity1;
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();

                    var nextPriceTag = context.PriceTagMasters.Where(x => x.ArticleId == artId && ((x.CountGiftItem + x.CountAllItem) > x.CountSoldItem)).OrderBy(x => x.ExpiryDate).ToList();
                    foreach (var item in nextPriceTag)
                    {
                        if (res != 0)
                        {
                            if (res > (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem)
                            {
                                res -= (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                item.CountSoldItem += (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                            }
                            else
                            {
                                item.CountSoldItem += res;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    priceTag.CountSoldItem += InventoryService.ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (_MessageBoxDialog.Show("هل تريد فعلا إلغاء كل ما أجري من تعديلات ؟", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                Close();
        }

        private void dgMaster_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgMaster.CurrentRow.DataBoundItem == null)
                return;
            var cell = dgMaster[e.ColumnIndex, e.RowIndex];
            string cellName = cell.OwningColumn.Name;
            if ((cellName == "TransfeerQuantity") && (e.FormattedValue.ToString() != "") && Convert.ToInt32(e.FormattedValue) > Convert.ToInt32(dgMaster.Rows[e.RowIndex].Cells["CountAllItem"].Value))
            {
                e.Cancel = true;
                _MessageBoxDialog.Show("لايمكن ترحيل كمية أكبر من الكمية الموجودة", MessageBoxState.Error);
                cell.Value = "0";
                return;
            }
        }
        private void dgMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dgMaster.CurrentCell.ColumnIndex;
            string headerText = dgMaster.Columns[column].Name;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (headerText.Equals("TransfeerQuantity"))
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
