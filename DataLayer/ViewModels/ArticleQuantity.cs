using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.ViewModels
{
    public class ArticleQuantity
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public int UnitId { get; set; }
        public int Quantity { get; set; }
    }
}
