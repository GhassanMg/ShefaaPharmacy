using DataLayer.Helper;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.Definition
{
    public enum Passwords
    {
        InstallingService
    }
    public partial class EnterPasswordForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {

        public bool Valid { get; set; }
        public Passwords Passwords { get; set; }
        public EnterPasswordForm()
        {
            InitializeComponent();
        }

        private void EnterPasswordForm_Load(object sender, EventArgs e)
        {

        }
        public static bool CheckInstallBarcodeService()
        {
            EnterPasswordForm enterPasswordForm = new EnterPasswordForm();
            enterPasswordForm.Valid = false;
            enterPasswordForm.Passwords = Passwords.InstallingService;
            enterPasswordForm.ShowDialog();
            return enterPasswordForm.Valid;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            switch (Passwords)
            {
                case Passwords.InstallingService:
                    if (String.IsNullOrEmpty(tbPassword.Text))
                    {
                        _MessageBoxDialog.Show("لا يجب أن تكون كلمة المرور فارغة", MessageBoxState.Error);
                    }
                    else
                    {
                        if (tbPassword.Text == ConstantDataBase.InstallingService)
                        {
                            Valid = true;
                            Close();
                        }
                        else
                        {
                            _MessageBoxDialog.Show("كلمة مرور غير صحيحية", MessageBoxState.Error);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void TbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnOk_Click(sender, e);
            }
        }
    }
}
