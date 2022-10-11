using System.ComponentModel;

namespace DataLayer.ViewModels
{
    public class CompanyApiViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("اسم الشركة")]
        public string Name { get; set; }
        [DisplayName("استيراد")]
        public bool Checked { get; set; }
    }
}
