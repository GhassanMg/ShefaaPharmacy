﻿using System.ComponentModel;

namespace ShefaaPharmacy.Helper
{
    public class BankDepthViewModel
    {
        //[Browsable(false)]
        //public int AccountId { get; set; }
        //[DisplayName("الحساب")]
        //public string AccountIdDescr
        //{
        //    get
        //    {
        //        return DescriptionFK.GetAccountName(AccountId);
        //    }
        //    set
        //    {
        //        int id = DescriptionFK.GetAccountId(value);
        //        if (id == 0)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            AccountId = id;
        //        }
        //    }
        //}

        //[DisplayName("المبلغ")]
        //public double Cash { get; set; }
        //[Browsable(false)]
        [DisplayName("الرصيد")]
        public double Debit { get; set; }
        //[Browsable(false)]
        //[DisplayName("دائن")]
        //public double Credit { get; set; }
    }
}
