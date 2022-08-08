using DataLayer;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Tables;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
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
                        ShefaaPharmacyDbContext.ConStr = ConnectionManager.GetConnection(ConnectionManager.DataBasePrefex + tbName.Text);
                        ShefaaPharmacyDbContext.Migrate();

                        ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                        context.CreateStoredProcedure();
                        SqlConnection sqcon = new SqlConnection(ShefaaPharmacyDbContext.ConStr); sqcon.Open();
                        string query = "CREATE TABLE [dbo].[Medicines]([id][nchar](5) NOT NULL,[name][nvarchar](600) NULL,[company][nvarchar](600) NULL,[scientific_name][nvarchar](600) NULL,[caliber][nvarchar](600) NULL,[format_id_descr][nvarchar](600) NULL,[size][nvarchar](600) NULL,[BuyPrice][nvarchar](600) NULL,[SellPrice][nvarchar](600) NULL,[barcode][nvarchar](600) NULL) ON[PRIMARY];";
                        query += "CREATE TABLE[dbo].[FirstTimeArticles]([id][nchar](5) NOT NULL,[name][nvarchar](600) NULL,[InvoiceKind][nvarchar](600) NULL,[UnitIdDescr][nvarchar](600) NULL,[Price][nvarchar](600) NULL,[Quantity][int],[Total][nvarchar](600) NULL,[ExpiryDate][datetime2](7) NULL) ON[PRIMARY];";
                        query += "CREATE TABLE [dbo].[ExistStuff] ([id][int] IDENTITY(1,1) NOT NULL,[name] [nvarchar](600) NULL,[count] [int] NULL,[price] [int] NULL,[description] [nvarchar](600) NULL) ON [PRIMARY];";
                        query += "CREATE TABLE [dbo].[LastTimeArticles]([id] [int] identity(1,1) NOT NULL,[ArticleId] [int] NOT NULL,[Name] [nvarchar] (600) NOT NULL,[UnitId] [int] NOT NULL,[QuantityLeft] [int] NULL,[TotalPrice] [decimal] NULL,[CreationDate] [datetime2](7) NOT NULL)ON [PRIMARY];";
                        query += "CREATE TABLE [dbo].[ExpiryTransfeerDetail]([Id][int] IDENTITY(1, 1) NOT NULL,[ArticleIdDescr] [nvarchar](600) NOT NULL,[UnitIdDescr] [nvarchar](600) NOT NULL,[LeftQuantity] [nvarchar](600) NOT NULL,[ExpiryDate] [datetime2](7) NOT NULL,[TransQuantity] [nchar](10) NOT NULL,[Checked] [bit] NULL) ON[PRIMARY]";
                        query += "update Account set AccountGeneralId=8 where id=20";
                        query += "update Account set Name = 'مخزن الأدوية' where id=19";
                        query += "delete from Formats where id=1";
                        query += "delete from Company where id=1";
                        query += "delete from company where id in( 19 , 21 , 37 , 47 , 56 ) ";
                        SqlCommand cmd = new SqlCommand(query, sqcon);
                        cmd.ExecuteNonQuery();
                        context.Accounts.Add(new Account() { Name = "الأصول الثابتة", CategoryId = ConstantDataBase.AC_Asset, General = false, AccountGeneralId = 10, CreationBy = 2 });
                        context.Accounts.FirstOrDefault(x => x.Id == 20).Name = "مخزن المواد منتهية الصلاحية";
                        context.Accounts.Add(new Account() { Name = "الحسم", CategoryId = ConstantDataBase.AC_Profits, General = false, AccountGeneralId = 8, CreationBy = 2 });
                        context.Years.FirstOrDefault().Name = DateTime.Now.Year.ToString();
                        context.Years.FirstOrDefault().CreationDate = DateTime.Now;
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
                        sqcon.Close();
                    });

                    thread.Start();
                }
                catch (Exception ex)
                {
                    //_MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
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
