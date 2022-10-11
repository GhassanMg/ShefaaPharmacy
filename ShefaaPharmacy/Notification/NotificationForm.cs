using DataLayer;
using DataLayer.Tables;
using DataLayer.ViewModels;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Notification
{
    public partial class NotificationForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        UserNotifications notificationForm;
        public NotificationForm()
        {
            InitializeComponent();
        }
        public enum enmAction
        {
            wait,
            start,
            close
        }
        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        private enmAction action;
        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }
        public void showAlert(string msg, enmType type)
        {
            this.StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
        public void showAlert(List<ArticleExpiryDay> articleExpiryDays, enmType type)
        {
            this.StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }

        private void dgvmaster_BindingContextChanged(object sender, EventArgs e)
        {
            dgvmaster.Refresh();
            dgvmaster.Columns["Id"].Visible = false;
            dgvmaster.Columns["RemindMeLater"].Visible = false;
            dgvmaster.Columns["DontRemindMeLater"].Visible = false;
            dgvmaster.Columns["RemindMeDate"].Visible = false;
            dgvmaster.Columns["CreationDate"].Visible = false;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                notificationForm.RemindMeLater = true;
                notificationForm.RemindMeDate = DateTime.Now.AddDays(context.SettingNotifications.FirstOrDefault().DayCountForRemind);
                context.UserNotifications.Update(notificationForm);
                context.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                context.UserNotifications.Remove(notificationForm);
                context.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                Close();
            }
        }

        public void showAlert(UserNotifications notificationForm, bool remindMe = false)
        {
            this.StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
            bsMaster.DataSource = notificationForm;
            this.notificationForm = notificationForm;
            dgvmaster.AutoGenerateColumns = true;
            dgvmaster.AllowUserToAddRows = false;
            dgvmaster.AllowUserToDeleteRows = false;
            dgvmaster.ReadOnly = true;
            btnRemindMe.Enabled = remindMe;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}