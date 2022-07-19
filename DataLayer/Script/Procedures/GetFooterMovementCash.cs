using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Script.Procedures
{
    public class GetFooterMovementCash
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[GetFooterMovementCash]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[GetFooterMovementCash]";
        }
        public static string Create()
        {
            return @"Create PROC [dbo].[GetFooterMovementCash] 
                    @AccountId INT,
                    @FromDate DATETIME,
                    @ToDate DATETIME,
                    @CreationBy INT
                    AS 
                    BEGIN
                    SELECT AccountId,SUM(Debit) AS Debit, SUM(Credit) AS Credit FROM dbo.EntryDetail 
                    WHERE AccountId = @AccountId
                    AND CreationDate>=@FromDate AND CreationDate<=@ToDate
                    AND (@CreationBy = 1 OR CreationBy = @CreationBy)
                    GROUP BY AccountId
                    END";
        }
    }
}
