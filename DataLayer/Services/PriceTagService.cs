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
        }
    }
}
