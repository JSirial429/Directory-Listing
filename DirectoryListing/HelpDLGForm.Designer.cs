namespace DirectoryListing
{
    partial class HelpDLGForm
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
            this.helpLabelDLG = new System.Windows.Forms.Label();
            this.okHelpDLGBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // helpLabelDLG
            // 
            this.helpLabelDLG.Location = new System.Drawing.Point(31, 37);
            this.helpLabelDLG.Margin = new System.Windows.Forms.Padding(100, 50, 100, 50);
            this.helpLabelDLG.Name = "helpLabelDLG";
            this.helpLabelDLG.Size = new System.Drawing.Size(214, 77);
            this.helpLabelDLG.TabIndex = 0;
            this.helpLabelDLG.Text = "helpLabelDLG";
            // 
            // okHelpDLGBtn
            // 
            this.okHelpDLGBtn.Location = new System.Drawing.Point(96, 135);
            this.okHelpDLGBtn.Name = "okHelpDLGBtn";
            this.okHelpDLGBtn.Size = new System.Drawing.Size(75, 23);
            this.okHelpDLGBtn.TabIndex = 1;
            this.okHelpDLGBtn.Text = "OK";
            this.okHelpDLGBtn.UseVisualStyleBackColor = true;
            this.okHelpDLGBtn.Click += new System.EventHandler(this.okHelpDLGBtn_Click);
            // 
            // HelpDLGForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 173);
            this.Controls.Add(this.okHelpDLGBtn);
            this.Controls.Add(this.helpLabelDLG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpDLGForm";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.HelpDLGForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label helpLabelDLG;
        private System.Windows.Forms.Button okHelpDLGBtn;
    }
}