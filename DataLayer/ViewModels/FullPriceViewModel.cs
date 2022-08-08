using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataLayer.ViewModels
{
    public class FullPriceViewModel
    {
        [DisplayName("القيمة الكلية")]
        public double FullPrice
        {
            get; 
            set ; 
        }
    }
}
