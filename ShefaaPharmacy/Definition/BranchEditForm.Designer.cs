namespace ShefaaPharmacy.Definition
{
    partial class BranchEditForm
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
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.pBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditBindingSource
            // 
            this.EditBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.EditBindingSource_AddingNew);
            // 
            // pBottom
            // 
            this.pBottom.Location = new System.Drawing.Point(10, 194);
            this.pBottom.Size = new System.Drawing.Size(402, 48);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(86, -2);
            this.btnCancel.Size = new System.Drawing.Size(113, 50);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(203, -2);
            this.btnOk.Size = new System.Drawing.Size(113, 50);
            // 
            // btnMaximaizing
            // 
            this.btnMaximaizing.Location = new System.Drawing.Point(33, 0);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(3, 0);
            // 
            // btnMinimizing
            // 
            this.btnMinimizing.Location = new System.Drawing.Point(65, 0);
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(314, 8);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.pHelperButton.Size = new System.Drawing.Size(94, 38);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.tbName);
            this.metroPanel2.Controls.Add(this.lbName);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 18;
            this.metroPanel2.Location = new System.Drawing.Point(10, 80);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(402, 114);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 13;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(59, 52);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(235, 30);
            this.tbName.TabIndex = 9;
            // 
            // lbName
            // 
            this.lbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(300, 55);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(44, 23);
            this.lbName.TabIndex = 8;
            this.lbName.Text = "المخزن";
            // 
            // BranchEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.ClientSize = new System.Drawing.Size(422, 252);
            this.Controls.Add(this.metroPanel2);
            this.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.Name = "BranchEditForm";
            this.Padding = new System.Windows.Forms.Padding(10, 80, 10, 10);
            this.Resizable = false;
            this.Text = "تعريف مخزن";
            this.Load += new System.EventHandler(this.BranchEditForm_Load);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            this.Controls.SetChildIndex(this.pBottom, 0);
            this.Controls.SetChildIndex(this.metroPanel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.pBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
    }
}
