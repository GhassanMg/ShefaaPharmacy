using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DTOs
{
    class TaxAccountDTOs
    {
        public int CreationBy { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string taxNumber { get; set; }
        public string Token { get; set; }
    }
}
