using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Services
{
    public class InventoryService
    {
        public static void UpdateInventory(List<BillDetail> billDetail, int branchId, int storeId, InvoiceKind invoiceKind)
        {
            foreach (var item in billDetail)
            {
                UpdateInventory(item.ArticaleId, branchId, storeId, item.UnitTypeId, item.PriceTagId, item.Quantity, invoiceKind, DateTime.Now, item.Price);
            }
        }
        public static void UpdateInventoryForExpiryArticles(List<PriceTagMaster> PriceDetail, int quantity, InvoiceKind invoiceKind)
        {
            foreach (var item in PriceDetail)
            {
                UpdateInventoryExpiry(item.ArticleId, item.UnitId, item.Id, quantity, invoiceKind, DateTime.Now, item.PriceTagDetails.FirstOrDefault().BuyPrice);
            }
        }
        public static void UpdateInventoryInMinus(List<BillDetail> billDetail, int branchId, int storeId, InvoiceKind invoiceKind)
        {
            foreach (var item in billDetail)
            {
                UpdateInventoryForMinus(item.ArticaleId, branchId, storeId, item.UnitTypeId, item.PriceTagId, item.Quantity, invoiceKind, DateTime.Now, item.Price);
            }
        }
        public static void UpdateInventory(List<BalanceFirstDurationViewModel> balanceFirstDurationViewModels, int branchId, int storeId, InvoiceKind invoiceKind)
        {
            foreach (var item in balanceFirstDurationViewModels)
            {
                UpdateInventory(item.ArticleId, branchId, storeId, item.UnitId, item.PriceTagId, item.Quantity, invoiceKind, item.ExpiryDate, item.Price);
            }
        }
        public static void UpdateInventoryMobile(ShefaaPharmacyDbContext context, User user, List<BillDetail> billDetail, int branchId, int storeId, InvoiceKind invoiceKind)
        {
            foreach (var item in billDetail)
            {
                UpdateInventoryMobile(context, user, item.ArticaleId, branchId, storeId, item.UnitTypeId, item.PriceTagId, item.Quantity, invoiceKind, DateTime.Now, item.Price);
            }
        }
        public static void UpdateInventoryMobile(ShefaaPharmacyDbContext context, User user, int artId, int branchId, int storeId, int unitId, int priceTagId, int quantity, InvoiceKind invoiceKind, DateTime expiryDate, double purchasePrice)
        {
            var priceTag = context.PriceTagMasters.FirstOrDefault(x => x.Id == priceTagId);
            if (invoiceKind == InvoiceKind.ExpiryArticles)
            {
                var quantitySmallest = ConvertQuantityToUnitMobile(context, artId, unitId, priceTag.UnitId, quantity);
                if (quantitySmallest > (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem)
                {
                    var quantity1 = (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem;
                    var res = quantitySmallest - quantity1;

                    priceTag.CountSoldItem += quantity1;
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();

                    var nextPriceTag = context.PriceTagMasters.Where(x => x.ArticleId == artId && ((x.CountGiftItem + x.CountAllItem) > x.CountSoldItem)).OrderBy(x => x.ExpiryDate).ToList();
                    foreach (var item in nextPriceTag)
                    {
                        if (res != 0)
                        {
                            if (res > (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem)
                            {
                                res -= (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                item.CountSoldItem += (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                            }
                            else
                            {
                                item.CountSoldItem += res;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                                break;
                            }

                        }
                    }
                }
                else
                {
                    priceTag.CountSoldItem += ConvertQuantityToUnitMobile(context, artId, unitId, priceTag.UnitId, quantity);
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();
                }
            }
            else if (invoiceKind == InvoiceKind.GoodFirstTime)
            {
                PriceTagMaster price = new PriceTagMaster()
                {
                    ArticleId = artId,
                    UnitId = GetSmallestArticleUnit(artId),
                    CountGiftItem = 0,
                    CountSoldItem = 0,
                    CountAllItem = ConvertArticleUnitToSmallestUnit(artId, unitId, quantity),
                    BranchId = UserLoggedIn.User.BranchId,
                    ExpiryDate = expiryDate,
                    PriceTagDetails = ArticleService.MakeNewPriceTagDetailForArticle(artId, unitId, purchasePrice),
                };
                context.PriceTagMasters.Add(price);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.Sell)
            {
                var quantitySmallest = ConvertQuantityToUnitMobile(context, artId, unitId, priceTag.UnitId, quantity);
                if (quantitySmallest > (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem)
                {
                    var quantity1 = (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem;
                    var res = quantitySmallest - quantity1;

                    priceTag.CountSoldItem += quantity1;
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();

                    var nextPriceTag = context.PriceTagMasters.Where(x => x.ArticleId == artId && ((x.CountGiftItem + x.CountAllItem) > x.CountSoldItem)).OrderBy(x => x.ExpiryDate).ToList();
                    foreach (var item in nextPriceTag)
                    {
                        if (res != 0)
                        {
                            if (res > (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem)
                            {
                                res -= (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                item.CountSoldItem += (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                            }
                            else
                            {
                                item.CountSoldItem += res;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                                break;
                            }

                        }
                    }

                }
                else
                {
                    priceTag.CountSoldItem += ConvertQuantityToUnitMobile(context, artId, unitId, priceTag.UnitId, quantity);
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();
                }
            }
            else if (invoiceKind == InvoiceKind.DeleteSell)
            {
                priceTag.CountSoldItem -= ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.ReturnSell)
            {
                priceTag.CountSoldItem -= ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.ReturnBuy)
            {
                var qu = ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                if (qu <= priceTag.CountAllItem + priceTag.CountGiftItem)
                {
                    if (qu <= priceTag.CountAllItem)
                    {
                        priceTag.CountAllItem -= qu;
                        context.PriceTagMasters.Update(priceTag);
                        context.SaveChanges();
                    }
                    else
                    {
                        var quGift = qu - priceTag.CountAllItem;
                        priceTag.CountAllItem -= qu;
                        priceTag.CountGiftItem -= quGift;
                        context.PriceTagMasters.Update(priceTag);
                        context.SaveChanges();
                    }
                }
            }
            else if (invoiceKind == InvoiceKind.DeleteBuy)
            {
                priceTag.CountAllItem -= ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.DeleteReturnSell)
            {
                priceTag.CountSoldItem += ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.DeleteReturnBuy)
            {
                priceTag.CountAllItem += ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
        }
        public static int ConvertQuantityToUnitMobile(ShefaaPharmacyDbContext context, int artId, int unitIdSource, int unitIdDestination, int quantity)
        {
            if (unitIdSource == unitIdDestination)
            {
                return quantity;
            }
            else
            {
                var quantityOfPrimary = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitIdSource).QuantityForPrimary;
                var quantityOfPrimaryDestination = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitIdDestination).QuantityForPrimary;
                if (unitIdDestination == DescriptionFK.GetPrimaryUnitMobile(context: context, articleId: artId))
                {
                    return quantity / quantityOfPrimary;
                }
                else
                {
                    if (unitIdSource == DescriptionFK.GetPrimaryUnitMobile(context: context, articleId: artId))
                    {
                        return quantity * quantityOfPrimaryDestination;
                    }
                    else
                    {
                        if (quantityOfPrimary < quantityOfPrimaryDestination)
                        {
                            return quantity * (quantityOfPrimaryDestination / quantityOfPrimary);
                        }
                        else
                        {
                            return quantity * (quantityOfPrimary / quantityOfPrimaryDestination);
                        }
                    }
                }
            }
        }
        public static string GetQuantityOfArticleAllPriceTagMobile(ShefaaPharmacyDbContext context, int artId, int unitId = 0)
        {

            var priceTags = context.PriceTagMasters
                .Where(x => x.ArticleId == artId && (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem) > 0)
                .Include(x => x.PriceTagDetails).ToList();

            ArticleUnits primaryUnit = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.IsPrimary);

            if (unitId == 0 || unitId == 1)
                unitId = primaryUnit.UnitTypeId;

            ArticleUnits unitDestionation = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitId);
            ArticleUnits smallestUnit = context.ArticleUnits.Where(x => x.ArticleId == artId).OrderByDescending(x => x.QuantityForPrimary).FirstOrDefault();
            int smallUnitQuantity = 0;
            if (primaryUnit == null || smallestUnit == null)
            {
                return "";
            }
            if (priceTags.Count <= 0)
            {
                priceTags = context.PriceTagMasters
                .Where(x => x.ArticleId == artId && (x.CountAllItem + x.CountGiftItem) < (x.CountSoldItem))
                .Include(x => x.PriceTagDetails).ToList();
                if (priceTags.Count > 0)
                {
                    foreach (var item in priceTags)
                    {
                        if ((item.CountSoldItem) > (item.CountAllItem + item.CountGiftItem))
                        {
                            smallUnitQuantity += (item.CountSoldItem) - (item.CountAllItem + item.CountGiftItem);
                        }
                    }
                    if (smallestUnit.UnitTypeId == unitDestionation.UnitTypeId)
                    {
                        return "-" + smallUnitQuantity.ToString();
                    }
                    else
                    {
                        if (unitDestionation.UnitTypeId == primaryUnit.UnitTypeId)
                        {
                            return "-" + Convert.ToDouble(
                            (double)smallUnitQuantity /
                            (double)smallestUnit.QuantityForPrimary)
                            .ToString();
                        }
                        else
                        {
                            return "-" + (Convert.ToDouble((double)smallestUnit.QuantityForPrimary / (double)unitDestionation.QuantityForPrimary) * (smallUnitQuantity)).ToString();
                        }
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                priceTags.ForEach(x => smallUnitQuantity += (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem));

                if (smallestUnit.UnitTypeId == unitDestionation.UnitTypeId)
                {
                    return smallUnitQuantity.ToString();
                }
                else
                {
                    if (unitDestionation.UnitTypeId == primaryUnit.UnitTypeId)
                    {
                        return Convert.ToDouble(
                        (double)smallUnitQuantity /
                        (double)smallestUnit.QuantityForPrimary)
                        .ToString();
                    }
                    else
                    {
                        return (Convert.ToDouble((double)smallestUnit.QuantityForPrimary / (double)unitDestionation.QuantityForPrimary) * (smallUnitQuantity)).ToString();
                    }
                }
            }
        }
        //                              =================================================================
        public static void IncresedOrDecresedQantity(int artId, int branchId, int storeId, int unitId, int priceTagId, int quantity, InvoiceKind invoiceKind)
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            var inv = context.Inventories.Where(x => x.ArticleId == artId && x.BranchId == branchId && x.StoreId == storeId && x.UnitTypeId == unitId && x.PriceTagId == priceTagId).FirstOrDefault();
            if (inv == null)
            {
                inv = context.Inventories.Add(new Inventory() { ArticleId = artId, BranchId = branchId, StoreId = storeId, UnitTypeId = unitId, PriceTagId = priceTagId }).Entity;
                context.SaveChanges();
            }
            switch (invoiceKind)
            {
                case InvoiceKind.Sell:
                    inv.Quantity -= quantity;
                    break;
                case InvoiceKind.Buy:
                    inv.Quantity += quantity;
                    break;
                case InvoiceKind.ReturnBuy:
                    inv.Quantity -= quantity;
                    break;
                case InvoiceKind.ReturnSell:
                    inv.Quantity += quantity;
                    break;
                default:
                    inv.Quantity -= quantity;
                    break;
            }
            context.SaveChanges();
            context.Entry(inv).State = EntityState.Detached;
        }
        public static void UpdateInventoryExpiry(int artId, int unitId, int priceTagId, int quantity, InvoiceKind invoiceKind, DateTime expiryDate, double purchasePrice)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var priceTag = context.PriceTagMasters.FirstOrDefault(x => x.Id == priceTagId);
            if (invoiceKind == InvoiceKind.ExpiryArticles)
            {
                var quantitySmallest = ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                if (quantitySmallest > (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem)
                {
                    var quantity1 = (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem;
                    var res = quantitySmallest - quantity1;

                    priceTag.CountSoldItem += quantity1;
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();

                    var nextPriceTag = context.PriceTagMasters.Where(x => x.ArticleId == artId && ((x.CountGiftItem + x.CountAllItem) > x.CountSoldItem)).OrderBy(x => x.ExpiryDate).ToList();
                    foreach (var item in nextPriceTag)
                    {
                        if (res != 0)
                        {
                            if (res > (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem)
                            {
                                res -= (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                item.CountSoldItem += (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                            }
                            else
                            {
                                item.CountSoldItem += res;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    priceTag.CountSoldItem += ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();
                }
            }
        }
        public static void UpdateInventory(int artId, int branchId, int storeId, int unitId, int priceTagId, int quantity, InvoiceKind invoiceKind, DateTime expiryDate, double purchasePrice)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var priceTag = context.PriceTagMasters.FirstOrDefault(x => x.Id == priceTagId);
            if (invoiceKind == InvoiceKind.ExpiryArticles)
            {
                var quantitySmallest = ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                if (quantitySmallest > (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem)
                {
                    var quantity1 = (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem;
                    var res = quantitySmallest - quantity1;

                    priceTag.CountSoldItem += quantity1;
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();

                    var nextPriceTag = context.PriceTagMasters.Where(x => x.ArticleId == artId && ((x.CountGiftItem + x.CountAllItem) > x.CountSoldItem)).OrderBy(x => x.ExpiryDate).ToList();
                    foreach (var item in nextPriceTag)
                    {
                        if (res != 0)
                        {
                            if (res > (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem)
                            {
                                res -= (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                item.CountSoldItem += (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                            }
                            else
                            {
                                item.CountSoldItem += res;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                                break;
                            }

                        }
                    }

                }
                else
                {
                    priceTag.CountSoldItem += ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();
                }
            }
            else if (invoiceKind == InvoiceKind.GoodFirstTime)
            {
                PriceTagMaster price = new PriceTagMaster()
                {
                    ArticleId = artId,
                    UnitId = GetSmallestArticleUnit(artId),
                    CountGiftItem = 0,
                    CountSoldItem = 0,
                    CountAllItem = ConvertArticleUnitToSmallestUnit(artId, unitId, quantity),
                    BranchId = UserLoggedIn.User.BranchId,
                    ExpiryDate = expiryDate,
                    PriceTagDetails = ArticleService.MakeNewPriceTagDetailForArticle(artId, unitId, purchasePrice),
                };
                context.PriceTagMasters.Add(price);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.Sell)
            {
                var quantitySmallest = ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                if (quantitySmallest > (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem)
                {
                    var quantity1 = (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem;
                    var res = quantitySmallest - quantity1;

                    priceTag.CountSoldItem += quantity1;
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();

                    var nextPriceTag = context.PriceTagMasters.Where(x => x.ArticleId == artId && ((x.CountGiftItem + x.CountAllItem) > x.CountSoldItem)).OrderBy(x => x.ExpiryDate).ToList();
                    foreach (var item in nextPriceTag)
                    {
                        if (res != 0)
                        {
                            if (res > (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem)
                            {
                                res -= (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                item.CountSoldItem += (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                            }
                            else
                            {
                                item.CountSoldItem += res;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                                break;
                            }

                        }
                    }

                }
                else
                {
                    PriceTagMaster lastpricetagexpiry = context.PriceTagMasters.Where(x => x.ArticleId == artId && ((x.CountGiftItem + x.CountAllItem) > x.CountSoldItem)).OrderBy(x => x.ExpiryDate).ToList().FirstOrDefault();
                    lastpricetagexpiry.CountSoldItem += ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();
                }
            }
            else if (invoiceKind == InvoiceKind.DeleteSell)
            {
                priceTag.CountSoldItem -= ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.ReturnSell)
            {
                priceTag.CountSoldItem -= ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.ReturnBuy)
            {
                priceTag.CountAllItem = 0;
                priceTag.CountGiftItem = 0;
                priceTag.CountSoldItem = 0;
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.EditBuy)
            {
                var qu = ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                try
                {
                    priceTag.CountAllItem = qu;
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();
                }
                catch
                {
                    return;
                }
            }
            else if (invoiceKind == InvoiceKind.DeleteBuy)
            {
                priceTag.CountAllItem -= ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.DeleteReturnSell)
            {
                priceTag.CountSoldItem += ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
            else if (invoiceKind == InvoiceKind.DeleteReturnBuy)
            {
                priceTag.CountAllItem += ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                context.PriceTagMasters.Update(priceTag);
                context.SaveChanges();
            }
        }
        public static void UpdateInventoryForMinus(int artId, int branchId, int storeId, int unitId, int priceTagId, int quantity, InvoiceKind invoiceKind, DateTime expiryDate, double purchasePrice)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var priceTag = context.PriceTagMasters.FirstOrDefault(x => x.Id == priceTagId);

            var RemainingAmount = GetAllArticleAmountRemaningInAllPrices(artId, unitId);
            var smallestunit = InventoryService.GetSmallestArticleUnit(artId);
            var AmountFromSmallestUnit = 1;
            if (!context.ArticleUnits.FirstOrDefault(x => x.UnitTypeId == smallestunit).IsPrimary)
            {
                AmountFromSmallestUnit = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == smallestunit).QuantityForPrimary;
            }
            if (RemainingAmount <= 0)
            {
                PriceTagMaster NewPriceTagMaster = new PriceTagMaster()
                {
                    ArticleId = artId,
                    UnitId = InventoryService.GetSmallestArticleUnit(artId),
                    CountGiftItem = 0,
                    CountSoldItem = (quantity * AmountFromSmallestUnit),
                    CountAllItem = 0,
                    BranchId = UserLoggedIn.User.BranchId,
                    ExpiryDate = DateTime.Now.AddYears(1),
                    PriceTagDetails = ArticleService
                                            .MakeNewPriceTagDetailForArticle(
                                                    artId,
                                                    InventoryService.GetBaseArticleUnit(artId),
                                                    Convert.ToInt32(context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == priceTagId).BuyPrice),
                                                    Convert.ToInt32(context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == priceTagId).SellPrice), 0),
                };
                context.PriceTagMasters.Add(NewPriceTagMaster);
                context.SaveChanges();
            }
            else
            {
                var quantitySmallest = ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                if (quantitySmallest > (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem)
                {
                    var quantity1 = (priceTag.CountGiftItem + priceTag.CountAllItem) - priceTag.CountSoldItem;
                    var res = quantitySmallest - quantity1;

                    priceTag.CountSoldItem += quantity1;
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();

                    var nextPriceTag = context.PriceTagMasters.Where(x => x.ArticleId == artId && ((x.CountGiftItem + x.CountAllItem) > x.CountSoldItem)).OrderBy(x => x.ExpiryDate).ToList();
                    foreach (var item in nextPriceTag)
                    {
                        if (res != 0)
                        {
                            if (res > (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem)
                            {
                                res -= (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                item.CountSoldItem += (item.CountGiftItem + item.CountAllItem) - item.CountSoldItem;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                                if (res > 0)
                                {
                                    PriceTagMaster NewPriceTagMaster = new PriceTagMaster()
                                    {
                                        ArticleId = artId,
                                        UnitId = InventoryService.GetSmallestArticleUnit(artId),
                                        CountGiftItem = 0,
                                        CountSoldItem = 0,
                                        CountAllItem = res * -1,
                                        BranchId = UserLoggedIn.User.BranchId,
                                        ExpiryDate = DateTime.Now.AddYears(1),
                                        PriceTagDetails = ArticleService
                                            .MakeNewPriceTagDetailForArticle(
                                                    artId,
                                                    InventoryService.GetBaseArticleUnit(artId),
                                                    Convert.ToInt32(context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == priceTagId).BuyPrice),
                                                    Convert.ToInt32(context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == priceTagId).SellPrice), 0),
                                    };
                                    context.PriceTagMasters.Add(NewPriceTagMaster);
                                    context.SaveChanges();
                                }
                            }
                            else
                            {
                                item.CountSoldItem += res;
                                context.PriceTagMasters.Update(item);
                                context.SaveChanges();
                                break;
                            }
                        }
                    }
                    if (nextPriceTag.Count == 0)
                    {
                        if (res > 0)
                        {
                            PriceTagMaster NewPriceTagMaster = new PriceTagMaster()
                            {
                                ArticleId = artId,
                                UnitId = InventoryService.GetSmallestArticleUnit(artId),
                                CountGiftItem = 0,
                                CountSoldItem = 0,
                                CountAllItem = res * -1,
                                BranchId = UserLoggedIn.User.BranchId,
                                ExpiryDate = DateTime.Now.AddYears(1),
                                PriceTagDetails = ArticleService
                                    .MakeNewPriceTagDetailForArticle(
                                            artId,
                                            InventoryService.GetBaseArticleUnit(artId),
                                            Convert.ToInt32(context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == priceTagId).BuyPrice),
                                            Convert.ToInt32(context.PriceTagDetails.FirstOrDefault(x => x.PriceTagId == priceTagId).SellPrice), 0),
                            };
                            context.PriceTagMasters.Add(NewPriceTagMaster);
                            context.SaveChanges();
                        }
                    }
                }
                else
                {
                    priceTag.CountSoldItem += ConvertQuantityToUnit(artId, unitId, priceTag.UnitId, quantity);
                    context.PriceTagMasters.Update(priceTag);
                    context.SaveChanges();
                }
            }
        }
        public static string GetQuantityOfArticleAllPriceTag(int artId, int unitId = 0)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();

            var priceTags = context.PriceTagMasters
                .Where(x => x.ArticleId == artId && (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem) != 0)
                .Include(x => x.PriceTagDetails).ToList();

            ArticleUnits primaryUnit = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.IsPrimary);

            if (unitId == 0 || unitId == 1)
                unitId = primaryUnit.UnitTypeId;

            ArticleUnits unitDestionation = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitId);
            ArticleUnits smallestUnit = context.ArticleUnits.Where(x => x.ArticleId == artId).OrderByDescending(x => x.QuantityForPrimary).FirstOrDefault();
            int smallUnitQuantity = 0;
            if (primaryUnit == null || smallestUnit == null)
            {
                return "";
            }
            if (priceTags.Count <= 0)
            {
                priceTags = context.PriceTagMasters
                .Where(x => x.ArticleId == artId && (x.CountAllItem + x.CountGiftItem) < (x.CountSoldItem))
                .Include(x => x.PriceTagDetails).ToList();
                if (priceTags.Count > 0)
                {
                    foreach (var item in priceTags)
                    {
                        if ((item.CountSoldItem) > (item.CountAllItem + item.CountGiftItem))
                        {
                            smallUnitQuantity += (item.CountSoldItem) - (item.CountAllItem + item.CountGiftItem);
                        }
                    }
                    if (smallestUnit.UnitTypeId == unitDestionation.UnitTypeId)
                    {
                        return "-" + smallUnitQuantity.ToString();
                    }
                    else
                    {
                        if (unitDestionation.UnitTypeId == primaryUnit.UnitTypeId)
                        {
                            return "-" + Convert.ToDouble(
                            (double)smallUnitQuantity /
                            (double)smallestUnit.QuantityForPrimary)
                            .ToString();
                        }
                        else
                        {
                            return "-" + (Convert.ToDouble((double)smallestUnit.QuantityForPrimary / (double)unitDestionation.QuantityForPrimary) * (smallUnitQuantity)).ToString();
                        }
                    }
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                //foreach (var item in priceTags)
                //{
                //    if (item.UnitId == smallestUnit.UnitTypeId)
                //    {
                //        smallUnitQuantity += (item.CountAllItem + item.CountGiftItem) - (item.CountSoldItem);
                //    }
                //    else if (item.UnitId == primaryUnit.UnitTypeId)
                //    {
                //        smallUnitQuantity += ((item.CountAllItem + item.CountGiftItem) - (item.CountSoldItem)) * smallestUnit.QuantityForPrimary;
                //    }
                //    else
                //    {
                //        var quantity = smallestUnit.QuantityForPrimary / unitDestionation.QuantityForPrimary;
                //        smallUnitQuantity += ((item.CountAllItem + item.CountGiftItem) - (item.CountSoldItem)) * quantity;
                //    }
                //}
                priceTags.ForEach(x => smallUnitQuantity += (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem));

                if (smallestUnit.UnitTypeId == unitDestionation.UnitTypeId)
                {
                    return smallUnitQuantity.ToString();
                }
                else
                {
                    if (unitDestionation.UnitTypeId == primaryUnit.UnitTypeId)
                    {
                        return Convert.ToDouble(
                        (double)smallUnitQuantity /
                        (double)smallestUnit.QuantityForPrimary)
                        .ToString();
                    }
                    else
                    {
                        return ((smallUnitQuantity) / (Convert.ToDouble((double)smallestUnit.QuantityForPrimary / (double)unitDestionation.QuantityForPrimary))).ToString();
                    }
                }
            }
        }
        static int fortry = 0;

        public static double GetQuantityOfArticleAllPriceTagInt(int artId, int unitId)
        {
            unitId = 0;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            if (artId >= 2140)
            {
                fortry++;
            }
            var priceTags = context.PriceTagMasters
                .Where(x => x.ArticleId == artId && (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem) > 0)
                .Include(x => x.PriceTagDetails).ToList();

            ArticleUnits primaryUnit = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.IsPrimary);
            if (primaryUnit == null)
            {
                primaryUnit = new ArticleUnits
                {
                    UnitTypeId = context.UnitTypes.FirstOrDefault(x => x.Name.Contains("علبة")).Id,
                    ArticleId = artId,
                    QuantityForPrimary = 0,
                    IsPrimary = true,
                    CreationDate = DateTime.Now,
                    CreationBy = UserLoggedIn.User.Id,
                };
                context.ArticleUnits.AddRange(primaryUnit);
                context.SaveChanges();
            }



            if (unitId == 0 || unitId == 1)
                unitId = primaryUnit.UnitTypeId;

            ArticleUnits unitDestionation = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitId);
            ArticleUnits smallestUnit = context.ArticleUnits.Where(x => x.ArticleId == artId).OrderByDescending(x => x.QuantityForPrimary).FirstOrDefault();
            int smallUnitQuantity = 0;
            if (primaryUnit == null || smallestUnit == null)
            {
                return 0;
            }
            if (priceTags.Count <= 0)
            {
                priceTags = context.PriceTagMasters
                .Where(x => x.ArticleId == artId && (x.CountAllItem + x.CountGiftItem) < (x.CountSoldItem))
                .Include(x => x.PriceTagDetails).ToList();
                if (priceTags.Count > 0)
                {
                    foreach (var item in priceTags)
                    {
                        if ((item.CountSoldItem) > (item.CountAllItem + item.CountGiftItem))
                        {
                            smallUnitQuantity += (item.CountSoldItem) - (item.CountAllItem + item.CountGiftItem);
                        }
                    }
                    if (smallestUnit.UnitTypeId == unitDestionation.UnitTypeId)
                    {
                        return smallUnitQuantity * -1;
                    }
                    else
                    {
                        if (unitDestionation.UnitTypeId == primaryUnit.UnitTypeId)
                        {
                            return Convert.ToDouble(
                            (double)smallUnitQuantity /
                            (double)smallestUnit.QuantityForPrimary) * -1;

                        }
                        else
                        {
                            return (Convert.ToDouble((double)smallestUnit.QuantityForPrimary / (double)unitDestionation.QuantityForPrimary) * (smallUnitQuantity)) * -1;
                        }
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                priceTags.ForEach(x => Convert.ToDouble(smallUnitQuantity += (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem)));

                if (smallestUnit.UnitTypeId == unitDestionation.UnitTypeId)
                {
                    return smallUnitQuantity;
                }
                else
                {
                    if (unitDestionation.UnitTypeId == primaryUnit.UnitTypeId)
                    {
                        return Convert.ToDouble(
                        (double)smallUnitQuantity /
                        (double)smallestUnit.QuantityForPrimary);

                    }
                    else
                    {
                        return ((smallUnitQuantity) / (Convert.ToDouble((double)smallestUnit.QuantityForPrimary / (double)unitDestionation.QuantityForPrimary)));
                    }
                }
            }
        }
        public static int GetSmallestArticleUnit(int artId)
        {
            var articleUnit = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == artId).OrderByDescending(x => x.QuantityForPrimary).ToList();
            if (articleUnit != null && articleUnit.Count > 0)
            {
                return articleUnit.First().UnitTypeId;
            }
            else
            {
                return 3;
            }
        }
        public static int QuantityForPrimaryUnit(int articleId, int UnitId, int quanitiyOfSmallest)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            int BaseUnit = context.ArticleUnits.FirstOrDefault(x => x.IsPrimary && x.ArticleId == articleId).UnitTypeId;
            int quantityOfPrimary = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == articleId && x.UnitTypeId == UnitId).QuantityForPrimary;
            if (BaseUnit > UnitId)
            {
                int result = quanitiyOfSmallest * quantityOfPrimary;
                return result;
            }
            else if (BaseUnit < UnitId)
            {
                int result = quanitiyOfSmallest / quantityOfPrimary;
                return result;
            }
            return quanitiyOfSmallest;
        }
        public static int GetBaseArticleUnit(int artId)
        {
            var articleUnit = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.IsPrimary);
            if (articleUnit != null)
            {
                return articleUnit.UnitTypeId;
            }
            else
            {
                return 2;
            }
        }
        public static int ConvertArticleUnitToSmallestUnit(int artId, int unitId, int quantity)
        {
            var smallestUnitId = GetSmallestArticleUnit(artId);
            var GeneralUnitId = GetBaseArticleUnit(artId);
            if (smallestUnitId == unitId)
            {
                return quantity;
            }
            else if (GeneralUnitId == unitId)
            {
                return ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == smallestUnitId).QuantityForPrimary * quantity;
            }
            else
            {
                var quantitofprimeryforsmallest = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == smallestUnitId).QuantityForPrimary;
                var quantitofprimeryforcurrent = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitId).QuantityForPrimary;
                return quantity * (quantitofprimeryforsmallest / quantitofprimeryforcurrent);
            }
        }
        public static int ConvertArticleUnitToBaseUnit(int artId, int unitId, int quantity)
        {
            var basetUnitId = GetBaseArticleUnit(artId);
            if (basetUnitId == unitId)
            {
                return quantity;
            }
            else
            {
                var quantityForPrimary = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitId).QuantityForPrimary;
                return quantity / quantityForPrimary;
            }
        }
        public static void ConvertAllPriceTagToSmallest(int artId)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var allPriceTagForThisUnit = context.PriceTagMasters.Where(x => x.ArticleId == artId).ToList();
            foreach (var item in allPriceTagForThisUnit)
            {
                item.CountGiftItem = ConvertArticleUnitToSmallestUnit(item.ArticleId, item.UnitId, item.CountGiftItem);
                item.CountAllItem = ConvertArticleUnitToSmallestUnit(item.ArticleId, item.UnitId, item.CountAllItem);
                item.CountSoldItem = ConvertArticleUnitToSmallestUnit(item.ArticleId, item.UnitId, item.CountSoldItem);
                item.UnitId = GetSmallestArticleUnit(artId);
                context.PriceTagMasters.Update(item);
                context.SaveChanges();
            }
        }

        public static List<ArticleRemaningAmount> GetArticleAmountRemaning(int artId)
        {
            List<ArticleRemaningAmount> articleRemaningAmounts = new List<ArticleRemaningAmount>();
            var data = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == artId && (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem) != 0).ToList();
            foreach (var item in data)
            {
                articleRemaningAmounts.Add(new ArticleRemaningAmount()
                {
                    ArticaleIdDescr = item.ArticleIdDescr,
                    UnitIdDescr = DescriptionFK.GetUnitName(DescriptionFK.GetPrimaryUnit(artId)),
                    CountItem = ConvertArticleUnitToBaseUnit(artId, item.UnitId, (item.CountAllItem + item.CountGiftItem)),
                    CountLeft = ConvertArticleUnitToBaseUnit(artId, item.UnitId, (item.CountAllItem + item.CountGiftItem) - (item.CountSoldItem)),
                    CountSoldItem = ConvertArticleUnitToBaseUnit(artId, item.UnitId, item.CountSoldItem),
                    ExpiryDate = item.ExpiryDate,
                    ArticleId = item.ArticleId,
                    UnitId = item.UnitId,
                    PriceTagId = item.Id,
                });
            }
            return articleRemaningAmounts;
        }
        public static double GetAllArticleAmountRemaningInAllPricesDouble(int articleId, int unitId)
        {
            var data = ShefaaPharmacyDbContext.GetCurrentContext()
                .PriceTagMasters
                .Where(x => x.ArticleId == articleId && (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem) != 0)
                .ToList();
            double res = 0;
            if (data.Count == 0)
            {
                data = ShefaaPharmacyDbContext.GetCurrentContext()
                .PriceTagMasters
                .Where(x => x.ArticleId == articleId && (x.CountAllItem + x.CountGiftItem) < (x.CountSoldItem))
                .ToList();
                if (data.Count > 0)
                {
                    data.ForEach(x => res += (x.CountSoldItem) - (x.CountAllItem + x.CountGiftItem));
                    res = res * (-1);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                data.ForEach(x => res += (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem));
            }
            return ConvertQuantityToUnitDouble(articleId, data.FirstOrDefault().UnitId, unitId, res);
        }
        public static int GetAllArticleAmountRemaningInAllPrices(int articleId, int unitId)
        {
            var data = ShefaaPharmacyDbContext.GetCurrentContext()
                .PriceTagMasters
                .Where(x => x.ArticleId == articleId && (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem) != 0)
                .ToList();
            int res = 0;
            if (data.Count == 0)
            {
                data = ShefaaPharmacyDbContext.GetCurrentContext()
                .PriceTagMasters
                .Where(x => x.ArticleId == articleId && (x.CountAllItem + x.CountGiftItem) < (x.CountSoldItem))
                .ToList();
                if (data.Count > 0)
                {
                    data.ForEach(x => res += (x.CountSoldItem) - (x.CountAllItem + x.CountGiftItem));
                    res = res * (-1);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                data.ForEach(x => res += (x.CountAllItem + x.CountGiftItem) - (x.CountSoldItem));
            }
            return ConvertQuantityToUnit(articleId, data.FirstOrDefault().UnitId, unitId, res);
        }
        public static List<ArticleRemaningAmount> GetArticleAllPriceTags(int artId)
        {
            List<ArticleRemaningAmount> articleRemaningAmounts = new List<ArticleRemaningAmount>();
            var data = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == artId).ToList();
            foreach (var item in data)
            {
                articleRemaningAmounts.Add(new ArticleRemaningAmount()
                {
                    ArticaleIdDescr = item.ArticleIdDescr,
                    UnitIdDescr = DescriptionFK.GetUnitName(DescriptionFK.GetPrimaryUnit(artId)),
                    CountItem = ConvertArticleUnitToBaseUnit(artId, item.UnitId, (item.CountAllItem + item.CountGiftItem)),
                    CountLeft = ConvertArticleUnitToBaseUnit(artId, item.UnitId, (item.CountAllItem + item.CountGiftItem) - (item.CountSoldItem)),
                    CountSoldItem = ConvertArticleUnitToBaseUnit(artId, item.UnitId, item.CountSoldItem),
                    ExpiryDate = item.ExpiryDate,
                    ArticleId = item.ArticleId,
                    UnitId = item.UnitId,
                    PriceTagId = item.Id
                });
            }
            return articleRemaningAmounts;
        }
        public static int ConvertQuantityToUnit(int artId, int unitIdSource, int unitIdDestination, int quantity)
        {
            if (unitIdSource == unitIdDestination)
            {
                return quantity;
            }
            else
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var quantityOfPrimary = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitIdSource).QuantityForPrimary;
                var quantityOfPrimaryDestination = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitIdDestination).QuantityForPrimary;
                if (unitIdDestination == DescriptionFK.GetPrimaryUnit(articleId: artId))
                {
                    return quantity / quantityOfPrimary;
                }
                else
                {
                    if (unitIdSource == DescriptionFK.GetPrimaryUnit(articleId: artId))
                    {
                        return quantity * quantityOfPrimaryDestination;
                    }
                    else
                    {
                        if (quantityOfPrimary < quantityOfPrimaryDestination)
                        {
                            return quantity * (quantityOfPrimaryDestination / quantityOfPrimary);
                        }
                        else
                        {
                            return quantity / (quantityOfPrimary / quantityOfPrimaryDestination);
                        }
                    }
                }
            }
        }
        public static double ConvertQuantityToUnitDouble(int artId, int unitIdSource, int unitIdDestination, double quantity)
        {
            if (unitIdSource == unitIdDestination)
            {
                return quantity;
            }
            else
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var quantityOfPrimary = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitIdSource).QuantityForPrimary;
                var quantityOfPrimaryDestination = context.ArticleUnits.FirstOrDefault(x => x.ArticleId == artId && x.UnitTypeId == unitIdDestination).QuantityForPrimary;
                if (unitIdDestination == DescriptionFK.GetPrimaryUnit(articleId: artId))
                {
                    return quantity / quantityOfPrimary;
                }
                else
                {
                    if (unitIdSource == DescriptionFK.GetPrimaryUnit(articleId: artId))
                    {
                        return quantity * quantityOfPrimaryDestination;
                    }
                    else
                    {
                        if (quantityOfPrimary < quantityOfPrimaryDestination)
                        {
                            return quantity * (quantityOfPrimaryDestination / quantityOfPrimary);
                        }
                        else
                        {
                            return quantity / (quantityOfPrimary / quantityOfPrimaryDestination);
                        }
                    }
                }
            }
        }
    }
}
