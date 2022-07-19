using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Script.Procedures
{
    public class GetArticleInStore
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[GetArticleInStore]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[GetArticleInStore]";
        }
        public static string Create()
        {
            return @"Create PROC [dbo].[GetArticleInStore]
                    AS
                    SELECT a.Barcode , a.ExpiryDate INTO #art FROM dbo.Article AS a 
                    INNER JOIN dbo.BillDetail AS b
                    ON b.Barcode = a.Barcode
                    WHERE a.ExpiryDate<=DATEADD(DAY, 10, GETDATE())
                    GROUP BY a.Barcode, a.ExpiryDate
                    --Buy
                    SELECT b.ArticaleId,a.ExpiryDate,SUM(b.Quentity) AS buyQuantity INTO #buy FROM #art AS a 
                    INNER JOIN dbo.BillDetail AS b
                    ON
                    b.Barcode = a.Barcode
                    WHERE 
                    b.InvoiceKind=1
                    GROUP BY b.ArticaleId, a.ExpiryDate
                    --Sell
                    SELECT b.ArticaleId,a.ExpiryDate,SUM(b.Quentity) AS sellQuantity INTO #sell FROM #art AS a 
                    INNER JOIN dbo.BillDetail AS b
                    ON
                    b.Barcode = a.Barcode
                    WHERE 
                    b.InvoiceKind=0
                    GROUP BY b.ArticaleId, a.ExpiryDate
                    --
                    SELECT a.ArticaleId AS ArticleId, (ISNULL(a.buyQuantity,0) - ISNULL(b.sellQuantity,0)) AS QuantityLeft  , a.ExpiryDate FROM #buy AS a 
                    FULL JOIN #sell AS b 
                    ON
                    b.ArticaleId = a.ArticaleId";
        }
    }
}
