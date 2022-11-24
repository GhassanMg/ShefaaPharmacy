using DataLayer;
using ShefaaPharmacy.Helper;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace ShefaaPharmacy.GeneralUI
{
    public partial class CreateDataBaseForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public CreateDataBaseForm()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                _MessageBoxDialog.Show("يجب إدخال اسم لقاعدة البيانات", MessageBoxState.Error);
            }
            else
            {
                try
                {
                    string DBname = tbName.Text;
                    //DBname = DBname.Substring(DBname.LastIndexOf('\\') + 1);
                    //SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);

                    //DBname = DBname.Remove(DBname.ToUpper().LastIndexOf("_"));
                    if (CheckDatabaseExists(DBname))
                    {
                        tbName.Clear();
                        _MessageBoxDialog.Show("يوجد قاعدة بيانات بنفس الاسم في هذا الجهاز", MessageBoxState.Error);
                        return;
                    }
                }
                catch
                {

                }
                try
                {
                    lbDots.Visible = true;
                    lbMassege.Visible = true;
                    tbName.Enabled = false;
                    timer1.Enabled = true;
                    var thread = new Thread(() =>
                    {
                        var OldConnectionString = ShefaaPharmacyDbContext.ConStr;
                        ShefaaPharmacyDbContext.ConStr = ConnectionManager.GetConnection(ConnectionManager.DataBasePrefex + tbName.Text);
                        ShefaaPharmacyDbContext.Migrate();

                        ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                        context.CreateStoredProcedure();
                        //SqlConnection sqcon = new SqlConnection(ShefaaPharmacyDbContext.ConStr); sqcon.Open();
                        //string query = "CREATE TABLE [dbo].[LastTimeArticles]([id] [int] identity(1,1) NOT NULL,[ArticleId] [int] NOT NULL,[Name] [nvarchar] (600) NOT NULL,[UnitId] [int] NOT NULL,[QuantityLeft] [float] NULL,[TotalPrice] [decimal] NULL,[CreationDate] [datetime2](7) NOT NULL)ON [PRIMARY];";
                        //SqlCommand cmd = new SqlCommand(query, sqcon);
                        //cmd.ExecuteNonQuery();
                        //sqcon.Close();
                        context.SaveChanges();
                        _MessageBoxDialog.Show("تم إنشاء قاعدة البيانات بنجاح", MessageBoxState.Done);
                        if (lbDots.InvokeRequired)
                        {
                            lbDots.Invoke(new MethodInvoker(delegate
                            {
                                lbDots.Visible = false;
                                lbMassege.Visible = false;
                                tbName.Enabled = true;
                                tbName.Text = "";
                                timer1.Enabled = false;
                            }));
                        }
                        ShefaaPharmacyDbContext.ConStr = OldConnectionString;

                    });

                    thread.Start();
                }
                catch (Exception ex)
                {
                    _MessageBoxDialog.Show("حدث خطأ, يرجى اعادة العملية", MessageBoxState.Error);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lbDots.Text.Length > 5)
            {
                lbDots.Text = ".";
            }
            else
            {
                lbDots.Text += ".";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateDataBaseForm_Load(object sender, EventArgs e)
        {

        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {

        }

        public static bool CheckDatabaseExists(string dataBase)
        {
            string conStr = ShefaaPharmacyDbContext.ConStr;
            string cmdText = "SELECT * FROM master.dbo.sysdatabases WHERE name ='" + ConnectionManager.DataBasePrefex + dataBase + "'";
            bool isExist = false;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        isExist = reader.HasRows;
                    }
                }
                con.Close();
            }
            return isExist;
        }
    }
}
