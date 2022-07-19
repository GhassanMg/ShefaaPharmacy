
namespace ShefaaPharmacy.Accounting
{
    partial class AccountCategoryEditForm
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
            this.pMaster = new System.Windows.Forms.Panel();
            this.cbAccountBaseCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.pMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditBindingSource
            // 
            this.EditBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.EditBindingSource_AddingNew);
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(10, 222);
            this.pBottom.Size = new System.Drawing.Size(416, 48);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(72, 0);
            this.btnCancel.Size = new System.Drawing.Size(134, 50);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(217, 0);
            this.btnOk.Size = new System.Drawing.Size(134, 50);
            // 
            // btnMaximaizing
            // 
            this.btnMaximaizing.Location = new System.Drawing.Point(33, 0);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3, 0);
            // 
            // btnMinimizing
            // 
            this.btnMinimizing.Location = new System.Drawing.Point(65, 0);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(335, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.pHelperButton.Size = new System.Drawing.Size(94, 38);
            // 
            // pMaster
            // 
            this.pMaster.Controls.Add(this.cbAccountBaseCategory);
            this.pMaster.Controls.Add(this.label2);
            this.pMaster.Controls.Add(this.tbName);
            this.pMaster.Controls.Add(this.label1);
            this.pMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMaster.Location = new System.Drawing.Point(10, 80);
            this.pMaster.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pMaster.Name = "pMaster";
            this.pMaster.Size = new System.Drawing.Size(416, 142);
            this.pMaster.TabIndex = 1;
            // 
            // cbAccountBaseCategory
            // 
            this.cbAccountBaseCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAccountBaseCategory.FormattingEnabled = true;
            this.cbAccountBaseCategory.Location = new System.Drawing.Point(61, 77);
            this.cbAccountBaseCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAccountBaseCategory.Name = "cbAccountBaseCategory";
            this.cbAccountBaseCategory.Size = new System.Drawing.Size(199, 31);
            this.cbAccountBaseCategory.TabIndex = 7;
            this.cbAccountBaseCategory.SelectedIndexChanged += new System.EventHandler(this.cbAccountBaseCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "نوع الحساب";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(61, 28);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(199, 30);
            this.tbName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "اسم الحساب";
            // 
            // AccountCategoryEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.ClientSize = new System.Drawing.Size(436, 280);
            this.Controls.Add(this.pMaster);
            this.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.Name = "AccountCategoryEditForm";
            this.Padding = new System.Windows.Forms.Padding(10, 80, 10, 10);
            this.Resizable = false;
            this.Text = "حساب رئيسي";
            this.Load += new System.EventHandler(this.AccountCategoryEditForm_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.pMaster, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.pMaster.ResumeLayout(false);
            this.pMaster.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMaster;
        private System.Windows.Forms.ComboBox cbAccountBaseCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
    }
}
