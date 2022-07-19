
namespace ShefaaPharmacy.Definition
{
    partial class FormatEditForm
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
            this.lbFormatName = new System.Windows.Forms.Label();
            this.tbFormatName = new System.Windows.Forms.TextBox();
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
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(74, 0);
            this.btnCancel.Size = new System.Drawing.Size(113, 50);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(191, 0);
            this.btnOk.Size = new System.Drawing.Size(113, 50);
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
            this.pHelperButton.Location = new System.Drawing.Point(313, 7);
            this.pHelperButton.Size = new System.Drawing.Size(94, 38);
            // 
            // lbFormatName
            // 
            this.lbFormatName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFormatName.AutoSize = true;
            this.lbFormatName.Location = new System.Drawing.Point(84, 117);
            this.lbFormatName.Name = "lbFormatName";
            this.lbFormatName.Size = new System.Drawing.Size(46, 23);
            this.lbFormatName.TabIndex = 12;
            this.lbFormatName.Text = "الشكل ";
            // 
            // tbFormatName
            // 
            this.tbFormatName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFormatName.Location = new System.Drawing.Point(136, 114);
            this.tbFormatName.Name = "tbFormatName";
            this.tbFormatName.Size = new System.Drawing.Size(195, 30);
            this.tbFormatName.TabIndex = 11;
            // 
            // FormatEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.ClientSize = new System.Drawing.Size(418, 258);
            this.Controls.Add(this.lbFormatName);
            this.Controls.Add(this.tbFormatName);
            this.Name = "FormatEditForm";
            this.Padding = new System.Windows.Forms.Padding(10, 80, 10, 10);
            this.Resizable = false;
            this.Load += new System.EventHandler(this.FormatEditForm_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.tbFormatName, 0);
            this.Controls.SetChildIndex(this.lbFormatName, 0);
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

        private System.Windows.Forms.Label lbFormatName;
        private System.Windows.Forms.TextBox tbFormatName;
    }
}
