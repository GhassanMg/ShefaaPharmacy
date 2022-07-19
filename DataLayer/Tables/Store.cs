using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Tables
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("اسم المستودع")]
        public string Name { get; set; }
        public int BranchId { get; set; }
        [NotMapped]
        [DisplayName("الفرع التابع له")]
        public string BranchIdDescr { get { return DescriptionFK.GetBranchName(BranchId); } set {; } }
        [ForeignKey("BranchId ")]
        public Branch Branch { get; set; }
    }
}
