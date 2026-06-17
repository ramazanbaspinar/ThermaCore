namespace ThermaCore.Presentation.WinForms.Forms.BaseForms
{
    partial class BaseListForm
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
            btnSil = new DevExpress.XtraBars.BarButtonItem();
            btnSec = new DevExpress.XtraBars.BarButtonItem();
            btnDuzelt = new DevExpress.XtraBars.BarButtonItem();
            btnYenile = new DevExpress.XtraBars.BarButtonItem();
            btnKolonlar = new DevExpress.XtraBars.BarButtonItem();
            btnYazdir = new DevExpress.XtraBars.BarButtonItem();
            btnBaskiOnizle = new DevExpress.XtraBars.BarButtonItem();
            btnKapat = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            btnDisariAktar = new DevExpress.XtraBars.BarSubItem();
            btnExcelDosyalari = new DevExpress.XtraBars.BarSubItem();
            btnStandartExcelDosyasi = new DevExpress.XtraBars.BarButtonItem();
            btnFormatliExcelDosyasi = new DevExpress.XtraBars.BarButtonItem();
            btnFormatsizExcelDosyasi = new DevExpress.XtraBars.BarButtonItem();
            btnWordDosyasi = new DevExpress.XtraBars.BarButtonItem();
            btnPdfDosyasi = new DevExpress.XtraBars.BarButtonItem();
            btnTxtDosyasi = new DevExpress.XtraBars.BarButtonItem();
            btnAktifPasifKayitlar = new DevExpress.XtraBars.BarButtonItem();
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
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, btnYeni, btnSil, btnSec, btnDuzelt, btnYenile, btnKolonlar, btnYazdir, btnBaskiOnizle, btnKapat, barButtonItem1, btnDisariAktar, btnAktifPasifKayitlar, btnExcelDosyalari, btnWordDosyasi, btnPdfDosyasi, btnTxtDosyasi, btnStandartExcelDosyasi, btnFormatliExcelDosyasi, btnFormatsizExcelDosyasi });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 20;
            ribbon.Name = "ribbon";
            ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage1 });
            ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            ribbon.ShowQatLocationSelector = false;
            ribbon.ShowToolbarCustomizeItem = false;
            ribbon.Size = new Size(814, 135);
            ribbon.StatusBar = ribbonStatusBar;
            ribbon.Toolbar.ShowCustomizeItem = false;
            ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnYeni
            // 
            btnYeni.Caption = "Yeni";
            btnYeni.Id = 1;
            btnYeni.ImageOptions.SvgImage = Properties.Resources._new;
            btnYeni.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Insert);
            btnYeni.Name = "btnYeni";
            // 
            // btnSil
            // 
            btnSil.Caption = "Sil";
            btnSil.Id = 2;
            btnSil.ImageOptions.SvgImage = Properties.Resources.snapdeletelist;
            btnSil.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Delete);
            btnSil.Name = "btnSil";
            // 
            // btnSec
            // 
            btnSec.Caption = "Seç";
            btnSec.Id = 3;
            btnSec.ImageOptions.SvgImage = Properties.Resources.bo_validation;
            btnSec.Name = "btnSec";
            btnSec.ShortcutKeyDisplayString = "Enter";
            // 
            // btnDuzelt
            // 
            btnDuzelt.Caption = "Düzelt";
            btnDuzelt.Id = 4;
            btnDuzelt.ImageOptions.SvgImage = Properties.Resources.bo_document;
            btnDuzelt.Name = "btnDuzelt";
            btnDuzelt.ShortcutKeyDisplayString = "Enter";
            // 
            // btnYenile
            // 
            btnYenile.Caption = "Yenile";
            btnYenile.Id = 5;
            btnYenile.ImageOptions.SvgImage = Properties.Resources.convertto;
            btnYenile.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.F5);
            btnYenile.Name = "btnYenile";
            // 
            // btnKolonlar
            // 
            btnKolonlar.Caption = "Kolonlar";
            btnKolonlar.Id = 6;
            btnKolonlar.ImageOptions.SvgImage = Properties.Resources.compressweekend;
            btnKolonlar.Name = "btnKolonlar";
            // 
            // btnYazdir
            // 
            btnYazdir.Caption = "Yazdır";
            btnYazdir.Id = 7;
            btnYazdir.ImageOptions.SvgImage = Properties.Resources.print;
            btnYazdir.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.P);
            btnYazdir.Name = "btnYazdir";
            // 
            // btnBaskiOnizle
            // 
            btnBaskiOnizle.Caption = "Baskı Önizle";
            btnBaskiOnizle.Id = 8;
            btnBaskiOnizle.ImageOptions.SvgImage = Properties.Resources.showprintpreview;
            btnBaskiOnizle.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.Shift | Keys.P);
            btnBaskiOnizle.Name = "btnBaskiOnizle";
            btnBaskiOnizle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnKapat
            // 
            btnKapat.Caption = "Kapat";
            btnKapat.Id = 9;
            btnKapat.ImageOptions.SvgImage = Properties.Resources.clearheaderandfooter;
            btnKapat.Name = "btnKapat";
            btnKapat.ShortcutKeyDisplayString = "Esc";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "barButtonItem1";
            barButtonItem1.Id = 10;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // btnDisariAktar
            // 
            btnDisariAktar.Caption = "Dışarı Aktar";
            btnDisariAktar.Id = 11;
            btnDisariAktar.ImageOptions.SvgImage = Properties.Resources.exportas;
            btnDisariAktar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(btnExcelDosyalari), new DevExpress.XtraBars.LinkPersistInfo(btnWordDosyasi), new DevExpress.XtraBars.LinkPersistInfo(btnPdfDosyasi), new DevExpress.XtraBars.LinkPersistInfo(btnTxtDosyasi) });
            btnDisariAktar.Name = "btnDisariAktar";
            // 
            // btnExcelDosyalari
            // 
            btnExcelDosyalari.Caption = "Excel Dosyaları";
            btnExcelDosyalari.Id = 13;
            btnExcelDosyalari.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(btnStandartExcelDosyasi), new DevExpress.XtraBars.LinkPersistInfo(btnFormatliExcelDosyasi), new DevExpress.XtraBars.LinkPersistInfo(btnFormatsizExcelDosyasi) });
            btnExcelDosyalari.Name = "btnExcelDosyalari";
            // 
            // btnStandartExcelDosyasi
            // 
            btnStandartExcelDosyasi.Caption = "Excel Dosyası ( Standart )";
            btnStandartExcelDosyasi.Id = 17;
            btnStandartExcelDosyasi.Name = "btnStandartExcelDosyasi";
            // 
            // btnFormatliExcelDosyasi
            // 
            btnFormatliExcelDosyasi.Caption = "Excel Dosyası ( Formatlı ) ";
            btnFormatliExcelDosyasi.Id = 18;
            btnFormatliExcelDosyasi.Name = "btnFormatliExcelDosyasi";
            // 
            // btnFormatsizExcelDosyasi
            // 
            btnFormatsizExcelDosyasi.Caption = "Excel Dosyası ( Formatsız )";
            btnFormatsizExcelDosyasi.Id = 19;
            btnFormatsizExcelDosyasi.Name = "btnFormatsizExcelDosyasi";
            // 
            // btnWordDosyasi
            // 
            btnWordDosyasi.Caption = "Word Dosyası";
            btnWordDosyasi.Id = 14;
            btnWordDosyasi.Name = "btnWordDosyasi";
            // 
            // btnPdfDosyasi
            // 
            btnPdfDosyasi.Caption = "Pdf Dosyası";
            btnPdfDosyasi.Id = 15;
            btnPdfDosyasi.Name = "btnPdfDosyasi";
            // 
            // btnTxtDosyasi
            // 
            btnTxtDosyasi.Caption = "Txt Dosyası";
            btnTxtDosyasi.Id = 16;
            btnTxtDosyasi.Name = "btnTxtDosyasi";
            // 
            // btnAktifPasifKayitlar
            // 
            btnAktifPasifKayitlar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            btnAktifPasifKayitlar.Caption = "Pasif Kayıtlar";
            btnAktifPasifKayitlar.Id = 12;
            btnAktifPasifKayitlar.ImageOptions.Image = Properties.Resources.breakingchange_16x16;
            btnAktifPasifKayitlar.ImageOptions.LargeImage = Properties.Resources.breakingchange_32x32;
            btnAktifPasifKayitlar.ItemAppearance.Hovered.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnAktifPasifKayitlar.ItemAppearance.Hovered.ForeColor = Color.DarkBlue;
            btnAktifPasifKayitlar.ItemAppearance.Hovered.Options.UseFont = true;
            btnAktifPasifKayitlar.ItemAppearance.Hovered.Options.UseForeColor = true;
            btnAktifPasifKayitlar.ItemAppearance.Normal.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnAktifPasifKayitlar.ItemAppearance.Normal.ForeColor = Color.Maroon;
            btnAktifPasifKayitlar.ItemAppearance.Normal.Options.UseFont = true;
            btnAktifPasifKayitlar.ItemAppearance.Normal.Options.UseForeColor = true;
            btnAktifPasifKayitlar.ItemAppearance.Pressed.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            btnAktifPasifKayitlar.ItemAppearance.Pressed.ForeColor = Color.Maroon;
            btnAktifPasifKayitlar.ItemAppearance.Pressed.Options.UseFont = true;
            btnAktifPasifKayitlar.ItemAppearance.Pressed.Options.UseForeColor = true;
            btnAktifPasifKayitlar.Name = "btnAktifPasifKayitlar";
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
            ribbonPageGroup1.ItemLinks.Add(btnSil);
            ribbonPageGroup1.ItemLinks.Add(btnSec);
            ribbonPageGroup1.ItemLinks.Add(btnDuzelt);
            ribbonPageGroup1.ItemLinks.Add(btnYenile);
            ribbonPageGroup1.ItemLinks.Add(btnKolonlar);
            ribbonPageGroup1.ItemLinks.Add(btnYazdir);
            ribbonPageGroup1.ItemLinks.Add(btnBaskiOnizle);
            ribbonPageGroup1.ItemLinks.Add(btnDisariAktar);
            ribbonPageGroup1.ItemLinks.Add(btnKapat);
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            ribbonStatusBar.ItemLinks.Add(btnAktifPasifKayitlar);
            ribbonStatusBar.Location = new Point(0, 401);
            ribbonStatusBar.Name = "ribbonStatusBar";
            ribbonStatusBar.Ribbon = ribbon;
            ribbonStatusBar.Size = new Size(814, 24);
            // 
            // BaseListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(ribbon);
            Controls.Add(ribbonStatusBar);
            IconOptions.ShowIcon = false;
            MinimizeBox = false;
            Name = "BaseListForm";
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        protected DevExpress.XtraBars.BarButtonItem btnYeni;
        protected DevExpress.XtraBars.BarButtonItem btnSil;
        protected DevExpress.XtraBars.BarButtonItem btnSec;
        protected DevExpress.XtraBars.BarButtonItem btnDuzelt;
        protected DevExpress.XtraBars.BarButtonItem btnYenile;
        protected DevExpress.XtraBars.BarButtonItem btnKolonlar;
        protected DevExpress.XtraBars.BarButtonItem btnYazdir;
        protected DevExpress.XtraBars.BarButtonItem btnBaskiOnizle;
        protected DevExpress.XtraBars.BarButtonItem btnKapat;
        protected DevExpress.XtraBars.BarSubItem btnDisariAktar;
        protected internal DevExpress.XtraBars.BarButtonItem btnAktifPasifKayitlar;
        private DevExpress.XtraBars.BarSubItem btnExcelDosyalari;
        private DevExpress.XtraBars.BarButtonItem btnStandartExcelDosyasi;
        private DevExpress.XtraBars.BarButtonItem btnFormatliExcelDosyasi;
        private DevExpress.XtraBars.BarButtonItem btnFormatsizExcelDosyasi;
        private DevExpress.XtraBars.BarButtonItem btnWordDosyasi;
        private DevExpress.XtraBars.BarButtonItem btnPdfDosyasi;
        private DevExpress.XtraBars.BarButtonItem btnTxtDosyasi;
    }
}