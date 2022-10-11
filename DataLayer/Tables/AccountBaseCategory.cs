using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Tables
{
    public class AccountBaseCategory
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("اسم النوع")]
        public string Name { get; set; }
        #region Relation
        [Browsable(false)]
        public IList<AccountCategory> AccountCategorys { set; get; }
        #endregion
    }
}
