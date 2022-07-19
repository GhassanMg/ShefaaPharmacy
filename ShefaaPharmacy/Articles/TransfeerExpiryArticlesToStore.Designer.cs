
namespace ShefaaPharmacy.Articles
{
    partial class TransfeerExpiryArticlesToStore
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btCancel = new System.Windows.Forms.PictureBox();
            this.btOk = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgMaster = new System.Windows.Forms.DataGridView();
            this.BindingSourceMaster = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btOk)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(805, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(23, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 369);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.btCancel);
            this.panel4.Controls.Add(this.btOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 316);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(867, 53);
            this.panel4.TabIndex = 10;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancel.Image = global::ShefaaPharmacy.Properties.Resources.CancelButton;
            this.btCancel.Location = new System.Drawing.Point(320, 3);
            this.btCancel.Name = "btCancel";
            this.btCancel.Padding = new System.Windows.Forms.Padding(2);
            this.btCancel.Size = new System.Drawing.Size(105, 47);
            this.btCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btCancel.TabIndex = 5;
            this.btCancel.TabStop = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btOk.Image = global::ShefaaPharmacy.Properties.Resources.Group_2315;
            this.btOk.Location = new System.Drawing.Point(436, 3);
            this.btOk.Name = "btOk";
            this.btOk.Padding = new System.Windows.Forms.Padding(2);
            this.btOk.Size = new System.Drawing.Size(105, 47);
            this.btOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btOk.TabIndex = 4;
            this.btOk.TabStop = false;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dgMaster);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(867, 310);
            this.panel2.TabIndex = 1;
            // 
            // dgMaster
            // 
            this.dgMaster.AllowUserToAddRows = false;
            this.dgMaster.AllowUserToDeleteRows = false;
            this.dgMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMaster.BackgroundColor = System.Drawing.Color.White;
            this.dgMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMaster.Location = new System.Drawing.Point(0, 0);
            this.dgMaster.Name = "dgMaster";
            this.dgMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgMaster.Size = new System.Drawing.Size(867, 310);
            this.dgMaster.TabIndex = 0;
            this.dgMaster.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgMaster_CellValidating);
            this.dgMaster.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgMaster_EditingControlShowing);
            // 
            // TransfeerExpiryArticlesToStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 473);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "TransfeerExpiryArticlesToStore";
            this.Padding = new System.Windows.Forms.Padding(23, 92, 12, 12);
            this.Text = "تحويل إلى مخزن مواد منتهية الصلاحية";
            this.Load += new System.EventHandler(this.ExpireArticlesReport_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btOk)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSourceMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgMaster;
        private System.Windows.Forms.BindingSource BindingSourceMaster;
        protected System.Windows.Forms.Panel panel4;
        protected System.Windows.Forms.PictureBox btCancel;
        protected System.Windows.Forms.PictureBox btOk;
    }
}