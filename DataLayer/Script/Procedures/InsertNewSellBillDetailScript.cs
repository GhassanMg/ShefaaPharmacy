namespace DataLayer.Script.Procedures
{
    public class InsertNewSellBillDetailScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[InsertNewSellBillDetail]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[InsertNewSellBillDetail]";
        }
        public static string Create()
        {
            return @"Create Proc InsertNewSellBillDetail
                    @Barcode varchar , 
                    @CreationBy int ,
                    @Quentity int ,
                    @Price float ,
                    @Discount float ,
                    @TotalPrice float ,
                    @PriceTagId int ,
                    @UnitTypeId int ,
                    @ArticaleId int ,
                    @BillMasterId int
                    AS  
                    Begin 
                    INSERT INTO [dbo].[BillDetail]([CreationBy],[CreationDate],[Barcode],[InvoiceKind],[UnitTypeIdBasic],[Quantity]
                               ,[Price],[Discount],[TotalPrice],[PriceTagId],[ArticaleId],[UnitTypeId],[BillMasterId])
                         VALUES
                               (@CreationBy, GETDATE(), @Barcode , 1 , @UnitTypeId , @Quentity, @Price ,@Discount , @TotalPrice ,
		                       @PriceTagId , @ArticaleId , @UnitTypeId ,@BillMasterId) 
                    End";
        }
    }
}
