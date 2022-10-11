using DataLayer.Helper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enums
{
    [TypeConverter(typeof(TranslateEnum))]
    public enum PaymentMethod
    {
        [Display(Name = "نقداً")]
        [Description("نقداً")]
        Cash,

        [Display(Name ="دين")]
        [Description("دين")]
        Debit

    }
}
