using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ShefaaPharmacy.Setting
{
    public partial class ServerSettingsForm : ShefaaPharmacy.GeneralUI.DialogForm
    {
        public ServerSettingsForm()
        {
            InitializeComponent();
            FillComponents();
        }

        private void btRefrash_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                cbServerName.Items.Clear();
                DataTable serversNames = ConnectionManager.GetServersAndInstancesNames();
                for (int i = 0; i < serversNames.Rows.Count; i++)
                {
                    cbServerName.Items.Add(serversNames.Rows[i][0].ToString() + "\\" + serversNames.Rows[i][1].ToString());
                }
                cbServerName.SelectedIndex = 0;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void FillComponents()
        {
            cbServerName.Text = ConnectionManager.ServerName;
            tbUserName.Text = ConnectionManager.Username;
            tbPassword.Text = ConnectionManager.Password;
            rbwindows.Checked = !ConnectionManager.ServerAuth;
            rbServer.Checked = ConnectionManager.ServerAuth;
        }

        private void btTestConn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlTestConn = new SqlConnection();
            sqlTestConn.Close();
            string dataBase = "master";
            try
            {
                if (rbwindows.Checked)
                {
                    sqlTestConn.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", cbServerName.Text, dataBase);
                }
                else
                {
                    sqlTestConn.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", cbServerName.Text, dataBase, tbUserName.Text, tbPassword.Text);
                }
                sqlTestConn.Open();
                _MessageBoxDialog.Show("تم الاتصال بنجاح", MessageBoxState.Done);
                sqlTestConn.Close();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("لم ينجح الاتصال يرجى التأكد من اسم المخدم واعادة المحاولة" , MessageBoxState.Error);
                //_MessageBoxDialog.Show("فشل الاتصال" + " .. " + ex.Message, MessageBoxState.Error);
                sqlTestConn.Close();
            }
        }

        private void rbwindows_CheckedChanged(object sender, EventArgs e)
        {
            tbUserName.Enabled = !rbwindows.Checked;
            tbPassword.Enabled = !rbwindows.Checked;
        }

        private void rbServer_CheckedChanged(object sender, EventArgs e)
        {
            tbUserName.Enabled = rbServer.Checked;
            tbPassword.Enabled = rbServer.Checked;
        }
        protected override void btOK_Click(object sender, EventArgs e)
        {
            ConnectionManager.ServerName = cbServerName.Text;
            ConnectionManager.Username = tbUserName.Text;
            ConnectionManager.Password = tbPassword.Text;
            ConnectionManager.ServerAuth = rbServer.Checked;
            if (!ConnectionManager.CanConnec())
            {
                if (_MessageBoxDialog.Show("لم يتمكن من الاتصال هل تريد المتابعة ؟",MessageBoxState.Answering)==MessageBoxAnswer.Yes)
                {
                    base.btOK_Click(sender, e);
                }
                else
                {
                    ConnectionManager.ServerName = "";
                    ConnectionManager.Username = "";
                    ConnectionManager.Password = "";
                    ConnectionManager.ServerAuth = false;
                }
            }
            else
            {
                ConnectionManager.SaveConnection();
                base.btOK_Click(sender, e);
            }
        }
        protected override void btCancel_Click(object sender, EventArgs e)
        {
            base.btCancel_Click(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
