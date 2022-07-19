
namespace ShefaaPharmacy.Orders
{
    partial class OrderEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderEditForm));
            this.DetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pIncreseQuantity = new System.Windows.Forms.Panel();
            this.pbIncreseQuantity = new System.Windows.Forms.PictureBox();
            this.lbIncreseQuantity = new System.Windows.Forms.Label();
            this.pDecreseQuantity = new System.Windows.Forms.Panel();
            this.pbDecresQuantity = new System.Windows.Forms.PictureBox();
            this.lbDecresQuantity = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pbAddRow = new System.Windows.Forms.PictureBox();
            this.pDeleteRow = new System.Windows.Forms.Panel();
            this.pbDeleteRow = new System.Windows.Forms.PictureBox();
            this.lbDeleteRow = new System.Windows.Forms.Label();
            this.ddlOrderState = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlArticle = new System.Windows.Forms.ComboBox();
            this.ddlCompany = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvOrderDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.pIncreseQuantity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIncreseQuantity)).BeginInit();
            this.pDecreseQuantity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDecresQuantity)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddRow)).BeginInit();
            this.pDeleteRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteRow)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(11, 430);
            this.pBottom.Size = new System.Drawing.Size(846, 44);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2299, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(126, 36);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(2440, 0);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3);
            this.btnOk.Size = new System.Drawing.Size(126, 36);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(759, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            // 
            // DetailBindingSource
            // 
            this.DetailBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.DetailBindingSource_AddingNew);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pIncreseQuantity);
            this.panel1.Controls.Add(this.pDecreseQuantity);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pDeleteRow);
            this.panel1.Controls.Add(this.ddlOrderState);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ddlArticle);
            this.panel1.Controls.Add(this.ddlCompany);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(11, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 117);
            this.panel1.TabIndex = 11;
            // 
            // pIncreseQuantity
            // 
            this.pIncreseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pIncreseQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pIncreseQuantity.Controls.Add(this.pbIncreseQuantity);
            this.pIncreseQuantity.Controls.Add(this.lbIncreseQuantity);
            this.pIncreseQuantity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pIncreseQuantity.Location = new System.Drawing.Point(287, 84);
            this.pIncreseQuantity.Name = "pIncreseQuantity";
            this.pIncreseQuantity.Size = new System.Drawing.Size(148, 26);
            this.pIncreseQuantity.TabIndex = 39;
            this.pIncreseQuantity.Click += new System.EventHandler(this.pbIncreseQuantity_Click);
            // 
            // pbIncreseQuantity
            // 
            this.pbIncreseQuantity.Image = global::ShefaaPharmacy.Properties.Resources.Up;
            this.pbIncreseQuantity.Location = new System.Drawing.Point(108, 1);
            this.pbIncreseQuantity.Name = "pbIncreseQuantity";
            this.pbIncreseQuantity.Size = new System.Drawing.Size(36, 22);
            this.pbIncreseQuantity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIncreseQuantity.TabIndex = 11;
            this.pbIncreseQuantity.TabStop = false;
            this.pbIncreseQuantity.Click += new System.EventHandler(this.pbIncreseQuantity_Click);
            // 
            // lbIncreseQuantity
            // 
            this.lbIncreseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIncreseQuantity.AutoSize = true;
            this.lbIncreseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbIncreseQuantity.Location = new System.Drawing.Point(3, 4);
            this.lbIncreseQuantity.Name = "lbIncreseQuantity";
            this.lbIncreseQuantity.Size = new System.Drawing.Size(87, 18);
            this.lbIncreseQuantity.TabIndex = 10;
            this.lbIncreseQuantity.Text = "زيادة الكمية +1";
            this.lbIncreseQuantity.Click += new System.EventHandler(this.pbIncreseQuantity_Click);
            // 
            // pDecreseQuantity
            // 
            this.pDecreseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pDecreseQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDecreseQuantity.Controls.Add(this.pbDecresQuantity);
            this.pDecreseQuantity.Controls.Add(this.lbDecresQuantity);
            this.pDecreseQuantity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pDecreseQuantity.Location = new System.Drawing.Point(442, 84);
            this.pDecreseQuantity.Name = "pDecreseQuantity";
            this.pDecreseQuantity.Size = new System.Drawing.Size(148, 26);
            this.pDecreseQuantity.TabIndex = 38;
            this.pDecreseQuantity.Click += new System.EventHandler(this.pbDecresQuantity_Click);
            // 
            // pbDecresQuantity
            // 
            this.pbDecresQuantity.Image = global::ShefaaPharmacy.Properties.Resources.Down;
            this.pbDecresQuantity.Location = new System.Drawing.Point(109, 1);
            this.pbDecresQuantity.Name = "pbDecresQuantity";
            this.pbDecresQuantity.Size = new System.Drawing.Size(36, 22);
            this.pbDecresQuantity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDecresQuantity.TabIndex = 11;
            this.pbDecresQuantity.TabStop = false;
            this.pbDecresQuantity.Click += new System.EventHandler(this.pbDecresQuantity_Click);
            // 
            // lbDecresQuantity
            // 
            this.lbDecresQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDecresQuantity.AutoSize = true;
            this.lbDecresQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbDecresQuantity.Location = new System.Drawing.Point(3, 4);
            this.lbDecresQuantity.Name = "lbDecresQuantity";
            this.lbDecresQuantity.Size = new System.Drawing.Size(90, 18);
            this.lbDecresQuantity.TabIndex = 10;
            this.lbDecresQuantity.Text = "إنقاص الكمية -1";
            this.lbDecresQuantity.Click += new System.EventHandler(this.pbDecresQuantity_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.pbAddRow);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(739, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(95, 26);
            this.panel3.TabIndex = 37;
            this.panel3.Click += new System.EventHandler(this.pbAddRow_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(4, 3);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "إضافة";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.pbAddRow_Click);
            // 
            // pbAddRow
            // 
            this.pbAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAddRow.BackColor = System.Drawing.Color.Transparent;
            this.pbAddRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddRow.Image = global::ShefaaPharmacy.Properties.Resources.icons8_plus_math_48px;
            this.pbAddRow.Location = new System.Drawing.Point(55, 1);
            this.pbAddRow.Name = "pbAddRow";
            this.pbAddRow.Size = new System.Drawing.Size(36, 22);
            this.pbAddRow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAddRow.TabIndex = 33;
            this.pbAddRow.TabStop = false;
            this.pbAddRow.Click += new System.EventHandler(this.pbAddRow_Click);
            // 
            // pDeleteRow
            // 
            this.pDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pDeleteRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDeleteRow.Controls.Add(this.pbDeleteRow);
            this.pDeleteRow.Controls.Add(this.lbDeleteRow);
            this.pDeleteRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pDeleteRow.Location = new System.Drawing.Point(598, 84);
            this.pDeleteRow.Name = "pDeleteRow";
            this.pDeleteRow.Size = new System.Drawing.Size(135, 26);
            this.pDeleteRow.TabIndex = 36;
            this.pDeleteRow.Click += new System.EventHandler(this.pbDeleteRow_Click);
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
            this.pbDeleteRow.Click += new System.EventHandler(this.pbDeleteRow_Click);
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
            this.lbDeleteRow.Click += new System.EventHandler(this.pbDeleteRow_Click);
            // 
            // ddlOrderState
            // 
            this.ddlOrderState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlOrderState.FormattingEnabled = true;
            this.ddlOrderState.Location = new System.Drawing.Point(130, 15);
            this.ddlOrderState.Name = "ddlOrderState";
            this.ddlOrderState.Size = new System.Drawing.Size(216, 26);
            this.ddlOrderState.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 34;
            this.label3.Text = "حالة الطلبية";
            // 
            // ddlArticle
            // 
            this.ddlArticle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlArticle.FormattingEnabled = true;
            this.ddlArticle.Location = new System.Drawing.Point(512, 49);
            this.ddlArticle.Name = "ddlArticle";
            this.ddlArticle.Size = new System.Drawing.Size(216, 26);
            this.ddlArticle.TabIndex = 3;
            // 
            // ddlCompany
            // 
            this.ddlCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlCompany.FormattingEnabled = true;
            this.ddlCompany.Location = new System.Drawing.Point(512, 15);
            this.ddlCompany.Name = "ddlCompany";
            this.ddlCompany.Size = new System.Drawing.Size(216, 26);
            this.ddlCompany.TabIndex = 2;
            this.ddlCompany.SelectedIndexChanged += new System.EventHandler(this.ddlCompany_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(756, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "اختر الدواء";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(747, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "اختر الشركة";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvOrderDetail);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(11, 179);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 251);
            this.panel2.TabIndex = 12;
            // 
            // dgvOrderDetail
            // 
            this.dgvOrderDetail.AllowUserToAddRows = false;
            this.dgvOrderDetail.AllowUserToDeleteRows = false;
            this.dgvOrderDetail.AutoGenerateColumns = false;
            this.dgvOrderDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetail.DataSource = this.DetailBindingSource;
            this.dgvOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderDetail.Name = "dgvOrderDetail";
            this.dgvOrderDetail.Size = new System.Drawing.Size(844, 249);
            this.dgvOrderDetail.TabIndex = 0;
            this.dgvOrderDetail.BindingContextChanged += new System.EventHandler(this.dgvOrderDetail_BindingContextChanged);
            // 
            // OrderEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(868, 482);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "OrderEditForm";
            this.Padding = new System.Windows.Forms.Padding(11, 62, 11, 8);
            this.Text = "طلبية من مستودع";
            this.Load += new System.EventHandler(this.OrderEditForm_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.DetailBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pIncreseQuantity.ResumeLayout(false);
            this.pIncreseQuantity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIncreseQuantity)).EndInit();
            this.pDecreseQuantity.ResumeLayout(false);
            this.pDecreseQuantity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDecresQuantity)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddRow)).EndInit();
            this.pDeleteRow.ResumeLayout(false);
            this.pDeleteRow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteRow)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource DetailBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbAddRow;
        private System.Windows.Forms.ComboBox ddlArticle;
        private System.Windows.Forms.ComboBox ddlCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvOrderDetail;
        private System.Windows.Forms.ComboBox ddlOrderState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pDeleteRow;
        private System.Windows.Forms.PictureBox pbDeleteRow;
        private System.Windows.Forms.Label lbDeleteRow;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pIncreseQuantity;
        private System.Windows.Forms.PictureBox pbIncreseQuantity;
        private System.Windows.Forms.Label lbIncreseQuantity;
        private System.Windows.Forms.Panel pDecreseQuantity;
        private System.Windows.Forms.PictureBox pbDecresQuantity;
        private System.Windows.Forms.Label lbDecresQuantity;
    }
}
