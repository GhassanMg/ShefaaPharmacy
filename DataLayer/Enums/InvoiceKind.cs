
using DataLayer.Helper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enums
{
    [TypeConverter(typeof(TranslateEnum))]
    public enum InvoiceKind
    {
        [Description("جميع الفواتير")]
        [Display(Name = "جميع الفواتير")]
        All = 0,
        [Description("بيع")]
        [Display(Name = "بيع")]
        Sell = 1,
        [Description("شراء")]
        [Display(Name = "شراء")]
        Buy = 2,
        [Description("مرتجع شراء")]
        [Display(Name = "مرتجع شراء")]
        ReturnBuy = 3,
        [Description("مرتجع مبيع")]
        [Display(Name = "مرتجع مبيع")]
        ReturnSell = 4,
        [Description("حذف فاتورة شراء")]
        [Display(Name = "حذف فاتورة شراء")]
        DeleteBuy = 5,
        [Description("حذف فاتورة مبيع")]
        [Display(Name = "حذف فاتورة مبيع")]
        DeleteSell = 6,
        [Description("بضاعة أول مدة")]
        [Display(Name = "بضاعة أول مدة")]
        GoodFirstTime = 7,
        [Description("حذف مرتجع شراء")]
        [Display(Name = "حذف مرتجع شراء")]
        DeleteReturnBuy = 8,
        [Description("حذف مرتجع مبيع")]
        [Display(Name = "حذف مرتجع مبيع")]
        DeleteReturnSell = 9,
        [Description("مواد منتهية الصلاحية")]
        [Display(Name = "مواد منتهية الصلاحية")]
        ExpiryArticles = 10,
        [Description("تعديل فاتورة شراء")]
        [Display(Name = "تعديل فاتورة شراء")]
        EditBuy = 11
    }
}
