namespace WinBeyazEsya.Updater
{
    partial class UpdateForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderIcon = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlProgressContainer = new System.Windows.Forms.Panel();
            this.lblPercent = new System.Windows.Forms.Label();
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._lblStatus = new System.Windows.Forms.Label();
            this.pnlStepIcon = new System.Windows.Forms.Panel();
            this.lblStepIcon = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlProgressContainer.SuspendLayout();
            this.pnlStepIcon.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 90, 158);
            this.pnlHeader.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblHeaderIcon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(540, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderIcon
            // 
            this.lblHeaderIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 32F);
            this.lblHeaderIcon.ForeColor = System.Drawing.Color.White;
            this.lblHeaderIcon.Location = new System.Drawing.Point(14, 12);
            this.lblHeaderIcon.Name = "lblHeaderIcon";
            this.lblHeaderIcon.Size = new System.Drawing.Size(60, 56);
            this.lblHeaderIcon.TabIndex = 0;
            this.lblHeaderIcon.Text = "⚙️";
            this.lblHeaderIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(80, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(310, 31);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Sistem Güncelleniyor";
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(83, 46);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(320, 17);
            this.lblHeaderSubtitle.TabIndex = 2;
            this.lblHeaderSubtitle.Text = "Lütfen güncelleme tamamlanana kadar bekleyiniz...";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.pnlBody.Controls.Add(this.pnlProgressContainer);
            this.pnlBody.Controls.Add(this.pnlStepIcon);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 80);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(24, 16, 24, 8);
            this.pnlBody.Size = new System.Drawing.Size(540, 160);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlStepIcon
            // 
            this.pnlStepIcon.BackColor = System.Drawing.Color.FromArgb(38, 38, 42);
            this.pnlStepIcon.Controls.Add(this.lblStepIcon);
            this.pnlStepIcon.Location = new System.Drawing.Point(24, 16);
            this.pnlStepIcon.Name = "pnlStepIcon";
            this.pnlStepIcon.Size = new System.Drawing.Size(50, 50);
            this.pnlStepIcon.TabIndex = 2;
            // 
            // lblStepIcon
            // 
            this.lblStepIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStepIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 22F);
            this.lblStepIcon.ForeColor = System.Drawing.Color.FromArgb(0, 180, 120);
            this.lblStepIcon.Location = new System.Drawing.Point(0, 0);
            this.lblStepIcon.Name = "lblStepIcon";
            this.lblStepIcon.Size = new System.Drawing.Size(50, 50);
            this.lblStepIcon.TabIndex = 0;
            this.lblStepIcon.Text = "🔄";
            this.lblStepIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProgressContainer
            // 
            this.pnlProgressContainer.Controls.Add(this._progressBar);
            this.pnlProgressContainer.Controls.Add(this.lblPercent);
            this.pnlProgressContainer.Controls.Add(this._lblStatus);
            this.pnlProgressContainer.Location = new System.Drawing.Point(82, 16);
            this.pnlProgressContainer.Name = "pnlProgressContainer";
            this.pnlProgressContainer.Size = new System.Drawing.Size(434, 130);
            this.pnlProgressContainer.TabIndex = 3;
            // 
            // _lblStatus
            // 
            this._lblStatus.Font = new System.Drawing.Font("Segoe UI", 11.5F);
            this._lblStatus.ForeColor = System.Drawing.Color.FromArgb(210, 210, 220);
            this._lblStatus.Location = new System.Drawing.Point(0, 0);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(434, 48);
            this._lblStatus.TabIndex = 0;
            this._lblStatus.Text = "Lütfen bekleyiniz...";
            this._lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(0, 56);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(370, 28);
            this._progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this._progressBar.TabIndex = 1;
            // 
            // lblPercent
            // 
            this.lblPercent.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPercent.ForeColor = System.Drawing.Color.FromArgb(0, 200, 120);
            this.lblPercent.Location = new System.Drawing.Point(376, 54);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(58, 30);
            this.lblPercent.TabIndex = 2;
            this.lblPercent.Text = "%0";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(22, 22, 24);
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 240);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(540, 40);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblFooter
            // 
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(100, 100, 110);
            this.lblFooter.Location = new System.Drawing.Point(0, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(540, 40);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "WinBeyazEsya® Otomatik Güncelleme Sistemi";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.ClientSize = new System.Drawing.Size(540, 280);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistem Güncelleme";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlProgressContainer.ResumeLayout(false);
            this.pnlStepIcon.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlStepIcon;
        private System.Windows.Forms.Label lblStepIcon;
        private System.Windows.Forms.Panel pnlProgressContainer;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}
