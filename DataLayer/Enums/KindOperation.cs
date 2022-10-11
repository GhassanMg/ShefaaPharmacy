using DataLayer.Helper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enums
{
    [TypeConverter(typeof(TranslateEnum))]
    public enum KindOperation
    {
        [Description("سند قيد")]
        [Display(Name = "سند قيد")]
        Entry = 0,
        [Description("فاتورة مبيع")]
        [Display(Name = "فاتورة مبيع")]
        Sell = 1,
        [Description("فاتورة شراء")]
        [Display(Name = "فاتورة شراء")]
        Buy = 2,
        [Description("مرتجع")]
        [Display(Name = "مرتجع")]
        Return = 3,
        [Description("دين")]
        [Display(Name = "دين")]
        Debit = 4,
        [Description("دفعة")]
        [Display(Name = "دفعة")]
        Payment = 5,
        [Description("رصيد أول مدة")]
        [Display(Name = ("رصيد أول مدة"))]
        GoodFirstTime = 6,
        [Description("مواد منتهية الصلاحية")]
        [Display(Name = "مواد منتهية الصلاحية")]
        Expired = 7,
        [Description("ديون الموردين")]
        [Display(Name = "ديون الموردين")]
        SupplierDepth = 8,
        [Description("ديون الزبائن")]
        [Display(Name = "ديون الزبائن")]
        CustomerDepth = 9,
        //[Description("المجموع")]
        //[Display(Name = "المجموع")]
        //TotalFirstTime = 10
    }
}
