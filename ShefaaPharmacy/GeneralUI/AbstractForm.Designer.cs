namespace ShefaaPharmacy.GeneralUI
{
    partial class AbstractForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbstractForm));
            this.btnMaximaizing = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnMinimizing = new System.Windows.Forms.PictureBox();
            this.pHelperButton = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMaximaizing
            // 
            this.btnMaximaizing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximaizing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximaizing.Image = global::ShefaaPharmacy.Properties.Resources.icons8_maximize_window_48px;
            this.btnMaximaizing.Location = new System.Drawing.Point(36, 2);
            this.btnMaximaizing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMaximaizing.Name = "btnMaximaizing";
            this.btnMaximaizing.Size = new System.Drawing.Size(26, 34);
            this.btnMaximaizing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximaizing.TabIndex = 5;
            this.btnMaximaizing.TabStop = false;
            this.btnMaximaizing.Click += new System.EventHandler(this.btnMaximaizing_Click);
            this.btnMaximaizing.MouseHover += new System.EventHandler(this.btnMaximaizing_MouseHover);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::ShefaaPharmacy.Properties.Resources.icons8_close_window_48px;
            this.btnClose.Location = new System.Drawing.Point(6, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 34);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // btnMinimizing
            // 
            this.btnMinimizing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizing.Image = global::ShefaaPharmacy.Properties.Resources.icons8_minimize_window_48px;
            this.btnMinimizing.Location = new System.Drawing.Point(67, 2);
            this.btnMinimizing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMinimizing.Name = "btnMinimizing";
            this.btnMinimizing.Size = new System.Drawing.Size(26, 34);
            this.btnMinimizing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizing.TabIndex = 6;
            this.btnMinimizing.TabStop = false;
            this.btnMinimizing.Click += new System.EventHandler(this.btnMinimizing_Click);
            this.btnMinimizing.MouseHover += new System.EventHandler(this.btnMinimizing_MouseHover);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Controls.Add(this.btnMinimizing);
            this.pHelperButton.Controls.Add(this.btnClose);
            this.pHelperButton.Controls.Add(this.btnMaximaizing);
            this.pHelperButton.Location = new System.Drawing.Point(295, 10);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pHelperButton.Name = "pHelperButton";
            this.pHelperButton.Size = new System.Drawing.Size(97, 38);
            this.pHelperButton.TabIndex = 0;
            // 
            // AbstractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 247);
            this.ControlBox = false;
            this.Controls.Add(this.pHelperButton);
            this.Font = new System.Drawing.Font("AD-STOOR", 9.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AbstractForm";
            this.Padding = new System.Windows.Forms.Padding(20, 80, 10, 10);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Load += new System.EventHandler(this.AbstractForm_Load);
            this.SizeChanged += new System.EventHandler(this.AbstractForm_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AbstractForm_MouseClick);
            this.Resize += new System.EventHandler(this.AbstractForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.PictureBox btnMaximaizing;
        protected System.Windows.Forms.PictureBox btnClose;
        protected System.Windows.Forms.PictureBox btnMinimizing;
        protected System.Windows.Forms.Panel pHelperButton;
    }
}