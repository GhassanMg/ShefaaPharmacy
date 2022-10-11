using DataLayer.Tables;
using DataLayer.Helper;

namespace ShefaaPharmacy.Helper
{
    public class Login
    {
        private static Login login;
        private bool LoggedIn { get; set; }
        private User _CurrentUser { get; set; }
        public User CurrentUser { get { return _CurrentUser; } }
        public bool IsLoggeIn { get { return LoggedIn; } }
        public static Login GetLogin()
        {
            return login ?? (login = new Login());
        }
        private Login()
        {
            LoggedIn = false;
        }
        public bool TryLogin(string userName, string password)
        {
            LogInServices logInServices = new LogInServices();
            #region tryGetNkey
            string s = RDSFECXA__WEWDSA.GetNKey();
            #endregion
            User tmp = logInServices.Login(userName,password,s);
            if (tmp == null)
            {
                return LoggedIn = false;
            }
            else
            {
                //ImportantData.GetImportantData(ShefaaPharmacyDbContext.GetCurrentContext());
                return LoggedIn = true;
            }
        }
        public void Logout()
        {
            if (LoggedIn)
            {
                //ShefaaPharmacyDbContext db = ShefaaPharmacyDbContext.GetCurrentContext();
                //db.Connections.Remove(UserLoggedIn.Connection);
                //db.SaveChanges();
                //LoggedIn = false;
            }
        }
    }
}
