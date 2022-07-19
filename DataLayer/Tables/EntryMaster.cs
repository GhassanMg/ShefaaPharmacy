
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Tables
{
    public class EntryMaster : BaseModel
    {
        public delegate void UpdateForm();
        public event UpdateForm onUpdateForm;
        public EntryMaster()
        {
            if (UserLoggedIn.User != null)
            {
                YearId = YearService.GetAvailableYear();
            }
        }
        [DisplayName("نوع العملية")]
        public KindOperation KindOperation { set; get; }
        [Browsable(false)]
        public int RelatedDocument { set; get; }
        [DisplayName("الفاتورة المرتبطة")]
        [NotMapped]
        public string RelatedDocumentDescr
        {
            get
            {
                if (RelatedDocument == 0)
                {
                    return "لا يوجد فاتورة مرتبطة";
                }
                else
                {
                    return "فاتورة رقم  " + RelatedDocument;
                }
            }
        }
        [DisplayName("مجموع المدين")]
        public double TotalDebit { set; get; }
        [DisplayName("مجموع الدائن")]
        public double TotalCredit { set; get; }
        [NotMapped]
        [DisplayName("الفرق")]
        public double Balance { get; set; }
        public void CalcTotal()
        {
            if (this.EntryDetails == null)
            {
                return;
            }
            double debit = 0;
            double credit = 0;
            ((List<EntryDetail>)this.EntryDetails).ForEach(x => debit += x.Debit);
            ((List<EntryDetail>)this.EntryDetails).ForEach(x => credit += x.Credit);
            TotalCredit = credit;
            TotalDebit = debit;
            Balance = TotalDebit - TotalCredit;
            onUpdateForm?.Invoke();
        }
        #region Relation
        [Browsable(false)]
        public int YearId { get; set; }
        [Browsable(false)]
        [ForeignKey("YearId")]
        public Year Year { get; set; }
        [Browsable(false)]
        public List<EntryDetail> EntryDetails { get; set; }
        #endregion
        #region ViewModel
        [NotMapped]
        [Browsable(false)]
        public int AccountDetail { get; set; }
        [NotMapped]
        [DisplayName("الحساب المدين")]
        public string AccountIdDebitDescr
        {
            get
            {
                if (Id != 0)
                {
                    return DescriptionFK.GetAccountDebitForEntryMaster(Id);
                }
                return "";
            }
            set
            {
                ;
            }
        }
        [NotMapped]
        [DisplayName("الحساب الدائن")]
        public string AccountIdCreditDescr
        {
            get
            {
                if (Id != 0)
                {
                    return DescriptionFK.GetAccountCreditForEntryMaster(Id);
                }
                return "";
            }
            set
            {
                ;
            }
        }
        #endregion
    }
}
