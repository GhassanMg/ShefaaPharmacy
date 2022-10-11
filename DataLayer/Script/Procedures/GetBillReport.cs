namespace DataLayer.Script.Procedures
{
    public class GetBillReport
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[BillReport]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[BillReport]";
        }
        public static string Create()
        {
            return @"Create PROC [dbo].[BillReport]
					 @InvoiceKind INT ,
					 @BillId INT,
                     @AccountId INT,
					 @FromDate DATETIME,
					 @ToDate DATETIME,
                     @CreationBy INT
                     AS 
                     SELECT * FROM dbo.BillMaster
					 WHERE 
					 (@AccountId=0 OR AccountId = @AccountId )
					 AND (@BillId = 0 OR Id = @BillId)
					 AND(@InvoiceKind =0 OR InvoiceKind=@InvoiceKind)
                     AND (CreationDate >=@FromDate AND CreationDate <= @ToDate)
                     AND (@CreationBy = 1 OR CreationBy = @CreationBy)";
        }
    }
}
