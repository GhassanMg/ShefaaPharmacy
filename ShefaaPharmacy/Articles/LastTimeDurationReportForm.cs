using DataLayer;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class LastTimeDurationReportForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public List<LastTimeArticleViewModel> _AllLastTimeArticales { get; set; }
        public List<FullPriceViewModel> _FullTotalPrice { get; set; }

        FullPriceViewModel FinalTotal = new FullPriceViewModel();
        public LastTimeDurationReportForm()
        {
            InitializeComponent();

            LoadGrid();
            dgMaster.AutoGenerateColumns = true;
            dgDetail.AutoGenerateColumns = true;
            var count = ShefaaPharmacyDbContext.GetCurrentContext().Articles.ToList().Count();
            if (count > 0)
            {
                LoadMaster();
                LoadDetail();
            }

            dgMaster.AllowUserToAddRows = false;
            dgDetail.AllowUserToAddRows = false;
            dgMaster.ReadOnly = true;
            dgDetail.ReadOnly = true;
            WindowState = FormWindowState.Maximized;
        }
        private void LoadGrid()
        {
            if (_AllLastTimeArticales == null)
            {
                _AllLastTimeArticales = new List<LastTimeArticleViewModel>();
            }
            if (_FullTotalPrice == null)
            {
                _FullTotalPrice = new List<FullPriceViewModel>();
            }

            bindingSourceMaster.DataSource = _AllLastTimeArticales;
            dgMaster.DataSource = bindingSourceMaster;

            bindingSourceDetail.DataSource = _FullTotalPrice;
            dgDetail.DataSource = bindingSourceDetail;
        }

        private void LoadMaster()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();

            List<Article> resultReport = context.Articles.ToList();
            List<LastTimeArticleViewModel> allarticles = new List<LastTimeArticleViewModel>();
            foreach (var item in resultReport)
            {
                if (!item.ItsGeneral)
                {
                    var lastPriceTage = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                    .Where(x => x.ArticleId == item.Id)
                    .Include(x => x.PriceTagDetails)
                    .OrderByDescending(x => x.CreationDate)
                    .LastOrDefault();

                    LastTimeArticleViewModel mynew = new LastTimeArticleViewModel();
                    mynew.ArticleId = item.Id;
                    mynew.Name = item.Name;
                    var Fullquantity = InventoryService.GetAllArticleAmountRemaningInAllPricesDouble(item.Id, context.ArticleUnits.FirstOrDefault(x => x.ArticleId == mynew.ArticleId && x.IsPrimary).UnitTypeId);
                    mynew.QuantityLeft = Math.Round(Fullquantity, 2);

                    if (mynew.QuantityLeft == 0) mynew.TotalPrice = 0;
                    else mynew.TotalPrice = Convert.ToInt32(lastPriceTage.PriceTagDetails.FirstOrDefault().BuyPrice * mynew.QuantityLeft);
                    mynew.UnitId = context.ArticleUnits.FirstOrDefault(x => x.IsPrimary && x.ArticleId == mynew.ArticleId).UnitTypeId;
                    mynew.UnitIdDescr = DescriptionFK.GetUnitName(mynew.UnitId);

                    mynew.CreationDate = item.CreationDate;
                    if (mynew.QuantityLeft == 0) continue;
                    allarticles.Add(mynew);
                }
            }
            bindingSourceMaster.DataSource = allarticles;
            Insert(allarticles);
        }
        public void Insert(List<LastTimeArticleViewModel> list)
        {
            SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);

            using (var copy = new SqlBulkCopy(ShefaaPharmacyDbContext.ConStr))
            {
                DataTable dt = new DataTable();
                copy.DestinationTableName = "dbo.LastTimeArticles";
                // Add mappings so that the column order doesn't matter
                copy.ColumnMappings.Add(nameof(LastTimeArticleViewModel.ArticleId), "ArticleId");
                copy.ColumnMappings.Add(nameof(LastTimeArticleViewModel.Name), "Name");
                copy.ColumnMappings.Add(nameof(LastTimeArticleViewModel.UnitId), "UnitId");
                copy.ColumnMappings.Add(nameof(LastTimeArticleViewModel.QuantityLeft), "QuantityLeft");
                copy.ColumnMappings.Add(nameof(LastTimeArticleViewModel.TotalPrice), "TotalPrice");
                copy.ColumnMappings.Add(nameof(LastTimeArticleViewModel.CreationDate), "CreationDate");

                dt = ToDataTable(list);
                copy.WriteToServer(dt);
            }
            con.Open();
            SqlCommand cmd = new SqlCommand("WITH CTE AS(SELECT *, ROW_NUMBER() OVER(PARTITION BY ArticleId ORDER BY id) AS RN FROM lasttimearticles)DELETE FROM CTE WHERE RN <> 1", con);
            cmd.ExecuteNonQuery();
            con.Close();
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

        private int calcTotalPriceForArticle(int ArticleId)
        {
            int TotalPrice = 0;
            return TotalPrice;
        }
        private void LoadDetail()
        {
            FullPriceViewModel FullPrice = new FullPriceViewModel();

            foreach (LastTimeArticleViewModel myrow in bindingSourceMaster)
            {
                FullPrice.FullPrice += myrow.TotalPrice * myrow.QuantityLeft;
            }
            bindingSourceDetail.DataSource = FullPrice;
            dgDetail.Refresh();
            
        }
        private void dgMaster_BindingContextChanged(object sender, EventArgs e)
        {
            dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.Refresh();
        }
        private void dgDetail_BindingContextChanged(object sender, EventArgs e)
        {
            dgDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.Refresh();
        }

        private void LastTimeDurationReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
