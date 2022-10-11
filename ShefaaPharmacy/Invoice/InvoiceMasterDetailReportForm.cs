using DataLayer;
using DataLayer.Enums;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Invoice
{
    public partial class InvoiceMasterDetailReportForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        UserParameters userParameters;
        public InvoiceMasterDetailReportForm()
        {
            InitializeComponent();
            userParameters = ReportParametersForm.ReportParameterForIvoice(new UserParameters());
            if (userParameters == null)
            {
                Load += (s, e) => Close();
                return;
            }
            else
            {
                LoadMaster();
                dgMaster.AutoGenerateColumns = true;
                dgDetail.AutoGenerateColumns = true;
                dgMaster.AllowUserToAddRows = false;
                dgDetail.AllowUserToAddRows = false;
                dgMaster.ReadOnly = true;
                dgDetail.ReadOnly = true;
            }
        }
        private void LoadMaster()
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@InvoiceKind", userParameters.InvoiceKind),
                new SqlParameter("@BillId", userParameters.InvoiceId),
                new SqlParameter("@AccountId", userParameters.Acc_AccountId),
                new SqlParameter("@FromDate", userParameters.FromDate),
                new SqlParameter("@ToDate", userParameters.ToDate),
                new SqlParameter("@CreationBy", userParameters.UserId)
            };
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "BillReport",
                                                parameters.ToArray());
            List<BillMaster> resultReport = DataBaseService.ConvertDataTable<BillMaster>(result);
            bindingSourceMaster.DataSource = resultReport;
            bindingNavigator1.BindingSource = bindingSourceMaster;
        }
        private void dgMaster_BindingContextChanged(object sender, EventArgs e)
        {
            dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.Refresh();
        }
        private void dgDetail_BindingContextChanged(object sender, EventArgs e)
        {
            dgDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.Refresh();
        }
        private void LoadDetail(BillMaster billMaster)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<BillDetail> resultReport = context.BillDetails.Where(x => x.BillMasterId == billMaster.Id).ToList();
            bindingSourceDetail.DataSource = resultReport;
        }
        private void bindingSourceMaster_PositionChanged(object sender, EventArgs e)
        {
            if (bindingSourceMaster.Current == null)
                return;
            LoadDetail(bindingSourceMaster.Current as BillMaster);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bindingSourceMaster.Current == null)
                return;
            if ((bindingSourceMaster.Current as BillMaster).InvoiceKind == InvoiceKind.ReturnSell || (bindingSourceMaster.Current as BillMaster).InvoiceKind == InvoiceKind.ReturnBuy)
            {
                _MessageBoxDialog.Show("لا يمكن التعديل على فاتورة مرتجعة", MessageBoxState.Error);
                return;
            }
            else if ((bindingSourceMaster.Current as BillMaster).InvoiceKind == InvoiceKind.Sell)
            {
                GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm((bindingSourceMaster.Current as BillMaster), (bindingSourceMaster.Current as BillMaster).InvoiceKind, FormOperation.EditFromPicker);
                generalInvoiceEditForm.ShowDialog();
            }
            else if ((bindingSourceMaster.Current as BillMaster).InvoiceKind == InvoiceKind.Buy)
            {
                BuyInvoiceEditForm buyInvoiceEditForm = new BuyInvoiceEditForm((bindingSourceMaster.Current as BillMaster), FormOperation.EditFromPicker);
                buyInvoiceEditForm.ShowDialog();
            }
            LoadMaster();
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            LoadMaster();
        }
        private void tsReset_Click(object sender, EventArgs e)
        {
            var oldUserParameter = userParameters;
            userParameters = ReportParametersForm.ReportParameterForIvoice(new UserParameters());
            if (userParameters != null)
                LoadMaster();
            else
            {
                userParameters = oldUserParameter;
            }
            dgDetail.Refresh();
        }

        private void InvoiceMasterDetailReportForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
