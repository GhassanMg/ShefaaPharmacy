using DataLayer.Tables;
using DataLayer.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Services
{
    public class ArticleService
    {
        public static int ItemLeftInStore(int articleId)
        {
            int result = 0;
            int sellCount = 0, buyCount = 0;
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<BillDetail> articaleExists = context.BillDetails.Where(x => x.ArticaleId == articleId).ToList();


            if (articaleExists != null)
            {
                articaleExists.Where(x => x.InvoiceKind == Enums.InvoiceKind.Sell).ToList()?.ForEach(x => sellCount += x.Quantity);
                articaleExists.Where(x => x.InvoiceKind == Enums.InvoiceKind.Buy).ToList()?.ForEach(x => buyCount += x.Quantity);
                result = buyCount - sellCount;
            }

            return result;
        }
        public static void ListItemLeftInStore(List<Article> articles)
        {
            foreach (var item in articles)
            {
                item.CountLeft = ItemLeftInStore(item.Id).ToString();
            }
        }
        public static int AllLeftQuantityForNotification(int articaleId)
        {

            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<Article> watedArt = new List<Article>();
            watedArt.AddRange(context.Articles);
            foreach (var item in watedArt)
            {
                if (item.Id == articaleId || item.Id == 1)
                {
                    return Convert.ToInt32(item.CountLeft);
                }
            }
            return 0;
        }
        public static void BindLastTimeArticlesToToDB()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<Article> resultReport = context.Articles.Where(x => !x.ItsGeneral).ToList();
            List<LastTimeArticles> allarticles = new List<LastTimeArticles>();
            foreach (var item in resultReport)
            {
                var lastPriceTage = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
                .Where(x => x.ArticleId == item.Id)
                .Include(x => x.PriceTagDetails)
                .OrderByDescending(x => x.CreationDate)
                .LastOrDefault();

                double Fullquantity = InventoryService.GetAllArticleAmountRemaningInAllPricesDouble(item.Id, context.ArticleUnits.FirstOrDefault(x => x.ArticleId == item.Id && x.IsPrimary).UnitTypeId);

                if (Fullquantity == 0) continue;

                LastTimeArticles mynew = new LastTimeArticles
                {
                    ArticleId = item.Id,
                    QuantityLeft = Math.Round(Fullquantity, 2),
                    UnitId = context.ArticleUnits.FirstOrDefault(x => x.IsPrimary && x.ArticleId == item.Id).UnitTypeId,
                    TotalPrice = lastPriceTage.PriceTagDetails.FirstOrDefault().BuyPrice * Math.Round(Fullquantity, 2)
                };
                allarticles.Add(mynew);
            }
            using (var db = context)
            {
                if (!db.LastTimeArticles.Any())
                {
                    context.LastTimeArticles.AddRange(allarticles);
                    context.SaveChanges();
                }
                else
                {
                    db.Database.ExecuteSqlCommand("Truncate table LastTimeArticles");
                    context.LastTimeArticles.AddRange(allarticles);
                    context.SaveChanges();
                }
            }
        }

        public static int LeftFromBaseUnit(int articleId)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            int baseUnitId = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == articleId && x.IsPrimary).UnitTypeId;
            int quantity = 0;
            List<PriceTagMaster> priceTagDetails = context.PriceTagMasters.Where(x => x.ArticleId == articleId && ((x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem)) > 0).ToList();
            foreach (var item in priceTagDetails)
            {
                if (item.UnitId == baseUnitId)
                {
                    quantity += (item.CountAllItem + item.CountGiftItem) - (item.CountSoldItem);
                }
                else
                {
                    int quantityForPrimary = context.ArticleUnits.FirstOrDefault(x => x.UnitTypeId == item.UnitId).QuantityForPrimary;
                    quantity += ((item.CountAllItem * (quantityForPrimary)) + (item.CountGiftItem * (quantityForPrimary))) - ((item.CountSoldItem * (quantityForPrimary)));
                }
            }
            return quantity;
        }
        public static PriceTagDetail ConvertToPrimaryUnit(int articleId, double sell, double buy, int unitId, int quantity)
        {
            ArticleUnits primaryUnit = ShefaaPharmacyDbContext
                .GetCurrentContext()
                .ArticleUnits
                .FirstOrDefault(x => x.IsPrimary && x.ArticleId == articleId);
            try
            {
                if (unitId == primaryUnit.UnitTypeId)
                {

                    PriceTagDetail priceTagDetail = new PriceTagDetail();
                    priceTagDetail.UnitId = primaryUnit.UnitTypeId;
                    priceTagDetail.SellPrice = sell;
                    priceTagDetail.BuyPrice = buy;
                    return priceTagDetail;
                }
                else
                {
                    ArticleUnits sourceUnit = ShefaaPharmacyDbContext
                    .GetCurrentContext()
                    .ArticleUnits
                    .FirstOrDefault(x => x.UnitTypeId == unitId && x.ArticleId == articleId);
                    PriceTagDetail priceTagDetail = new PriceTagDetail();
                    priceTagDetail.UnitId = primaryUnit.UnitTypeId;
                    priceTagDetail.SellPrice = sell * sourceUnit.QuantityForPrimary;
                    priceTagDetail.BuyPrice = buy * sourceUnit.QuantityForPrimary;
                    return priceTagDetail;
                }
            }
            catch
            {
                ArticleUnits sourceUnit = ShefaaPharmacyDbContext
                .GetCurrentContext()
                .ArticleUnits
                .FirstOrDefault(x => x.UnitTypeId == unitId && x.ArticleId == articleId);
                PriceTagDetail priceTagDetail = new PriceTagDetail();

                priceTagDetail.UnitId = primaryUnit.UnitTypeId;
                priceTagDetail.SellPrice = sell * sourceUnit.QuantityForPrimary;
                priceTagDetail.BuyPrice = buy * sourceUnit.QuantityForPrimary;

                return priceTagDetail;
            }
        }
        public static List<PriceTagDetail> MakeNewPriceTagDetailForArticle(BillDetail ForSellInMinus)
        {
            List<PriceTagDetail> priceTagDetails = new List<PriceTagDetail>();
            List<ArticleUnits> articleUnits = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == ForSellInMinus.ArticaleId).ToList();

            PriceTagDetail priceTagDetailPrimary = ConvertToPrimaryUnit(ForSellInMinus.ArticaleId, ForSellInMinus.Price, 0, ForSellInMinus.UnitTypeId, ForSellInMinus.Quantity);
            priceTagDetails.Add(priceTagDetailPrimary);
            foreach (var item in articleUnits.Where(x => !x.IsPrimary))
            {
                PriceTagDetail priceTagDetail = new PriceTagDetail
                {
                    UnitId = item.UnitTypeId,
                    BuyPrice = priceTagDetailPrimary.BuyPrice / item.QuantityForPrimary,
                    SellPrice = priceTagDetailPrimary.SellPrice / item.QuantityForPrimary
                };
                priceTagDetails.Add(priceTagDetail);
            }
            return priceTagDetails;
        }
        public static List<PriceTagDetail> MakeNewPriceTagDetailForArticle(PurchesBillViewModel purchesBillViewModel)
        {
            List<PriceTagDetail> priceTagDetails = new List<PriceTagDetail>();
            List<ArticleUnits> articleUnits = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == purchesBillViewModel.ArticleId).ToList();

            PriceTagDetail priceTagDetailPrimary = ConvertToPrimaryUnit(purchesBillViewModel.ArticleId, purchesBillViewModel.SellPrice, purchesBillViewModel.PurchasePrice, purchesBillViewModel.UnitId, purchesBillViewModel.Quantity);
            priceTagDetails.Add(priceTagDetailPrimary);
            foreach (var item in articleUnits.Where(x => !x.IsPrimary))
            {
                PriceTagDetail priceTagDetail = new PriceTagDetail
                {
                    UnitId = item.UnitTypeId,
                    BuyPrice = priceTagDetailPrimary.BuyPrice / item.QuantityForPrimary,
                    SellPrice = priceTagDetailPrimary.SellPrice / item.QuantityForPrimary
                };
                priceTagDetails.Add(priceTagDetail);
            }
            return priceTagDetails;
        }
        public static void MakeNewPriceTagDetailForNewUnit(int articleId, int unitId, int masterId)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            int QuantityForPrimary = context.ArticleUnits.Where(x => x.ArticleId == articleId && x.UnitTypeId == unitId).FirstOrDefault().QuantityForPrimary;
            var pricemaster = context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == masterId);
            PriceTagDetail priceTagDetail = new PriceTagDetail
            {
                UnitId = unitId,
                BuyPrice = pricemaster.BuyPrice / QuantityForPrimary,
                SellPrice = pricemaster.SellPrice / QuantityForPrimary
            };
            var currentmaster = context.PriceTagMasters.FirstOrDefault(x => x.Id == masterId);
            currentmaster.PriceTagDetails.Add(priceTagDetail);
            context.PriceTagMasters.Update(currentmaster);
            context.SaveChanges();
        }
        public static List<PriceTagDetail> MakeNewPriceTagDetailForArticle(int articleId, int unitId, double purchasePrice, double sellPrice, int quantity)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<PriceTagDetail> priceTagDetails = new List<PriceTagDetail>();
            List<ArticleUnits> articleUnits = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == articleId).ToList();

            PriceTagDetail priceTagDetailPrimary = ConvertToPrimaryUnit(articleId, sellPrice, purchasePrice, unitId, quantity);
            priceTagDetails.Add(priceTagDetailPrimary);
            foreach (var item in articleUnits.Where(x => !x.IsPrimary))
            {
                PriceTagDetail priceTagDetail = new PriceTagDetail
                {
                    UnitId = item.UnitTypeId,
                    BuyPrice = priceTagDetailPrimary.BuyPrice / item.QuantityForPrimary,
                    SellPrice = priceTagDetailPrimary.SellPrice / item.QuantityForPrimary
                };
                priceTagDetails.Add(priceTagDetail);
                context.SaveChanges();
            }
            return priceTagDetails;
        }
        public static void MakeNewPriceTagForNewUnit(int articleId, int unitId)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<ArticleUnits> articleUnits = ShefaaPharmacyDbContext.GetCurrentContext()
                .ArticleUnits
                .Where(x => x.ArticleId == articleId)
                .ToList();
            int primaryUnit = articleUnits.FirstOrDefault(x => x.IsPrimary).UnitTypeId;
            int quantityForUnit = articleUnits.FirstOrDefault(x => x.UnitTypeId == unitId).QuantityForPrimary;
            if (articleUnits.Count > 0)
            {
                PriceTagMaster priceTagMaster = context.PriceTagMasters.Where(x => x.ArticleId == articleId && x.UnitId == primaryUnit).ToList().FirstOrDefault();
                PriceTagDetail newpriceTagDetail = new PriceTagDetail();
                if (priceTagMaster != null)
                {
                    priceTagMaster.PriceTagDetails = context.PriceTagDetails.Where(x => x.PriceTagId == priceTagMaster.Id).ToList();
                    PriceTagDetail basedetail = priceTagMaster.PriceTagDetails.FirstOrDefault(x => x.UnitId == primaryUnit);
                    newpriceTagDetail = new PriceTagDetail();

                    newpriceTagDetail.UnitId = unitId;
                    if (unitId > primaryUnit)
                    {
                        newpriceTagDetail.BuyPrice = basedetail.BuyPrice / quantityForUnit;
                        newpriceTagDetail.SellPrice = basedetail.SellPrice / quantityForUnit;
                    }
                    else
                    {
                        return;
                    }
                    priceTagMaster.PriceTagDetails.Add(newpriceTagDetail);
                    context.PriceTagMasters.Update(priceTagMaster);
                    context.SaveChanges();
                }
            }
        }
        public static List<PriceTagDetail> MakeNewPriceTagDetailForArticle(int articleId, int unitId, double purchasePrice)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<PriceTagDetail> priceTagDetails = new List<PriceTagDetail>();
            List<ArticleUnits> articleUnits = ShefaaPharmacyDbContext.GetCurrentContext()
                .ArticleUnits
                .Where(x => x.ArticleId == articleId)
                .ToList();
            double sellPrice = 0;
            int quantityForUnit = articleUnits.FirstOrDefault(x => x.UnitTypeId == unitId).QuantityForPrimary;
            if (sellPrice == 0)
            {
                //sellPrice = 10 / 100;
            }
            int primaryUnit = articleUnits.FirstOrDefault(x => x.IsPrimary).UnitTypeId;
            foreach (var item in articleUnits)
            {
                PriceTagDetail priceTagDetail = new PriceTagDetail();

                if (item.UnitTypeId == unitId)
                {
                    priceTagDetail.UnitId = unitId;
                    priceTagDetail.BuyPrice = purchasePrice;
                    var masterId = context.PriceTagMasters.Where(x => x.ArticleId == item.ArticleId).FirstOrDefault().Id;
                    priceTagDetail.SellPrice = context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == masterId).SellPrice;
                }
                else
                {
                    if (item.UnitTypeId == primaryUnit)
                    {
                        priceTagDetail.UnitId = item.UnitTypeId;
                        priceTagDetail.BuyPrice = purchasePrice * quantityForUnit;
                        priceTagDetail.SellPrice = priceTagDetail.BuyPrice + (priceTagDetail.BuyPrice * sellPrice);
                    }
                    else
                    {
                        if (quantityForUnit == 0)
                        {
                            priceTagDetail.UnitId = item.UnitTypeId;
                            priceTagDetail.BuyPrice = purchasePrice / item.QuantityForPrimary;
                            var masterId = context.PriceTagMasters.Where(x => x.ArticleId == item.ArticleId).FirstOrDefault().Id;
                            priceTagDetail.SellPrice = context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == masterId).SellPrice / item.QuantityForPrimary;
                        }
                        else
                        {
                            if (quantityForUnit > item.QuantityForPrimary)
                            {
                                var res = quantityForUnit / item.QuantityForPrimary;
                                priceTagDetail.UnitId = item.UnitTypeId;
                                priceTagDetail.BuyPrice = purchasePrice * res;
                                priceTagDetail.SellPrice = priceTagDetail.BuyPrice + (priceTagDetail.BuyPrice * sellPrice);
                            }
                            else
                            {
                                var res = item.QuantityForPrimary / quantityForUnit;
                                priceTagDetail.UnitId = item.UnitTypeId;
                                priceTagDetail.BuyPrice = purchasePrice / res;
                                priceTagDetail.SellPrice = priceTagDetail.BuyPrice + (priceTagDetail.BuyPrice * sellPrice);
                            }
                        }
                    }
                }
                priceTagDetails.Add(priceTagDetail);
            }
            return priceTagDetails;
        }
    }
}
