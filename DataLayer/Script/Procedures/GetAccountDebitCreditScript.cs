using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Script.Procedures
{
    public class GetAccountDebitCreditScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[GetAccountDebitCredit]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[GetAccountDebitCredit]";
        }
        public static string Create()
        {
            return @"Create PROC GetAccountDebitCredit
                         @AccountId INT,
					@FromDate DATETIME,
					@ToDate DATETIME,
                    @CreationBy INT
                    AS
                    DECLARE @ItsGeneral BIT
                    DECLARE @Debit INT
                    DECLARE @Credit INT
					SET @ItsGeneral = 0
					 SET @ItsGeneral = (SELECT TOP 1 General FROM dbo.Account WHERE Id = @AccountId)
					 IF	@ItsGeneral = 0 
					 BEGIN
						SET @Debit = (SELECT SUM(Debit) FROM dbo.EntryDetail WHERE AccountId = @AccountId
						AND CreationDate>=@FromDate AND CreationDate<=@ToDate
						AND (@CreationBy = 1 OR CreationBy = @CreationBy) )
							SET @Credit = (SELECT SUM(Credit) FROM dbo.EntryDetail WHERE AccountId = @AccountId
						AND CreationDate>=@FromDate AND CreationDate<=@ToDate
						AND (@CreationBy = 1 OR CreationBy = @CreationBy) )
							SELECT @AccountId AS AccountId, @Debit AS Debit, @Credit AS Credit
					 End
					 ELSE
					 BEGIN
						 SET @Debit = (SELECT SUM(Debit) FROM dbo.EntryDetail as b WHERE 
						 (b.AccountId = @AccountId) OR (b.AccountId IN (SELECT Id FROM dbo.Account WHERE General = 0 AND
						  AccountGeneralId = @AccountId ))
						AND CreationDate>=@FromDate AND CreationDate<=@ToDate
						AND (@CreationBy = 1 OR CreationBy = @CreationBy) )
							SET @Credit = (SELECT SUM(Credit) FROM dbo.EntryDetail as b where
							(b.AccountId = @AccountId) OR (b.AccountId IN (SELECT Id FROM dbo.Account WHERE General = 0 AND
						  AccountGeneralId = @AccountId ))
						AND CreationDate>=@FromDate AND CreationDate<=@ToDate
						AND (@CreationBy = 1 OR CreationBy = @CreationBy) )
							SELECT @AccountId AS AccountId, @Debit AS Debit, @Credit AS Credit
					 END";
        }
    }
}
