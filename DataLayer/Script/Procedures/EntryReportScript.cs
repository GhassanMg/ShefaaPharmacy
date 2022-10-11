namespace DataLayer.Script.Procedures
{
    public class EntryReportScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[EntryReport]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[EntryReport]";
        }
        public static string Create()
        {
            return @"Create Procedure EntryReport 
                    @FromDate DATETIME,
                    @ToDate DATETIME,
                    @CreationBy INT, 
                    @YearId INT
                    As
                    Begin 
                    Select * from EntryMaster where 
                    CreationDate>=@FromDate AND CreationDate<=@ToDate
                    AND (@CreationBy = 1 OR CreationBy = @CreationBy)
                    AND (YearId = @YearId)
                    End";
        }
    }
}
