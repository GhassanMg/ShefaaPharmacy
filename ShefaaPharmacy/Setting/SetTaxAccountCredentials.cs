using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ShefaaPharmacy.Setting
{
    public partial class SetTaxAccountCredentials : ShefaaPharmacy.GeneralUI.DialogForm
    {
        string Token = " ";
        string FacilityName;
        public SetTaxAccountCredentials()
        {
            InitializeComponent();
            InitializeMyControl();
        }
        
        public void LoginToRefreshToken(TaxAccount NewAccount)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            NewAccount.password = DecodeFrom64(NewAccount.password);
            bool token = LoginExternal(NewAccount);
            if (!token) return;
            var Current = context.TaxAccount.ToList().FirstOrDefault();
            Current.Token = Token;
            context.SaveChanges();
        }

        private void InitializeMyControl()
        {
            // Set to no text.
            tbPassword.Text = "";
            // The password character is an asterisk.
            tbPassword.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            tbPassword.MaxLength = 14;
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
                        bool token = LoginExternal(NewAccount);
                        if (!token) return;
                        NewAccount.password = EncodePasswordToBase64(NewAccount.password);
                        NewAccount.Token = Token;
                        NewAccount.facilityName = FacilityName;
                        context.TaxAccount.Add(NewAccount);
                        context.SaveChanges();
                        _MessageBoxDialog.Show("تمت الإضافة بنجاح", MessageBoxState.Done);
                        Close();
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
        private bool LoginExternal(TaxAccount NewAccount)
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                string url = String.Format("http://213.178.227.75/Taxapi/api/account/AccountingSoftwarelogin");
                WebRequest requestPost = WebRequest.Create(url);
                requestPost.Method = "POST";
                requestPost.ContentType = "application/json";

                var postData = JsonConvert.SerializeObject(NewAccount);
                using (var streamWriter = new StreamWriter(requestPost.GetRequestStream()))
                {
                    streamWriter.Write(postData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)requestPost.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    int code = (int)httpResponse.StatusCode;
                    var res = streamReader.ReadToEnd();
                    bool succeed;
                    JObject resultJson = (JObject)JsonConvert.DeserializeObject(res);
                    IList<string> keys = resultJson.Properties().Select(p => p.Name).ToList();
                    if (resultJson["data"] == null)
                    {
                        succeed = (bool)resultJson["succeed"];
                        _MessageBoxDialog.Show("هناك خطأ في المدخلات يرجى إعادة تسجيل معلومات الحساب الضريبي مرة أخرى", MessageBoxState.Error);
                        return false;
                    }
                    JObject data = (JObject)resultJson["data"];
                    FacilityName = data["facilityName"].ToString();
                    string token = data["token"].ToString();
                    string[] splitted = token.Split(' ');
                    token = splitted[1];
                    Token = token;
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The operation has timed out")
                {
                    _MessageBoxDialog.Show("هناك مشكلة في المخدم يرجى المحاولة لاحقاً ", MessageBoxState.Error);
                    Close();
                    return false;
                }
                _MessageBoxDialog.Show("يرجى التأكد من اتصالك بالإنترنت واعادة المحاولة", MessageBoxState.Error);
                return false;
            }
        }
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        //this function Convert to Decord your Password
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
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
