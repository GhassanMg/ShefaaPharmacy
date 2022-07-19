using DataLayer.Helper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enums
{
    [TypeConverter(typeof(TranslateEnum))]
    public enum OrderState
    {
        [Display(Name = "الكل")]
        [Description("الكل")]
        All,
        [Display(Name = "ألغيت")]
        [Description("ألغيت")]
        Canceled,
        [Display(Name = "تمت")]
        [Description("تمت")]
        Done,
        [Display(Name = "موقفة مؤقتاً")]
        [Description("موقفة مؤقتاً")]
        paused,
        [Display(Name = "جارية")]
        [Description("جارية")]
        Running
    }

}
