using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels
{
    public class ApiResponseViewModel<T>
    {
        public string message { get; set; }
        public bool success { get; set; }
        public int status_code { get; set; }
        public List<T> data { get; set; }

    }
}
