using DataLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Services
{
    public class PriceTagService
    {
        public static void SaveFirstTimeBalancePriceTag(List<BalanceFirstDurationViewModel> balanceFirstDurationViewModels)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var profitOnBuy = context.DataBaseConfigurations.FirstOrDefault().ValueSellPrice;
            var year = context.Years.OrderByDescending(x => x.CreationDate).FirstOrDefault().Id;
            //foreach (var item in balanceFirstDurationViewModels)
            //{
            //    PriceTag data = new PriceTag()
            //    {
            //        ArticaleId = item.ArticleId,
            //        BranchId = UserLoggedIn.User.BranchId,
            //        UnitTypeId = item.UnitId,
            //        Unit3TypeId = 1,
            //        Unit2TypeId = 1,
            //        BuyPrimary = item.Price,
            //        SellPrimary = item.Price + (item.Price * profitOnBuy ),
            //        CountItem = item.Quantity,
            //        CreationBy = UserLoggedIn.User.Id,
            //        CreationDate = DateTime.Now,
            //        ExpiryDate = item.ExpiryDate,
            //        YearId = year
            //    };
            //    context.PriceTags.Add(data);
            //    context.SaveChanges();
            //    item.PriceTagId = data.Id;
            //}
        }
    }
}
