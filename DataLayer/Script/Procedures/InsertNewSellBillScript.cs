namespace DataLayer.Script.Procedures
{
    public class InsertNewSellBillScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[InsertNewSellBill]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[InsertNewSellBill]";
        }
        public static string Create()
        {
            return @"Create Proc [dbo].[InsertNewSellBill]
                    @UserId int , 
                    @TotalPrice float, 
                    @TotalItem int ,
                    @Payment float,
                    @RemainingAmount float,
                    @Discount float
                    As 
                    Begin
	                    Declare 
		                    @YearId int,
		                    @BranchId int, 
		                    @StoreId int;
	
	                    Set @YearId = (Select Top 1 Id From [dbo].[Year] Order By CreationDate Desc)
	                    Set @BranchId  = (Select Top 1 BranchId From [dbo].[User] Where Id = @userId )
	                    Set @StoreId = (Select Top 1 StoreId From [dbo].[User] Where Id = @userId )

	                    INSERT INTO [dbo].[BillMaster]
				                    ([CreationBy],[CreationDate],[InvoiceKind],[PaymentMethod],[CreatedBy],[TotalPrice],[TotalItem],[Payment],[RemainingAmount],[Discount]
			                        ,[IsReturned],[ReturnTo],[ReturnedTime],[BranchId],[YearId],[StoreId],[AccountId])
	                    VALUES		( @userId, GETDATE() , 1 , 0 , Null , @TotalPrice , @TotalItem , @Payment , @RemainingAmount , @Discount , 
                                    0, 0 , CONVERT(datetime,'1980-01-01'), @BranchId , @YearId , @StoreId, 11)
                        Return SCOPE_IDENTITY()
                    END";
        }
    }

}
