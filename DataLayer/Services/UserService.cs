using DataLayer.Tables;
using System.Linq;

namespace DataLayer.Services
{
    public class UserService
    {
        public static Branch GetBranch(int userId)
        {
            var contect = ShefaaPharmacyDbContext.GetCurrentContext();
            var result = contect.Branches.Where(x => x.Id == contect.Users.FirstOrDefault(y => y.Id == userId).BranchId).FirstOrDefault();
            return result;
        }
    }
}
