
namespace ShefaaPharmacy.Articles
{
    partial class FirstTimeCustomerEditForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCustomerEdit = new System.Windows.Forms.DataGridView();
            this.CustomerEditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerEditBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(10, 392);
            this.pBottom.Size = new System.Drawing.Size(811, 48);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(485, 3);
            this.btnCancel.Size = new System.Drawing.Size(104, 41);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(595, 3);
            this.btnOk.Size = new System.Drawing.Size(104, 41);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(722, 7);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCustomerEdit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 312);
            this.panel1.TabIndex = 9;
            // 
            // dgvCustomerEdit
            // 
            this.dgvCustomerEdit.AllowUserToAddRows = false;
            this.dgvCustomerEdit.AllowUserToDeleteRows = false;
            this.dgvCustomerEdit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerEdit.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomerEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomerEdit.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomerEdit.Name = "dgvCustomerEdit";
            this.dgvCustomerEdit.Size = new System.Drawing.Size(811, 312);
            this.dgvCustomerEdit.TabIndex = 9;
            this.dgvCustomerEdit.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvCustomerEdit_EditingControlShowing);
            // 
            // FirstTimeCustomerEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FirstTimeCustomerEditForm";
            this.Text = "تعديل ديون الزبائن لأول مدة :";
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerEditBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCustomerEdit;
        private System.Windows.Forms.BindingSource CustomerEditBindingSource;
    }
}