using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Services
{
    public class UnitTypeService
    {
        public static double GetLastBuyPrice(int articleId, int unitTypeId)
        {
            try
            {
                PriceTagMaster priceTag = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == articleId).Include(e => e.PriceTagDetails).OrderByDescending(x => x.CreationDate).First();
                if (priceTag == null)
                    return 0;
                else
                    return priceTag.PriceTagDetails.FirstOrDefault(x => x.UnitId == unitTypeId).BuyPrice;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static double GetLastSellPrice(int articleId, int unitTypeId)
        {
            try
            {
                PriceTagMaster priceTag = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == articleId).Include(e => e.PriceTagDetails).OrderByDescending(x => x.CreationDate).First();
                if (priceTag == null)
                    return 0;
                else
                    return priceTag.PriceTagDetails.FirstOrDefault(x => x.UnitId == unitTypeId).SellPrice;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static PriceTagMaster GetLastPriceTagForArticle(int articleId)
        {
            try
            {
                PriceTagMaster priceTag = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == articleId).OrderByDescending(x => x.CreationDate).FirstOrDefault();
                return priceTag;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<ArticleUnits> GetAllUnitForArticle(int articleId)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            return context.ArticleUnits.Where(x => x.ArticleId == articleId).ToList();
        }
    }
}
