using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLayer.ViewModels
{
    public class ExistStuffViewModel
    {
       
        [DisplayName("المادة")]
        public string Name { get; set; }
        [DisplayName("العدد")]
        public double Count { get; set; }
        [DisplayName("السعر")]
        public double Price { get; set; }
        [DisplayName("الوصف")]
        public string Description { get; set; }

    }
}
