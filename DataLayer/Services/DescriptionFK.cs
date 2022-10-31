using Newtonsoft.Json;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Management;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Services
{
    public static class DescriptionFK
    {
        public static List<Article> articlesForPicker = new List<Article>();
        public static List<DetailedTaxCode> TaxDetailsForPicker = new List<DetailedTaxCode>();
        public static bool CheckDoubleValue(this double value)
        {
            if (Double.IsNaN(value) || Double.IsInfinity(value) || Double.IsNegativeInfinity(value) || Double.IsPositiveInfinity(value))
            {
                value = 0.0;
                return false;
            }
            return true;
        }
        public static int RoundToNearest(double i, int v)
        {
            return (int)(Math.Round(i / v) * v);
        }
        public static double RoundInMath(double number, int n)
        {
            return Math.Round(number, n);
        }
        public static string getMotherBoardID()
        {
            string serial = "";
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                ManagementObjectCollection moc = mos.Get();

                foreach (ManagementObject mo in moc)
                {
                    serial = mo["SerialNumber"].ToString();
                }
                return serial;
            }
            catch (Exception)
            {
                return serial;
            }
        }
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        public async static Task<string> LoadImportantDataForImages()
        {
            try
            {
                DummyData dummyData = new DummyData()
                {
                    ComputerName = UserLoggedIn.Connection.ComputerName,
                    MotherBoard = getMotherBoardID(),
                    SerialNumberClient = UserLoggedIn.Connection.NKey
                };
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                StringContent content = new StringContent(JsonConvert.SerializeObject(dummyData), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient(clientHandler))
                {
                    using (var response = await httpClient.PostAsync("https://localhost:44329/CopyStatusLog/CheckIn", content))
                    {
                        return "Found Images";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static string GetUnitName(int unitTypeId)
        {
            UnitType unitType = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.FirstOrDefault(x => x.Id == unitTypeId);
            if (unitType != null)
            {
                return unitType.Name;
            }
            return "علبة";
        }
        public static int GetUnitId(string name)
        {
            UnitType unitType = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.FirstOrDefault(x => x.Name == name);
            if (unitType != null)
            {
                return unitType.Id;
            }
            return 0;
        }
        public static UnitType GetUnitAndCreate(string name)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            if (name == "")
            {
                return context.UnitTypes.FirstOrDefault();
            }
            var unit = context.UnitTypes.FirstOrDefault(x => x.Name == name);
            if (unit == null)
            {
                unit = new UnitType()
                {
                    Name = name
                };
                unit = context.Add(unit).Entity;
                context.SaveChanges();
                return unit;
            }
            else
            {
                return unit;
            }
        }
        public static UnitType GetUnit(int unitId)
        {
            UnitType unitType = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.FirstOrDefault(x => x.Id == unitId);
            if (unitType != null)
            {
                return unitType;
            }
            return null;
        }
        public static int GetPrimaryUnit(int articleId)
        {
            try
            {
                int artid = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.FirstOrDefault(x => x.IsPrimary && x.ArticleId == articleId).UnitTypeId;
                return artid;
            }
            catch (Exception)
            {
                return 3;
            }
        }
        public static string GetUserName(int userId)
        {
            User user = ShefaaPharmacyDbContext.GetCurrentContext().Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                return user.Name;
            }
            return "";
        }
        public static string GetYearName(int yearId)
        {
            Year year = ShefaaPharmacyDbContext.GetCurrentContext().Years.FirstOrDefault(x => x.Id == yearId);
            if (year != null)
            {
                return year.Name;
            }
            return "";
        }
        public static string GetBranchName(int branchId)
        {
            Branch branch = ShefaaPharmacyDbContext.GetCurrentContext().Branches.FirstOrDefault(x => x.Id == branchId);
            if (branch != null)
            {
                return branch.Name;
            }
            return "";
        }
        public static string GetStoreName(int storeId)
        {
            Store store = ShefaaPharmacyDbContext.GetCurrentContext().Stores.FirstOrDefault(x => x.Id == storeId);
            if (store != null)
            {
                return store.Name;
            }
            return "";
        }
        public static string GetCompanyName(int? companyId)
        {
            try
            {
                Company company = ShefaaPharmacyDbContext.GetCurrentContext().Companys.FirstOrDefault(x => x.Id == companyId);
                if (company != null)
                {
                    return company.Name;
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }

        }
        public static int GetCompanyId(string name)
        {
            Company company = ShefaaPharmacyDbContext.GetCurrentContext().Companys.FirstOrDefault(x => x.Name == name);
            if (company != null)
            {
                return company.Id;
            }
            else
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                Company newcomp = new Company()
                {
                    Name = name,
                    Location = "Damascus"
                };
                context.Companys.Add(newcomp);
                context.SaveChanges();
                return context.Companys.FirstOrDefault(x => x.Name == name).Id;
            }
        }
        public static Company GetCompanyAndCreate(string name)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            if (name == "")
            {
                return context.Companys.FirstOrDefault();
            }
            var company = context.Companys.FirstOrDefault(x => x.Name == name);
            if (company == null)
            {
                company = new Company()
                {
                    Name = name
                };
                company = context.Add(company).Entity;
                context.SaveChanges();
                return company;
            }
            else
            {
                return company;
            }
        }
        public static string GetArticaleName(int articaleId)
        {
            Article articale = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Id == articaleId);
            if (articale != null)
            {
                return articale.Name;
            }
            return "";
        }
        public static int GetArticaleIdFromEntry(int EntryId)
        {
            EntryDetail MyEntry = ShefaaPharmacyDbContext.GetCurrentContext().EntryDetails.FirstOrDefault(x => x.Id == EntryId);

            if (MyEntry != null)
            {
                return MyEntry.EntryMasterId;
            }
            return 0;
        }
        public static int GetArticaleNameForBalanceFirst(string articaleName)
        {
            Article articale = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Name == articaleName);
            if (articale != null)
            {
                return articale.Id;
            }
            return -1;
        }
        public static string GetArticaleCategoryName(int articaleCategoryId)
        {
            ArticleCategory articaleCategory = ShefaaPharmacyDbContext.GetCurrentContext().ArticleCategorys.FirstOrDefault(x => x.Id == articaleCategoryId);
            if (articaleCategory != null)
            {
                return articaleCategory.Name;
            }
            return "";
        }
        public static Article ExistsArticleCategory(bool isName, string Name, int articleId)
        {
            Article article;
            if (isName)
            {
                article = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ItsGeneral && (x.Name == Name || x.EnglishName == Name)).FirstOrDefault();
            }
            else
            {
                article = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ItsGeneral && x.Id == articleId).FirstOrDefault();
            }
            return article;
        }
        public static Article GetArticleCategory(int? articleId)
        {
            Article article = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Id == articleId);
            return article;
        }
        public static string GetAccountCategoryName(int accountCategoryId)
        {
            AccountCategory accountCategory = ShefaaPharmacyDbContext.GetCurrentContext().AccountCategorys.FirstOrDefault(x => x.Id == accountCategoryId);
            if (accountCategory != null)
            {
                return accountCategory.Name;
            }
            return "";
        }
        public static int GetAccountCategory(int? accountId)
        {
            Account account = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account != null)
            {
                return account.CategoryId;
            }
            return 0;
        }
        public static string GetAccountBaseCategoryName(int accountBaseCategoryId)
        {
            AccountBaseCategory accountBaseCategory = ShefaaPharmacyDbContext.GetCurrentContext().AccountBaseCategorys.FirstOrDefault(x => x.Id == accountBaseCategoryId);
            if (accountBaseCategory != null)
            {
                return accountBaseCategory.Name;
            }
            return "";
        }
        public static string GetAccountDebitForEntryMaster(int entryMasterId)
        {
            try
            {
                var details = ShefaaPharmacyDbContext.GetCurrentContext().EntryDetails.Where(x => x.EntryMasterId == entryMasterId).ToList();
                if (details.Count > 0)
                {
                    var d = details.Where(x => x.Debit != 0).FirstOrDefault()?.AccountIdDescr.ToString();
                    return d;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static string GetAccountCreditForEntryMaster(int entryMasterId)
        {
            try
            {
                var details = ShefaaPharmacyDbContext.GetCurrentContext().EntryDetails.Where(x => x.EntryMasterId == entryMasterId).ToList();
                if (details.Count > 0)
                {
                    var d = details.Where(x => x.Credit != 0).FirstOrDefault()?.AccountIdDescr.ToString();
                    return d;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static string GetAccountName(int? accountId)
        {
            if (accountId == null)
            {
                return "";
            }
            Account account = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account != null)
            {
                return account.Name;
            }
            return "";
        }
        public static int GetAccountId(string accountName)
        {
            Account account = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.FirstOrDefault(x => x.Name == accountName);
            if (account != null)
            {
                return account.Id;
            }
            return 0;
        }
        public static Account AccountExists(bool isName, string name, int Id)
        {
            Account account;
            switch (isName)
            {
                case true:
                    account = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.FirstOrDefault(x => x.Name == name);
                    break;
                case false:
                    account = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.FirstOrDefault(x => x.Id == Id);
                    break;
                default:
                    account = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.FirstOrDefault(x => x.Id == Id);
                    break;
            }
            if (account != null)
                return account;
            else
                return null;
        }
        public static bool IsRightAccount(string name, int AccountGeneralId)
        {
            Account account = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.FirstOrDefault(x => x.Name == name);
            if (account.AccountGeneralId == AccountGeneralId || account.Id == AccountGeneralId)
                return true;
            else return false;

        }
        public static Account AccountExists<T>(Func<Account, bool> predicate)
        {
            try
            {
                var account = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(predicate);
                if (account != null)
                    return account.FirstOrDefault();
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Article ArticaleExists(string name)
        {
            try
            {
                var art = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Name == name || x.EnglishName == name);
                if (art != null)
                    return art;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static Article ArticaleExists(bool isName, string name, int Id)
        {
            Article articale = null;
            switch (isName)
            {
                case true:
                    articale = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Include(x => x.PriceTagMasters).FirstOrDefault(x => x.Name == name);
                    break;
                case false:
                    articale = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Include(x => x.PriceTagMasters).FirstOrDefault(x => x.Id == Id);
                    break;
                default:
                    break;
            }
            if (articale != null)
                return articale;
            else
                return null;
        }
        public static Article ArticleExistsNameOrBarcode(string name)
        {
            try
            {
                Article article = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Include(x => x.PriceTagMasters).FirstOrDefault(x => x.Name == name || x.EnglishName == name || x.Barcode == name);
                return article;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string GetArticaleBarcodeForBalanceFirstTime(string name)
        {
            try
            {
                string ArticleBarcode = ShefaaPharmacyDbContext.GetCurrentContext().Articles.FirstOrDefault(x => x.Name == name).Barcode;
                return ArticleBarcode;
            }
            catch (Exception)
            {
                return "0";
            }

        }
        public static Company CompanyExists(bool isName, string name, int Id)
        {
            Company company;
            switch (isName)
            {
                case true:
                    company = ShefaaPharmacyDbContext.GetCurrentContext().Companys.FirstOrDefault(x => x.Name == name);
                    break;
                case false:
                    company = ShefaaPharmacyDbContext.GetCurrentContext().Companys.FirstOrDefault(x => x.Id == Id);
                    break;
                default:
                    company = ShefaaPharmacyDbContext.GetCurrentContext().Companys.FirstOrDefault(x => x.Id == Id);
                    break;
            }
            if (company != null)
                return company;
            else
                return null;
        }
        public static Format FormatExistsAndCreate(string name)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            if (name == "")
            {
                return context.Formats.FirstOrDefault();
            }
            var format = context.Formats.FirstOrDefault(x => x.Name == name);
            if (format == null)
            {
                format = new Format()
                {
                    Name = name
                };
                format = context.Add(format).Entity;
                context.SaveChanges();
                return format;
            }
            else
            {
                return format;
            }
        }
        public static Format FormatExists(bool isName, string name, int id)
        {
            Format format;
            switch (isName)
            {
                case true:
                    format = ShefaaPharmacyDbContext.GetCurrentContext().Formats.FirstOrDefault(x => x.Name == name);
                    break;
                case false:
                    format = ShefaaPharmacyDbContext.GetCurrentContext().Formats.FirstOrDefault(x => x.Id == id);
                    break;
                default:
                    format = ShefaaPharmacyDbContext.GetCurrentContext().Formats.FirstOrDefault(x => x.Id == id);
                    break;
            }
            if (format != null)
                return format;
            else
                return null;
        }
        public static PriceTagMaster PriceTagExists(int articleId)
        {
            PriceTagMaster priceTag = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == articleId).Include(x => x.PriceTagDetails).OrderBy(x => x.CreationDate).FirstOrDefault();
            return priceTag;
        }
        public static string GetFormatName(int? formatId)
        {
            if (formatId == 0 || formatId == null)
            {
                return "";
            }
            try
            {
                return ShefaaPharmacyDbContext.GetCurrentContext().Formats.FirstOrDefault(x => x.Id == formatId).Name;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static int GetFormatId(string FormatIdDescr)
        {
            ShefaaPharmacyDbContext context = new ShefaaPharmacyDbContext();
            if (FormatIdDescr == "" || FormatIdDescr == null)
            {
                return 0;
            }
            try
            {
                return context.Formats.FirstOrDefault(x => x.Name == FormatIdDescr).Id;
            }
            catch (Exception)
            {
                Format mine = new Format();
                int lastid = context.Formats.Max(x => x.Id);
                mine.Id = ++lastid;
                mine.Name = FormatIdDescr;

                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Formats ON;");
                    context.Formats.Add(mine);

                    context.SaveChanges();

                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Formats OFF;");
                    transaction.Commit();
                }
                return mine.Id;
            }
        }
        public static void GetAllChild(int? articleId)
        {
            if (articleId == null)
            {
                return;
            }
            var allChild = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.ArticleIdGeneral == articleId).ToList();
            foreach (var item in allChild)
            {
                if (item.ItsGeneral)
                {
                    GetAllChild(item.Id);
                }
                else
                {
                    articlesForPicker.Add(item);
                }
            }
        }
        public static void GetAllArticleInCompany(int companyId)
        {
            articlesForPicker = new List<Article>();
            articlesForPicker = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.CompanyId == companyId).ToList();
        }
        public static void GetAllReportsForThisInvoiceType(string InvoiceKind)
        {
            InvoiceKind value = (InvoiceKind)Enum.Parse(typeof(InvoiceKind), InvoiceKind);
            TaxDetailsForPicker = new List<DetailedTaxCode>();
            TaxDetailsForPicker = ShefaaPharmacyDbContext.GetCurrentContext().DetailedTaxCode.Where(x => x.InvoiceKind == value).ToList();
        }
        public static T GetValueByShortName<T>(string shortName)
        {
            var values = from f in typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public)
                         let attribute = Attribute.GetCustomAttribute(f, typeof(InvoiceKind)) as DisplayAttribute
                         where attribute != null && attribute.ShortName == shortName
                         select (T)f.GetValue(null);

            if (values.Count() > 0)
            {
                return (T)(object)values.FirstOrDefault();
            }
            return default(T);
        }
        public static void GetArticlesForCompany(int companyId)
        {
            articlesForPicker = articlesForPicker.Where(x => x.CompanyId == companyId).ToList();
        }
        public static bool IsValid(params object[] data)
        {
            foreach (var item in data)
            {
                if (item == null)
                {
                    return false;
                }
                if (item.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty(item as string))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static PriceTagMaster GetLastPriceTagForArt(int articleId)
        {
            try
            {
                return ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                    .Where(x => x.ArticleId == articleId)
                    .Include(x => x.PriceTagDetails)
                    .OrderByDescending(x => x.CreationDate)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static PriceTagMaster GetLastPriceTagForArticle(int articleId)
        {
            try
            {
                PriceTagMaster priceTagMaster = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                    .Where(x => x.ArticleId == articleId && (x.CountAllItem + x.CountGiftItem) > (x.CountSoldItem))
                    .Include(x => x.PriceTagDetails)
                    .OrderByDescending(x => x.CreationDate)
                    .FirstOrDefault();
                return priceTagMaster;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<PriceTagMaster> GetOldestExpiryDate(int articleId)
        {
            try
            {
                var articalepricetags = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == articleId).Include(x => x.PriceTagDetails).ToList();
                int s = 0;
                var tosendback = articalepricetags
                    .Where(x => ((x.CountAllItem + x.CountGiftItem) - x.CountSoldItem) > 0 || ((x.CountAllItem + x.CountGiftItem) - x.CountSoldItem) < 0)
                    .OrderByDescending(x => x.ExpiryDate)
                    .ToList();

                return tosendback;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<PurchesBillViewModel> ConvertBillDetailToPurchesBill(List<BillDetail> billDetails)
        {
            List<PurchesBillViewModel> purchesBillViewModel = new List<PurchesBillViewModel>();
            PriceTagMaster priceTagMaster = new PriceTagMaster();
            foreach (var item in billDetails)
            {
                priceTagMaster = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                    .Include(x => x.PriceTagDetails)
                    .FirstOrDefault(x => x.Id == item.PriceTagId);
                PurchesBillViewModel purchaes = new PurchesBillViewModel();
                purchaes.ArticleId = item.ArticaleId;
                purchaes.Barcode = item.Barcode;
                purchaes.BarcodeDescr = item.BarcodeDescr;
                purchaes.BaseUnitId = item.UnitTypeId;
                purchaes.Gift = item.QuantityGift;
                purchaes.PurchasePrice = item.Price;
                purchaes.SellPrice = priceTagMaster.PriceTagDetails.FirstOrDefault(x => x.UnitId == item.UnitTypeId).SellPrice;
                purchaes.UnitId = item.UnitTypeId;
                purchaes.ExpiryDate = priceTagMaster.ExpiryDate;
                purchaes.Quantity = item.Quantity;
                purchesBillViewModel.Add(purchaes);
            }
            return purchesBillViewModel;
        }
        public static ArticleUnits ArticleUnitExists(int artId, string name)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            UnitType unitType = context.UnitTypes.FirstOrDefault(x => x.Name == name);
            if (unitType != null)
            {
                return context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitType.Id);
            }
            return null;
        }
        public static int GetPrimaryUnitMobile(ShefaaPharmacyDbContext context, int articleId)
        {
            try
            {
                return context.ArticleUnits.FirstOrDefault(x => x.IsPrimary && x.ArticleId == articleId).UnitTypeId;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static string GetAccountNameMobile(ShefaaPharmacyDbContext context, int? accountId)
        {
            if (accountId == null)
            {
                return "";
            }
            Account account = context.Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account != null)
            {
                return account.Name;
            }
            return "";
        }
        public static int GetAccountIdMobile(ShefaaPharmacyDbContext context, string accountName)
        {
            Account account = context.Accounts.FirstOrDefault(x => x.Name == accountName);
            if (account != null)
            {
                return account.Id;
            }
            return 0;
        }
        public static string GetArticaleNameMobile(ShefaaPharmacyDbContext context, int articaleId)
        {
            Article articale = context.Articles.FirstOrDefault(x => x.Id == articaleId);
            if (articale != null)
            {
                return articale.Name;
            }
            return "";
        }
        public static string GetUnitNameMobile(ShefaaPharmacyDbContext context, int unitTypeId)
        {
            UnitType unitType = context.UnitTypes.FirstOrDefault(x => x.Id == unitTypeId);
            if (unitType != null)
            {
                return unitType.Name;
            }
            return "";
        }
    }
}
