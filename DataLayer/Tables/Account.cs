using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class Account : BaseModel
    {
        [DisplayName("اسم الحساب")]
        public string Name { get; set; }
        [DisplayName("الاسم الثاني")]
        public string LastName { get; set; }
        [DisplayName("معلومات")]
        public string Description { get; set; }
        [DisplayName("رقم الهاتف")]
        public string Tel { get; set; }
        [DisplayName("الرقم 2")]
        public string Tel2 { get; set; }
        [DisplayName("العنوان")]
        public string Address { get; set; }
        [DisplayName("العنوان 2")]
        public string Address2 { get; set; }
        [DisplayName("رئيسي")]
        public bool General { get; set; }
        [NotMapped]
        [DisplayName("الحساب الرئيسي")]
        public string AccountGeneralIdDescr { get { return DescriptionFK.GetAccountName(AccountGeneralId); } set {; } }
        [NotMapped]
        [DisplayName("التصنيف")]
        public string CategoryIdDescr { get { return DescriptionFK.GetAccountBaseCategoryName(CategoryId); } set {; } }
        public int CategoryId { get; set; }
        public int? AccountGeneralId { get; set; }
        [DisplayName("طبيعة الحساب")]
        public AccountState AccountState { get; set; } = AccountState.Both;
        #region Relation
        [ForeignKey("CategoryId")]
        [Browsable(false)]
        public AccountBaseCategory AccountBaseCategory { get; set; }
        [Browsable(false)]
        [ForeignKey("AccountGeneralId")]
        public Account AccountGeneral { get; set; }
        [Browsable(false)]
        public IList<EntryMaster> EntryMasters { set; get; }
        [Browsable(false)]
        public IList<EntryDetail> EntryDetails { get; set; }
        [Browsable(false)]
        public IList<BillMaster> BillMasters { get; set; }
        [Browsable(false)]
        [NotMapped]
        public IList<UserPermissions> UserPermissions { get; set; }
        #endregion
    }
}
