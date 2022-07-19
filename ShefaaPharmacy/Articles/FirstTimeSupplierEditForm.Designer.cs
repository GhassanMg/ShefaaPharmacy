
namespace ShefaaPharmacy.Articles
{
    partial class FirstTimeSupplierEditForm
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
            this.dgvSupllierEdit = new System.Windows.Forms.DataGridView();
            this.SupplierEditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupllierEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierEditBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(15, 388);
            this.pBottom.Size = new System.Drawing.Size(846, 48);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(305, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnCancel.Size = new System.Drawing.Size(104, 39);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(417, 4);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOk.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnOk.Size = new System.Drawing.Size(104, 39);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(767, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSupllierEdit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(15, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 277);
            this.panel1.TabIndex = 6;
            // 
            // dgvSupllierEdit
            // 
            this.dgvSupllierEdit.AllowUserToAddRows = false;
            this.dgvSupllierEdit.AllowUserToDeleteRows = false;
            this.dgvSupllierEdit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSupllierEdit.BackgroundColor = System.Drawing.Color.White;
            this.dgvSupllierEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupllierEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSupllierEdit.Location = new System.Drawing.Point(0, 0);
            this.dgvSupllierEdit.Name = "dgvSupllierEdit";
            this.dgvSupllierEdit.Size = new System.Drawing.Size(846, 277);
            this.dgvSupllierEdit.TabIndex = 9;
            this.dgvSupllierEdit.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSupllierEdit_EditingControlShowing);
            // 
            // FirstTimeSupplierEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 450);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.Name = "FirstTimeSupplierEditForm";
            this.Padding = new System.Windows.Forms.Padding(15, 111, 15, 14);
            this.Text = "تعديل ديون الموردين لأول مدة :";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupllierEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierEditBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSupllierEdit;
        private System.Windows.Forms.BindingSource SupplierEditBindingSource;
    }
}