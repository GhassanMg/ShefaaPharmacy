namespace ShefaaPharmacy.Accounting
{
    partial class AccountPickForm
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
            ((System.ComponentModel.ISupportInitialize)(this.PickBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.Location = new System.Drawing.Point(12, 98);
            this.metroPanel2.Size = new System.Drawing.Size(915, 289);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(842, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            // 
            // AccountPickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(939, 395);
            this.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.Name = "AccountPickForm";
            this.Padding = new System.Windows.Forms.Padding(12, 63, 12, 8);
            this.Text = "إستعراض الحسابات";
            this.Load += new System.EventHandler(this.AccountPickForm_Load);
            this.Controls.SetChildIndex(this.metroPanel2, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.PickBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
