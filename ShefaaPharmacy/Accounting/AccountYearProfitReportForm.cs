using DataLayer;
using DataLayer.Helper;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.Accounting
{
    public partial class AccountYearProfitReportForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        UserParameters userParameters;
        public AccountYearProfitReportForm()
        {
            InitializeComponent();
            int cash = UserLoggedIn.User.UserPermissions.CashAccountId;
            userParameters = ReportParametersForm.ReportParameterForProfit(new UserParameters());
            if (userParameters == null)
            {
                Load += (s, e) => Close();
                return;
                //return;
            }
            else
            {
                LoadMaster();
                LoadDetail();
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
                new SqlParameter("@YearId", userParameters.YearId)
            };
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetProfitForYear",
                                                parameters.ToArray());
            List<AccountingReportForYearProfit> resultReport = DataBaseService.ConvertDataTable<AccountingReportForYearProfit>(result);

            bindingSourceMaster.DataSource = resultReport;
            bindingNavigator1.BindingSource = bindingSourceMaster;
        }
        private void LoadDetail()
        {
            AccountingReportForYearProfitDetail accountingReportForYearProfitDetail = new AccountingReportForYearProfitDetail();
            (bindingSourceMaster.DataSource as List<AccountingReportForYearProfit>).ForEach(x => accountingReportForYearProfitDetail.Debit += x.Debit);
            (bindingSourceMaster.DataSource as List<AccountingReportForYearProfit>).ForEach(x => accountingReportForYearProfitDetail.Credit += x.Credit);
            bindingSourceDetail.DataSource = accountingReportForYearProfitDetail;
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

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            LoadMaster();
            LoadDetail();
        }

        private void tsReset_Click(object sender, EventArgs e)
        {
            var oldUserParameter = userParameters;
            userParameters = ReportParametersForm.ReportParameterForProfit(new UserParameters());
            if (userParameters != null)
            {

                LoadMaster();
                LoadDetail();
            }
            else
            {
                userParameters = oldUserParameter;
            }
        }
    }
}
