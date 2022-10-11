using DataLayer;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.DataBaseSetting
{
    public partial class DataBaseBackUp : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        SqlCommand cmd;
        SqlConnection sqlCon;

        public DataBaseBackUp()
        {
            InitializeComponent();
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            sqlCon = new SqlConnection(context.Database.GetDbConnection().ConnectionString);
            sqlCon.Open();
            FillDataBaseNames();
        }

        void FillDataBaseNames()
        {

            SqlConnection sqlConn;
            sqlConn = new SqlConnection();
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            sqlConn.ConnectionString = context.Database.GetDbConnection().ConnectionString;
            Cursor.Current = Cursors.WaitCursor;
            cbDataBase.Items.Clear();
            DataTable DBs = ConnectionManager.GetDataTable(sqlCon, @"SELECT  name,  Right(name, LEN(name) - 3) AS DBMask FROM SYSDATABASES WHERE name like '" + ConnectionManager.DataBasePrefex + "%'");
            cbDataBase.ValueMember = "name";
            cbDataBase.DisplayMember = "DBMask";
            cbDataBase.DataSource = DBs;
            if (DBs.Rows.Count <= 0)
            {
                _MessageBoxDialog.Show("لا يوجد أي قاعدة بيانات قم بإنشاء واحدة", MessageBoxState.Error);
                Load += (s, es) => Close();
                return;
            }
        }
        private async void PbOk_Click(object sender, EventArgs e)
        {
            if (tbPath.Text == string.Empty)
            {
                _MessageBoxDialog.Show("يجب تحديد مسار لحفظ النسخة الاحتياطية", MessageBoxState.Error);
                return;
            }
            //if()
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                lblLoading.Visible = true;
                pbOk.Enabled = false;
                try
                {
                    await Task.Run(() => RunBackUp());
                    this.Close();
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                //_MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);

            }

        }
        private void RunBackUp()
        {
            try
            {
                cmd = new SqlCommand("BACKUP DATABASE @name TO DISK = @fileName", sqlCon);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", cbDataBase.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@fileName", tbPath.Text + "\\" + cbDataBase.SelectedValue.ToString() + "_" + DateTime.Now.Ticks + ".BAK"); // Your Database Name  
                cmd.ExecuteNonQuery();
                _MessageBoxDialog.Show("تم حفظ النسخة الإحتياطية بنجاح", MessageBoxState.Done);
            }
            catch
            {
                _MessageBoxDialog.Show("حدث خطأ,قد تكون قاعدة البيانات قيد الاستخدام, يرجى اغلاق الواجهة واعادة العملية", MessageBoxState.Error);
            }
        }
        private void DataBaseBackUp_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
            this.Resizable = false;
            pbOk.Enabled = false;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.SelectedPath[0] == 'C')
                {
                    _MessageBoxDialog.Show("لايمكن النسخ في القرص C يرجى تحديد مسار اخر", MessageBoxState.Error);
                    return;
                }
                else
                {
                    tbPath.Text = dlg.SelectedPath;
                    pbOk.Enabled = true;
                }

            }
        }

        private void lblLoading_Click(object sender, EventArgs e)
        {

        }
    }
}
