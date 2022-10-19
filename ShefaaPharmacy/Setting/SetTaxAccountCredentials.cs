using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ShefaaPharmacy.Setting
{
    public partial class SetTaxAccountCredentials : ShefaaPharmacy.GeneralUI.DialogForm
    {
        public SetTaxAccountCredentials()
        {
            InitializeComponent();
            InitializeMyControl();
        }
        private void InitializeMyControl()
        {
            // Set to no text.
            tbPassword.Text = "";
            // The password character is an asterisk.
            tbPassword.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            tbPassword.MaxLength = 14;
            // The control will allow no less than 8 characters.
            //tbPassword.MinimumSize = 8;
        }

        protected override void btOK_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (_MessageBoxDialog.Show("هل انت متأكد من صحة هذه المعلومات ", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                {
                    try
                    {
                        var context = ShefaaPharmacyDbContext.GetCurrentContext();

                        TaxAccount NewAcount = new TaxAccount
                        {
                            username = tbUserName.Text,
                            password = tbPassword.Text,
                            taxNumber = tbTaxNumber.Text
                        };
                        CheckLoginCredentials(NewAcount);
                        context.TaxAccount.Add(NewAcount);
                        context.SaveChanges();
                        _MessageBoxDialog.Show("تمت الإضافة بنجاح", MessageBoxState.Done);
                    }
                    catch (Exception ex)
                    {
                        _MessageBoxDialog.Show("هناك خطأ في المعلومات المدخلة", MessageBoxState.Error);
                        return;
                    }
                }
                else
                {

                }
            }

        }
        protected override void btCancel_Click(object sender, EventArgs e)
        {
            base.btCancel_Click(sender, e);
        }
        private bool CheckLoginCredentials(TaxAccount NewAcount)
        {
            //{
            //    "username": "testpos2",
            //    "password": "A@123456789",
            //    "taxNumber": "000000100000"
            //}
            HttpClient client = new HttpClient();
            Uri baseAddress = new Uri("http://213.178.227.75/Taxapi/api/account/AccountingSoftwarelogin");
            client.BaseAddress = baseAddress;

            var response =  client.PostAsync(baseAddress, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(NewAcount), Encoding.UTF8,"application/json"));
            
            return false;
        }
        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                e.Cancel = true;
                tbPassword.Focus();
                errorProviderApp.SetError(tbPassword, "Password should not be empty!");
            }
            else if (tbPassword.Text.Length < 8)
            {
                e.Cancel = true;
                tbPassword.Focus();
                errorProviderApp.SetError(tbPassword, "Password should be greater than 8 chars!");
            }
            else
            {
                e.Cancel = false;
                errorProviderApp.SetError(tbPassword, "");
            }
        }

        private void SetTaxAccountCredentials_Load(object sender, EventArgs e)
        {

        }

        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbUserName.Text))
            {
                e.Cancel = true;
                tbPassword.Focus();
                errorProviderApp.SetError(tbUserName, "UserName should not be empty!");
            }
            else
            {
                e.Cancel = false;
                errorProviderApp.SetError(tbUserName, "");
            }
        }

        private void tbTaxNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbTaxNumber.Text))
            {
                e.Cancel = true;
                tbPassword.Focus();
                errorProviderApp.SetError(tbTaxNumber, "TaxNumber should not be empty!");
            }
            else
            {
                e.Cancel = false;
                errorProviderApp.SetError(tbTaxNumber, "");
            }
        }
    }
}
