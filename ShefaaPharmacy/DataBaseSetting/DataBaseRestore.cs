using DataLayer;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ShefaaPharmacy.GeneralUI;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.SqlServer.Management.Smo;
using Database = Microsoft.SqlServer.Management.Smo.Database;
using System.Data.Odbc;
using System.Threading.Tasks;

namespace ShefaaPharmacy.DataBaseSetting
{
    public partial class DataBaseRestore : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        SqlCommand cmd;
        SqlConnection sqlCon;
        public DataBaseRestore()
        {
            InitializeComponent();
            var context = ShefaaPharmacyDbContext.GetCurrentContext();

            //string ConnectionString = @"Data Source=POST-5\SQLEXPRESS;Initial Catalog=TM_firstdb;Integrated Security=true;";
            //sqlCon = new SqlConnection(ConnectionString);
            //sqlCon.Open();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //string[] filePaths;
            //if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    tbPath.Text = folderBrowserDialog1.SelectedPath;
            //    filePaths = Directory.GetFiles(tbPath.Text, "*.BAk", SearchOption.AllDirectories);
            //    List<string> newarray = new List<string>();
            //    foreach (var item in filePaths)
            //    {
            //        string tmp = " ";
            //        try
            //        {
            //            tmp = item.Substring(item.LastIndexOf('\\') + 1);
            //            //tmp = tmp.Substring(tmp.IndexOf("_") + 1);
            //            //tmp = tmp.Remove(tmp.ToUpper().IndexOf(".BAK"));
            //            newarray.Add(tmp);
            //        }
            //        catch (Exception ex)
            //        {
            //            newarray.Add(tmp);
            //        }
            //    }
            //    cbBackUp.DataSource = newarray;
            //}
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName[0] == 'C')
                {
                    _MessageBoxDialog.Show("لايمكن الاسترداد من القرص C يرجى تحديد مسار اخر", MessageBoxState.Error);
                    return;
                }
                else
                {
                    tbPath.Text = dlg.FileName;
                    btnRestore.Enabled = true;

                    string tmp = tbPath.Text;
                    tmp = tmp.Substring(tmp.LastIndexOf('\\') + 1);
                    SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
                    
                    tmp = tmp.Remove(tmp.ToUpper().LastIndexOf("_"));
                    if (tmp != con.Database)
                    {
                        tbPath.Clear();
                        _MessageBoxDialog.Show("يرجى تسجيل الدخول الى قاعدة البيانات المراد استعادة نسخة منها", MessageBoxState.Error);
                        return;
                    }
                    tbDataBaseName.Text = tmp;
                }
            }
        }

        private void DataBaseRestore_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
            Resizable = false;
            btnRestore.Enabled = false;
            //cbBackUp.Enabled = false;
        }

        private async void BtnRestore_Click(object sender, EventArgs e)
        {
            btnRestore.Enabled = tbDataBaseName.Enabled = tbPath.Enabled = false;
            lblLoading.Visible = pcloader.Visible = true;
            try
            {
                await Task.Run(() => RestoreDB());
                this.Close();
            }
            catch
            {
                
            }
            
        }
        public void RestoreDB()
        {
            try
            {
                string ConnectionString = ShefaaPharmacyDbContext.ConStr;
                sqlCon = new SqlConnection(ConnectionString);
                sqlCon.Open();

                string con = ShefaaPharmacyDbContext.ConStr;

                string data = sqlCon.Database.ToString();
                string sqlStmt2 = string.Format("ALTER DATABASE [" + data + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, sqlCon);
                bu2.ExecuteNonQuery();

                string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + data + "] FROM DISK='" + tbPath.Text + "'WITH REPLACE;";
                SqlCommand bu3 = new SqlCommand(sqlStmt3, sqlCon);
                bu3.ExecuteNonQuery();

                string sqlStmt4 = string.Format("ALTER DATABASE [" + data + "] SET MULTI_USER");
                SqlCommand bu4 = new SqlCommand(sqlStmt4, sqlCon);
                bu4.ExecuteNonQuery();

                _MessageBoxDialog.Show("تم استرداد النسخة الإحتياطية بنجاح", MessageBoxState.Done);
                sqlCon.Close();
                //btnRestore.Enabled = true;
                //lblLoading.Visible = pcloader.Visible = false;
                
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء الاستعادة..تأكد من تسجيل الدخول الى قاعدة البيانات المراد استعادة نسخة منها", MessageBoxState.Error);
                //btnRestore.Enabled = true;
                //.Visible = pcloader.Visible = false;
            }
        }
        static void res_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            // do something......
        }

        private void tbDataBaseName_Validating(object sender, CancelEventArgs e)
        {
           
        }
    }
}            //            If My.Computer.FileSystem.FileExists(File) Then

        //        Using Cmd As New SqlCommand() With {.Connection = New SqlConnection("Data Source=.\sqlexpress;Initial Catalog=JoyBoxStaff;User ID=samer-a;Password=" & pASS)}

        //            Cmd.CommandTimeout = 900

        //            Cmd.CommandText = "use master;"
        //            Cmd.CommandText &= "alter database JoyBoxStaff set single_user with rollback immediate; "
        //            Cmd.CommandText &= "restore database JoyBoxStaff from disk='" & File & "' with replace;"
        //            Cmd.CommandText &= "alter database JoyBoxStaff set multi_user;"

        //            Cmd.Connection.Open()
        //            Dim r = Cmd.ExecuteNonQuery
        //            HttpContext.Current.Session("Message1") = "تمت عملية الاستعادة: " & r.ToString
        //            Cmd.Connection.Close()

        //        End Using
        //    Else
        //        Masterlbl1.Text = "فشلت الاستعادة ملف غير موجود أو لايمكن الوصول إليه"
        //    End If


        //Using Cmd As New SqlCommand() With {.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("JoyBoxStaff").ConnectionString)}

        //        Cmd.CommandTimeout = 900

        //        Dim Fnm As String = Server.MapPath("~\backup\" & Now.ToString("yyyy-MM-dd-HH-mm-ss") & ".bak")

        //        If My.Computer.FileSystem.FileExists(Fnm) Then
        //            My.Computer.FileSystem.DeleteFile(Fnm, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently)
        //        End If

        //        Cmd.CommandText = "backup database JoyBoxStaff to disk='" & Fnm & "'"

        //        Cmd.Connection.Open()
        //        Dim r = Cmd.ExecuteNonQuery

        //        Cmd.Connection.Close()


        //    End Using

