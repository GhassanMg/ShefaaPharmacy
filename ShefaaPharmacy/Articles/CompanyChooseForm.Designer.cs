
namespace ShefaaPharmacy.Articles
{
    partial class CompanyChooseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyChooseForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckCompanies = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.pcloader = new System.Windows.Forms.PictureBox();
            this.datagridcompane = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcloader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridcompane)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMaximaizing
            // 
            this.btnMaximaizing.Location = new System.Drawing.Point(68, 2);
            this.btnMaximaizing.Visible = false;
            // 
            // btnMinimizing
            // 
            this.btnMinimizing.Location = new System.Drawing.Point(36, 2);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(838, 7);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CheckCompanies);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(23, 92);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(900, 100);
            this.panel1.TabIndex = 57;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button1.Location = new System.Drawing.Point(397, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 46);
            this.button1.TabIndex = 58;
            this.button1.Text = "استعراض";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 35);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 63;
            this.label1.Text = "بحث :";
            // 
            // CheckCompanies
            // 
            this.CheckCompanies.AutoSize = true;
            this.CheckCompanies.Enabled = false;
            this.CheckCompanies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.CheckCompanies.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CheckCompanies.Location = new System.Drawing.Point(759, 67);
            this.CheckCompanies.Name = "CheckCompanies";
            this.CheckCompanies.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckCompanies.Size = new System.Drawing.Size(117, 20);
            this.CheckCompanies.TabIndex = 64;
            this.CheckCompanies.Text = "تحديد كل الشركات";
            this.CheckCompanies.UseVisualStyleBackColor = true;
            this.CheckCompanies.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.radioButton2.Location = new System.Drawing.Point(503, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton2.Size = new System.Drawing.Size(73, 20);
            this.radioButton2.TabIndex = 62;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "من الجهاز";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.button2.Location = new System.Drawing.Point(7, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 28);
            this.button2.TabIndex = 60;
            this.button2.Text = "موافق";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.radioButton1.Location = new System.Drawing.Point(497, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton1.Size = new System.Drawing.Size(79, 20);
            this.radioButton1.TabIndex = 61;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "من الانترنت";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.Color.Black;
            this.tbSearch.Location = new System.Drawing.Point(97, 61);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(257, 27);
            this.tbSearch.TabIndex = 59;
            this.tbSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblLoading);
            this.panel2.Controls.Add(this.pcloader);
            this.panel2.Controls.Add(this.datagridcompane);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(23, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 491);
            this.panel2.TabIndex = 58;
            // 
            // lblLoading
            // 
            this.lblLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Gabriola", 9.25F);
            this.lblLoading.Location = new System.Drawing.Point(366, 172);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(168, 23);
            this.lblLoading.TabIndex = 57;
            this.lblLoading.Text = "يتم التحميل الان, يرجى الانتظار";
            this.lblLoading.Visible = false;
            // 
            // pcloader
            // 
            this.pcloader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pcloader.BackColor = System.Drawing.Color.Transparent;
            this.pcloader.Image = ((System.Drawing.Image)(resources.GetObject("pcloader.Image")));
            this.pcloader.Location = new System.Drawing.Point(408, 198);
            this.pcloader.Name = "pcloader";
            this.pcloader.Size = new System.Drawing.Size(79, 73);
            this.pcloader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcloader.TabIndex = 56;
            this.pcloader.TabStop = false;
            this.pcloader.Visible = false;
            // 
            // datagridcompane
            // 
            this.datagridcompane.AllowUserToAddRows = false;
            this.datagridcompane.AllowUserToDeleteRows = false;
            this.datagridcompane.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridcompane.BackgroundColor = System.Drawing.Color.White;
            this.datagridcompane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridcompane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridcompane.EnableHeadersVisualStyles = false;
            this.datagridcompane.Location = new System.Drawing.Point(0, 0);
            this.datagridcompane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.datagridcompane.Name = "datagridcompane";
            this.datagridcompane.RowHeadersWidth = 51;
            this.datagridcompane.RowTemplate.Height = 26;
            this.datagridcompane.Size = new System.Drawing.Size(900, 491);
            this.datagridcompane.TabIndex = 6;
            // 
            // CompanyChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 695);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "CompanyChooseForm";
            this.Padding = new System.Windows.Forms.Padding(23, 92, 12, 12);
            this.Text = "حدد الشركات للاستيراد منها";
            this.Load += new System.EventHandler(this.CompanyChooseForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcloader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridcompane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckCompanies;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.PictureBox pcloader;
        private System.Windows.Forms.DataGridView datagridcompane;
    }
}