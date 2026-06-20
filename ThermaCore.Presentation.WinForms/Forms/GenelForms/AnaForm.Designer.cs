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
            btnTanimlar = new ToolStripMenuItem();
            btnCariTanim = new ToolStripMenuItem();
            btnMusteriCariKartlar = new ToolStripMenuItem();
            btnParametre = new ToolStripMenuItem();
            btnProgramHakkinda = new ToolStripMenuItem();
            btnKodYonetimi = new ToolStripMenuItem();
            btnKodSayaclari = new ToolStripMenuItem();
            btnLayoutSifirla = new ToolStripMenuItem();
            btnAktifKullanicilar = new ToolStripMenuItem();
            btnTemalar = new ToolStripMenuItem();
            btnProgramGuncelle = new ToolStripMenuItem();
            sistemYönetimiToolStripMenuItem = new ToolStripMenuItem();
            kurumsalTanımlarToolStripMenuItem = new ToolStripMenuItem();
            miSirketTanimlari = new ToolStripMenuItem();
            depoTanımlarıToolStripMenuItem = new ToolStripMenuItem();
            güvenlikVeYetkilendirmeToolStripMenuItem = new ToolStripMenuItem();
            kullanıcıTanımlarıToolStripMenuItem = new ToolStripMenuItem();
            miYetkiGruplariRoller = new ToolStripMenuItem();
            terminalCihazYönetimiToolStripMenuItem = new ToolStripMenuItem();
            parametrelerToolStripMenuItem = new ToolStripMenuItem();
            genelSistemParametreleriToolStripMenuItem = new ToolStripMenuItem();
            kullanıcıParametreleriToolStripMenuItem = new ToolStripMenuItem();
            xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(components);
            timerDoviz = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            txtDovizBilgisi = new ToolStripMenuItem();
            txtAylikMetreVerileri = new ToolStripMenuItem();
            btnAnaFormResim = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyPictureEdit();
            miCodeTemplatelari = new ToolStripMenuItem();
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
            menuStrip.Items.AddRange(new ToolStripItem[] { btnTanimlar, btnParametre, sistemYönetimiToolStripMenuItem });
            menuStrip.Location = new Point(0, 28);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 1, 0, 1);
            menuStrip.Size = new Size(1248, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // btnTanimlar
            // 
            btnTanimlar.DropDownItems.AddRange(new ToolStripItem[] { btnCariTanim });
            btnTanimlar.Name = "btnTanimlar";
            btnTanimlar.Size = new Size(69, 22);
            btnTanimlar.Text = "Tanımlar";
            // 
            // btnCariTanim
            // 
            btnCariTanim.DropDownItems.AddRange(new ToolStripItem[] { btnMusteriCariKartlar });
            btnCariTanim.Name = "btnCariTanim";
            btnCariTanim.Size = new Size(137, 22);
            btnCariTanim.Text = "Cari Tanım";
            // 
            // btnMusteriCariKartlar
            // 
            btnMusteriCariKartlar.Name = "btnMusteriCariKartlar";
            btnMusteriCariKartlar.Size = new Size(203, 22);
            btnMusteriCariKartlar.Text = "Müşteri Cari Tanımları";
            btnMusteriCariKartlar.Click += BtnMusteriCariKartlar_Click;
            // 
            // btnParametre
            // 
            btnParametre.DropDownItems.AddRange(new ToolStripItem[] { btnProgramHakkinda, btnKodYonetimi, btnKodSayaclari, btnLayoutSifirla, btnAktifKullanicilar, btnTemalar, btnProgramGuncelle });
            btnParametre.Name = "btnParametre";
            btnParametre.Size = new Size(80, 22);
            btnParametre.Text = "Parametre";
            // 
            // btnProgramHakkinda
            // 
            btnProgramHakkinda.Name = "btnProgramHakkinda";
            btnProgramHakkinda.Size = new Size(184, 22);
            btnProgramHakkinda.Text = "Program Hakkında";
            // 
            // btnKodYonetimi
            // 
            btnKodYonetimi.Name = "btnKodYonetimi";
            btnKodYonetimi.Size = new Size(184, 22);
            btnKodYonetimi.Text = "Kod Şablonları";
            // 
            // btnKodSayaclari
            // 
            btnKodSayaclari.Name = "btnKodSayaclari";
            btnKodSayaclari.Size = new Size(184, 22);
            btnKodSayaclari.Text = "Kod Sayaçları";
            // 
            // btnLayoutSifirla
            // 
            btnLayoutSifirla.Name = "btnLayoutSifirla";
            btnLayoutSifirla.Size = new Size(184, 22);
            btnLayoutSifirla.Text = "Layout Sıfırla";
            // 
            // btnAktifKullanicilar
            // 
            btnAktifKullanicilar.Name = "btnAktifKullanicilar";
            btnAktifKullanicilar.Size = new Size(184, 22);
            btnAktifKullanicilar.Text = "Aktif Kullanıcılar";
            // 
            // btnTemalar
            // 
            btnTemalar.Name = "btnTemalar";
            btnTemalar.Size = new Size(184, 22);
            btnTemalar.Text = "Temalar";
            // 
            // btnProgramGuncelle
            // 
            btnProgramGuncelle.Name = "btnProgramGuncelle";
            btnProgramGuncelle.Size = new Size(184, 22);
            btnProgramGuncelle.Text = "Programı Güncelle";
            btnProgramGuncelle.Click += BtnProgramGuncelle_Click;
            // 
            // sistemYönetimiToolStripMenuItem
            // 
            sistemYönetimiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kurumsalTanımlarToolStripMenuItem, güvenlikVeYetkilendirmeToolStripMenuItem, parametrelerToolStripMenuItem });
            sistemYönetimiToolStripMenuItem.Name = "sistemYönetimiToolStripMenuItem";
            sistemYönetimiToolStripMenuItem.Size = new Size(111, 22);
            sistemYönetimiToolStripMenuItem.Text = "Sistem Yönetimi";
            // 
            // kurumsalTanımlarToolStripMenuItem
            // 
            kurumsalTanımlarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miSirketTanimlari, depoTanımlarıToolStripMenuItem });
            kurumsalTanımlarToolStripMenuItem.Name = "kurumsalTanımlarToolStripMenuItem";
            kurumsalTanımlarToolStripMenuItem.Size = new Size(222, 22);
            kurumsalTanımlarToolStripMenuItem.Text = "Kurumsal Tanımlar";
            // 
            // miSirketTanimlari
            // 
            miSirketTanimlari.Name = "miSirketTanimlari";
            miSirketTanimlari.Size = new Size(180, 22);
            miSirketTanimlari.Text = "Şirket Tanımları";
            // 
            // depoTanımlarıToolStripMenuItem
            // 
            depoTanımlarıToolStripMenuItem.Name = "depoTanımlarıToolStripMenuItem";
            depoTanımlarıToolStripMenuItem.Size = new Size(180, 22);
            depoTanımlarıToolStripMenuItem.Text = "Depo Tanımları";
            // 
            // güvenlikVeYetkilendirmeToolStripMenuItem
            // 
            güvenlikVeYetkilendirmeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kullanıcıTanımlarıToolStripMenuItem, miYetkiGruplariRoller, terminalCihazYönetimiToolStripMenuItem });
            güvenlikVeYetkilendirmeToolStripMenuItem.Name = "güvenlikVeYetkilendirmeToolStripMenuItem";
            güvenlikVeYetkilendirmeToolStripMenuItem.Size = new Size(222, 22);
            güvenlikVeYetkilendirmeToolStripMenuItem.Text = "Güvenlik ve Yetkilendirme";
            // 
            // kullanıcıTanımlarıToolStripMenuItem
            // 
            kullanıcıTanımlarıToolStripMenuItem.Name = "kullanıcıTanımlarıToolStripMenuItem";
            kullanıcıTanımlarıToolStripMenuItem.Size = new Size(221, 22);
            kullanıcıTanımlarıToolStripMenuItem.Text = "Kullanıcı Tanımları";
            // 
            // miYetkiGruplariRoller
            // 
            miYetkiGruplariRoller.Name = "miYetkiGruplariRoller";
            miYetkiGruplariRoller.Size = new Size(221, 22);
            miYetkiGruplariRoller.Text = "Yetki Grupları (Roller)";
            // 
            // terminalCihazYönetimiToolStripMenuItem
            // 
            terminalCihazYönetimiToolStripMenuItem.Name = "terminalCihazYönetimiToolStripMenuItem";
            terminalCihazYönetimiToolStripMenuItem.Size = new Size(221, 22);
            terminalCihazYönetimiToolStripMenuItem.Text = "Terminal (Cihaz) Yönetimi";
            // 
            // parametrelerToolStripMenuItem
            // 
            parametrelerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { genelSistemParametreleriToolStripMenuItem, kullanıcıParametreleriToolStripMenuItem, miCodeTemplatelari });
            parametrelerToolStripMenuItem.Name = "parametrelerToolStripMenuItem";
            parametrelerToolStripMenuItem.Size = new Size(222, 22);
            parametrelerToolStripMenuItem.Text = "Parametreler";
            // 
            // genelSistemParametreleriToolStripMenuItem
            // 
            genelSistemParametreleriToolStripMenuItem.Name = "genelSistemParametreleriToolStripMenuItem";
            genelSistemParametreleriToolStripMenuItem.Size = new Size(233, 22);
            genelSistemParametreleriToolStripMenuItem.Text = "Genel Sistem Parametreleri";
            // 
            // kullanıcıParametreleriToolStripMenuItem
            // 
            kullanıcıParametreleriToolStripMenuItem.Name = "kullanıcıParametreleriToolStripMenuItem";
            kullanıcıParametreleriToolStripMenuItem.Size = new Size(233, 22);
            kullanıcıParametreleriToolStripMenuItem.Text = "Kullanıcı Parametreleri";
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { txtDovizBilgisi, txtAylikMetreVerileri });
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
            // txtAylikMetreVerileri
            // 
            txtAylikMetreVerileri.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            txtAylikMetreVerileri.ForeColor = Color.Yellow;
            txtAylikMetreVerileri.Name = "txtAylikMetreVerileri";
            txtAylikMetreVerileri.Size = new Size(190, 24);
            txtAylikMetreVerileri.Text = "Aylık Veriler Getiriliyor...";
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
            // miCodeTemplatelari
            // 
            miCodeTemplatelari.Name = "miCodeTemplatelari";
            miCodeTemplatelari.Size = new Size(233, 22);
            miCodeTemplatelari.Text = "Kod Şablonları";
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
        private System.Windows.Forms.ToolStripMenuItem btnParametre;
        private System.Windows.Forms.ToolStripMenuItem btnProgramHakkinda;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem txtDovizBilgisi;
        private System.Windows.Forms.ToolStripMenuItem txtAylikMetreVerileri;
        private System.Windows.Forms.ToolStripMenuItem btnKodYonetimi;
        private System.Windows.Forms.ToolStripMenuItem btnLayoutSifirla;
        private System.Windows.Forms.ToolStripMenuItem btnAktifKullanicilar;
        private System.Windows.Forms.ToolStripMenuItem btnKodSayaclari;
        private System.Windows.Forms.ToolStripMenuItem btnTemalar;
        private System.Windows.Forms.ToolStripMenuItem btnProgramGuncelle;
        private ToolStripMenuItem btnTanimlar;
        private ToolStripMenuItem btnCariTanim;
        private ToolStripMenuItem btnMusteriCariKartlar;
        private UserControls.Controls.MyPictureEdit btnAnaFormResim;
        private ToolStripMenuItem sistemYönetimiToolStripMenuItem;
        private ToolStripMenuItem kurumsalTanımlarToolStripMenuItem;
        private ToolStripMenuItem miSirketTanimlari;
        private ToolStripMenuItem depoTanımlarıToolStripMenuItem;
        private ToolStripMenuItem güvenlikVeYetkilendirmeToolStripMenuItem;
        private ToolStripMenuItem kullanıcıTanımlarıToolStripMenuItem;
        private ToolStripMenuItem miYetkiGruplariRoller;
        private ToolStripMenuItem terminalCihazYönetimiToolStripMenuItem;
        private ToolStripMenuItem parametrelerToolStripMenuItem;
        private ToolStripMenuItem genelSistemParametreleriToolStripMenuItem;
        private ToolStripMenuItem kullanıcıParametreleriToolStripMenuItem;
        private ToolStripMenuItem miCodeTemplatelari;
    }
}
