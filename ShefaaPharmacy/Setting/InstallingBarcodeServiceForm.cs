using ShefaaPharmacy.Helper;
using System;
using System.Windows.Forms;

namespace ShefaaPharmacy.Setting
{
    public partial class InstallingBarcodeServiceForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public InstallingBarcodeServiceForm()
        {
            InitializeComponent();
        }
        private void InstallingBarcodeServiceForm_Load(object sender, EventArgs e)
        {
            tbInstallUtil.Text = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\";
        }
        private void LbPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                tbPath.Text = folderBrowserDialog1.SelectedPath;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!HelperUI.IsAdministrator)
            {
                MessageBox.Show("Need Administrator privilege!");
                return;
            }
            HelperUI.ExecuteCommandAsAdmin($"cd \"C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\" @ installutil.exe \"{ folderBrowserDialog1.SelectedPath + "\\ShefaaBarcodeService.exe"}");
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            HelperUI.ExecuteCommandAsAdmin("net start WebAPISelfHosting");
            HelperUI.ExecuteCommandAsAdmin("Start-Service -Name WebAPISelfHosting");
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!HelperUI.IsAdministrator)
            {
                MessageBox.Show("Need Administrator privilege!");
                return;
            }
            HelperUI.ExecuteCommandAsAdmin($"cd \"C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\" @ installutil.exe /u \"{ folderBrowserDialog1.SelectedPath + "\\ShefaaBarcodeService.exe\""}");
        }
        private void BtnUpdateIp_Click(object sender, EventArgs e)
        {
            RDSFECXA__WEWDSA.SetIpAddressForApiBarcode(tbAddress.Text, tbPort.Text);
        }
        private void BtnOpenPort_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbPort.Text))
            {
                if (!HelperUI.IsAdministrator)
                {
                    MessageBox.Show("Need Administrator privilege!");
                    return;
                }
                HelperUI.ExecuteCommandAsAdmin("netsh advfirewall firewall add rule name=\"AAATest" + tbPort.Text + "\" dir=in action=allow protocol=TCP localport=" + tbPort.Text + "");
            }
        }
    }
}
