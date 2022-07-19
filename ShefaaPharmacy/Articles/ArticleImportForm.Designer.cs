namespace ShefaaPharmacy.Articles
{
    partial class ArticleImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticleImportForm));
            this.pMaster = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dtGrid = new System.Windows.Forms.DataGridView();
            this.lbStop = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAll = new System.Windows.Forms.Label();
            this.lbDone = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pbAccountPick = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbPath = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.pMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccountPick)).BeginInit();
            this.SuspendLayout();
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(698, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            // 
            // pMaster
            // 
            this.pMaster.Controls.Add(this.tbSearch);
            this.pMaster.Controls.Add(this.label5);
            this.pMaster.Controls.Add(this.button2);
            this.pMaster.Controls.Add(this.dtGrid);
            this.pMaster.Controls.Add(this.lbStop);
            this.pMaster.Controls.Add(this.lbError);
            this.pMaster.Controls.Add(this.label4);
            this.pMaster.Controls.Add(this.label3);
            this.pMaster.Controls.Add(this.lbAll);
            this.pMaster.Controls.Add(this.lbDone);
            this.pMaster.Controls.Add(this.label2);
            this.pMaster.Controls.Add(this.label1);
            this.pMaster.Controls.Add(this.button1);
            this.pMaster.Controls.Add(this.pbAccountPick);
            this.pMaster.Controls.Add(this.textBox1);
            this.pMaster.Controls.Add(this.lbPath);
            this.pMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMaster.Font = new System.Drawing.Font("AD-STOOR", 11F);
            this.pMaster.Location = new System.Drawing.Point(20, 80);
            this.pMaster.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pMaster.Name = "pMaster";
            this.pMaster.Size = new System.Drawing.Size(764, 478);
            this.pMaster.TabIndex = 0;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(443, 57);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(221, 30);
            this.tbSearch.TabIndex = 38;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(691, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 37;
            this.label5.Text = "بحث عن ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(167, 12);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 33);
            this.button2.TabIndex = 36;
            this.button2.Text = "حفظ إلى قاعدة البيانات";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // dtGrid
            // 
            this.dtGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGrid.BackgroundColor = System.Drawing.Color.White;
            this.dtGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtGrid.Location = new System.Drawing.Point(0, 109);
            this.dtGrid.Name = "dtGrid";
            this.dtGrid.Size = new System.Drawing.Size(764, 369);
            this.dtGrid.TabIndex = 35;
            this.dtGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_CellEndEdit);
            this.dtGrid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtGrid_CellMouseUp);
            this.dtGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtGrid_CellValidating);
            // 
            // lbStop
            // 
            this.lbStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStop.AutoSize = true;
            this.lbStop.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.lbStop.ForeColor = System.Drawing.Color.Red;
            this.lbStop.Location = new System.Drawing.Point(57, 48);
            this.lbStop.Name = "lbStop";
            this.lbStop.Size = new System.Drawing.Size(79, 23);
            this.lbStop.TabIndex = 34;
            this.lbStop.Text = "إيقاف قسري";
            this.lbStop.UseWaitCursor = true;
            this.lbStop.Visible = false;
            // 
            // lbError
            // 
            this.lbError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(165, 106);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(17, 23);
            this.lbError.TabIndex = 33;
            this.lbError.Text = "0";
            this.lbError.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 23);
            this.label4.TabIndex = 32;
            this.label4.Text = "الأخطاء";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 31;
            this.label3.Text = "جاري إستيراد الأصناف .....";
            this.label3.Visible = false;
            // 
            // lbAll
            // 
            this.lbAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAll.AutoSize = true;
            this.lbAll.ForeColor = System.Drawing.Color.Blue;
            this.lbAll.Location = new System.Drawing.Point(25, 48);
            this.lbAll.Name = "lbAll";
            this.lbAll.Size = new System.Drawing.Size(17, 23);
            this.lbAll.TabIndex = 30;
            this.lbAll.Text = "0";
            this.lbAll.Visible = false;
            // 
            // lbDone
            // 
            this.lbDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDone.AutoSize = true;
            this.lbDone.ForeColor = System.Drawing.Color.Green;
            this.lbDone.Location = new System.Drawing.Point(165, 64);
            this.lbDone.Name = "lbDone";
            this.lbDone.Size = new System.Drawing.Size(17, 23);
            this.lbDone.TabIndex = 29;
            this.lbDone.Text = "0";
            this.lbDone.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "من أصل";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "تمت إضافة ";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(320, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 33);
            this.button1.TabIndex = 26;
            this.button1.Text = "استيراد";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbAccountPick
            // 
            this.pbAccountPick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAccountPick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAccountPick.Image = ((System.Drawing.Image)(resources.GetObject("pbAccountPick.Image")));
            this.pbAccountPick.Location = new System.Drawing.Point(415, 17);
            this.pbAccountPick.Name = "pbAccountPick";
            this.pbAccountPick.Size = new System.Drawing.Size(22, 24);
            this.pbAccountPick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAccountPick.TabIndex = 25;
            this.pbAccountPick.TabStop = false;
            this.pbAccountPick.Click += new System.EventHandler(this.pbAccountPick_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(443, 14);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(221, 30);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbPath
            // 
            this.lbPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(670, 17);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(77, 23);
            this.lbPath.TabIndex = 2;
            this.lbPath.Text = "ملف الإكسل";
            this.lbPath.Click += new System.EventHandler(this.lbPath_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ArticleImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.ClientSize = new System.Drawing.Size(794, 573);
            this.Controls.Add(this.pMaster);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "ArticleImportForm";
            this.Padding = new System.Windows.Forms.Padding(20, 80, 10, 15);
            this.Text = "استيراد أصناف";
            this.Load += new System.EventHandler(this.ArticleImportForm_Load);
            this.Controls.SetChildIndex(this.pMaster, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.pMaster.ResumeLayout(false);
            this.pMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccountPick)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMaster;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.PictureBox pbAccountPick;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbAll;
        private System.Windows.Forms.Label lbDone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbStop;
        private System.Windows.Forms.DataGridView dtGrid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label5;
    }
}
