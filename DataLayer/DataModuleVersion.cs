using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer
{
    public class DataModuleVersion
    {
        public void checkedTableFromVersion(string version)
        {
            switch (version)
            {
                case "A1":
                    {
                        //ShefaaPharmacyDbContext.GetCurrentContext().Database.ExecuteSqlRaw(CreateColumn("CountNumberAfterComma", "DataBaseConfigurations", "INT", 0));
                        //ShefaaPharmacyDbContext.GetCurrentContext().Database.ExecuteSqlRaw(CreateColumn("RoundToNearest", "DataBaseConfigurations", "INT", 0));
                        //ShefaaPharmacyDbContext.GetCurrentContext().Database.ExecuteSqlRaw(CreateColumn("CountSoldItem", "PriceTag", "INT", 0));
                        break;
                    }
                default:
                    break;
            }
        }
        public void BackUp()
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                string fileName = AppDomain.CurrentDomain.BaseDirectory + context.Database.GetDbConnection().Database + "_" + (DateTime.Now.Ticks / 10) % 100000000;
                context.Database.ExecuteSqlRaw("BACKUP DATABASE " + context.Database.GetDbConnection().Database + " TO DISK = '" + fileName + "'");
            }
            catch (Exception ex)
            {
                ;
            }
        }
        public string CreateColumn(string colName, string tableName, string dataType, object defaultValue)
        {
            return @"IF NOT EXISTS ( SELECT *  FROM  sys.columns 
                      WHERE  object_id = OBJECT_ID(N'[dbo].[" + tableName + "]') AND name = '" + colName + "') ALTER TABLE " + tableName + " ADD[" + colName + "] " + dataType + " NOT NULL DEFAULT " + defaultValue + "";
        }
    }
}
