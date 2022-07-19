using DataLayer;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ShefaaPharmacy.GeneralUI;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ShefaaPharmacy.Articles
{

    public partial class UpdatePriceOnlineEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        List<Article> Articles { set; get; }
        List<Article> SelectedArticles;
        string status;
        public UpdatePriceOnlineEditForm(string status)
        {
            this.status = status;
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = new List<CompanyApiViewModel>();
            dataGridView1.Refresh();

            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.Refresh();

            button1.Enabled = false;
            ChangeStyleOfGrid(dataGridView2);
            ChangeStyleOfGrid(dataGridView1);
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
        private void UpdatePriceOnlineEditForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            pBottom.Visible = false;
            dataGridView1.Columns[0].ReadOnly = true;
        }
        int count = 0;
        private void button2_Click(object sender, EventArgs e)
        {

            count++;
            if (count % 2 != 0)
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    Convert.ToBoolean(item.Cells["checkBoxColumn"].Value = true);
                }
            else
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["checkBoxColumn"].Value) == true)
                    {
                        Convert.ToBoolean(item.Cells["checkBoxColumn"].Value = false);
                    }
                }
            dataGridView1.Refresh();
        }
        public StreamWriter outputStream;

        private ApiResponseViewModel<CompanyApiViewModel> GetRESTData(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            var x = JsonConvert.DeserializeObject<ApiResponseViewModel<CompanyApiViewModel>>(s);
            return x;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (status == "online")
            {
                if (dataGridView1.DataSource != null && (dataGridView1.DataSource as List<CompanyApiViewModel>).Count == 0)
                {
                    dataGridView1.DataSource = GetRESTData("http://lamsetshefaa-desktop.lamsetshefaa.com/api/company/all").data;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
                    button1.Enabled = true;
                    button3.Enabled = false;
                }
            }
            else
            {
                if (dataGridView1.DataSource != null && (dataGridView1.DataSource as List<CompanyApiViewModel>).Count == 0)
                {
                    SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);//connection name

                    SqlCommand cmd = new SqlCommand("select distinct company as الشركة from Medicines ", con);
                    con.Open();

                    SqlCommand IfEmpty = new SqlCommand("Select count(name) from Medicines", con);
                    int res = System.Convert.ToInt32(IfEmpty.ExecuteScalar());
                    
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds, "Medicines");

                    if (res == 0)
                    {

                        if (_MessageBoxDialog.Show("لم يتم استيراد قائمة المواد من ملف الاكسل..يرجى الاستيراد اولاً", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                        {
                            return;
                        }
                    }
                    else
                    {

                        dataGridView1.DataSource = ds.Tables["Medicines"];
                        dataGridView1.Columns[0].ReadOnly = true;
                        this.dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
                        dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;

                        button1.Enabled = true;
                        try
                        {
                            if (dataGridView1.Columns.Contains("checkBoxColumn") == true)
                            {
                                dataGridView1.Columns.Remove("checkBoxColumn");
                            }
                            else
                            {
                                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                                checkBoxColumn.HeaderText = "استيراد";
                                checkBoxColumn.Width = 30;
                                checkBoxColumn.Name = "checkBoxColumn";
                                dataGridView1.Columns.Insert(1, checkBoxColumn);
                            }
                        }
                        catch
                        {

                        }
                        dataGridView1.Refresh();
                    }
                }
            }
        }
        int mycount = 0;
        private async void Upload(string actionUrl)
        {
            List<string> companys = new List<string>();
            MultipartFormDataContent formContent = new MultipartFormDataContent();
            int i = 0;
            foreach (var item in dataGridView1.DataSource as List<CompanyApiViewModel>)
            {
                if (item.Checked)
                {
                    formContent.Add(new StringContent(item.Name), "company_names[" + i + "]");
                    i++;
                }
            }

            var myHttpClient = new HttpClient();
            var response = await myHttpClient.PostAsync(actionUrl.ToString(), formContent);
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            string stringContent = await response.Content.ReadAsStringAsync();
            //MessageBox.Show(stringContent);
            var x = JsonConvert.DeserializeObject<ApiResponseViewModel<ArticleApiViewModel>>(stringContent);
            List<ArticleApiViewModel> existarticale = new List<ArticleApiViewModel>();
            
            var articles = (dataGridView2.DataSource as List<ArticleApiViewModel>);
            foreach (var item in x.data)
            {

                mycount++;
                var rowFound = context.Articles.FirstOrDefault(s => s.Name == item.name
                                 && s.Caliber == item.caliber
                                 &&s.CompanyId == context.Companys.FirstOrDefault(e=>e.Name == item.company_id_descr).Id
                                 && s.FormatId == DescriptionFK.FormatExistsAndCreate(item.format_id_descr.ToString()).Id);
                if (rowFound != null)
                {
                    existarticale.Add(item);
                    item.Checked = true;
                }
                else
                {
                    continue;
                }

            }
            if (existarticale.Count == 0)
                _MessageBoxDialog.Show("لا يوجد أدوية للشركة المحددة في المخزن", MessageBoxState.Warning);
            else
            {
                dataGridView2.DataSource = existarticale;
                dataGridView2.Columns["Description"].Visible = false;
                dataGridView2.Columns["Description2"].Visible = false;
                dataGridView2.Columns["dosage"].Visible = false;
                dataGridView2.Columns["english_name"].Visible = false;
                dataGridView2.Columns["interactions"].Visible = false;
                dataGridView2.Columns["note"].Visible = false;
                dataGridView2.Columns["note2"].Visible = false;
                dataGridView2.Columns["precautions"].Visible = false;
                dataGridView2.Columns["side_effects"].Visible = false;
                dataGridView2.Columns["scientific_name"].Visible = false;
                dataGridView2.Columns["barcode"].Visible = false;
                dataGridView2.Columns["active_ingredients"].Visible = false;
                dataGridView2.Columns["size"].Visible = false;
                dataGridView2.Columns["company_id_descr"].DisplayIndex = 3;


                dataGridView2.Columns["Name"].ReadOnly = true;
                dataGridView2.Columns["company_id_descr"].ReadOnly = true;
                dataGridView2.Columns["scientific_name"].ReadOnly = true;
                dataGridView2.Columns["caliber"].ReadOnly = true;
                dataGridView2.Columns["format_id_descr"].ReadOnly = true;
                dataGridView2.Columns["BuyPrice"].ReadOnly = true;
                dataGridView2.Columns["SellPrice"].ReadOnly = true;
            }
        }
        /// <summary>
        /// Update All Prices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button4_Click(object sender, EventArgs e)
        {
            if (status == "online")
            {
                SelectedArticles = new List<Article>();
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                if ((dataGridView2.DataSource as List<ArticleApiViewModel>).Count > 0)
                {
                    var articles = (dataGridView2.DataSource as List<ArticleApiViewModel>);
                    foreach (var item in articles)
                    {
                        var rowFound = context.Articles.FirstOrDefault(x => x.Name == item.name
                                         && x.Caliber == item.caliber
                                         && x.FormatId == DescriptionFK.FormatExistsAndCreate(item.format_id_descr.ToString()).Id);
                        if (item.Checked)
                        {

                            if (rowFound != null)
                            {
                                PriceTagMaster price = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                                .Where(x => x.ArticleId == rowFound.Id)
                                .Include(x => x.PriceTagDetails)
                                .OrderByDescending(x => x.CreationDate)
                                .LastOrDefault();
                                button4.Enabled = false; lblLoading.Visible = true; dataGridView2.Enabled = false;
                                await Task.Run(() => UpdateCurrentPrice(price, rowFound.Id, item.BuyPrice, item.SellPrice));
                            }
                        }
                    }
                    _MessageBoxDialog.Show("تم تحديث أسعار المواد المحددة", MessageBoxState.Done);
                    button4.Enabled = true; lblLoading.Visible = false; dataGridView2.Enabled = true;
                }
            }
            else
            {
                SelectedArticles = new List<Article>();
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (dataGridView2.Rows.Count != 0)
                {
                    //var articles = (dataGridView2.DataSource as List<Medicine>);
                    foreach (DataGridViewRow item in dataGridView2.Rows)
                    {
                        var rowFound = context.Articles.FirstOrDefault(s => s.Name == item.Cells["الاسم"].Value.ToString());

                        if (Convert.ToBoolean(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells["checkBoxColumn"].Value) == true)
                        {
                            if (rowFound != null)
                            {
                                PriceTagMaster price = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                                .Where(x => x.ArticleId == rowFound.Id)
                                .Include(x => x.PriceTagDetails)
                                .OrderByDescending(x => x.CreationDate)
                                .LastOrDefault();
                                button4.Enabled = false; lblLoading.Visible = true; dataGridView2.Enabled = false;
                                await Task.Run(() => UpdateCurrentPrice(price, rowFound.Id, Convert.ToDouble(item.Cells["سعر_الشراء"].Value),
                                                                                            Convert.ToDouble(item.Cells["سعر_المبيع"].Value)));

                            }
                        }
                    }
                    _MessageBoxDialog.Show("تم تحديث أسعار المواد المحددة", MessageBoxState.Done);
                    button4.Enabled = true; lblLoading.Visible = false; dataGridView2.Enabled = true;
                }
            }
        }
        public void UpdateCurrentPrice(PriceTagMaster priceTagMaster,int ArticleId,double BuyPrice,double SellPrice)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<ArticleUnits> articleUnits = context.ArticleUnits.Where(x => x.ArticleId == ArticleId).ToList();
            PriceTagMaster editprice = context.PriceTagMasters.FirstOrDefault(x => x.Id == priceTagMaster.Id);
            editprice.PriceTagDetails = priceTagMaster.PriceTagDetails;
            List<PriceTagDetail> mylist = new List<PriceTagDetail>();
            foreach (PriceTagDetail item in editprice.PriceTagDetails)
            {
                int UnitId = context.ArticleUnits.Where(x => x.ArticleId == ArticleId && x.IsPrimary == true).FirstOrDefault().UnitTypeId;
                if (item.UnitId == UnitId)
                {
                    item.BuyPrice = Convert.ToInt32(BuyPrice);
                    item.SellPrice = Convert.ToInt32(SellPrice);
                    mylist.Add(item);
                }
                else
                {
                    int quantityofprimary = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == ArticleId && x.UnitTypeId == item.UnitId).QuantityForPrimary;
                    if (item.UnitId > UnitId)
                    {
                        item.BuyPrice = Convert.ToInt32(BuyPrice) / quantityofprimary;
                        item.SellPrice = Convert.ToInt32(SellPrice) / quantityofprimary;
                    }
                    else if (item.UnitId < UnitId)
                    {
                        item.BuyPrice = Convert.ToInt32(BuyPrice) * quantityofprimary;
                        item.SellPrice = Convert.ToInt32(SellPrice) * quantityofprimary;
                    }
                    mylist.Add(item);
                }
            }
            editprice.PriceTagDetails = mylist;
            context.PriceTagMasters.Update(editprice);
            context.SaveChanges();

        }
        public List<ArticleUnits> DefinedArticleUnit()
        {
            List<ArticleUnits> articleUnits = new List<ArticleUnits>();
            articleUnits.Add(
                new ArticleUnits()
                {
                    IsPrimary = true,
                    QuantityForPrimary = 0,
                    UnitTypeId = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.FirstOrDefault(x => x.Name == "علبة").Id
                });
            return articleUnits;
        }
        public void DefinedPriceTagMaster(int artId, double sellPrice, double buyPrice)
        {
            PriceTagMaster PriceTagMasters = new PriceTagMaster()
            {
                ArticleId = artId,
                UnitId = InventoryService.GetSmallestArticleUnit(artId),
                CountGiftItem = 0,
                CountSoldItem = 0,
                CountAllItem = 0,
                BranchId = UserLoggedIn.User.BranchId,
                ExpiryDate = DateTime.Now.AddYears(2),
                PriceTagDetails = ArticleService
                                            .MakeNewPriceTagDetailForArticle(
                                                    artId,
                                                    InventoryService.GetBaseArticleUnit(artId),
                                                    Convert.ToInt32(buyPrice),
                                                    Convert.ToInt32(sellPrice), 0),
            };
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            context.PriceTagMasters.Add(PriceTagMasters);
            context.SaveChanges();

        }
        int press = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (status == "online")
            {
                Upload("http://lamsetshefaa-desktop.lamsetshefaa.com/api/articles/by/company-names");
                press++;
            }
            else
            {

                press++;

                int count = 0;
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                List<string> companys = new List<string>();
                List<DataGridViewRow> existarticale = new List<DataGridViewRow>();

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["checkBoxColumn"].Value) == true)
                    {
                        count++;
                        if (count > 1)
                        {
                            _MessageBoxDialog.Show("يرجى تحديث مواد كل شركة على حدة..سيتم تحديد الشركة الأخيرة", MessageBoxState.Warning);
                            break;
                        }
                        else
                            companys.Add(item.Cells[0].Value.ToString());

                    }
                }

                SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);//connection name

                con.Open();
                DataTable dt = new DataTable();
                List<int> toremove = new List<int>();
                List<Medicine> mymodel = new List<Medicine>();
                foreach (string item in companys)
                {

                    SqlCommand cmd = new SqlCommand("select name as الاسم,company as الشركة,scientific_name as التركيب,caliber as العيار,format_id_descr as الشكل_الصيدلاني,BuyPrice as سعر_الشراء,SellPrice as سعر_المبيع,barcode from Medicines where company='" + item + "'", con);
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds, "Medicines");
                    //dt = ds.Tables["Medicines"];
                    dataGridView2.DataSource = ds.Tables["Medicines"];
                    dataGridView2.Columns["الاسم"].ReadOnly = true;
                    dataGridView2.Columns["الشركة"].ReadOnly = true;
                    dataGridView2.Columns["التركيب"].ReadOnly = true;
                    dataGridView2.Columns["العيار"].ReadOnly = true;
                    dataGridView2.Columns["الشكل_الصيدلاني"].ReadOnly = true;
                    dataGridView2.Columns["سعر_الشراء"].ReadOnly = true;
                    dataGridView2.Columns["سعر_المبيع"].ReadOnly = true;
                    dataGridView2.Columns["barcode"].ReadOnly = true;

                }
                foreach (DataGridViewRow f in dataGridView2.Rows)
                {
                    var rowFound = context.Articles.FirstOrDefault(s => s.Name == f.Cells["الاسم"].Value.ToString()
                             && s.Caliber == f.Cells["العيار"].Value.ToString() /*format_id_descr*/
                             && s.FormatId == DescriptionFK.FormatExistsAndCreate(f.Cells["الشكل_الصيدلاني"].Value.ToString()).Id);

                    if (rowFound == null)
                    {
                        dataGridView2.Rows.Remove(f);
                    }
                }
                if (dataGridView2.Rows.Count == 0)
                    _MessageBoxDialog.Show("لا يوجد أدوية للشركة المحددة في المخزن", MessageBoxState.Warning);
                else
                {

                }

                if (dataGridView2.Columns.Count < 9 && dataGridView2.Rows.Count != 0)
                {
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                    checkBoxColumn.HeaderText = "استيراد";
                    checkBoxColumn.Width = 10;
                    checkBoxColumn.Name = "checkBoxColumn";
                    dataGridView2.Columns.Insert(8, checkBoxColumn);
                }

                try
                {
                    foreach (DataGridViewRow myrow in dataGridView2.Rows)
                    {
                        Convert.ToBoolean(myrow.Cells["checkBoxColumn"].Value = true);
                    }
                    dataGridView2.Refresh();
                }
                catch
                {
                    return;
                }
            }
        }
    }
}

