namespace ShefaaPharmacy.DataBaseSetting
{
    partial class DataBaseRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBaseRestore));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnRestore = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDataBaseName = new System.Windows.Forms.TextBox();
            this.lblLoading = new System.Windows.Forms.Label();
            this.pcloader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcloader)).BeginInit();
            this.SuspendLayout();
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(493, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.linkLabel1.Location = new System.Drawing.Point(32, 92);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(124, 18);
            this.linkLabel1.TabIndex = 30;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "اختر النسخة الإحتياطية";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbPath.Location = new System.Drawing.Point(186, 89);
            this.tbPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(373, 24);
            this.tbPath.TabIndex = 31;
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnRestore.Location = new System.Drawing.Point(232, 188);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(93, 28);
            this.btnRestore.TabIndex = 35;
            this.btnRestore.Text = "إستعادة";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(48, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 36;
            this.label2.Text = "اسم قاعدة البيانات";
            // 
            // tbDataBaseName
            // 
            this.tbDataBaseName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDataBaseName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDataBaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbDataBaseName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tbDataBaseName.Location = new System.Drawing.Point(186, 128);
            this.tbDataBaseName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDataBaseName.Name = "tbDataBaseName";
            this.tbDataBaseName.ReadOnly = true;
            this.tbDataBaseName.Size = new System.Drawing.Size(373, 24);
            this.tbDataBaseName.TabIndex = 37;
            this.tbDataBaseName.Validating += new System.ComponentModel.CancelEventHandler(this.tbDataBaseName_Validating);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblLoading.Location = new System.Drawing.Point(248, 43);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(152, 16);
            this.lblLoading.TabIndex = 60;
            this.lblLoading.Text = "يتم التحميل الان, يرجى الانتظار";
            this.lblLoading.Visible = false;
            this.lblLoading.Click += new System.EventHandler(this.lblLoading_Click);
            // 
            // pcloader
            // 
            this.pcloader.Image = ((System.Drawing.Image)(resources.GetObject("pcloader.Image")));
            this.pcloader.Location = new System.Drawing.Point(406, 35);
            this.pcloader.Name = "pcloader";
            this.pcloader.Size = new System.Drawing.Size(32, 32);
            this.pcloader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcloader.TabIndex = 61;
            this.pcloader.TabStop = false;
            this.pcloader.Visible = false;
            // 
            // DataBaseRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(590, 224);
            this.Controls.Add(this.pcloader);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.tbDataBaseName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.linkLabel1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "DataBaseRestore";
            this.Padding = new System.Windows.Forms.Padding(18, 60, 9, 7);
            this.Text = "إستعادة نسخة إحتياطية";
            this.Load += new System.EventHandler(this.DataBaseRestore_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            this.Controls.SetChildIndex(this.tbPath, 0);
            this.Controls.SetChildIndex(this.btnRestore, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbDataBaseName, 0);
            this.Controls.SetChildIndex(this.lblLoading, 0);
            this.Controls.SetChildIndex(this.pcloader, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcloader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDataBaseName;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.PictureBox pcloader;
    }
}
