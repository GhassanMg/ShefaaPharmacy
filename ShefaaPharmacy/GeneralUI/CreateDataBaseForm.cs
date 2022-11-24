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
                catch (Exception)
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
            Close();
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
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
