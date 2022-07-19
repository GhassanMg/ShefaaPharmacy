
namespace ShefaaPharmacy.Articles
{
    partial class FirstDurationArticlesEditForm
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
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(15, 403);
            this.pBottom.Size = new System.Drawing.Size(1011, 55);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(7945, 3);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(8110, 3);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOk.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(932, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvArticles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(15, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1011, 286);
            this.panel1.TabIndex = 9;
            // 
            // dgvArticles
            // 
            this.dgvArticles.AllowUserToAddRows = false;
            this.dgvArticles.AllowUserToDeleteRows = false;
            this.dgvArticles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArticles.BackgroundColor = System.Drawing.Color.White;
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvArticles.Location = new System.Drawing.Point(0, 0);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.Size = new System.Drawing.Size(1011, 286);
            this.dgvArticles.TabIndex = 0;
            this.dgvArticles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticles_CellClick);
            this.dgvArticles.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvArticles_CellValidating);
            this.dgvArticles.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvArticles_ColumnWidthChanged);
            this.dgvArticles.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvArticles_Scroll);
            // 
            // FirstDurationArticlesEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 472);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 10, 4, 10);
            this.Name = "FirstDurationArticlesEditForm";
            this.Padding = new System.Windows.Forms.Padding(15, 111, 15, 14);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "تعديل مواد أول مدة :";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvArticles;
    }
}