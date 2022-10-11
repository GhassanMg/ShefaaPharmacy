using DataLayer.Enums;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.MapTables
{
    public class UserMap
    {
        public UserMap()
        {

        }
        public void SeedData(EntityTypeBuilder<UserPermissions> entity)
        {
            entity.HasData(new UserPermissions()
            {
                Id = 2,
                CanBuyBill = true,
                CanDeleteBill = true,
                CanDeleteEntry = true,
                CanInsertEntry = true,
                CanSellBill = true,
                UserId = 2,
                CustomerAccountId = 11,
                CashAccountId = 12,
                SellAccountId = 13,
                BuyAccountId = 14,
                UserDesktopUI = UserDesktopUI.Icons
            });
            entity.HasData(new UserPermissions()
            {
                Id = 3,
                CanBuyBill = false,
                CanDeleteBill = false,
                CanDeleteEntry = false,
                CanInsertEntry = false,
                CanSellBill = false,
                UserId = 3,
                CustomerAccountId = 11,
                CashAccountId = 12,
                SellAccountId = 13,
                BuyAccountId = 14,
                UserDesktopUI = UserDesktopUI.Icons
            });
            entity.HasData(new UserPermissions()
            {
                Id = 4,
                CanBuyBill = false,
                CanDeleteBill = false,
                CanDeleteEntry = false,
                CanInsertEntry = false,
                CanSellBill = false,
                UserId = 4,
                CustomerAccountId = 11,
                CashAccountId = 12,
                SellAccountId = 13,
                BuyAccountId = 14,
                UserDesktopUI = UserDesktopUI.Icons
            });
            entity.HasData(new UserPermissions()
            {
                Id = 5,
                CanBuyBill = false,
                CanDeleteBill = false,
                CanDeleteEntry = false,
                CanInsertEntry = false,
                CanSellBill = false,
                UserId = 5,
                CustomerAccountId = 11,
                CashAccountId = 12,
                SellAccountId = 13,
                BuyAccountId = 14,
                UserDesktopUI = UserDesktopUI.Icons 
            });
        }
    }
}
