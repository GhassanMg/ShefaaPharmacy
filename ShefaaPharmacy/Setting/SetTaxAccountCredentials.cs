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
using System.Net;
using System.IO;
using static ShefaaPharmacy.MainForm;
using Newtonsoft.Json.Linq;

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

                        TaxAccount NewAccount = new TaxAccount
                        {
                            username = tbUserName.Text,
                            password = tbPassword.Text,
                            taxNumber = tbTaxNumber.Text
                        };
                        LoginExternalAsync(NewAccount);
                        CheckLoginCredentials(NewAccount);
                        context.TaxAccount.Add(NewAccount);
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
        private void LoginExternalAsync(TaxAccount NewAccount)
        {
            try
            {
                //Default Account For Test
                TaxAccount myaccount = new TaxAccount
                {
                    username = "testpos2",
                    password = "A@123456789",
                    taxNumber = "000000100000"
                };
                //*
                string url = String.Format("http://213.178.227.75/Taxapi/api/account/AccountingSoftwarelogin");

                WebRequest requestPost = WebRequest.Create(url);
                requestPost.Method = "POST";
                requestPost.ContentType = "application/json";

                var postData = JsonConvert.SerializeObject(myaccount);
                using (var streamWriter = new StreamWriter(requestPost.GetRequestStream()))
                {
                    streamWriter.Write(postData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = requestPost.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var res = streamReader.ReadToEnd();
                    var resultJson = JsonConvert.DeserializeObject(res);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                return;
            }
        }
        private bool CheckLoginCredentials(TaxAccount NewAccount)
        {
            try
            {
                string NewTaxAccount = JsonConvert.SerializeObject(NewAccount);
                string url = "http://213.178.227.75/Taxapi/api/account/AccountingSoftwarelogin";
                string data = "username=testpos2&password=A@123456789&taxNumber: 000000100000";

                TaxAccount jo = JsonConvert.DeserializeObject<TaxAccount>(NewTaxAccount);

                ///NewTaxAccount.Property("id").Remove();
                //var splitted = NewTaxAccount.Split(',');
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] data1 = encoder.GetBytes(NewTaxAccount); // a json object, or xml, whatever...

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data1.Length;
                request.Expect = "application/json";

                request.GetRequestStream().Write(data1, 0, data.Length);

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;






                var webRequest1 = (HttpWebRequest)WebRequest.Create("http://213.178.227.75/Taxapi/api/account/AccountingSoftwarelogin");
                webRequest1.Method = "POST";
                var webResponse1 = (HttpWebResponse)webRequest1.GetResponse();
                var reader1 = new StreamReader(webResponse1.GetResponseStream());
                string s1 = reader1.ReadToEnd();
                Root x1 = JsonConvert.DeserializeObject<Root>(s1);

                byte[] dataStream = Encoding.UTF8.GetBytes(data);
                var webRequest = WebRequest.Create("http://213.178.227.75/Taxapi/api/account/AccountingSoftwarelogin");

                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = dataStream.Length;
                Stream newStream = webRequest.GetRequestStream();
                // Send the data.
                newStream.Write(dataStream, 0, dataStream.Length);
                newStream.Close();
                WebResponse webResponse = webRequest.GetResponse();

                //var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                Root x = JsonConvert.DeserializeObject<Root>(s);
                if (x.data != null)
                {
                    int Version = Convert.ToInt32(x.data.version_number);
                    //DownloadPath = x.data.file;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                return false;
            }

            ////{
            ////    "username": "testpos2",
            ////    "password": "A@123456789",
            ////    "taxNumber": "000000100000"
            ////}

            //HttpWebRequest client = (HttpWebRequest)WebRequest.Create("http://213.178.227.75/Taxapi/api/account/AccountingSoftwarelogin");

            //client.ContentType = "application/soap+xml";
            //client.Method = "POST";
            ////HttpClient client = new HttpClient();
            ////Uri baseAddress = new Uri("http://213.178.227.75/Taxapi/api/account/AccountingSoftwarelogin");
            ////client.BaseAddress = baseAddress;

            //var response =  client.PostAsync(baseAddress, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(NewAcount), Encoding.UTF8,"application/json"));

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
