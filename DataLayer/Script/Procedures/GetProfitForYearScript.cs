using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Script.Procedures
{
    public class GetProfitForYearScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[GetProfitForYear]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[GetProfitForYear]";
        }
        public static string Create()
        {
            return @"CREATE PROC GetProfitForYear
                    @YearId INT
                    AS
                    --رأس المال
                    SELECT a.AccountId,a.Debit , a. Credit INTO #tempFirstMoney  FROM dbo.EntryDetail AS a
                    INNER JOIN dbo.EntryMaster AS b
                    ON b.Id = a.EntryMasterId
                    WHERE a.AccountId IN (SELECT Id FROM dbo.Account WHERE CategoryId = 10 AND General=0) 
                    AND 
                    b.YearId = @YearId
                    --الموجودات
                    SELECT  a.AccountId,a.Debit , a. Credit INTO #tempFirstGoods  FROM dbo.EntryDetail AS a
                    INNER JOIN dbo.EntryMaster AS b
                    ON b.Id = a.EntryMasterId
                    WHERE a.AccountId IN (SELECT Id FROM dbo.Account WHERE CategoryId = 11 AND General=0)  
                    AND 
                    b.YearId = @YearId
                    ---- المشتريات
                    --SELECT * INTO #tempPurches  FROM dbo.EntryDetail 
                    --WHERE AccountId IN (SELECT Id FROM dbo.Account WHERE AccountGeneralId = 5 AND General=0) 
                    ---- المبيعات
                    --SELECT * INTO #tempSell  FROM dbo.EntryDetail 
                    --WHERE AccountId IN (SELECT Id FROM dbo.Account WHERE AccountGeneralId = 4 AND General=0) 
                    -- المصاريف
                    SELECT  a.AccountId,a.Debit , a. Credit INTO #tempExpense  FROM dbo.EntryDetail AS a
                    INNER JOIN dbo.EntryMaster AS b
                    ON b.Id = a.EntryMasterId
                    WHERE a.AccountId IN (SELECT Id FROM dbo.Account WHERE CategoryId = 8 AND General=0)  
                    AND 
                    b.YearId = @YearId
                    -- الضرائب
                    SELECT  a.AccountId,a.Debit , a. Credit INTO #tempTax  FROM dbo.EntryDetail AS a
                    INNER JOIN dbo.EntryMaster AS b
                    ON b.Id = a.EntryMasterId
                    WHERE a.AccountId IN (SELECT Id FROM dbo.Account WHERE CategoryId = 9 AND General=0)  
                    AND 
                    b.YearId = @YearId
                    -- الصندوق
                    SELECT  a.AccountId,a.Debit , a. Credit INTO #tempCash  FROM dbo.EntryDetail AS a
                    INNER JOIN dbo.EntryMaster AS b
                    ON b.Id = a.EntryMasterId
                    WHERE a.AccountId IN (SELECT Id FROM dbo.Account WHERE CategoryId = 3 AND General=0) 
                    AND 
                    b.YearId = @YearId
                    --
                    SELECT  a.AccountId,a.Debit , a. Credit INTO #tempProvider  FROM dbo.EntryDetail AS a
                    INNER JOIN dbo.EntryMaster AS b
                    ON b.Id = a.EntryMasterId
                    WHERE a.AccountId IN (SELECT Id FROM dbo.Account WHERE CategoryId = 6 AND General=0) 
                    AND 
                    b.YearId = @YearId
                    --
                    SELECT  a.AccountId,a.Debit , a. Credit INTO #tempCustomer  FROM dbo.EntryDetail AS a
                    INNER JOIN dbo.EntryMaster AS b
                    ON b.Id = a.EntryMasterId
                    WHERE a.AccountId IN (SELECT Id FROM dbo.Account WHERE CategoryId = 2 AND General=0) 
                    AND 
                    b.YearId = @YearId


                    SELECT AccountId,ISNULL(SUM(Debit),0) AS Debit,ISNULL(SUM(Credit),0) AS Credit FROM #tempCash GROUP BY AccountId UNION
                    SELECT AccountId,ISNULL(SUM(Debit),0) AS Debit,ISNULL(SUM(Credit),0) AS Credit FROM #tempProvider GROUP BY AccountId UNION
                    SELECT AccountId,ISNULL(SUM(Debit),0) AS Debit,ISNULL(SUM(Credit),0) AS Credit FROM #tempCustomer GROUP BY AccountId UNION
                    SELECT AccountId,ISNULL(SUM(Debit),0) AS Debit,ISNULL(SUM(Credit),0) AS Credit FROM #tempExpense GROUP BY AccountId UNION
                    SELECT AccountId,ISNULL(SUM(Debit),0) AS Debit,ISNULL(SUM(Credit),0) AS Credit FROM #tempTax GROUP BY AccountId UNION
                    SELECT AccountId,ISNULL(SUM(Debit),0) AS Debit,ISNULL(SUM(Credit),0) AS Credit FROM #tempFirstGoods GROUP BY AccountId UNION
                    SELECT AccountId,ISNULL(SUM(Debit),0) AS Debit,ISNULL(SUM(Credit),0) AS Credit FROM #tempFirstMoney GROUP BY AccountId ";
        }
    }
}
