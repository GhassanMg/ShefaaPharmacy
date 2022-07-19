using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Services
{
    public class EntryService
    {
        public EntryMaster _EntryMaster { get; set; }
        public EntryService()
        {

        }
        public EntryService(EntryMaster entryMaster)
        {
            _EntryMaster = entryMaster;
        }
        public bool DeleteEntry()
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                context.EntryDetails.RemoveRange(_EntryMaster.EntryDetails);
                context.SaveChanges();
                _EntryMaster.EntryDetails.Clear();
                context.EntryMasters.Remove(_EntryMaster);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EditEntry()
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                context.EntryMasters.Update(_EntryMaster);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //_MessageBoxDialog.Show(ex.Message, "خطأ");
                return false;
            }

        }
        public static void EditEntryDetail(int DetailId, int accountId, double debit, double credit, DateTime datetime, string description = "")
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var Entry = context.EntryDetails.FirstOrDefault(x => x.Id == DetailId);
            Entry.AccountId = accountId;
            Entry.Credit = credit;
            Entry.Debit = debit;
            Entry.Description = description;
            Entry.CreationDate = datetime;
            context.EntryDetails.Update(Entry);
            context.SaveChanges();
        }
        public static EntryMaster CalcTotal(EntryMaster entryMaster, List<EntryDetail> entryDetails)
        {
            entryMaster.TotalCredit = 0;
            entryMaster.TotalDebit = 0;
            entryMaster.Balance = 0;
            foreach (var item in entryDetails)
            {
                entryMaster.TotalCredit += item.Credit;
                entryMaster.TotalDebit += item.Debit;
            }
            entryMaster.Balance = Math.Abs(entryMaster.TotalCredit - entryMaster.TotalDebit);
            return entryMaster;
        }
        public static void InsertEntryReturnBillBuy(BillMaster billMaster)
        {
            try
            {
                if (billMaster.PaymentMethod == PaymentMethod.Cash)
                {
                    ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    int AccountDiscountId = context.Accounts.FirstOrDefault(x => x.Name == "الحسم").Id;
                    EntryMaster entryMaster = MakeEntryMaster(billMaster.Id, billMaster.TotalPrice, billMaster.TotalPrice, KindOperation.Return);
                    entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                    context.SaveChanges();
                    List<EntryDetail> entryDetails = new List<EntryDetail>();
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.TotalPrice, KindOperation.Return, entryMaster.Id, DescriptionFK.GetAccountName(billMaster.AccountId)));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.BuyAccountId, billMaster.TotalPrice, 0, KindOperation.Return, entryMaster.Id, "المشتريات"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.Payment, 0, KindOperation.Return, entryMaster.Id, DescriptionFK.GetAccountName(billMaster.AccountId)));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.CashAccountId, 0, billMaster.Payment, KindOperation.Return, entryMaster.Id, "الصندوق"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.Discount, 0, KindOperation.Buy, entryMaster.Id, billMaster.AccountIdDescr));
                    entryDetails.Add(MakeEntryDetail(AccountDiscountId, 0,  billMaster.Discount, KindOperation.Return, entryMaster.Id, DescriptionFK.GetAccountName(AccountDiscountId)));
                    double totDebit = 0;
                    double totCredit = 0;
                    entryDetails.ForEach(x => totCredit += x.Credit);
                    entryDetails.ForEach(x => totDebit += x.Debit);
                    entryMaster.TotalCredit = totCredit;
                    entryMaster.TotalDebit = totDebit;
                    context.EntryMasters.Update(entryMaster);
                    context.SaveChanges();
                    context.EntryDetails.AddRange(entryDetails);
                    context.SaveChanges();
                }
                else if (billMaster.PaymentMethod == PaymentMethod.Debit)
                {
                    ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    int AccountDiscountId = context.Accounts.FirstOrDefault(x => x.Name == "الحسم").Id;
                    EntryMaster entryMaster = MakeEntryMaster(billMaster.Id, billMaster.TotalPrice, billMaster.TotalPrice, KindOperation.Return);
                    entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                    context.SaveChanges();
                    List<EntryDetail> entryDetails = new List<EntryDetail>();
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.TotalPrice, KindOperation.Return, entryMaster.Id, billMaster.AccountIdDescr));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.BuyAccountId, billMaster.TotalPrice, 0, KindOperation.Return, entryMaster.Id, "المشتريات"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.Payment, 0, KindOperation.Return, entryMaster.Id, billMaster.AccountIdDescr));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.CashAccountId, 0, billMaster.Payment, KindOperation.Return, entryMaster.Id, "الصندوق"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.Discount, 0, KindOperation.Buy, entryMaster.Id, billMaster.AccountIdDescr));
                    entryDetails.Add(MakeEntryDetail(AccountDiscountId, 0, billMaster.Discount, KindOperation.Return, entryMaster.Id, DescriptionFK.GetAccountName(AccountDiscountId)));
                    double totDebit = 0;
                    double totCredit = 0;
                    entryDetails.ForEach(x => totCredit += x.Credit);
                    entryDetails.ForEach(x => totDebit += x.Debit);
                    entryMaster.TotalCredit = totCredit;
                    entryMaster.TotalDebit = totDebit;
                    context.EntryMasters.Update(entryMaster);
                    context.SaveChanges();
                    context.EntryDetails.AddRange(entryDetails);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertEntryBillBuy(BillMaster billMaster)
        {
            try
            {
                if (billMaster.PaymentMethod == PaymentMethod.Cash)
                {
                    ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    int AccountDiscountId = context.Accounts.FirstOrDefault(x => x.Name == "الحسم").Id;
                    EntryMaster entryMaster = MakeEntryMaster(billMaster.Id, billMaster.TotalPrice, billMaster.TotalPrice, KindOperation.Buy);
                    entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                    context.SaveChanges();
                    List<EntryDetail> entryDetails = new List<EntryDetail>();
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.TotalPrice, KindOperation.Buy, entryMaster.Id, "المورد"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.BuyAccountId, billMaster.TotalPrice, 0, KindOperation.Buy, entryMaster.Id, "المشتريات"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.Payment, 0, KindOperation.Buy, entryMaster.Id, "المورد"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.CashAccountId, 0, billMaster.Payment, KindOperation.Buy, entryMaster.Id, "الصندوق"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.Discount, 0, KindOperation.Buy, entryMaster.Id, "المورد"));
                    entryDetails.Add(MakeEntryDetail(AccountDiscountId, 0,  billMaster.Discount, KindOperation.Buy, entryMaster.Id, DescriptionFK.GetAccountName(AccountDiscountId)));
                    double totDebit = 0;
                    double totCredit = 0;
                    entryDetails.ForEach(x => totCredit += x.Credit);
                    entryDetails.ForEach(x => totDebit += x.Debit);
                    entryMaster.TotalCredit = totCredit;
                    entryMaster.TotalDebit = totDebit;
                    context.EntryMasters.Update(entryMaster);
                    context.SaveChanges();
                    context.EntryDetails.AddRange(entryDetails);
                    context.SaveChanges();
                }
                else if (billMaster.PaymentMethod == PaymentMethod.Debit)
                {
                    ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    int AccountDiscountId = context.Accounts.FirstOrDefault(x => x.Name == "الحسم").Id;
                    EntryMaster entryMaster = MakeEntryMaster(billMaster.Id, billMaster.TotalPrice, billMaster.TotalPrice, KindOperation.Buy);
                    entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                    context.SaveChanges();
                    List<EntryDetail> entryDetails = new List<EntryDetail>();
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.TotalPrice, KindOperation.Buy, entryMaster.Id, "المورد"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.BuyAccountId, billMaster.TotalPrice, 0, KindOperation.Buy, entryMaster.Id, "المشتريات"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.Payment, 0, KindOperation.Buy, entryMaster.Id, "المورد"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.CashAccountId, 0, billMaster.Payment, KindOperation.Buy, entryMaster.Id, "الصندوق"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.Discount, 0, KindOperation.Buy, entryMaster.Id, "المورد"));
                    entryDetails.Add(MakeEntryDetail(AccountDiscountId, 0, billMaster.Discount, KindOperation.Buy, entryMaster.Id, DescriptionFK.GetAccountName(AccountDiscountId)));
                    double totDebit = 0;
                    double totCredit = 0;
                    entryDetails.ForEach(x => totCredit += x.Credit);
                    entryDetails.ForEach(x => totDebit += x.Debit);
                    entryMaster.TotalCredit = totCredit;
                    entryMaster.TotalDebit = totDebit;
                    context.EntryMasters.Update(entryMaster);
                    context.SaveChanges();
                    context.EntryDetails.AddRange(entryDetails);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertEntryReturnBillSell(BillMaster billMaster)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            int AccountDiscountId = context.Accounts.FirstOrDefault(x => x.Name == "الحسم").Id;
            try
            {
                if (billMaster.PaymentMethod == PaymentMethod.Cash)
                {
                    //ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    EntryMaster entryMaster = MakeEntryMaster(billMaster.Id, billMaster.TotalPrice, billMaster.TotalPrice, KindOperation.Return);
                    entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                    context.SaveChanges();
                    List<EntryDetail> entryDetails = new List<EntryDetail>();
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.TotalPrice, 0, KindOperation.Return, entryMaster.Id, "حساب المندوب"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.SellAccountId, 0, billMaster.TotalPrice, KindOperation.Return, entryMaster.Id, "المبيعات"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.CashAccountId, billMaster.Payment, 0, KindOperation.Return, entryMaster.Id, "الصندوق"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.Payment, KindOperation.Return, entryMaster.Id, "حساب المندوب"));
                    entryDetails.Add(MakeEntryDetail(AccountDiscountId, billMaster.TotalPrice - billMaster.Payment, 0, KindOperation.Return, entryMaster.Id, DescriptionFK.GetAccountName(AccountDiscountId)));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.TotalPrice - billMaster.Payment, KindOperation.Sell, entryMaster.Id, "حساب المندوب"));
                    double totDebit = 0;
                    double totCredit = 0;
                    entryDetails.ForEach(x => totCredit += x.Credit);
                    entryDetails.ForEach(x => totDebit += x.Debit);
                    entryMaster.TotalCredit = totCredit;
                    entryMaster.TotalDebit = totDebit;
                    context.EntryMasters.Update(entryMaster);
                    context.SaveChanges();
                    context.EntryDetails.AddRange(entryDetails);
                    context.SaveChanges();
                }
                else if (billMaster.PaymentMethod == PaymentMethod.Debit)
                {
                    //ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    EntryMaster entryMaster = MakeEntryMaster(billMaster.Id, billMaster.TotalPrice, billMaster.TotalPrice, KindOperation.Sell);
                    entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                    context.SaveChanges();
                    List<EntryDetail> entryDetails = new List<EntryDetail>();
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.TotalPrice, 0, KindOperation.Return, entryMaster.Id, "حساب المندوب"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.SellAccountId, 0, billMaster.TotalPrice, KindOperation.Return, entryMaster.Id, "المبيعات"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.CashAccountId, billMaster.Payment, 0, KindOperation.Return, entryMaster.Id, "الصندوق"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.Payment, KindOperation.Return, entryMaster.Id, "حساب المندوب"));
                    entryDetails.Add(MakeEntryDetail(AccountDiscountId, billMaster.Discount, 0, KindOperation.Return, entryMaster.Id, DescriptionFK.GetAccountName(AccountDiscountId)));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.Discount, KindOperation.Sell, entryMaster.Id, "حساب المندوب"));
                    double totDebit = 0;
                    double totCredit = 0;
                    entryDetails.ForEach(x => totCredit += x.Credit);
                    entryDetails.ForEach(x => totDebit += x.Debit);
                    entryMaster.TotalCredit = totCredit;
                    entryMaster.TotalDebit = totDebit;
                    context.EntryMasters.Update(entryMaster);
                    context.SaveChanges();
                    context.EntryDetails.AddRange(entryDetails);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertEntryBillSell(BillMaster billMaster)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            int AccountDiscountId = context.Accounts.FirstOrDefault(x => x.Name == "الحسم").Id;
            try
            {
                if (billMaster.PaymentMethod == PaymentMethod.Cash)
                {
                    //ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    EntryMaster entryMaster = MakeEntryMaster(billMaster.Id, billMaster.TotalPrice, billMaster.TotalPrice, KindOperation.Sell);
                    entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                    context.SaveChanges();
                    List<EntryDetail> entryDetails = new List<EntryDetail>();
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.TotalPrice, 0, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.SellAccountId, 0, billMaster.TotalPrice, KindOperation.Sell, entryMaster.Id, "المبيعات"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.CashAccountId, billMaster.Payment, 0, KindOperation.Sell, entryMaster.Id, "الصندوق")); 
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.Payment, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    entryDetails.Add(MakeEntryDetail(AccountDiscountId,billMaster.TotalPrice - billMaster.Payment,0, KindOperation.Sell, entryMaster.Id, DescriptionFK.GetAccountName(AccountDiscountId)));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.TotalPrice - billMaster.Payment, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    double totDebit = 0;
                    double totCredit = 0;
                    entryDetails.ForEach(x => totCredit += x.Credit);
                    entryDetails.ForEach(x => totDebit += x.Debit);
                    entryMaster.TotalCredit = totCredit;
                    entryMaster.TotalDebit = totDebit;
                    context.EntryMasters.Update(entryMaster);
                    context.SaveChanges();
                    context.EntryDetails.AddRange(entryDetails);
                    context.SaveChanges();
                }
                else if (billMaster.PaymentMethod == PaymentMethod.Debit)
                {
                    //ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    EntryMaster entryMaster = MakeEntryMaster(billMaster.Id, billMaster.TotalPrice, billMaster.TotalPrice, KindOperation.Sell);
                    entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                    context.SaveChanges();
                    List<EntryDetail> entryDetails = new List<EntryDetail>();
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.TotalPrice, 0, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.SellAccountId, 0, billMaster.TotalPrice, KindOperation.Sell, entryMaster.Id, "المبيعات"));
                    entryDetails.Add(MakeEntryDetail(UserLoggedIn.User.UserPermissions.CashAccountId, billMaster.Payment, 0, KindOperation.Sell, entryMaster.Id, "الصندوق"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.Payment, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    entryDetails.Add(MakeEntryDetail(AccountDiscountId,  billMaster.Discount,0, KindOperation.Sell, entryMaster.Id, DescriptionFK.GetAccountName(AccountDiscountId)));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.Discount, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    double totDebit = 0;
                    double totCredit = 0;
                    entryDetails.ForEach(x => totCredit += x.Credit);
                    entryDetails.ForEach(x => totDebit += x.Debit);
                    entryMaster.TotalCredit = totCredit;
                    entryMaster.TotalDebit = totDebit;
                    context.EntryMasters.Update(entryMaster);
                    context.SaveChanges();
                    context.EntryDetails.AddRange(entryDetails);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static EntryDetail MakeEntryDetail(int accountId, double debit, double credit, KindOperation kindOperation, int masterId = 0, string description = "")
        {
            EntryDetail entryDetail = new EntryDetail()
            {
                AccountId = accountId,
                Debit = debit,
                KindOperation = kindOperation,
                Credit = credit,
                Description = description
            };
            if (masterId != 0)
            {
                entryDetail.EntryMasterId = masterId;
            }
            return entryDetail;
        }

        public static EntryMaster MakeEntryMaster(int realatedDoc, double totDebit, double totCredit, KindOperation kindOperation)
        {
            return new EntryMaster()
            {
                RelatedDocument = realatedDoc,
                TotalDebit = totDebit,
                KindOperation = kindOperation,
                TotalCredit = totCredit,
                Balance = 0,
            };
        }
        public static bool PaymentAccount(int cashAccountId, int accountId, double amount, DateTime dateTime, string description = "", PayingCashState payingCashState = PayingCashState.InComing)
        {
            try
            {
                if (dateTime == null)
                {
                    dateTime = DateTime.Now;
                }
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                EntryMaster entryMaster = MakeEntryMaster(0, amount, amount, KindOperation.Payment);
                entryMaster.CreationDate = dateTime;
                var entity = context.EntryMasters.Add(entryMaster);
                context.SaveChanges();
                List<EntryDetail> entryDetails = new List<EntryDetail>();
                EntryDetail entryDetail;
                if (payingCashState == PayingCashState.InComing)
                {
                    entryDetail = MakeEntryDetail(cashAccountId, amount, 0, KindOperation.Payment, entity.Entity.Id, description == "" ? "دفعة حساب" : description);
                    entryDetail.CreationDate = dateTime;
                    entryDetails.Add(entryDetail);
                    entryDetail = MakeEntryDetail(accountId, 0, amount, KindOperation.Payment, entity.Entity.Id, description == "" ? "دفعة حساب" : description);
                    entryDetail.CreationDate = dateTime;
                    entryDetails.Add(entryDetail);
                }
                else
                {
                    entryDetail = MakeEntryDetail(cashAccountId, 0, amount, KindOperation.Payment, entity.Entity.Id, description == "" ? "دفعة حساب" : description);
                    entryDetail.CreationDate = dateTime;
                    entryDetails.Add(entryDetail);
                    entryDetail = MakeEntryDetail(accountId, amount, 0, KindOperation.Payment, entity.Entity.Id, description == "" ? "دفعة حساب" : description);
                    entryDetail.CreationDate = dateTime;
                    entryDetails.Add(entryDetail);
                }
                context.EntryDetails.AddRange(entryDetails);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void InsertEntryBillSellMobile(ShefaaPharmacyDbContext context, BillMaster billMaster, User user)
        {
            int AccountDiscountId = context.Accounts.FirstOrDefault(x => x.Name == "الحسم").Id;
            try
            {
                if (billMaster.PaymentMethod == PaymentMethod.Cash)
                {
                    // ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    EntryMaster entryMaster = MakeEntryMaster(billMaster.Id, billMaster.TotalPrice, billMaster.TotalPrice, KindOperation.Sell);
                    entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                    entryMaster.CreationBy = billMaster.CreationBy;
                    entryMaster.YearId = billMaster.YearId;
                    context.SaveChanges();
                    List<EntryDetail> entryDetails = new List<EntryDetail>();
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.TotalPrice, 0, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    entryDetails.Add(MakeEntryDetail(user.UserPermissions.SellAccountId, 0, billMaster.TotalPrice, KindOperation.Sell, entryMaster.Id, "المبيعات"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.Payment, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    entryDetails.Add(MakeEntryDetail(user.UserPermissions.CashAccountId, billMaster.Payment, 0, KindOperation.Sell, entryMaster.Id, "الصندوق"));
                    entryDetails.Add(MakeEntryDetail(AccountDiscountId, billMaster.TotalPrice - billMaster.Payment, 0, KindOperation.Sell, entryMaster.Id, DescriptionFK.GetAccountName(AccountDiscountId)));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.TotalPrice - billMaster.Payment, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    double totDebit = 0;
                    double totCredit = 0;
                    entryDetails.ForEach(x => totCredit += x.Credit);   
                    entryDetails.ForEach(x => totDebit += x.Debit);
                    entryMaster.TotalCredit = totCredit;
                    entryMaster.TotalDebit = totDebit;
                    context.EntryMasters.Update(entryMaster);
                    context.SaveChanges();
                    entryDetails.ForEach(x => x.CreationBy = entryMaster.CreationBy);

                    context.EntryDetails.AddRange(entryDetails);
                    context.SaveChanges();
                }

                else if (billMaster.PaymentMethod == PaymentMethod.Debit)
                {
                    // ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                    EntryMaster entryMaster = MakeEntryMaster(billMaster.Id, billMaster.TotalPrice, billMaster.TotalPrice, KindOperation.Sell);
                    entryMaster = context.EntryMasters.Add(entryMaster).Entity;
                    entryMaster.CreationBy = billMaster.CreationBy;
                    entryMaster.YearId = billMaster.YearId;
                    context.SaveChanges();
                    List<EntryDetail> entryDetails = new List<EntryDetail>();
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, billMaster.TotalPrice, 0, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    entryDetails.Add(MakeEntryDetail(user.UserPermissions.SellAccountId, 0, billMaster.TotalPrice, KindOperation.Sell, entryMaster.Id, "المبيعات"));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.Payment, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    entryDetails.Add(MakeEntryDetail(user.UserPermissions.CashAccountId, billMaster.Payment, 0, KindOperation.Sell, entryMaster.Id, "الصندوق"));
                    entryDetails.Add(MakeEntryDetail(AccountDiscountId, billMaster.Discount, 0, KindOperation.Sell, entryMaster.Id, DescriptionFK.GetAccountName(AccountDiscountId)));
                    entryDetails.Add(MakeEntryDetail(billMaster.AccountId, 0, billMaster.Discount, KindOperation.Sell, entryMaster.Id, "حساب الزبون"));
                    double totDebit = 0;
                    double totCredit = 0;
                    entryDetails.ForEach(x => totCredit += x.Credit);
                    entryDetails.ForEach(x => totDebit += x.Debit);
                    entryMaster.TotalCredit = totCredit;
                    entryMaster.TotalDebit = totDebit;
                    context.EntryMasters.Update(entryMaster);
                    context.SaveChanges();
                    entryDetails.ForEach(x => x.CreationBy = entryMaster.CreationBy);
                    context.EntryDetails.AddRange(entryDetails);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
