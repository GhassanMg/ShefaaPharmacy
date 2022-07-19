namespace ShefaaPharmacy.Definition
{
    partial class YearEditForm
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.dtCreationDate = new System.Windows.Forms.DateTimePicker();
            this.lbCreationDate = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditBindingSource
            // 
            this.EditBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.EditBindingSource_AddingNew);
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(10, 234);
            this.pBottom.Size = new System.Drawing.Size(429, 48);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(95, 0);
            this.btnCancel.Size = new System.Drawing.Size(134, 50);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(237, 0);
            this.btnOk.Size = new System.Drawing.Size(134, 50);
            // 
            // btnMaximaizing
            // 
            this.btnMaximaizing.Location = new System.Drawing.Point(33, 0);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3, 0);
            // 
            // btnMinimizing
            // 
            this.btnMinimizing.Location = new System.Drawing.Point(65, 0);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(345, 8);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.pHelperButton.Size = new System.Drawing.Size(94, 38);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.dtCreationDate);
            this.panel1.Controls.Add(this.lbCreationDate);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 154);
            this.panel1.TabIndex = 9;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(77, 55);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 30);
            this.tbName.TabIndex = 21;
            // 
            // dtCreationDate
            // 
            this.dtCreationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtCreationDate.Location = new System.Drawing.Point(77, 89);
            this.dtCreationDate.Name = "dtCreationDate";
            this.dtCreationDate.Size = new System.Drawing.Size(200, 30);
            this.dtCreationDate.TabIndex = 20;
            // 
            // lbCreationDate
            // 
            this.lbCreationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCreationDate.AutoSize = true;
            this.lbCreationDate.Location = new System.Drawing.Point(314, 95);
            this.lbCreationDate.Name = "lbCreationDate";
            this.lbCreationDate.Size = new System.Drawing.Size(38, 23);
            this.lbCreationDate.TabIndex = 19;
            this.lbCreationDate.Text = "التاريخ";
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(291, 58);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(61, 23);
            this.lbName.TabIndex = 18;
            this.lbName.Text = "سنة مالية";
            // 
            // YearEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.ClientSize = new System.Drawing.Size(449, 292);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.Name = "YearEditForm";
            this.Padding = new System.Windows.Forms.Padding(10, 80, 10, 10);
            this.Resizable = false;
            this.Load += new System.EventHandler(this.YearEditForm_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DateTimePicker dtCreationDate;
        private System.Windows.Forms.Label lbCreationDate;
        private System.Windows.Forms.Label lbName;
    }
}
