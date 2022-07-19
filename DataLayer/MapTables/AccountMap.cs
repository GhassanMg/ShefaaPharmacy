using DataLayer.Helper;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.MapTables
{
    public class AccountMap
    {
        public AccountMap()
        {

        }
        public AccountMap(EntityTypeBuilder<AccountCategory> entity)
        {
            entity.ToTable("AccountCategory");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
        }

        public AccountMap(EntityTypeBuilder<Account> entity)
        {
            entity.ToTable("Account");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.LastName)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Tel)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Tel2)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Address)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Address2)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.Description)
                .HasDefaultValueSql("('')");
            entity.Property(e => e.CreationDate)
                .HasDefaultValue(DateTime.Now);
            //entity.ToTable("AccountCategory");
            //entity.HasOne(e => e.AccountCategory)
            //    .WithMany(p => p.Accounts)
            //    .HasForeignKey(b => b.AccountCategoryId)
            //    .HasConstraintName("FK_Account_AccountCategory");
        }
        public void SeedData(EntityTypeBuilder<Account> entity)
        {
            #region General
            entity.HasData(new Account() { Id = 1, Name = "الحساب العام", CategoryId = ConstantDataBase.AC_GeneralAccount, General = true, AccountGeneralId = null, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 2, Name = "الزبائن", CategoryId = ConstantDataBase.AC_Customer, General = true, AccountGeneralId = 1, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 3, Name = "الصناديق", CategoryId = ConstantDataBase.AC_Cash, General = true, AccountGeneralId = 1, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 4, Name = "المبيعات", CategoryId = ConstantDataBase.AC_Sales, General = true, AccountGeneralId = 1, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 5, Name = "المشتريات", CategoryId = ConstantDataBase.AC_Purchases, General = true, AccountGeneralId = 1, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 6, Name = "المندوبين", CategoryId = ConstantDataBase.AC_Supplier, General = true, AccountGeneralId = 1, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 7, Name = "الضرائب", CategoryId = ConstantDataBase.AC_Tax, General = true, AccountGeneralId = 1, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 8, Name = "المصاريف", CategoryId = ConstantDataBase.AC_Expense, General = true, AccountGeneralId = 1, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 9, Name = "رأس المال", CategoryId = ConstantDataBase.AC_Profits, General = true, AccountGeneralId = 1, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 10, Name = "الموجودات", CategoryId = ConstantDataBase.AC_Asset, General = true, AccountGeneralId = 1, CreationDate = DateTime.Now, CreationBy = 2 });
            #endregion

            #region Non General
            entity.HasData(new Account() { Id = 11, Name = "زبائن الصيدلية", CategoryId = ConstantDataBase.AC_Customer, General = false, AccountGeneralId = 2, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 12, Name = "صندوق الصيدلية", CategoryId = ConstantDataBase.AC_Cash, General = false, AccountGeneralId = 3, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 13, Name = "مبيعات الصيدلية", CategoryId = ConstantDataBase.AC_Sales, General = false, AccountGeneralId = 4, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 14, Name = "مشتريات الصيدلية", CategoryId = ConstantDataBase.AC_Purchases, General = false, AccountGeneralId = 5, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 15, Name = "ضريبة الصيدلية", CategoryId = ConstantDataBase.AC_Tax, General = false, AccountGeneralId = 7, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 16, Name = "مندوب عام", CategoryId = ConstantDataBase.AC_Supplier, General = false, AccountGeneralId = 6, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 17, Name = "مصروف الصيدلية", CategoryId = ConstantDataBase.AC_Expense, General = false, AccountGeneralId = 8, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 18, Name = "رأس مال الصيدلية", CategoryId = ConstantDataBase.AC_Profits, General = false, AccountGeneralId = 9, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 19, Name = "مخزن الأدوية", CategoryId = ConstantDataBase.AC_Asset, General = false, AccountGeneralId = 10, CreationDate = DateTime.Now, CreationBy = 2 });
            entity.HasData(new Account() { Id = 20, Name = "مخزن المواد منتهية الصلاحية", CategoryId = ConstantDataBase.AC_Profits, General = false, AccountGeneralId = 8, CreationDate = DateTime.Now, CreationBy = 2 });
            //entity.HasData(new Account() { Id = 21, Name = "الحسم", CategoryId = ConstantDataBase.AC_Profits, General = false, AccountGeneralId = 8, CreationDate = DateTime.Now, CreationBy = 2 });
            #endregion

        }

        public void SeedData(EntityTypeBuilder<AccountBaseCategory> entity)
        {
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_GeneralAccount, Name = ConstantDataBase.AC_GeneralAccountDescr });
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_Customer, Name = ConstantDataBase.AC_CustomerDescr });
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_Cash, Name = ConstantDataBase.AC_CashDescr });
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_Sales, Name = ConstantDataBase.AC_SalesDescr });
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_Purchases, Name = ConstantDataBase.AC_PurchasesDescr });
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_Supplier, Name = ConstantDataBase.AC_SupplierDescr });
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_Insurances, Name = ConstantDataBase.AC_InsurancesDescr });
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_Expense, Name = ConstantDataBase.AC_ExpenseDescr });
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_Tax, Name = ConstantDataBase.AC_TaxDescr });
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_Profits, Name = ConstantDataBase.AC_ProfitsDescr });
            entity.HasData(new AccountBaseCategory() { Id = ConstantDataBase.AC_Asset, Name = ConstantDataBase.AC_AssetDescr });
        }
    }
}
