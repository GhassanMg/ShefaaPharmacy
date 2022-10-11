using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class Connection
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }
        [DisplayName("معرف الجهاز")]
        public string HostId { get; set; }
        public int UserId { get; set; }
        [DisplayName("أسم الجهاز")]
        public string ComputerName { get; set; }
        [DisplayName("أسم المستخدم")]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [NotMapped]
        public string NKey { set; get; }
        [NotMapped]
        public string DataBaseName { set; get; }
    }
}
