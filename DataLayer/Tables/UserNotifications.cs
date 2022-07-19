using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Tables
{
    public class UserNotifications
    {
        public UserNotifications()
        {
            RemindMeDate = DateTime.Now.AddDays(1);
        }
        [Key]
        public int Id { get; set; }
        [DisplayName("الرسالة")]
        public string Message { get; set; }
        [DisplayName("التصنيف")]
        public string Category { get; set; }
        [DisplayName("التذكير لاحقاً")]
        public bool RemindMeLater { get; set; }
        [DisplayName("عدم التذكير لاحقاً")]
        public bool DontRemindMeLater { get; set; }
        [DisplayName("تاريخ التذكير القادم")]
        public DateTime RemindMeDate { get; set; }
        [DisplayName("تاريخ الإنشاء")]
        public DateTime CreationDate { get; set; }
    }
    public class SettingNotifications
    {
        [Key]
        public int Id { get; set; }
        public int DayCountForRemind { get; set; }
        public int DeleteAfterDay { get; set; }
    }
    public class ArticleNotification
    {
        [DisplayName("اسم الصنف")]
        public string Name { get; set; }
        [DisplayName("تاريخ الصلاحية")]
        public DateTime ExpiryDate { get; set; }
        [DisplayName("عدد القطع المتبقية")]
        public int ItemLeft { get; set; }
    }
}
