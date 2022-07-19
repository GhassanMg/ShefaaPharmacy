using DataLayer.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.Services
{
    public class YearService
    {
        public static int GetAvailableYear()
        {
            return ShefaaPharmacyDbContext.GetCurrentContext().Years.ToList().OrderByDescending(x => x.CreationDate).FirstOrDefault().Id;
        }
        public static int GetAvailableYearMobile(ShefaaPharmacyDbContext context)
        {
            return context.Years.ToList().OrderByDescending(x => x.CreationDate).FirstOrDefault().Id;
        }
        public static List<Year> GetYear()
        {
            return ShefaaPharmacyDbContext.GetCurrentContext().Years.ToList().OrderByDescending(x => x.CreationDate).ToList();
        }
    }
}
