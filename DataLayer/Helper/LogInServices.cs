using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataLayer.Helper
{
    public class LogInServices
    {
        public User Login(string userName, string password,string userNKey="")
        {
            try
            {
                ShefaaPharmacyDbContext db = ShefaaPharmacyDbContext.GetCurrentContext();
                User tmp = db.Users.Where(x => (x.Name == userName) && (x.Password == password)).FirstOrDefault();
                if (tmp == null)
                    return null;
                Connection connection = new Connection();
                connection.ComputerName = Environment.MachineName;
                connection.NKey = userNKey;
                connection.HostId = db.Connections.FromSqlRaw("SELECT NEWID() AS Id,HOST_ID() AS HostId,UserId=1,'' AS ComputerName").FirstOrDefault().HostId;
                connection.UserId = tmp.Id;
                db.Connections.Add(connection);
                db.SaveChanges();
                UserLoggedIn.User = tmp;
                UserLoggedIn.User.UserPermissions = db.UserPermissions.FirstOrDefault(x => x.UserId == tmp.Id);
                UserLoggedIn.Connection = connection;
                UserLoggedIn.Connection.DataBaseName = db.Database.GetDbConnection().Database;
                return tmp;
            }
            catch (Exception ex)
            {
                return null; 
            }
        }
        public User LogInApi(ShefaaPharmacyDbContext db,string userName, string password)
        {
            User tmp = db.Users.Where(x => (x.Name == userName) && (x.Password == password)).FirstOrDefault();
            if (tmp == null)
                return null;
            Connection connection = new Connection();
            connection.ComputerName = Environment.MachineName;
            connection.HostId = db.Connections.FromSqlRaw("SELECT NEWID() AS Id,HOST_ID() AS HostId,UserId=1,'' AS ComputerName").FirstOrDefault().HostId;
            connection.UserId = tmp.Id;
            db.Connections.Add(connection);
            db.SaveChanges();
            UserLoggedIn.User = tmp;
            UserLoggedIn.User.UserPermissions = db.UserPermissions.FirstOrDefault(x => x.UserId == tmp.Id);
            UserLoggedIn.Connection = connection;
            return tmp;
        }
        public User LoginForMobile(ShefaaPharmacyDbContext context, string userName, string password)
        {
            try
            {
                User tmp = context.Users.Where(x => (x.Name == userName) && (x.Password == password)).FirstOrDefault();
                tmp.UserPermissions = context.UserPermissions.Where(x => x.UserId == tmp.Id).FirstOrDefault();
                if (tmp == null)
                    return null;
                return tmp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
