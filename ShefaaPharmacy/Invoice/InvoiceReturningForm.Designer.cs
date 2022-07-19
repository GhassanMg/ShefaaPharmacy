namespace ShefaaPharmacy.Invoice
{
    partial class InvoiceReturningForm
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
            this.tbBillMasterId = new System.Windows.Forms.TextBox();
            this.pYesNo = new System.Windows.Forms.Panel();
            this.pbYes = new System.Windows.Forms.PictureBox();
            this.pbNo = new System.Windows.Forms.PictureBox();
            this.lbBillNumber = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.pYesNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbYes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMaximaizing
            // 
            this.btnMaximaizing.Location = new System.Drawing.Point(45, 0);
            this.btnMaximaizing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(7, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // btnMinimizing
            // 
            this.btnMinimizing.Location = new System.Drawing.Point(85, 0);
            this.btnMinimizing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(474, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // tbBillMasterId
            // 
            this.tbBillMasterId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBillMasterId.Location = new System.Drawing.Point(216, 128);
            this.tbBillMasterId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbBillMasterId.Name = "tbBillMasterId";
            this.tbBillMasterId.Size = new System.Drawing.Size(219, 31);
            this.tbBillMasterId.TabIndex = 6;
            this.tbBillMasterId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBillMasterId_KeyDown);
            // 
            // pYesNo
            // 
            this.pYesNo.Controls.Add(this.pbYes);
            this.pYesNo.Controls.Add(this.pbNo);
            this.pYesNo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pYesNo.Location = new System.Drawing.Point(23, 217);
            this.pYesNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pYesNo.Name = "pYesNo";
            this.pYesNo.Size = new System.Drawing.Size(536, 59);
            this.pYesNo.TabIndex = 8;
            // 
            // pbYes
            // 
            this.pbYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbYes.Image = global::ShefaaPharmacy.Properties.Resources.Group_2315;
            this.pbYes.Location = new System.Drawing.Point(276, 0);
            this.pbYes.Margin = new System.Windows.Forms.Padding(4);
            this.pbYes.Name = "pbYes";
            this.pbYes.Size = new System.Drawing.Size(145, 59);
            this.pbYes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbYes.TabIndex = 20;
            this.pbYes.TabStop = false;
            this.pbYes.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pbNo
            // 
            this.pbNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNo.Image = global::ShefaaPharmacy.Properties.Resources.Group_2299__1_;
            this.pbNo.Location = new System.Drawing.Point(123, 0);
            this.pbNo.Margin = new System.Windows.Forms.Padding(4);
            this.pbNo.Name = "pbNo";
            this.pbNo.Size = new System.Drawing.Size(145, 59);
            this.pbNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNo.TabIndex = 19;
            this.pbNo.TabStop = false;
            this.pbNo.Click += new System.EventHandler(this.pbNo_Click);
            // 
            // lbBillNumber
            // 
            this.lbBillNumber.AutoSize = true;
            this.lbBillNumber.Location = new System.Drawing.Point(133, 134);
            this.lbBillNumber.Name = "lbBillNumber";
            this.lbBillNumber.Size = new System.Drawing.Size(68, 25);
            this.lbBillNumber.TabIndex = 9;
            this.lbBillNumber.TabStop = true;
            this.lbBillNumber.Text = "فاتورة رقم";
            this.toolTip1.SetToolTip(this.lbBillNumber, "عرض الفواتير");
            this.lbBillNumber.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LbBillNumber_LinkClicked);
            // 
            // InvoiceReturningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.ClientSize = new System.Drawing.Size(571, 287);
            this.Controls.Add(this.lbBillNumber);
            this.Controls.Add(this.pYesNo);
            this.Controls.Add(this.tbBillMasterId);
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "InvoiceReturningForm";
            this.Padding = new System.Windows.Forms.Padding(23, 92, 12, 11);
            this.Text = "مرتجع فاتورة";
            this.Load += new System.EventHandler(this.InvoiceReturningForm_Load);
            this.Controls.SetChildIndex(this.tbBillMasterId, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pYesNo, 0);
            this.Controls.SetChildIndex(this.lbBillNumber, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.pYesNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbYes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbBillMasterId;
        private System.Windows.Forms.Panel pYesNo;
        private System.Windows.Forms.PictureBox pbYes;
        private System.Windows.Forms.PictureBox pbNo;
        private System.Windows.Forms.LinkLabel lbBillNumber;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
