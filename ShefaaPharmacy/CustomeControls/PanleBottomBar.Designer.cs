
namespace ShefaaPharmacy.CustomeControls
{
    partial class PanleBottomBar
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
            this.pBottomCustome = new System.Windows.Forms.Panel();
            this.saveButton1 = new ShefaaPharmacy.CustomeControls.SaveButton();
            this.pBottomCustome.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBottomCustome
            // 
            this.pBottomCustome.Controls.Add(this.saveButton1);
            this.pBottomCustome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBottomCustome.Location = new System.Drawing.Point(0, 0);
            this.pBottomCustome.Name = "pBottomCustome";
            this.pBottomCustome.Size = new System.Drawing.Size(566, 57);
            this.pBottomCustome.TabIndex = 0;
            // 
            // saveButton1
            // 
            this.saveButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(172)))), ((int)(((byte)(186)))));
            this.saveButton1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(172)))), ((int)(((byte)(186)))));
            this.saveButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton1.Location = new System.Drawing.Point(451, 14);
            this.saveButton1.Name = "saveButton1";
            this.saveButton1.OnHoverBorderColor = System.Drawing.Color.WhiteSmoke;
            this.saveButton1.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.saveButton1.OnHoverTextColor = System.Drawing.Color.Gray;
            this.saveButton1.Size = new System.Drawing.Size(102, 36);
            this.saveButton1.TabIndex = 0;
            this.saveButton1.TabStop = false;
            this.saveButton1.Text = "saveButton1";
            this.saveButton1.TextColor = System.Drawing.Color.White;
            this.saveButton1.UseVisualStyleBackColor = true;
            // 
            // PanleBottomBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pBottomCustome);
            this.Name = "PanleBottomBar";
            this.Size = new System.Drawing.Size(566, 57);
            this.pBottomCustome.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBottomCustome;
        private SaveButton saveButton1;
    }
}
