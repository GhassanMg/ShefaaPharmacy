using DataLayer.Helper;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Tables
{
    public class TaxAccount
    {
        public TaxAccount()
        {
            try
            {
                if (UserLoggedIn.User != null)
                {
                    CreationBy = UserLoggedIn.User.Id;
                }
            }
            catch (Exception)
            {
                ;
            }
        }
        [Key]
        [DisplayName("المعرف")]
        public int Id { get; set; }
        [Browsable(false)]
        [DisplayName("تم انشاؤه من قبل")]
        public int CreationBy { get; set; }
        [DisplayName("اسم المستخدم")]
        public string username { get; set; }
        [DisplayName("كلمة المرور")]
        public string password { get; set; }
        [DisplayName("اسم الصيدلية")]
        public string facilityName { get; set; }
        [DisplayName("الرقم الضريبي")]
        public string taxNumber { set; get; }
        [Browsable(false)]
        [DisplayName("رمز التحقق الخاص")]
        public string Token { set; get; } = "";
    }
}
