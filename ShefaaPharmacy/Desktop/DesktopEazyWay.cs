using ShefaaPharmacy.Helper;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShefaaPharmacy.Desktop
{
    public partial class DesktopEazyWay : UserControl
    {
        public DesktopEazyWay()
        {
            InitializeComponent();
        }
        public void Assigned()
        {
            dgMasterEazyWay.DataSource = new List<EazyWayViewModel>();
            dgMasterEazyWay.AutoGenerateColumns = true;
        }

        private void dgMasterEazyWay_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            EazyWayViewModel s = dgMasterEazyWay.Rows[e.RowIndex].DataBoundItem as EazyWayViewModel;
            if (s.OutComing != 0)
            {
                MessageBox.Show("");
            }
        }
    }
}
