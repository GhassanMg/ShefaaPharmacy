
namespace ShefaaPharmacy.Articles
{
    partial class ExistStuffEditForm
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
            this.dgvEditStuff = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditStuff)).BeginInit();
            this.SuspendLayout();
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(10, 392);
            this.pBottom.Size = new System.Drawing.Size(954, 48);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(369, 3);
            this.btnCancel.Size = new System.Drawing.Size(104, 41);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(479, 3);
            this.btnOk.Size = new System.Drawing.Size(104, 41);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(865, 7);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvEditStuff);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 312);
            this.panel1.TabIndex = 9;
            // 
            // dgvEditStuff
            // 
            this.dgvEditStuff.AllowUserToAddRows = false;
            this.dgvEditStuff.AllowUserToDeleteRows = false;
            this.dgvEditStuff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEditStuff.BackgroundColor = System.Drawing.Color.White;
            this.dgvEditStuff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditStuff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEditStuff.Location = new System.Drawing.Point(0, 0);
            this.dgvEditStuff.Name = "dgvEditStuff";
            this.dgvEditStuff.Size = new System.Drawing.Size(954, 312);
            this.dgvEditStuff.TabIndex = 10;
            this.dgvEditStuff.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvEditStuff_EditingControlShowing);
            // 
            // ExistStuffEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ExistStuffEditForm";
            this.Text = "تعديل الموجودات :";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditStuff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvEditStuff;
    }
}