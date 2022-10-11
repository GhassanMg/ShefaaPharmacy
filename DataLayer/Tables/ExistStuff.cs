using DataLayer.Helper;
using System.ComponentModel;

namespace DataLayer.Tables
{
    public class ExistStuff : BaseModel
    {
        //[ExistStuff] ([id][int] IDENTITY(1,1) NOT NULL,[name] [nvarchar](600) NULL,[count] [int] NULL,[price] [int] NULL,[description] [nvarchar](600) NULL) ON [PRIMARY];";
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
