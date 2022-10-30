using DataLayer;
using DataLayer.Tables;
using DataLayer.Enums;
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
    public partial class AccountTaxReportForm : AbstractForm
    {
        UserParameters userParameters;
        public AccountTaxReportForm()
        {
            InitializeComponent();
            userParameters = ReportParametersForm.ReportParameterForEntryReport(new UserParameters());
            if (userParameters == null)
            {
                Load += (s, e) => Close();
                return;
            }
            else
            {
                dgMaster.AutoGenerateColumns = true;
                dgDetail.AutoGenerateColumns = true;
                dgMaster.AllowUserToAddRows = false;
                dgDetail.AllowUserToAddRows = false;
                dgMaster.ReadOnly = true;
                dgDetail.ReadOnly = true;
                LoadMaster();
            }
            WindowState = FormWindowState.Maximized;
        }
        private void LoadMaster()
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", userParameters.FromDate),
                new SqlParameter("@ToDate", userParameters.ToDate),
                new SqlParameter("@CreationBy", userParameters.UserId),
                new SqlParameter("@YearId", userParameters.YearId)
            };
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "TaxReport",
                                                parameters.ToArray());
            List<DetailedTaxCode> resultReport = DataBaseService.ConvertDataTable<DetailedTaxCode>(result);
            bindingSourceMaster.DataSource = resultReport;
            bindingNavigator1.BindingSource = bindingSourceMaster;
        }
        private void LoadDetail(EntryMaster entryMaster)
        {
            try
            {
                //List<DetailedTaxCode> TaxDetails = ShefaaPharmacyDbContext.GetCurrentContext().DetailedTaxCode.ToList();
                //bindingSourceDetail.DataSource = TaxDetails;
            }
            catch
            {

            }
        }
        private void dgMaster_BindingContextChanged(object sender, EventArgs e)
        {
            dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.Columns["Id"].Visible = false;
            dgMaster.Columns["RandomCode"].Visible = false;
            dgMaster.Columns["CreationByDescr"].Visible = false;
            dgMaster.Columns["DateTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["BillExporterApp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["CreationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["Currency"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgMaster.Refresh();
        }
        private void dgDetail_BindingContextChanged(object sender, EventArgs e)
        {
            //dgDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            //dgDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            //dgDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            //dgDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgDetail.EnableHeadersVisualStyles = false;
            //dgDetail.Refresh();
        }
        private void tsRefresh_Click(object sender, EventArgs e)
        {
            LoadMaster();
        }
        private void tsReset_Click(object sender, EventArgs e)
        {
            var oldUserParameter = userParameters;
            userParameters = ReportParametersForm.ReportParameterForEntryReport(new UserParameters());
            if (userParameters != null)
            {
                LoadMaster();
            }
            else
            {
                userParameters = oldUserParameter;
            }
        }
        private void BindingSourceMaster_PositionChanged(object sender, EventArgs e)
        {
            if (bindingSourceMaster.Current == null)
                return;
            LoadDetail(bindingSourceMaster.Current as EntryMaster);
        }
        private void MiEditEntry_Click(object sender, EventArgs e)
        {
            if (bindingSourceMaster.Current == null)
                return;
            EntryEditForm entryEditForm = new EntryEditForm(bindingSourceMaster.Current as EntryMaster, KindOperation.Entry, FormOperation.EditFromPicker);
            entryEditForm.ShowDialog();
        }

        private void AccountTaxReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
