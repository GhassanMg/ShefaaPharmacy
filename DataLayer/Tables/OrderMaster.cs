using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class OrderMaster : BaseModel
    {
        [DisplayName("حالة الطلبية")]
        public OrderState OrderState { get; set; }
        // Order Form Company
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [NotMapped]
        [DisplayName("شركة الأدوية")]
        public string CompanyIdDescr
        {
            set {; }
            get
            {
                return DescriptionFK.GetCompanyName(CompanyId);
            }
        }
        public List<OrderDetail> Details { set; get; }
    }
}
