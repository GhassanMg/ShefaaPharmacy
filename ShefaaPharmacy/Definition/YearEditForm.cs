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
    public partial class YearEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        Year year;
        public YearEditForm()
        {
            InitializeComponent();
        }
        public YearEditForm(Year entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            year = entity;
            FormOperation = formOperation;
            if (entity.Id == 0)
            {
                this.Text = "تعريف سنة مالية";
            }
            else
            {
                this.Text = "تعديل سنة مالية";
            }
            EditBindingSource.DataSource = year;
        }
        public static Year CreateYear(Year year, FormOperation formOperation = FormOperation.New)
        {
            YearEditForm fmEdit = new YearEditForm(year, formOperation);
            try
            {
                fmEdit.Text = "تعريف سنة مالية";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return fmEdit.year;
            }
            finally
            {
                fmEdit.Dispose();
            }
        }
        protected override void BindingEntityToControls()
        {
            base.BindingEntityToControls();
            tbName.DataBindings.Add("text", EditBindingSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            dtCreationDate.DataBindings.Add("text", EditBindingSource, "CreationDate", false, DataSourceUpdateMode.OnPropertyChanged);//,true, DataSourceUpdateMode.OnValidation,"", "dd-MM-yyyy"
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
                    context.Years.Add(year);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة سنة مالية جديدة", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    context.Years.Update(year);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات السنة المالية", MessageBoxState.Done);
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
        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EditBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            year = new Year();
            e.NewObject = year;
        }

        private void YearEditForm_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                this.Text = "تعريف سنة مالية جديدة";
            }
            else
            {
                this.Text = "تعديل معلومات سنة مالية";
            }
        }
    }
}
