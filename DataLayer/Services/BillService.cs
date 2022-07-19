using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataLayer.Services
{
    public class BillService
    {
        BillMaster billMaster;
        public BillService()
        {

        }
        public BillService(BillMaster billMaster)
        {
            this.billMaster = billMaster;
        }
        public bool DeleteBill(InvoiceKind invoiceKind)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var master = context.EntryMasters.Where(x => x.RelatedDocument == billMaster.Id).Include("EntryDetails").FirstOrDefault();
            //var pricetag=context.PriceTagMasters.Where(x=>x.==billMaster.ar) //لحذف كمية المواد بعد حذف الفاتورة
            if (master != null)
            {
                context.EntryDetails.RemoveRange(master.EntryDetails);
                context.SaveChanges();
                context.EntryMasters.Remove(master);
                context.SaveChanges();
            }
            foreach (var item in billMaster.BillDetails)
            {
                if (invoiceKind == InvoiceKind.Sell)
                {
                    InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId, item.Quantity, InvoiceKind.DeleteSell, item.CreationDate, item.Price);
                }
                else if (invoiceKind == InvoiceKind.Buy)
                {
                    InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId, item.Quantity, InvoiceKind.DeleteBuy, item.CreationDate, item.Price);
                }
                else if (invoiceKind == InvoiceKind.DeleteSell)
                {
                    InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId, item.Quantity, InvoiceKind.DeleteSell, item.CreationDate, item.Price);
                }
                else if (invoiceKind == InvoiceKind.DeleteReturnBuy)
                {
                    InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId, item.Quantity, InvoiceKind.DeleteReturnBuy, item.CreationDate, item.Price);
                }
                else if (invoiceKind == InvoiceKind.DeleteReturnSell)
                {
                    InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId, item.Quantity, InvoiceKind.DeleteReturnSell, item.CreationDate, item.Price);
                }
            }
            context.BillDetails.RemoveRange(billMaster.BillDetails);
            context.SaveChanges();
            billMaster.BillDetails.Clear();
            context.BillMasters.Remove(billMaster);
            context.SaveChanges();
            return true;
        }
        public bool EditBill(List<PurchesBillViewModel> purchesBillViewModel = null)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var entryMaster = context.EntryMasters.Where(x => x.RelatedDocument == billMaster.Id).Include("EntryDetails").FirstOrDefault();
            if (entryMaster != null)
            {
                //Delete Old Entry
                context.EntryDetails.RemoveRange(entryMaster.EntryDetails);
                context.SaveChanges();
                context.EntryMasters.Remove(entryMaster);
                context.SaveChanges();
            }

            // Update Bill
            var old = context.BillDetails.Where(x => x.BillMasterId == billMaster.Id).AsNoTracking().ToList();
 
            foreach (var item in old)
            {
                if (!billMaster.BillDetails.Any(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId))
                {
                    //موجود بالقديمة غير موجود بالجديدة
                    if (item.InvoiceKind == InvoiceKind.Sell)
                    {
                        InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId, item.Quantity, InvoiceKind.ReturnSell, item.CreationDate, item.Price);
                    }
                    else
                    {
                        InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId, item.Quantity, InvoiceKind.EditBuy, item.CreationDate, item.Price);
                    }

                    context.BillDetails.Remove(item);
                    context.SaveChanges();
                }
                else
                {
                    //موجود بالفاتورة القديمة والجديدة
                    if (item.Quantity > billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).Quantity)
                    {
                        if (item.InvoiceKind == InvoiceKind.Sell)
                        {
                            InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId,
                                item.Quantity - billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).Quantity, InvoiceKind.ReturnSell, item.CreationDate, item.Price);
                            billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).PriceTagId = item.PriceTagId;
                        }
                        else if (item.InvoiceKind == InvoiceKind.Buy)
                        {
                            InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId,
                                /*item.Quantity -*/ billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).Quantity, InvoiceKind.EditBuy, item.CreationDate, item.Price);
                            billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).PriceTagId = item.PriceTagId;
                        }
                    }
                    else if (item.Quantity < billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).Quantity)
                    {
                        if (item.InvoiceKind == InvoiceKind.Sell)
                        {
                            InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId,
                                billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).Quantity - item.Quantity, InvoiceKind.Sell, item.CreationDate, item.Price);
                            billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).PriceTagId = item.PriceTagId;
                        }
                        else if (item.InvoiceKind == InvoiceKind.Buy)
                        {
                            InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId,
                                billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).Quantity /*- item.Quantity*/, InvoiceKind.EditBuy, item.CreationDate, item.Price);
                            billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).PriceTagId = item.PriceTagId;
                        }
                    }
                    billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).Id = item.Id;
                    billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).BillMasterId = item.BillMasterId;
                    billMaster.BillDetails.FirstOrDefault(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId).PriceTagId = item.PriceTagId;

                }
            }
            foreach (var item in billMaster.BillDetails)
            {
                //ADD New Price Tag Id
                //موجود بالجديدة وغير موجود بالقديمة
                if (!old.Any(x => x.ArticaleId == item.ArticaleId && x.UnitTypeId == item.UnitTypeId && x.Barcode == item.Barcode))
                {
                    if (item.InvoiceKind == InvoiceKind.Sell)
                    {
                        InventoryService.UpdateInventory(item.ArticaleId, UserLoggedIn.User.BranchId, UserLoggedIn.User.StoreId, item.UnitTypeId, item.PriceTagId, item.Quantity, InvoiceKind.Sell, item.CreationDate, item.Price);
                    }
                    else if (item.InvoiceKind == InvoiceKind.Buy)
                    {
                        PriceTagMaster PriceTag = new PriceTagMaster()
                        {
                            ArticleId = item.ArticaleId,
                            UnitId = InventoryService.GetSmallestArticleUnit(item.ArticaleId),
                            CountGiftItem = InventoryService.ConvertArticleUnitToSmallestUnit(item.ArticaleId, item.UnitTypeId, item.QuantityGift),
                            CountSoldItem = 0,
                            CountAllItem = InventoryService.ConvertArticleUnitToSmallestUnit(item.ArticaleId, item.UnitTypeId, item.Quantity),
                            BranchId = UserLoggedIn.User.BranchId,
                            ExpiryDate = purchesBillViewModel.FirstOrDefault(x => x.ArticleId == item.ArticaleId && x.UnitId == item.UnitTypeId).ExpiryDate,
                            PriceTagDetails = ArticleService.MakeNewPriceTagDetailForArticle(purchesBillViewModel.FirstOrDefault(x => x.ArticleId == item.ArticaleId && x.UnitId == item.UnitTypeId)),
                        };

                        var entity = context.PriceTagMasters.Add(PriceTag);
                        context.SaveChanges();
                        item.PriceTagId = entity.Entity.Id;
                    }
                }
            }
            context.BillMasters.Update(billMaster);
            context.SaveChanges();
            // New Entry
            if (billMaster.InvoiceKind == Enums.InvoiceKind.Sell)
            {
                EntryService.InsertEntryBillSell(billMaster);
            }
            else if (billMaster.InvoiceKind == Enums.InvoiceKind.Buy)
            {
                EntryService.InsertEntryBillBuy(billMaster);
            }
            return true;
        }
        public bool ReturnBill(InvoiceKind invoiceKind)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    billMaster.IsReturned = true;
                    billMaster.ReturnedTime = DateTime.Now;
                    context.BillMasters.Update(billMaster);
                    var newmasterbill = new BillMaster()
                    {
                        AccountId = billMaster.AccountId,
                        TotalItem = billMaster.TotalItem,
                        TotalPrice = billMaster.TotalPrice,
                        BranchId = billMaster.BranchId,
                        CreationBy = billMaster.CreationBy,
                        InvoiceKind = invoiceKind,
                        CreationDate = DateTime.Now,
                        Payment = billMaster.Payment,
                        PaymentMethod = billMaster.PaymentMethod,
                        RemainingAmount = billMaster.RemainingAmount,
                        YearId = billMaster.YearId,
                        Discount=billMaster.Discount
                    };
                    context.BillMasters.Add(newmasterbill);
                    context.SaveChanges();

                    // Make bill Return Detail
                    var newdetailbil = new List<BillDetail>();
                    foreach (var item in billMaster.BillDetails)
                    {
                        newdetailbil.Add(new BillDetail(newmasterbill)
                        {
                            ArticaleId = item.ArticaleId,
                            Barcode = item.Barcode,
                            BillMasterId = item.BillMasterId,
                            CreationBy = item.CreationBy,
                            CreationDate = DateTime.Now,
                            Discount = item.Discount,
                            InvoiceKind = invoiceKind,
                            Price = item.Price,
                            Quantity = item.Quantity ,
                            TotalPrice = item.TotalPrice,
                            UnitTypeId = item.UnitTypeId,
                            PriceTagId = item.PriceTagId
                        }
                        );
                    }
                    context.BillDetails.AddRange(newdetailbil);
                    context.SaveChanges();
                    if (billMaster.InvoiceKind == InvoiceKind.Buy)
                    {
                        EntryService.InsertEntryReturnBillSell(billMaster);
                        InventoryService.UpdateInventory(billMaster.BillDetails.ToList(), billMaster.BranchId, billMaster.StoreId, invoiceKind: InvoiceKind.ReturnBuy);
                    }
                    else if (billMaster.InvoiceKind == Enums.InvoiceKind.Sell)
                    { 

                        EntryService.InsertEntryReturnBillBuy(billMaster);
                        InventoryService.UpdateInventory(billMaster.BillDetails.ToList(), billMaster.BranchId, billMaster.StoreId, invoiceKind: InvoiceKind.ReturnSell);
                    }
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }
        public bool ExpiryArticlesTransfeer()
        {
            try
            {
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                var newMaster = context.BillMasters.Add(billMaster);
                InventoryService.UpdateInventory(newMaster.Entity.BillDetails.ToList(), newMaster.Entity.BranchId, newMaster.Entity.StoreId, invoiceKind: InvoiceKind.ExpiryArticles);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DestructionBill()
        {
            try
            {
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                var newMaster = context.BillMasters.Add(billMaster);
                context.SaveChanges();
                InventoryService.UpdateInventory(newMaster.Entity.BillDetails.ToList(), newMaster.Entity.BranchId, newMaster.Entity.StoreId, invoiceKind: InvoiceKind.ExpiryArticles);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SellBill()
        {
            try
            {
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                var newMaster = context.BillMasters.Add(billMaster);
                context.SaveChanges();
                EntryService.InsertEntryBillSell(newMaster.Entity);
                InventoryService.UpdateInventory(newMaster.Entity.BillDetails.ToList(), newMaster.Entity.BranchId, newMaster.Entity.StoreId, invoiceKind: InvoiceKind.Sell);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SellInMinusBill()
        {
            try
            {
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                var newMaster = context.BillMasters.Add(billMaster);
                context.SaveChanges();
                EntryService.InsertEntryBillSell(newMaster.Entity);
                InventoryService.UpdateInventoryInMinus(newMaster.Entity.BillDetails.ToList(), newMaster.Entity.BranchId, newMaster.Entity.StoreId, invoiceKind: InvoiceKind.Sell);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool BuyBill()
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            try
            {
                var newMaster = context.BillMasters.Add(billMaster);
                context.SaveChanges();
                EntryService.InsertEntryBillBuy(newMaster.Entity);
                InventoryService.UpdateInventory(newMaster.Entity.BillDetails.ToList(), newMaster.Entity.BranchId, newMaster.Entity.StoreId, invoiceKind: InvoiceKind.Buy);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SellBillMobile(ShefaaPharmacyDbContext context, User user)
        {
            try
            {
                var newMaster = context.BillMasters.Add(billMaster);
                context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[BillMaster] ON");
                context.SaveChanges();
                EntryService.InsertEntryBillSellMobile(context, newMaster.Entity, user);
                InventoryService.UpdateInventoryMobile(context, user, newMaster.Entity.BillDetails.ToList(), newMaster.Entity.BranchId, newMaster.Entity.StoreId, invoiceKind: InvoiceKind.Sell);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
