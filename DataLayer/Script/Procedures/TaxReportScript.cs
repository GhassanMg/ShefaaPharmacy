namespace DataLayer.Script.Procedures
{
    class TaxReportScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[TaxReport]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[TaxReport]";
        }
        public static string Create()
        {
            return @"Create Procedure TaxReport 
                    @FromDate DATETIME,
                    @ToDate DATETIME,
                    @CreationBy INT, 
                    @YearId INT
                    As
                    Begin 
                    Select * from DetailedTaxCode where 
                    CreationDate>=@FromDate AND CreationDate<=@ToDate
                    AND (@CreationBy = 1 OR CreationBy = @CreationBy)
                    AND (YearId = @YearId)
                    End";
        }
    }
}
