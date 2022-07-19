
namespace ShefaaPharmacy.Desktop
{
    partial class DesktopEazyWay
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
            this.dgMasterEazyWay = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgMasterEazyWay)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMasterEazyWay
            // 
            this.dgMasterEazyWay.BackgroundColor = System.Drawing.Color.White;
            this.dgMasterEazyWay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMasterEazyWay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMasterEazyWay.GridColor = System.Drawing.Color.White;
            this.dgMasterEazyWay.Location = new System.Drawing.Point(0, 0);
            this.dgMasterEazyWay.Name = "dgMasterEazyWay";
            this.dgMasterEazyWay.Size = new System.Drawing.Size(804, 521);
            this.dgMasterEazyWay.TabIndex = 0;
            this.dgMasterEazyWay.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMasterEazyWay_RowLeave);
            // 
            // DesktopEazyWay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgMasterEazyWay);
            this.Name = "DesktopEazyWay";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(804, 521);
            ((System.ComponentModel.ISupportInitialize)(this.dgMasterEazyWay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMasterEazyWay;
    }
}
