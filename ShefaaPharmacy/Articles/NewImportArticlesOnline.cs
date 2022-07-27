using DataLayer;
using DataLayer.Helper;
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
//using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class NewImportArticlesOnline : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public NewImportArticlesOnline()
        {
            InitializeComponent();
            tbSearch.Enabled = false;
        }
        string status;
        public NewImportArticlesOnline(List<ArticleApiViewModel> x)
        {
            status = "online";
            InitializeComponent();
            dataGridView2.DataSource = x.OrderBy(r => r.name).ToList();
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


            dataGridView2.Columns["name"].ReadOnly = true;
            dataGridView2.Columns["size"].ReadOnly = true;
            dataGridView2.Columns["active_ingredients"].ReadOnly = true;
            dataGridView2.Columns["caliber"].ReadOnly = true;
            dataGridView2.Columns["BuyPrice"].ReadOnly = true;
            dataGridView2.Columns["SellPrice"].ReadOnly = true;
            dataGridView2.Columns["company_id_descr"].ReadOnly = true;
            dataGridView2.Columns["format_id_descr"].ReadOnly = true;
            dataGridView2.Columns["barcode"].ReadOnly = true;

            dataGridView2.Columns["barcode"].DisplayIndex = dataGridView2.ColumnCount - 2;

            btnImport.Enabled = true;
            CheckArticles.Enabled = true;
            tbSearch.Enabled = true;
            dataGridView2.Refresh();
        }
        public NewImportArticlesOnline(List<string> v)
        {
            status = "offline";
            InitializeComponent();
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);//connection name

            con.Open();
            string[] CompsNames = v.ToArray();
            string Comps = string.Join(",", CompsNames);
            string LastNames = string.Join(",", Comps.Split(',').Select(s => "'" + s + "'"));
            SqlCommand cmd = new SqlCommand(string.Format("select name as الاسم,company as الشركة,scientific_name as التركيب,caliber as العيار,format_id_descr as [الشكل الصيدلاني],size as [الحجم],BuyPrice as [سعر الشراء],SellPrice as [سعر المبيع],barcode from Medicines where company IN ({0}) order by company Asc", LastNames), con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicines");
            dataGridView2.DataSource = ds.Tables["Medicines"];

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "استيراد";
            checkBoxColumn.Width = 10;
            checkBoxColumn.Name = "checked";
            dataGridView2.Columns.Insert(9, checkBoxColumn);
            dataGridView2.Refresh();
            btnImport.Enabled = true;
            CheckArticles.Enabled = true;
            tbSearch.Enabled = true;
        }
        private async void btnImport_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource != null)
            {
                try
                {
                    //Stopwatch stopwatch = new Stopwatch();

                    //stopwatch.Start();
                    lblWait.Visible = true;
                    btnImport.Enabled = button3.Enabled = CheckArticles.Enabled = tbSearch.Enabled = btnClose.Enabled = btnMaximaizing.Enabled = btnMinimizing.Enabled = dataGridView2.Enabled = false;
                    await Task.Delay(2000);
                    await Task.Run(() => Thread1Job());
                    //stopwatch.Stop();
                    //_MessageBoxDialog.Show("الوقت المستغرق في معالجة العملية \n "+stopwatch.ElapsedMilliseconds, MessageBoxState.Error);

                }
                catch
                {
                    _MessageBoxDialog.Show("حدث خطأ يرجى المحاولة مجدداً", MessageBoxState.Error);
                }
            }
            else _MessageBoxDialog.Show("لم يتم تحديد مواد", MessageBoxState.Warning);
        }
        int addcheck = 0, isconsist = 0;
        private async void AddToDatabase()
        {
            addcheck = 0; isconsist = 0;
            int idcount2 = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Max(x => x.Id);
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var articles = dataGridView2.DataSource as List<ArticleApiViewModel>;
            List<Article> NewArt = new List<Article>();
            try
            {
                Article article;
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    article = new Article();
                    if (status == "online")
                    {
                        if (Convert.ToBoolean(item.Cells[item.Cells.Count - 1].Value) == true)
                        {
                            if (article.Name == null) break;
                            article.Name = item.Cells["name"].Value.ToString();
                            article.FormatId = DescriptionFK.GetFormatId(item.Cells["format_id_descr"].Value.ToString());
                            article.FormatIdDescr = DescriptionFK.GetFormatName(article.FormatId);
                            article.ScientificName = item.Cells["active_ingredients"].Value.ToString();
                            article.Size = item.Cells["size"].Value.ToString();
                            if (dataGridView2.Columns.Contains("barcode")) article.Barcode = item.Cells["barcode"].Value.ToString();
                            else article.Barcode = "0";
                            article.CompanyId = DescriptionFK.GetCompanyId(item.Cells["company_id_descr"].Value.ToString());
                            article.CompanyIdDescr = DescriptionFK.GetArticaleName((int)article.CompanyId);
                            article.ArticleIdGeneral = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.ItsGeneral == true).Id;
                            //article.ArticleIdGeneralDescr = "a";
                            article.Id = ++idcount2; idcount2 = article.Id;
                            article.Caliber = item.Cells["caliber"].Value.ToString();
                            article.ArticleCategoryId = DescriptionFK.GetArticleCategory((article).ArticleIdGeneral).ArticleCategoryId;
                            article.ArticleCategoryIdDescr = DescriptionFK.GetArticaleCategoryName(article.ArticleCategoryId);
                            article.ItsGeneral = false;

                            if (await Task.Run(() => IsConsist(article)))
                            {
                                isconsist++;
                                continue;
                            }
                            else
                            {
                                await Task.Run(() => Thread3Job(article, Convert.ToInt32(Convert.ToDouble(item.Cells["BuyPrice"].Value)), Convert.ToInt32(Convert.ToDouble(item.Cells["SellPrice"].Value))));
                            }
                        }
                    }
                    else if (status == "offline")
                    {
                        if (Convert.ToBoolean(item.Cells["checked"].Value) == true)
                        {
                            if (article.Name == null) break;
                            article.Name = item.Cells["الاسم"].Value.ToString();
                            article.ScientificName = item.Cells["التركيب"].Value.ToString();
                            article.FormatId = DescriptionFK.GetFormatId(item.Cells["الشكل الصيدلاني"].Value.ToString());
                            article.FormatIdDescr = DescriptionFK.GetFormatName(article.FormatId); //item.Cells["الشكل_الصيدلاني"].Value.ToString();
                            article.Size = item.Cells["الحجم"].Value.ToString();
                            article.CompanyId = DescriptionFK.GetCompanyId(item.Cells["الشركة"].Value.ToString()); //item.Cells["الشركة"].Value.ToString();
                            article.CompanyIdDescr = DescriptionFK.GetArticaleName((int)article.CompanyId);
                            article.Id = ++idcount2; idcount2 = article.Id;
                            if (dataGridView2.Columns.Contains("barcode")) article.Barcode = item.Cells["barcode"].Value.ToString();
                            else article.Barcode = "0";
                            article.ArticleIdGeneral = 1;
                            article.ArticleCategoryId = DescriptionFK.GetArticleCategory((article).ArticleIdGeneral).ArticleCategoryId;
                            article.ArticleCategoryIdDescr = DescriptionFK.GetArticaleCategoryName(article.ArticleCategoryId);
                            article.Caliber = item.Cells["العيار"].Value.ToString();
                            article.ItsGeneral = false;

                            if (await Task.Run(() => IsConsist(article)))
                            {
                                isconsist++;
                                continue;
                            }
                            else
                            {
                                await Task.Run(() => Thread3Job(article, Convert.ToInt32(Convert.ToDouble(item.Cells["سعر الشراء"].Value)), Convert.ToInt32(Convert.ToDouble(item.Cells["سعر المبيع"].Value))));
                            }
                        }
                    }
                }
                _MessageBoxDialog.Show("تمت اضافة " + addcheck + " مادة" + "\n" + "المواد الموجودة سابقاً من المواد المحددة " + isconsist + " مادة", MessageBoxState.Done);
                _MessageBoxDialog.Show("تم تعريف الواحدة الاساسية لجميع المواد المستوردة على أنها علبة \n يمكنك اضافة واحدات أخرى للمادة من واجهة واحدات المادة من الواجهة الرئيسية في قائمة المواد ", MessageBoxState.Alert);


                lblWait.Visible = false;
                btnImport.Enabled = button3.Enabled = CheckArticles.Enabled = tbSearch.Enabled = btnClose.Enabled = btnMaximaizing.Enabled = btnMinimizing.Enabled = dataGridView2.Enabled = true;
            }
            catch
            {
                _MessageBoxDialog.Show("حدث خطأ يرجى المحاولة مجدداً", MessageBoxState.Error);
                btnImport.Enabled = button3.Enabled = CheckArticles.Enabled = tbSearch.Enabled = btnClose.Enabled = btnMaximaizing.Enabled = btnMinimizing.Enabled = dataGridView2.Enabled = true;
                return;
            }
        }
        public bool IsConsist(Article art)
        {
            try
            {
                var articale = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(item => item.Name == art.Name && item.ScientificName == art.ScientificName && item.CompanyId == art.CompanyId && item.Caliber == art.Caliber && item.Size == art.Size).FirstOrDefault();
                if (articale != null)
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
        private void Thread1Job()
        {
            this.Invoke((MethodInvoker)delegate
            {
                AddToDatabase();
            });
        }
        private void Thread3Job(Article article, int BuyPrice, int SellPrice)
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                List<Article> NewArt = new List<Article>();
                this.Invoke((MethodInvoker)delegate
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Articale ON;");
                        NewArt.Add(article);
                        context.Articles.Add(NewArt.Last());
                        context.SaveChanges();
                        addcheck++;
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Articale OFF;");
                        transaction.Commit();
                    }
                    ArticleUnits myarts = new ArticleUnits()
                    {
                        ArticleId = article.Id,
                        IsPrimary = true,
                        QuantityForPrimary = 0,
                        UnitTypeId = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.FirstOrDefault(x => x.Name == "علبة").Id
                    };
                    context.ArticleUnits.Add(myarts);
                    context.SaveChanges();

                    PriceTagMaster PriceTagMasters = new PriceTagMaster()
                    {
                        ArticleId = article.Id,
                        UnitId = InventoryService.GetSmallestArticleUnit(article.Id),
                        CountGiftItem = 0,
                        CountSoldItem = 0,
                        CountAllItem = 0,
                        BranchId = UserLoggedIn.User.BranchId,
                        ExpiryDate = DateTime.Now.AddYears(2),
                        PriceTagDetails = ArticleService
                                            .MakeNewPriceTagDetailForArticle(
                                                    article.Id,
                                                    InventoryService.GetBaseArticleUnit(article.Id),
                                                    BuyPrice,
                                                    SellPrice, 0),
                    };
                    context.PriceTagMasters.Add(PriceTagMasters);
                    context.SaveChanges();

                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Articale ON;");
                        article.PriceTagMasters.Add(PriceTagMasters);
                        context.SaveChanges();
                        context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Articale OFF;");
                        transaction.Commit();
                    }
                });
            }
            catch
            {
                _MessageBoxDialog.Show("حدث خطأ يرجى المحاولة مجدداً", MessageBoxState.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CompanyChooseForm frm = new CompanyChooseForm();
            frm.ShowDialog();
            this.Close();
        }
        //private ApiResponseViewModel<CompanyApiViewModel> GetRESTData(string uri)
        //{
        //    var webRequest = (HttpWebRequest)WebRequest.Create(uri);
        //    var webResponse = (HttpWebResponse)webRequest.GetResponse();
        //    var reader = new StreamReader(webResponse.GetResponseStream());
        //    string s = reader.ReadToEnd();
        //    //Console.WriteLine(JsonConvert.DeserializeObject<ApiResponseViewModel<CompanyApiViewModel>>(s));
        //    //MessageBox.Show("["+s+"]");
        //    var x = JsonConvert.DeserializeObject<ApiResponseViewModel<CompanyApiViewModel>>(s);
        //    //Console.WriteLine(x);
        //    //outputStream.WriteLine(x);
        //    var context = ShefaaPharmacyDbContext.GetCurrentContext();
        //    var T = context.Articles.FirstOrDefault().ScientificName.Split();
        //    return x;
        //}
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckArticles.Checked)
            {
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    item.Cells["checked"].Value = 1;
                }
                dataGridView2.Refresh();
            }
            else
            {
                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    item.Cells["checked"].Value = 0;
                }
            }
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
        private void NewImportArticlesOnline_Load(object sender, EventArgs e)
        {
            ChangeStyleOfGrid(dataGridView2);
            ChangeFontForAll();
            WindowState = FormWindowState.Maximized;

        }
        public void ChangeFontForAll()
        {
            button3.Font = btnImport.Font = lblWait.Font = label5.Font = CheckArticles.Font = new Font("El Messiri SemiBold", 10);
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (status == "offline")
            {
                try
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dataGridView2.DataSource;
                    bs.Filter = dataGridView2.Columns["الاسم"].HeaderText.ToString().ToUpper() + " LIKE '%" + tbSearch.Text.ToUpper() + "%'";
                    dataGridView2.DataSource = bs;
                }
                catch (Exception ex)
                {
                    ;
                }
            }
            else if (status == "online")
            {
                try
                {
                    //BindingSource bs = new BindingSource();
                    dataGridView2.ClearSelection();
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        //row.Selected = false;
                        if (row.Cells[0].Value.ToString().ToUpper().Contains(tbSearch.Text.ToUpper()))
                        {
                            row.Selected = true;
                            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.SelectedRows[0].Index;
                            //bs.Add(row);

                            //(dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("name = '{0}'", tbSearch.Text);

                            //BindingSource bs = new BindingSource();
                            //bs.DataSource = dataGridView2.DataSource;
                            //bs.Filter = "[name] Like '%" + tbSearch.Text.ToUpper() + "%'";
                            //dataGridView2.DataSource = bs;

                            //var bd = (BindingSource)dataGridView2.DataSource;
                            //var dt = (DataTable)bd.DataSource;
                            //dt.DefaultView.RowFilter = string.Format("اسم الصنف like '%{0}%'", tbSearch.Text.Trim().Replace("'", "''"));
                            //dataGridView2.DataSource = dt;
                            //dataGridView2.Refresh();

                            //dataTable1.DefaultView.RowFilter = $"[{name}] LIKE '%{textBoxFilter.Text}%'";

                            //((DataTable)dataGridView2.DataSource).DefaultView.RowFilter = $"name LIKE %{tbSearch.Text.ToUpper()}%";

                            //(dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("Field = '{0}'", tbSearch.Text);

                            //break;
                        }
                    }
                    //dataGridView2.DataSource = bs;
                }
                catch (Exception ex)
                {
                    ;
                }
            }
        }
    }
}
