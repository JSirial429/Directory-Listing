namespace DirectoryListing
{
    partial class ExportSuccessDLG
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
            this.okBtnExportSuccessDLG = new System.Windows.Forms.Button();
            this.lblExportSuccessDLG = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okBtnExportSuccessDLG
            // 
            this.okBtnExportSuccessDLG.Location = new System.Drawing.Point(107, 98);
            this.okBtnExportSuccessDLG.Name = "okBtnExportSuccessDLG";
            this.okBtnExportSuccessDLG.Size = new System.Drawing.Size(75, 23);
            this.okBtnExportSuccessDLG.TabIndex = 0;
            this.okBtnExportSuccessDLG.Text = "OK";
            this.okBtnExportSuccessDLG.UseVisualStyleBackColor = true;
            this.okBtnExportSuccessDLG.Click += new System.EventHandler(this.okBtnExportSuccessDLG_Click);
            // 
            // lblExportSuccessDLG
            // 
            this.lblExportSuccessDLG.AutoSize = true;
            this.lblExportSuccessDLG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportSuccessDLG.Location = new System.Drawing.Point(29, 32);
            this.lblExportSuccessDLG.Name = "lblExportSuccessDLG";
            this.lblExportSuccessDLG.Size = new System.Drawing.Size(45, 16);
            this.lblExportSuccessDLG.TabIndex = 1;
            this.lblExportSuccessDLG.Text = "label1";
            // 
            // ExportSuccessDLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 133);
            this.Controls.Add(this.lblExportSuccessDLG);
            this.Controls.Add(this.okBtnExportSuccessDLG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportSuccessDLG";
            this.Text = "Success";
            this.Load += new System.EventHandler(this.ExportSuccessDLG_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtnExportSuccessDLG;
        private System.Windows.Forms.Label lblExportSuccessDLG;
    }
}