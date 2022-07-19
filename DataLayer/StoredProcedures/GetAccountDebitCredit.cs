using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.StoredProcedures
{
    public class GetAccountDebitCredit
    {
        [Browsable(false)]
        public int AccountId { get; set; }
        [DisplayName("الحساب")]
        [NotMapped]
        public string AccountIdDescr
        {
            get
            {
                return DescriptionFK.GetAccountName(AccountId);
            }
            set {; }
        }
        [DisplayName("مجموع المدين")]
        public double Debit { get; set; }
        [DisplayName("مجموع الدائن")]
        public double Credit { get; set; }
        [DisplayName("الفرق")]
        public double Sum
        {
            get
            {
                return Debit - Credit;
            }
        }
    }
}
