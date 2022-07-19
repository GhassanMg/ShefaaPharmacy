namespace ShefaaPharmacy.Accounting
{
    partial class AccountPaymentEditForm
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
            this.pFill = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAccountCash = new System.Windows.Forms.LinkLabel();
            this.lbAccountId = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCashOut = new System.Windows.Forms.RadioButton();
            this.rbCashIn = new System.Windows.Forms.RadioButton();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lbAmount = new System.Windows.Forms.Label();
            this.tbAccountCash = new System.Windows.Forms.TextBox();
            this.tbAccountId = new System.Windows.Forms.TextBox();
            this.ttPaymentAccount = new System.Windows.Forms.ToolTip(this.components);
            this.pBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.pFill.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMaximaizing
            // 
            this.btnMaximaizing.Enabled = false;
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(710, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // pFill
            // 
            this.pFill.Controls.Add(this.label1);
            this.pFill.Controls.Add(this.tbId);
            this.pFill.Controls.Add(this.dtDate);
            this.pFill.Controls.Add(this.label2);
            this.pFill.Controls.Add(this.lbAccountCash);
            this.pFill.Controls.Add(this.lbAccountId);
            this.pFill.Controls.Add(this.groupBox1);
            this.pFill.Controls.Add(this.tbDescription);
            this.pFill.Controls.Add(this.lbDescription);
            this.pFill.Controls.Add(this.tbAmount);
            this.pFill.Controls.Add(this.lbAmount);
            this.pFill.Controls.Add(this.tbAccountCash);
            this.pFill.Controls.Add(this.tbAccountId);
            this.pFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.pFill.Location = new System.Drawing.Point(24, 63);
            this.pFill.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pFill.Name = "pFill";
            this.pFill.Size = new System.Drawing.Size(772, 200);
            this.pFill.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "رقم قيد الدفعة";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(156, 28);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(100, 24);
            this.tbId.TabIndex = 46;
            this.tbId.TextChanged += new System.EventHandler(this.tbId_TextChanged);
            this.tbId.Validating += new System.ComponentModel.CancelEventHandler(this.tbId_Validating);
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(456, 139);
            this.dtDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtDate.Name = "dtDate";
            this.dtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtDate.Size = new System.Drawing.Size(208, 24);
            this.dtDate.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(679, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 44;
            this.label2.Text = "تاريخ الدفعة";
            // 
            // lbAccountCash
            // 
            this.lbAccountCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAccountCash.AutoSize = true;
            this.lbAccountCash.Location = new System.Drawing.Point(267, 74);
            this.lbAccountCash.Name = "lbAccountCash";
            this.lbAccountCash.Size = new System.Drawing.Size(88, 18);
            this.lbAccountCash.TabIndex = 43;
            this.lbAccountCash.TabStop = true;
            this.lbAccountCash.Text = "حساب الصندوق";
            this.ttPaymentAccount.SetToolTip(this.lbAccountCash, "إستعراض حسابات الصناديق");
            this.lbAccountCash.Click += new System.EventHandler(this.pbAccountCashPick_Click);
            // 
            // lbAccountId
            // 
            this.lbAccountId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAccountId.AutoSize = true;
            this.lbAccountId.Location = new System.Drawing.Point(699, 74);
            this.lbAccountId.Name = "lbAccountId";
            this.lbAccountId.Size = new System.Drawing.Size(47, 18);
            this.lbAccountId.TabIndex = 42;
            this.lbAccountId.TabStop = true;
            this.lbAccountId.Text = "الحساب";
            this.ttPaymentAccount.SetToolTip(this.lbAccountId, "إستعراض الحسابات");
            this.lbAccountId.Click += new System.EventHandler(this.pbAccountPick_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbCashOut);
            this.groupBox1.Controls.Add(this.rbCashIn);
            this.groupBox1.Location = new System.Drawing.Point(397, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 50);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "حالة الواجهة";
            // 
            // rbCashOut
            // 
            this.rbCashOut.AutoSize = true;
            this.rbCashOut.Location = new System.Drawing.Point(200, 20);
            this.rbCashOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbCashOut.Name = "rbCashOut";
            this.rbCashOut.Size = new System.Drawing.Size(118, 22);
            this.rbCashOut.TabIndex = 39;
            this.rbCashOut.TabStop = true;
            this.rbCashOut.Text = "مدفوعات الصندوق";
            this.rbCashOut.UseVisualStyleBackColor = true;
            this.rbCashOut.CheckedChanged += new System.EventHandler(this.rbCashOut_CheckedChanged);
            // 
            // rbCashIn
            // 
            this.rbCashIn.AutoSize = true;
            this.rbCashIn.Location = new System.Drawing.Point(6, 20);
            this.rbCashIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbCashIn.Name = "rbCashIn";
            this.rbCashIn.Size = new System.Drawing.Size(122, 22);
            this.rbCashIn.TabIndex = 40;
            this.rbCashIn.TabStop = true;
            this.rbCashIn.Text = "مقبوضات الصندوق";
            this.rbCashIn.UseVisualStyleBackColor = true;
            this.rbCashIn.CheckedChanged += new System.EventHandler(this.rbCashIn_CheckedChanged);
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDescription.Location = new System.Drawing.Point(57, 170);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(607, 24);
            this.tbDescription.TabIndex = 38;
            // 
            // lbDescription
            // 
            this.lbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(711, 171);
            this.lbDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(35, 18);
            this.lbDescription.TabIndex = 37;
            this.lbDescription.Text = "البيان";
            // 
            // tbAmount
            // 
            this.tbAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAmount.Location = new System.Drawing.Point(456, 106);
            this.tbAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(208, 24);
            this.tbAmount.TabIndex = 31;
            this.tbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbAmount_KeyPress);
            // 
            // lbAmount
            // 
            this.lbAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAmount.AutoSize = true;
            this.lbAmount.Location = new System.Drawing.Point(711, 108);
            this.lbAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(35, 18);
            this.lbAmount.TabIndex = 30;
            this.lbAmount.Text = "المبلغ";
            // 
            // tbAccountCash
            // 
            this.tbAccountCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAccountCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAccountCash.Location = new System.Drawing.Point(57, 72);
            this.tbAccountCash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAccountCash.Name = "tbAccountCash";
            this.tbAccountCash.Size = new System.Drawing.Size(199, 24);
            this.tbAccountCash.TabIndex = 29;
            this.tbAccountCash.TextChanged += new System.EventHandler(this.tbAccountCash_TextChanged);
            // 
            // tbAccountId
            // 
            this.tbAccountId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAccountId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAccountId.Location = new System.Drawing.Point(456, 72);
            this.tbAccountId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbAccountId.Name = "tbAccountId";
            this.tbAccountId.Size = new System.Drawing.Size(208, 24);
            this.tbAccountId.TabIndex = 26;
            this.tbAccountId.TextChanged += new System.EventHandler(this.tbAccountId_TextChanged);
            // 
            // pBottom
            // 
            this.pBottom.Controls.Add(this.btnCancel);
            this.pBottom.Controls.Add(this.btnEdit);
            this.pBottom.Controls.Add(this.btnOk);
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pBottom.Location = new System.Drawing.Point(24, 263);
            this.pBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(772, 52);
            this.pBottom.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = global::ShefaaPharmacy.Properties.Resources.CancelButton;
            this.btnCancel.Location = new System.Drawing.Point(262, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnCancel.Size = new System.Drawing.Size(134, 35);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Image = global::ShefaaPharmacy.Properties.Resources.AddButton;
            this.btnEdit.Location = new System.Drawing.Point(403, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnEdit.Size = new System.Drawing.Size(134, 35);
            this.btnEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEdit.TabIndex = 8;
            this.btnEdit.TabStop = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Image = global::ShefaaPharmacy.Properties.Resources.Group_2315;
            this.btnOk.Location = new System.Drawing.Point(403, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnOk.Size = new System.Drawing.Size(134, 35);
            this.btnOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnOk.TabIndex = 6;
            this.btnOk.TabStop = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // AccountPaymentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(807, 323);
            this.Controls.Add(this.pFill);
            this.Controls.Add(this.pBottom);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountPaymentEditForm";
            this.Padding = new System.Windows.Forms.Padding(24, 63, 11, 8);
            this.Resizable = false;
            this.Text = "إدخال دفعة حساب";
            this.Load += new System.EventHandler(this.AccountPaymentEditForm_Load);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.pFill, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.pFill.ResumeLayout(false);
            this.pFill.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pFill;
        private System.Windows.Forms.TextBox tbAccountId;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.TextBox tbAccountCash;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.RadioButton rbCashIn;
        private System.Windows.Forms.RadioButton rbCashOut;
        private System.Windows.Forms.ToolTip ttPaymentAccount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pBottom;
        protected System.Windows.Forms.PictureBox btnCancel;
        protected System.Windows.Forms.PictureBox btnOk;
        private System.Windows.Forms.LinkLabel lbAccountCash;
        private System.Windows.Forms.LinkLabel lbAccountId;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbId;
        protected System.Windows.Forms.PictureBox btnEdit;
    }
}
