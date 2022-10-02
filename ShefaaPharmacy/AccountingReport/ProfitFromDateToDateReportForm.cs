using DataLayer;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace ShefaaPharmacy.AccountingReport
{
    public partial class ProfitFromDateToDateReportForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        UserParameters userParameters;
        int[] SumRows = new int[] { 0, 4, 5, 8 };
        public ProfitFromDateToDateReportForm()
        {
            InitializeComponent();
            userParameters = ReportParametersForm.ReportParameterProfitFromDateToDate(new UserParameters());
            if (userParameters == null)
            {
                Load += (s, e) => Close();
                return;
            }
            else
            {
                LoadMaster();
                dgMaster.AutoGenerateColumns = true;
                dgMaster.AllowUserToAddRows = false;
                dgMaster.ReadOnly = true;
            }
        }
        public ProfitFromDateToDateReportForm(UserParameters userParameters)
        {
            InitializeComponent();
            this.userParameters = userParameters;
            if (userParameters == null)
            {
                Load += (s, e) => Close();
                return;
            }
            else
            {
                LoadMaster();
                dgMaster.AutoGenerateColumns = true;
                dgMaster.AllowUserToAddRows = false;
                dgMaster.ReadOnly = true;
            }
        }
        public void RebindLastTimeArts()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();

            List<Article> resultReport = context.Articles.ToList();
            List<LastTimeArticleViewModel> allarticles = new List<LastTimeArticleViewModel>();
            List<int> ToRemoveIds = new List<int>();
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
                    mynew.QuantityLeft = Math.Round(Fullquantity, 2).ToString();
                    if (mynew.QuantityLeft == "0")
                    {
                        mynew.TotalPrice = 0;
                    }
                    else mynew.TotalPrice = Convert.ToInt32(lastPriceTage.PriceTagDetails.FirstOrDefault().BuyPrice * Convert.ToDouble(mynew.QuantityLeft));
                    mynew.UnitId = context.ArticleUnits.FirstOrDefault(x => x.IsPrimary && x.ArticleId == mynew.ArticleId).UnitTypeId;
                    mynew.UnitIdDescr = DescriptionFK.GetUnitName(mynew.UnitId);

                    mynew.CreationDate = item.CreationDate;
                    if (mynew.QuantityLeft == "0") continue;
                    allarticles.Add(mynew);
                }
            }

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
            SqlCommand cmd = new SqlCommand("WITH CTE AS(SELECT *, ROW_NUMBER() OVER(PARTITION BY ArticleId ORDER BY id Desc) AS RN FROM lasttimearticles)DELETE FROM CTE WHERE RN <> 1", con);
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
        private void LoadMaster()
        {
            RebindLastTimeArts();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", userParameters.FromDate),
                new SqlParameter("@ToDate", userParameters.ToDate)
            };
            parameters[0].Value = Convert.ToDateTime(parameters[0].Value).AddDays(-1);
            parameters[1].Value = Convert.ToDateTime(parameters[1].Value).AddDays(+1);

            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetProfitFromDateToDate",
                                                parameters.ToArray());

            List<GetProfitFromDateToDateViewModel> resultReport = DataBaseService.ConvertDataTable<GetProfitFromDateToDateViewModel>(result);
            bindingSourceMaster.DataSource = resultReport;
            bindingNavigator1.BindingSource = bindingSourceMaster;
        }

        private int GetTotalLastTimeArticles()
        {
            try
            {
                int len = 0;
                int[] MyIds = GetExpiredTimeArticles().ToArray();
                string IDS = string.Join(",", MyIds);
                SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
                con.Open();
                SqlCommand cmd = new SqlCommand(string.Format("select Debit as Total FROM dbo.EntryDetail where AccountId =20", IDS), con);
                cmd.CommandType = CommandType.Text;
                int T = Convert.ToInt32(cmd.ExecuteScalar());
                return T;
            }
            catch
            {
                return 0;
            }
        }
        private List<int> GetExpiredTimeArticles()
        {
            List<int> IdList = new List<int>();

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
                        if (i == 0)
                        {
                            IdList.Add(articles[i].ArticleId);
                            continue;
                        }
                        else
                        {
                            if (articles[i].ArticleIdDescr == articles[i - 1].ArticleIdDescr)
                            {
                                continue;
                            }
                            else
                            {
                                IdList.Add(articles[i].ArticleId);
                            }
                        }
                    }
                }
                return IdList;
            }
            catch
            {
                IdList.Clear();
                return IdList;
            }
        }
        private void ProfitFromDateToDateReportForm_Load(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void DgMaster_BindingContextChanged(object sender, System.EventArgs e)
        {
            dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.Refresh();
        }

        private void TsRefresh_Click(object sender, System.EventArgs e)
        {
            LoadMaster();
        }

        private void TsReset_Click(object sender, System.EventArgs e)
        {
            var oldUserParameter = userParameters;
            userParameters = ReportParametersForm.ReportParameterProfitFromDateToDate(new UserParameters());
            if (userParameters != null)
            {
                LoadMaster();
            }
            else
            {
                userParameters = oldUserParameter;
            }
        }
        private void DgMaster_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (SumRows.Contains(e.RowIndex))
            {
                dgMaster.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LimeGreen;
                dgMaster.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }
}
