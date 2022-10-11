using DataLayer.Helper;
using DataLayer.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class AccountCategory : BaseModel
    {
        [DisplayName("الاسم")]
        public string Name { get; set; }
        public int AccountBaseCategoryId { get; set; }
        [DisplayName("تصنيف الحساب")]
        [NotMapped]
        public string AccountBaseCategoryIdDescr 
        { 
            set 
            {
                ;
            }
            get 
            { 
                return DescriptionFK.GetAccountBaseCategoryName(this.AccountBaseCategoryId); 
            } 
        }
        #region Relation
        [ForeignKey("AccountBaseCategoryId")]
        [Browsable(false)]
        public AccountBaseCategory AccountBaseCategory { set; get; }
        public IList<Account> Accounts { set; get; }
        #endregion
    }
}
