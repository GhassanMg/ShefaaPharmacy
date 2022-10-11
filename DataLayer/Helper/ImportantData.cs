using DataLayer.Tables;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Helper
{
    public static  class ImportantData
    {
        public static List<Account> AllAccount;
        public static List<AccountCategory> AllAccountCategory;
        public static List<Article> AllArticle;
        public static void GetImportantData(ShefaaPharmacyDbContext context)
        {
            AllAccount = context.Accounts.ToList() ;
            AllAccountCategory = context.AccountCategorys.ToList();
            AllArticle = context.Articles.ToList();
        }
    }
}
