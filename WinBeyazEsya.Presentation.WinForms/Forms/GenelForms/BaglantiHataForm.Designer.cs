namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    partial class BaglantiHataForm
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
            lblWarningHeader = new System.Windows.Forms.Label();
            lblWarningText = new System.Windows.Forms.Label();
            btnSihirbaziAc = new DevExpress.XtraEditors.SimpleButton();
            pnlBottom = new System.Windows.Forms.Panel();
            pnlIcon = new System.Windows.Forms.Panel();
            lblIcon = new System.Windows.Forms.Label();
            pnlBottom.SuspendLayout();
            pnlIcon.SuspendLayout();
            SuspendLayout();
            // 
            // lblWarningHeader
            // 
            lblWarningHeader.Dock = System.Windows.Forms.DockStyle.Top;
            lblWarningHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblWarningHeader.ForeColor = System.Drawing.Color.FromArgb(255, 100, 100);
            lblWarningHeader.Location = new System.Drawing.Point(0, 100);
            lblWarningHeader.Name = "lblWarningHeader";
            lblWarningHeader.Size = new System.Drawing.Size(550, 50);
            lblWarningHeader.TabIndex = 1;
            lblWarningHeader.Text = "SUNUCU BAĞLANTISI KURULAMADI";
            lblWarningHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarningText
            // 
            lblWarningText.Dock = System.Windows.Forms.DockStyle.Fill;
            lblWarningText.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblWarningText.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            lblWarningText.Location = new System.Drawing.Point(0, 150);
            lblWarningText.Name = "lblWarningText";
            lblWarningText.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            lblWarningText.Size = new System.Drawing.Size(550, 120);
            lblWarningText.TabIndex = 2;
            lblWarningText.Text = "Sistem ana sunucusuna erişilemiyor veya veritabanı ayarlarınız eksik.\n\nLütfen bağlantı ayarlarını yapılandırmak için sihirbazı çalıştırın.";
            lblWarningText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = System.Drawing.Color.FromArgb(36, 36, 38);
            pnlBottom.Controls.Add(btnSihirbaziAc);
            pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlBottom.Location = new System.Drawing.Point(0, 270);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new System.Drawing.Size(550, 80);
            pnlBottom.TabIndex = 3;
            // 
            // btnSihirbaziAc
            // 
            btnSihirbaziAc.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            btnSihirbaziAc.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSihirbaziAc.Appearance.ForeColor = System.Drawing.Color.White;
            btnSihirbaziAc.Appearance.Options.UseBackColor = true;
            btnSihirbaziAc.Appearance.Options.UseFont = true;
            btnSihirbaziAc.Appearance.Options.UseForeColor = true;
            btnSihirbaziAc.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSihirbaziAc.Location = new System.Drawing.Point(145, 20);
            btnSihirbaziAc.Name = "btnSihirbaziAc";
            btnSihirbaziAc.Size = new System.Drawing.Size(260, 40);
            btnSihirbaziAc.TabIndex = 0;
            btnSihirbaziAc.Text = "⚙ Veritabanı Ayarlarını Yapılandır";
            btnSihirbaziAc.Click += new System.EventHandler(btnSihirbaziAc_Click);
            // 
            // pnlIcon
            // 
            pnlIcon.Controls.Add(lblIcon);
            pnlIcon.Dock = System.Windows.Forms.DockStyle.Top;
            pnlIcon.Location = new System.Drawing.Point(0, 0);
            pnlIcon.Name = "pnlIcon";
            pnlIcon.Size = new System.Drawing.Size(550, 100);
            pnlIcon.TabIndex = 0;
            // 
            // lblIcon
            // 
            lblIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            lblIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 48F);
            lblIcon.ForeColor = System.Drawing.Color.FromArgb(255, 100, 100);
            lblIcon.Location = new System.Drawing.Point(0, 0);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new System.Drawing.Size(550, 100);
            lblIcon.TabIndex = 0;
            lblIcon.Text = "🔌";
            lblIcon.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // BaglantiHataForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            ClientSize = new System.Drawing.Size(550, 350);
            Controls.Add(lblWarningText);
            Controls.Add(lblWarningHeader);
            Controls.Add(pnlIcon);
            Controls.Add(pnlBottom);
            ForeColor = System.Drawing.Color.FromArgb(242, 242, 247);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            IconOptions.ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BaglantiHataForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Bağlantı Hatası - WinBeyazEsya";
            pnlBottom.ResumeLayout(false);
            pnlIcon.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblWarningHeader;
        private System.Windows.Forms.Label lblWarningText;
        private DevExpress.XtraEditors.SimpleButton btnSihirbaziAc;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlIcon;
        private System.Windows.Forms.Label lblIcon;
    }
}
