
namespace ShefaaPharmacy.Notification
{
    partial class GeneralNotification
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
            this.dgvNotification = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(11, 283);
            this.pBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBottom.Size = new System.Drawing.Size(808, 38);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1064, 2);
            this.btnCancel.Size = new System.Drawing.Size(126, 35);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(1194, 2);
            this.btnOk.Size = new System.Drawing.Size(126, 35);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(721, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // dgvNotification
            // 
            this.dgvNotification.AllowUserToAddRows = false;
            this.dgvNotification.AllowUserToDeleteRows = false;
            this.dgvNotification.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNotification.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotification.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotification.Location = new System.Drawing.Point(11, 63);
            this.dgvNotification.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvNotification.Name = "dgvNotification";
            this.dgvNotification.ReadOnly = true;
            this.dgvNotification.Size = new System.Drawing.Size(808, 220);
            this.dgvNotification.TabIndex = 9;
            // 
            // GeneralNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(830, 329);
            this.Controls.Add(this.dgvNotification);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "GeneralNotification";
            this.Padding = new System.Windows.Forms.Padding(11, 63, 11, 8);
            this.Load += new System.EventHandler(this.GeneralNotification_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.dgvNotification, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotification)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNotification;
    }
}
