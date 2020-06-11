namespace JSBuild
{
    partial class ProgressForm
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
            if(disposing && (components != null))
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
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.plabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(16, 43);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(362, 19);
            this.pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbar.TabIndex = 0;
            this.pbar.Value = 1;
            // 
            // plabel
            // 
            this.plabel.AutoSize = true;
            this.plabel.Location = new System.Drawing.Point(15, 17);
            this.plabel.Name = "plabel";
            this.plabel.Size = new System.Drawing.Size(61, 13);
            this.plabel.TabIndex = 3;
            this.plabel.Text = "Initializing...";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(402, 91);
            this.ControlBox = false;
            this.Controls.Add(this.plabel);
            this.Controls.Add(this.pbar);
            this.MinimizeBox = false;
            this.Name = "ProgressForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.Label plabel;
    }
}