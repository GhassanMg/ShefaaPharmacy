using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Tables;
using DataLayer.MapTables;
using DataLayer.Script.Procedures;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ShefaaPharmacyDbContext : DbContext
    {
        public static string ConStr;
        public DbSet<User> Users { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<ArticleCategory> ArticleCategorys { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountCategory> AccountCategorys { set; get; }
        public DbSet<BillMaster> BillMasters { set; get; }
        public DbSet<BillDetail> BillDetails { set; get; }
        public DbSet<OrderMaster> OrderMasters { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<EntryMaster> EntryMasters { set; get; }
        public DbSet<EntryDetail> EntryDetails { set; get; }
        public DbSet<Barcode> Barcodes { set; get; }
        public DbSet<UnitType> UnitTypes { set; get; }
        public DbSet<Branch> Branches { set; get; }
        public DbSet<Store> Stores { set; get; }
        public DbSet<PriceTagMaster> PriceTagMasters { set; get; }
        public DbSet<PriceTagDetail> PriceTagDetails { set; get; }
        public DbSet<Connection> Connections { set; get; }
        public DbSet<Company> Companys { set; get; }
        public DbSet<UserPermissions> UserPermissions { set; get; }
        public DbSet<UserNotifications> UserNotifications { set; get; }
        public DbSet<SettingNotifications> SettingNotifications { set; get; }
        public DbSet<AccountBaseCategory> AccountBaseCategorys { set; get; }
        public DbSet<DataBaseConfiguration> DataBaseConfigurations { set; get; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<ArticleUnits> ArticleUnits { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Medicines> Medicines { get; set; }
        public DbSet<FirstTimeArticles> FirstTimeArticles { get; set; }
        public DbSet<ExistStuff> ExistStuffs { get; set; }
        //public DbSet<LastTimeArticles> LastTimeArticles { get; set; }
        public DbSet<ExpiryTransfeerDetail> ExpiryTransfeerDetails { get; set; }
        public DbSet<TaxAccount> TaxAccount { get; set; }
        public DbSet<DetailedTaxCode> DetailedTaxCode { get; set; }
        public DbSet<PharmacyInformation> PharmacyInformation { get; set; }

        public ShefaaPharmacyDbContext()
        {

        }
        public ShefaaPharmacyDbContext(string connectionString) : base(GetOptions(connectionString))
        {

        }
        public ShefaaPharmacyDbContext(DbContextOptions<ShefaaPharmacyDbContext> options) : base(options)
        {

        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public static void Migrate()
        {
            GetCurrentContext().Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseSqlServer(@"Data Source=POST-5;Initial Catalog=TM_Fifth;Integrated Security=true;")
                .UseSqlServer(ConStr)
                .UseLoggerFactory(new LoggerFactory())
                .EnableSensitiveDataLogging();
        }
        public static void DeleteUnit(int articleid)
        {
            GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == articleid && x.UnitTypeId == articleid).ToList();
        }
        public static ShefaaPharmacyDbContext GetCurrentContext(bool Create = false)
        {
            ShefaaPharmacyDbContext context = new ShefaaPharmacyDbContext(ConStr);
            if (Create)
            {
                context.Database.EnsureCreated();
            }
            return context;
        }
        public static void WriteOnSetting(string conStr)
        {
            //Properties.Settings.Default["ConStr"] = conStr;
        }
        public static bool IsItMoreThanMonth()
        {
            //var cote = ShefaaPharmacyDbContext.GetCurrentContext();
            //try
            //{
            //    var firstday = cote.BillMasters.FirstOrDefault()?.CreationDate;
            //    var lastday = cote.BillMasters.LastOrDefault()?.CreationDate;
            //    if (firstday == null || lastday == null)
            //    {
            //        return false;
            //    }
            //    else if (firstday != null && lastday != null)
            //    {
            //        if (firstday == lastday)
            //        {
            //            return false;
            //        }
            //        else if (lastday > firstday.Value.AddMonths(1))
            //        {
            //            return true;
            //        }
            //    }
            //    return true;
            //}
            //catch
            //{
            return false;
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleUnits>()
                .HasKey(c => new { c.ArticleId, c.UnitTypeId });
            modelBuilder.Entity<Inventory>()
                .HasKey(c => new { c.ArticleId, c.UnitTypeId, c.BranchId, c.StoreId, c.PriceTagId });
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            new AccountMap(modelBuilder.Entity<Account>());
            new AccountMap(modelBuilder.Entity<AccountCategory>());

            new ArticaleMap(modelBuilder.Entity<ArticleCategory>());
            new ArticaleMap(modelBuilder.Entity<Article>());

            new BillMap(modelBuilder.Entity<BillMaster>());
            new BillMap(modelBuilder.Entity<BillDetail>());

            new EntryMap(modelBuilder.Entity<EntryMaster>());
            new EntryMap(modelBuilder.Entity<EntryDetail>());

            new BranchMap(modelBuilder.Entity<PriceTagMaster>());
            new BranchMap(modelBuilder.Entity<PriceTagDetail>());

            new BranchMap(modelBuilder.Entity<Branch>());

            new BasicMap(modelBuilder.Entity<Year>());
            new BasicMap(modelBuilder.Entity<User>());
            new BasicMap(modelBuilder.Entity<UnitType>());
            new BasicMap(modelBuilder.Entity<Barcode>());
            new BasicMap(modelBuilder.Entity<Connection>());
            new BasicMap(modelBuilder.Entity<Company>());

            new ExistStuffMap(modelBuilder.Entity<ExistStuff>());

            new ExpiryArticlesMap(modelBuilder.Entity<ExpiryTransfeerDetail>());

            new MedicinesMap(modelBuilder.Entity<Medicines>());

            new FirstTimeArticlesMap(modelBuilder.Entity<FirstTimeArticles>());

            new TaxAccountMap(modelBuilder.Entity<TaxAccount>());

            new DetailedTaxCodeMap(modelBuilder.Entity<DetailedTaxCode>());

            //new LastTimeArticlesMap(modelBuilder.Entity<LastTimeArticles>());
            #region Branches
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 1, Name = "جميع الفروع" });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 2, Name = "الفرع الرئيسي" });
            #endregion
            #region Stores
            modelBuilder.Entity<Store>().HasData(new Store { Id = 1, Name = "جميع المستودعات", BranchId = 2 });
            modelBuilder.Entity<Store>().HasData(new Store { Id = 2, Name = "المستودع الأول", BranchId = 2 });
            #endregion
            #region Users
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "All User", Password = "allUser", Position = Position.admin, BranchId = 1, StoreId = 1 });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, Name = "admin", Password = "admin", Position = Position.admin, BranchId = 2, StoreId = 2 });
            modelBuilder.Entity<User>().HasData(new User { Id = 3, Name = "manager", Password = "manager", Position = Position.manager, BranchId = 2, StoreId = 2 });
            modelBuilder.Entity<User>().HasData(new User { Id = 4, Name = "dataEntry", Password = "dataEntry", Position = Position.dataEntry, BranchId = 2, StoreId = 2 });
            modelBuilder.Entity<User>().HasData(new User { Id = 5, Name = "reportReader", Password = "reportReader", Position = Position.reportReader, BranchId = 2, StoreId = 2 });
            #endregion
            #region Years
            modelBuilder.Entity<Year>().HasData(new Year { Id = 1, Name = DateTime.Now.Year.ToString(), CreationDate = DateTime.Now, CreationBy = 2 });
            #endregion
            #region UnitTypes
            modelBuilder.Entity<UnitType>().HasData(new UnitType { Id = 1, Name = "لا يوجد", CreationDate = DateTime.Now, CreationBy = 2 });
            modelBuilder.Entity<UnitType>().HasData(new UnitType { Id = 2, Name = "طرد", CreationDate = DateTime.Now, CreationBy = 2 });
            modelBuilder.Entity<UnitType>().HasData(new UnitType { Id = 3, Name = "علبة", CreationDate = DateTime.Now, CreationBy = 2 });
            modelBuilder.Entity<UnitType>().HasData(new UnitType { Id = 4, Name = "ظرف", CreationDate = DateTime.Now, CreationBy = 2 });
            modelBuilder.Entity<UnitType>().HasData(new UnitType { Id = 5, Name = "حبة", CreationDate = DateTime.Now, CreationBy = 2 });
            modelBuilder.Entity<UnitType>().HasData(new UnitType { Id = 6, Name = "إبرة", CreationDate = DateTime.Now, CreationBy = 2 });
            #endregion
            #region ArticleCategories
            modelBuilder.Entity<ArticleCategory>().HasData(new ArticleCategory() { Id = ConstantDataBase.APC_Drugs, Name = ConstantDataBase.APC_DrugsDescr, CreationDate = DateTime.Now, CreationBy = 2 });
            modelBuilder.Entity<ArticleCategory>().HasData(new ArticleCategory() { Id = ConstantDataBase.APC_Accessories, Name = ConstantDataBase.APC_AccessoriesDescr, CreationDate = DateTime.Now, CreationBy = 2 });
            #endregion
            #region AccountBaseCategory
            new AccountMap().SeedData(modelBuilder.Entity<AccountBaseCategory>());
            #endregion
            new CompanyMap().SeedData(modelBuilder.Entity<Company>());
            #region Accounts
            new AccountMap().SeedData(modelBuilder.Entity<Account>());
            #endregion
            #region UserPermissionses
            new UserMap().SeedData(modelBuilder.Entity<UserPermissions>());
            #endregion
            #region Format
            new FormatMap().SeedData(modelBuilder.Entity<Format>());
            #endregion
            modelBuilder.Entity<DataBaseConfiguration>().HasData(new DataBaseConfiguration() { Id = 1, VersionNumber = "B12", DateIfNotUpdatedExternal = 10, DateIfNotUpdatedLocal = 30, DayForExpiry = 60, DiscountPercentage = 0, AccountTaxId = 12, TaxValue = 0, ValueSellPrice = 0 });
        }
        public void CreateStoredProcedure()
        {
            Database.ExecuteSqlRaw(GetProfitFromDateToDateScript.Create());
            Database.ExecuteSqlRaw(GetAccountDebitCreditScript.Create());
            Database.ExecuteSqlRaw(GetAccountMovementScript.Create());
            Database.ExecuteSqlRaw(GetFooterMovementCash.Create());
            Database.ExecuteSqlRaw(GetBillReport.Create());
            Database.ExecuteSqlRaw(GetProfitForYearScript.Create());
            Database.ExecuteSqlRaw(InsertNewSellBillDetailScript.Create());
            Database.ExecuteSqlRaw(InsertNewSellBillScript.Create());
            Database.ExecuteSqlRaw(IncresedOrDecresedQantityScript.Create());
            Database.ExecuteSqlRaw(UpdateInvintoryScript.Create());
            Database.ExecuteSqlRaw(InsertEntryScript.Create());
            Database.ExecuteSqlRaw(GetArticleForCompanyScript.Create());
            Database.ExecuteSqlRaw(EntryReportScript.Create());
            Database.ExecuteSqlRaw(GetArticleInStore.Create());
            Database.ExecuteSqlRaw(TaxReportScript.Create());
        }
        public void DropStoredProcedure()
        {
            Database.ExecuteSqlRaw(GetProfitFromDateToDateScript.Drop());
            Database.ExecuteSqlRaw(GetAccountDebitCreditScript.Drop());
            Database.ExecuteSqlRaw(GetAccountMovementScript.Drop());
            Database.ExecuteSqlRaw(GetFooterMovementCash.Drop());
            Database.ExecuteSqlRaw(GetBillReport.Drop());
            Database.ExecuteSqlRaw(GetProfitForYearScript.Drop());
            Database.ExecuteSqlRaw(InsertNewSellBillDetailScript.Drop());
            Database.ExecuteSqlRaw(InsertNewSellBillScript.Drop());
            Database.ExecuteSqlRaw(IncresedOrDecresedQantityScript.Drop());
            Database.ExecuteSqlRaw(UpdateInvintoryScript.Drop());
            Database.ExecuteSqlRaw(InsertEntryScript.Drop());
            Database.ExecuteSqlRaw(GetArticleForCompanyScript.Drop());
            Database.ExecuteSqlRaw(EntryReportScript.Drop());
            Database.ExecuteSqlRaw(GetArticleInStore.Drop());
            Database.ExecuteSqlRaw(TaxReportScript.Drop());
        }
        public static void CheckVersion()
        {
            DataModuleVersion dataModuleVersion = new DataModuleVersion();
            dataModuleVersion.checkedTableFromVersion("A1");
        }
        public static void BackUp()
        {
            DataModuleVersion dataModuleVersion = new DataModuleVersion();
            dataModuleVersion.BackUp();
        }
    }
}
