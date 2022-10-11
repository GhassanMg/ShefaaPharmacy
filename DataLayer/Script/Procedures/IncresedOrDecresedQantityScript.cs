namespace DataLayer.Script.Procedures
{
    public class IncresedOrDecresedQantityScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[IncresedOrDecresedQantity]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[IncresedOrDecresedQantity]";
        }
        public static string Create()
        {
            return @"create Procedure IncresedOrDecresedQantity
                    @ArticleId int , 
                    @BranchId int ,
                    @StoreId int ,
                    @PriceTagId int ,
                    @UnitTypeId int ,
                    @Quantity int ,
                    @InvoiceKind int
                    As
                    Begin
	                    Declare @inventoryId int
	                    Set @inventoryId = (select 1 from Inventories where ArticleId = @ArticleId and StoreId =@StoreId  and BranchId = @BranchId and UnitTypeId = @UnitTypeId and PriceTagId = @PriceTagId)
	                    If( @inventoryId is NULL)
	                    Begin
		                    INSERT INTO [dbo].[Inventories]([ArticleId],[BranchId],[StoreId],[PriceTagId],[UnitTypeId],[Quantity])
		                    VALUES (@ArticleId,@BranchId,@StoreId,@PriceTagId,@UnitTypeId,0);
	                    End 
	                    if @InvoiceKind = 1
		                    Update [dbo].[Inventories] Set Quantity= Quantity - @Quantity where  ArticleId =@ArticleId and StoreId =@StoreId  
										                    and BranchId = @BranchId and UnitTypeId = @UnitTypeId and PriceTagId = @PriceTagId
                    End";
        }
    }
}
