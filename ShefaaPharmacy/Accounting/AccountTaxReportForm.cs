using DataLayer;
using DataLayer.Enums;
using DataLayer.Tables;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Invoice;
using ShefaaPharmacy.GeneralUI;
using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShefaaPharmacy.Accounting
{
    public partial class AccountTaxReportForm : AbstractForm
    {
        UserParameters userParameters;
        List<DetailedTaxCode> resultReport = new List<DetailedTaxCode>();

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
            resultReport = DataBaseService.ConvertDataTable<DetailedTaxCode>(result);
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
            dgMaster.Columns["CreationByDescr"].Visible = false;
            dgMaster.Columns["CreationDate"].Visible = false;
            dgMaster.Columns["InvoiceKind"].Visible = false;
            dgMaster.Columns["DateTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["BillExporterApp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["Currency"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgMaster.Columns["RandomCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
        private void miShowBill_Click(object sender, EventArgs e)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            if ((bindingSourceMaster.Current as DetailedTaxCode).InvoiceKind == InvoiceKind.Sell)
            {
                var BillMaster = context.BillMasters.Where(x=>x.Id==Convert.ToInt32((bindingSourceMaster.Current as DetailedTaxCode).BillNumber)).FirstOrDefault();
                GeneralInvoiceEditForm generalInvoiceEditForm = new GeneralInvoiceEditForm(BillMaster, InvoiceKind.Sell, FormOperation.Show);
                generalInvoiceEditForm.ShowDialog();
            }
            else
            {
                return;
            }
        }
        public string GetEnumDisplayName(Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
        private void AccountTaxReportForm_Load(object sender, EventArgs e)
        {
            //CBKindFilter.Visible = true;
            //List<string> MyList = new List<string> { GetEnumDisplayName(InvoiceKind.All), GetEnumDisplayName(InvoiceKind.Buy), GetEnumDisplayName(InvoiceKind.Sell) };

            //CBKindFilter.ComboBox.DataSource = MyList;
            //CBKindFilter.ComboBox.DisplayMember = "Name";

            //CBKindFilter.SelectedIndexChanged += CBKindFilter_SelectedIndexChanged;
        }
        private void CBKindFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var Invoicekind = EnumHelper<InvoiceKind>.GetValueFromName((string)CBKindFilter.ComboBox.SelectedValue);
            //    if(Invoicekind != InvoiceKind.All)
            //    bindingSourceMaster.DataSource = resultReport.Where(x => x.InvoiceKind == Invoicekind).ToList();
            //    else bindingSourceMaster.DataSource = resultReport;
            //    dgMaster.Refresh();

            //}
            //catch (Exception ex)
            //{
            //    ;
            //}
        }
    }
    // Helper Class To Get InvoiceKind Item Name
    public static class EnumHelper<T>
    {
        public static T GetValueFromName(string name)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                    typeof(DisplayAttribute)) is DisplayAttribute attribute)
                {
                    if (attribute.Name == name)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == name)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentOutOfRangeException("name");
        }
    }
}
