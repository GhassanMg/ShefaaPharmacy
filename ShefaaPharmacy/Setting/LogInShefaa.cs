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
using System.Threading;

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
                cbDataBase.DropDownStyle = ComboBoxStyle.DropDownList;
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
        private void CbDataBase_SelectedIndexChanged(object sender, EventArgs e)
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
            if (cbDataBase.SelectedIndex == -1)
            {
                _MessageBoxDialog.Show("لا يوجد أي قاعدة بيانات قم بإنشاء واحدة", MessageBoxState.Error);
                return;
            }
            ShefaaPharmacyDbContext.ConStr = ConnectionManager.GetConnection(cbDataBase.SelectedValue.ToString());
            ShefaaPharmacyDbContext.Migrate();
            ShefaaPharmacyDbContext.CheckVersion();
            Login login = Login.GetLogin();
            if (login.TryLogin(((User)cbUserName.SelectedItem).Name, tbPassword.Text))
            {
                ConnectionManager.SetLastOpenedDB(cbDataBase.SelectedValue.ToString());
                DescriptionFK.LoadImportantDataForImages();
                this.Close();
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                if (!context.TaxAccount.Any())
                {
                    _MessageBoxDialog.Show("يرجى تسجيل معلومات الحساب الضريبي", MessageBoxState.Alert);
                    SetTaxAccountCredentials TaxAccountCred = new SetTaxAccountCredentials();
                    TaxAccountCred.ShowDialog();
                }
                else
                {
                    var thread = new Thread(() =>
                    {
                        SetTaxAccountCredentials Credentials = new SetTaxAccountCredentials();
                        var CurrentAccount = context.TaxAccount.ToList().FirstOrDefault();
                        Credentials.LoginToRefreshToken(CurrentAccount);
                    });
                    thread.Start();
                }
            }
            else
            {
                _MessageBoxDialog.Show("خطأ في اسم المستخدم أو كلمة المرور", MessageBoxState.Error);
            }
        }
        private void TbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btOK_Click(sender, e);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
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
