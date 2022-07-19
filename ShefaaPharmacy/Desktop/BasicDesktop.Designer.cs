
namespace ShefaaPharmacy.Desktop
{
    partial class BasicDesktop
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicDesktop));
            this.pnlproccess = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlproccess
            // 
            this.pnlproccess.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlproccess.BackgroundImage")));
            this.pnlproccess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlproccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlproccess.Font = new System.Drawing.Font("AD-STOOR", 8F);
            this.pnlproccess.Location = new System.Drawing.Point(0, 0);
            this.pnlproccess.Name = "pnlproccess";
            this.pnlproccess.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlproccess.Size = new System.Drawing.Size(804, 521);
            this.pnlproccess.TabIndex = 17;
            // 
            // BasicDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlproccess);
            this.Name = "BasicDesktop";
            this.Size = new System.Drawing.Size(804, 521);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlproccess;
    }
}
