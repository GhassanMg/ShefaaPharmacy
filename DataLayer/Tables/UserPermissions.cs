using DataLayer.Enums;
using DataLayer.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class UserPermissions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CashAccountId { get; set; }
        [Required]
        public int BuyAccountId { get; set; }
        [Required]
        public int SellAccountId { get; set; }
        //[Required]
        //public int ReturnBuyAccountId { get; set; }
        //[Required]
        //public int ReturnSellAccountId { get; set; }
        [Required]
        public int CustomerAccountId { get; set; }
        public bool CanSellBill { get; set; }
        public bool CanBuyBill { get; set; }
        public bool CanInsertEntry { get; set; }
        public bool CanDeleteEntry { get; set; }
        public bool CanDeleteBill { get; set; }
        [DisplayName("اسم المستخدم")]
        [NotMapped]
        public string UserIdDescr
        {
            get
            {
                return DescriptionFK.GetUserName(UserId);
            }
            set {; }
        }
        [DisplayName("حساب الصندوق")]
        [NotMapped]
        public string CashAccountIdDescr
        {
            get
            {
                return DescriptionFK.GetAccountName(CashAccountId);
            }
            set {; }
        }
        [DisplayName("حساب المشتريات")]
        [NotMapped]
        public string BuyAccountIdDescr
        {
            get
            {
                return DescriptionFK.GetAccountName(BuyAccountId);
            }
            set {; }
        }
        [DisplayName("حساب المبيعات")]
        [NotMapped]
        public string SellAccountIdDescr
        {
            get
            {
                return DescriptionFK.GetAccountName(SellAccountId);
            }
            set {; }
        }
        //[DisplayName("حساب مردودات المشتريات")]
        //[NotMapped]
        //public string ReturnBuyAccountIdDescr
        //{
        //    get
        //    {
        //        return DescriptionFK.GetAccountName(ReturnBuyAccountId);
        //    }
        //    set {; }
        //}
        //[DisplayName("حساب مردودات المبيعات")]
        //[NotMapped]
        //public string ReturnSellAccountIdDescr
        //{
        //    get
        //    {
        //        return DescriptionFK.GetAccountName(ReturnSellAccountId);
        //    }
        //    set {; }
        //}
        [DisplayName("حساب الزبائن")]
        [NotMapped]
        public string CustomerAccountIdDescr
        {
            get
            {
                return DescriptionFK.GetAccountName(CustomerAccountId);
            }
            set {; }
        }
        [Browsable(false)]
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Browsable(false)]
        [ForeignKey("CashAccountId")]
        public Account CashAccount { get; set; }

        [Browsable(false)]
        [ForeignKey("BuyAccountId")]
        public Account BuyAccount { get; set; }

        [Browsable(false)]
        [ForeignKey("SellAccountId")]
        public Account SellAccount { get; set; }
        [ForeignKey("CustomerAccountId")]
        public Account CustomerAccount { get; set; }
        [DisplayName("واجهة البرنامج")]
        public UserDesktopUI UserDesktopUI { get; set; }
    }
}
