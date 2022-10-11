﻿using System;

namespace ShefaaPharmacy.GeneralUI
{
    public partial class DialogForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        protected bool NewRecord = false;
        public DialogForm()
        {
            InitializeComponent();
        }

        virtual protected void btOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        virtual protected void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
