using DataLayer.Tables;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.Articale;
using ShefaaPharmacy.Definition;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Public;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.Desktop
{
    public partial class BasicDesktop : UserControl
    {
        public BasicDesktop()
        {
            InitializeComponent();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    CompanyEditForm companyEditForm = new CompanyEditForm(new Company());
                    companyEditForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    AccountCardEditForm accountEditForm = new AccountCardEditForm(new Account());
                    accountEditForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.IsManager())
                {
                    UnitEditForm unitEditForm = new UnitEditForm(new UnitType());
                    unitEditForm.ShowDialog();
                }
                else
                {
                    _MessageBoxDialog.Show("ليس لديك صلاحية لاستخدام هذه الواجهة", MessageBoxState.Error);
                }
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }
    }
}
