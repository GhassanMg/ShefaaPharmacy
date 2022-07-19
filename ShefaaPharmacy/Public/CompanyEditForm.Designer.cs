namespace ShefaaPharmacy.Public
{
    partial class CompanyEditForm
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
            this.tbLocationCompany = new System.Windows.Forms.TextBox();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new System.Windows.Forms.Label();
            this.metroLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditBindingSource
            // 
            this.EditBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.EditBindingSource_AddingNew);
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(11, 146);
            this.pBottom.Size = new System.Drawing.Size(448, 48);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(122, -2);
            this.btnCancel.Size = new System.Drawing.Size(126, 41);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(252, 0);
            this.btnOk.Size = new System.Drawing.Size(126, 41);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(406, 5);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
            // 
            // tbLocationCompany
            // 
            this.tbLocationCompany.Location = new System.Drawing.Point(206, 104);
            this.tbLocationCompany.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLocationCompany.Multiline = true;
            this.tbLocationCompany.Name = "tbLocationCompany";
            this.tbLocationCompany.Size = new System.Drawing.Size(216, 24);
            this.tbLocationCompany.TabIndex = 12;
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(206, 71);
            this.tbCompanyName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(216, 24);
            this.tbCompanyName.TabIndex = 11;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(79, 110);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(43, 18);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "العنوان";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(43, 74);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(105, 18);
            this.metroLabel1.TabIndex = 9;
            this.metroLabel1.Text = "اسم مستودع الأدوية";
            // 
            // CompanyEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(470, 202);
            this.Controls.Add(this.tbLocationCompany);
            this.Controls.Add(this.tbCompanyName);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Margin = new System.Windows.Forms.Padding(4, 9, 4, 9);
            this.Name = "CompanyEditForm";
            this.Padding = new System.Windows.Forms.Padding(11, 63, 11, 8);
            this.Load += new System.EventHandler(this.CompanyEditForm_Load);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.metroLabel1, 0);
            this.Controls.SetChildIndex(this.metroLabel2, 0);
            this.Controls.SetChildIndex(this.tbCompanyName, 0);
            this.Controls.SetChildIndex(this.tbLocationCompany, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLocationCompany;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.Label metroLabel2;
        private System.Windows.Forms.Label metroLabel1;
    }
}
