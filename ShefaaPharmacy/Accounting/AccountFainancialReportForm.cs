using DataLayer;
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
    public partial class AccountFainancialReportForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        UserParameters userParameters;
        public AccountFainancialReportForm()
        {
            InitializeComponent();
            userParameters = ReportParametersForm.ReportParameterForAccounting(new UserParameters());
            if (userParameters == null)
            {
                Load += (s, e) => Close();
                return;
            }
            else
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var account = context.Accounts.Where(x => x.Id == userParameters.Acc_AccountId).FirstOrDefault();
                lbGeneralAccount.Text = account.General ? account.Name : account.AccountGeneralIdDescr;
                LoadMaster();
                LoadDetail();
                dgMaster.AutoGenerateColumns = true;
                dgDetail.AutoGenerateColumns = true;
                dgMaster.AllowUserToAddRows = false;
                dgDetail.AllowUserToAddRows = false;
                dgMaster.ReadOnly = true;
                dgDetail.ReadOnly = true;
                //dgMaster.Columns[4].Visible = false;

            }
        }
        public AccountFainancialReportForm(UserParameters userParameters)
        {
            InitializeComponent();
            this.userParameters = userParameters;
            if (userParameters == null)
            {
                Load += (s, e) => Close();
                return;
            }
            else
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var account = context.Accounts.Where(x => x.Id == userParameters.Acc_AccountId).FirstOrDefault();
                lbGeneralAccount.Text = account.General ? account.Name : account.AccountGeneralIdDescr;
                LoadMaster();
                LoadDetail();
                dgMaster.AutoGenerateColumns = true;
                dgDetail.AutoGenerateColumns = true;
                dgMaster.AllowUserToAddRows = false;
                dgDetail.AllowUserToAddRows = false;
                dgMaster.ReadOnly = true;
                dgDetail.ReadOnly = true;
                //dgMaster.Columns[4].Visible = false;

            }
        }
        int count = 0;
        private void LoadMaster()
        {
            string mydate = "01/01/2000";
            DateTime firstdate = Convert.ToDateTime(mydate);
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@AccountId", userParameters.Acc_AccountId),
                new SqlParameter("@FromDate", userParameters.FromDate),
                new SqlParameter("@ToDate", userParameters.ToDate),
                new SqlParameter("@CreationBy", userParameters.UserId)
            };
            var x = parameters.ToArray();
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetAccountMovmement",
                                                parameters.ToArray());
            List<EntryDetail> resultReport = DataBaseService.ConvertDataTable<EntryDetail>(result);
            List<EntryDetail> beforefinalresult = DataBaseService.ConvertDataTable<EntryDetail>(result);
            List<EntryDetail> finalresult = new List<EntryDetail>();
            foreach (EntryDetail item in resultReport)
            {
                if (item.Id == item.Id - 1)
                {
                    if (count == 2) continue;
                    beforefinalresult.Add(item);
                    count++;
                }
            }
            foreach (EntryDetail detail in beforefinalresult)
            {
                detail.CreationDate = detail.CreationDate.Date;
                finalresult.Add(detail);
            }
            bindingSourceMaster.DataSource = finalresult;
            bindingNavigator1.BindingSource = bindingSourceMaster;

        }
        private void LoadDetail()
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@AccountId", userParameters.Acc_AccountId),
                new SqlParameter("@FromDate", userParameters.FromDate),
                new SqlParameter("@ToDate", userParameters.ToDate),
                new SqlParameter("@CreationBy", userParameters.UserId)
            };
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetAccountDebitCredit",
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
            try
            {
                dgMaster.Columns["Id"].Visible = false;
                //dgMaster.Columns["Description"].Visible = false;
                dgMaster.Columns["CreationByDescr"].Visible = false;
                dgMaster.Columns["AccountIdDescr"].HeaderText = "حساب العملية";

            }
            catch {; }
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
            userParameters = ReportParametersForm.ReportParameterForAccounting(new UserParameters());
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

        private void AccountFainancialReportForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void dgMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
