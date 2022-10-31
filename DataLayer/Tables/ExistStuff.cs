using DataLayer.Helper;
using System.ComponentModel;

namespace DataLayer.Tables
{
    public class ExistStuff : BaseModel
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
