using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Script.Procedures
{
    public class UpdateInvintoryScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[UpdateInvintory]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[UpdateInvintory]";
        }
        public static string Create()
        {
            return @"Create Proc UpdateInvintory 
                    @ArticleId int , 
                    @UserId int ,
                    @UnitTypeId int , 
                    @PriceTagId int , 
                    @Quantity int 
                    As 
                    Begin
	                    Declare 
		                    @YearId int,
		                    @BranchId int, 
		                    @StoreId int , 
		                    @inventoryId int , 
		                    @PriceTag int , 
		                    @unit1 int,
		                    @unit2 int,
		                    @unit3 int , 
		                    @Qunat int ,
		                    @QunatityOfPrimary int , 
		                    @QunatityOfSecondry int  ,
		                    @prCount int ,
		                    @secCount int ,
		                    @Deff  int

	
	                    Set @YearId = (Select Top 1 Id From [dbo].[Year] Order By CreationDate Desc)
	                    Set @BranchId  = (Select Top 1 BranchId From [dbo].[User] Where Id = @UserId )
	                    Set @StoreId = (Select Top 1 StoreId From [dbo].[User] Where Id = @UserId )
	                    Set @PriceTag = (Select UnitTypeId  From [dbo].[PriceTag] Where Id = @PriceTagId )
    
	                     IF @PriceTag is NOT NULL 
	                     Begin 
	                        Select @QunatityOfPrimary  = QuentityOfPrimary , @QunatityOfSecondry = QuentityOfSecondary From [dbo].[PriceTag] Where Id = @PriceTagId
		                    Set @unit1 = (Select UnitTypeId  From [dbo].[PriceTag] Where Id = @PriceTagId )
		                    Set @unit2 = (Select Unit2TypeId  From [dbo].[PriceTag] Where Id = @PriceTagId )
		                    Set @unit3 = (Select Unit3TypeId  From [dbo].[PriceTag] Where Id = @PriceTagId )
		                    If @unit1 = @UnitTypeId
		                    Begin
			                    Set @inventoryId = (select 1 from Inventories where ArticleId =@ArticleId and StoreId =@StoreId  and BranchId = @BranchId and UnitTypeId = @UnitTypeId and PriceTagId = @PriceTagId)
			                    If( @inventoryId is NULL)
			                    Begin
			                     INSERT INTO [dbo].[Inventories]([ArticleId],[BranchId],[StoreId],[PriceTagId],[UnitTypeId],[Quantity])
			                     VALUES (@ArticleId,@BranchId,@StoreId,@PriceTagId,@UnitTypeId,0);
			                    End 
			                    Update [dbo].[Inventories] Set Quantity=Quantity-@Quantity where  ArticleId =@ArticleId and StoreId =@StoreId  
										                    and BranchId = @BranchId and UnitTypeId = @UnitTypeId and PriceTagId = @PriceTagId
		                    ENd
		                    Else if @unit2 =@UnitTypeId
		                    Begin
		                      Set @inventoryId = (select 1 from Inventories where ArticleId =@ArticleId and StoreId =@StoreId  and BranchId = @BranchId and UnitTypeId = @UnitTypeId and PriceTagId = @PriceTagId)
		                      IF @inventoryId is Null
		                      Begin
		                        insert into Inventories (ArticleId , StoreId , BranchId , UnitTypeId , PriceTagId) Values (@ArticleId,@StoreId,@BranchId,@UnitTypeId,@PriceTagId)
		                      End
		                      Set @Qunat = (Select Quantity from Inventories where ArticleId =@ArticleId and StoreId =@StoreId  and BranchId = @BranchId and UnitTypeId = @UnitTypeId and PriceTagId = @PriceTagId)
		                      if @Qunat = 0
		                      Begin
			                    if @Quantity > @QunatityOfPrimary
			                    Begin 
			                      Set @prCount = (@Quantity / @QunatityOfPrimary)
			                      Set @secCount = (@Quantity -(@prCount* @QunatityOfPrimary))
			                      if @secCount> 0 
			                      Begin
			                       Set @prCount = @prCount + 1
			                      End
			                      exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@unit2,@prCount,1
			                      IF @secCount> 0 
			                      Begin
			                         exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@UnitTypeId,@prCount,1
			                      End
			                    End 
			                    Else
			                    Begin
			                     Declare @res int 
			                     set @res = (@QunatityOfPrimary -  @Quantity)
			                     exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@UnitTypeId,1,1
			                     SELECT @res = @res * -1;
			                     exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@UnitTypeId, @res   ,1
			                    End
		                      End
		                      Else
		                      Begin
		                        IF @Quantity > @QunatityOfPrimary
			                    Begin 
			   
			                      Set @prCount = (@Quantity / @QunatityOfPrimary)
			                      Set @secCount = (@Quantity -(@prCount* @QunatityOfPrimary))
			                      if @secCount> 0 
			                      Begin
			                       Set @prCount = @prCount + 1
			                      End	
			                      IF @secCount <= @Qunat
			                      Begin
			                        exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@unit1,@prCount,1
				                    if @secCount >  0
				                    Begin
					                    exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@UnitTypeId,@secCount,1
				                    End
			                      End
			                      Else 
			                      Begin
				                    Set @Deff = (@secCount - @Qunat) *(-1)
				                    Set @prCount = @prCount + 1
				                    exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@UnitTypeId,@Qunat,1
				                    exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@unit1,@prCount,1
				                    exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@UnitTypeId,@Deff,1
			                      End
			                    End
			                    Else
			                    BEGIN
				                    IF @Quantity <= @Qunat
				                    Begin
					                    exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@UnitTypeId,@Quantity,1
				                    End
				                    Else
				                    Begin
				                      Set @Deff = (@Quantity - @Qunat)
				                      Declare @rr int 
				                      Set @rr = (@QunatityOfPrimary - @Deff) *(-1)
				                      exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@UnitTypeId,@Qunat,1
				                    exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@unit1,1,1
				                    exec [dbo].[IncresedOrDecresedQantity] @ArticleId , @BranchId , @StoreId,@PriceTagId ,@UnitTypeId,@rr,1
				                    End
			                    END
		                      End

		                    End
	                     END
                    End";
        }
    }
}
