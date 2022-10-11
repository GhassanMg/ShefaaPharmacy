using DataLayer.Enums;
using DataLayer.Tables;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataLayer.Helper
{
    public class BaseModel
    {
        public BaseModel()
        {
            try
            {
                if (UserLoggedIn.User != null)
                {
                    CreationBy = UserLoggedIn.User.Id;
                }
                CreationDate = DateTime.Now;
            }
            catch (Exception)
            {
                ;
            }
        }
        public ShefaaPharmacyDbContext context = null;
        [Key]
        //[Browsable(false)]
        [DisplayName("المعرف")]
        public int Id { get; set; }
        [Browsable(false)]
        public int CreationBy { get; set; }
        [NotMapped]
        [DisplayName("أنشئت من قبل")]
        [ReadOnly(true)]
        public string CreationByDescr
        { 
            //get { return ShefaaPharmacyDbContext.GetCurrentContext().Users.FirstOrDefault(x=>x.Id==this.CreationBy).Name; }
            get { return context == null ? ShefaaPharmacyDbContext.GetCurrentContext().Users.FirstOrDefault(x => x.Id == this.CreationBy).Name : context.Users.FirstOrDefault(x => x.Id == this.CreationBy).Name; }
            set {; }
        }
        [DisplayName("تاريخ الإنشاء")]
        [ReadOnly(true)]
        public DateTime CreationDate { get; set; }
        [ForeignKey("CreationBy")]
        [Browsable(false)]
        public virtual User User { get; set; }
        [NotMapped]
        [Browsable(false)]
        public FormOperation FormOperation { get; set; }
    }
}
