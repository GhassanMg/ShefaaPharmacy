namespace ShefaaPharmacy.GeneralUI
{
    partial class GeneralEditForm
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
            this.EditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.SuspendLayout();
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(322, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            // 
            // EditBindingSource
            // 
            this.EditBindingSource.DataSourceChanged += new System.EventHandler(this.EditBindingSource_DataSourceChanged);
            // 
            // pBottom
            // 
            this.pBottom.Controls.Add(this.btnCancel);
            this.pBottom.Controls.Add(this.btnOk);
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottom.Location = new System.Drawing.Point(10, 200);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(398, 48);
            this.pBottom.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = global::ShefaaPharmacy.Properties.Resources.CancelButton;
            this.btnCancel.Location = new System.Drawing.Point(86, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(2);
            this.btnCancel.Size = new System.Drawing.Size(105, 47);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = global::ShefaaPharmacy.Properties.Resources.Group_2315;
            this.btnOk.Location = new System.Drawing.Point(202, 1);
            this.btnOk.Name = "btnOk";
            this.btnOk.Padding = new System.Windows.Forms.Padding(2);
            this.btnOk.Size = new System.Drawing.Size(105, 47);
            this.btnOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnOk.TabIndex = 4;
            this.btnOk.TabStop = false;
            this.btnOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // GeneralEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.ClientSize = new System.Drawing.Size(418, 258);
            this.Controls.Add(this.pBottom);
            this.Font = new System.Drawing.Font("AD-STOOR", 11F);
            this.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.Name = "GeneralEditForm";
            this.Padding = new System.Windows.Forms.Padding(10, 80, 10, 10);
            this.Load += new System.EventHandler(this.GeneralEditForm_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.BindingSource EditBindingSource;
        protected System.Windows.Forms.Panel pBottom;
        protected System.Windows.Forms.PictureBox btnCancel;
        protected System.Windows.Forms.PictureBox btnOk;
    }
}
