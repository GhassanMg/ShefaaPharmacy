namespace ShefaaPharmacy.Definition
{
    partial class YearPickForm
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
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(697, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            // 
            // YearPickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.ClientSize = new System.Drawing.Size(793, 693);
            this.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.Name = "YearPickForm";
            this.Padding = new System.Windows.Forms.Padding(10, 80, 10, 10);
            this.Text = "إستعراض السنوات المالية";
            this.Load += new System.EventHandler(this.YearPickForm_Load);
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
