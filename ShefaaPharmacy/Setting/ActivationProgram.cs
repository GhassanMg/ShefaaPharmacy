using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Drawing;

namespace ShefaaPharmacy.Setting
{
    public partial class ActivationProgram : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public ActivationProgram()
        {
            InitializeComponent();
        }
        private void ActivationProgram_Load(object sender, EventArgs e)
        {
            tbNumber.Text = RDSFECXA__WEWDSA.GetString(RDSFECXA__WEWDSA.getMotherBoardID());
            tbNumber.ForeColor = Color.DimGray;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (tbCorporateNumber.Text != "" && tbNextNumber.Text != "")
            {
                if (!RDSFECXA__WEWDSA.CheckNumber(tbNumber.Text, tbCorporateNumber.Text, tbNextNumber.Text, true))
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
