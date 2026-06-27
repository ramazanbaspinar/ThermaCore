namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
{
    partial class SubeSecimForm
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

        private void InitializeComponent()
        {
            lblMesaj = new DevExpress.XtraEditors.LabelControl();
            cmbSubeler = new DevExpress.XtraEditors.ImageComboBoxEdit();
            chkHatirla = new DevExpress.XtraEditors.CheckEdit();
            btnSecVeBasla = new DevExpress.XtraEditors.SimpleButton();
            btnIptalCikis = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)cmbSubeler.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkHatirla.Properties).BeginInit();
            SuspendLayout();
            // 
            // lblMesaj
            // 
            lblMesaj.Appearance.Font = new Font("Tahoma", 10F);
            lblMesaj.Appearance.Options.UseFont = true;
            lblMesaj.Appearance.Options.UseTextOptions = true;
            lblMesaj.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            lblMesaj.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            lblMesaj.Location = new Point(17, 16);
            lblMesaj.Margin = new Padding(3, 2, 3, 2);
            lblMesaj.Name = "lblMesaj";
            lblMesaj.Size = new Size(309, 32);
            lblMesaj.TabIndex = 0;
            lblMesaj.Text = "Birden fazla fabrikada işlem yetkiniz bulunmaktadır. Lütfen giriş yapmak istediğiniz şubeyi seçin:";
            // 
            // cmbSubeler
            // 
            cmbSubeler.Location = new Point(17, 57);
            cmbSubeler.Margin = new Padding(3, 2, 3, 2);
            cmbSubeler.Name = "cmbSubeler";
            cmbSubeler.Properties.Appearance.Font = new Font("Tahoma", 10F);
            cmbSubeler.Properties.Appearance.Options.UseFont = true;
            cmbSubeler.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbSubeler.Size = new Size(309, 22);
            cmbSubeler.TabIndex = 1;
            // 
            // chkHatirla
            // 
            chkHatirla.Location = new Point(17, 89);
            chkHatirla.Margin = new Padding(3, 2, 3, 2);
            chkHatirla.Name = "chkHatirla";
            chkHatirla.Properties.Appearance.Font = new Font("Tahoma", 9F);
            chkHatirla.Properties.Appearance.Options.UseFont = true;
            chkHatirla.Properties.Caption = "Bu seçimi hatırla (Girişte tekrar sorma)";
            chkHatirla.Size = new Size(309, 20);
            chkHatirla.TabIndex = 2;
            // 
            // btnSecVeBasla
            // 
            btnSecVeBasla.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnSecVeBasla.Appearance.Options.UseFont = true;
            btnSecVeBasla.ImageOptions.SvgImage = Properties.Resources.bo_validation;
            btnSecVeBasla.Location = new Point(154, 122);
            btnSecVeBasla.Margin = new Padding(3, 2, 3, 2);
            btnSecVeBasla.Name = "btnSecVeBasla";
            btnSecVeBasla.Size = new Size(171, 34);
            btnSecVeBasla.TabIndex = 3;
            btnSecVeBasla.Text = "Seç ve Başla";
            // 
            // btnIptalCikis
            // 
            btnIptalCikis.Appearance.Font = new Font("Tahoma", 9F);
            btnIptalCikis.Appearance.Options.UseFont = true;
            btnIptalCikis.ImageOptions.SvgImage = Properties.Resources.clearheaderandfooter;
            btnIptalCikis.Location = new Point(17, 122);
            btnIptalCikis.Margin = new Padding(3, 2, 3, 2);
            btnIptalCikis.Name = "btnIptalCikis";
            btnIptalCikis.Size = new Size(129, 34);
            btnIptalCikis.TabIndex = 4;
            btnIptalCikis.Text = "İptal / Çıkış";
            // 
            // SubeSecimForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 167);
            Controls.Add(btnIptalCikis);
            Controls.Add(btnSecVeBasla);
            Controls.Add(chkHatirla);
            Controls.Add(cmbSubeler);
            Controls.Add(lblMesaj);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SubeSecimForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şube / Fabrika Seçimi";
            ((System.ComponentModel.ISupportInitialize)cmbSubeler.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkHatirla.Properties).EndInit();
            ResumeLayout(false);

        }

        private DevExpress.XtraEditors.LabelControl lblMesaj;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbSubeler;
        private DevExpress.XtraEditors.CheckEdit chkHatirla;
        private DevExpress.XtraEditors.SimpleButton btnSecVeBasla;
        private DevExpress.XtraEditors.SimpleButton btnIptalCikis;
    }
}
