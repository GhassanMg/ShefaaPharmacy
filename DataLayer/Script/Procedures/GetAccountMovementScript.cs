namespace DataLayer.Script.Procedures
{
    public class GetAccountMovementScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[GetAccountMovmement]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[GetAccountMovmement]";
        }
        public static string Create()
        {
			return @"CREATE PROC [dbo].[GetAccountMovmement]
                     @AccountId INT,
					 @FromDate DATETIME,
					 @ToDate DATETIME,
                     @CreationBy INT
                     AS 
					 DECLARE @ItsGeneral BIT
					 SET @ItsGeneral = 0
					 SET @ItsGeneral = (SELECT TOP 1 General FROM dbo.Account WHERE Id = @AccountId)
					 IF	@ItsGeneral = 1 
					 BEGIN
						 SELECT * From EntryDetail as b
						 WHERE (b.AccountId = @AccountId) OR (b.AccountId IN (SELECT Id FROM dbo.Account WHERE AccountGeneralId = @AccountId ))
						 AND b.CreationDate>=@FromDate AND b.CreationDate<=@ToDate
						 AND (@CreationBy = 1 OR b.CreationBy = @CreationBy)
					 END
					 ELSE
					 BEGIN
						 SELECT * From EntryDetail as b
						 WHERE b.AccountId = @AccountId
						 AND b.CreationDate>=@FromDate AND b.CreationDate<=@ToDate
						 AND (@CreationBy = 1 OR b.CreationBy = @CreationBy)
					 END";
        }
    }
}
