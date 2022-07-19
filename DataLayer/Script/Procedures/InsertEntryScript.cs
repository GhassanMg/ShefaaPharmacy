using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Script.Procedures
{
    public class InsertEntryScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[InsertEntry]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[InsertEntry]";
        }
        public static string Create()
        {
            return @"create Procedure InsertEntry
                        @CreationBy int,
                        @BillMasterId int ,
                        @TotalPrice Float , 
                        @KindOperation int ,
                        @Payment Float


                        AS 
                        Begin 
	                        Declare 
		                        @YearId int,
		                        @BranchId int, 
		                        @StoreId int ,
		                        @EntryMasterId int,
		                        @CustomerAccountId int,
		                        @SellAccountId int,
		                        @CashAccountId int,
		                        @TotDebit Float , 
		                        @TotCredit Float

	                        Set @YearId = (Select Top 1 Id From [dbo].[Year] Order By CreationDate Desc)
	                        Set @BranchId  = (Select Top 1 BranchId From [dbo].[User] Where Id = @CreationBy )
                            Set @StoreId = (Select Top 1 StoreId From [dbo].[User] Where Id = @CreationBy )	
	                        Set @CustomerAccountId = (Select Top 1 CustomerAccountId From [dbo].[UserPermissions] where UserId = @CreationBy)
	                        Set @SellAccountId = (Select Top 1 SellAccountId From [dbo].[UserPermissions] where UserId = @CreationBy)
	                        Set @CashAccountId = (Select Top 1 CashAccountId From [dbo].[UserPermissions] where UserId = @CreationBy)

                            INSERT INTO [dbo].[EntryMaster]([CreationBy],[CreationDate],[KindOperation],[RelatedDocument]
                                   ,[TotalDebit],[TotalCredit],[YearId],[AccountId],[BranchId])
                            VALUES
	                         (@CreationBy , GetDate(),@KindOperation,@BillMasterId,@TotalPrice,@TotalPrice,@YearId, Null ,@BranchId)

	                        set @EntryMasterId   = SCOPE_IDENTITY()
	                        --1--
	                        INSERT INTO [dbo].[EntryDetail]([CreationBy],[CreationDate],[KindOperation],[Debit],[Credit],[Description],[EntryMasterId],[AccountId])
                            VALUES
	                        (@CreationBy,GETDATE(),@KindOperation,@Payment,0,'حساب الزبون',@EntryMasterId,@CustomerAccountId)

	                        --2--
	                        INSERT INTO [dbo].[EntryDetail]([CreationBy],[CreationDate],[KindOperation],[Debit],[Credit],[Description],[EntryMasterId],[AccountId])
                            VALUES
	                        (@CreationBy,GETDATE(),@KindOperation,0,@Payment,'المبيعات',@EntryMasterId,@SellAccountId)

	                        --3--
	                        INSERT INTO [dbo].[EntryDetail]([CreationBy],[CreationDate],[KindOperation],[Debit],[Credit],[Description],[EntryMasterId],[AccountId])
                            VALUES
	                        (@CreationBy,GETDATE(),@KindOperation,0,@Payment,'حساب الزبون',@EntryMasterId,@CustomerAccountId)

	                        --4--
	                        INSERT INTO [dbo].[EntryDetail]([CreationBy],[CreationDate],[KindOperation],[Debit],[Credit],[Description],[EntryMasterId],[AccountId])
                            VALUES
	                        (@CreationBy,GETDATE(),@KindOperation,@Payment,0,'الصندوق',@EntryMasterId,@CashAccountId)


	                        Select @TotDebit = Sum(Debit)  , @TotCredit = Sum(Credit) from EntryDetail where EntryMasterId = @EntryMasterId		 

	                        Update EntryMaster Set TotalCredit = @TotCredit ,TotalDebit =@TotDebit
	                        where Id = @EntryMasterId
	 
                        End";
        }
    }
}
