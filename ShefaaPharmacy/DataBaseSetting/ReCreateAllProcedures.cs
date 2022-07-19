using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.DataBaseSetting
{
    public partial class ReCreateAllProcedures : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public ReCreateAllProcedures()
        {
            InitializeComponent();
        }

        private void ReCreateAllProcedures_Load(object sender, EventArgs e)
        {
            pHelperButton.Visible = false;
        }
    }
}
