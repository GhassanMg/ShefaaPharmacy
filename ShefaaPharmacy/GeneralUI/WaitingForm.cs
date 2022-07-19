using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.GeneralUI
{
    public partial class WaitingForm : MetroForm
    {
        public string Header { get; set; }
        public WaitingForm()
        {
            InitializeComponent();
        }
        public WaitingForm(string header)
        {
            this.Header = header;
        }
        private void WaitingForm_Load(object sender, EventArgs e)
        {
            Text = Header;
        }
    }
}
