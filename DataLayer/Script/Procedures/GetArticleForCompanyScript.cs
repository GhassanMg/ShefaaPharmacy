namespace DataLayer.Script.Procedures
{
    public class GetArticleForCompanyScript
    {
        public static string Drop()
        {
            return @"If exists (select * from sysobjects where id = object_id(N'[dbo].[GetArticleForCompany]') and 
                            OBJECTPROPERTY(id, N'IsProcedure') = 1) 
                            drop procedure [dbo].[GetArticleForCompany]";
        }
        public static string Create()
        {
            return @"Create proc GetArticleForCompany 
                        @companyId int
                        As
                        select a.Id as 'ArticleId' from Articale  as a 
                        inner join Company as b
                        on a.CompanyId = b.Id
                        Where b.Id = @companyId";
        }
    }
}
