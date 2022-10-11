using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
