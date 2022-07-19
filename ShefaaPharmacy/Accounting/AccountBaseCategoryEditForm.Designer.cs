namespace ShefaaPharmacy.Accounting
{
    partial class AccountBaseCategoryEditForm
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
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditBindingSource
            // 
            this.EditBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.EditBindingSource_AddingNew);
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(10, 157);
            this.pBottom.Size = new System.Drawing.Size(370, 48);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(73, -4);
            this.btnCancel.Size = new System.Drawing.Size(108, 57);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(185, -4);
            this.btnOk.Size = new System.Drawing.Size(108, 57);
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
            this.pHelperButton.Location = new System.Drawing.Point(294, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.pHelperButton.Size = new System.Drawing.Size(94, 38);
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(59, 104);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(72, 23);
            this.lbName.TabIndex = 9;
            this.lbName.Text = "نوع الحساب";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(143, 101);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(192, 30);
            this.tbName.TabIndex = 10;
            // 
            // AccountBaseCategoryEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.ClientSize = new System.Drawing.Size(390, 215);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lbName);
            this.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.Name = "AccountBaseCategoryEditForm";
            this.Padding = new System.Windows.Forms.Padding(10, 80, 10, 10);
            this.Text = "تعريف نوع حساب";
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.lbName, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
    }
}
