using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Enums
{
    public enum PayingCashState
    {
        [Description("مقبوضات الصندوق")]
        [Display(Name = "مقبوضات الصندوق")]
        InComing,
        [Description("مدفوعات الصندوق")]
        [Display(Name = "مدفوعات الصندوق")]
        OutComing
    }
}
