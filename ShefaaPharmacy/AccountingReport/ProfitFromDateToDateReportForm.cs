using DataLayer;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
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

namespace ShefaaPharmacy.AccountingReport
{
    public partial class ProfitFromDateToDateReportForm : AbstractForm
    {
        UserParameters userParameters;
        readonly int[] SumRows = new int[] { 0, 4, 5, 8 };
        public ProfitFromDateToDateReportForm()
        {
            InitializeComponent();
            userParameters = ReportParametersForm.ReportParameterProfitFromDateToDate(new UserParameters());
            if (userParameters == null)
            {
                Load += (s, e) => Close();
                return;
            }
            else
            {
                LoadMaster();
                dgMaster.AutoGenerateColumns = true;
                dgMaster.AllowUserToAddRows = false;
                dgMaster.ReadOnly = true;
            }
        }
        public ProfitFromDateToDateReportForm(UserParameters userParameters)
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
                LoadMaster();
                dgMaster.AutoGenerateColumns = true;
                dgMaster.AllowUserToAddRows = false;
                dgMaster.ReadOnly = true;
            }
        }

        private void LoadMaster()
        {
            ArticleService.BindLastTimeArticlesToToDB();

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", userParameters.FromDate),
                new SqlParameter("@ToDate", userParameters.ToDate)
            };
            parameters[0].Value = Convert.ToDateTime(parameters[0].Value).AddDays(-1);
            parameters[1].Value = Convert.ToDateTime(parameters[1].Value).AddDays(+1);

            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetProfitFromDateToDate",
                                                parameters.ToArray());

            List<GetProfitFromDateToDateViewModel> resultReport = DataBaseService.ConvertDataTable<GetProfitFromDateToDateViewModel>(result);
            bindingSourceMaster.DataSource = resultReport;
            bindingNavigator1.BindingSource = bindingSourceMaster;
        }

        private void ProfitFromDateToDateReportForm_Load(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void DgMaster_BindingContextChanged(object sender, System.EventArgs e)
        {
            dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.Refresh();
        }
        private void TsRefresh_Click(object sender, System.EventArgs e)
        {
            LoadMaster();
        }
        private void TsReset_Click(object sender, System.EventArgs e)
        {
            var oldUserParameter = userParameters;
            userParameters = ReportParametersForm.ReportParameterProfitFromDateToDate(new UserParameters());
            if (userParameters != null)
            {
                LoadMaster();
            }
            else
            {
                userParameters = oldUserParameter;
            }
        }
        private void DgMaster_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (SumRows.Contains(e.RowIndex))
            {
                dgMaster.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LimeGreen;
                dgMaster.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }
    }
}
