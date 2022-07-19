namespace ShefaaPharmacy.GeneralUI
{
    partial class CreateDataBaseForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbDots = new System.Windows.Forms.Label();
            this.lbMassege = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(417, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.panel1.Location = new System.Drawing.Point(12, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 35);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = global::ShefaaPharmacy.Properties.Resources.CancelButton;
            this.btnCancel.Location = new System.Drawing.Point(111, -3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 42);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = global::ShefaaPharmacy.Properties.Resources.Group_2315;
            this.btnOk.Location = new System.Drawing.Point(248, -3);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(131, 42);
            this.btnOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnOk.TabIndex = 6;
            this.btnOk.TabStop = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbDots);
            this.panel2.Controls.Add(this.lbMassege);
            this.panel2.Controls.Add(this.tbName);
            this.panel2.Controls.Add(this.lbName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(12, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 156);
            this.panel2.TabIndex = 1;
            // 
            // lbDots
            // 
            this.lbDots.AutoSize = true;
            this.lbDots.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lbDots.Location = new System.Drawing.Point(125, 105);
            this.lbDots.Name = "lbDots";
            this.lbDots.Size = new System.Drawing.Size(30, 25);
            this.lbDots.TabIndex = 7;
            this.lbDots.Text = "...";
            this.lbDots.Visible = false;
            // 
            // lbMassege
            // 
            this.lbMassege.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMassege.AutoSize = true;
            this.lbMassege.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbMassege.Location = new System.Drawing.Point(166, 76);
            this.lbMassege.Name = "lbMassege";
            this.lbMassege.Size = new System.Drawing.Size(140, 18);
            this.lbMassege.TabIndex = 6;
            this.lbMassege.Text = "جاري إنشاء قاعدة البيانات";
            this.lbMassege.Visible = false;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbName.Location = new System.Drawing.Point(48, 29);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(231, 24);
            this.tbName.TabIndex = 3;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbName.Location = new System.Drawing.Point(304, 32);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(98, 18);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "اسم قاعدة البيانات";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CreateDataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(514, 262);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "CreateDataBaseForm";
            this.Padding = new System.Windows.Forms.Padding(12, 63, 12, 8);
            this.Resizable = false;
            this.Text = "إنشاء قاعدة بيانات";
            this.Load += new System.EventHandler(this.CreateDataBaseForm_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbDots;
        private System.Windows.Forms.Label lbMassege;
        private System.Windows.Forms.Timer timer1;
        protected System.Windows.Forms.PictureBox btnCancel;
        protected System.Windows.Forms.PictureBox btnOk;
    }
}
