namespace ShefaaPharmacy.Setting
{
    partial class ServerSettingsForm
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
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.rbwindows = new System.Windows.Forms.RadioButton();
            this.btTestConn = new System.Windows.Forms.Button();
            this.cbServerName = new System.Windows.Forms.ComboBox();
            this.btRefrash = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbServerName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.plButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(152, -2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(131, 38);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(289, -2);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3);
            this.btnOk.Size = new System.Drawing.Size(131, 38);
            // 
            // plButtom
            // 
            this.plButtom.Location = new System.Drawing.Point(27, 254);
            this.plButtom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plButtom.Size = new System.Drawing.Size(556, 35);
            // 
            // btnMaximaizing
            // 
            this.btnMaximaizing.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMaximaizing.Size = new System.Drawing.Size(30, 35);
            // 
            // btnClose
            // 
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Size = new System.Drawing.Size(30, 35);
            // 
            // btnMinimizing
            // 
            this.btnMinimizing.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMinimizing.Size = new System.Drawing.Size(30, 35);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(485, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.pHelperButton.Size = new System.Drawing.Size(112, 35);
            // 
            // rbServer
            // 
            this.rbServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbServer.AutoSize = true;
            this.rbServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.rbServer.Location = new System.Drawing.Point(226, 131);
            this.rbServer.Name = "rbServer";
            this.rbServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbServer.Size = new System.Drawing.Size(139, 22);
            this.rbServer.TabIndex = 22;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "تحقق عن طريق المخدم";
            this.rbServer.UseVisualStyleBackColor = true;
            this.rbServer.CheckedChanged += new System.EventHandler(this.rbServer_CheckedChanged);
            // 
            // rbwindows
            // 
            this.rbwindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbwindows.AutoSize = true;
            this.rbwindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.rbwindows.Location = new System.Drawing.Point(219, 105);
            this.rbwindows.Name = "rbwindows";
            this.rbwindows.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbwindows.Size = new System.Drawing.Size(147, 22);
            this.rbwindows.TabIndex = 21;
            this.rbwindows.TabStop = true;
            this.rbwindows.Text = "تحقق عن طريق الويندوز";
            this.rbwindows.UseVisualStyleBackColor = true;
            this.rbwindows.CheckedChanged += new System.EventHandler(this.rbwindows_CheckedChanged);
            // 
            // btTestConn
            // 
            this.btTestConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTestConn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btTestConn.Location = new System.Drawing.Point(191, 219);
            this.btTestConn.Name = "btTestConn";
            this.btTestConn.Size = new System.Drawing.Size(113, 27);
            this.btTestConn.TabIndex = 20;
            this.btTestConn.Text = "إختبار الأتصال";
            this.btTestConn.UseVisualStyleBackColor = true;
            this.btTestConn.Click += new System.EventHandler(this.btTestConn_Click);
            // 
            // cbServerName
            // 
            this.cbServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.cbServerName.FormattingEnabled = true;
            this.cbServerName.Location = new System.Drawing.Point(190, 71);
            this.cbServerName.Name = "cbServerName";
            this.cbServerName.Size = new System.Drawing.Size(261, 26);
            this.cbServerName.TabIndex = 19;
            // 
            // btRefrash
            // 
            this.btRefrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btRefrash.Location = new System.Drawing.Point(470, 71);
            this.btRefrash.Name = "btRefrash";
            this.btRefrash.Size = new System.Drawing.Size(66, 27);
            this.btRefrash.TabIndex = 18;
            this.btRefrash.Text = "تحديث";
            this.btRefrash.UseVisualStyleBackColor = true;
            this.btRefrash.Click += new System.EventHandler(this.btRefrash_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbPassword.Location = new System.Drawing.Point(190, 189);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(261, 24);
            this.tbPassword.TabIndex = 17;
            // 
            // tbUserName
            // 
            this.tbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbUserName.Location = new System.Drawing.Point(190, 159);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(261, 24);
            this.tbUserName.TabIndex = 16;
            // 
            // lbPassword
            // 
            this.lbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbPassword.Location = new System.Drawing.Point(65, 194);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(66, 18);
            this.lbPassword.TabIndex = 15;
            this.lbPassword.Text = "كلمة المرور";
            // 
            // lbUserName
            // 
            this.lbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbUserName.Location = new System.Drawing.Point(65, 164);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(74, 18);
            this.lbUserName.TabIndex = 14;
            this.lbUserName.Text = "اسم المستخدم";
            // 
            // lbServerName
            // 
            this.lbServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbServerName.AutoSize = true;
            this.lbServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbServerName.Location = new System.Drawing.Point(65, 73);
            this.lbServerName.Name = "lbServerName";
            this.lbServerName.Size = new System.Drawing.Size(61, 18);
            this.lbServerName.TabIndex = 13;
            this.lbServerName.Text = "اسم المخدم";
            // 
            // ServerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(597, 295);
            this.Controls.Add(this.rbServer);
            this.Controls.Add(this.rbwindows);
            this.Controls.Add(this.btTestConn);
            this.Controls.Add(this.cbServerName);
            this.Controls.Add(this.btRefrash);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbServerName);
            this.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerSettingsForm";
            this.Padding = new System.Windows.Forms.Padding(27, 60, 14, 6);
            this.Resizable = false;
            this.Text = "إعدادات الإتصال";
            this.Load += new System.EventHandler(this.ServerSettingsForm_Load);
            this.Controls.SetChildIndex(this.plButtom, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.lbServerName, 0);
            this.Controls.SetChildIndex(this.lbUserName, 0);
            this.Controls.SetChildIndex(this.lbPassword, 0);
            this.Controls.SetChildIndex(this.tbUserName, 0);
            this.Controls.SetChildIndex(this.tbPassword, 0);
            this.Controls.SetChildIndex(this.btRefrash, 0);
            this.Controls.SetChildIndex(this.cbServerName, 0);
            this.Controls.SetChildIndex(this.btTestConn, 0);
            this.Controls.SetChildIndex(this.rbwindows, 0);
            this.Controls.SetChildIndex(this.rbServer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.plButtom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.RadioButton rbwindows;
        private System.Windows.Forms.Button btTestConn;
        private System.Windows.Forms.ComboBox cbServerName;
        private System.Windows.Forms.Button btRefrash;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbServerName;
    }
}
