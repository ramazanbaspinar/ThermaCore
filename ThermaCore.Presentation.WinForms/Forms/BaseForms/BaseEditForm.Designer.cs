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
            ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbon.ExpandCollapseItem, btnYeni, btnKaydet, btnGerial, btnYenile, btnYazdir, btnBaskiOnizle, btnKapat, btnSifreDegistir, btnSil });
            ribbon.Location = new Point(0, 0);
            ribbon.MaxItemId = 10;
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
            // 
            // btnYazdir
            // 
            btnYazdir.Caption = "Yazdır";
            btnYazdir.Id = 5;
            btnYazdir.ImageOptions.SvgImage = Properties.Resources.print;
            btnYazdir.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.P);
            btnYazdir.Name = "btnYazdir";
            // 
            // btnBaskiOnizle
            // 
            btnBaskiOnizle.Caption = "Baskı Önizle";
            btnBaskiOnizle.Id = 6;
            btnBaskiOnizle.ImageOptions.SvgImage = Properties.Resources.showprintpreview;
            btnBaskiOnizle.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Control | Keys.Shift | Keys.P);
            btnBaskiOnizle.Name = "btnBaskiOnizle";
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
            // 
            // btnSil
            // 
            btnSil.Caption = "Sil";
            btnSil.Id = 9;
            btnSil.ImageOptions.SvgImage = Properties.Resources.snapdeletelist;
            btnSil.ItemShortcut = new DevExpress.XtraBars.BarShortcut(Keys.Delete);
            btnSil.Name = "btnSil";
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
    }
}