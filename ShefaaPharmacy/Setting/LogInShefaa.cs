using DataLayer;
using DataLayer.Services;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ShefaaPharmacy.Setting
{
    public partial class LogInShefaa : Form
    {
        SqlConnection sqlConn;
        public LogInShefaa()
        {
            InitializeComponent();
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = ConnectionManager.GetConnection();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbDataBase.DropDownStyle = ComboBoxStyle.DropDownList;
                Cursor.Current = Cursors.WaitCursor;
                cbDataBase.Items.Clear();
                DataTable DBs = ConnectionManager.GetDataTable(sqlConn, @"SELECT  name,  Right(name, LEN(name) - 3) AS DBMask FROM SYSDATABASES WHERE name like '" + ConnectionManager.DataBasePrefex + "%'");
                cbDataBase.ValueMember = "name";
                cbDataBase.DisplayMember = "DBMask";
                cbDataBase.DataSource = DBs;
                if (DBs.Rows.Count > 0)
                {
                    string lastDB = ConnectionManager.LoadLastOpenedDB();
                    if (lastDB.Trim() != string.Empty)
                    {
                        for (int i = 0; i < cbDataBase.Items.Count; i++)
                        {
                            if ((cbDataBase.Items[i] as DataRowView)[0].ToString().Trim() == lastDB.Trim())
                            {
                                cbDataBase.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        cbDataBase.SelectedIndex = 0;
                    }
                    //ApplicationDeployment deploy = ApplicationDeployment.CurrentDeployment;
                    //UpdateCheckInfo update = deploy.CheckForDetailedUpdate();
                    //MessageBox.Show("You can update to version: " + update.AvailableVersion.ToString());

                    //ApplicationDeployment deploy = ApplicationDeployment.CurrentDeployment;
                    //UpdateCheckInfo update = deploy.CheckForDetailedUpdate();
                    //if (deploy.CheckForUpdate())
                    //{
                    //    MessageBox.Show("You can update to version: " + update.AvailableVersion.ToString());
                    //    deploy.Update();
                    //    Application.Restart();
                    //}
                }
                else
                {
                    _MessageBoxDialog.Show("لا يوجد أي قاعدة بيانات قم بإنشاء واحدة", MessageBoxState.Error);
                    Load += (s, es) => Close();
                    return;
                }
                tbPassword.Focus();
                this.ActiveControl = tbPassword;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }
        private void cbDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDataBase.SelectedIndex == -1)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShefaaPharmacyDbContext.ConStr = ConnectionManager.GetConnection(cbDataBase.SelectedValue.ToString());

                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                cbUserName.DataSource = null;
                cbUserName.Items.Clear();
                List<User> UserLst = null;
                try
                {
                    UserLst = context.Users.Where(x => x.Id == 2).ToList();
                    cbUserName.Items.Clear();
                    cbUserName.DataSource = UserLst;
                    cbUserName.DisplayMember = "Name";
                    cbUserName.ValueMember = "Id";
                    try
                    {
                        if (UserLst.Count() > 0)
                        {
                            cbUserName.SelectedIndex = 0;
                        }
                    }
                    catch {; }
                }
                catch (Exception ex)
                {
                    _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            ShefaaPharmacyDbContext.ConStr = ConnectionManager.GetConnection(cbDataBase.SelectedValue.ToString());
            ShefaaPharmacyDbContext.Migrate();
            ShefaaPharmacyDbContext.CheckVersion();
            Login login = Login.GetLogin();
            if (login.TryLogin(((User)cbUserName.SelectedItem).Name, tbPassword.Text))
            {
                ConnectionManager.SetLastOpenedDB(cbDataBase.SelectedValue.ToString());
                //this.Close();
                //this.Dispose();
                //Program.mainForm = new MainForm();
                //Program.mainForm.ShowDialog();
                DescriptionFK.LoadImportantDataForImages();
                this.Close();
            }
            else
            {
                _MessageBoxDialog.Show("خطأ في اسم المستخدم أو كلمة المرور", MessageBoxState.Error);
            }
        }
        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btOK_Click(sender, e);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void LogInShefaa_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void LogInShefaa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void pbClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
