
using ShefaaPharmacy.CustomeControls;

namespace ShefaaPharmacy.Desktop
{
    partial class SellFormTabs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellFormTabs));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ptop = new ShefaaPharmacy.CustomeControls.PanelEx();
            this.tbSearchArticle = new System.Windows.Forms.TextBox();
            this.pIncreseQuantity = new ShefaaPharmacy.CustomeControls.PanelEx();
            this.pbIncreseQuantity = new System.Windows.Forms.PictureBox();
            this.lbIncreseQuantity = new System.Windows.Forms.Label();
            this.pDecreseQuantity = new ShefaaPharmacy.CustomeControls.PanelEx();
            this.pbDecresQuantity = new System.Windows.Forms.PictureBox();
            this.lbDecresQuantity = new System.Windows.Forms.Label();
            this.pDeleteRow = new ShefaaPharmacy.CustomeControls.PanelEx();
            this.pbDeleteRow = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pFill = new ShefaaPharmacy.CustomeControls.PanelEx();
            this.tcSell = new System.Windows.Forms.TabControl();
            this.tp1 = new System.Windows.Forms.TabPage();
            this.tp2 = new System.Windows.Forms.TabPage();
            this.tp3 = new System.Windows.Forms.TabPage();
            this.tp4 = new System.Windows.Forms.TabPage();
            this.tp5 = new System.Windows.Forms.TabPage();
            this.tp6 = new System.Windows.Forms.TabPage();
            this.EditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvQueryArticle = new System.Windows.Forms.DataGridView();
            this.bsQueryArticle = new System.Windows.Forms.BindingSource(this.components);
            this.ptop.SuspendLayout();
            this.pIncreseQuantity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIncreseQuantity)).BeginInit();
            this.pDecreseQuantity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDecresQuantity)).BeginInit();
            this.pDeleteRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteRow)).BeginInit();
            this.pFill.SuspendLayout();
            this.tcSell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryArticle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQueryArticle)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add.png");
            // 
            // ptop
            // 
            this.ptop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptop.Controls.Add(this.tbSearchArticle);
            this.ptop.Controls.Add(this.pIncreseQuantity);
            this.ptop.Controls.Add(this.pDecreseQuantity);
            this.ptop.Controls.Add(this.pDeleteRow);
            this.ptop.Controls.Add(this.label1);
            this.ptop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptop.Location = new System.Drawing.Point(0, 0);
            this.ptop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ptop.Name = "ptop";
            this.ptop.Size = new System.Drawing.Size(969, 44);
            this.ptop.TabIndex = 1;
            // 
            // tbSearchArticle
            // 
            this.tbSearchArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchArticle.Location = new System.Drawing.Point(130, 11);
            this.tbSearchArticle.Name = "tbSearchArticle";
            this.tbSearchArticle.Size = new System.Drawing.Size(197, 21);
            this.tbSearchArticle.TabIndex = 9;
            this.tbSearchArticle.TextChanged += new System.EventHandler(this.tbSearchArticle_TextChanged);
            this.tbSearchArticle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchArticle_KeyDown);
            // 
            // pIncreseQuantity
            // 
            this.pIncreseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pIncreseQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pIncreseQuantity.Controls.Add(this.pbIncreseQuantity);
            this.pIncreseQuantity.Controls.Add(this.lbIncreseQuantity);
            this.pIncreseQuantity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pIncreseQuantity.Location = new System.Drawing.Point(490, 5);
            this.pIncreseQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pIncreseQuantity.Name = "pIncreseQuantity";
            this.pIncreseQuantity.Size = new System.Drawing.Size(154, 33);
            this.pIncreseQuantity.TabIndex = 8;
            this.pIncreseQuantity.Click += new System.EventHandler(this.pIncreseQuantity_Click);
            // 
            // pbIncreseQuantity
            // 
            this.pbIncreseQuantity.Image = global::ShefaaPharmacy.Properties.Resources.Up;
            this.pbIncreseQuantity.Location = new System.Drawing.Point(116, 1);
            this.pbIncreseQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbIncreseQuantity.Name = "pbIncreseQuantity";
            this.pbIncreseQuantity.Size = new System.Drawing.Size(32, 29);
            this.pbIncreseQuantity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIncreseQuantity.TabIndex = 11;
            this.pbIncreseQuantity.TabStop = false;
            this.pbIncreseQuantity.Click += new System.EventHandler(this.pIncreseQuantity_Click);
            // 
            // lbIncreseQuantity
            // 
            this.lbIncreseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIncreseQuantity.AutoSize = true;
            this.lbIncreseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbIncreseQuantity.Location = new System.Drawing.Point(2, 2);
            this.lbIncreseQuantity.Name = "lbIncreseQuantity";
            this.lbIncreseQuantity.Size = new System.Drawing.Size(87, 18);
            this.lbIncreseQuantity.TabIndex = 10;
            this.lbIncreseQuantity.Text = "زيادة الكمية +1";
            this.lbIncreseQuantity.Click += new System.EventHandler(this.pIncreseQuantity_Click);
            // 
            // pDecreseQuantity
            // 
            this.pDecreseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pDecreseQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDecreseQuantity.Controls.Add(this.pbDecresQuantity);
            this.pDecreseQuantity.Controls.Add(this.lbDecresQuantity);
            this.pDecreseQuantity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pDecreseQuantity.Location = new System.Drawing.Point(650, 5);
            this.pDecreseQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pDecreseQuantity.Name = "pDecreseQuantity";
            this.pDecreseQuantity.Size = new System.Drawing.Size(154, 33);
            this.pDecreseQuantity.TabIndex = 7;
            this.pDecreseQuantity.Click += new System.EventHandler(this.pDecreseQuantity_Click);
            // 
            // pbDecresQuantity
            // 
            this.pbDecresQuantity.Image = global::ShefaaPharmacy.Properties.Resources.Down;
            this.pbDecresQuantity.Location = new System.Drawing.Point(118, 1);
            this.pbDecresQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbDecresQuantity.Name = "pbDecresQuantity";
            this.pbDecresQuantity.Size = new System.Drawing.Size(32, 29);
            this.pbDecresQuantity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDecresQuantity.TabIndex = 11;
            this.pbDecresQuantity.TabStop = false;
            this.pbDecresQuantity.Click += new System.EventHandler(this.pDecreseQuantity_Click);
            // 
            // lbDecresQuantity
            // 
            this.lbDecresQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDecresQuantity.AutoSize = true;
            this.lbDecresQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbDecresQuantity.Location = new System.Drawing.Point(3, 2);
            this.lbDecresQuantity.Name = "lbDecresQuantity";
            this.lbDecresQuantity.Size = new System.Drawing.Size(90, 18);
            this.lbDecresQuantity.TabIndex = 10;
            this.lbDecresQuantity.Text = "إنقاص الكمية -1";
            this.lbDecresQuantity.Click += new System.EventHandler(this.pDecreseQuantity_Click);
            // 
            // pDeleteRow
            // 
            this.pDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pDeleteRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDeleteRow.Controls.Add(this.pbDeleteRow);
            this.pDeleteRow.Controls.Add(this.label2);
            this.pDeleteRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pDeleteRow.Location = new System.Drawing.Point(810, 5);
            this.pDeleteRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pDeleteRow.Name = "pDeleteRow";
            this.pDeleteRow.Size = new System.Drawing.Size(154, 33);
            this.pDeleteRow.TabIndex = 6;
            this.pDeleteRow.Click += new System.EventHandler(this.pDeleteRow_Click);
            // 
            // pbDeleteRow
            // 
            this.pbDeleteRow.Image = global::ShefaaPharmacy.Properties.Resources.DeleteCancel;
            this.pbDeleteRow.Location = new System.Drawing.Point(117, 0);
            this.pbDeleteRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbDeleteRow.Name = "pbDeleteRow";
            this.pbDeleteRow.Size = new System.Drawing.Size(32, 29);
            this.pbDeleteRow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeleteRow.TabIndex = 10;
            this.pbDeleteRow.TabStop = false;
            this.pbDeleteRow.Click += new System.EventHandler(this.pDeleteRow_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(15, 1);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "حذف سطر";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.pDeleteRow_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(333, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "استعلام مواد";
            // 
            // pFill
            // 
            this.pFill.Controls.Add(this.tcSell);
            this.pFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFill.Location = new System.Drawing.Point(0, 44);
            this.pFill.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pFill.Name = "pFill";
            this.pFill.Size = new System.Drawing.Size(969, 617);
            this.pFill.TabIndex = 2;
            // 
            // tcSell
            // 
            this.tcSell.Controls.Add(this.tp1);
            this.tcSell.Controls.Add(this.tp2);
            this.tcSell.Controls.Add(this.tp3);
            this.tcSell.Controls.Add(this.tp4);
            this.tcSell.Controls.Add(this.tp5);
            this.tcSell.Controls.Add(this.tp6);
            this.tcSell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tcSell.ImageList = this.imageList1;
            this.tcSell.Location = new System.Drawing.Point(0, 0);
            this.tcSell.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcSell.Name = "tcSell";
            this.tcSell.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tcSell.RightToLeftLayout = true;
            this.tcSell.SelectedIndex = 0;
            this.tcSell.Size = new System.Drawing.Size(969, 617);
            this.tcSell.TabIndex = 1;
            this.tcSell.SelectedIndexChanged += new System.EventHandler(this.tcSell_SelectedIndexChanged);
            this.tcSell.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcSell_Selected);
            // 
            // tp1
            // 
            this.tp1.Location = new System.Drawing.Point(4, 27);
            this.tp1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp1.Name = "tp1";
            this.tp1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp1.Size = new System.Drawing.Size(961, 586);
            this.tp1.TabIndex = 0;
            this.tp1.Text = "زبون 1";
            this.tp1.UseVisualStyleBackColor = true;
            // 
            // tp2
            // 
            this.tp2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tp2.Location = new System.Drawing.Point(4, 27);
            this.tp2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp2.Name = "tp2";
            this.tp2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp2.Size = new System.Drawing.Size(961, 586);
            this.tp2.TabIndex = 1;
            this.tp2.Text = "زبون 2";
            this.tp2.UseVisualStyleBackColor = true;
            this.tp2.Click += new System.EventHandler(this.tp2_Click);
            // 
            // tp3
            // 
            this.tp3.Location = new System.Drawing.Point(4, 27);
            this.tp3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp3.Name = "tp3";
            this.tp3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp3.Size = new System.Drawing.Size(961, 586);
            this.tp3.TabIndex = 2;
            this.tp3.Text = "زبون 3";
            this.tp3.UseVisualStyleBackColor = true;
            // 
            // tp4
            // 
            this.tp4.Location = new System.Drawing.Point(4, 27);
            this.tp4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp4.Name = "tp4";
            this.tp4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp4.Size = new System.Drawing.Size(961, 586);
            this.tp4.TabIndex = 3;
            this.tp4.Text = "زبون 4";
            this.tp4.UseVisualStyleBackColor = true;
            // 
            // tp5
            // 
            this.tp5.Location = new System.Drawing.Point(4, 27);
            this.tp5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp5.Name = "tp5";
            this.tp5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp5.Size = new System.Drawing.Size(961, 586);
            this.tp5.TabIndex = 4;
            this.tp5.Text = "زبون 5";
            this.tp5.UseVisualStyleBackColor = true;
            // 
            // tp6
            // 
            this.tp6.Location = new System.Drawing.Point(4, 27);
            this.tp6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp6.Name = "tp6";
            this.tp6.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tp6.Size = new System.Drawing.Size(961, 586);
            this.tp6.TabIndex = 5;
            this.tp6.Text = "زبون 6";
            this.tp6.UseVisualStyleBackColor = true;
            // 
            // EditBindingSource
            // 
            this.EditBindingSource.DataSourceChanged += new System.EventHandler(this.EditBindingSource_DataSourceChanged);
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
            this.dgvQueryArticle.Location = new System.Drawing.Point(209, 45);
            this.dgvQueryArticle.MultiSelect = false;
            this.dgvQueryArticle.Name = "dgvQueryArticle";
            this.dgvQueryArticle.Size = new System.Drawing.Size(210, 262);
            this.dgvQueryArticle.TabIndex = 16;
            this.dgvQueryArticle.Visible = false;
            this.dgvQueryArticle.BindingContextChanged += new System.EventHandler(this.dgvQueryArticle_BindingContextChanged);
            // 
            // bsQueryArticle
            // 
            this.bsQueryArticle.AllowNew = false;
            // 
            // SellFormTabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pFill);
            this.Controls.Add(this.ptop);
            this.Controls.Add(this.dgvQueryArticle);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SellFormTabs";
            this.Size = new System.Drawing.Size(969, 661);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SellFormTabs_MouseClick);
            this.ptop.ResumeLayout(false);
            this.ptop.PerformLayout();
            this.pIncreseQuantity.ResumeLayout(false);
            this.pIncreseQuantity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIncreseQuantity)).EndInit();
            this.pDecreseQuantity.ResumeLayout(false);
            this.pDecreseQuantity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDecresQuantity)).EndInit();
            this.pDeleteRow.ResumeLayout(false);
            this.pDeleteRow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteRow)).EndInit();
            this.pFill.ResumeLayout(false);
            this.tcSell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryArticle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsQueryArticle)).EndInit();
            this.ResumeLayout(false);

        }

       
        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private PanelEx ptop;
        private System.Windows.Forms.Label label1;
        private PanelEx pFill;
        private System.Windows.Forms.TabControl tcSell;
        private System.Windows.Forms.TabPage tp1;
        private System.Windows.Forms.TabPage tp2;
        private System.Windows.Forms.TabPage tp3;
        private System.Windows.Forms.TabPage tp4;
        private System.Windows.Forms.TabPage tp5;
        private System.Windows.Forms.TabPage tp6;
        private PanelEx pDeleteRow;
        private PanelEx pDecreseQuantity;
        private PanelEx pIncreseQuantity;
        private System.Windows.Forms.PictureBox pbIncreseQuantity;
        private System.Windows.Forms.Label lbIncreseQuantity;
        private System.Windows.Forms.PictureBox pbDecresQuantity;
        private System.Windows.Forms.Label lbDecresQuantity;
        private System.Windows.Forms.PictureBox pbDeleteRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource EditBindingSource;
        private System.Windows.Forms.TextBox tbSearchArticle;
        public System.Windows.Forms.DataGridView dgvQueryArticle;
        private System.Windows.Forms.BindingSource bsQueryArticle;
    }
}
