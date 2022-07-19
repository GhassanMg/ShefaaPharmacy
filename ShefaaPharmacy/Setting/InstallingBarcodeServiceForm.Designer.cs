namespace ShefaaPharmacy.Setting
{
    partial class InstallingBarcodeServiceForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdateIp = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tbInstallUtil = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.lbIpAddress = new System.Windows.Forms.Label();
            this.lbPath = new System.Windows.Forms.LinkLabel();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnOpenPort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(539, 7);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpenPort);
            this.panel1.Controls.Add(this.btnUpdateIp);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.tbInstallUtil);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.tbPort);
            this.panel1.Controls.Add(this.lbPort);
            this.panel1.Controls.Add(this.tbAddress);
            this.panel1.Controls.Add(this.lbIpAddress);
            this.panel1.Controls.Add(this.lbPath);
            this.panel1.Controls.Add(this.tbPath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("AD-STOOR", 11F);
            this.panel1.Location = new System.Drawing.Point(20, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 452);
            this.panel1.TabIndex = 1;
            // 
            // btnUpdateIp
            // 
            this.btnUpdateIp.Location = new System.Drawing.Point(196, 248);
            this.btnUpdateIp.Name = "btnUpdateIp";
            this.btnUpdateIp.Size = new System.Drawing.Size(153, 40);
            this.btnUpdateIp.TabIndex = 17;
            this.btnUpdateIp.Text = "تحديث البيانات";
            this.btnUpdateIp.UseVisualStyleBackColor = true;
            this.btnUpdateIp.Click += new System.EventHandler(this.BtnUpdateIp_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(416, 248);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(153, 40);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "حذف الخدمة";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(416, 373);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(153, 40);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "تشغيل الخدمة";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(447, 79);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(127, 29);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "مسار اداة التنصيب";
            // 
            // tbInstallUtil
            // 
            this.tbInstallUtil.Location = new System.Drawing.Point(50, 79);
            this.tbInstallUtil.Name = "tbInstallUtil";
            this.tbInstallUtil.Size = new System.Drawing.Size(375, 36);
            this.tbInstallUtil.TabIndex = 13;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(416, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "تنصيب الخدمة";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(50, 190);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(375, 36);
            this.tbPort.TabIndex = 11;
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(491, 193);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(83, 29);
            this.lbPort.TabIndex = 10;
            this.lbPort.Text = "رقم المنفذ";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(50, 135);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(375, 36);
            this.tbAddress.TabIndex = 9;
            // 
            // lbIpAddress
            // 
            this.lbIpAddress.AutoSize = true;
            this.lbIpAddress.Location = new System.Drawing.Point(485, 135);
            this.lbIpAddress.Name = "lbIpAddress";
            this.lbIpAddress.Size = new System.Drawing.Size(89, 29);
            this.lbIpAddress.TabIndex = 8;
            this.lbIpAddress.Text = "عنوان الجهاز";
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(479, 31);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(95, 29);
            this.lbPath.TabIndex = 7;
            this.lbPath.TabStop = true;
            this.lbPath.Text = "مسار الخدمة";
            this.lbPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LbPath_LinkClicked);
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(50, 28);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(375, 36);
            this.tbPath.TabIndex = 6;
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(196, 309);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(153, 40);
            this.btnOpenPort.TabIndex = 18;
            this.btnOpenPort.Text = "فتح منفذ";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.BtnOpenPort_Click);
            // 
            // InstallingBarcodeServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.ClientSize = new System.Drawing.Size(636, 542);
            this.Controls.Add(this.panel1);
            this.Name = "InstallingBarcodeServiceForm";
            this.Text = "تنصيب الباركود";
            this.Load += new System.EventHandler(this.InstallingBarcodeServiceForm_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label lbIpAddress;
        private System.Windows.Forms.LinkLabel lbPath;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox tbInstallUtil;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdateIp;
        private System.Windows.Forms.Button btnOpenPort;
    }
}
