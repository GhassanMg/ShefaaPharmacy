using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ShefaaPharmacy.Public
{
    public partial class CompanyEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        Company company;
        public CompanyEditForm()
        {
            btnMaximaizing.Enabled = false;
            InitializeComponent();
        }
        public CompanyEditForm(Company entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            btnMaximaizing.Enabled = false;
            company = entity;
            FormOperation = formOperation;
            if (entity.Id == 0)
            {
                this.Text = "إضافة مستودع أدوية";
            }
            else
            {
                this.Text = "تعديل مستودع أدوية ";
            }
            EditBindingSource.DataSource = company;
        }
        public static Company CreateCompany(Company company, FormOperation formOperation = FormOperation.New)
        {
            CompanyEditForm fmEdit = new CompanyEditForm(company, formOperation);
            try
            {
                fmEdit.Text = "إضافة مستودع أدوية";
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return (Company)fmEdit.CurrentEntity;
            }
            finally
            {
                fmEdit.Dispose();
            }
        }
        protected override void BindingEntityToControls()
        {
            base.BindingEntityToControls();
            tbCompanyName.DataBindings.Add("text", EditBindingSource, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            tbLocationCompany.DataBindings.Add("text", EditBindingSource, "Location", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
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
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (company.Name.Trim() == "")
                {
                    _MessageBoxDialog.Show("يرجى تعبئة الاسم", MessageBoxState.Error);
                    return;
                }
                if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                {
                    context.Companys.Add(company);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة مستودع أدوية جديد", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    context.Companys.Update(company);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل معلومات مستودع الأدوية", MessageBoxState.Done);
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
            company = new Company();
            e.NewObject = company;
        }
        private void CompanyEditForm_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
            if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
            {
                this.Text = "تعريف مستودع أدوية";
            }
            else
            {
                this.Text = "تعديل مستودع أدوية";
            }
        }
    }
}
