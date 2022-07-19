namespace ShefaaPharmacy.Orders
{
    partial class OrderFromCompanyEditForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pIncreseQuantity = new System.Windows.Forms.Panel();
            this.pbIncreseQuantity = new System.Windows.Forms.PictureBox();
            this.lbIncreseQuantity = new System.Windows.Forms.Label();
            this.pDeleteRow = new System.Windows.Forms.Panel();
            this.pbDeleteRow = new System.Windows.Forms.PictureBox();
            this.lbDeleteRow = new System.Windows.Forms.Label();
            this.ddlCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgFinalOrder = new System.Windows.Forms.DataGridView();
            this.dgvOrderDetail = new System.Windows.Forms.DataGridView();
            this.DetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bsFinalOrder = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pIncreseQuantity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIncreseQuantity)).BeginInit();
            this.pDeleteRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteRow)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFinalOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFinalOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(10, 480);
            this.pBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBottom.Padding = new System.Windows.Forms.Padding(2, 3, 2, 1);
            this.pBottom.Size = new System.Drawing.Size(999, 46);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3563, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnCancel.Size = new System.Drawing.Size(136, 31);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(3705, 9);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnOk.Size = new System.Drawing.Size(136, 31);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(910, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.pIncreseQuantity);
            this.panel1.Controls.Add(this.pDeleteRow);
            this.panel1.Controls.Add(this.ddlCompany);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(999, 87);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 43;
            this.label2.Text = "البحث";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(30, 59);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(220, 24);
            this.tbSearch.TabIndex = 42;
            this.tbSearch.TextChanged += new System.EventHandler(this.TbSearch_TextChanged);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbSearch_KeyDown);
            // 
            // pIncreseQuantity
            // 
            this.pIncreseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pIncreseQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pIncreseQuantity.Controls.Add(this.pbIncreseQuantity);
            this.pIncreseQuantity.Controls.Add(this.lbIncreseQuantity);
            this.pIncreseQuantity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pIncreseQuantity.Location = new System.Drawing.Point(654, 57);
            this.pIncreseQuantity.Name = "pIncreseQuantity";
            this.pIncreseQuantity.Size = new System.Drawing.Size(171, 26);
            this.pIncreseQuantity.TabIndex = 41;
            this.pIncreseQuantity.Click += new System.EventHandler(this.LbIncreseQuantity_Click);
            // 
            // pbIncreseQuantity
            // 
            this.pbIncreseQuantity.Image = global::ShefaaPharmacy.Properties.Resources.Up;
            this.pbIncreseQuantity.Location = new System.Drawing.Point(130, 1);
            this.pbIncreseQuantity.Name = "pbIncreseQuantity";
            this.pbIncreseQuantity.Size = new System.Drawing.Size(36, 22);
            this.pbIncreseQuantity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIncreseQuantity.TabIndex = 11;
            this.pbIncreseQuantity.TabStop = false;
            this.pbIncreseQuantity.Click += new System.EventHandler(this.LbIncreseQuantity_Click);
            // 
            // lbIncreseQuantity
            // 
            this.lbIncreseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIncreseQuantity.AutoSize = true;
            this.lbIncreseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbIncreseQuantity.Location = new System.Drawing.Point(9, 3);
            this.lbIncreseQuantity.Name = "lbIncreseQuantity";
            this.lbIncreseQuantity.Size = new System.Drawing.Size(87, 18);
            this.lbIncreseQuantity.TabIndex = 10;
            this.lbIncreseQuantity.Text = "زيادة الكمية +1";
            this.lbIncreseQuantity.Click += new System.EventHandler(this.LbIncreseQuantity_Click);
            // 
            // pDeleteRow
            // 
            this.pDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pDeleteRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDeleteRow.Controls.Add(this.pbDeleteRow);
            this.pDeleteRow.Controls.Add(this.lbDeleteRow);
            this.pDeleteRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pDeleteRow.Location = new System.Drawing.Point(841, 57);
            this.pDeleteRow.Name = "pDeleteRow";
            this.pDeleteRow.Size = new System.Drawing.Size(135, 26);
            this.pDeleteRow.TabIndex = 40;
            this.pDeleteRow.Click += new System.EventHandler(this.LbDeleteRow_Click);
            // 
            // pbDeleteRow
            // 
            this.pbDeleteRow.Image = global::ShefaaPharmacy.Properties.Resources.DeleteCancel;
            this.pbDeleteRow.Location = new System.Drawing.Point(93, 1);
            this.pbDeleteRow.Name = "pbDeleteRow";
            this.pbDeleteRow.Size = new System.Drawing.Size(36, 22);
            this.pbDeleteRow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeleteRow.TabIndex = 10;
            this.pbDeleteRow.TabStop = false;
            this.pbDeleteRow.Click += new System.EventHandler(this.LbDeleteRow_Click);
            // 
            // lbDeleteRow
            // 
            this.lbDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDeleteRow.AutoSize = true;
            this.lbDeleteRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbDeleteRow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbDeleteRow.Location = new System.Drawing.Point(10, 3);
            this.lbDeleteRow.Name = "lbDeleteRow";
            this.lbDeleteRow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbDeleteRow.Size = new System.Drawing.Size(62, 18);
            this.lbDeleteRow.TabIndex = 9;
            this.lbDeleteRow.Text = "حذف سطر";
            this.lbDeleteRow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbDeleteRow.Click += new System.EventHandler(this.LbDeleteRow_Click);
            // 
            // ddlCompany
            // 
            this.ddlCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCompany.FormattingEnabled = true;
            this.ddlCompany.Location = new System.Drawing.Point(654, 21);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Size = new System.Drawing.Size(216, 26);
            this.ddlCompany.TabIndex = 4;
            this.ddlCompany.SelectedIndexChanged += new System.EventHandler(this.DdlCompany_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(894, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "اختر الشركة";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgFinalOrder);
            this.panel2.Controls.Add(this.dgvOrderDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 147);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(999, 320);
            this.panel2.TabIndex = 10;
            // 
            // dgFinalOrder
            // 
            this.dgFinalOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFinalOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgFinalOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFinalOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgFinalOrder.Location = new System.Drawing.Point(0, 180);
            this.dgFinalOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgFinalOrder.Name = "dgFinalOrder";
            this.dgFinalOrder.RowTemplate.Height = 26;
            this.dgFinalOrder.Size = new System.Drawing.Size(999, 140);
            this.dgFinalOrder.TabIndex = 2;
            this.dgFinalOrder.BindingContextChanged += new System.EventHandler(this.DgFinalOrder_BindingContextChanged);
            // 
            // dgvOrderDetail
            // 
            this.dgvOrderDetail.AllowUserToAddRows = false;
            this.dgvOrderDetail.AllowUserToDeleteRows = false;
            this.dgvOrderDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvOrderDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderDetail.Name = "dgvOrderDetail";
            this.dgvOrderDetail.Size = new System.Drawing.Size(999, 184);
            this.dgvOrderDetail.TabIndex = 1;
            this.dgvOrderDetail.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOrderDetail_CellDoubleClick);
            this.dgvOrderDetail.BindingContextChanged += new System.EventHandler(this.DgvOrderDetail_BindingContextChanged);
            // 
            // OrderFromCompanyEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(1019, 532);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OrderFromCompanyEditForm";
            this.Padding = new System.Windows.Forms.Padding(10, 60, 10, 6);
            this.Text = "طلبية من مستودع";
            this.Load += new System.EventHandler(this.OrderFromCompanyEditForm_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pIncreseQuantity.ResumeLayout(false);
            this.pIncreseQuantity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIncreseQuantity)).EndInit();
            this.pDeleteRow.ResumeLayout(false);
            this.pDeleteRow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteRow)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFinalOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFinalOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ddlCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvOrderDetail;
        private System.Windows.Forms.BindingSource DetailBindingSource;
        private System.Windows.Forms.Panel pIncreseQuantity;
        private System.Windows.Forms.PictureBox pbIncreseQuantity;
        private System.Windows.Forms.Label lbIncreseQuantity;
        private System.Windows.Forms.Panel pDeleteRow;
        private System.Windows.Forms.PictureBox pbDeleteRow;
        private System.Windows.Forms.Label lbDeleteRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView dgFinalOrder;
        private System.Windows.Forms.BindingSource bsFinalOrder;
    }
}
