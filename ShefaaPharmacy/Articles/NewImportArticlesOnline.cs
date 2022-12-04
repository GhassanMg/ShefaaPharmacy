using DataLayer;
using DataLayer.Helper;
using DataLayer.Tables;
using DataLayer.Services;
using DataLayer.ViewModels;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.GeneralUI;
using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShefaaPharmacy.Articles
{
    public partial class NewImportArticlesOnline : AbstractForm
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
            dataGridView2.Columns["note"].Visible = false;
            dataGridView2.Columns["note2"].Visible = false;
            dataGridView2.Columns["dosage"].Visible = false;
            dataGridView2.Columns["barcode"].Visible = false;
            dataGridView2.Columns["Description"].Visible = false;
            dataGridView2.Columns["precautions"].Visible = false;
            dataGridView2.Columns["interactions"].Visible = false;
            dataGridView2.Columns["side_effects"].Visible = false;
            dataGridView2.Columns["Description2"].Visible = false;
            dataGridView2.Columns["english_name"].Visible = false;
            dataGridView2.Columns["scientific_name"].Visible = false;

            dataGridView2.Columns["name"].ReadOnly = true;
            dataGridView2.Columns["size"].ReadOnly = true;
            dataGridView2.Columns["barcode"].ReadOnly = true;
            dataGridView2.Columns["caliber"].ReadOnly = true;
            dataGridView2.Columns["BuyPrice"].ReadOnly = true;
            dataGridView2.Columns["SellPrice"].ReadOnly = true;
            dataGridView2.Columns["format_id_descr"].ReadOnly = true;
            dataGridView2.Columns["company_id_descr"].ReadOnly = true;
            dataGridView2.Columns["active_ingredients"].ReadOnly = true;

            dataGridView2.Columns["format_id_descr"].DisplayIndex = 4;
            dataGridView2.Columns["company_id_descr"].DisplayIndex = 1;
            dataGridView2.Columns["barcode"].DisplayIndex = dataGridView2.ColumnCount - 2;

            tbSearch.Enabled = true;
            btnImport.Enabled = true;
            CheckArticles.Enabled = true;
            dataGridView2.Refresh();
        }
        public NewImportArticlesOnline(List<string> Comparray)
        {
            status = "offline";
            InitializeComponent();
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var Medicines = context.Medicines.Where(x => Comparray.Contains(x.Company))
                .OrderBy(x => x.Name)
                .ToList();



            dataGridView2.DataSource = Medicines;
            dataGridView2.Columns["Barcode"].Visible = dataGridView2.Columns["Id"].Visible = false;

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
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayData();
            }
            catch (Exception)
            {
                _MessageBoxDialog.Show("حدث خطأ يرجى المحاولة مجدداً", MessageBoxState.Error);
            }
        }
        private async void DisplayData()
        {
            SetLoading(true);
            // Do other operations...
            if (dataGridView2.DataSource != null)
            {
                try
                {
                    lblWait.Visible = true;
                    btnImport.Enabled = button3.Enabled = CheckArticles.Enabled = tbSearch.Enabled = btnClose.Enabled = btnMaximaizing.Enabled = btnMinimizing.Enabled = dataGridView2.Enabled = false;
                    await Task.Delay(2000);
                    await Task.Run(() => Thread1Job());
                }
                catch (Exception e)
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
                            article.Name = item.Cells["Name"].Value.ToString();
                            article.ScientificName = item.Cells["ScientificName"].Value.ToString();
                            article.FormatId = DescriptionFK.GetFormatId(item.Cells["FormatIdDescr"].Value.ToString());
                            article.FormatIdDescr = DescriptionFK.GetFormatName(article.FormatId); //item.Cells["الشكل_الصيدلاني"].Value.ToString();
                            article.Size = item.Cells["Size"].Value.ToString();
                            article.CompanyId = DescriptionFK.GetCompanyId(item.Cells["Company"].Value.ToString()); //item.Cells["الشركة"].Value.ToString();
                            article.CompanyIdDescr = DescriptionFK.GetArticaleName((int)article.CompanyId);
                            article.Id = ++idcount2; idcount2 = article.Id;
                            if (dataGridView2.Columns.Contains("barcode")) article.Barcode = item.Cells["barcode"].Value.ToString();
                            else article.Barcode = "0";
                            article.ArticleIdGeneral = 1;
                            article.ArticleCategoryId = DescriptionFK.GetArticleCategory((article).ArticleIdGeneral).ArticleCategoryId;
                            article.ArticleCategoryIdDescr = DescriptionFK.GetArticaleCategoryName(article.ArticleCategoryId);
                            article.Caliber = item.Cells["Caliber"].Value.ToString();
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
                }
                lblWait.Visible = false;
                SetLoading(false);
                if (addcheck > 0)
                {
                    _MessageBoxDialog.Show("تمت اضافة " + addcheck + " مادة" + "\n" + "المواد الموجودة سابقاً من المواد المحددة " + isconsist + " مادة", MessageBoxState.Done);
                    _MessageBoxDialog.Show("تم تعريف الواحدة الاساسية لجميع المواد المستوردة على أنها علبة \n يمكنك اضافة واحدات أخرى للمادة من قائمة المواد في الواجهة الرئيسية ", MessageBoxState.Alert);
                }
                else
                {
                    _MessageBoxDialog.Show("تمت اضافة " + addcheck + " مادة" + "\n" + "المواد الموجودة سابقاً من المواد المحددة " + isconsist + " مادة", MessageBoxState.Alert);
                }
                btnImport.Enabled = button3.Enabled = CheckArticles.Enabled = tbSearch.Enabled = btnClose.Enabled = btnMaximaizing.Enabled = btnMinimizing.Enabled = dataGridView2.Enabled = true;
            }
            catch (Exception)
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
        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = true;
                    dataGridView2.ReadOnly = true;
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    picLoader.Visible = false;
                    dataGridView2.ReadOnly = false;
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                });
            }
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
                    dataGridView2.ClearSelection();
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (row.Cells[0].Value.ToString().ToUpper().Contains(tbSearch.Text.ToUpper()))
                        {
                            row.Selected = true;
                            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.SelectedRows[0].Index;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ;
                }
            }
        }
    }
}
