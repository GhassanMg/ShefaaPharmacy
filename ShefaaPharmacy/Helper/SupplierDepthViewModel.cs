using DataLayer.Services;
using System.ComponentModel;

namespace ShefaaPharmacy.Helper
{
    public class SupplierDepthViewModel
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
        
        //[DisplayName("مدين")]
        //public double Debit { get; set; }
        
        [DisplayName("المبلغ")]
        public double Credit { get; set; }

    }
}
