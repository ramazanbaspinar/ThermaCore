namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
{
    partial class GirisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
            panel3 = new Panel();
            lblLisansKalanGun = new DevExpress.XtraEditors.LabelControl();
            lblVersiyon = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            linkSifremi = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyHyperlinkLabelControl();
            chcBeniHatirla = new DevExpress.XtraEditors.CheckEdit();
            picExit = new DevExpress.XtraEditors.PictureEdit();
            panel5 = new Panel();
            gluSirket = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyLookUpEdit();
            pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            btnGiris = new DevExpress.XtraEditors.SimpleButton();
            panel4 = new Panel();
            txtSifre = new DevExpress.XtraEditors.TextEdit();
            picPassword = new DevExpress.XtraEditors.PictureEdit();
            panel2 = new Panel();
            txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chcBeniHatirla.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picExit.Properties).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gluSirket.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit3.Properties).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtSifre.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPassword.Properties).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKullaniciAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.DodgerBlue;
            panel3.Controls.Add(lblLisansKalanGun);
            panel3.Controls.Add(lblVersiyon);
            panel3.Controls.Add(labelControl1);
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(127, 250);
            panel3.TabIndex = 2;
            // 
            // lblLisansKalanGun
            // 
            lblLisansKalanGun.Appearance.ForeColor = Color.White;
            lblLisansKalanGun.Appearance.Options.UseForeColor = true;
            lblLisansKalanGun.Location = new Point(4, 227);
            lblLisansKalanGun.Name = "lblLisansKalanGun";
            lblLisansKalanGun.Size = new Size(69, 13);
            lblLisansKalanGun.TabIndex = 14;
            lblLisansKalanGun.Text = "Lisans Durumu";
            // 
            // lblVersiyon
            // 
            lblVersiyon.Appearance.ForeColor = Color.White;
            lblVersiyon.Appearance.Options.UseForeColor = true;
            lblVersiyon.Location = new Point(4, 209);
            lblVersiyon.Name = "lblVersiyon";
            lblVersiyon.Size = new Size(105, 13);
            lblVersiyon.TabIndex = 12;
            lblVersiyon.Text = "Versiyon Yükleniyor...";
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new Font("Tahoma", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            labelControl1.Appearance.ForeColor = Color.White;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Appearance.Options.UseTextOptions = true;
            labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelControl1.Location = new Point(3, 60);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(124, 108);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "ThermaCore \r\n      ERP";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(linkSifremi);
            panel1.Controls.Add(chcBeniHatirla);
            panel1.Controls.Add(picExit);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(btnGiris);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(127, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(268, 250);
            panel1.TabIndex = 3;
            // 
            // linkSifremi
            // 
            linkSifremi.Cursor = Cursors.Hand;
            linkSifremi.LinkBehavior = LinkBehavior.NeverUnderline;
            linkSifremi.Location = new Point(6, 223);
            linkSifremi.Name = "linkSifremi";
            linkSifremi.Size = new Size(74, 13);
            linkSifremi.StatusBarAciklama = null;
            linkSifremi.TabIndex = 14;
            linkSifremi.Text = "şifremi unuttum";
            // 
            // chcBeniHatirla
            // 
            chcBeniHatirla.Location = new Point(6, 198);
            chcBeniHatirla.Name = "chcBeniHatirla";
            chcBeniHatirla.Properties.Caption = "Beni Hatırla";
            chcBeniHatirla.Size = new Size(75, 20);
            chcBeniHatirla.TabIndex = 0;
            // 
            // picExit
            // 
            picExit.EditValue = resources.GetObject("picExit.EditValue");
            picExit.Location = new Point(205, 10);
            picExit.Name = "picExit";
            picExit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            picExit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            picExit.Size = new Size(49, 44);
            picExit.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(gluSirket);
            panel5.Controls.Add(pictureEdit3);
            panel5.Location = new Point(1, 60);
            panel5.Name = "panel5";
            panel5.Size = new Size(263, 33);
            panel5.TabIndex = 5;
            // 
            // gluSirket
            // 
            gluSirket.EnterMoveNextControl = true;
            gluSirket.Location = new Point(32, 5);
            gluSirket.Name = "gluSirket";
            gluSirket.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            gluSirket.Properties.Appearance.Options.UseFont = true;
            gluSirket.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            gluSirket.Properties.AppearanceDisabled.Options.UseFont = true;
            gluSirket.Properties.AppearanceDropDown.Font = new Font("Segoe UI", 9F);
            gluSirket.Properties.AppearanceDropDown.Options.UseFont = true;
            gluSirket.Properties.AppearanceDropDownHeader.Font = new Font("Segoe UI", 9F);
            gluSirket.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            gluSirket.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            gluSirket.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            gluSirket.Properties.AppearanceFocused.Options.UseBackColor = true;
            gluSirket.Properties.AppearanceFocused.Options.UseFont = true;
            gluSirket.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            gluSirket.Properties.AppearanceReadOnly.Options.UseFont = true;
            gluSirket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            gluSirket.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Şirket Adı") });
            gluSirket.Properties.NullText = " ";
            gluSirket.Size = new Size(222, 22);
            gluSirket.StatusBarAciklama = null;
            gluSirket.StatusBarKisaYol = "F4 :";
            gluSirket.StatusBarKisaYolAciklama = null;
            gluSirket.TabIndex = 5;
            // 
            // pictureEdit3
            // 
            pictureEdit3.EditValue = resources.GetObject("pictureEdit3.EditValue");
            pictureEdit3.Location = new Point(3, 2);
            pictureEdit3.Name = "pictureEdit3";
            pictureEdit3.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit3.Size = new Size(24, 28);
            pictureEdit3.TabIndex = 4;
            // 
            // btnGiris
            // 
            btnGiris.Appearance.BackColor = Color.DodgerBlue;
            btnGiris.Appearance.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGiris.Appearance.Options.UseBackColor = true;
            btnGiris.Appearance.Options.UseFont = true;
            btnGiris.Location = new Point(179, 198);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(75, 24);
            btnGiris.TabIndex = 2;
            btnGiris.Text = "GİRİŞ";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtSifre);
            panel4.Controls.Add(picPassword);
            panel4.Location = new Point(1, 140);
            panel4.Name = "panel4";
            panel4.Size = new Size(264, 33);
            panel4.TabIndex = 1;
            // 
            // txtSifre
            // 
            txtSifre.EnterMoveNextControl = true;
            txtSifre.Location = new Point(31, 6);
            txtSifre.Name = "txtSifre";
            txtSifre.Properties.Appearance.ForeColor = Color.RoyalBlue;
            txtSifre.Properties.Appearance.Options.UseForeColor = true;
            txtSifre.Properties.UseSystemPasswordChar = true;
            txtSifre.Size = new Size(222, 20);
            txtSifre.TabIndex = 0;
            txtSifre.Tag = "Password";
            // 
            // picPassword
            // 
            picPassword.EditValue = resources.GetObject("picPassword.EditValue");
            picPassword.Location = new Point(2, 2);
            picPassword.Name = "picPassword";
            picPassword.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            picPassword.Size = new Size(23, 28);
            picPassword.TabIndex = 3;
            picPassword.MouseDown += picPassword_MouseDown;
            picPassword.MouseUp += picPassword_MouseUp;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtKullaniciAdi);
            panel2.Controls.Add(pictureEdit1);
            panel2.Location = new Point(1, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(263, 33);
            panel2.TabIndex = 0;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.EnterMoveNextControl = true;
            txtKullaniciAdi.Location = new Point(32, 6);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Properties.Appearance.ForeColor = Color.RoyalBlue;
            txtKullaniciAdi.Properties.Appearance.Options.UseForeColor = true;
            txtKullaniciAdi.Size = new Size(222, 20);
            txtKullaniciAdi.TabIndex = 0;
            // 
            // pictureEdit1
            // 
            pictureEdit1.EditValue = resources.GetObject("pictureEdit1.EditValue");
            pictureEdit1.Location = new Point(2, 3);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Size = new Size(24, 28);
            pictureEdit1.TabIndex = 2;
            // 
            // GirisForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(395, 250);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.None;
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(395, 250);
            Name = "GirisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            Activated += frmLogin_Activated;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chcBeniHatirla.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)picExit.Properties).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gluSirket.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit3.Properties).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtSifre.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPassword.Properties).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtKullaniciAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PictureEdit picPassword;
        private DevExpress.XtraEditors.TextEdit txtSifre;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.SimpleButton btnGiris;

        private System.Windows.Forms.Panel panel5;
        private DevExpress.XtraEditors.PictureEdit picExit;

        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private DevExpress.XtraEditors.CheckEdit chcBeniHatirla;
        private DevExpress.XtraEditors.LabelControl lblVersiyon;
        private ThermaCore.Presentation.WinForms.UserControls.Controls.MyHyperlinkLabelControl linkSifremi;
        private DevExpress.XtraEditors.LabelControl lblLisansKalanGun;
        private UserControls.Controls.MyLookUpEdit gluSirket;

    }
}