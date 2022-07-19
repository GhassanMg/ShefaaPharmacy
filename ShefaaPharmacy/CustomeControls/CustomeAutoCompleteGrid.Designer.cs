
namespace ShefaaPharmacy.CustomeControls
{
    partial class CustomeAutoCompleteGrid
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
            this.dgvQueryArticle = new System.Windows.Forms.DataGridView();
            this.bsQueryArticle = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryArticle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQueryArticle)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQueryArticle
            // 
            this.dgvQueryArticle.AllowUserToAddRows = false;
            this.dgvQueryArticle.AllowUserToDeleteRows = false;
            this.dgvQueryArticle.AllowUserToResizeColumns = false;
            this.dgvQueryArticle.AllowUserToResizeRows = false;
            this.dgvQueryArticle.AutoGenerateColumns = false;
            this.dgvQueryArticle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQueryArticle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryArticle.DataSource = this.bsQueryArticle;
            this.dgvQueryArticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQueryArticle.Location = new System.Drawing.Point(0, 0);
            this.dgvQueryArticle.MultiSelect = false;
            this.dgvQueryArticle.Name = "dgvQueryArticle";
            this.dgvQueryArticle.Size = new System.Drawing.Size(547, 322);
            this.dgvQueryArticle.TabIndex = 0;
            this.dgvQueryArticle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQueryArticle_CellContentClick);
            this.dgvQueryArticle.BindingContextChanged += new System.EventHandler(this.dgvQueryArticle_BindingContextChanged);
            // 
            // bsQueryArticle
            // 
            this.bsQueryArticle.AllowNew = false;
            // 
            // CustomeAutoCompleteGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 322);
            this.Controls.Add(this.dgvQueryArticle);
            this.Font = new System.Drawing.Font("AD-STOOR", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CustomeAutoCompleteGrid";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "CustomeAutoCompleteGrid";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryArticle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQueryArticle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bsQueryArticle;
        public System.Windows.Forms.DataGridView dgvQueryArticle;
    }
}