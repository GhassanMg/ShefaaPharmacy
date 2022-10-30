namespace ShefaaPharmacy.Invoice
{
    partial class InvoicDayPickForm
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
            this.dtCreationDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.PickBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Location = new System.Drawing.Point(11, 98);
            this.metroPanel2.Size = new System.Drawing.Size(1004, 271);
            // 
            // dtCreationDate
            // 
            this.dtCreationDate.Location = new System.Drawing.Point(549, 64);
            this.dtCreationDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtCreationDate.MinimumSize = new System.Drawing.Size(4, 29);
            this.dtCreationDate.Name = "dtCreationDate";
            this.dtCreationDate.RightToLeftLayout = true;
            this.dtCreationDate.Size = new System.Drawing.Size(196, 29);
            this.dtCreationDate.TabIndex = 17;
            this.dtCreationDate.ValueChanged += new System.EventHandler(this.dtCreationDate_ValueChanged);
            // 
            // InvoicDayPickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1026, 472);
            this.Controls.Add(this.dtCreationDate);
            this.Name = "InvoicDayPickForm";
            this.Padding = new System.Windows.Forms.Padding(11, 63, 11, 8);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.InvoicDayPickForm_Load);
            this.Controls.SetChildIndex(this.metroPanel2, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.dtCreationDate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PickBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtCreationDate;
    }
}
