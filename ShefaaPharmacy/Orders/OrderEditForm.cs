using DataLayer.Enums;
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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.Orders
{
    public partial class OrderEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        OrderMaster OrderMaster;
        public bool SelectedFromDDL { get; set; }
        public OrderEditForm(FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            OrderMaster = new OrderMaster();
            OrderMaster.Details = new List<OrderDetail>();
            dgvOrderDetail.AutoGenerateColumns = true;
            EditBindingSource.DataSource = OrderMaster;
            DetailBindingSource.DataSource = OrderMaster.Details;
            FormOperation = formOperation;
            FillCompanyDDL();
            SelectedFromDDL = false;
            HelperUI.BindToEnum<OrderState>(ddlOrderState);
        }
        public OrderEditForm(OrderMaster orderMaster, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            FormOperation = formOperation;
            if (orderMaster == null || orderMaster.Id == 0)
            {
                orderMaster = new OrderMaster();
                OrderMaster = orderMaster;
                OrderMaster.Details = new List<OrderDetail>();
                FillCompanyDDL();
                SelectedFromDDL = false;
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
                FillArticleDDL(OrderMaster.CompanyId);
            }
            dgvOrderDetail.AutoGenerateColumns = true;
            EditBindingSource.DataSource = OrderMaster;
            DetailBindingSource.DataSource = OrderMaster.Details;
            HelperUI.BindToEnum<OrderState>(ddlOrderState);
            if (!(FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New))
            {
                ddlOrderState.SelectedValue = (int)OrderMaster.OrderState;
            }
        }
        void FillCompanyDDL()
        {
            ddlCompany.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Companys.ToList();
            ddlCompany.DisplayMember = "Name";
            ddlCompany.ValueMember = "Id";
            ddlCompany.SelectedIndex = 0;
        }
        void FillArticleDDL(int companyId)
        {
            ddlArticle.DataSource = null;
            ddlArticle.Items.Clear();
            ddlArticle.ResetText();
            ddlArticle.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(y => y.CompanyId == companyId).Select(z => new { z.Name, z.Id }).ToList();
            ddlArticle.DisplayMember = "Name";
            ddlArticle.ValueMember = "Id";
            ddlArticle.SelectedIndex = 0;
            ddlArticle.Focus();
        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetail.Rows.Count == 0)
            {
                _MessageBoxDialog.Show("لا يمكن إضافة طلبية فارغة", MessageBoxState.Warning);
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
                    OrderMaster.OrderState = (OrderState)ddlOrderState.SelectedValue;
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
                    OrderMaster.OrderState = (OrderState)ddlOrderState.SelectedValue;
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
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }
        public static OrderMaster CreateOrder(OrderMaster orderMaster, FormOperation formOperation = FormOperation.New)
        {
            OrderEditForm fmEdit = new OrderEditForm(orderMaster, formOperation);
            try
            {
                fmEdit.Text = "إضافة طلبية";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return (OrderMaster)fmEdit.CurrentEntity;
            }
            finally
            {
                fmEdit.Dispose();
            }
        }
        private void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New))
                {
                    return;
                }
                if (DetailBindingSource.Count > 0)
                {
                    MessageBoxAnswer dialogResult = _MessageBoxDialog.Show("إذا قمت بتغير الشركة سيتم حذف الطلبية مالم يتم حفظها هل تريد المتابعة بدون حفظ؟", MessageBoxState.Answering);
                    if (dialogResult == MessageBoxAnswer.Yes)
                    {
                        OrderMaster.Details = new List<OrderDetail>();
                        DetailBindingSource.DataSource = OrderMaster.Details;
                        FillArticleDDL((int)ddlCompany.SelectedValue);
                    }
                }
                else
                {
                    FillArticleDDL((int)ddlCompany.SelectedValue);
                    OrderMaster.CompanyId = (int)ddlCompany.SelectedValue;
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void pbAddRow_Click(object sender, EventArgs e)
        {
            if (ddlArticle.Items == null || ddlArticle.Items.Count < 1)
            {
                return;
            }
            SelectedFromDDL = true;
            if (((List<OrderDetail>)DetailBindingSource.DataSource).Any(x => x.ArticleId == (int)ddlArticle.SelectedValue))
            {
                ((List<OrderDetail>)DetailBindingSource.DataSource).FirstOrDefault(x => x.ArticleId == (int)ddlArticle.SelectedValue).Quantity += 1;
                dgvOrderDetail.Refresh();
            }
            else
            {
                DetailBindingSource.AddNew();
            }
        }

        private void DetailBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            OrderDetail orderDetail = new OrderDetail();
            if (SelectedFromDDL)
            {
                orderDetail.ArticleId = (int)ddlArticle.SelectedValue;
                orderDetail.Quantity = 1;
                e.NewObject = orderDetail;
            }
            dgvOrderDetail.Refresh();
        }

        private void dgvOrderDetail_BindingContextChanged(object sender, EventArgs e)
        {
            try
            {
                HiddenColumn = new string[] { "Articale", "ArticleId", "OrderMasterId", "OrderMaster", "CreationByDescr", "CreationDate", "Id" };
                ShowColumn(dgvOrderDetail.Columns);
                dgvOrderDetail.Columns["ArticleIdDescr"].ReadOnly = true;
                dgvOrderDetail.Refresh();
            }
            catch (Exception ex)
            {
                ;
            }
        }
        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgvOrderDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);
            dgvOrderDetail.EnableHeadersVisualStyles = false;

            dgvOrderDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgvOrderDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            ddlCompany_SelectedIndexChanged(sender, e);
        }

        private void pbDeleteRow_Click(object sender, EventArgs e)
        {
            DeleteRow();
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
        public void DecreseQuantity()
        {
            if (dgvOrderDetail.Rows.Count > 0 && DetailBindingSource.Current != null)
            {
                if ((DetailBindingSource.Current as OrderDetail).Quantity > 1)
                {
                    (DetailBindingSource.Current as OrderDetail).Quantity -= 1;
                }
                dgvOrderDetail.Refresh();
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

        private void pbDecresQuantity_Click(object sender, EventArgs e)
        {
            DecreseQuantity();
        }

        private void pbIncreseQuantity_Click(object sender, EventArgs e)
        {
            InecreseQuantity();
        }
    }
}
