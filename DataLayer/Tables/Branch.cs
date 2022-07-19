using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Tables
{
    public class Branch 
    {
        [Key]
        //[Browsable(false)]
        [DisplayName("معرف الفرع")]
        public int Id { get; set; }
        [DisplayName("تاريخ الإنشاء")]
        [ReadOnly(true)]
        public DateTime CreationDate { get; set; }
        [DisplayName("اسم الفرع")]
        public string Name { get; set; }
        #region Relation
        [Browsable(false)]
        public List<EntryMaster> EntryMasters { set; get; }
        [Browsable(false)]
        public List<BillMaster> BillMasters { set; get; }
        [Browsable(false)]
        public List<User> Users { get; set; }
        [Browsable(false)]
        public List<Store> Stores { get; set; }
        #endregion
    }
}
