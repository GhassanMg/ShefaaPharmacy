using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
