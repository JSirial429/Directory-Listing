namespace DirectoryListing
{
    partial class NoDir2Print
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
            this.lblNoDir2Print = new System.Windows.Forms.Label();
            this.okBtnNoDir2Print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNoDir2Print
            // 
            this.lblNoDir2Print.Location = new System.Drawing.Point(41, 50);
            this.lblNoDir2Print.Name = "lblNoDir2Print";
            this.lblNoDir2Print.Size = new System.Drawing.Size(217, 40);
            this.lblNoDir2Print.TabIndex = 0;
            this.lblNoDir2Print.Text = "label1";
            // 
            // okBtnNoDir2Print
            // 
            this.okBtnNoDir2Print.Location = new System.Drawing.Point(104, 139);
            this.okBtnNoDir2Print.Name = "okBtnNoDir2Print";
            this.okBtnNoDir2Print.Size = new System.Drawing.Size(75, 23);
            this.okBtnNoDir2Print.TabIndex = 1;
            this.okBtnNoDir2Print.Text = "OK";
            this.okBtnNoDir2Print.UseVisualStyleBackColor = true;
            this.okBtnNoDir2Print.Click += new System.EventHandler(this.okBtnNoDir2Print_Click);
            // 
            // NoDir2Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 200);
            this.Controls.Add(this.okBtnNoDir2Print);
            this.Controls.Add(this.lblNoDir2Print);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoDir2Print";
            this.Text = "NoDir2Print";
            this.Load += new System.EventHandler(this.NoDir2Print_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNoDir2Print;
        private System.Windows.Forms.Button okBtnNoDir2Print;
    }
}