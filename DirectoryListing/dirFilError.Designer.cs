namespace DirectoryListing
{
    partial class dirFilError
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
            this.errLabel = new System.Windows.Forms.Label();
            this.btnErrOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // errLabel
            // 
            this.errLabel.Location = new System.Drawing.Point(70, 18);
            this.errLabel.Name = "errLabel";
            this.errLabel.Size = new System.Drawing.Size(188, 90);
            this.errLabel.TabIndex = 0;
            this.errLabel.Text = "label1";
            // 
            // btnErrOk
            // 
            this.btnErrOk.Location = new System.Drawing.Point(118, 120);
            this.btnErrOk.Name = "btnErrOk";
            this.btnErrOk.Size = new System.Drawing.Size(75, 23);
            this.btnErrOk.TabIndex = 1;
            this.btnErrOk.Text = "OK";
            this.btnErrOk.UseVisualStyleBackColor = true;
            this.btnErrOk.Click += new System.EventHandler(this.btnErrOk_Click);
            // 
            // dirFilError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 182);
            this.Controls.Add(this.btnErrOk);
            this.Controls.Add(this.errLabel);
            this.Name = "dirFilError";
            this.Text = "Error";
            this.Load += new System.EventHandler(this.dirFilError_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label errLabel;
        private System.Windows.Forms.Button btnErrOk;
    }
}