
using ShefaaPharmacy.CustomeControls;

namespace ShefaaPharmacy.Desktop
{
    partial class AccountingDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountingDesktop));
            this.panel4 = new ShefaaPharmacy.CustomeControls.PanelEx();
            this.lblLoading = new System.Windows.Forms.Label();
            this.pcloader = new System.Windows.Forms.PictureBox();
            this.pbBillPick = new System.Windows.Forms.PictureBox();
            this.pbAccountReport = new System.Windows.Forms.PictureBox();
            this.pbPaymentAccount = new System.Windows.Forms.PictureBox();
            this.pbDeleteBill = new System.Windows.Forms.PictureBox();
            this.pbInvoiceBuy = new System.Windows.Forms.PictureBox();
            this.pbInvoiceSell = new System.Windows.Forms.PictureBox();
            this.pbReturnBill = new System.Windows.Forms.PictureBox();
            this.pbEditBill = new System.Windows.Forms.PictureBox();
            this.pbArticleDetail = new System.Windows.Forms.PictureBox();
            this.panel3 = new ShefaaPharmacy.CustomeControls.PanelEx();
            this.panel2 = new ShefaaPharmacy.CustomeControls.PanelEx();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcloader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBillPick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccountReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPaymentAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInvoiceBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInvoiceSell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReturnBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticleDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lblLoading);
            this.panel4.Controls.Add(this.pcloader);
            this.panel4.Controls.Add(this.pbBillPick);
            this.panel4.Controls.Add(this.pbAccountReport);
            this.panel4.Controls.Add(this.pbPaymentAccount);
            this.panel4.Controls.Add(this.pbDeleteBill);
            this.panel4.Controls.Add(this.pbInvoiceBuy);
            this.panel4.Controls.Add(this.pbInvoiceSell);
            this.panel4.Controls.Add(this.pbReturnBill);
            this.panel4.Controls.Add(this.pbEditBill);
            this.panel4.Controls.Add(this.pbArticleDetail);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1244, 744);
            this.panel4.TabIndex = 49;
            // 
            // lblLoading
            // 
            this.lblLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Gabriola", 9.25F);
            this.lblLoading.Location = new System.Drawing.Point(532, 301);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(168, 23);
            this.lblLoading.TabIndex = 61;
            this.lblLoading.Text = "يتم التحميل الان, يرجى الانتظار";
            this.lblLoading.Visible = false;
            // 
            // pcloader
            // 
            this.pcloader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pcloader.BackColor = System.Drawing.Color.Transparent;
            this.pcloader.Image = ((System.Drawing.Image)(resources.GetObject("pcloader.Image")));
            this.pcloader.Location = new System.Drawing.Point(574, 327);
            this.pcloader.Name = "pcloader";
            this.pcloader.Size = new System.Drawing.Size(79, 73);
            this.pcloader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcloader.TabIndex = 60;
            this.pcloader.TabStop = false;
            this.pcloader.Visible = false;
            // 
            // pbBillPick
            // 
            this.pbBillPick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBillPick.Image = ((System.Drawing.Image)(resources.GetObject("pbBillPick.Image")));
            this.pbBillPick.Location = new System.Drawing.Point(26, 26);
            this.pbBillPick.Name = "pbBillPick";
            this.pbBillPick.Size = new System.Drawing.Size(379, 131);
            this.pbBillPick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBillPick.TabIndex = 59;
            this.pbBillPick.TabStop = false;
            this.pbBillPick.Click += new System.EventHandler(this.pbBillPick_Click_1);
            // 
            // pbAccountReport
            // 
            this.pbAccountReport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbAccountReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAccountReport.Image = ((System.Drawing.Image)(resources.GetObject("pbAccountReport.Image")));
            this.pbAccountReport.Location = new System.Drawing.Point(426, 366);
            this.pbAccountReport.Name = "pbAccountReport";
            this.pbAccountReport.Size = new System.Drawing.Size(379, 131);
            this.pbAccountReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAccountReport.TabIndex = 58;
            this.pbAccountReport.TabStop = false;
            this.pbAccountReport.Click += new System.EventHandler(this.pbCashAccountReport_Click);
            // 
            // pbPaymentAccount
            // 
            this.pbPaymentAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPaymentAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPaymentAccount.Image = ((System.Drawing.Image)(resources.GetObject("pbPaymentAccount.Image")));
            this.pbPaymentAccount.Location = new System.Drawing.Point(826, 366);
            this.pbPaymentAccount.Name = "pbPaymentAccount";
            this.pbPaymentAccount.Size = new System.Drawing.Size(379, 131);
            this.pbPaymentAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPaymentAccount.TabIndex = 50;
            this.pbPaymentAccount.TabStop = false;
            this.pbPaymentAccount.Click += new System.EventHandler(this.pbPaymentAccount_Click);
            // 
            // pbDeleteBill
            // 
            this.pbDeleteBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDeleteBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDeleteBill.Image = ((System.Drawing.Image)(resources.GetObject("pbDeleteBill.Image")));
            this.pbDeleteBill.Location = new System.Drawing.Point(826, 196);
            this.pbDeleteBill.Name = "pbDeleteBill";
            this.pbDeleteBill.Size = new System.Drawing.Size(379, 131);
            this.pbDeleteBill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeleteBill.TabIndex = 53;
            this.pbDeleteBill.TabStop = false;
            this.pbDeleteBill.Click += new System.EventHandler(this.pbDeleteBill_Click);
            // 
            // pbInvoiceBuy
            // 
            this.pbInvoiceBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbInvoiceBuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbInvoiceBuy.Image = ((System.Drawing.Image)(resources.GetObject("pbInvoiceBuy.Image")));
            this.pbInvoiceBuy.Location = new System.Drawing.Point(826, 26);
            this.pbInvoiceBuy.Name = "pbInvoiceBuy";
            this.pbInvoiceBuy.Size = new System.Drawing.Size(379, 131);
            this.pbInvoiceBuy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInvoiceBuy.TabIndex = 51;
            this.pbInvoiceBuy.TabStop = false;
            this.pbInvoiceBuy.Click += new System.EventHandler(this.pbInvoiceBuy_Click);
            // 
            // pbInvoiceSell
            // 
            this.pbInvoiceSell.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbInvoiceSell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbInvoiceSell.Image = ((System.Drawing.Image)(resources.GetObject("pbInvoiceSell.Image")));
            this.pbInvoiceSell.Location = new System.Drawing.Point(426, 26);
            this.pbInvoiceSell.Name = "pbInvoiceSell";
            this.pbInvoiceSell.Size = new System.Drawing.Size(379, 131);
            this.pbInvoiceSell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInvoiceSell.TabIndex = 52;
            this.pbInvoiceSell.TabStop = false;
            this.pbInvoiceSell.Click += new System.EventHandler(this.pbInvoiceSell_Click);
            // 
            // pbReturnBill
            // 
            this.pbReturnBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbReturnBill.Image = ((System.Drawing.Image)(resources.GetObject("pbReturnBill.Image")));
            this.pbReturnBill.Location = new System.Drawing.Point(26, 196);
            this.pbReturnBill.Name = "pbReturnBill";
            this.pbReturnBill.Size = new System.Drawing.Size(379, 131);
            this.pbReturnBill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReturnBill.TabIndex = 55;
            this.pbReturnBill.TabStop = false;
            this.pbReturnBill.Click += new System.EventHandler(this.pbReturnBill_Click);
            // 
            // pbEditBill
            // 
            this.pbEditBill.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbEditBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbEditBill.Image = global::ShefaaPharmacy.Properties.Resources.Card_Rep_Cash;
            this.pbEditBill.Location = new System.Drawing.Point(426, 196);
            this.pbEditBill.Name = "pbEditBill";
            this.pbEditBill.Size = new System.Drawing.Size(379, 131);
            this.pbEditBill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEditBill.TabIndex = 56;
            this.pbEditBill.TabStop = false;
            this.pbEditBill.Click += new System.EventHandler(this.pbEditBill_Click);
            // 
            // pbArticleDetail
            // 
            this.pbArticleDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbArticleDetail.Image = ((System.Drawing.Image)(resources.GetObject("pbArticleDetail.Image")));
            this.pbArticleDetail.Location = new System.Drawing.Point(26, 366);
            this.pbArticleDetail.Name = "pbArticleDetail";
            this.pbArticleDetail.Size = new System.Drawing.Size(379, 131);
            this.pbArticleDetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArticleDetail.TabIndex = 54;
            this.pbArticleDetail.TabStop = false;
            this.pbArticleDetail.Click += new System.EventHandler(this.pbArticleDetailReport_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1244, 0);
            this.panel3.TabIndex = 48;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1244, 0);
            this.panel2.TabIndex = 47;
            // 
            // AccountingDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AccountingDesktop";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1244, 744);
            this.Load += new System.EventHandler(this.AccountingDesktop_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcloader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBillPick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccountReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPaymentAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInvoiceBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInvoiceSell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReturnBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEditBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArticleDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PanelEx panel2;
        private PanelEx panel3;
        private PanelEx panel4;
        private System.Windows.Forms.PictureBox pbPaymentAccount;
        private System.Windows.Forms.PictureBox pbDeleteBill;
        private System.Windows.Forms.PictureBox pbInvoiceBuy;
        private System.Windows.Forms.PictureBox pbInvoiceSell;
        private System.Windows.Forms.PictureBox pbReturnBill;
        private System.Windows.Forms.PictureBox pbEditBill;
        private System.Windows.Forms.PictureBox pbArticleDetail;
        private System.Windows.Forms.PictureBox pbBillPick;
        private System.Windows.Forms.PictureBox pbAccountReport;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.PictureBox pcloader;
    }
}
