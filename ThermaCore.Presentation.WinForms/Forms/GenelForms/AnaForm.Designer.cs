namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
{
    partial class AnaForm
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
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            miTanimlar = new ToolStripMenuItem();
            miSistemYonetimi = new ToolStripMenuItem();
            miKurumsalTanimlar = new ToolStripMenuItem();
            miSirketTanimlari = new ToolStripMenuItem();
            miGuvenlikVeYetkilendirme = new ToolStripMenuItem();
            miKullaniciTanimlari = new ToolStripMenuItem();
            miYetkiGruplariRoller = new ToolStripMenuItem();
            miTerminalYonetim = new ToolStripMenuItem();
            miParametreler = new ToolStripMenuItem();
            miGenelSistemParametreleri = new ToolStripMenuItem();
            miKullaniciArayuzSablonlari = new ToolStripMenuItem();
            miCodeTemplatelari = new ToolStripMenuItem();
            miEmailParameter = new ToolStripMenuItem();
            miSystemLicense = new ToolStripMenuItem();
            xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(components);
            timerDoviz = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            txtDovizBilgisi = new ToolStripMenuItem();
            btnAnaFormResim = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyPictureEdit();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)xtraTabbedMdiManager).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnAnaFormResim.Properties).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Gainsboro;
            menuStrip.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            menuStrip.Items.AddRange(new ToolStripItem[] { miTanimlar, miSistemYonetimi });
            menuStrip.Location = new Point(0, 28);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 1, 0, 1);
            menuStrip.Size = new Size(1248, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // miTanimlar
            // 
            miTanimlar.Name = "miTanimlar";
            miTanimlar.Size = new Size(69, 22);
            miTanimlar.Text = "Tanımlar";
            // 
            // miSistemYonetimi
            // 
            miSistemYonetimi.DropDownItems.AddRange(new ToolStripItem[] { miKurumsalTanimlar, miGuvenlikVeYetkilendirme, miParametreler });
            miSistemYonetimi.Name = "miSistemYonetimi";
            miSistemYonetimi.Size = new Size(111, 22);
            miSistemYonetimi.Tag = "SistemYonetimi";
            miSistemYonetimi.Text = "Sistem Yönetimi";
            // 
            // miKurumsalTanimlar
            // 
            miKurumsalTanimlar.DropDownItems.AddRange(new ToolStripItem[] { miSirketTanimlari });
            miKurumsalTanimlar.Name = "miKurumsalTanimlar";
            miKurumsalTanimlar.Size = new Size(222, 22);
            miKurumsalTanimlar.Tag = "KurumsalTanimlar";
            miKurumsalTanimlar.Text = "Kurumsal Tanımlar";
            // 
            // miSirketTanimlari
            // 
            miSirketTanimlari.Name = "miSirketTanimlari";
            miSirketTanimlari.Size = new Size(164, 22);
            miSirketTanimlari.Tag = "SirketTanimlari";
            miSirketTanimlari.Text = "Şirket Tanımları";
            // 
            // miGuvenlikVeYetkilendirme
            // 
            miGuvenlikVeYetkilendirme.DropDownItems.AddRange(new ToolStripItem[] { miKullaniciTanimlari, miYetkiGruplariRoller, miTerminalYonetim });
            miGuvenlikVeYetkilendirme.Name = "miGuvenlikVeYetkilendirme";
            miGuvenlikVeYetkilendirme.Size = new Size(222, 22);
            miGuvenlikVeYetkilendirme.Tag = "GuvenlikVeYetkilendirme";
            miGuvenlikVeYetkilendirme.Text = "Güvenlik ve Yetkilendirme";
            // 
            // miKullaniciTanimlari
            // 
            miKullaniciTanimlari.Name = "miKullaniciTanimlari";
            miKullaniciTanimlari.Size = new Size(221, 22);
            miKullaniciTanimlari.Tag = " User";
            miKullaniciTanimlari.Text = "Kullanıcı Tanımları";
            // 
            // miYetkiGruplariRoller
            // 
            miYetkiGruplariRoller.Name = "miYetkiGruplariRoller";
            miYetkiGruplariRoller.Size = new Size(221, 22);
            miYetkiGruplariRoller.Tag = "YetkiGruplari";
            miYetkiGruplariRoller.Text = "Yetki Grupları (Roller)";
            // 
            // miTerminalYonetim
            // 
            miTerminalYonetim.Name = "miTerminalYonetim";
            miTerminalYonetim.Size = new Size(221, 22);
            miTerminalYonetim.Tag = "TerminalYonetimi";
            miTerminalYonetim.Text = "Terminal (Cihaz) Yönetimi";
            // 
            // miParametreler
            // 
            miParametreler.DropDownItems.AddRange(new ToolStripItem[] { miGenelSistemParametreleri, miKullaniciArayuzSablonlari, miCodeTemplatelari, miEmailParameter, miSystemLicense });
            miParametreler.Name = "miParametreler";
            miParametreler.Size = new Size(222, 22);
            miParametreler.Tag = "Parametreler";
            miParametreler.Text = "Parametreler";
            // 
            // miGenelSistemParametreleri
            // 
            miGenelSistemParametreleri.Name = "miGenelSistemParametreleri";
            miGenelSistemParametreleri.Size = new Size(233, 22);
            miGenelSistemParametreleri.Text = "Genel Sistem Parametreleri";
            // 
            // miKullaniciArayuzSablonlari
            // 
            miKullaniciArayuzSablonlari.Name = "miKullaniciArayuzSablonlari";
            miKullaniciArayuzSablonlari.Size = new Size(233, 22);
            miKullaniciArayuzSablonlari.Tag = "UserInterfaceTemplate";
            miKullaniciArayuzSablonlari.Text = "Kullanıcı Arayüz Şablonları";
            // 
            // miCodeTemplatelari
            // 
            miCodeTemplatelari.Name = "miCodeTemplatelari";
            miCodeTemplatelari.Size = new Size(233, 22);
            miCodeTemplatelari.Tag = "CodeTemplateYonetimi";
            miCodeTemplatelari.Text = "Kod Şablonları";
            // 
            // miEmailParameter
            // 
            miEmailParameter.Name = "miEmailParameter";
            miEmailParameter.Size = new Size(233, 22);
            miEmailParameter.Tag = "EmailParameter";
            miEmailParameter.Text = "E-Mail Parametreleri";
            // 
            // miSystemLicense
            // 
            miSystemLicense.Name = "miSystemLicense";
            miSystemLicense.Size = new Size(233, 22);
            miSystemLicense.Tag = "SystemLicense";
            miSystemLicense.Text = "Sistem Lisansı";
            // 
            // xtraTabbedMdiManager
            // 
            xtraTabbedMdiManager.MdiParent = this;
            // 
            // timerDoviz
            // 
            timerDoviz.Interval = 30000;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(0, 125, 125);
            menuStrip1.Items.AddRange(new ToolStripItem[] { txtDovizBilgisi });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1248, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // txtDovizBilgisi
            // 
            txtDovizBilgisi.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            txtDovizBilgisi.ForeColor = Color.Yellow;
            txtDovizBilgisi.Name = "txtDovizBilgisi";
            txtDovizBilgisi.Size = new Size(304, 24);
            txtDovizBilgisi.Text = "Merkez Bankası Döviz Bilgisi Getiriliyor...";
            // 
            // btnAnaFormResim
            // 
            btnAnaFormResim.Dock = DockStyle.Fill;
            btnAnaFormResim.EditValue = Properties.Resources.thermacorearkaplan;
            btnAnaFormResim.EnterMoveNextControl = true;
            btnAnaFormResim.Location = new Point(0, 0);
            btnAnaFormResim.Name = "btnAnaFormResim";
            btnAnaFormResim.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            btnAnaFormResim.Properties.Appearance.Options.UseFont = true;
            btnAnaFormResim.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnAnaFormResim.Properties.AppearanceDisabled.Options.UseFont = true;
            btnAnaFormResim.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            btnAnaFormResim.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            btnAnaFormResim.Properties.AppearanceFocused.Options.UseBackColor = true;
            btnAnaFormResim.Properties.AppearanceFocused.Options.UseFont = true;
            btnAnaFormResim.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            btnAnaFormResim.Properties.AppearanceReadOnly.Options.UseFont = true;
            btnAnaFormResim.Properties.NullText = "Resim Yok";
            btnAnaFormResim.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            btnAnaFormResim.Properties.ShowMenu = false;
            btnAnaFormResim.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            btnAnaFormResim.Size = new Size(1248, 698);
            btnAnaFormResim.StatusBarAciklama = null;
            btnAnaFormResim.StatusBarKisaYol = "F4 :";
            btnAnaFormResim.StatusBarKisaYolAciklama = null;
            btnAnaFormResim.TabIndex = 3;
            // 
            // AnaForm
            // 
            Appearance.BackColor = SystemColors.Control;
            Appearance.Options.UseBackColor = true;
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 698);
            Controls.Add(menuStrip);
            Controls.Add(menuStrip1);
            Controls.Add(btnAnaFormResim);
            Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IconOptions.ShowIcon = false;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Margin = new Padding(4);
            Name = "AnaForm";
            Text = "ThermaCore";
            WindowState = FormWindowState.Maximized;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)xtraTabbedMdiManager).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnAnaFormResim.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private System.Windows.Forms.Timer timerDoviz;
        private System.Windows.Forms.ToolStripMenuItem btnProgramHakkinda;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem txtDovizBilgisi;
        private System.Windows.Forms.ToolStripMenuItem btnKodYonetimi;
        private System.Windows.Forms.ToolStripMenuItem btnKodSayaclari;
        private ToolStripMenuItem miTanimlar;
        private ToolStripMenuItem btnCariTanim;
        private ToolStripMenuItem btnMusteriCariKartlar;
        private UserControls.Controls.MyPictureEdit btnAnaFormResim;
        private ToolStripMenuItem miSistemYonetimi;
        private ToolStripMenuItem miKurumsalTanimlar;
        private ToolStripMenuItem miSirketTanimlari;
        private ToolStripMenuItem depoTanımlarıToolStripMenuItem;
        private ToolStripMenuItem miGuvenlikVeYetkilendirme;
        private ToolStripMenuItem miKullaniciTanimlari;
        private ToolStripMenuItem miYetkiGruplariRoller;
        private ToolStripMenuItem miTerminalYonetim;
        private ToolStripMenuItem miParametreler;
        private ToolStripMenuItem miGenelSistemParametreleri;
        private ToolStripMenuItem miKullaniciArayuzSablonlari;
        private ToolStripMenuItem miCodeTemplatelari;
        private ToolStripMenuItem miEmailParameter;
        private ToolStripMenuItem miSystemLicense;
    }
}
