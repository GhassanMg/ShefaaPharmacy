using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Helper
{
    public static class ConstantDataBase
    {
        public static DateTime FirstDayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00,01);
        public static DateTime LastDayTime = new DateTime(FirstDayTime.Year, 12, 31, 23, 59,59);

        #region Account Category
        public static int AC_GeneralAccount = 1;
        public static string AC_GeneralAccountDescr = "حسابات عامة";
        public static int AC_Customer = 2;
        public static string AC_CustomerDescr = "زبائن";
        public static int AC_Cash = 3;
        public static string AC_CashDescr = "صناديق";
        public static int AC_Sales = 4;
        public static string AC_SalesDescr = "مبيعات";
        public static int AC_Purchases = 5;
        public static string AC_PurchasesDescr = "مشتريات";
        public static int AC_Supplier = 6;
        public static string AC_SupplierDescr = "موردين";
        public static int AC_Insurances = 7;
        public static string AC_InsurancesDescr = "تأمينات";
        public static int AC_Expense = 8;
        public static string AC_ExpenseDescr = "مصاريف";
        public static int AC_Tax = 9;
        public static string AC_TaxDescr = "ضرائب";
        public static int AC_Profits = 10;
        public static string AC_ProfitsDescr = "الأرباح ورأس المال";
        public static int AC_Asset = 11;
        public static string AC_AssetDescr = "الموجودات";

        #endregion
        #region Article Primary Category
        public static int APC_General = 1;
        public static string APC_GeneralDescr = "أصناف عامة";

        public static int APC_Drugs = 1;
        public static string APC_DrugsDescr = "أدوية";

        public static int APC_Accessories = 2;
        public static string APC_AccessoriesDescr = "اكسسوارات";
        #endregion
        #region Pa$$w0rd 
        public static string InstallingService = "adidas";
        #endregion
    }
}
