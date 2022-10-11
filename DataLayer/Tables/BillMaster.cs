using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Tables
{
    public class BillMaster : BaseModel
    {
        /// <summary>
        /// onUpdateForm?.Invoke(); 
        /// تستخدم لتعبئة الحقول في الواجهة
        /// </summary>
        public delegate void UpdateForm();
        public event UpdateForm onUpdateForm;
        public BillMaster()
        {
            if (UserLoggedIn.User != null)
            {
                YearId = YearService.GetAvailableYear();
                BranchId = UserLoggedIn.User.BranchId;
                StoreId = UserLoggedIn.User.StoreId;
            }
        }
        /// <summary>
        /// نوع الفاتورة {Buy , Sell }
        /// </summary>
        [DisplayName("نوع الفاتورة ")]
        public InvoiceKind InvoiceKind { set; get; }
        [NotMapped]
        [Browsable(false)]
        public PaymentMethod paymentMethod;
        /// <summary>
        /// طريفة الدفع 
        /// {نقداً أو بالتقسيط}
        /// </summary>
        [DisplayName("طريقة الدفع ")]
        public PaymentMethod PaymentMethod
        {
            set
            {
                paymentMethod = value;
            }
            get
            {
                return paymentMethod;
            }
        }
        [DisplayName("أنشئت من قبل")]
        public string CreatedBy { get; set; }
        /// <summary>
        /// إجمالي الفاتورة
        /// </summary>
        [DisplayName("إجمالي الفاتورة")]
        public double TotalPrice { set; get; } //{ get { return; } set { onUpdateForm?.Invoke(); } }
        /// <summary>
        /// إجمالي القطع
        /// </summary>
        [DisplayName("إجمالي القطع")]
        public double TotalItem { get; set; }
        [NotMapped]
        [Browsable(false)]
        public double payment;
        /// <summary>
        /// المبلغ المدفوع
        /// </summary>
        [DisplayName("المبلغ المدفوع")]
        public double Payment
        {
            get
            {
                return payment;
            }
            set
            {
                payment = value;
            }
        }
        /// <summary>
        ///  المبلغ المتبقي
        /// </summary>
        [DisplayName("المبلغ المتبقي")]
        public double RemainingAmount { get; set; }
        //                                                =================================================
        //public ShefaaPharmacyDbContext context
        //{
        //    set
        //    {
        //        context = value;

        //    }
        //}
        //                                                ================================================
        //[NotMapped]
        //[DisplayName("اسم الحساب")]
        //public string AccountIdDescr
        //{
        //    get
        //    {
        //        return DescriptionFK.GetAccountName(AccountId);
        //    }
        //    set
        //    {
        //        AccountId = DescriptionFK.GetAccountId(value);
        //        onUpdateForm?.Invoke();
        //    }
        //}
        [NotMapped]
        [DisplayName("اسم الحساب")]
        public string AccountIdDescr
        {
            get
            {
                return context == null ? DescriptionFK.GetAccountName(AccountId) : DescriptionFK.GetAccountNameMobile(context, AccountId);
            }
            set
            {
                AccountId = context == null ? DescriptionFK.GetAccountId(value) : DescriptionFK.GetAccountIdMobile(context, value);
                onUpdateForm?.Invoke();
            }
        }
        [NotMapped]
        [Browsable(false)]
        public double discount;
        [DisplayName("الحسم")]
        public double Discount
        {
            get
            {
                return discount;
            }
            set
            {
                if (Double.IsNaN(value) || Double.IsInfinity(value) || Double.IsPositiveInfinity(value) || Double.IsNegativeInfinity(value))
                    discount = 0;
                else
                    discount = value;
            }
        }
        [Browsable(false)]
        public bool IsReturned { get; set; }
        [Browsable(false)]
        public int ReturnTo { get; set; }
        [Browsable(false)]
        public DateTime ReturnedTime { get; set; }
        /// <summary>
        ///  الفرع الذي قام بالفاتورة
        /// </summary>
        [Browsable(false)]
        public int BranchId { get; set; }
        /// <summary>
        /// السنة المالية
        /// </summary>
        [Browsable(false)]
        public int YearId { get; set; }
        /// <summary>
        /// المستودع
        /// </summary>
        [Browsable(false)]
        public int StoreId { get; set; }
        /// <summary>
        /// الحساب
        /// </summary>
        [Browsable(false)]
        public int AccountId { get; set; }
        #region Relation Objects
        [ForeignKey("BranchId")]
        [Browsable(false)]
        public Branch Branch { get; set; }
        [ForeignKey("YearId")]
        [Browsable(false)]
        public Year Year { get; set; }
        [ForeignKey("StoreId")]
        [Browsable(false)]
        public Store Store { get; set; }
        [ForeignKey("AccountId")]
        [Browsable(false)]
        public Account Account { get; set; }
        [Browsable(false)]
        public IList<BillDetail> BillDetails { get; set; }
        #endregion
        #region Methods
        public void CalcTotal()
        {
            if (this.BillDetails == null)
            {
                return;
            }
            double total = 0;
            int totalItem = 0;
            double discount = 0;
            ((List<BillDetail>)this.BillDetails).ForEach(x => total += x.TotalPrice);
            ((List<BillDetail>)this.BillDetails).ForEach(x => totalItem += x.Quantity);
            //((List<BillDetail>)this.BillDetails).ForEach(x => discount += x.Discount);
            TotalPrice = total;
            TotalItem = totalItem;
            //Payment = discount;
            if (PaymentMethod == PaymentMethod.Cash)
            {
                if (Payment <= TotalPrice)
                    Payment = TotalPrice - Discount;
            }
            else
            {
                if (Payment != 0)
                {
                    RemainingAmount = TotalPrice - Payment - Discount;
                }
                else
                {
                    RemainingAmount = TotalPrice;
                }
            }
            if (Discount > 0)
                if (PaymentMethod == PaymentMethod.Cash) Payment = TotalPrice - Discount;
            //else Payment = payment - Discount;

            onUpdateForm?.Invoke();
        }
        public void CalcTotalMobile()
        {
            if (this.BillDetails == null)
            {
                return;
            }
            double total = 0;
            int totalItem = 0;
            ((List<BillDetail>)this.BillDetails).ForEach(x => total += x.TotalPrice);
            ((List<BillDetail>)this.BillDetails).ForEach(x => totalItem += x.Quantity);
            TotalPrice = total;
            //TotalItem = totalItem-discount;
            //TotalPrice = total - (total * discount) ;
            if (PaymentMethod == PaymentMethod.Cash)
            {
                Payment = TotalPrice - discount;
            }
            else
            {
                if (Payment != 0)
                {
                    RemainingAmount = TotalPrice - Payment - Discount;
                }
                else
                {
                    RemainingAmount = TotalPrice;
                }

            }
        }
        public void CalcTotalForPurches(List<PurchesBillViewModel> purchesBillViewModel)
        {
            if (purchesBillViewModel == null || purchesBillViewModel.Count < 1)
            {
                return;
            }
            double total = 0;
            int totalItem = 0;
            purchesBillViewModel.ForEach(x => total += (x.PurchasePrice * x.Quantity));
            purchesBillViewModel.ForEach(x => totalItem += x.Quantity);
            TotalPrice = total;
            TotalItem = totalItem;
            if (PaymentMethod == PaymentMethod.Cash)
            {
                if (FormOperation == FormOperation.EditFromPicker)
                {
                    Payment = TotalPrice;
                }
                if (payment <= TotalPrice) Payment = TotalPrice - Discount;
            }
            else
            {
                if (Payment != 0)
                {
                    RemainingAmount = TotalPrice - Payment - Discount;
                }
                else
                {
                    RemainingAmount = TotalPrice;
                }
            }
            if (Discount > 0)
                if (PaymentMethod == PaymentMethod.Cash) Payment = TotalPrice - Discount;

            onUpdateForm?.Invoke();
        }
        public void CalcTotalForPurchesWhenUpdatePrice(List<PurchesBillViewModel> purchesBillViewModel)
        {
            if (purchesBillViewModel == null || purchesBillViewModel.Count < 1)
            {
                return;
            }
            double total = 0;
            int totalItem = 0;
            purchesBillViewModel.ForEach(x => total += (x.PurchasePrice * x.Quantity));
            purchesBillViewModel.ForEach(x => totalItem += x.Quantity);
            TotalPrice = total;
            TotalItem = totalItem;
            if (PaymentMethod == PaymentMethod.Cash)
            {
                Payment = TotalPrice - Discount;
            }
            else
            {
                if (Payment != 0)
                {
                    RemainingAmount = TotalPrice - Payment - Discount;
                }
                else
                {
                    RemainingAmount = TotalPrice;
                }
            }
            if (Discount > 0)
                if (PaymentMethod == PaymentMethod.Cash) Payment = TotalPrice - Discount;
            if (FormOperation == FormOperation.EditFromPicker && PaymentMethod == PaymentMethod.Cash)
            {
                Payment = TotalPrice;
                //tbPayment.Text = billMaster.Payment.ToString();
            }
            onUpdateForm?.Invoke();


        }
        #endregion
    }
}
