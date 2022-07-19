using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.Setting
{
    public partial class ActivationTest : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public ActivationTest()
        {
            InitializeComponent();
        }

        private void ActivationTest_Load(object sender, EventArgs e)
        {
            tbNumber.Text = RDSFECXA__WEWDSA.GetString(RDSFECXA__WEWDSA.getMotherBoardID());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (tbNumber.Text != "" && tbNextNumber.Text != "")
            {
                if (!RDSFECXA__WEWDSA.TestingNumber(tbNumber.Text, tbNextNumber.Text, true))
                {
                    _MessageBoxDialog.Show("الرقم المقابل غير صحيح", MessageBoxState.Error);
                }
                else
                {
                    _MessageBoxDialog.Show("تم تسجيل النسخة بنجاح يجب إعادة تشغيل التطبيق لتسجيل المعلومات", MessageBoxState.Done);
                }
            }
        }
    }
}
