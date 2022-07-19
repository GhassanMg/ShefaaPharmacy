namespace ShefaaPharmacy.Definition
{
    partial class InputForm
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
            this.pbOk = new System.Windows.Forms.PictureBox();
            this.lbNumber = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
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
            this.pHelperButton.Location = new System.Drawing.Point(336, 7);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbOk);
            this.panel1.Controls.Add(this.lbNumber);
            this.panel1.Controls.Add(this.tbNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("AD-STOOR", 11F);
            this.panel1.Location = new System.Drawing.Point(20, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 157);
            this.panel1.TabIndex = 2;
            // 
            // pbOk
            // 
            this.pbOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOk.Image = global::ShefaaPharmacy.Properties.Resources.Group_2315;
            this.pbOk.Location = new System.Drawing.Point(123, 98);
            this.pbOk.Margin = new System.Windows.Forms.Padding(4);
            this.pbOk.Name = "pbOk";
            this.pbOk.Size = new System.Drawing.Size(154, 46);
            this.pbOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOk.TabIndex = 241;
            this.pbOk.TabStop = false;
            this.pbOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(300, 42);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(90, 29);
            this.lbNumber.TabIndex = 3;
            this.lbNumber.Text = "رقم الفاتورة";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(45, 39);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(232, 36);
            this.tbNumber.TabIndex = 2;
            this.tbNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbNumber_KeyDown);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.ClientSize = new System.Drawing.Size(433, 247);
            this.Controls.Add(this.panel1);
            this.Name = "InputForm";
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.PictureBox pbOk;
    }
}
