namespace WinBeyazEsya.Updater
{
    partial class UpdateForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this._lblStatus = new System.Windows.Forms.Label();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(206, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sistem Güncelleniyor";
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this._lblStatus.Location = new System.Drawing.Point(20, 60);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(126, 19);
            this._lblStatus.TabIndex = 1;
            this._lblStatus.Text = "Lütfen bekleyiniz...";
            // 
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(20, 90);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(360, 20);
            this._progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._progressBar.TabIndex = 2;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Controls.Add(this._progressBar);
            this.Controls.Add(this._lblStatus);
            this.Controls.Add(this.lblTitle);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem Güncelleme";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.ProgressBar _progressBar;
    }
}
