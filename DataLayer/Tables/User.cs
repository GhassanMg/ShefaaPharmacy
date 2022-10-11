using DataLayer.Enums;
using DataLayer.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class User
    {
        [Key]
        [DisplayName("معرف المستخدم")]
        public int Id { get; set; }
        [DisplayName("اسم المستخدم")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("كلمة المرور")]
        public string Password { get; set; }
        [DisplayName("المنصب")]
        public Position Position { get; set; }
        [DisplayName("مجمد")]
        public bool Freez { get; set; }
        [DisplayName("الفرع")]
        [NotMapped]
        public string BranchIdDescr { get { return DescriptionFK.GetBranchName(BranchId); } set {; } }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        [Browsable(false)]
        public Branch Branch { get; set; }
        [DisplayName("المستودع")]
        [NotMapped]
        public string StoreIdDescr 
        {
            get { return DescriptionFK.GetStoreName(StoreId); }
            set {; } 
        }
        public int StoreId { get; set; }
        [ForeignKey("StoreId")]
        [Browsable(false)]
        public Store Store { get; set; }
        public UserPermissions UserPermissions { get; set; }
    }
}
