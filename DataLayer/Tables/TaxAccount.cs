using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Tables
{
    public class TaxAccount 
    {
        [Key]
        [DisplayName("المعرف")]
        public int Id { get; set; }
        [DisplayName("اسم المستخدم")]
        public string username { get; set; }
        //[DataType(DataType.Password)]
        [DisplayName("كلمة المرور")]
        public string password { get; set; }
        [DisplayName("الرقم الضريبي")]
        public string taxNumber { set; get; } = "";
    }
}
