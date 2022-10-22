
namespace ShefaaPharmacy.Setting
{
    partial class SetTaxAccountCredentials
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbTaxNumber = new System.Windows.Forms.Label();
            this.tbTaxNumber = new System.Windows.Forms.TextBox();
            this.errorProviderApp = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.plButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(118, -1);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(255, -1);
            // 
            // plButtom
            // 
            this.plButtom.Location = new System.Drawing.Point(27, 252);
            this.plButtom.Size = new System.Drawing.Size(505, 40);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(449, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbPassword.Location = new System.Drawing.Point(175, 140);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(261, 24);
            this.tbPassword.TabIndex = 27;
            this.tbPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tbPassword_Validating);
            // 
            // tbUserName
            // 
            this.tbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbUserName.Location = new System.Drawing.Point(175, 102);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(261, 24);
            this.tbUserName.TabIndex = 26;
            this.tbUserName.Validating += new System.ComponentModel.CancelEventHandler(this.tbUserName_Validating);
            // 
            // lbPassword
            // 
            this.lbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbPassword.Location = new System.Drawing.Point(50, 143);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(66, 18);
            this.lbPassword.TabIndex = 25;
            this.lbPassword.Text = "كلمة المرور";
            // 
            // lbUserName
            // 
            this.lbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbUserName.Location = new System.Drawing.Point(50, 105);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(74, 18);
            this.lbUserName.TabIndex = 24;
            this.lbUserName.Text = "اسم المستخدم";
            // 
            // lbTaxNumber
            // 
            this.lbTaxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTaxNumber.AutoSize = true;
            this.lbTaxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbTaxNumber.Location = new System.Drawing.Point(50, 181);
            this.lbTaxNumber.Name = "lbTaxNumber";
            this.lbTaxNumber.Size = new System.Drawing.Size(79, 18);
            this.lbTaxNumber.TabIndex = 28;
            this.lbTaxNumber.Text = "الرقم الضريبي";
            // 
            // tbTaxNumber
            // 
            this.tbTaxNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTaxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbTaxNumber.Location = new System.Drawing.Point(175, 178);
            this.tbTaxNumber.Name = "tbTaxNumber";
            this.tbTaxNumber.Size = new System.Drawing.Size(261, 24);
            this.tbTaxNumber.TabIndex = 29;
            this.tbTaxNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tbTaxNumber_Validating);
            // 
            // errorProviderApp
            // 
            this.errorProviderApp.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderApp.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Papyrus", 9.25F);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(189, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 21);
            this.label1.TabIndex = 30;
            this.label1.Text = "يرجى التأكد تماما من صحة المعلومات المدخلة";
            // 
            // SetTaxAccountCredentials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 301);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTaxNumber);
            this.Controls.Add(this.lbTaxNumber);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUserName);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "SetTaxAccountCredentials";
            this.Padding = new System.Windows.Forms.Padding(27, 73, 14, 9);
            this.Resizable = false;
            this.Text = "تسجيل معلومات الحساب الضريبي";
            this.Controls.SetChildIndex(this.plButtom, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.lbUserName, 0);
            this.Controls.SetChildIndex(this.lbPassword, 0);
            this.Controls.SetChildIndex(this.tbUserName, 0);
            this.Controls.SetChildIndex(this.tbPassword, 0);
            this.Controls.SetChildIndex(this.lbTaxNumber, 0);
            this.Controls.SetChildIndex(this.tbTaxNumber, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.plButtom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbTaxNumber;
        private System.Windows.Forms.TextBox tbTaxNumber;
        private System.Windows.Forms.ErrorProvider errorProviderApp;
        private System.Windows.Forms.Label label1;
    }
}