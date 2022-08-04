using DataLayer;
using DataLayer.Enums;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.Articles;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Invoice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articale
{
    public partial class ArticleDetailReportForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        UserParameters userParameters;
        public ArticleDetailReportForm()
        {
            InitializeComponent();
            userParameters = ReportParametersForm.ReportParameterForArticle(new UserParameters());
            if (userParameters == null)
            {
                Load += (s, e) => Close();
                return;
            }
            else
            {
                LoadMaster();
                dgMaster.AutoGenerateColumns = true;
                dgDetail.AutoGenerateColumns = true;
                dgDetail2.AutoGenerateColumns = true;

                dgMaster.AllowUserToAddRows = false;
                dgDetail.AllowUserToAddRows = false;
                dgDetail2.AllowUserToAddRows = false;

                dgMaster.ReadOnly = true;
                dgDetail.ReadOnly = true;
                dgDetail2.ReadOnly = true;

            }
        }

        public ArticleDetailReportForm(UserParameters userParameters)
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
                dgDetail.AutoGenerateColumns = true;
                dgDetail2.AutoGenerateColumns = true;

                dgMaster.AllowUserToAddRows = false;
                dgDetail.AllowUserToAddRows = false;
                dgDetail2.AllowUserToAddRows = false;

                dgMaster.ReadOnly = true;
                dgDetail.ReadOnly = true;
                dgDetail2.ReadOnly = true;

            }
        }
        private void LoadMaster()
        {
            HiddenColumn = new string[] { "CreationByDescr","Id", "CreationDate", "Description", "Description2", "Note", "Note2", "SideEffects", "Interactions", "Precautions", "Dosage", "ActiveIngredients" };
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<Article> resultReport;
            if (userParameters.ArticleId != 0)
            {
                resultReport = context.Articles.Where(x => x.Id == userParameters.ArticleId && !x.ItsGeneral).ToList();
            }
            else
            {
                resultReport = context.Articles.Where(x => !x.ItsGeneral).ToList();
            }
            bindingSourceMaster.DataSource = resultReport;
            bindingNavigator1.BindingSource = bindingSourceMaster;
        }
        private void dgMaster_BindingContextChanged(object sender, EventArgs e)
        {
            try
            {
                dgMaster.EnableHeadersVisualStyles = false;
                dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
                dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

                dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
                dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                ShowColumn(dgMaster.Columns);
                dgMaster.Refresh();
            }
            catch (Exception)
            {
                ;
            }
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
        private void LoadDetail(Article article)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<BillDetail> resultReport = context.BillDetails.Where(x => x.ArticaleId == article.Id).ToList();
            ArticleDetail articleDetail = new ArticleDetail();
            var lastPriceTage = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                    .Where(x => x.ArticleId == article.Id)
                    .Include(x => x.PriceTagDetails)
                    .OrderByDescending(x => x.CreationDate)
                    .LastOrDefault();
            

            SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select name as الصنف ,InvoiceKind as [نوع الفاتورة],UnitIdDescr as الواحدة ,price as السعر,quantity as الكمية ,Total as الإجمالي,Expirydate as [تاريخ الصلاحية] from FirstTimeArticles where name='" + article.Name + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "FirstTimeArticles");

            FirstTimeArticles FirstTimeDetailRow = new FirstTimeArticles();
            foreach (DataRow dr in ds.Tables["FirstTimeArticles"].Rows)
            {

                FirstTimeDetailRow.Name = dr.ItemArray[0].ToString();
                FirstTimeDetailRow.InvoiceKind = dr.ItemArray[1].ToString();
                FirstTimeDetailRow.Quantity = Convert.ToInt32(dr.ItemArray[4]);
                FirstTimeDetailRow.UnitIdDescr = dr.ItemArray[0].ToString();
                FirstTimeDetailRow.Price = Convert.ToDouble(dr.ItemArray[3]);
                FirstTimeDetailRow.Expirydate = Convert.ToDateTime(dr.ItemArray[6]).Date;
                FirstTimeDetailRow.Total = Convert.ToInt32(dr.ItemArray[5]);

                BillDetail NewRow = new BillDetail()
                {
                    ArticaleId= ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Name == FirstTimeDetailRow.Name).Id,
                    Barcode = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Name == FirstTimeDetailRow.Name).Barcode,
                    InvoiceKind = InvoiceKind.GoodFirstTime,
                    UnitTypeId = FirstTimeDetailRow.UnitId,
                    Price = FirstTimeDetailRow.Price,
                    Quantity = FirstTimeDetailRow.Quantity,
                    
                };
                resultReport.Add(NewRow);
                //resultReport.OrderByDescending(x=>x.InvoiceKind);
            }
            SqlCommand cmd2 = new SqlCommand("select ArticleIdDescr as الصنف,UnitIdDescr as الواحدة ,TransQuantity as الكمية from ExpiryTransfeerDetail where ArticleIdDescr='" + article.Name + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "ExpiryTransfeerDetail");

            ExpiryTransfeerDetail ExpiryTransfeerDetailRow = new ExpiryTransfeerDetail();
            foreach (DataRow dr in ds2.Tables["ExpiryTransfeerDetail"].Rows)
            {
                ExpiryTransfeerDetailRow.ArticleIdDescr = dr.ItemArray[0].ToString();
                ExpiryTransfeerDetailRow.TransQuantity = Convert.ToInt32(dr.ItemArray[2]);
                ExpiryTransfeerDetailRow.UnitIdDescr = dr.ItemArray[1].ToString();

                BillDetail NewRow = new BillDetail()
                {
                    ArticaleId = context.Articles.FirstOrDefault(x => x.Name == ExpiryTransfeerDetailRow.ArticleIdDescr).Id,
                    Barcode = context.Articles.FirstOrDefault(x => x.Name == ExpiryTransfeerDetailRow.ArticleIdDescr).Barcode,
                    InvoiceKind = InvoiceKind.ExpiryArticles,
                    UnitTypeId = context.ArticleUnits.ToList().FirstOrDefault(x => x.UnitTypeIdDescr == ExpiryTransfeerDetailRow.UnitIdDescr).UnitTypeId,
                    Quantity = ExpiryTransfeerDetailRow.TransQuantity,
                    
                };
                resultReport.Add(NewRow);
            }

            for (int item = 0; item < resultReport.Count; item++)
            {
                resultReport[item].CreationDate = resultReport[item].CreationDate.Date;

            }
            bindingSourceDetail.DataSource = resultReport.OrderByDescending(x=>x.InvoiceKind);
            dgDetail.Refresh();
            articleDetail.CountLeft = String.Format("{0:0.##}", Convert.ToDouble(InventoryService.GetQuantityOfArticleAllPriceTag(article.Id)));
            articleDetail.LastBuyPrimary = lastPriceTage.PriceTagDetails.FirstOrDefault(x => x.UnitId == DescriptionFK.GetPrimaryUnit(article.Id)).BuyPrice;/*UnitTypeService.GetLastBuyPrice(article.Id, UnitTypeService.GetBrimaryPriceId(article.Id));*/
            articleDetail.LastSellPrimary = lastPriceTage.PriceTagDetails.FirstOrDefault(x => x.UnitId == DescriptionFK.GetPrimaryUnit(article.Id)).SellPrice;/*UnitTypeService.GetLastSellPrice(article.Id, UnitTypeService.GetBrimaryPriceId(article.Id));*/
            bindingSourceDetail2.DataSource = articleDetail;
        }
        private void LoadFirtTimeArticales(Article article)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select name as الصنف ,InvoiceKind as [نوع الفاتورة],UnitIdDescr as الواحدة ,price as السعر,quantity as الكمية ,Total as الإجمالي,Expirydate as [تاريخ الصلاحية] from FirstTimeArticles where name='" + article.Name + "'", con);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "FirstTimeArticles");
            FirstTimebindingSource.DataSource = ds.Tables["FirstTimeArticles"];
        }
        private void dgMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgDetail2_BindingContextChanged(object sender, EventArgs e)
        {
            dgDetail2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail2.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgDetail2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgDetail2.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgDetail2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail2.Refresh();
        }
        private void miDefPriceTag_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry())
                {
                    //ArticlePriceTagEditForm articlePriceTagEditForm = new ArticlePriceTagEditForm(bindingSourceMaster.Current as DataLayer.Tables.Article);
                    //articlePriceTagEditForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void dgMaster_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var ht = dgMaster.HitTest(e.X, e.Y);
            }
        }

        private void bindingSourceMaster_PositionChanged(object sender, EventArgs e)
        {
            if (bindingSourceMaster.Current == null)
                return;
            LoadDetail(bindingSourceMaster.Current as Article);
        }

        private void dgMaster_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 != 0)
            {
                dgMaster.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSeaGreen;
            }
            else
            {
                dgMaster.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MediumTurquoise;
            }
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            LoadMaster();
            dgDetail.Refresh();
        }

        private void tsReset_Click(object sender, EventArgs e)
        {
            userParameters = ReportParametersForm.ReportParameterForArticle(new UserParameters());
            if (userParameters != null)
            {
                LoadMaster();
                dgDetail.Refresh();
            }
        }
        public static DataSet ConvertToDataSet<T>(IEnumerable<T> source, string name)
        {
            if (source == null)
                throw new ArgumentNullException("source ");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            var converted = new DataSet(name);
            converted.Tables.Add(NewTable(name, source));
            return converted;
        }
        private static DataRow CreateRow<T>(DataRow row, T listItem, PropertyInfo[] pi)
        {
            foreach (PropertyInfo p in pi)
                row[p.Name.ToString()] = p.GetValue(listItem, null);
            return row;
        }
        private static DataTable NewTable<T>(string name, IEnumerable<T> list)
        {
            PropertyInfo[] propInfo = typeof(T).GetProperties();
            DataTable table = Table<T>(name, list, propInfo);
            IEnumerator<T> enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
                table.Rows.Add(CreateRow<T>(table.NewRow(), enumerator.Current, propInfo));
            return table;
        }
        private static DataTable Table<T>(string name, IEnumerable<T> list, PropertyInfo[] pi)
        {
            DataTable table = new DataTable(name);
            foreach (PropertyInfo p in pi)
                table.Columns.Add(p.Name, p.PropertyType);
            return table;
        }
        private void tsPreview_Click(object sender, EventArgs e)
        {
            //Report report = new Report();

            //// load nwind database
            //DataSet dataSet = new DataSet();
            //dataSet = ConvertToDataSet((bindingSourceMaster.DataSource as List<DataLayer.Tables.Article>), "Employees");

            //// register all data tables and relations
            //report.RegisterData(dataSet);

            //// enable the "Employees" table to use it in the report
            //report.GetDataSource("Employees").Enabled = true;

            //// add report page
            //ReportPage page = new ReportPage();
            //report.Pages.Add(page);
            //// always give names to objects you create. You can use CreateUniqueName method to do this;
            //// call it after the object is added to a report.
            //page.CreateUniqueName();

            //// create title band
            //page.ReportTitle = new ReportTitleBand();
            //// native FastReport unit is screen pixel, use conversion 
            //page.ReportTitle.Height = Units.Centimeters * 1;
            //page.ReportTitle.CreateUniqueName();

            //// create title text
            //TextObject titleText = new TextObject();
            //titleText.Parent = page.ReportTitle;
            //titleText.CreateUniqueName();
            //titleText.Bounds = new RectangleF(Units.Centimeters * 5, 0, Units.Centimeters * 10, Units.Centimeters * 1);
            //titleText.Font = new Font("Arial", 14, FontStyle.Bold);
            //titleText.Text = "Employees";
            //titleText.HorzAlign = HorzAlign.Center;

            //// create data band
            //DataBand dataBand = new DataBand();
            //page.Bands.Add(dataBand);
            //dataBand.CreateUniqueName();
            //dataBand.DataSource = report.GetDataSource("Employees");
            //dataBand.Height = Units.Centimeters * 0.5f;

            //// create two text objects with employee's name and birth date
            //TextObject empNameText = new TextObject();
            //empNameText.Parent = dataBand;
            //empNameText.CreateUniqueName();
            //empNameText.Bounds = new RectangleF(0, 0, Units.Centimeters * 5, Units.Centimeters * 0.5f);
            //empNameText.Text = "[Employees.Name]";

            //TextObject empBirthDateText = new TextObject();
            //empBirthDateText.Parent = dataBand;
            //empBirthDateText.CreateUniqueName();
            //empBirthDateText.Bounds = new RectangleF(Units.Centimeters * 5.5f, 0, Units.Centimeters * 3, Units.Centimeters * 0.5f);
            //empBirthDateText.Text = "[Employees.CreationDate]";
            //// format value as date
            //DateFormat format = new DateFormat();
            //format.Format = "MM/dd/yyyy";
            //empBirthDateText.Format = format;

            //// run report designer
            //report.Design();
            //run 
            //report.Preview;
        }

        private void ArticleDetailReportForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void MiShowBill_Click(object sender, EventArgs e)
        {
            if (bindingSourceDetail.Current == null)
                return;
            var billMaster = ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.FirstOrDefault(x => x.Id == (bindingSourceDetail.Current as BillDetail).BillMasterId);
            billMaster.BillDetails = ShefaaPharmacyDbContext.GetCurrentContext().BillDetails.Where(x => x.BillMasterId == billMaster.Id).ToList();
            if ((bindingSourceDetail.Current as BillDetail).InvoiceKind == InvoiceKind.ReturnSell || (bindingSourceDetail.Current as BillDetail).InvoiceKind == InvoiceKind.ReturnBuy)
            {
                GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(billMaster, (bindingSourceDetail.Current as BillDetail).InvoiceKind, FormOperation.EditFromPicker);
                generalInvoiceEditForm.ShowDialog();
            }
            else if ((bindingSourceDetail.Current as BillDetail).InvoiceKind == InvoiceKind.Sell)
            {
                GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(billMaster, (bindingSourceDetail.Current as BillDetail).InvoiceKind, FormOperation.EditFromPicker);
                generalInvoiceEditForm.ShowDialog();
            }
            else if ((bindingSourceDetail.Current as BillDetail).InvoiceKind == InvoiceKind.Buy)
            {
                BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm(billMaster, FormOperation.EditFromPicker);
                buyInvoiceEditForm.ShowDialog();
            }

        }
        private void MiShowEntry_Click(object sender, EventArgs e)
        {
            if (bindingSourceDetail.Current == null)
                return;
            var entryMaster = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.FirstOrDefault(x => x.RelatedDocument == (bindingSourceDetail.Current as BillDetail).BillMasterId);
            entryMaster.EntryDetails = ShefaaPharmacyDbContext.GetCurrentContext().EntryDetails.Where(x => x.EntryMasterId == entryMaster.Id).ToList();
            EntryEditForm entryEditForm = new EntryEditForm(entryMaster, entryMaster.KindOperation, FormOperation.EditFromPicker);
            entryEditForm.ShowDialog();
        }


        private void FirstTimebindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (bindingSourceMaster.Current == null)
                return;
            //LoadFirtTimeArticales(bindingSourceMaster.Current as Article);
        }

        private void dgDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow item in dgDetail.Rows)
            {
                if (dgDetail.Rows[item.Index].Cells["InvoiceKind"].Value.ToString() == "Sell")
                {
                    var font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    dgDetail.Rows[item.Index].Cells["InvoiceKind"].Style = new DataGridViewCellStyle { ForeColor = Color.DarkRed, Font = font };
                }
            }
        }
    }
}
