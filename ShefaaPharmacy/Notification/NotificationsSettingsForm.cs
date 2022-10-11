using DataLayer;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Linq;

namespace ShefaaPharmacy.Notification
{
    public partial class NotificationsSettingsForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        SettingNotifications settingNotifications;
        public NotificationsSettingsForm()
        {
            InitializeComponent();
        }

        private void NotificationsSettingsForm_Load(object sender, EventArgs e)
        {
            settingNotifications = ShefaaPharmacyDbContext.GetCurrentContext().SettingNotifications.ToList().FirstOrDefault();
            if (settingNotifications == null)
                settingNotifications = new SettingNotifications();
            bsNotification.DataSource = settingNotifications;
            tbRmindAfterDay.DataBindings.Add("text", bsNotification, "DayCountForRemind");
            tbDeleteAfterDay.DataBindings.Add("text", bsNotification, "DeleteAfterDay");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                bool New = false;
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var result = context.SettingNotifications.AsNoTracking().ToList();
                if (result.Count > 0)
                {
                    context.SettingNotifications.Update(bsNotification.DataSource as SettingNotifications);
                }
                else
                    context.SettingNotifications.Add(bsNotification.DataSource as SettingNotifications);
                context.SaveChanges();
                _MessageBoxDialog.Show("تم حفظ الإشعارات", MessageBoxState.Done);
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }

        }
    }
}
