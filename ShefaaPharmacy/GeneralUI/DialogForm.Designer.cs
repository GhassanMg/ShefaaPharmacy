namespace ShefaaPharmacy.GeneralUI
{
    partial class DialogForm
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
            this.plButtom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.PictureBox();
            this.pHelperButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.plButtom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.SuspendLayout();
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(337, 10);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            // 
            // plButtom
            // 
            this.plButtom.Controls.Add(this.btnCancel);
            this.plButtom.Controls.Add(this.btnOk);
            this.plButtom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtom.Location = new System.Drawing.Point(10, 253);
            this.plButtom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plButtom.Name = "plButtom";
            this.plButtom.Size = new System.Drawing.Size(481, 45);
            this.plButtom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = global::ShefaaPharmacy.Properties.Resources.CancelButton;
            this.btnCancel.Location = new System.Drawing.Point(125, -4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 53);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = global::ShefaaPharmacy.Properties.Resources.Group_2315;
            this.btnOk.Location = new System.Drawing.Point(243, -4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 53);
            this.btnOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnOk.TabIndex = 6;
            this.btnOk.TabStop = false;
            this.btnOk.Click += new System.EventHandler(this.btOK_Click);
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.ClientSize = new System.Drawing.Size(501, 308);
            this.Controls.Add(this.plButtom);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "DialogForm";
            this.Controls.SetChildIndex(this.plButtom, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.pHelperButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.plButtom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.PictureBox btnCancel;
        protected System.Windows.Forms.PictureBox btnOk;
        protected System.Windows.Forms.Panel plButtom;
    }
}
