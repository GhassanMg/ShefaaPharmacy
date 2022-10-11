using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using System;

namespace DataLayer.Tables
{
    public class UserParameters : BaseModel
    {
        public UserParameters()
        {
            FromDate = ConstantDataBase.FirstDayTime;
            ToDate = ConstantDataBase.LastDayTime;
            UserId = UserLoggedIn.User.Id;
            BranchId = UserLoggedIn.User.BranchId;
            YearId = YearService.GetAvailableYear();
        }
        public int UserId { get; set; }
        public string UserIdDescr
        {
            get
            {
                return DescriptionFK.GetUserName(UserId);
            }
            set {; }
        }
        public int YearId { get; set; }
        public string YearIdDescr
        {
            get
            {
                return DescriptionFK.GetYearName(YearId);
            }
            set {; }
        }
        public int BranchId { get; set; }
        public string BranchIdDescr
        {
            get
            {
                return DescriptionFK.GetBranchName(BranchId);
            }
            set {; }
        }
        public int Acc_AccountId { get; set; }
        public string Acc_AccountIdDescr
        {
            get
            {
                return DescriptionFK.GetAccountName(Acc_AccountId);
            }
            set {; }
        }
        public int ArticleId { get; set; }
        public string ArticleIdDescr
        {
            get
            {
                return DescriptionFK.GetArticaleName(ArticleId);
            }
            set {; }
        }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        #region Bill
        public InvoiceKind InvoiceKind { get; set; }
        public int InvoiceId { get; set; }
        #endregion

    }
}
