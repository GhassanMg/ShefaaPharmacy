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
    public partial class BranchEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        Branch branch;
        public BranchEditForm()
        {
            InitializeComponent();
        }
        public BranchEditForm(Branch entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            branch = entity;
            FormOperation = formOperation;
            if (entity.Id == 0)
            {
                this.Text = "تعريف فرع";
            }
            else
            {
                this.Text = "تعديل فرع";
            }
            EditBindingSource.DataSource = branch;
        }
        public static Branch CreateBranch(Branch branch, FormOperation formOperation = FormOperation.New)
        {
            BranchEditForm fmEdit = new BranchEditForm(branch,formOperation);
            try
            {
                fmEdit.Text = "تعريف فرع";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return fmEdit.branch;
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
                    context.Branches.Add(EditBindingSource.Current as Branch);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة فرع جديد", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker )
                    {
                        Close();
                    }
                }
                else
                {
                    context.Branches.Update(EditBindingSource.Current as Branch);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات فرع", MessageBoxState.Done);
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
            branch = new Branch();
            e.NewObject = branch;
        }

        private void BranchEditForm_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
        }
    }
}
