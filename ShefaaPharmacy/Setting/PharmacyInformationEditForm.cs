using DataLayer.Enums;
using DataLayer;
using DataLayer.Enums;
using DataLayer.Services;
using DataLayer.Tables;
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
using System.Text.RegularExpressions;

namespace ShefaaPharmacy.setting
{
    public partial class PharmacyInformationEditForm : GeneralEditForm
    {
        PharmacyInformation Info;
        public PharmacyInformationEditForm()
        {
            InitializeComponent();
        }
        public PharmacyInformationEditForm(PharmacyInformation entity, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            Info = entity;
            FormOperation = formOperation;
            if (entity == null)
            {
                Text = "معلومات الصيدلية";
            }
            else
            {
                Text = "تعديل معلومات الصيدلية";
            }
            EditBindingSource.DataSource = Info;
        }

        private void EditBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            BindingEntityToControls();
        }
        private void BindingEntityToControls()
        {
            tbPharmacyName.DataBindings.Add("text", EditBindingSource, "PharmacyName");
            tbOwnerName.DataBindings.Add("text", EditBindingSource, "OwnerName");
            tbTel.DataBindings.Add("text", EditBindingSource, "Tel");
            tbCommercialNumber.DataBindings.Add("text", EditBindingSource, "CommercialRegisterNumber");
            tbAddress.DataBindings.Add("text", EditBindingSource, "Address");
            tbDescription.DataBindings.Add("text", EditBindingSource, "Description");

        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            if (!DescriptionFK.IsValid((EditBindingSource.Current as PharmacyInformation).PharmacyName))
            {
                _MessageBoxDialog.Show("يرجى إدخال اسم للصيدلية!!", MessageBoxState.Warning);
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
            tbPharmacyName.Focus();
            tbAddress.Focus();
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();

                PharmacyInformation newInfo = new PharmacyInformation
                {
                    PharmacyName = tbPharmacyName.Text,
                    OwnerName = tbOwnerName.Text,
                    Tel = tbTel.Text,
                    CommercialRegisterNumber = tbCommercialNumber.Text,
                    Address = tbAddress.Text,
                    Description = tbDescription.Text
                };

                using (var db = context)
                {
                    if (!db.PharmacyInformation.Any())
                    {
                        context.PharmacyInformation.Add(EditBindingSource.Current as PharmacyInformation);
                        context.SaveChanges();
                        _MessageBoxDialog.Show("تم إضافة معلومات الصيدلية", MessageBoxState.Done);
                        Close();
                    }
                    else
                    {
                        context.PharmacyInformation.Update(EditBindingSource.Current as PharmacyInformation);
                        context.SaveChanges();
                        _MessageBoxDialog.Show("تم تعديل معلومات الصيدلية", MessageBoxState.Done);
                        Close();
                    }
                }
                
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
            }
        }
        private void CheckKeys(object sender, KeyPressEventArgs e)
        {
            Regex phoneNumpattern = new Regex(@"\+[0-9]{3}\s+[0-9]{3}\s+[0-9]{5}\s+[0-9]{3}");
            if (phoneNumpattern.IsMatch(tbTel.Text))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // only allow one plus char
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbTel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-') && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }

            // only allow one plus char
            if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
