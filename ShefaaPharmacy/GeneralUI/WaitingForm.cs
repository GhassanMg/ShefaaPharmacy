using MetroFramework.Forms;
using System;

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
