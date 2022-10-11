using DataLayer.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.ViewModels
{
    public class AccountingReportForYearProfit
    {
        [Browsable(false)]
        public int AccountId { get; set; }
        [NotMapped]
        [DisplayName("الحساب")]
        public string AccountIdDescr
        {
            get
            {
                return DescriptionFK.GetAccountName(AccountId);
            }
            set
            {
                ;
            }
        }
        [DisplayName("إجمالي مدين")]
        public double Debit { get; set; }
        [DisplayName("إجمالي دائن")]
        public double Credit { get; set; }
    }
    public class AccountingReportForYearProfitDetail
    {
        [DisplayName("مجاميع مدين")]
        public double Debit { get; set; }
        [DisplayName("مجاميع دائن")]
        public double Credit { get; set; }
        [DisplayName("الفرق")]
        public double Total {
            get
            {
                return Debit - Credit;
            }
            set 
            {
                ; 
            } 
        }
    }
}
