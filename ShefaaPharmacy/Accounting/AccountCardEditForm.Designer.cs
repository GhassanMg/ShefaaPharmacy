
namespace ShefaaPharmacy.Accounting
{
    partial class AccountCardEditForm
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
            this.AllAccounts_linkLabel = new System.Windows.Forms.LinkLabel();
            this.lbAccountParent = new System.Windows.Forms.LinkLabel();
            this.lbCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbAddress2 = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbTel2 = new System.Windows.Forms.Label();
            this.lbTel = new System.Windows.Forms.Label();
            this.lbAccountState = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbTel2 = new System.Windows.Forms.TextBox();
            this.tbAddress2 = new System.Windows.Forms.TextBox();
            this.tbTel = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbAccountParent = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.gbAccountType = new System.Windows.Forms.GroupBox();
            this.rbChild = new System.Windows.Forms.RadioButton();
            this.rbParent = new System.Windows.Forms.RadioButton();
            this.cbAccountState = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbAccountType.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditBindingSource
            // 
            this.EditBindingSource.DataSourceChanged += new System.EventHandler(this.EditBindingSource_DataSourceChanged);
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(11, 321);
            this.pBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBottom.Size = new System.Drawing.Size(902, 38);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2033, 0);
            this.btnCancel.Size = new System.Drawing.Size(126, 41);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(2163, 0);
            this.btnOk.Size = new System.Drawing.Size(126, 41);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(815, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AllAccounts_linkLabel);
            this.panel1.Controls.Add(this.lbAccountParent);
            this.panel1.Controls.Add(this.lbCategory);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.lbDescription);
            this.panel1.Controls.Add(this.lbAddress2);
            this.panel1.Controls.Add(this.lbAddress);
            this.panel1.Controls.Add(this.lbTel2);
            this.panel1.Controls.Add(this.lbTel);
            this.panel1.Controls.Add(this.lbAccountState);
            this.panel1.Controls.Add(this.lbLastName);
            this.panel1.Controls.Add(this.lbName);
            this.panel1.Controls.Add(this.tbDescription);
            this.panel1.Controls.Add(this.tbTel2);
            this.panel1.Controls.Add(this.tbAddress2);
            this.panel1.Controls.Add(this.tbTel);
            this.panel1.Controls.Add(this.tbAddress);
            this.panel1.Controls.Add(this.tbAccountParent);
            this.panel1.Controls.Add(this.tbLastName);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Controls.Add(this.gbAccountType);
            this.panel1.Controls.Add(this.cbAccountState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(11, 63);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 296);
            this.panel1.TabIndex = 135;
            // 
            // AllAccounts_linkLabel
            // 
            this.AllAccounts_linkLabel.AutoSize = true;
            this.AllAccounts_linkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AllAccounts_linkLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.AllAccounts_linkLabel.LinkColor = System.Drawing.Color.Maroon;
            this.AllAccounts_linkLabel.Location = new System.Drawing.Point(29, 16);
            this.AllAccounts_linkLabel.Name = "AllAccounts_linkLabel";
            this.AllAccounts_linkLabel.Size = new System.Drawing.Size(139, 20);
            this.AllAccounts_linkLabel.TabIndex = 154;
            this.AllAccounts_linkLabel.TabStop = true;
            this.AllAccounts_linkLabel.Text = "استعراض جميع الحسابات";
            this.AllAccounts_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AllAccounts_linkLabel_LinkClicked);
            // 
            // lbAccountParent
            // 
            this.lbAccountParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAccountParent.AutoSize = true;
            this.lbAccountParent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAccountParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbAccountParent.Location = new System.Drawing.Point(777, 105);
            this.lbAccountParent.Name = "lbAccountParent";
            this.lbAccountParent.Size = new System.Drawing.Size(82, 17);
            this.lbAccountParent.TabIndex = 153;
            this.lbAccountParent.TabStop = true;
            this.lbAccountParent.Text = "الحساب الرئيسي";
            this.lbAccountParent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbAccountParent_LinkClicked_1);
            // 
            // lbCategory
            // 
            this.lbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(400, 103);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(69, 18);
            this.lbCategory.TabIndex = 152;
            this.lbCategory.Text = "نوع الحساب";
            // 
            // cbCategory
            // 
            this.cbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(135, 105);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(241, 26);
            this.cbCategory.TabIndex = 151;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // lbDescription
            // 
            this.lbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(801, 235);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(50, 18);
            this.lbDescription.TabIndex = 150;
            this.lbDescription.Text = "معلومات";
            // 
            // lbAddress2
            // 
            this.lbAddress2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAddress2.AutoSize = true;
            this.lbAddress2.Location = new System.Drawing.Point(409, 204);
            this.lbAddress2.Name = "lbAddress2";
            this.lbAddress2.Size = new System.Drawing.Size(55, 18);
            this.lbAddress2.TabIndex = 149;
            this.lbAddress2.Text = "العنوان 2";
            // 
            // lbAddress
            // 
            this.lbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAddress.AutoSize = true;
            this.lbAddress.Location = new System.Drawing.Point(799, 203);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(43, 18);
            this.lbAddress.TabIndex = 148;
            this.lbAddress.Text = "العنوان";
            // 
            // lbTel2
            // 
            this.lbTel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTel2.AutoSize = true;
            this.lbTel2.Location = new System.Drawing.Point(393, 169);
            this.lbTel2.Name = "lbTel2";
            this.lbTel2.Size = new System.Drawing.Size(73, 18);
            this.lbTel2.TabIndex = 147;
            this.lbTel2.Text = "رقم الهاتف 2";
            // 
            // lbTel
            // 
            this.lbTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTel.AutoSize = true;
            this.lbTel.Location = new System.Drawing.Point(791, 169);
            this.lbTel.Name = "lbTel";
            this.lbTel.Size = new System.Drawing.Size(61, 18);
            this.lbTel.TabIndex = 146;
            this.lbTel.Text = "رقم الهاتف";
            // 
            // lbAccountState
            // 
            this.lbAccountState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAccountState.AutoSize = true;
            this.lbAccountState.Location = new System.Drawing.Point(779, 138);
            this.lbAccountState.Name = "lbAccountState";
            this.lbAccountState.Size = new System.Drawing.Size(80, 18);
            this.lbAccountState.TabIndex = 145;
            this.lbAccountState.Text = "طبيعة الحساب";
            // 
            // lbLastName
            // 
            this.lbLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLastName.AutoSize = true;
            this.lbLastName.Location = new System.Drawing.Point(400, 71);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(66, 18);
            this.lbLastName.TabIndex = 144;
            this.lbLastName.Text = "الاسم الثاني";
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(784, 74);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(69, 18);
            this.lbName.TabIndex = 143;
            this.lbName.Text = "اسم الحساب";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(135, 232);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(617, 24);
            this.tbDescription.TabIndex = 142;
            // 
            // tbTel2
            // 
            this.tbTel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTel2.Location = new System.Drawing.Point(135, 166);
            this.tbTel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbTel2.Name = "tbTel2";
            this.tbTel2.Size = new System.Drawing.Size(241, 24);
            this.tbTel2.TabIndex = 141;
            this.tbTel2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTel2_KeyPress);
            // 
            // tbAddress2
            // 
            this.tbAddress2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddress2.Location = new System.Drawing.Point(135, 201);
            this.tbAddress2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbAddress2.Name = "tbAddress2";
            this.tbAddress2.Size = new System.Drawing.Size(241, 24);
            this.tbAddress2.TabIndex = 140;
            // 
            // tbTel
            // 
            this.tbTel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTel.Location = new System.Drawing.Point(525, 166);
            this.tbTel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(227, 24);
            this.tbTel.TabIndex = 139;
            this.tbTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTel_KeyPress);
            // 
            // tbAddress
            // 
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddress.Location = new System.Drawing.Point(525, 199);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(227, 24);
            this.tbAddress.TabIndex = 138;
            // 
            // tbAccountParent
            // 
            this.tbAccountParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAccountParent.Location = new System.Drawing.Point(525, 103);
            this.tbAccountParent.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbAccountParent.Name = "tbAccountParent";
            this.tbAccountParent.Size = new System.Drawing.Size(227, 24);
            this.tbAccountParent.TabIndex = 137;
            this.tbAccountParent.Validating += new System.ComponentModel.CancelEventHandler(this.tbAccountParent_Validating);
            // 
            // tbLastName
            // 
            this.tbLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLastName.Location = new System.Drawing.Point(135, 71);
            this.tbLastName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(241, 24);
            this.tbLastName.TabIndex = 136;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(525, 71);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(227, 24);
            this.tbName.TabIndex = 135;
            // 
            // gbAccountType
            // 
            this.gbAccountType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAccountType.Controls.Add(this.rbChild);
            this.gbAccountType.Controls.Add(this.rbParent);
            this.gbAccountType.Location = new System.Drawing.Point(522, 6);
            this.gbAccountType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbAccountType.Name = "gbAccountType";
            this.gbAccountType.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gbAccountType.Size = new System.Drawing.Size(362, 54);
            this.gbAccountType.TabIndex = 134;
            this.gbAccountType.TabStop = false;
            this.gbAccountType.Text = "نوع الحساب";
            // 
            // rbChild
            // 
            this.rbChild.AutoSize = true;
            this.rbChild.Location = new System.Drawing.Point(279, 27);
            this.rbChild.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.rbChild.Name = "rbChild";
            this.rbChild.Size = new System.Drawing.Size(54, 22);
            this.rbChild.TabIndex = 1;
            this.rbChild.TabStop = true;
            this.rbChild.Text = "فرعي";
            this.rbChild.UseVisualStyleBackColor = true;
            this.rbChild.CheckedChanged += new System.EventHandler(this.rbChild_CheckedChanged);
            // 
            // rbParent
            // 
            this.rbParent.AutoSize = true;
            this.rbParent.Location = new System.Drawing.Point(200, 27);
            this.rbParent.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.rbParent.Name = "rbParent";
            this.rbParent.Size = new System.Drawing.Size(59, 22);
            this.rbParent.TabIndex = 0;
            this.rbParent.TabStop = true;
            this.rbParent.Text = "رئيسي";
            this.rbParent.UseVisualStyleBackColor = true;
            this.rbParent.CheckedChanged += new System.EventHandler(this.rbParent_CheckedChanged);
            // 
            // cbAccountState
            // 
            this.cbAccountState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAccountState.FormattingEnabled = true;
            this.cbAccountState.Location = new System.Drawing.Point(525, 136);
            this.cbAccountState.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbAccountState.Name = "cbAccountState";
            this.cbAccountState.Size = new System.Drawing.Size(227, 26);
            this.cbAccountState.TabIndex = 133;
            this.cbAccountState.SelectedIndexChanged += new System.EventHandler(this.cbAccountState_SelectedIndexChanged);
            // 
            // AccountCardEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.BackLocation = MetroFramework.Forms.BackLocation.TopRight;
            this.ClientSize = new System.Drawing.Size(924, 367);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "AccountCardEditForm";
            this.Padding = new System.Windows.Forms.Padding(11, 63, 11, 8);
            this.Text = "تعريف بطاقة حساب";
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
            this.gbAccountType.ResumeLayout(false);
            this.gbAccountType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lbAccountParent;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbAddress2;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbTel2;
        private System.Windows.Forms.Label lbTel;
        private System.Windows.Forms.Label lbAccountState;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbTel2;
        private System.Windows.Forms.TextBox tbAddress2;
        private System.Windows.Forms.TextBox tbTel;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbAccountParent;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox gbAccountType;
        private System.Windows.Forms.RadioButton rbChild;
        private System.Windows.Forms.RadioButton rbParent;
        private System.Windows.Forms.ComboBox cbAccountState;
        private System.Windows.Forms.LinkLabel AllAccounts_linkLabel;
    }
}
