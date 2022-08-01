namespace ShefaaPharmacy.Articles
{
    partial class ArticleUnitsEditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pTop = new System.Windows.Forms.Panel();
            this.tbArticleName = new System.Windows.Forms.TextBox();
            this.lbArticleName = new System.Windows.Forms.LinkLabel();
            this.pTop2 = new System.Windows.Forms.Panel();
            this.gbUnit = new System.Windows.Forms.GroupBox();
            this.lbBaseUnit2 = new System.Windows.Forms.Label();
            this.lbBaseUnit1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.lbQuantityFromBaseUnit = new System.Windows.Forms.Label();
            this.tbQuantityFromBaseUnit = new System.Windows.Forms.TextBox();
            this.cbPrimary = new System.Windows.Forms.CheckBox();
            this.cbUnitTypeId = new System.Windows.Forms.ComboBox();
            this.metroLabel11 = new System.Windows.Forms.Label();
            this.pbot = new System.Windows.Forms.Panel();
            this.dgMaster = new MetroFramework.Controls.MetroGrid();
            this.bsMaster = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.pTop.SuspendLayout();
            this.pTop2.SuspendLayout();
            this.gbUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.pbot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMaster)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(11, 427);
            this.pBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBottom.Size = new System.Drawing.Size(765, 40);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(5094, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3);
            this.btnCancel.Size = new System.Drawing.Size(126, 42);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(5226, -2);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3);
            this.btnOk.Size = new System.Drawing.Size(126, 42);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(678, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.tbArticleName);
            this.pTop.Controls.Add(this.lbArticleName);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(11, 62);
            this.pTop.Margin = new System.Windows.Forms.Padding(4);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(765, 46);
            this.pTop.TabIndex = 2;
            // 
            // tbArticleName
            // 
            this.tbArticleName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbArticleName.Location = new System.Drawing.Point(394, 13);
            this.tbArticleName.Margin = new System.Windows.Forms.Padding(4);
            this.tbArticleName.Name = "tbArticleName";
            this.tbArticleName.Size = new System.Drawing.Size(236, 24);
            this.tbArticleName.TabIndex = 260;
            this.tbArticleName.Validating += new System.ComponentModel.CancelEventHandler(this.TbArticleName_Validating);
            // 
            // lbArticleName
            // 
            this.lbArticleName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbArticleName.AutoSize = true;
            this.lbArticleName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbArticleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbArticleName.Location = new System.Drawing.Point(682, 12);
            this.lbArticleName.Name = "lbArticleName";
            this.lbArticleName.Size = new System.Drawing.Size(44, 18);
            this.lbArticleName.TabIndex = 259;
            this.lbArticleName.TabStop = true;
            this.lbArticleName.Text = "الصنف";
            this.lbArticleName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LbArticleName_LinkClicked);
            // 
            // pTop2
            // 
            this.pTop2.Controls.Add(this.gbUnit);
            this.pTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop2.Location = new System.Drawing.Point(11, 108);
            this.pTop2.Name = "pTop2";
            this.pTop2.Size = new System.Drawing.Size(765, 122);
            this.pTop2.TabIndex = 3;
            // 
            // gbUnit
            // 
            this.gbUnit.Controls.Add(this.lbBaseUnit2);
            this.gbUnit.Controls.Add(this.lbBaseUnit1);
            this.gbUnit.Controls.Add(this.btnAdd);
            this.gbUnit.Controls.Add(this.lbQuantityFromBaseUnit);
            this.gbUnit.Controls.Add(this.tbQuantityFromBaseUnit);
            this.gbUnit.Controls.Add(this.cbPrimary);
            this.gbUnit.Controls.Add(this.cbUnitTypeId);
            this.gbUnit.Controls.Add(this.metroLabel11);
            this.gbUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.gbUnit.Location = new System.Drawing.Point(0, 0);
            this.gbUnit.Name = "gbUnit";
            this.gbUnit.Size = new System.Drawing.Size(765, 122);
            this.gbUnit.TabIndex = 37;
            this.gbUnit.TabStop = false;
            this.gbUnit.Text = "الواحدة";
            // 
            // lbBaseUnit2
            // 
            this.lbBaseUnit2.AutoSize = true;
            this.lbBaseUnit2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbBaseUnit2.Location = new System.Drawing.Point(50, 45);
            this.lbBaseUnit2.Name = "lbBaseUnit2";
            this.lbBaseUnit2.Size = new System.Drawing.Size(0, 18);
            this.lbBaseUnit2.TabIndex = 231;
            this.lbBaseUnit2.Visible = false;
            // 
            // lbBaseUnit1
            // 
            this.lbBaseUnit1.AutoSize = true;
            this.lbBaseUnit1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbBaseUnit1.Location = new System.Drawing.Point(29, 20);
            this.lbBaseUnit1.Name = "lbBaseUnit1";
            this.lbBaseUnit1.Size = new System.Drawing.Size(88, 18);
            this.lbBaseUnit1.TabIndex = 1;
            this.lbBaseUnit1.Text = "الواحدة الرئيسية";
            this.lbBaseUnit1.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = global::ShefaaPharmacy.Properties.Resources.AddButton;
            this.btnAdd.Location = new System.Drawing.Point(270, 38);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(2);
            this.btnAdd.Size = new System.Drawing.Size(97, 36);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAdd.TabIndex = 7;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbQuantityFromBaseUnit
            // 
            this.lbQuantityFromBaseUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbQuantityFromBaseUnit.AutoSize = true;
            this.lbQuantityFromBaseUnit.Location = new System.Drawing.Point(527, 83);
            this.lbQuantityFromBaseUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbQuantityFromBaseUnit.Name = "lbQuantityFromBaseUnit";
            this.lbQuantityFromBaseUnit.Size = new System.Drawing.Size(138, 18);
            this.lbQuantityFromBaseUnit.TabIndex = 230;
            this.lbQuantityFromBaseUnit.Text = "الكمية من الوحدة الأساسية";
            // 
            // tbQuantityFromBaseUnit
            // 
            this.tbQuantityFromBaseUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuantityFromBaseUnit.Location = new System.Drawing.Point(386, 80);
            this.tbQuantityFromBaseUnit.Name = "tbQuantityFromBaseUnit";
            this.tbQuantityFromBaseUnit.Size = new System.Drawing.Size(112, 24);
            this.tbQuantityFromBaseUnit.TabIndex = 229;
            // 
            // cbPrimary
            // 
            this.cbPrimary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPrimary.AutoSize = true;
            this.cbPrimary.Location = new System.Drawing.Point(273, 83);
            this.cbPrimary.Name = "cbPrimary";
            this.cbPrimary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPrimary.Size = new System.Drawing.Size(91, 22);
            this.cbPrimary.TabIndex = 228;
            this.cbPrimary.Text = "وحدة أساسية";
            this.cbPrimary.UseVisualStyleBackColor = true;
            this.cbPrimary.Visible = false;
            this.cbPrimary.CheckedChanged += new System.EventHandler(this.CbPrimary_CheckedChanged);
            // 
            // cbUnitTypeId
            // 
            this.cbUnitTypeId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUnitTypeId.FormattingEnabled = true;
            this.cbUnitTypeId.Location = new System.Drawing.Point(385, 43);
            this.cbUnitTypeId.Margin = new System.Windows.Forms.Padding(4);
            this.cbUnitTypeId.Name = "cbUnitTypeId";
            this.cbUnitTypeId.Size = new System.Drawing.Size(236, 26);
            this.cbUnitTypeId.TabIndex = 224;
            this.cbUnitTypeId.SelectedIndexChanged += new System.EventHandler(this.CbUnitTypeId_SelectedIndexChanged);
            // 
            // metroLabel11
            // 
            this.metroLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(642, 46);
            this.metroLabel11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(63, 18);
            this.metroLabel11.TabIndex = 227;
            this.metroLabel11.Text = "إختر واحدة";
            // 
            // pbot
            // 
            this.pbot.Controls.Add(this.dgMaster);
            this.pbot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbot.Location = new System.Drawing.Point(11, 230);
            this.pbot.Margin = new System.Windows.Forms.Padding(4);
            this.pbot.Name = "pbot";
            this.pbot.Size = new System.Drawing.Size(765, 197);
            this.pbot.TabIndex = 9;
            // 
            // dgMaster
            // 
            this.dgMaster.AllowUserToResizeRows = false;
            this.dgMaster.AutoGenerateColumns = false;
            this.dgMaster.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMaster.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgMaster.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgMaster.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMaster.DataSource = this.bsMaster;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgMaster.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMaster.EnableHeadersVisualStyles = false;
            this.dgMaster.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgMaster.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgMaster.Location = new System.Drawing.Point(0, 0);
            this.dgMaster.Margin = new System.Windows.Forms.Padding(4);
            this.dgMaster.Name = "dgMaster";
            this.dgMaster.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgMaster.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMaster.Size = new System.Drawing.Size(765, 197);
            this.dgMaster.TabIndex = 0;
            this.dgMaster.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgMaster_CellMouseClick);
            this.dgMaster.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgMaster_CellMouseDown);
            this.dgMaster.BindingContextChanged += new System.EventHandler(this.DgMaster_BindingContextChanged);
            this.dgMaster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgMaster_MouseDown);
            // 
            // bsMaster
            // 
            this.bsMaster.DataSourceChanged += new System.EventHandler(this.BsMaster_DataSourceChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.toolStripMenuItem1.Text = "حذف واحدة";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ArticleUnitsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(787, 475);
            this.Controls.Add(this.pbot);
            this.Controls.Add(this.pTop2);
            this.Controls.Add(this.pTop);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "ArticleUnitsEditForm";
            this.Padding = new System.Windows.Forms.Padding(11, 62, 11, 8);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "واحدات الصنف";
            this.Load += new System.EventHandler(this.ArticleUnitsEditForm_Load);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pTop, 0);
            this.Controls.SetChildIndex(this.pTop2, 0);
            this.Controls.SetChildIndex(this.pbot, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.pTop.ResumeLayout(false);
            this.pTop.PerformLayout();
            this.pTop2.ResumeLayout(false);
            this.gbUnit.ResumeLayout(false);
            this.gbUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.pbot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMaster)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.TextBox tbArticleName;
        private System.Windows.Forms.LinkLabel lbArticleName;
        private System.Windows.Forms.Panel pTop2;
        private System.Windows.Forms.GroupBox gbUnit;
        private System.Windows.Forms.Label lbQuantityFromBaseUnit;
        private System.Windows.Forms.TextBox tbQuantityFromBaseUnit;
        private System.Windows.Forms.CheckBox cbPrimary;
        private System.Windows.Forms.ComboBox cbUnitTypeId;
        private System.Windows.Forms.Label metroLabel11;
        private System.Windows.Forms.Panel pbot;
        private MetroFramework.Controls.MetroGrid dgMaster;
        private System.Windows.Forms.BindingSource bsMaster;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        protected System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.Label lbBaseUnit2;
        private System.Windows.Forms.Label lbBaseUnit1;
    }
}
