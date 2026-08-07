namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    partial class SurumNotlariForm
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
            this.lblVersionBadge = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderIcon = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 140, 80);
            this.pnlHeader.Controls.Add(this.lblVersionBadge);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.lblHeaderIcon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(540, 85);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderIcon
            // 
            this.lblHeaderIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 34F);
            this.lblHeaderIcon.ForeColor = System.Drawing.Color.White;
            this.lblHeaderIcon.Location = new System.Drawing.Point(14, 10);
            this.lblHeaderIcon.Name = "lblHeaderIcon";
            this.lblHeaderIcon.Size = new System.Drawing.Size(65, 62);
            this.lblHeaderIcon.TabIndex = 0;
            this.lblHeaderIcon.Text = "📋";
            this.lblHeaderIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(85, 14);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(200, 32);
            this.lblHeaderTitle.TabIndex = 1;
            this.lblHeaderTitle.Text = "Neler Yeni?";
            // 
            // lblVersionBadge
            // 
            this.lblVersionBadge.BackColor = System.Drawing.Color.FromArgb(0, 100, 56);
            this.lblVersionBadge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVersionBadge.ForeColor = System.Drawing.Color.FromArgb(150, 255, 200);
            this.lblVersionBadge.Location = new System.Drawing.Point(88, 50);
            this.lblVersionBadge.Name = "lblVersionBadge";
            this.lblVersionBadge.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
            this.lblVersionBadge.Size = new System.Drawing.Size(120, 24);
            this.lblVersionBadge.TabIndex = 2;
            this.lblVersionBadge.Text = "v1.0.0.0";
            this.lblVersionBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.pnlBody.Controls.Add(this.txtNotes);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 85);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(22, 18, 22, 12);
            this.pnlBody.Size = new System.Drawing.Size(540, 295);
            this.pnlBody.TabIndex = 1;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.FromArgb(38, 38, 42);
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNotes.ForeColor = System.Drawing.Color.FromArgb(220, 220, 230);
            this.txtNotes.Location = new System.Drawing.Point(22, 18);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(496, 265);
            this.txtNotes.TabIndex = 0;
            this.txtNotes.Text = "";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(36, 36, 38);
            this.pnlBottom.Controls.Add(this.btnKapat);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 380);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(540, 65);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnKapat
            // 
            this.btnKapat.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 140, 80);
            this.btnKapat.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnKapat.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Appearance.Options.UseBackColor = true;
            this.btnKapat.Appearance.Options.UseFont = true;
            this.btnKapat.Appearance.Options.UseForeColor = true;
            this.btnKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKapat.Location = new System.Drawing.Point(195, 14);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnKapat.Size = new System.Drawing.Size(150, 38);
            this.btnKapat.TabIndex = 0;
            this.btnKapat.Text = "Tamam";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // SurumNotlariForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(28, 28, 30);
            this.ClientSize = new System.Drawing.Size(540, 445);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SurumNotlariForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sürüm Notları — WinBeyazEsya";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderIcon;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblVersionBadge;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.Panel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
    }
}
