namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    partial class GuncellemeBildirimForm
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
            this.lblIcon = new System.Windows.Forms.Label();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlVersionContainer = new System.Windows.Forms.Panel();
            this.pnlNewVersion = new System.Windows.Forms.Panel();
            this.lblNewVersionValue = new System.Windows.Forms.Label();
            this.lblNewVersionCaption = new System.Windows.Forms.Label();
            this.pnlArrow = new System.Windows.Forms.Panel();
            this.lblArrow = new System.Windows.Forms.Label();
            this.pnlOldVersion = new System.Windows.Forms.Panel();
            this.lblOldVersionValue = new System.Windows.Forms.Label();
            this.lblOldVersionCaption = new System.Windows.Forms.Label();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnDahaSonra = new DevExpress.XtraEditors.SimpleButton();
            this.btnSimdiGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlVersionContainer.SuspendLayout();
            this.pnlNewVersion.SuspendLayout();
            this.pnlArrow.SuspendLayout();
            this.pnlOldVersion.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.pnlHeader.Controls.Add(this.lblBaslik);
            this.pnlHeader.Controls.Add(this.lblIcon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(500, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblIcon
            // 
            this.lblIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 36F);
            this.lblIcon.ForeColor = System.Drawing.Color.White;
            this.lblIcon.Location = new System.Drawing.Point(15, 10);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(70, 60);
            this.lblIcon.TabIndex = 0;
            this.lblIcon.Text = "🚀";
            this.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(90, 22);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(320, 32);
            this.lblBaslik.TabIndex = 1;
            this.lblBaslik.Text = "Yeni Güncelleme Mevcut!";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.pnlBody.Controls.Add(this.pnlVersionContainer);
            this.pnlBody.Controls.Add(this.lblAciklama);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 80);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(500, 190);
            this.pnlBody.TabIndex = 1;
            // 
            // lblAciklama
            // 
            this.lblAciklama.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAciklama.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAciklama.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            this.lblAciklama.Location = new System.Drawing.Point(0, 0);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.lblAciklama.Size = new System.Drawing.Size(500, 60);
            this.lblAciklama.TabIndex = 0;
            this.lblAciklama.Text = "Sisteminiz için yeni bir sürüm yayınlandı.";
            this.lblAciklama.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlVersionContainer
            // 
            this.pnlVersionContainer.Controls.Add(this.pnlNewVersion);
            this.pnlVersionContainer.Controls.Add(this.pnlArrow);
            this.pnlVersionContainer.Controls.Add(this.pnlOldVersion);
            this.pnlVersionContainer.Location = new System.Drawing.Point(30, 70);
            this.pnlVersionContainer.Name = "pnlVersionContainer";
            this.pnlVersionContainer.Size = new System.Drawing.Size(440, 90);
            this.pnlVersionContainer.TabIndex = 1;
            // 
            // pnlOldVersion
            // 
            this.pnlOldVersion.BackColor = System.Drawing.Color.FromArgb(50, 50, 55);
            this.pnlOldVersion.Controls.Add(this.lblOldVersionValue);
            this.pnlOldVersion.Controls.Add(this.lblOldVersionCaption);
            this.pnlOldVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlOldVersion.Location = new System.Drawing.Point(0, 0);
            this.pnlOldVersion.Name = "pnlOldVersion";
            this.pnlOldVersion.Size = new System.Drawing.Size(175, 90);
            this.pnlOldVersion.TabIndex = 0;
            // 
            // lblOldVersionCaption
            // 
            this.lblOldVersionCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOldVersionCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOldVersionCaption.ForeColor = System.Drawing.Color.FromArgb(150, 150, 160);
            this.lblOldVersionCaption.Location = new System.Drawing.Point(0, 0);
            this.lblOldVersionCaption.Name = "lblOldVersionCaption";
            this.lblOldVersionCaption.Size = new System.Drawing.Size(175, 30);
            this.lblOldVersionCaption.TabIndex = 0;
            this.lblOldVersionCaption.Text = "Mevcut Sürüm";
            this.lblOldVersionCaption.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblOldVersionValue
            // 
            this.lblOldVersionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOldVersionValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblOldVersionValue.ForeColor = System.Drawing.Color.FromArgb(255, 100, 100);
            this.lblOldVersionValue.Location = new System.Drawing.Point(0, 30);
            this.lblOldVersionValue.Name = "lblOldVersionValue";
            this.lblOldVersionValue.Size = new System.Drawing.Size(175, 60);
            this.lblOldVersionValue.TabIndex = 1;
            this.lblOldVersionValue.Text = "v1.0.0";
            this.lblOldVersionValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlArrow
            // 
            this.pnlArrow.Controls.Add(this.lblArrow);
            this.pnlArrow.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlArrow.Location = new System.Drawing.Point(175, 0);
            this.pnlArrow.Name = "pnlArrow";
            this.pnlArrow.Size = new System.Drawing.Size(90, 90);
            this.pnlArrow.TabIndex = 1;
            // 
            // lblArrow
            // 
            this.lblArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblArrow.Font = new System.Drawing.Font("Segoe UI Emoji", 28F);
            this.lblArrow.ForeColor = System.Drawing.Color.FromArgb(0, 180, 100);
            this.lblArrow.Location = new System.Drawing.Point(0, 0);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(90, 90);
            this.lblArrow.TabIndex = 0;
            this.lblArrow.Text = "➡️";
            this.lblArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlNewVersion
            // 
            this.pnlNewVersion.BackColor = System.Drawing.Color.FromArgb(0, 60, 100);
            this.pnlNewVersion.Controls.Add(this.lblNewVersionValue);
            this.pnlNewVersion.Controls.Add(this.lblNewVersionCaption);
            this.pnlNewVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNewVersion.Location = new System.Drawing.Point(265, 0);
            this.pnlNewVersion.Name = "pnlNewVersion";
            this.pnlNewVersion.Size = new System.Drawing.Size(175, 90);
            this.pnlNewVersion.TabIndex = 2;
            // 
            // lblNewVersionCaption
            // 
            this.lblNewVersionCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNewVersionCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewVersionCaption.ForeColor = System.Drawing.Color.FromArgb(150, 200, 255);
            this.lblNewVersionCaption.Location = new System.Drawing.Point(0, 0);
            this.lblNewVersionCaption.Name = "lblNewVersionCaption";
            this.lblNewVersionCaption.Size = new System.Drawing.Size(175, 30);
            this.lblNewVersionCaption.TabIndex = 0;
            this.lblNewVersionCaption.Text = "Yeni Sürüm";
            this.lblNewVersionCaption.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblNewVersionValue
            // 
            this.lblNewVersionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNewVersionValue.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblNewVersionValue.ForeColor = System.Drawing.Color.FromArgb(0, 200, 120);
            this.lblNewVersionValue.Location = new System.Drawing.Point(0, 30);
            this.lblNewVersionValue.Name = "lblNewVersionValue";
            this.lblNewVersionValue.Size = new System.Drawing.Size(175, 60);
            this.lblNewVersionValue.TabIndex = 1;
            this.lblNewVersionValue.Text = "v1.0.5";
            this.lblNewVersionValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(36, 36, 38);
            this.pnlBottom.Controls.Add(this.btnDahaSonra);
            this.pnlBottom.Controls.Add(this.btnSimdiGuncelle);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 270);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(500, 75);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnSimdiGuncelle
            // 
            this.btnSimdiGuncelle.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 150, 80);
            this.btnSimdiGuncelle.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSimdiGuncelle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSimdiGuncelle.Appearance.Options.UseBackColor = true;
            this.btnSimdiGuncelle.Appearance.Options.UseFont = true;
            this.btnSimdiGuncelle.Appearance.Options.UseForeColor = true;
            this.btnSimdiGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimdiGuncelle.Location = new System.Drawing.Point(140, 17);
            this.btnSimdiGuncelle.Name = "btnSimdiGuncelle";
            this.btnSimdiGuncelle.Size = new System.Drawing.Size(220, 42);
            this.btnSimdiGuncelle.TabIndex = 0;
            this.btnSimdiGuncelle.Text = "🔄 Şimdi Güncelle";
            this.btnSimdiGuncelle.Click += new System.EventHandler(this.btnSimdiGuncelle_Click);
            // 
            // btnDahaSonra
            // 
            this.btnDahaSonra.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDahaSonra.Appearance.ForeColor = System.Drawing.Color.FromArgb(180, 180, 190);
            this.btnDahaSonra.Appearance.Options.UseFont = true;
            this.btnDahaSonra.Appearance.Options.UseForeColor = true;
            this.btnDahaSonra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDahaSonra.Location = new System.Drawing.Point(370, 22);
            this.btnDahaSonra.Name = "btnDahaSonra";
            this.btnDahaSonra.Size = new System.Drawing.Size(120, 32);
            this.btnDahaSonra.TabIndex = 1;
            this.btnDahaSonra.Text = "Daha Sonra";
            this.btnDahaSonra.Click += new System.EventHandler(this.btnDahaSonra_Click);
            // 
            // GuncellemeBildirimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.ClientSize = new System.Drawing.Size(500, 345);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuncellemeBildirimForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Güncelleme Bildirimi - WinBeyazEsya";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlVersionContainer.ResumeLayout(false);
            this.pnlNewVersion.ResumeLayout(false);
            this.pnlArrow.ResumeLayout(false);
            this.pnlOldVersion.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblAciklama;
        private System.Windows.Forms.Panel pnlVersionContainer;
        private System.Windows.Forms.Panel pnlOldVersion;
        private System.Windows.Forms.Label lblOldVersionCaption;
        private System.Windows.Forms.Label lblOldVersionValue;
        private System.Windows.Forms.Panel pnlArrow;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.Panel pnlNewVersion;
        private System.Windows.Forms.Label lblNewVersionCaption;
        private System.Windows.Forms.Label lblNewVersionValue;
        private System.Windows.Forms.Panel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnSimdiGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnDahaSonra;
    }
}
