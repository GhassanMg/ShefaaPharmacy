using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.Definition
{
    public partial class FormatEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        Format format;
        public FormatEditForm()
        {
            InitializeComponent();
        }
        public FormatEditForm(Format entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            format = entity;
            FormOperation = formOperation;
            if (entity.Id == 0)
            {
                this.Text = "تعريف شكل";
            }
            else
            {
                this.Text = "تعديل شكل";
            }
            EditBindingSource.DataSource = format;
            ((Format)EditBindingSource.DataSource).onUpdateForm += InitEntity_onUpdateForm;
        }
        private void InitEntity_onUpdateForm()
        {
            EditBindingSource.ResetCurrentItem();
        }
        public static Format CreateFormat(Format format, FormOperation formOperation = FormOperation.New)
        {
            FormatEditForm fmEdit = new FormatEditForm(format, formOperation);
            try
            {
                fmEdit.Text = "تعريف شكل";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return fmEdit.format;
            }
            finally
            {
                fmEdit.Dispose();
            }
        }
        protected override void BindingEntityToControls()
        {
            base.BindingEntityToControls();
            tbFormatName.DataBindings.Add("text", EditBindingSource, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
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
                    context.Formats.Add(EditBindingSource.Current as Format);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة شكل جديد", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    context.Formats.Update(EditBindingSource.Current as Format);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات الشكل", MessageBoxState.Done);
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
            format= new Format();
            e.NewObject = format;
        }

        private void FormatEditForm_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                this.Text = "إضافة شكل جديد";
            }
            else
            {
                this.Text = "تعديل شكل";
            }
        }
    }
}
