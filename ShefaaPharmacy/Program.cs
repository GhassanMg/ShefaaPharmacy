using DataLayer;
using DataLayer.Helper;
using Microsoft.Win32;
using ShefaaPharmacy.Api;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Setting;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ShefaaPharmacy
{
    static class Program
    {
        public static MainForm mainForm;
        public static PrivateFontCollection modernFont;
        public static MetroFramework.Forms.MetroForm[] minimizedForm = new MetroFramework.Forms.MetroForm[6];
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Checkfont("AD-STOOR");
            Checkfont("Akhbar MT");
            Checkfont("Zekton");
            Checkfont("ElMessiri-SemiBold");
            DBsHttpServer dbsHttpServer;
            dbsHttpServer = new DBsHttpServer(1010);
            Thread thread1 = new Thread(new ThreadStart(dbsHttpServer.listen));
            thread1.Start();
            LoginHttpServer loginHttpServer;
            loginHttpServer = new LoginHttpServer(2020);
            Thread thread2 = new Thread(new ThreadStart(loginHttpServer.listen));
            thread2.Start();
            BuyHttpServer buyhttpserver;
            buyhttpserver = new BuyHttpServer(3030);
            Thread thread3 = new Thread(new ThreadStart(buyhttpserver.listen));
            thread3.Start();
            if (!ConnectionManager.LoadConnection())
            {

                ServerSettingsForm fmServerConfig = new ServerSettingsForm();
                fmServerConfig.ShowDialog();
                fmServerConfig.Dispose();

            }

            if (ConnectionManager.Connected)
            {
                LogInShefaa LoginForm = new LogInShefaa();
                LoginForm.ShowDialog();
                LoginForm.Dispose();
                if (UserLoggedIn.User != null)
                {
                    ShefaaPharmacyDbContext.BackUp();
                }
            }
            mainForm = new MainForm();
            Application.Run(mainForm);
            Login.GetLogin().Logout();
        }
        static void Checkfont(string fontName)
        {
            try
            {
                using (Font fontTester = new Font(fontName, 12, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    if (fontTester.Name != fontName)
                    {
                        if (fontName == "AD-STOOR")
                        {
                            RegisterFont(@"AD-STOOR.otf");
                        }
                        else if (fontName == "Akhbar MT")
                        {
                            RegisterFont(@"AKHBR.TTF");
                        }
                        else if (fontName == "Zekton")
                        {
                            RegisterFont(@"ZEKTON.TTF");
                        }
                        else if (fontName == "ElMessiri-SemiBold")
                        {
                            RegisterFont(@"ElMessiri-SemiBold");
                        }
                    }
                }
            }

            catch (Exception)
            {
                ;
            }

        }

        private static void RegisterFont(string contentFontName)
        {
            try
            {
                // Creates the full path where your font will be installed
                var fontDestination = Path.Combine(System.Environment.GetFolderPath
                                              (System.Environment.SpecialFolder.Fonts), contentFontName);

                if (!File.Exists(fontDestination))
                {
                    // Copies font to destination
                    System.IO.File.Copy(Path.Combine(System.IO.Directory.GetCurrentDirectory(), contentFontName), fontDestination);

                    // Retrieves font name
                    // Makes sure you reference System.Drawing
                    PrivateFontCollection fontCol = new PrivateFontCollection();
                    fontCol.AddFontFile(fontDestination);
                    var actualFontName = fontCol.Families[0].Name;

                    //Add font
                    AddFontResource(fontDestination);
                    //Add registry entry   
                    Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts",
                    actualFontName, contentFontName, RegistryValueKind.String);
                }


            }
            catch (Exception)
            {
                ;
            }
        }
        [DllImport("gdi32", EntryPoint = "AddFontResource")]
        public static extern int AddFontResourceA(string lpFileName);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern int AddFontResource(string lpszFilename);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern int CreateScalableFontResource(uint fdwHidden, string
        lpszFontRes, string lpszFontFile, string lpszCurrentPath);
        static void UseCustomFont()
        {

            modernFont = new PrivateFontCollection();

            int fontLength = Properties.Resources.ZEKTON.Length;
            byte[] fontdata = Properties.Resources.ZEKTON;
            IntPtr data0 = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data0, fontLength);
            modernFont.AddMemoryFont(data0, fontLength);

            fontLength = Properties.Resources.AD_STOOR.Length;
            fontdata = Properties.Resources.AD_STOOR;
            IntPtr data1 = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data1, fontLength);
            modernFont.AddMemoryFont(data1, fontLength);

            fontLength = Properties.Resources.AKHBR.Length;
            fontdata = Properties.Resources.AKHBR;
            IntPtr data2 = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data2, fontLength);
            modernFont.AddMemoryFont(data2, fontLength);

            fontLength = Properties.Resources.ElMessiri_SemiBold.Length;
            fontdata = Properties.Resources.ElMessiri_SemiBold;
            IntPtr data3 = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data2, fontLength);
            modernFont.AddMemoryFont(data2, fontLength);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //_MessageBoxDialog.Show("عذراً لقد حدث خطأ تأكد من صحة العملية",MessageBoxState.Error);
            _MessageBoxDialog.Show(e.Exception.Message, MessageBoxState.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //_MessageBoxDialog.Show("عذراً لقد حدث خطأ تأكد من صحة العملية", MessageBoxState.Error);
            _MessageBoxDialog.Show((e.ExceptionObject as Exception).Message, MessageBoxState.Error);
        }
    }

    public class MyCustomApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public MyCustomApplicationContext()
        {
            trayIcon = new NotifyIcon()
            {
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit),new MenuItem("LogOut",LogOut)
            }),
                Visible = true
            };
        }

        void LogOut(object sender, EventArgs e)
        {
            Login.GetLogin().Logout();
        }

        void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
