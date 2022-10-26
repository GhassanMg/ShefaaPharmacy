using DataLayer;
using DataLayer.Helper;
using DataLayer.StoredProcedures;
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

namespace ShefaaPharmacy.Accounting
{
    public partial class AccountCashMovementReportForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        UserParameters userParameters;
        public AccountCashMovementReportForm()
        {
            InitializeComponent();
            int cash = UserLoggedIn.User.UserPermissions.CashAccountId;
            userParameters = ReportParametersForm.ReportParameterForAccounting(new UserParameters()
            {
                Acc_AccountId = cash
            });
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
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<EntryDetail> resultReport = context.EntryDetails.Where(x => x.AccountId == userParameters.Acc_AccountId
            && x.CreationDate >= userParameters.FromDate
            && x.CreationDate <= userParameters.ToDate).ToList();
            if (userParameters.UserId != 1)
            {
                resultReport = resultReport.Where(x => x.CreationBy == userParameters.UserId).ToList();
            }
            bindingSourceMaster.DataSource = resultReport;
            bindingNavigator1.BindingSource = bindingSourceMaster;
        }
        private void LoadDetail()
        {
            List<SqlParameter> parameters = new List<SqlParameter>( )
            {
                new SqlParameter("@AccountId", userParameters.Acc_AccountId),
                new SqlParameter("@FromDate", userParameters.FromDate),
                new SqlParameter("@ToDate", userParameters.ToDate),
                new SqlParameter("@CreationBy", userParameters.UserId)
            };

            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetFooterMovementCash",
                                                parameters.ToArray());
            List<GetAccountDebitCredit> resultReport = DataBaseService.ConvertDataTable<GetAccountDebitCredit>(result);
            bindingSourceDetail.DataSource = resultReport;

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

        private void bindingSourceMaster_PositionChanged(object sender, EventArgs e)
        {
            //if (bindingSourceMaster.Current == null)
            //    return;
            //LoadDetail();
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            LoadMaster();
            LoadDetail();
        }

        private void tsReset_Click(object sender, EventArgs e)
        {
            var oldUserParameter = userParameters;
            int cash = UserLoggedIn.User.UserPermissions.CashAccountId;
            userParameters = ReportParametersForm.ReportParameterForAccounting(new UserParameters()
            {
                Acc_AccountId = cash
            });
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

        private void AccountCashMovementReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
