using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
