using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer.Services;

namespace ShefaaPharmacy.Orders
{
    public partial class OrderPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        OrderMaster orderMaster;
        public OrderPickForm()
        {
            InitializeComponent();
        }
        public OrderPickForm(OrderMaster orderMaster)
        {
            this.orderMaster = orderMaster;
            InitializeComponent();
        }
        public static OrderMaster PickOrderMaster(OrderMaster orderMaster, FormOperation formOperation = FormOperation.Show)
        {
            OrderPickForm fmPick = new OrderPickForm(orderMaster);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض الطلبيات";
                fmPick.ShowDialog();
                return (OrderMaster)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static OrderMaster PickOrderMaster(string textFilter, OrderMaster orderMaster, FormOperation formOperation = FormOperation.Show)
        {
            OrderMaster tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().OrderMasters.Where(x => x.CompanyIdDescr == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            OrderPickForm fmPick = new OrderPickForm(orderMaster);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر طلبية";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return (OrderMaster)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }

        protected override void AdjustmentGridColumns()
        {
            HiddenColumn = new string[] { "Company", "CompanyId" };
            base.AdjustmentGridColumns();
            PickGridView.Columns["Id"].HeaderText = "رقم الطلبية";
            PickGridView.Refresh();
        }
        protected override void Rebinding()
        {
            if (orderMaster == null || orderMaster.Id == 0)
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().OrderMasters.ToList();
            else
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().OrderMasters.Where(x => x.Id == orderMaster.Id).ToList();
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (OrderMaster)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            OrderEditForm.CreateOrder(CurrentEntity as OrderMaster, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (FormOperation != FormOperation.Pick)
            {
                (CurrentEntity as OrderMaster).Details = ShefaaPharmacyDbContext.GetCurrentContext().OrderDetails.Where(x => x.OrderMasterId == (CurrentEntity as OrderMaster).Id).ToList();
                OrderEditForm edForm = new OrderEditForm(CurrentEntity as OrderMaster, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            if (FormOperation != FormOperation.Pick)
            {
                SetCurrentEntity();
                (CurrentEntity as OrderMaster).Details = ShefaaPharmacyDbContext.GetCurrentContext().OrderDetails.Where(x => x.OrderMasterId == (CurrentEntity as OrderMaster).Id).ToList();
                OrderEditForm edForm = new OrderEditForm(CurrentEntity as OrderMaster, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        private void tsddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((int)tsddlSearch.ComboBox.SelectedValue == 0)
                {
                    PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().OrderMasters.ToList();
                }
                else
                {
                    PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().OrderMasters.Where(x => x.OrderState == (OrderState)tsddlSearch.ComboBox.SelectedValue).ToList();
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }
        private void OrderPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Pick)
            {
                this.Text = "إختر طلبية";
            }
            else
            {
                this.Text = "إستعراض الطلبيات";
            }
            tsddlSearch.Visible = true;
            LoadCombo(tsddlSearch);
            tsddlSearch.SelectedIndexChanged += tsddlSearch_SelectedIndexChanged;
        }
        public static void LoadCombo(ToolStripComboBox cbo)
        {
            cbo.ComboBox.DataSource = Enum.GetValues(typeof(OrderState))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            cbo.ComboBox.DisplayMember = "Description";
            cbo.ComboBox.ValueMember = "value";
        }
    }
}
