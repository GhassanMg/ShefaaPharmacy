namespace ShefaaPharmacy.DataBaseSetting
{
    partial class DataBaseBackUp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pbOk = new System.Windows.Forms.PictureBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDataBase = new System.Windows.Forms.ComboBox();
            this.lblLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).BeginInit();
            this.SuspendLayout();
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(467, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.pbOk);
            this.panel1.Controls.Add(this.tbPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbDataBase);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(18, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 146);
            this.panel1.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.linkLabel1.Location = new System.Drawing.Point(380, 62);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(103, 18);
            this.linkLabel1.TabIndex = 33;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "اختر مسار التخزين";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pbOk
            // 
            this.pbOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOk.Image = global::ShefaaPharmacy.Properties.Resources.SaveButton;
            this.pbOk.Location = new System.Drawing.Point(192, 104);
            this.pbOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbOk.Name = "pbOk";
            this.pbOk.Size = new System.Drawing.Size(164, 30);
            this.pbOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOk.TabIndex = 32;
            this.pbOk.TabStop = false;
            this.pbOk.Click += new System.EventHandler(this.PbOk_Click);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.ForeColor = System.Drawing.Color.Black;
            this.tbPath.Location = new System.Drawing.Point(112, 59);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Multiline = true;
            this.tbPath.Name = "tbPath";
            this.tbPath.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbPath.Size = new System.Drawing.Size(261, 25);
            this.tbPath.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(382, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "قاعدة البيانات";
            // 
            // cbDataBase
            // 
            this.cbDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDataBase.ForeColor = System.Drawing.Color.Black;
            this.cbDataBase.FormattingEnabled = true;
            this.cbDataBase.Location = new System.Drawing.Point(112, 19);
            this.cbDataBase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDataBase.Name = "cbDataBase";
            this.cbDataBase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbDataBase.Size = new System.Drawing.Size(262, 23);
            this.cbDataBase.TabIndex = 26;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("El Messiri SemiBold", 9.25F);
            this.lblLoading.Location = new System.Drawing.Point(239, 25);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(172, 20);
            this.lblLoading.TabIndex = 61;
            this.lblLoading.Text = "يتم التحميل الان, يرجى الانتظار";
            this.lblLoading.Visible = false;
            this.lblLoading.Click += new System.EventHandler(this.lblLoading_Click);
            // 
            // DataBaseBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(564, 213);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "DataBaseBackUp";
            this.Padding = new System.Windows.Forms.Padding(18, 60, 9, 7);
            this.Text = "إنشاء نسخة إحتياطية";
            this.Load += new System.EventHandler(this.DataBaseBackUp_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblLoading, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDataBase;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.PictureBox pbOk;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblLoading;
    }
}
