using DataLayer.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Services
{
    public class UnitArticleService
    {
        public static void DefindUnit(int artId, int unitId, bool isPrimary, int quantityOfPrimary)
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            var result = context.ArticleUnits.Where(x => x.ArticleId == artId && x.IsPrimary == isPrimary && x.UnitTypeId == unitId && x.QuantityForPrimary == quantityOfPrimary).FirstOrDefault();
            if (result == null)
            {
                context.ArticleUnits.Add(new ArticleUnits() { ArticleId = artId, IsPrimary = isPrimary, UnitTypeId = unitId, QuantityForPrimary = quantityOfPrimary });
            }
            context.SaveChanges();
        }
        public static List<UnitType> GetArticleUnits(int articleId)
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();

            return context.ArticleUnits.Where(x => x.ArticleId == articleId).Select(x => new UnitType { Id = x.UnitTypeId, Name = x.UnitTypeIdDescr }).ToList();
        }
    }
}
