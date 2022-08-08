using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Script.Procedures
{
    public class GetProfitFromDateToDateScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'GetProfitFromDateToDate') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure GetProfitFromDateToDate";
        }
        public static string Create()
        {
			return @"Create Procedure GetProfitFromDateToDate 
                    @FromDate Date,
                    @ToDate Date 
                    As
	                    Declare @sumsells float= 0; 
	                    declare @sumpurches float ; 
	                    declare @allexpense float;
	                    declare @allprofit float;
	                    declare @netprofit float;
						-- المبيعات
	                    SELECT 0 as Id , 'المبيعات' as Account, Sum(Credit) Credit , 0 as Debit , Sum(Credit) as Total INTO #tempSell  FROM dbo.EntryDetail 
				                       WHERE AccountId IN (SELECT Id FROM dbo.Account WHERE AccountGeneralId = 4 OR Id=4) 
				                       AND CreationDate >= @FromDate AND CreationDate <=@ToDate
						-- خصم ممنوح للزبائن
	                    SELECT 1 as Id ,'خصم ممنوح للزبائن' as Account,0 as Credit ,Sum(Discount) as Debit , Sum(Discount) as Total INTO #tempSellDiscount  FROM dbo.BillMaster 
				                       WHERE InvoiceKind = 1 AND CreationDate >= @FromDate AND CreationDate <=@ToDate 
					    -- مرتجع مبيعات
	                    select 2 as Id , 'مرتجع مبيعات' as Account,0 as Credit , Sum(payment) as Debit , Sum(payment) as Total  into #tempSellReturn from billmaster 
									  WHERE InvoiceKind = 4 AND CreationDate >= @FromDate AND CreationDate <=@ToDate

						-- صافي المبيعات
						Select 3 as Id ,'صافي المبيعات' as Account ,
									0 as Credit ,
									0 as Debit ,
									(ISNULL((select SUM(Credit) from #tempSell ),0)) as Total 
									Into #TempNetSells

						-- المشتريات
	                    SELECT 4 as Id , 'المشتريات' as Account,0 as Credit,Sum(Debit) as Debit ,Sum(Debit) as Total  INTO #tempPurches  FROM dbo.EntryDetail 
				                       WHERE AccountId IN (SELECT Id FROM dbo.Account WHERE AccountGeneralId = 5 OR Id=5) 
				                       AND CreationDate >= @FromDate AND CreationDate <=@ToDate
						--بضاعة أول مدة
	                    SELECT  5 as Id ,'بضاعة أول مدة' as Account,Sum(Debit) as Debit,0 as Credit, Sum(Debit) as Total INTO #tempFirstGood  FROM dbo.EntryDetail 
				                       WHERE AccountId IN (SELECT Id FROM dbo.Account WHERE AccountGeneralId = 19 OR Id=19) 
				                       AND CreationDate >= @FromDate AND CreationDate <=@ToDate
						--خصم مكتسب
	                    SELECT 6 as Id ,'خصم مكتسب' as Account,Sum(Discount) as Credit,0 as Debit, Sum(Discount) as Total INTO #tempPurchesDiscount  FROM dbo.BillMaster 
				                       WHERE InvoiceKind = 2 
				                       AND CreationDate >= @FromDate AND CreationDate <=@ToDate
						--مرتجع مشتريات
	                    select 7 as Id ,'مرتجع مشتريات' as Account, Sum(payment) as Credit,0 as Debit, Sum(payment) as Total into #tempPurchesReturn from billmaster 
					                    WHERE InvoiceKind = 3
					                    AND CreationDate >= @FromDate AND CreationDate <=@ToDate
						--بضاعة آخر المدة
						select 8 as Id,'بضاعة آخر المدة' as Account,0 as Debit,0 as Credit,Sum(TotalPrice *QuantityLeft) as Total INTO #tempLastArticles From dbo.LastTimeArticles
				                    WHERE CreationDate >= @FromDate AND CreationDate <=@ToDate
									AND TotalPrice > 0

						-- تكلفة المبيعات
						Select 9 as Id , 'تكلفة المبيعات' as Account ,0 as Credit , 0 as Debit ,
									(ISNULL((select Total from #tempFirstGood ),0) + ISNULL((select Total from #tempPurches),0)-ISNULL((select Total from #tempLastArticles),0)) as Total 
									Into #TempNetPurches
						
						--مجمل الربح
						Select 10 as Id ,'مجمل الربح' as Account ,  0 as Debit , 0 as Credit , IsNull((Select Sum(Total) from #TempNetSells),0) -IsNull((Select Sum(Total) from #TempNetPurches),0)  as Total 
									Into #TempProfit
						
	                    --set @allprofit = (select ISNULL(@sumsells,0) - ISNULL(@sumpurches ,0))
						--المصاريف
	                    select 11 as Id ,'المصاريف' as Account, Sum(Credit) as Credit, Sum(Debit) as Debit, Sum(Debit - Credit) as Total INTO #tempExpense from dbo.EntryDetail 
				                     Where AccountId IN (Select Id from Account where AccountGeneralId = 8 OR Id = 8) and AccountId Not in (20)
				                     AND CreationDate >= @FromDate AND CreationDate <=@ToDate
 
						--بضاعة منتهية الصلاحية
						Select 12 as Id , 'بضاعة منتهية الصلاحية' As Account, Sum(Debit) as Debit , 0 as Credit ,Sum(Debit) as Total INTO #tempExpiryArticles from dbo.EntryDetail
									Where AccountId = 20

						--صافي الربح
						Select 13 as Id ,'صافي الربح' as Account ,  0 as Debit , 0 as Credit , IsNull((Select Sum(Total) from #TempProfit),0) -IsNull((Select Sum(Debit) from #tempExpense),0)  as Total
									into #TempNetProfit

						
											
	                    --select @sumsells as 'Sells' , @sumpurches as 'Purches' , @allprofit as 'All Profit' , @allexpense as 'Expense' , @netprofit as 'Net Profit'  
						--select * from #tempSell 
						--Union 
						--select * from #tempSellReturn
						--Union 
						--select * from #tempSellDiscount 
						--Union 
						select * from #TempNetSells
						Union 
						select * from #tempFirstGood 
						Union 
						select * from #tempPurches
						Union 
						--select * from #tempPurchesDiscount
						--Union 
						--select * from #tempPurchesReturn
						--Union 
						select * from #TempNetPurches
						Union 
						select * from #TempProfit
						Union 
						select * from #tempExpense
						Union 
						select * from #tempExpiryArticles
						Union
						select * from #TempNetProfit
						Union 
						select * from #tempLastArticles";
			//--WHERE id=(select ArticleId from dbo.pricetagmaster WHERE ExpiryDate>=0)
			//Union select* from #tempLastArticles
		}
	}
}
