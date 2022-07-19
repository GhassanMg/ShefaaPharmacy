
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System.Reflection;

namespace ShefaaPharmacy.Setting
{
    public partial class DBConfigEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        DataBaseConfiguration DataBaseConfiguration;

        public DBConfigEditForm()
        {
            InitializeComponent();
            FormOperation = FormOperation.New;
            DataBaseConfiguration = ShefaaPharmacyDbContext.GetCurrentContext().DataBaseConfigurations.FirstOrDefault();
            EditBindingSource.DataSource = this.DataBaseConfiguration;
        }
        public DBConfigEditForm(DataBaseConfiguration dataBaseConfiguration, FormOperation formOperation = FormOperation.New)
        {
            FormOperation = formOperation;
            DataBaseConfiguration = dataBaseConfiguration;
            EditBindingSource.DataSource = this.DataBaseConfiguration;
        }
        protected override void BindingEntityToControls()
        {
            base.BindingEntityToControls();
            //tbAccountTaxIdDescr.DataBindings.Add("text", EditBindingSource, "AccountTaxIdDescr", true, DataSourceUpdateMode.OnPropertyChanged);
            //tbDateIfNotUpdatedExternal.DataBindings.Add("text", EditBindingSource, "DateIfNotUpdatedExternal", true, DataSourceUpdateMode.OnPropertyChanged, "N");
            //tbDateIfNotUpdatedLocal.DataBindings.Add("text", EditBindingSource, "DateIfNotUpdatedLocal", true, DataSourceUpdateMode.OnPropertyChanged, "N");
            tbDayForExpiry.DataBindings.Add("text", EditBindingSource, "DayForExpiry", true, DataSourceUpdateMode.OnPropertyChanged, "N");
            //tbVersion.DataBindings.Add("text", EditBindingSource, "VersionNumber", true, DataSourceUpdateMode.OnPropertyChanged);
            //tbDiscountPercentage.DataBindings.Add("text", EditBindingSource, "DiscountPercentage", true, DataSourceUpdateMode.OnPropertyChanged, "N");
            //tbTaxValue.DataBindings.Add("text", EditBindingSource, "TaxValue", true, DataSourceUpdateMode.OnPropertyChanged, "N");
            //.DataBindings.Add("text", EditBindingSource, "ValueSellPrice", true, DataSourceUpdateMode.OnPropertyChanged, "N");

            //tbRoundToNearest.DataBindings.Add("text", EditBindingSource, "RoundToNearest", true, DataSourceUpdateMode.OnPropertyChanged, "N");
            tbCountNumberAfterComma.DataBindings.Add("text", EditBindingSource, "CountNumberAfterComma", true, DataSourceUpdateMode.OnPropertyChanged, "N");
        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                base.btOk_Click(sender, e);
            }
            catch (Exception)
            {
                ;
            }
            try
            {
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                {
                    context.DataBaseConfigurations.Update(DataBaseConfiguration);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تمت العملية بنجاح", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                }
                else
                {
                    context.DataBaseConfigurations.Update(DataBaseConfiguration);
                    context.SaveChanges();
                    _MessageBoxDialog.Show("تم تعديل إعدادات قاعدة البيانات" + "\n" + "يجب إعادة تسجيل الدخول", MessageBoxState.Done);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void DBConfigEditForm_Load(object sender, EventArgs e)
        {
            tbVersion.Text = "A" + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString();
        }
    }
}
