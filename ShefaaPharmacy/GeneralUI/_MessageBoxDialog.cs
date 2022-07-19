using MetroFramework;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.GeneralUI
{
    public partial class _MessageBoxDialog : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        MessageBoxAnswer messageBoxAnswer;
        MessageBoxState messageBoxState;
        public _MessageBoxDialog()
        {
            InitializeComponent();
        }
        public static MessageBoxAnswer Show(string message, MessageBoxState messageBoxState)
        {
            _MessageBoxDialog fmMessage = new _MessageBoxDialog();
            fmMessage.messageBoxState = messageBoxState;
            try
            {
                switch (messageBoxState)
                {
                    case MessageBoxState.Error:
                        fmMessage.Text = "خطأ";
                        fmMessage.StyleManager = fmMessage.metroStyleManager1;
                        fmMessage.StyleManager.Style = MetroColorStyle.Red;
                        break;
                    case MessageBoxState.Alert:
                    case MessageBoxState.Warning:
                        fmMessage.Text = "تنبيه";
                        fmMessage.StyleManager = fmMessage.metroStyleManager1;
                        fmMessage.StyleManager.Style = MetroColorStyle.Orange;
                        break;
                    case MessageBoxState.Answering:
                        fmMessage.Text = "يرجى الإجابة";
                        fmMessage.StyleManager = fmMessage.metroStyleManager1;
                        fmMessage.StyleManager.Style = MetroColorStyle.Blue;
                        break;
                    case MessageBoxState.Done:
                        fmMessage.Text = "نجاح العملية";
                        fmMessage.StyleManager = fmMessage.metroStyleManager1;
                        fmMessage.StyleManager.Style = MetroColorStyle.Green;
                        break;
                    default:
                        break;
                }
                fmMessage.lbMessageText.Text = message;
                fmMessage.lbMessageText.AutoEllipsis = true;
                fmMessage.lbMessageText.AutoSize = false;
                fmMessage.AutoSize = false;
                //if (Convert.ToInt32(message.Length) > 256)
                //{
                //    fmMessage.Size = new Size(fmMessage.Size.Width, Convert.ToInt32(message.Length));
                //}
                fmMessage.StartPosition = FormStartPosition.CenterScreen;
                fmMessage.ShowDialog();
                return fmMessage.messageBoxAnswer;
            }
            finally
            {
                fmMessage.Dispose();
            }
        }
        private void btnYes_Click(object sender, EventArgs e)
        {
            if (MessageBoxState.Answering == messageBoxState)
            {
                messageBoxAnswer = MessageBoxAnswer.Yes;
            }
            else
            {
                messageBoxAnswer = MessageBoxAnswer.Ok;
            }
            Close();
        }
        private void btnNo_Click(object sender, EventArgs e)
        {
            messageBoxAnswer = MessageBoxAnswer.No;
            Close();
        }
        private void _MessageBoxDialog_Load(object sender, EventArgs e)
        {
            if (MessageBoxState.Answering == messageBoxState)
            {
                pbNo.Visible = true;
                int leftFirstButton = ((pYesNo.Size.Width - (pbYes.Size.Width + pbNo.Size.Width)) / 2);
                pbNo.Location = new Point(leftFirstButton - 3, 0);
                pbYes.Location = new Point(leftFirstButton + pbNo.Size.Width + 3, 0);
            }
            else
            {
                pbNo.Visible = false;
                pbYes.Location = new Point((pYesNo.Size.Width - pbYes.Size.Width) / 2, 0);
            }
            lbMessageText.Location = new Point((pFill.Size.Width - lbMessageText.Size.Width) / 2, (pFill.Size.Height - lbMessageText.Size.Height) / 2);
            btnMinimizing.Enabled = false;
            btnMaximaizing.Enabled = false;
        }

        private void _MessageBoxDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnYes_Click(sender, e);
            }
        }
    }
}
