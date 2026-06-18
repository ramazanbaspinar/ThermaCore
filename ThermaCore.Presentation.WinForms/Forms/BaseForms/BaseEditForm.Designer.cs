namespace ThermaCore.Presentation.WinForms.Forms.BaseForms
{
    partial class BaseEditForm
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
            ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            btnYeni = new DevExpress.XtraBars.BarButtonItem();
            btnKaydet = new DevExpress.XtraBars.BarButtonItem();
            btnGerial = new DevExpress.XtraBars.BarButtonItem();
            btnYenile = new DevExpress.XtraBars.BarButtonItem();
            btnYazdir = new DevExpress.XtraBars.BarButtonItem();
            btnBaskiOnizle = new DevExpress.XtraBars.BarButtonItem();
            btnKapat = new DevExpress.XtraBars.BarButtonItem();
            btnSifreDegistir = new DevExpress.XtraBars.BarButtonItem();
            btnSil = new DevExpress.XtraBars.BarButtonItem();
            bsiYeni = new DevExpress.XtraBars.BarStaticItem();
            bsiYeniAciklama = new DevExpress.XtraBars.BarStaticItem();
            bsiKaydet = new DevExpress.XtraBars.BarStaticItem();
            bsiKaydetAciklama = new DevExpress.XtraBars.BarStaticItem();
            bsiYenile = new DevExpress.XtraBars.BarStaticItem();
            bsiYenileAciklama = new DevExpress.XtraBars.BarStaticItem();
            bsiGerial = new DevExpress.XtraBars.BarStaticItem();
            bsiGerialAciklama = new DevExpress.XtraBars.BarStaticItem();
            bsiSil = new DevExpress.XtraBars.BarStaticItem();
            bsiSilAciklama = new DevExpress.XtraBars.BarStaticItem();
            bsiKapat = new DevExpress.XtraBars.BarStaticItem();
            bsiKapatAciklama = new DevExpress.XtraBars.BarStaticItem();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            ribbon.DrawGroupsBorderMode = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, btnYeni, btnKaydet, btnGerial, btnYenile, btnYazdir, btnBaskiOnizle, btnKapat, btnSifreDegistir, btnSil, bsiYeni, bsiYeniAciklama, bsiKaydet, bsiKaydetAciklama, bsiYenile, bsiYenileAciklama, bsiGerial, bsiGerialAciklama, bsiSil, bsiSilAciklama, bsiKapat, bsiKapatAciklama });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 22;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            ribbon.ShowQatLocationSelector = false;
            ribbon.ShowToolbarCustomizeItem = false;
            ribbon.Size = new Size(609, 135);
            ribbon.StatusBar = ribbonStatusBar;
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnYeni
            // 
            btnYeni.Caption = "Yeni";
            btnYeni.Id = 1;
            btnYeni.ImageOptions.SvgImage = Properties.Resources._new;
            btnYeni.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Insert);
            btnYeni.Name = "btnYeni";
            // 
            // btnKaydet
            // 
            btnKaydet.Caption = "Kaydet";
            btnKaydet.Id = 2;
            btnKaydet.ImageOptions.SvgImage = Properties.Resources.save;
            btnKaydet.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.S);
            btnKaydet.Name = "btnKaydet";
            // 
            // btnGerial
            // 
            btnGerial.Caption = "Gerial";
            btnGerial.Id = 3;
            btnGerial.ImageOptions.SvgImage = Properties.Resources.undo;
            btnGerial.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.Z);
            btnGerial.Name = "btnGerial";
            // 
            // btnYenile
            // 
            btnYenile.Caption = "Yenile";
            btnYenile.Id = 4;
            btnYenile.ImageOptions.SvgImage = Properties.Resources.convertto;
            btnYenile.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.F5);
            btnYenile.Name = "btnYenile";
            btnYenile.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnYazdir
            // 
            btnYazdir.Caption = "Yazdır";
            btnYazdir.Id = 5;
            btnYazdir.ImageOptions.SvgImage = Properties.Resources.print;
            btnYazdir.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.P);
            btnYazdir.Name = "btnYazdir";
            btnYazdir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnBaskiOnizle
            // 
            btnBaskiOnizle.Caption = "Baskı Önizle";
            btnBaskiOnizle.Id = 6;
            btnBaskiOnizle.ImageOptions.SvgImage = Properties.Resources.showprintpreview;
            btnBaskiOnizle.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.Shift | Keys.P);
            btnBaskiOnizle.Name = "btnBaskiOnizle";
            btnBaskiOnizle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnKapat
            // 
            btnKapat.Caption = "Kapat";
            btnKapat.Id = 7;
            btnKapat.ImageOptions.SvgImage = Properties.Resources.clearheaderandfooter;
            btnKapat.Name = "btnKapat";
            btnKapat.ShortcutKeyDisplayString = "Esc";
            // 
            // btnSifreDegistir
            // 
            btnSifreDegistir.Caption = "Şifre Değiştir";
            btnSifreDegistir.Id = 8;
            btnSifreDegistir.ImageOptions.SvgImage = Properties.Resources.bo_user;
            btnSifreDegistir.Name = "btnSifreDegistir";
            btnSifreDegistir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnSil
            // 
            btnSil.Caption = "Sil";
            btnSil.Id = 9;
            btnSil.ImageOptions.SvgImage = Properties.Resources.snapdeletelist;
            btnSil.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Delete);
            btnSil.Name = "btnSil";
            // 
            // bsiYeni
            // 
            bsiYeni.Caption = "Insert :";
            bsiYeni.Id = 10;
            bsiYeni.ItemAppearance.Normal.ForeColor = Color.DarkBlue;
            bsiYeni.ItemAppearance.Normal.Options.UseForeColor = true;
            bsiYeni.Name = "bsiYeni";
            bsiYeni.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiYeniAciklama
            // 
            bsiYeniAciklama.Caption = "Yeni";
            bsiYeniAciklama.Id = 11;
            bsiYeniAciklama.Name = "bsiYeniAciklama";
            bsiYeniAciklama.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiKaydet
            // 
            bsiKaydet.Caption = "Ctrl+S :";
            bsiKaydet.Id = 12;
            bsiKaydet.ItemAppearance.Normal.ForeColor = Color.DarkBlue;
            bsiKaydet.ItemAppearance.Normal.Options.UseForeColor = true;
            bsiKaydet.Name = "bsiKaydet";
            bsiKaydet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiKaydetAciklama
            // 
            bsiKaydetAciklama.Caption = "Kaydet";
            bsiKaydetAciklama.Id = 13;
            bsiKaydetAciklama.Name = "bsiKaydetAciklama";
            bsiKaydetAciklama.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiYenile
            // 
            bsiYenile.Caption = "F5 :";
            bsiYenile.Id = 14;
            bsiYenile.ItemAppearance.Normal.ForeColor = Color.DarkBlue;
            bsiYenile.ItemAppearance.Normal.Options.UseForeColor = true;
            bsiYenile.Name = "bsiYenile";
            bsiYenile.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiYenileAciklama
            // 
            bsiYenileAciklama.Caption = "Yenile";
            bsiYenileAciklama.Id = 15;
            bsiYenileAciklama.Name = "bsiYenileAciklama";
            bsiYenileAciklama.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiGerial
            // 
            bsiGerial.Caption = "Ctrl+Z :";
            bsiGerial.Id = 16;
            bsiGerial.ItemAppearance.Normal.ForeColor = Color.DarkBlue;
            bsiGerial.ItemAppearance.Normal.Options.UseForeColor = true;
            bsiGerial.Name = "bsiGerial";
            bsiGerial.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiGerialAciklama
            // 
            bsiGerialAciklama.Caption = "Gerial";
            bsiGerialAciklama.Id = 17;
            bsiGerialAciklama.Name = "bsiGerialAciklama";
            bsiGerialAciklama.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiSil
            // 
            bsiSil.Caption = "Delete :";
            bsiSil.Id = 18;
            bsiSil.ItemAppearance.Normal.ForeColor = Color.DarkBlue;
            bsiSil.ItemAppearance.Normal.Options.UseForeColor = true;
            bsiSil.Name = "bsiSil";
            bsiSil.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiSilAciklama
            // 
            bsiSilAciklama.Caption = "Sil";
            bsiSilAciklama.Id = 19;
            bsiSilAciklama.Name = "bsiSilAciklama";
            bsiSilAciklama.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiKapat
            // 
            bsiKapat.Caption = "Esc :";
            bsiKapat.Id = 20;
            bsiKapat.ItemAppearance.Normal.ForeColor = Color.DarkBlue;
            bsiKapat.ItemAppearance.Normal.Options.UseForeColor = true;
            bsiKapat.Name = "bsiKapat";
            bsiKapat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bsiKapatAciklama
            // 
            bsiKapatAciklama.Caption = "Kapat";
            bsiKapatAciklama.Id = 21;
            bsiKapatAciklama.Name = "bsiKapatAciklama";
            bsiKapatAciklama.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.ItemLinks.Add(btnYeni);
            ribbonPageGroup1.ItemLinks.Add(btnKaydet);
            ribbonPageGroup1.ItemLinks.Add(btnYenile);
            ribbonPageGroup1.ItemLinks.Add(btnGerial);
            ribbonPageGroup1.ItemLinks.Add(btnSil);
            ribbonPageGroup1.ItemLinks.Add(btnYazdir);
            ribbonPageGroup1.ItemLinks.Add(btnBaskiOnizle);
            ribbonPageGroup1.ItemLinks.Add(btnSifreDegistir);
            ribbonPageGroup1.ItemLinks.Add(btnKapat);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.ItemLinks.Add(bsiYeni);
            ribbonStatusBar.ItemLinks.Add(bsiYeniAciklama);
            ribbonStatusBar.ItemLinks.Add(bsiKaydet, true);
            ribbonStatusBar.ItemLinks.Add(bsiKaydetAciklama);
            ribbonStatusBar.ItemLinks.Add(bsiYenile, true);
            ribbonStatusBar.ItemLinks.Add(bsiYenileAciklama);
            ribbonStatusBar.ItemLinks.Add(bsiGerial, true);
            ribbonStatusBar.ItemLinks.Add(bsiGerialAciklama);
            ribbonStatusBar.ItemLinks.Add(bsiSil, true);
            ribbonStatusBar.ItemLinks.Add(bsiSilAciklama);
            ribbonStatusBar.ItemLinks.Add(bsiKapat, true);
            ribbonStatusBar.ItemLinks.Add(bsiKapatAciklama);
            ribbonStatusBar.Location = new Point(0, 378);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(609, 24);
            // 
            // BaseEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 402);
            Controls.Add(ribbon);
            Controls.Add(ribbonStatusBar);
            IconOptions.ShowIcon = false;
            MinimizeBox = false;
            Name = "BaseEditForm";
            Ribbon = ribbon;
            ShowInTaskbar = false;
            StatusBar = ribbonStatusBar;
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        protected DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        protected DevExpress.XtraBars.BarButtonItem btnYeni;
        protected DevExpress.XtraBars.BarButtonItem btnKaydet;
        protected DevExpress.XtraBars.BarButtonItem btnGerial;
        protected DevExpress.XtraBars.BarButtonItem btnYenile;
        protected DevExpress.XtraBars.BarButtonItem btnYazdir;
        protected DevExpress.XtraBars.BarButtonItem btnBaskiOnizle;
        protected DevExpress.XtraBars.BarButtonItem btnKapat;
        protected DevExpress.XtraBars.BarButtonItem btnSifreDegistir;
        protected DevExpress.XtraBars.BarButtonItem btnSil;
        private DevExpress.XtraBars.BarStaticItem bsiYeni;
        private DevExpress.XtraBars.BarStaticItem bsiYeniAciklama;
        private DevExpress.XtraBars.BarStaticItem bsiKaydet;
        private DevExpress.XtraBars.BarStaticItem bsiKaydetAciklama;
        private DevExpress.XtraBars.BarStaticItem bsiYenile;
        private DevExpress.XtraBars.BarStaticItem bsiYenileAciklama;
        private DevExpress.XtraBars.BarStaticItem bsiGerial;
        private DevExpress.XtraBars.BarStaticItem bsiGerialAciklama;
        private DevExpress.XtraBars.BarStaticItem bsiSil;
        private DevExpress.XtraBars.BarStaticItem bsiSilAciklama;
        private DevExpress.XtraBars.BarStaticItem bsiKapat;
        private DevExpress.XtraBars.BarStaticItem bsiKapatAciklama;
    }
}