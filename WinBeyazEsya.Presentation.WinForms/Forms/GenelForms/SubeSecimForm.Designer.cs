namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
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
            chkVarsayilanYap = new DevExpress.XtraEditors.CheckEdit();
            chkAcilistaSor = new DevExpress.XtraEditors.CheckEdit();
            btnSecVeBasla = new DevExpress.XtraEditors.SimpleButton();
            btnIptalCikis = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)cmbSubeler.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkVarsayilanYap.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkAcilistaSor.Properties).BeginInit();
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
            // chkVarsayilanYap
            // 
            chkVarsayilanYap.Location = new Point(17, 89);
            chkVarsayilanYap.Margin = new Padding(3, 2, 3, 2);
            chkVarsayilanYap.Name = "chkVarsayilanYap";
            chkVarsayilanYap.Properties.Appearance.Font = new Font("Tahoma", 9F);
            chkVarsayilanYap.Properties.Appearance.Options.UseFont = true;
            chkVarsayilanYap.Properties.Caption = "Varsayılan olarak belirle";
            chkVarsayilanYap.Size = new Size(309, 20);
            chkVarsayilanYap.TabIndex = 2;
            chkVarsayilanYap.Visible = true;
            // 
            // chkAcilistaSor
            // 
            chkAcilistaSor.Location = new Point(17, 114);
            chkAcilistaSor.Margin = new Padding(3, 2, 3, 2);
            chkAcilistaSor.Name = "chkAcilistaSor";
            chkAcilistaSor.Properties.Appearance.Font = new Font("Tahoma", 9F);
            chkAcilistaSor.Properties.Appearance.Options.UseFont = true;
            chkAcilistaSor.Properties.Caption = "Açılışta tekrar sor (Formu göster)";
            chkAcilistaSor.Size = new Size(309, 20);
            chkAcilistaSor.TabIndex = 3;
            // 
            // btnSecVeBasla
            // 
            btnSecVeBasla.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnSecVeBasla.Appearance.Options.UseFont = true;
            btnSecVeBasla.ImageOptions.SvgImage = Properties.Resources.bo_validation;
            btnSecVeBasla.Location = new Point(154, 142);
            btnSecVeBasla.Margin = new Padding(3, 2, 3, 2);
            btnSecVeBasla.Name = "btnSecVeBasla";
            btnSecVeBasla.Size = new Size(171, 34);
            btnSecVeBasla.TabIndex = 4;
            btnSecVeBasla.Text = "Seç ve Başla";
            // 
            // btnIptalCikis
            // 
            btnIptalCikis.Appearance.Font = new Font("Tahoma", 9F);
            btnIptalCikis.Appearance.Options.UseFont = true;
            btnIptalCikis.ImageOptions.SvgImage = Properties.Resources.clearheaderandfooter;
            btnIptalCikis.Location = new Point(17, 142);
            btnIptalCikis.Margin = new Padding(3, 2, 3, 2);
            btnIptalCikis.Name = "btnIptalCikis";
            btnIptalCikis.Size = new Size(129, 34);
            btnIptalCikis.TabIndex = 5;
            btnIptalCikis.Text = "İptal / Çıkış";
            // 
            // SubeSecimForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 192);
            Controls.Add(btnIptalCikis);
            Controls.Add(btnSecVeBasla);
            Controls.Add(chkVarsayilanYap);
            Controls.Add(chkAcilistaSor);
            Controls.Add(cmbSubeler);
            Controls.Add(lblMesaj);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SubeSecimForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şube / Fabrika Seçimi";
            ((System.ComponentModel.ISupportInitialize)cmbSubeler.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkVarsayilanYap.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkAcilistaSor.Properties).EndInit();
            ResumeLayout(false);

        }

        private DevExpress.XtraEditors.LabelControl lblMesaj;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbSubeler;
        private DevExpress.XtraEditors.CheckEdit chkVarsayilanYap;
        private DevExpress.XtraEditors.CheckEdit chkAcilistaSor;
        private DevExpress.XtraEditors.SimpleButton btnSecVeBasla;
        private DevExpress.XtraEditors.SimpleButton btnIptalCikis;
    }
}

