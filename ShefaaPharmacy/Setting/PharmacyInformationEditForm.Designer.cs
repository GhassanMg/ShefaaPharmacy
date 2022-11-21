
namespace ShefaaPharmacy.setting
{
    partial class PharmacyInformationEditForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCommercialRegisterNumber = new System.Windows.Forms.Label();
            this.tbCommercialNumber = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbTel = new System.Windows.Forms.Label();
            this.lbOwnerName = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbTel = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbOwnerName = new System.Windows.Forms.TextBox();
            this.tbPharmacyName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditBindingSource
            // 
            this.EditBindingSource.DataSourceChanged += new System.EventHandler(this.EditBindingSource_DataSourceChanged);
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(11, 286);
            this.pBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBottom.Size = new System.Drawing.Size(902, 38);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3041, 0);
            this.btnCancel.Size = new System.Drawing.Size(126, 41);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(3171, 0);
            this.btnOk.Size = new System.Drawing.Size(126, 41);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(815, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbCommercialRegisterNumber);
            this.panel1.Controls.Add(this.tbCommercialNumber);
            this.panel1.Controls.Add(this.lbDescription);
            this.panel1.Controls.Add(this.lbAddress);
            this.panel1.Controls.Add(this.lbTel);
            this.panel1.Controls.Add(this.lbOwnerName);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.tbDescription);
            this.panel1.Controls.Add(this.tbTel);
            this.panel1.Controls.Add(this.tbAddress);
            this.panel1.Controls.Add(this.tbOwnerName);
            this.panel1.Controls.Add(this.tbPharmacyName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(11, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 261);
            this.panel1.TabIndex = 135;
            // 
            // lbCommercialRegisterNumber
            // 
            this.lbCommercialRegisterNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCommercialRegisterNumber.AutoSize = true;
            this.lbCommercialRegisterNumber.Location = new System.Drawing.Point(394, 68);
            this.lbCommercialRegisterNumber.Name = "lbCommercialRegisterNumber";
            this.lbCommercialRegisterNumber.Size = new System.Drawing.Size(84, 18);
            this.lbCommercialRegisterNumber.TabIndex = 152;
            this.lbCommercialRegisterNumber.Text = "السجل التجاري";
            // 
            // tbCommercialNumber
            // 
            this.tbCommercialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCommercialNumber.Location = new System.Drawing.Point(135, 65);
            this.tbCommercialNumber.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbCommercialNumber.Name = "tbCommercialNumber";
            this.tbCommercialNumber.Size = new System.Drawing.Size(241, 24);
            this.tbCommercialNumber.TabIndex = 151;
            // 
            // lbDescription
            // 
            this.lbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(767, 163);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(89, 18);
            this.lbDescription.TabIndex = 150;
            this.lbDescription.Text = "معلومات اضافية";
            // 
            // lbAddress
            // 
            this.lbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(813, 102);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(43, 18);
            this.lbAddress.TabIndex = 148;
            this.lbAddress.Text = "العنوان";
            // 
            // lbTel
            // 
            this.lbTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTel.AutoSize = true;
            this.lbTel.Location = new System.Drawing.Point(795, 68);
            this.lbTel.Name = "lbTel";
            this.lbTel.Size = new System.Drawing.Size(61, 18);
            this.lbTel.TabIndex = 146;
            this.lbTel.Text = "رقم الهاتف";
            // 
            // lbOwnerName
            // 
            this.lbOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOwnerName.AutoSize = true;
            this.lbOwnerName.Location = new System.Drawing.Point(419, 34);
            this.lbOwnerName.Name = "lbOwnerName";
            this.lbOwnerName.Size = new System.Drawing.Size(59, 18);
            this.lbOwnerName.TabIndex = 144;
            this.lbOwnerName.Text = "اسم المالك";
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(784, 34);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(72, 18);
            this.lbName.TabIndex = 143;
            this.lbName.Text = "اسم الصيدلية";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(135, 133);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(617, 83);
            this.tbDescription.TabIndex = 142;
            // 
            // tbTel
            // 
            this.tbTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTel.Location = new System.Drawing.Point(525, 65);
            this.tbTel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(227, 24);
            this.tbTel.TabIndex = 139;
            this.tbTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTel_KeyPress);
            // 
            // tbAddress
            // 
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddress.Location = new System.Drawing.Point(525, 99);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(227, 24);
            this.tbAddress.TabIndex = 138;
            // 
            // tbOwnerName
            // 
            this.tbOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOwnerName.Location = new System.Drawing.Point(135, 31);
            this.tbOwnerName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbOwnerName.Name = "tbOwnerName";
            this.tbOwnerName.Size = new System.Drawing.Size(241, 24);
            this.tbOwnerName.TabIndex = 136;
            // 
            // tbPharmacyName
            // 
            this.tbPharmacyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPharmacyName.Location = new System.Drawing.Point(525, 31);
            this.tbPharmacyName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbPharmacyName.Name = "tbPharmacyName";
            this.tbPharmacyName.Size = new System.Drawing.Size(227, 24);
            this.tbPharmacyName.TabIndex = 135;
            // 
            // PharmacyInformationEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.BackLocation = MetroFramework.Forms.BackLocation.TopRight;
            this.ClientSize = new System.Drawing.Size(924, 332);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "PharmacyInformationEditForm";
            this.Padding = new System.Windows.Forms.Padding(11, 63, 11, 8);
            this.Text = "معلومات الصيدلية";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbTel;
        private System.Windows.Forms.Label lbOwnerName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbTel;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbOwnerName;
        private System.Windows.Forms.TextBox tbPharmacyName;
        private System.Windows.Forms.Label lbCommercialRegisterNumber;
        private System.Windows.Forms.TextBox tbCommercialNumber;
    }
}
