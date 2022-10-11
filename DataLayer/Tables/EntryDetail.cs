using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class EntryDetail : BaseModel
    {
        public EntryDetail()
        {

        }
        public EntryDetail(EntryMaster entryMaster)
        {
            if (entryMaster != null)
            {
                EntryMaster = entryMaster;
                KindOperation = entryMaster.KindOperation;
            }

        }
        [DisplayName("نوع الوثيقة")]
        public KindOperation KindOperation { set; get; }
        [NotMapped]
        [Browsable(false)]
        double debit;
        [DisplayName("مدين")]
        public double Debit
        {
            get { return debit; }
            set
            {
                debit = value;
                if (EntryMaster != null)
                {
                    EntryMaster.CalcTotal();
                }
            }
        }
        [NotMapped]
        [Browsable(false)]
        double credit;
        [DisplayName("دائن")]
        public double Credit
        {
            get { return credit; }
            set
            {
                credit = value;
                if (EntryMaster != null)
                {
                    EntryMaster.CalcTotal();
                }
            }
        }
        [DisplayName("ملاحظة")]
        public string Description { get; set; }
        [DisplayName("الحساب")]
        [NotMapped]
        public string AccountIdDescr
        {
            get
            {
                return DescriptionFK.GetAccountName(AccountId);
            }
            set
            {
                int id = DescriptionFK.GetAccountId(value);
                if (id == 0)
                {
                    return;
                }
                else
                {
                    AccountId = id;
                }
            }
        }
        #region Relation
        [Browsable(false)]
        public int EntryMasterId { get; set; }
        [Browsable(false)]
        public int AccountId { get; set; }
        [Browsable(false)]
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        [Browsable(false)]
        [ForeignKey("EntryMasterId")]
        public EntryMaster EntryMaster { get; set; }
        #endregion
    }
}
