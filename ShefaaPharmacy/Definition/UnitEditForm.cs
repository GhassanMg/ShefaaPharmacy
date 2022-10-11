using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ShefaaPharmacy.Definition
{
    public partial class UnitEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        UnitType unitType;
        public UnitEditForm()
        {
            InitializeComponent();
        }
        public UnitEditForm(UnitType entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            unitType = entity;
            FormOperation = formOperation;
            if (entity.Id == 0)
            {
                this.Text = "تعريف كمية";
            }
            else
            {
                this.Text = "تعديل كمية";
            }
            EditBindingSource.DataSource = unitType;
        }
        public static UnitType CreateUnitType(UnitType unitType, FormOperation formOperation = FormOperation.New)
        {
            UnitEditForm fmEdit = new UnitEditForm(unitType, formOperation);
            try
            {
                fmEdit.Text = "تعريف كمية";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return fmEdit.unitType;
            }
            finally
            {
                fmEdit.Dispose();
            }
        }
        protected override void BindingEntityToControls()
        {
            base.BindingEntityToControls();
            tbUnitName.DataBindings.Add("text", EditBindingSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                base.btOk_Click(sender, e);
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                {
                    context.UnitTypes.Add(EditBindingSource.Current as UnitType);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة كمية جديد", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    context.UnitTypes.Update(EditBindingSource.Current as UnitType);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات الكمية", MessageBoxState.Done);
                    if (FormOperation == FormOperation.EditFromPicker)
                    {
                        Close();
                    }
                }
                EditBindingSource.AddNew();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
            }
        }

        private void EditBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            unitType = new UnitType();
            e.NewObject = unitType;
        }

        private void UnitEditForm_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                this.Text = "تعريف كمية جديدة";
            }
            else
            {
                this.Text = "تعديل كمية";
            }
        }
    }
}
