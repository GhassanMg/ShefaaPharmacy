using DataLayer;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Tables;
using Microsoft.Win32;
using Newtonsoft.Json;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.AccountingReport;
using ShefaaPharmacy.Articale;
using ShefaaPharmacy.Articles;
using ShefaaPharmacy.DataBaseSetting;
using ShefaaPharmacy.Definition;
using ShefaaPharmacy.Desktop;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Invoice;
using ShefaaPharmacy.Notification;
using ShefaaPharmacy.Orders;
using ShefaaPharmacy.Public;
using ShefaaPharmacy.Setting;
using ShefaaPharmacy.UserSetting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy
{
    public partial class MainForm : AbstractForm
    {
        AccountingDesktop accountingDesktop;
        BasicDesktop basicDesktop;
        WarningDesktop warningDesktop;
        SellFormTabs sellFormTabs;
        string DownloadPath;
        public class Data
        {
            public int id { get; set; }
            public string File { get; set; }
            public string Platform { get; set; }
            public string Version_number { get; set; }
            public string Description { get; set; }
            public DateTime Created_at { get; set; }
            public DateTime Updated_at { get; set; }
        }
        public class Root
        {
            public string Message { get; set; }
            public string Success { get; set; }
            public int Status_code { get; set; }
            public Data Data { get; set; }
        }
        public MainForm()
        {
            InitializeComponent();
            basicDesktop = new BasicDesktop();
        }
        private void MiDefenetionCompany_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    CompanyEditForm companyEditForm = new CompanyEditForm(new Company());
                    companyEditForm.ShowDialog();
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

        private void MiDefenetionYear_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    YearEditForm yearEditForm = new YearEditForm(new Year());
                    yearEditForm.ShowDialog();
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
        private void MiDefenetionStore_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    BranchEditForm storeEditForm = new BranchEditForm(new Branch());
                    storeEditForm.ShowDialog();
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
        private void MiAreticleGeneralDef_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    ArticleGeneralEditForm articaleSubCategory = new ArticleGeneralEditForm(new Article());
                    articaleSubCategory.ShowDialog();
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
        private void miArticleGeneralPick_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    ArticleGeneralPickForm articaleSubCategoryPickForm = new ArticleGeneralPickForm(new Article());
                    articaleSubCategoryPickForm.ShowDialog();
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
        private void miDefintionArticale_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry())
                {
                    ArticaleEditForm articaleEditForm = new ArticaleEditForm(new DataLayer.Tables.Article());
                    articaleEditForm.ShowDialog();
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
        private void miPickCompany_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    CompanyPickForm companyPickForm = new CompanyPickForm(new Company());
                    companyPickForm.ShowDialog();
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
        private void miPickYears_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    YearPickForm yearPickForm = new YearPickForm(new Year());
                    yearPickForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }
        private void miPickStore_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    BranchPickForm storePickForm = new BranchPickForm(new Branch());
                    storePickForm.ShowDialog();
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
        private void miDefinitionUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    UserEditForm userEditForm = new UserEditForm(new User());
                    userEditForm.ShowDialog();
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
        private void miPickUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    UserPickForm userPickForm = new UserPickForm(new User());
                    userPickForm.ShowDialog();
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
        private void miDefinitionUnitType_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    UnitEditForm unitEditForm = new UnitEditForm(new UnitType());
                    unitEditForm.ShowDialog();
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
        private void miPickUnitType_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    UnitPickForm unitPickForm = new UnitPickForm(new UnitType());
                    unitPickForm.ShowDialog();
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
        private void miArticalePickArticale_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    ArticlePicker articlePicker = new ArticlePicker(new List<Article>());
                    articlePicker.ShowDialog();
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
        private void miDefinitionAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    AccountCardEditForm accountCardEditForm = new AccountCardEditForm(new Account(), FormOperation.New);
                    accountCardEditForm.ShowDialog();
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
        private void miDefinitionAccountCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    AccountCategoryEditForm accountCategoryEditForm = new AccountCategoryEditForm(new AccountCategory(), FormOperation.New);
                    accountCategoryEditForm.ShowDialog();
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
        private void miPickAccountCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    AccountBaseCategoryPickForm.PickAccountCategory(new AccountBaseCategory(), FormOperation.Show);
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
        private void miPickAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    AccountPickForm accountPickForm = new AccountPickForm(new Account());
                    accountPickForm.ShowDialog();
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
        private void miDefinitionEntry_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager() && ((UserLoggedIn.User.UserPermissions.CanInsertEntry) || ((int)UserLoggedIn.User.Position <= (int)Position.manager)))
                {
                    EntryEditForm entryEditForm = new EntryEditForm(new EntryMaster(), KindOperation.Entry, FormOperation.New);
                    entryEditForm.ShowDialog();
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
        private void miInvoiceBuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry() && ((UserLoggedIn.User.UserPermissions.CanBuyBill) || ((int)UserLoggedIn.User.Position <= (int)Position.manager)))
                {
                    //GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(new BillMaster(), DataLayer.Enums.InvoiceKind.Buy, true);
                    //generalInvoiceEditForm.Show();
                    BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm(new BillMaster(), FormOperation.New);
                    buyInvoiceEditForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لفتح الواجهة", MessageBoxState.Error);
                }
                //BuyInvoiceEditForm buyInvoiceForm = new BuyInvoiceEditForm(new BillMaster());
                //buyInvoiceForm.ShowDialog();

            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }
        private void miUserPermission_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsAdmin())
                {
                    UserPermissionEditForm userPermissionEditForm = new UserPermissionEditForm(ShefaaPharmacyDbContext.GetCurrentContext().UserPermissions.ToList());
                    userPermissionEditForm.ShowDialog();
                    UserLoggedIn.User.UserPermissions = ShefaaPharmacyDbContext.GetCurrentContext().UserPermissions.FirstOrDefault(x => x.UserId == UserLoggedIn.User.Id);
                    DisableEnableMenuItem();
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
        private void miAccountMovementReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    AccountFainancialReportForm accountFainancialReportForm = new AccountFainancialReportForm();
                    accountFainancialReportForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("لا يوجد صلاحية للوصول لهذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }
        private void miInvoiceSell_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry() && ((UserLoggedIn.User.UserPermissions.CanSellBill) || ((int)UserLoggedIn.User.Position <= (int)Position.manager)))
                {
                    GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(new BillMaster(), DataLayer.Enums.InvoiceKind.Sell, FormOperation.New);
                    generalInvoiceEditForm.Show();
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
        private void miInvoiceReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    InvoiceMasterDetailReportForm invoiceMasterDetailReportForm = new InvoiceMasterDetailReportForm();
                    invoiceMasterDetailReportForm.ShowDialog();
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
        private void miArticleDetailQuentity_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    ArticleDetailReportForm articleDetailReportForm = new ArticleDetailReportForm();
                    articleDetailReportForm.ShowDialog();
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
        private void miDefArticlePriceTag_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry())
                {
                    PriceTagEditForm articlePriceTagEditForm = new PriceTagEditForm();
                    articlePriceTagEditForm.ShowDialog();
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

        private void miNotificationsSettings_Click(object sender, EventArgs e)
        {
            if (Auth.IsAdmin())
            {
                NotificationsSettingsForm notificationsSettingsForm = new NotificationsSettingsForm();
                notificationsSettingsForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            //lblclock.Font = new Font(Program.modernFont.Families[0],16);
            //menuStrip1.Font = new Font(Program.modernFont.Families[2],10);
            //WindowState = FormWindowState.Maximized;
            //DisableEnableMenuItem();
            if (UserLoggedIn.User != null)
            {
                try
                {
                    await Task.Delay(5000);
                    await Task.Run(() => notifytimer_Tick(sender, e));
                    Task.Run(() => DeleteFolderUpdate());
                }
                catch
                {

                }
            }
        }
        private void DeleteFolderUpdate()
        {
            string extractionPath = @"C:\ShefaaPharmacyVersions\";
            if (Directory.Exists(extractionPath + "NewVersion"))
            {
                Directory.Delete(extractionPath + "NewVersion", true);
            }
            Task.Run(() => CheckUpdateVerison());
        }
        private void CheckUpdateVerison()
        {
            string Currentversion = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString();
            int LatestVersion = CheckForUpdates("http://lamsetshefaa-desktop.lamsetshefaa.com/api/versions/desktop/last");
            if (LatestVersion > Convert.ToInt32(Currentversion))
            {
                DownloadUpdatesAndUnzip(DownloadPath);
            }
        }
        private int CheckForUpdates(string uri)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                Root x = JsonConvert.DeserializeObject<Root>(s);
                if (x.Data != null)
                {
                    int Version = Convert.ToInt32(x.Data.Version_number);
                    DownloadPath = x.Data.File;
                    return Version;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        private void DownloadUpdatesAndUnzip(string uri)
        {
            try
            {
                string Currentpath = Directory.GetCurrentDirectory();
                string NewFolder = @"C:\ShefaaPharmacyVersions";
                if (!Directory.Exists(NewFolder))
                {
                    Directory.CreateDirectory(NewFolder);
                }
                if (File.Exists(@"C:\ShefaaPharmacyVersions\NewVersion.Zip"))
                {
                    File.Delete(@"C:\ShefaaPharmacyVersions\NewVersion.Zip");
                }
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(new Uri(uri), @"C:\ShefaaPharmacyVersions\NewVersion.Zip");
                }
                string zipFilePath = @"C:\ShefaaPharmacyVersions\NewVersion.Zip";
                string extractionPath = @"C:\ShefaaPharmacyVersions\";
                DirectoryInfo di = new DirectoryInfo(extractionPath + "NewVersion");
                if (Directory.Exists(extractionPath + "NewVersion"))
                {
                    Directory.Delete(extractionPath + "NewVersion", true);
                }
                ZipFile.ExtractToDirectory(zipFilePath, extractionPath + "NewVersion");
            }
            catch
            {

            }
        }
        private void miShowWarningArchive_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                NotficationArticleWarning.ArticleWarningMessagesToRemind();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miShowWarning_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                NotficationArticleWarning.ArticleExpiryDate();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miConnectionSetting_Click(object sender, EventArgs e)
        {
            ServerSettingsForm fmServerConfig = new ServerSettingsForm();
            fmServerConfig.ShowDialog();
        }
        private void miCashMovementReport_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                AccountCashMovementReportForm accountCashMovementReportForm = new AccountCashMovementReportForm();
                accountCashMovementReportForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miActivationMethod_Click(object sender, EventArgs e)
        {
            ActivationProgram activationProgram = new ActivationProgram();
            activationProgram.ShowDialog();
        }
        private void miInvoiceReturningSelling_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                InvoiceReturningForm invoiceReturningForm = new InvoiceReturningForm("إرجاع فاتورة", FormOperation.Return);
                invoiceReturningForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void lblaccounting_Click(object sender, EventArgs e)
        {
            DisableEnableMenuItem();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblclock.Text = DateTime.Now.ToShortTimeString();
            }
            catch
            {
                ;
            }
        }
        List<string> mylist = new List<string>();
        private void MiImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry())
                {
                    if (ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ItsGeneral).ToList().Count == 0)
                    {
                        Article article = new Article();
                        ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();

                        article.ArticleCategoryId = 1;
                        article.ItsGeneral = true;
                        article.Name = "الأدوية";
                        context.Articles.Add(article);
                        context.SaveChanges();
                        NewImportArticlesOnline importArticles = new NewImportArticlesOnline();
                        importArticles.ShowDialog();
                    }
                    else
                    {
                        NewImportArticlesOnline importArticles = new NewImportArticlesOnline();
                        importArticles.ShowDialog();
                    }
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }
        private void miEntryPick_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                EntryPickForm entryPickForm = new EntryPickForm(new EntryMaster());
                entryPickForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miAccountPayment_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                AccountPaymentEditForm accountPaymentEditForm = new AccountPaymentEditForm(PayingCashState.InComing, "NewPayment");
                accountPaymentEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void tsmiEditAccountPayment_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                AccountPaymentEditForm accountPaymentEditForm = new AccountPaymentEditForm(PayingCashState.InComing, "EditPayment");
                accountPaymentEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miLogIn_Click(object sender, EventArgs e)
        {
            LogInShefaa loginForm = new LogInShefaa();
            loginForm.ShowDialog();
            DisableEnableMenuItem();
        }
        private void DisableEnableMenuItem()
        {
            bool registerd = RDSFECXA__WEWDSA.Ree();
            if (UserLoggedIn.User == null)
            {
                miAccount.Enabled = false;
                miArticale.Enabled = false;
                miOperation.Enabled = false;
                miOrders.Enabled = false;
                pbWarning.Enabled = false;
                lbUserNameDataBaseName.Text = "... / ...";
                lbUserNameDataBaseName.ForeColor = Color.White;
                UIBlankActive();
            }
            if (!registerd)
            {
                miAccount.Enabled = false;
                miArticale.Enabled = false;
                miOperation.Enabled = false;
                miOrders.Enabled = false;
                pbWarning.Enabled = false;
                _MessageBoxDialog.Show("النسخة غير مسجلة يجب التسجيل للإكمال", MessageBoxState.Warning);
                lbUserNameDataBaseName.Text = "... / ...";
                lbUserNameDataBaseName.ForeColor = Color.White;
                UIBlankActive();
            }
            if (registerd && UserLoggedIn.User != null)
            {
                miAccount.Enabled = true;
                miArticale.Enabled = true;
                miOperation.Enabled = true;
                miOrders.Enabled = true;
                pbWarning.Enabled = true;
                lbUserNameDataBaseName.Text = UserLoggedIn.User.Name + "/" + UserLoggedIn.Connection.DataBaseName;
                lbUserNameDataBaseName.ForeColor = Color.White;
                if (UserLoggedIn.User.UserPermissions.UserDesktopUI == UserDesktopUI.Icons)
                {
                    UIIconsActive();
                }
                else
                {
                    UITabsActive();
                }
            }
        }
        private void UIIconsActive()
        {
            accountingDesktop = new AccountingDesktop();
            warningDesktop = new WarningDesktop();
            FillPanelMaster(accountingDesktop);

            accountingDesktop.Show();
            accountingDesktop.Dock = DockStyle.Fill;
            accountingDesktop.BringToFront();

            warningDesktop.Hide();
            basicDesktop.Hide();
        }
        private void UITabsActive()
        {
            sellFormTabs = new SellFormTabs();
            FillPanelMaster(sellFormTabs);
            sellFormTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            sellFormTabs.BringToFront();
            sellFormTabs.LoadTabs();
            sellFormTabs.Show();
            sellFormTabs.assinged();
        }
        private void UIBlankActive()
        {
            basicDesktop = new BasicDesktop();
            FillPanelMaster(basicDesktop);
            basicDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            basicDesktop.BringToFront();
            basicDesktop.Show();
        }
        private void FillPanelMaster(Control control)
        {
            pFill.Controls.Add(control);
            pFill.Dock = System.Windows.Forms.DockStyle.Fill;
        }
        private void miCreateDB_Click(object sender, EventArgs e)
        {
            CreateDataBaseForm createDataBaseForm = new CreateDataBaseForm();
            createDataBaseForm.ShowDialog();
        }
        private void miInvoicDayPick_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                InvoicDayPickForm invoicDayPickForm = new InvoicDayPickForm(null);
                invoicDayPickForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miPickAccountPayments_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                PaymentDayPickForm paymentDayPickForm = new PaymentDayPickForm();
                paymentDayPickForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void lbWarning_Click(object sender, EventArgs e)
        {
            if (UserLoggedIn.User != null)
            {
                if (warningDesktop == null)
                {
                    warningDesktop = new WarningDesktop();
                    accountingDesktop = new AccountingDesktop();
                }
            }
            else
            {
                return;
            }
            FillPanelMaster(warningDesktop);

            warningDesktop.Show();
            warningDesktop.Dock = DockStyle.Fill;
            warningDesktop.BringToFront();

            accountingDesktop.Hide();
            basicDesktop.Hide();
            if (sellFormTabs != null)
            {
                sellFormTabs.Hide();
            }
            warningDesktop.ArticleWarning();
        }
        private void miDefinitionBaseAccount_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                AccountBaseCategoryEditForm baseAccountEditForm = new AccountBaseCategoryEditForm(new AccountBaseCategory(), FormOperation.New);
                baseAccountEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miPickAccountBaseCategory_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                AccountCategoryPickForm.PickAccountCategory(new AccountCategory(), FormOperation.Show);
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void pbLogInOut_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            string hoverText = "تسجيل الدخول";
            if (UserLoggedIn.User != null)
            {
                hoverText = "تسجيل الخروج";
            }
            toolTip.SetToolTip(pbLogInOut, hoverText);
        }
        private void pbLogInOut_Click(object sender, EventArgs e)
        {
            if (UserLoggedIn.User == null)
            {
                if (!ConnectionManager.LoadConnection())
                {
                    ServerSettingsForm fmServerConfig = new ServerSettingsForm();
                    fmServerConfig.ShowDialog();
                    fmServerConfig.Dispose();
                }
                if (ConnectionManager.Connected)
                {
                    LogInShefaa LoginForm = new LogInShefaa();
                    LoginForm.ShowDialog();
                    LoginForm.Dispose();
                }
                DisableEnableMenuItem();
            }
            else
            {
                UserLoggedIn.User = null;
                DisableEnableMenuItem();
            }
        }
        private void miDataBaseConfig_Click(object sender, EventArgs e)
        {
            if (Auth.IsManager())
            {
                DBConfigEditForm dBConfigEditForm = new DBConfigEditForm();
                dBConfigEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void pbWarning_MouseHover(object sender, EventArgs e)
        {
            pbWarning.Cursor = Cursors.Hand;
            ToolTip toolTip = new ToolTip();
            string hoverText = "الإشعارات";
            toolTip.SetToolTip(pbWarning, hoverText);
        }
        private void pbMessages_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            string hoverText = "الرسائل";
            toolTip.SetToolTip(pbMessages, hoverText);
        }
        private void pbMain_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            string hoverText = "الرئيسية";
            toolTip.SetToolTip(pbMain, hoverText);
        }
        private void miDefinitionFormat_Click(object sender, EventArgs e)
        {
            if (Auth.IsManager())
            {
                FormatEditForm formatEditForm = new FormatEditForm(new Format(), FormOperation.New);
                formatEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miPickFormat_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                FormatPickForm formatPickForm = new FormatPickForm();
                formatPickForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RestoreForm(1);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RestoreForm(2);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RestoreForm(3);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            RestoreForm(4);
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            RestoreForm(5);
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            RestoreForm(6);
        }
        private void miNewOrder_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                OrderEditForm orderEditForm = new OrderEditForm();
                orderEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miPickAllOrders_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                OrderPickForm.PickOrderMaster(new OrderMaster(), FormOperation.Show);
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miArticleCategoryDef_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    ArticaleCategoryEditForm articaleCategory = new ArticaleCategoryEditForm(new ArticleCategory());
                    articaleCategory.ShowDialog();
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
        private void miArticaleCategoryPick_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    ArticaleCategoryPickForm articaleCategoryPickForm = new ArticaleCategoryPickForm(new ArticleCategory());
                    articaleCategoryPickForm.ShowDialog();
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
        private void miBalanceFirstDuration_Click(object sender, EventArgs e)
        {
            if (Auth.IsManager())
            {
                FirstDurationEditForm frm = new FirstDurationEditForm();
                frm.ShowDialog();
                //BalanceFirstDurationEditForm balanceFirstDurationEditForm = new BalanceFirstDurationEditForm();
                //balanceFirstDurationEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void tsmiUpdatePricesArticles_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                GeneralNotification generalNotification = new GeneralNotification(NotificationType.UpdatePrices);
                generalNotification.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void tsmiExpiryDateArticle_Click(object sender, EventArgs e)
        {
            if (GetNotified == true)
            {
                pbWarning.Image = Properties.Resources.bell;
                contextMenuStrip1.Items[1].BackColor = Color.Transparent;
                contextMenuStrip1.Items[1].Image = null;
            }
            if (Auth.IsReportReader())
            {
                GeneralNotification generalNotification = new GeneralNotification(NotificationType.ExpiryDate);
                generalNotification.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void tsmiQuantityNotification_Click(object sender, EventArgs e)
        {
            if (GetNotified == true)
            {
                pbWarning.Image = Properties.Resources.bell;
                contextMenuStrip1.Items[0].BackColor = Color.Transparent;
                contextMenuStrip1.Items[0].Image = null;
            }
            if (Auth.IsReportReader())
            {
                GeneralNotification generalNotification = new GeneralNotification(NotificationType.Quantity);
                generalNotification.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miAccountYearProfitReport_Click(object sender, EventArgs e)//تقرير الربح السنوي
        {
            if (Auth.IsReportReader())
            {
                AccountYearProfitReportForm accountYearProfitReportForm = new AccountYearProfitReportForm();
                accountYearProfitReportForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void pbWarning_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(MousePosition);
        }
        private void MiInvoiceUpdateInvoice_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                InvoiceReturningForm invoiceReturningForm = new InvoiceReturningForm("تعديل فاتورة", FormOperation.EditFromPicker);
                invoiceReturningForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void MiInvoiceDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry() && ((UserLoggedIn.User.UserPermissions.CanDeleteBill) || ((int)UserLoggedIn.User.Position <= (int)Position.manager)))
            {
                InvoiceReturningForm invoiceReturningForm = new InvoiceReturningForm("حذف فاتورة", FormOperation.Delete);
                invoiceReturningForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void MiTestingTimer_Click(object sender, EventArgs e)
        {
            RegistryKey MTAppkey = Registry.CurrentUser.OpenSubKey(@"Software\" + ConnectionManager.ApplicationName);
            if (RDSFECXA__WEWDSA.DecodeForRegistry(MTAppkey.GetValue("UserNKey").ToString()) == "Demo")
            {
                _MessageBoxDialog.Show("النسخة التجريبية", MessageBoxState.Alert);
            }
            else if (RDSFECXA__WEWDSA.Ree())
            {
                _MessageBoxDialog.Show("النسخة مسجلة بالفعل", MessageBoxState.Alert);
            }
            else
            {
                ActivationTest activationTest = new ActivationTest();
                activationTest.ShowDialog();
            }
        }
        private void MiBackupDataBase_Click(object sender, EventArgs e)
        {
            DataBaseBackUp dataBaseBackUp = new DataBaseBackUp();
            dataBaseBackUp.ShowDialog();
        }
        private void MiRestoreBackUp_Click(object sender, EventArgs e)
        {
            DataBaseRestore dataBaseRestore = new DataBaseRestore();
            dataBaseRestore.ShowDialog();
        }
        private void MiAccountProfitFromDateToDateReport_Click(object sender, EventArgs e)
        {
            if (Auth.IsReportReader())
            {
                ProfitFromDateToDateReportForm profitFromDateToDateReportForm = new ProfitFromDateToDateReportForm();
                profitFromDateToDateReportForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void MiReCreateAllProcedure_Click(object sender, EventArgs e)
        {
            _MessageBoxDialog.Show("الرجاء الإنتظار بينما تتم إعادة بناء الإجراءات", MessageBoxState.Alert);
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            context.DropStoredProcedure();
            context.CreateStoredProcedure();
            _MessageBoxDialog.Show("تمت إعادة بناء الإجرائيات بنجاح", MessageBoxState.Alert);
        }

        private void MiInstallBarcode_Click(object sender, EventArgs e)
        {
            if (EnterPasswordForm.CheckInstallBarcodeService())
            {
                InstallingBarcodeServiceForm installingBarcodeServiceForm = new InstallingBarcodeServiceForm();
                installingBarcodeServiceForm.ShowDialog();
            }
        }
        private void MiOrderFromCompany_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                OrderFromCompanyEditForm orderFromCompanyEditForm = new OrderFromCompanyEditForm();
                orderFromCompanyEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void MiEntryReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsReportReader())
                {
                    EntryReportForm entryReportForm = new EntryReportForm();
                    entryReportForm.ShowDialog();
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
        private void miLastTimeReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry())
                {
                    LastTimeDurationReportForm LastTimeReport = new LastTimeDurationReportForm();
                    LastTimeReport.ShowDialog();
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
        private void MainForm_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            DisableEnableMenuItem();
        }
        private void MiArticleUnits_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry())
                {
                    ArticleUnitsEditForm articleUnitsEditForm = new ArticleUnitsEditForm();
                    articleUnitsEditForm.ShowDialog();
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
        private void miDestructionBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsDataEntry() && ((UserLoggedIn.User.UserPermissions.CanSellBill) || ((int)UserLoggedIn.User.Position <= (int)Position.manager)))
                {
                    GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(new BillMaster(), InvoiceKind.ExpiryArticles, FormOperation.DestructionBill);
                    generalInvoiceEditForm.Show();
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
        private void miUpdatePrices_Click(object sender, EventArgs e)
        {
            SetUpdateStatus frm = new SetUpdateStatus();
            frm.ShowDialog();
        }

        int ticks = 0;
        bool GetNotified = false;
        GeneralNotification generalNotification = new GeneralNotification();
        private void notifytimer_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (generalNotification.QuantityNotification() == true)
            {
                pbWarning.Image = Properties.Resources.notify;
                contextMenuStrip1.Items[0].BackColor = Color.LightGray;
                contextMenuStrip1.Items[0].Image = Properties.Resources.Warning;
                GetNotified = true;
            }
            if (generalNotification.ExpiryDateNotification() == true)
            {
                pbWarning.Image = Properties.Resources.notify;
                contextMenuStrip1.Items[1].BackColor = Color.LightGray;
                contextMenuStrip1.Items[1].Image = Properties.Resources.Warning;
                GetNotified = true;
            }
            //else if (generalNotification.UpdatePricesNotification() == true)
            //{
            //    pbWarning.Image = Properties.Resources.notify;
            //    contextMenuStrip1.Items[2].BackColor = Color.LightGray;
            //    contextMenuStrip1.Items[2].Image = Properties.Resources.Warning;
            //    GetNotified = true;
            //}
            if (ticks == 1)
            {
                notifytimer.Stop();
                notifytimer.Interval = 3600000;
                notifytimer.Start();
            }
        }
        private void pFill_Paint(object sender, PaintEventArgs e)
        {

        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        private void tTracking_Tick(object sender, EventArgs e)
        {

        }
        private void lblclock_Click(object sender, EventArgs e)
        {

        }
        private void miOrders_Click(object sender, EventArgs e)
        {

        }
        private void miAccountingReport_Click(object sender, EventArgs e)
        {

        }
        private void miNotificationsPick_Click(object sender, EventArgs e)
        {

        }
        private void TsmTransfeerToExpiryStore_Click(object sender, EventArgs e)
        {
            TransfeerExpiryArticlesToStore frm = new TransfeerExpiryArticlesToStore();
            frm.ShowDialog();
        }
        private void stmExpiryAerticlesStore_Click(object sender, EventArgs e)
        {
            ExpiryAerticlesStore frm = new ExpiryAerticlesStore();
            frm.ShowDialog();
        }
        private void miArticale_Click(object sender, EventArgs e)
        {

        }
        private void miReturnSellInvoice_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                var newbill = new BillMaster();
                newbill.InvoiceKind = InvoiceKind.ReturnSell;
                GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(newbill, InvoiceKind.ReturnSell, FormOperation.ReturnArticles);
                generalInvoiceEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miReturnBuyInvoice_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                var newbill = new BillMaster();
                newbill.InvoiceKind = InvoiceKind.ReturnBuy;
                BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm(newbill, FormOperation.ReturnArticles);
                buyInvoiceEditForm.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
        private void miTaxAccount_Click(object sender, EventArgs e)
        {
            if (Auth.IsDataEntry())
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (context.TaxAccount.Any())
                {
                    if (UserLoggedIn.User.Id == context.TaxAccount.FirstOrDefault().CreationBy)
                    {
                        _MessageBoxDialog.Show("الحساب الضريبي للمستخدم الحالي مسجل بالفعل", MessageBoxState.Warning);
                        return;
                    }
                }
                SetTaxAccountCredentials TaxAccountCred = new SetTaxAccountCredentials();
                TaxAccountCred.ShowDialog();
            }
            else
            {
                _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
            }
        }
    }
}


