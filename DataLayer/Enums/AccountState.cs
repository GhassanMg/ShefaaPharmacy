using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enums
{
    public enum AccountState
    {
        [Description("مدين")]
        [Display(Name = "مدين")]
        Debit,
        [Description("دائن")]
        [Display(Name = "دائن")]
        Credit,
        [Description("مدين ودائن")]
        [Display(Name = "مدين ودائن")]
        Both
    }
}
