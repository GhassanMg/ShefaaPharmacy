namespace ShefaaPharmacy.GeneralUI
{
    partial class _MessageBoxDialog
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.pFill = new System.Windows.Forms.Panel();
            this.lbMessageText = new System.Windows.Forms.Label();
            this.pYesNo = new System.Windows.Forms.Panel();
            this.pbYes = new System.Windows.Forms.PictureBox();
            this.pbNo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.pFill.SuspendLayout();
            this.pYesNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbYes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNo)).BeginInit();
            this.SuspendLayout();
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(380, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime;
            // 
            // pFill
            // 
            this.pFill.AutoSize = true;
            this.pFill.Controls.Add(this.lbMessageText);
            this.pFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFill.Location = new System.Drawing.Point(20, 80);
            this.pFill.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pFill.Name = "pFill";
            this.pFill.Size = new System.Drawing.Size(446, 132);
            this.pFill.TabIndex = 7;
            // 
            // lbMessageText
            // 
            this.lbMessageText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMessageText.AutoEllipsis = true;
            this.lbMessageText.Font = new System.Drawing.Font("AD-STOOR", 12F);
            this.lbMessageText.Location = new System.Drawing.Point(13, 4);
            this.lbMessageText.Name = "lbMessageText";
            this.lbMessageText.Size = new System.Drawing.Size(423, 124);
            this.lbMessageText.TabIndex = 9;
            this.lbMessageText.Text = " ;slakf;sldfk";
            this.lbMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pYesNo
            // 
            this.pYesNo.Controls.Add(this.pbYes);
            this.pYesNo.Controls.Add(this.pbNo);
            this.pYesNo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pYesNo.Location = new System.Drawing.Point(20, 212);
            this.pYesNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pYesNo.Name = "pYesNo";
            this.pYesNo.Size = new System.Drawing.Size(446, 49);
            this.pYesNo.TabIndex = 6;
            // 
            // pbYes
            // 
            this.pbYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbYes.Image = global::ShefaaPharmacy.Properties.Resources.Group_2315;
            this.pbYes.Location = new System.Drawing.Point(207, 0);
            this.pbYes.Name = "pbYes";
            this.pbYes.Size = new System.Drawing.Size(109, 49);
            this.pbYes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbYes.TabIndex = 20;
            this.pbYes.TabStop = false;
            this.pbYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // pbNo
            // 
            this.pbNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNo.Image = global::ShefaaPharmacy.Properties.Resources.Group_2299__1_;
            this.pbNo.Location = new System.Drawing.Point(92, 0);
            this.pbNo.Name = "pbNo";
            this.pbNo.Size = new System.Drawing.Size(109, 49);
            this.pbNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbNo.TabIndex = 19;
            this.pbNo.TabStop = false;
            this.pbNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // _MessageBoxDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(476, 271);
            this.Controls.Add(this.pFill);
            this.Controls.Add(this.pYesNo);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "_MessageBoxDialog";
            this.Resizable = false;
            this.Load += new System.EventHandler(this._MessageBoxDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this._MessageBoxDialog_KeyDown);
            this.Controls.SetChildIndex(this.pYesNo, 0);
            this.Controls.SetChildIndex(this.pFill, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.pFill.ResumeLayout(false);
            this.pYesNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbYes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.Panel pFill;
        private System.Windows.Forms.Label lbMessageText;
        private System.Windows.Forms.Panel pYesNo;
        private System.Windows.Forms.PictureBox pbYes;
        private System.Windows.Forms.PictureBox pbNo;
    }
}
