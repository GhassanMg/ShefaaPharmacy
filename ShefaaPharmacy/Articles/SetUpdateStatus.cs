using System;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class SetUpdateStatus : MetroFramework.Forms.MetroForm
    {
        string status;
        public SetUpdateStatus()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (status == null)
            {
                MessageBox.Show("يجب تحديد نوع التحديث أولاً");

            }
            else
            {
                UpdatePriceOnlineEditForm updatePriceOnlineEditForm = new UpdatePriceOnlineEditForm(status);
                updatePriceOnlineEditForm.ShowDialog();
                this.Close();
            }

        }

        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            status = "offline";
        }

        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            status = "online";
        }
    }
}
