using DataLayer;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.Notification;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShefaaPharmacy.Helper
{
    public class NotficationArticleWarning
    {
        public static void ArticleWarningMessagesToRemind()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<UserNotifications> userNotifications = context.UserNotifications.Where(x => x.RemindMeLater == true).ToList();
            if (userNotifications != null && userNotifications.Count > 0)
            {
                userNotifications = userNotifications.Where(x => x.RemindMeDate.ToString("ddMMyyyy") == DateTime.Now.ToString("ddMMyyyy")).ToList();
                if (userNotifications != null && userNotifications.Count > 0)
                {
                    NotificationForm notificationForm = new NotificationForm();
                    foreach (var item in userNotifications)
                    {
                        notificationForm.showAlert(item);
                    }
                }
            }
        }
        public static void ArticleExpiryDate()
        {
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetArticleInStore",
                                                null);
            List<ArticleExpiryDay> resultReport = DataBaseService.ConvertDataTable<ArticleExpiryDay>(result);
            if (resultReport != null)
            {
                NotificationForm notificationForm = new NotificationForm();
                notificationForm.showAlert(resultReport,NotificationForm.enmType.Info);
            }

        }
    }
}
