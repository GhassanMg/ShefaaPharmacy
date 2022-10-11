using Microsoft.Win32;
using ShefaaPharmacy.GeneralUI;
using System;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace ShefaaPharmacy.Helper
{
    public class ConnectionManager
    {
        public static string ApplicationName = "ShefaaPharmacyApplication";
        public static string DataBasePrefex = "TM_";
        public static string ServerName = string.Empty;
        public static string Username = string.Empty;
        public static string Password = string.Empty;
        public static string DataBase = string.Empty;
        public static string DefaultDataBase = "TM_ShefaaPharmacy";
        public static string DefaultUsername = "admin";
        public static string DefaultPassword = "admin";
        public static bool ServerAuth = true;
        public static bool Connected = false;
        public static int Language = 0;
        public static string ConnStr = "";
        public static DataTable GetServersAndInstancesNames()
        {
            //ColumnsNames is "ServerName","InstanceName","IsClustered","Version"
            DataTable serversList;
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            serversList = instance.GetDataSources();
            return serversList;
        }
        //public static string LoadDataBase()
        //{
        //    try
        //    {
        //        RegistryKey MTAppkey = Registry.CurrentUser.OpenSubKey(@"Software\" + ApplicationName);
        //        DataBase = MTAppkey.GetValue("DataBase").ToString();

        //    }
        //    catch (Exception)
        //    {
        //        return "";
        //    }
            
        //}
        public static bool LoadConnection()
        {
            try
            {
                RegistryKey MTAppkey = Registry.CurrentUser.OpenSubKey(@"Software\" + ApplicationName);
                ServerName = MTAppkey.GetValue("ServerName").ToString();
                Username = MTAppkey.GetValue("UserName").ToString();
                Password = MTAppkey.GetValue("Password").ToString();
                DataBase = MTAppkey.GetValue("DataBase").ToString();
                ServerAuth = (MTAppkey.GetValue("ServerAuth").ToString() == "1");
                Language = Convert.ToInt32(MTAppkey.GetValue("Language").ToString());
                MTAppkey.Close();
                if (Language == 1) // means Arabic
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
                    Thread.CurrentThread.CurrentUICulture.DateTimeFormat.Calendar = new GregorianCalendar(GregorianCalendarTypes.Localized);
                }
                
                return CanConnec();
            }
            catch (Exception ex)
            {
                //_MessageBoxDialog.Show("لا يوجد اعدادات للسيرفر" + " .. " + ex.Message, MessageBoxState.Error);
                return false;
            }
        }
        public static bool SaveConnection()
        {
            try
            {
                RegistryKey SoftWarekey = Registry.CurrentUser.OpenSubKey("Software", true);
                RegistryKey MTAppkey = SoftWarekey.CreateSubKey(ApplicationName);
                MTAppkey.SetValue("ServerName", ServerName);
                MTAppkey.SetValue("UserName", Username);
                MTAppkey.SetValue("Password", Password);
                MTAppkey.SetValue("DataBase", DataBase);
                if (ServerAuth)
                    MTAppkey.SetValue("ServerAuth", "1");
                else
                    MTAppkey.SetValue("ServerAuth", "0");
                MTAppkey.SetValue("Language", "0");
                MTAppkey.Close();
                SoftWarekey.Close();
                return true;
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("لم أستطع تخزين" + " .. " + ex.Message, MessageBoxState.Error);
                return false;
            }
        }
        
        public static bool SetLastOpenedDB(string databaseName)
        {
            try
            {
                RegistryKey SoftWarekey = Registry.CurrentUser.OpenSubKey("Software", true);
                RegistryKey MTAppkey = SoftWarekey.CreateSubKey(ApplicationName);
                MTAppkey.SetValue("DataBase", databaseName);
                MTAppkey.Close();
                SoftWarekey.Close();
                return true;
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("لم أستطع تخزين اعدادات" + " .. " + ex.Message, MessageBoxState.Error);
                return false;
            }
        }
        public static string LoadLastOpenedDB()
        {
            try
            {
                RegistryKey MTAppkey = Registry.CurrentUser.OpenSubKey(@"Software\" + ApplicationName);
                DataBase = MTAppkey.GetValue("DataBase").ToString();
                MTAppkey.Close();
                return DataBase;
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("لا يوجد اعدادات محفوظة" + " .. " + ex.Message, MessageBoxState.Error);
                return string.Empty;
            }
        }
        public static string GetConnection(string DatabaseName = "master")
        {
            string curDB;
            if (DatabaseName.Trim() != string.Empty)
                curDB = DatabaseName.Trim();
            else
                curDB = DataBase;
            try
            {
                if (ServerName == string.Empty)
                {
                    if (LoadConnection())
                    {
                        if (ServerAuth)
                            ConnStr = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", ServerName, curDB, Username, Password);
                        else
                            ConnStr = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", ServerName, curDB);
                        return ConnStr;
                    }
                    else
                    {
                        _MessageBoxDialog.Show("لم أستطع الأتصال" + " .. " + "لم أستطع تحميل المعاملات", MessageBoxState.Error);
                        return string.Empty;
                    }
                }
                else
                {
                    if (ServerAuth)
                        ConnStr = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", ServerName, curDB, Username, Password);
                    else
                        ConnStr = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", ServerName, curDB);
                    return ConnStr;
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("لم أستطع الأتصال" + " .. " + ex.Message, MessageBoxState.Error);
                return string.Empty;
            }
        }
        public static bool OpenConnection(string DataBaseName = "")
        {
            string curDB;
            if (DataBaseName.Trim() != string.Empty)
                curDB = DataBaseName.Trim();
            else
                curDB = DataBase;
            try
            {
                if (ServerName == string.Empty)
                {
                    if (LoadConnection())
                    {
                        if (ServerAuth)
                            ConnStr = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", ServerName, curDB, Username, Password);
                        else
                            ConnStr = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", ServerName, curDB);
                        ConfigurationManager.ConnectionStrings["MTModel"].ConnectionString = ConnStr;
                        return true;
                    }
                    else
                    {
                        _MessageBoxDialog.Show("لم أستطع الأتصال" + " .. " + "لم أستطع تحميل المعاملات", MessageBoxState.Error);
                        return false;
                    }
                }
                else
                {
                    if (ServerAuth)
                        ConnStr = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", ServerName, curDB, Username, Password);
                    else
                        ConnStr = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", ServerName, curDB);
                    ConfigurationManager.ConnectionStrings["MTModel"].ConnectionString = ConnStr;
                    return true;
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("لم أستطع الأتصال" + " .. " + "لم أستطع تحميل المعاملات", MessageBoxState.Error);
                return false;
            }
        }
        public static bool CanConnec()
        {
            SqlConnection sqlTestConn = new SqlConnection();
            sqlTestConn.Close();
            string dataBase = "master";
            try
            {
                if (!ServerAuth)
                {
                    sqlTestConn.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", ServerName, dataBase);
                }
                else
                {
                    sqlTestConn.ConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", ServerName, dataBase, Username, Password);
                }
                sqlTestConn.Open();
                sqlTestConn.Close();
                Connected = true;
                return true;
            }
            catch (Exception ex)
            {
                //_MessageBoxDialog.Show("لم أستطع الأتصال" + " .. " + ex.Message, MessageBoxState.Error);
                Connected = false;
                sqlTestConn.Close();
                return false;
            }
        }
        public static DataTable GetDataTable(SqlConnection conn, string cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand(cmd, conn);
            try
            {
                da.SelectCommand = cm;
                dt.Clear();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("لم أستطع الأتصال" + " .. " + ex.Message, MessageBoxState.Error);
                return null;
            }
        }
    }
}
