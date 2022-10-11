using System.ComponentModel;

namespace DataLayer.ViewModels
{
    public class GetProfitFromDateToDateViewModel
    {
        [DisplayName("الحساب")]
        public string Account { get; set; }
        [Browsable(false)]
        [DisplayName("مدين")]
        public double Debit { get; set; }
        [Browsable(false)]
        [DisplayName("دائن")]
        public double Credit { get; set; }
        [DisplayName("الصافي")]
        public double Total { get; set; }
    }
}
