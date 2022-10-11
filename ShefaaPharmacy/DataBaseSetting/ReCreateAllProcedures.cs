using System;

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
