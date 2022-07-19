namespace ShefaaPharmacy.Definition
{
    partial class UnitEditForm
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
            this.tbUnitName = new System.Windows.Forms.TextBox();
            this.lbUnitName = new System.Windows.Forms.Label();
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
            this.pBottom.Location = new System.Drawing.Point(10, 159);
            this.pBottom.Size = new System.Drawing.Size(339, 48);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(54, -1);
            this.btnCancel.Size = new System.Drawing.Size(113, 50);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(171, -1);
            this.btnOk.Size = new System.Drawing.Size(113, 50);
            // 
            // btnMaximaizing
            // 
            this.btnMaximaizing.Location = new System.Drawing.Point(33, 0);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1, 0);
            // 
            // btnMinimizing
            // 
            this.btnMinimizing.Location = new System.Drawing.Point(65, 0);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(263, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.pHelperButton.Size = new System.Drawing.Size(94, 38);
            // 
            // tbUnitName
            // 
            this.tbUnitName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUnitName.Location = new System.Drawing.Point(109, 94);
            this.tbUnitName.Name = "tbUnitName";
            this.tbUnitName.Size = new System.Drawing.Size(195, 30);
            this.tbUnitName.TabIndex = 9;
            // 
            // lbUnitName
            // 
            this.lbUnitName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnitName.AutoSize = true;
            this.lbUnitName.Location = new System.Drawing.Point(61, 97);
            this.lbUnitName.Name = "lbUnitName";
            this.lbUnitName.Size = new System.Drawing.Size(42, 23);
            this.lbUnitName.TabIndex = 10;
            this.lbUnitName.Text = "الكمية";
            // 
            // UnitEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.ClientSize = new System.Drawing.Size(359, 217);
            this.Controls.Add(this.lbUnitName);
            this.Controls.Add(this.tbUnitName);
            this.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.Name = "UnitEditForm";
            this.Padding = new System.Windows.Forms.Padding(10, 80, 10, 10);
            this.Resizable = false;
            this.Text = "تعريف كمية";
            this.Load += new System.EventHandler(this.UnitEditForm_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.tbUnitName, 0);
            this.Controls.SetChildIndex(this.lbUnitName, 0);
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

        private System.Windows.Forms.TextBox tbUnitName;
        private System.Windows.Forms.Label lbUnitName;
    }
}
