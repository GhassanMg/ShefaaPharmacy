using MetroFramework.Forms;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataLayer.Enums;
using System.Diagnostics;

namespace ShefaaPharmacy.GeneralUI
{
    public partial class AbstractForm : MetroForm
    {
        protected string[] HiddenColumn;
        protected string FormName { get; set; }
        protected FormOperation FormOperation { get; set; }
        private static List<string> closeFormWithoutAsking;
        private static List<string> windowsStaticSize;
        public AbstractForm()
        {
            InitializeComponent();
            closeFormWithoutAsking = new List<string>() { "_MessageBoxDialog", "LoginForm" };
            windowsStaticSize = new List<string>() { "_MessageBoxDialog", "LoginForm" };
            //if (Program.modernFont != null)
            //    if (ActiveForm != null && ActiveForm.Name != "MainForm")
            //        Font = new Font(Program.modernFont.Families[1], 10);
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams; 
        //        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED

        //        if (this.IsXpOr2003 == true)
        //            cp.ExStyle |= 0x00080000;  // Turn on WS_EX_LAYERED

        //        return cp;
        //    }
        //}
        ////Check os version
        //private Boolean IsXpOr2003
        //{
        //    get
        //    {
        //        OperatingSystem os = Environment.OSVersion;
        //        Version vs = os.Version;

        //        if (os.Platform == PlatformID.Win32NT)
        //            if ((vs.Major == 5) && (vs.Minor != 0))
        //                return true;
        //            else
        //                return false;
        //        else
        //            return false;
        //    }
        //}
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (closeFormWithoutAsking.Contains(ActiveForm.Name))
            {
                AutoValidate = AutoValidate.Disable;
                this.Close();
            }
            else if (_MessageBoxDialog.Show("هل تريد إغلاق الواجهة وإلغاء العملية", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
            {
                if (ActiveForm.Name == "MainForm")
                {
                    this.Close();
                    AutoValidate = AutoValidate.Disable;
                    //Environment.Exit();
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    AutoValidate = AutoValidate.Disable;
                    this.Close();
                }
               
                
            }
        }
        private void AbstractForm_Load(object sender, EventArgs e)
        {
            //pHelperButton.Location = new Point(this.Size.Width - 96, 7);
            //if (!windowsStaticSize.Contains(ActiveForm.Name))
            //{
            //    Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            //    int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            //    int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            //    this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            //    this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //}
            //pHelperButton.Left = this.Size.Width - pHelperButton.Width;
            //pHelperButton.Top = 7;
            pHelperButton.Location = new Point(this.Size.Width - pHelperButton.Width, 7);
            // btnMaximaizing.Enabled = false;
            //if (Program.modernFont != null)
            //    if (ActiveForm != null && ActiveForm.Name != "MainForm")
            //        Font = new Font(Program.modernFont.Families[1], 10);
        }
        private void AbstractForm_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.Location.X.ToString() + "\t" + e.Location.Y.ToString());
        }
        private void btnMaximaizing_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
            pHelperButton.Location = new Point(this.Size.Width - 96, 7);
        }
        private void btnMinimizing_Click(object sender, EventArgs e)
        {
            if (this.Name == "MainForm")
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                HiddenForm();
            } 
        }
        public void HiddenForm()
        {
            this.Visible = false;
            int i = 0;
            for (; i < Program.minimizedForm.Length; i++)
            {
                if (Program.minimizedForm[i] == null)
                {
                    Program.minimizedForm[i] = this;
                    break;
                }
            }
            i += 1;
            switch (i)
            {
                case 1:
                    {
                        Program.mainForm.pHidden1.Visible = true;
                        Program.mainForm.lbHidden1.Text = this.Text;
                        break;
                    }
                case 2:
                    {
                        Program.mainForm.pHidden2.Visible = true;
                        Program.mainForm.lbHidden2.Text = this.Text;
                        break;
                    }
                case 3:
                    {
                        Program.mainForm.pHidden3.Visible = true;
                        Program.mainForm.lbHidden3.Text = this.Text;
                        break;
                    }
                case 4:
                    {
                        Program.mainForm.pHidden4.Visible = true;
                        Program.mainForm.lbHidden4.Text = this.Text;
                        break;
                    }
                case 5:
                    {
                        Program.mainForm.pHidden5.Visible = true;
                        Program.mainForm.lbHidden5.Text = this.Text;
                        break;
                    }
                case 6:
                    {
                        Program.mainForm.pHidden6.Visible = true;
                        Program.mainForm.lbHidden6.Text = this.Text;
                        break;
                    }
                default:
                    break;
            }
            Program.mainForm.Focus();
            Program.mainForm.Activate();
        }
        public void RestoreForm(int i)
        {
            Program.minimizedForm[i - 1].Visible = true;
            switch (i)
            {
                case 1:
                    {
                        Program.mainForm.pHidden1.Visible = false;
                        Program.mainForm.lbHidden1.Text = this.Text;
                        break;
                    }
                case 2:
                    {
                        Program.mainForm.pHidden2.Visible = false;
                        Program.mainForm.lbHidden2.Text = this.Text;
                        break;
                    }
                case 3:
                    {
                        Program.mainForm.pHidden3.Visible = false;
                        Program.mainForm.lbHidden3.Text = this.Text;
                        break;
                    }
                case 4:
                    {
                        Program.mainForm.pHidden4.Visible = false;
                        Program.mainForm.lbHidden4.Text = this.Text;
                        break;
                    }
                case 5:
                    {
                        Program.mainForm.pHidden5.Visible = false;
                        Program.mainForm.lbHidden5.Text = this.Text;
                        break;
                    }
                case 6:
                    {
                        Program.mainForm.pHidden6.Visible = false;
                        Program.mainForm.lbHidden6.Text = this.Text;
                        break;
                    }
                default:
                    break;
            }
            Program.minimizedForm[i - 1].Focus();
            Program.minimizedForm[i - 1].Activate();
            Program.minimizedForm[i - 1] = null;
        }
        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.btnClose, "إغلاق");
        }
        private void btnMaximaizing_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.btnMaximaizing, "تكبير");
        }
        private void btnMinimizing_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.btnMinimizing, "تصغير");
        }

        private void AbstractForm_Resize(object sender, EventArgs e)
        {
            // pHelperButton.Location = new Point(this.Size.Width - 96, 7);
        }

        private void AbstractForm_SizeChanged(object sender, EventArgs e)
        {
            pHelperButton.Location = new Point(this.Size.Width - pHelperButton.Width, 7);
        }
        virtual protected void ShowColumn(DataGridViewColumnCollection dataGridViewColumnCollection)
        {
            foreach (DataGridViewColumn item in dataGridViewColumnCollection)
            {
                if (HiddenColumn == null || !HiddenColumn.Contains(item.Name))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
        }
    }
}
