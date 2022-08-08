using DataLayer;
using DataLayer.Enums;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.Orders
{
    public partial class OrderFromCompanyEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        OrderMaster OrderMaster;
        List<OrderDetail> orderDetails;
        public OrderFromCompanyEditForm(FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            OrderMaster = new OrderMaster();
            OrderMaster.Details = new List<OrderDetail>();
            #region Final Order
            orderDetails = new List<OrderDetail>();
            dgFinalOrder.AutoGenerateColumns = true;
            bsFinalOrder.DataSource = orderDetails;
            dgFinalOrder.DataSource = bsFinalOrder;
            #endregion
            dgvOrderDetail.AutoGenerateColumns = true;
            EditBindingSource.DataSource = OrderMaster;
            DetailBindingSource.DataSource = OrderMaster.Details;
            dgvOrderDetail.DataSource = DetailBindingSource;
            FormOperation = formOperation;
            FillCompanyDDL();
        }
        public OrderFromCompanyEditForm(OrderMaster orderMaster, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            FormOperation = formOperation;
            if (orderMaster == null || orderMaster.Id == 0)
            {
                orderMaster = new OrderMaster();
                OrderMaster = orderMaster;
                OrderMaster.Details = new List<OrderDetail>();
                FillCompanyDDL();
            }
            else
            {
                OrderMaster = orderMaster;
                if (OrderMaster.Details == null || OrderMaster.Details.Count < 1)
                {
                    OrderMaster.Details = new List<OrderDetail>();
                }
                ddlCompany.Items.Add(OrderMaster.CompanyIdDescr);
                ddlCompany.SelectedIndex = 0;
            }
            dgvOrderDetail.AutoGenerateColumns = true;
            EditBindingSource.DataSource = OrderMaster;
            DetailBindingSource.DataSource = OrderMaster.Details;
            dgvOrderDetail.DataSource = DetailBindingSource;
            #region Final Order
            orderDetails = new List<OrderDetail>();
            dgFinalOrder.AutoGenerateColumns = true;
            bsFinalOrder.DataSource = orderDetails;
            dgFinalOrder.DataSource = bsFinalOrder;
            #endregion
        }
        void FillCompanyDDL()
        {
            ddlCompany.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Companys.ToList();
            ddlCompany.DisplayMember = "Name";
            ddlCompany.ValueMember = "Id";
            ddlCompany.SelectedIndex = 0;

        }

        private void DgvOrderDetail_BindingContextChanged(object sender, EventArgs e)
        {
            try
            {
                HiddenColumn = new string[] { "Articale", "ArticleId", "OrderMasterId", "OrderMaster", "CreationByDescr", "CreationDate", "Id", "Quantity" };
                ShowColumn(dgvOrderDetail.Columns);
                dgvOrderDetail.Columns["ArticleIdDescr"].ReadOnly = true;
                dgvOrderDetail.Columns["QuantityLeft"].ReadOnly = true;
                dgvOrderDetail.Refresh();
            }
            catch (Exception ex)
            {
                ;
            }
        }
        private void GetOrderDetail(int companyId)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@companyId", companyId),
            };
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(), "GetArticleForCompany", parameters.ToArray());
            List<OrderDetail> resultReport = DataBaseService.ConvertDataTable<OrderDetail>(result);
            DetailBindingSource.DataSource = resultReport;
            dgvOrderDetail.DataSource = DetailBindingSource;
        }
        private void GetOrderDetail(int companyId, string name)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@companyId", companyId),
            };
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(), "GetArticleForCompany", parameters.ToArray());
            List<OrderDetail> resultReport = DataBaseService.ConvertDataTable<OrderDetail>(result).Where(x => x.ArticleIdDescr.Contains(name.ToUpper())).ToList();
            DetailBindingSource.DataSource = resultReport;
            dgvOrderDetail.DataSource = DetailBindingSource;
        }
        private void DdlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetOrderDetail(Convert.ToInt32(ddlCompany.SelectedValue));
            }
            catch (Exception)
            {
                ;
            }
        }
        public void DeleteRow()
        {
            try
            {
                if (dgvOrderDetail.Rows.Count > 0 && DetailBindingSource.Current != null)
                {
                    var index = dgvOrderDetail.CurrentRow.Index;
                    dgvOrderDetail.Rows.RemoveAt(index);
                    dgvOrderDetail.Refresh();
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }
        public void InecreseQuantity()
        {
            if (dgvOrderDetail.Rows.Count > 0 && DetailBindingSource.Current != null)
            {
                (DetailBindingSource.Current as OrderDetail).Quantity += 1;
                dgvOrderDetail.Refresh();
            }
        }
        private void LbDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void LbIncreseQuantity_Click(object sender, EventArgs e)
        {
            InecreseQuantity();
        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetail.DataSource == null || dgFinalOrder.Rows[0].IsNewRow)
            {
                _MessageBoxDialog.Show("قم بإدخال الطلبية", MessageBoxState.Warning);
                return;
            }
            try
            {
                base.btOk_Click(sender, e);
            }
            catch (Exception)
            {
                return;
            }
            try
            {

                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                {
                    OrderMaster.OrderState = OrderState.Running;
                    OrderMaster.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                    OrderMaster.Id = 0;
                    OrderMaster.Details = (bsFinalOrder.DataSource as List<OrderDetail>).Where(x => x.Quantity > 0).ToList();
                    context.OrderMasters.Add(OrderMaster);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة طلبية جديدة", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                        return;
                    }
                }
                else
                {
                    context.OrderMasters.UpdateRange(OrderMaster);
                    context.SaveChanges();
                    context.Entry(OrderMaster).State = EntityState.Detached;
                    var old = context.OrderDetails.Where(x => x.OrderMasterId == OrderMaster.Id).ToList();
                    if (OrderMaster.Details.Count < old.Count())
                    {
                        foreach (var item in old)
                        {
                            if (!OrderMaster.Details.Any(x => x.Id == item.Id))
                            {
                                context.OrderDetails.Remove(item);
                                context.SaveChanges();
                            }
                        }
                    }
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات الطلبية", MessageBoxState.Done);
                    if (FormOperation == FormOperation.EditFromPicker)
                    {
                        Close();
                        return;
                    }
                }
                EditBindingSource.AddNew();
                tbSearch.Text = "";
                bsFinalOrder.Clear();
                orderDetails = new List<OrderDetail>();
                bsFinalOrder.DataSource = orderDetails;
                dgFinalOrder.Refresh();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void OrderFromCompanyEditForm_Load(object sender, EventArgs e)
        {
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);
            dgvOrderDetail.EnableHeadersVisualStyles = false;

            dgvOrderDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgvOrderDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgFinalOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgFinalOrder.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgFinalOrder.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);
            dgFinalOrder.EnableHeadersVisualStyles = false;

            dgFinalOrder.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgFinalOrder.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DdlCompany_SelectedIndexChanged(sender, e);

        }

        private void TbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvOrderDetail.DataSource == null)
            {
                return;
            }
            if (String.IsNullOrEmpty(tbSearch.Text))
            {
                GetOrderDetail(Convert.ToInt32(ddlCompany.SelectedValue));
            }
            else
            {
                GetOrderDetail(Convert.ToInt32(ddlCompany.SelectedValue), tbSearch.Text.ToUpper());
            }
            dgvOrderDetail.Refresh();
        }

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbSearch.Text))
            {
                GetOrderDetail(Convert.ToInt32(ddlCompany.SelectedValue));
            }
            else
            {
                GetOrderDetail(Convert.ToInt32(ddlCompany.SelectedValue), tbSearch.Text.ToUpper());
            }
            dgvOrderDetail.Refresh();
        }

        private void DgvOrderDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrderDetail.DataSource == null || dgvOrderDetail.CurrentRow == null || (dgvOrderDetail.Rows.Count < 1))
            {
                return;
            }
            else
            {
                bsFinalOrder.Add(DetailBindingSource.Current as OrderDetail);
                dgFinalOrder.Refresh();
            }
        }

        private void DgFinalOrder_BindingContextChanged(object sender, EventArgs e)
        {
            try
            {
                HiddenColumn = new string[] { "Articale", "ArticleId", "OrderMasterId", "OrderMaster", "CreationByDescr", "CreationDate", "Id" };
                ShowColumn(dgFinalOrder.Columns);
                dgFinalOrder.Columns["ArticleIdDescr"].ReadOnly = true;
                dgFinalOrder.Columns["QuantityLeft"].ReadOnly = true;
                dgFinalOrder.Refresh();
            }
            catch (Exception ex)
            {
                ;
            }
        }
    }
}

