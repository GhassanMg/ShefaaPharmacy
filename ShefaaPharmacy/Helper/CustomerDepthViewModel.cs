using DataLayer.Services;
using System.ComponentModel;

namespace ShefaaPharmacy.Helper
{
    public class CustomerDepthViewModel
    {
        [Browsable(false)]
        public int AccountId { get; set; }
        [DisplayName("الحساب")]
        public string AccountIdDescr
        {
            get
            {
                return DescriptionFK.GetAccountName(AccountId);
            }
            set
            {
                int id = DescriptionFK.GetAccountId(value);
                if (id == 0)
                {
                    return;
                }
                else
                {
                    AccountId = id;
                }
            }
        }
        //[DisplayName("المبلغ")]
        //public double Cash { get; set; }
        //[Browsable(false)]
        [DisplayName("المبلغ")]
        public double Debit { get; set; }
        //[Browsable(false)]
        //[DisplayName("دائن")]
        //public double Credit { get; set; }
    }
}
