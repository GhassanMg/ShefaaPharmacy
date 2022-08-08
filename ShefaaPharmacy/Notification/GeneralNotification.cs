using DataLayer;
using DataLayer.Services;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
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

namespace ShefaaPharmacy.Notification
{
    public partial class GeneralNotification : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        public NotificationType _NotificationType { get; set; }
        public GeneralNotification()
        {
            InitializeComponent();
            ChangeStyleOfGrid(dgvNotification);
        }
        public GeneralNotification(NotificationType notificationType)
        {
            _NotificationType = notificationType;
            InitializeComponent();
            ChangeStyleOfGrid(dgvNotification);

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
        private void GeneralNotification_Load(object sender, EventArgs e)
        {
            pBottom.Visible = false;
            switch (_NotificationType)
            {
                case NotificationType.Quantity:
                    {
                        Text = "الكميات";
                        QuantityArticle();
                        break;
                    }
                case NotificationType.ExpiryDate:
                    {
                        Text = "تاريخ صلاحية المواد";
                        ExpiryDateArticle();
                        break;
                    }
                case NotificationType.UpdatePrices:
                    {
                        Text = "تحديث الأسعار";
                        UpdatePricesArticle();
                        break;
                    }
                default:
                    break;
            }
        }
        int count = 0;
        private void QuantityArticle()
        {

            //GeneralInvoiceEditForm gi = new GeneralInvoiceEditForm();
            List<QuantityLeftArticleViewModel> quantities = new List<QuantityLeftArticleViewModel>();
            List<QuantityLeftArticleViewModel> finalquents = new List<QuantityLeftArticleViewModel>();
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<PriceTagMaster> PriceTagsForArticleInStore = context.PriceTagMasters.Include(x => x.Article).ToList();
            PriceTagsForArticleInStore
                .Where(x => ((x.Article.LimitUp > 0) && (x.Article.LimitDown != 0)
                            && (InventoryService.GetAllArticleAmountRemaningInAllPrices(x.ArticleId, x.UnitId) >= x.Article.LimitUp))
                           || (InventoryService.GetAllArticleAmountRemaningInAllPrices(x.ArticleId, context.ArticleUnits.FirstOrDefault(s => s.ArticleId == x.ArticleId && s.IsPrimary).UnitTypeId) <= x.Article.LimitDown))
                .ToList();
            dgvNotification.Rows.Clear();
            dgvNotification.Refresh();
            List<int> Ids = new List<int>();
            foreach (var item in PriceTagsForArticleInStore)
            {
                if (Ids.Contains(item.ArticleId) == true) continue;
                Ids.Add(item.ArticleId);
                if (item.Article.LimitDown != 0 && item.Article.LimitUp != 0)
                {
                    if (Convert.ToDouble(item.Article.CountLeft) < item.Article.LimitDown || Convert.ToDouble(item.Article.CountLeft) > item.Article.LimitUp)
                    {
                        int QuantOfSmallest = Convert.ToInt32(InventoryService.GetAllArticleAmountRemaningInAllPrices(item.ArticleId, item.UnitId));
                        quantities.Add(
                        new QuantityLeftArticleViewModel()
                        {
                            ArticleId = item.ArticleId,
                            ArticleIdDescr = DescriptionFK.GetArticaleName(item.ArticleId),
                            ArticleLeftAsString = InventoryService.QuantityForPrimaryUnit(item.ArticleId, item.UnitId, QuantOfSmallest).ToString(),
                            ArticleMaxCount = item.Article.LimitUp,
                            ArticleMinCount = item.Article.LimitDown
                        });
                    }
                }
            }

            if (quantities.Count > 0)
            {
                for (int i = 0; i < quantities.Count; i++)
                {
                    if (i == 0) { finalquents.Add(quantities[i]); continue; }
                    else if (quantities[i].ArticleIdDescr == quantities[i - 1].ArticleIdDescr) continue;
                    else finalquents.Add(quantities[i]);
                }
                EditBindingSource.DataSource = finalquents;
                dgvNotification.AutoGenerateColumns = true;
                dgvNotification.DataSource = EditBindingSource;
                dgvNotification.Refresh();
            }
            else
            {
                dgvNotification.Visible = false;
                _MessageBoxDialog.Show("لا يوجد منتجات تخطت حدها الأعلى أو الأدنى للكمية", MessageBoxState.Warning);
                this.Close();
            }

        }
        private void ExpiryDateArticle()
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var dbConfig = context.DataBaseConfigurations.FirstOrDefault();
                List<PriceTagMaster> PriceTagsForArticleInStore = context.PriceTagMasters.Include(x => x.Article).ToList();
                List<PriceTagMaster> articles = PriceTagsForArticleInStore.Where(x => (DateTime.Now.AddDays(dbConfig.DayForExpiry) >= x.ExpiryDate)).ToList();
                List<PriceTagMaster> mylist = new List<PriceTagMaster>();
                List<PriceTagMaster> ExpiryList = new List<PriceTagMaster>();
                List<BillDetail> myprices = context.BillDetails.Include(x => x.Articale).ToList();

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
                    //Article=g.Key.Article,
                    ExpiryDate = g.Key.ExpiryDate,
                    ArticleId = g.Key.ArticleId, // join better than taking First()
                    CountAllItem = InventoryService.QuantityForPrimaryUnit(g.Key.ArticleId, g.Key.UnitId, g.Sum(i => i.CountAllItem - (i.CountSoldItem + i.CountGiftItem))),
                    UnitId = DescriptionFK.GetPrimaryUnit(g.Key.ArticleId)
                }).ToList();

                EditBindingSource.DataSource = mylist.Select(x => new { x.ArticleIdDescr,/* x.CreationDate,*/ x.UnitIdDescr, x.CountAllItem,/* Buy, sell,*/ x.ExpiryDate }).Where(x => x.CountAllItem != 0);
                dgvNotification.AutoGenerateColumns = true;
                dgvNotification.DataSource = EditBindingSource;
                dgvNotification.Columns["ArticleIdDescr"].HeaderText = "اسم المنتج";
                dgvNotification.Columns["UnitIdDescr"].HeaderText = "الواحدة";
                dgvNotification.Columns["CountAllItem"].HeaderText = "الكمية منتهية الصلاحية";
                dgvNotification.Columns["ExpiryDate"].HeaderText = "تاريخ انتهاء الصلاحية";
                dgvNotification.Columns.Add("LeftDays", "الأيام المتبقية");
                dgvNotification.Columns["UnitIdDescr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvNotification.Columns["CountAllItem"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvNotification.Columns["LeftDays"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvNotification.Refresh();
                CheckLeftDays();
            }
            catch
            {
                dgvNotification.Rows.Clear(); dgvNotification.Columns.Clear();
                _MessageBoxDialog.Show("لا يوجد منتجات تجاوزت تاريخ صلاحيتها", MessageBoxState.Warning);
                this.Close();
            }
        }
        private void CheckLeftDays()
        {
            int Ldays = 0;
            foreach (DataGridViewRow MyRow in dgvNotification.Rows)
            {
                Ldays = (int)(Convert.ToDateTime(MyRow.Cells["ExpiryDate"].Value) - DateTime.Now).TotalDays;
                if (Ldays <= 0)
                {
                    dgvNotification.Rows[MyRow.Index].Cells["LeftDays"].Value = 0;
                    dgvNotification.Rows[MyRow.Index].Cells["LeftDays"].Style.BackColor = Color.Red;
                }
                else
                {
                    dgvNotification.Rows[MyRow.Index].Cells["LeftDays"].Value = Ldays;
                    dgvNotification.Rows[MyRow.Index].Cells["LeftDays"].Style.BackColor = Color.Orange;
                }
            }
            dgvNotification.Refresh();
        }

        private void UpdatePricesArticle()
        {
            //var context = ShefaaPharmacyDbContext.GetCurrentContext();
            //var dbConfig = context.DataBaseConfigurations.FirstOrDefault();
            //List<PriceTag> PriceTagsForArticleInStore = context.PriceTags.Include(x => x.Articale).AsNoTracking().ToList();
            //List<PriceTag> articles = PriceTagsForArticleInStore.Where(x => (x.Articale.IsForeign && DateTime.Now >= x.CreationDate.AddDays(dbConfig.DateIfNotUpdatedExternal)) || (!x.Articale.IsForeign && DateTime.Now >= x.CreationDate.AddDays(dbConfig.DateIfNotUpdatedLocal))).ToList();
            //if (articles.Count > 0)
            //{
            //    EditBindingSource.DataSource = articles.Select(x => new { x.ArticaleIdDescr, x.CreationDate, x.UnitTypeIdDescr, x.BuyPrimary, x.SellPrimary, x.ExpiryDate });
            //    dgvNotification.AutoGenerateColumns = true;
            //    dgvNotification.DataSource = EditBindingSource;
            //    dgvNotification.Refresh();
            //}
            //else
            //{
            //    dgvNotification.Visible = false;
            //    _MessageBoxDialog.Show("لا يوجد منتجات تحتاج الى تحديث الأسعار", MessageBoxState.Warning);
            //}
        }
        public bool QuantityNotification()
        {
            try
            {
                //GeneralInvoiceEditForm gi = new GeneralInvoiceEditForm();
                List<QuantityLeftArticleViewModel> quantities = new List<QuantityLeftArticleViewModel>();
                List<QuantityLeftArticleViewModel> finalquents = new List<QuantityLeftArticleViewModel>();
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                List<PriceTagMaster> PriceTagsForArticleInStore = context.PriceTagMasters.Include(x => x.Article).ToList();
                PriceTagsForArticleInStore
                    .Where(x => ((x.Article.LimitUp > 0) && (x.Article.LimitDown != 0) && (InventoryService.GetQuantityOfArticleAllPriceTagInt(x.ArticleId, x.UnitId) >= x.Article.LimitUp))
                               ||
                               (InventoryService.GetAllArticleAmountRemaningInAllPrices(x.ArticleId, context.ArticleUnits.FirstOrDefault(s => s.ArticleId == x.ArticleId && s.IsPrimary).UnitTypeId) <= x.Article.LimitDown))
                    .ToList();
                dgvNotification.Rows.Clear();
                dgvNotification.Refresh();
                List<int> Ids = new List<int>();
                foreach (var item in PriceTagsForArticleInStore)
                {
                    if (Ids.Contains(item.ArticleId) == true) continue;
                    Ids.Add(item.ArticleId);
                    if (item.Article.LimitDown != 0 && item.Article.LimitUp != 0)
                    {
                        if (Convert.ToInt32(item.Article.CountLeft) < item.Article.LimitDown || Convert.ToInt32(item.Article.CountLeft) > item.Article.LimitUp)
                        {
                            quantities.Add(
                           new QuantityLeftArticleViewModel()
                           {
                               ArticleId = item.ArticleId,
                               ArticleIdDescr = DescriptionFK.GetArticaleName(item.ArticleId),
                               ArticleLeftAsString = InventoryService.GetAllArticleAmountRemaningInAllPrices(item.ArticleId, item.UnitId).ToString(),/*gi.tryquantitycalc(),/*" Unknown yet !!",/*InventoryService.GetAllArticleAmountRemaningInAllPrices(item.ArticleId, item.UnitTypeId).ToString(),*/
                               ArticleMaxCount = item.Article.LimitUp,
                               ArticleMinCount = item.Article.LimitDown
                           });
                        }
                    }
                }

                if (quantities.Count > 0)
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
        public bool ExpiryDateNotification()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            try
            {
                var dbConfig = context.DataBaseConfigurations.FirstOrDefault();
                List<PriceTagMaster> PriceTagsForArticleInStore = context.PriceTagMasters.Include(x => x.Article).ToList();
                List<PriceTagMaster> articles = PriceTagsForArticleInStore.Where(x => (DateTime.Now.AddDays(dbConfig.DayForExpiry) >= x.ExpiryDate)).ToList();
                List<PriceTagMaster> mylist = new List<PriceTagMaster>();
                List<PriceTagMaster> NewList = new List<PriceTagMaster>();

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
                mylist = mylist.GroupBy(i => new { i.ExpiryDate, i.ArticleId }).Select(g => new PriceTagMaster
                {
                    ExpiryDate = g.Key.ExpiryDate,
                    ArticleId = g.Key.ArticleId, // join better than taking First()
                    CountAllItem = g.Sum(i => i.CountAllItem - (i.CountSoldItem + i.CountGiftItem))
                }).ToList();
                int Count = mylist.Select(x => new { x.ArticleIdDescr,/* x.CreationDate,*/ x.UnitIdDescr, x.CountAllItem,/* Buy, sell,*/ x.ExpiryDate }).Where(x => x.CountAllItem != 0).Count();

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

        public bool UpdatePricesNotification()
        {
            //var context = ShefaaPharmacyDbContext.GetCurrentContext();
            //var dbConfig = context.DataBaseConfigurations.FirstOrDefault();
            //List<PriceTagMaster> PriceTagsForArticleInStore = context.PriceTagMasters.Include(x => x.Article).AsNoTracking().ToList();
            //List<PriceTagMaster> articles = PriceTagsForArticleInStore.Where(x => (x.Article.IsForeign && DateTime.Now >= x.CreationDate.AddDays(dbConfig.DateIfNotUpdatedExternal)) || (!x.Article.IsForeign && DateTime.Now >= x.CreationDate.AddDays(dbConfig.DateIfNotUpdatedLocal))).ToList();
            //if (articles.Count > 0)
            //{
            //    return true;
            //}
            //else
            //{
            return false;
            //}
        }
        private bool IsExist(List<PriceTagMaster> list, PriceTagMaster Current)
        {
            foreach (var item in list)
            {
                if (item.ArticleIdDescr == Current.ArticleIdDescr && item.ExpiryDate == Current.ExpiryDate) return true;
            }
            return false;
        }
        private void CheckDublicate()
        {
            for (int i = 0; i < dgvNotification.RowCount - 1; i++) //compare data
            {
                var Row = dgvNotification.Rows[i];
                string abc = Row.Cells["ArticleIdDescr"].Value.ToString() + Row.Cells["ExpiryDate"].Value.ToString().ToUpper();

                for (int j = i + 1; j < dgvNotification.RowCount; j++)
                {
                    var Row2 = dgvNotification.Rows[j];
                    string def = Row2.Cells["ArticleIdDescr"].Value.ToString() + Row2.Cells["ExpiryDate"].Value.ToString().ToUpper();
                    if (abc == def)
                    {
                        int sum = (int)Row.Cells["CountAllItem"].Value + (int)Row2.Cells["CountAllItem"].Value;
                        Row.Cells["CountAllItem"].Value = sum.ToString();
                        dgvNotification.Rows.Remove(Row2);
                        j--;
                    }
                }
            }
            dgvNotification.Refresh();
        }
    }
}

