namespace WinBeyazEsya.Presentation.WinForms.Forms.UretimForms
{
    partial class UrunMaliyetDetaylariForm
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
            this.components = new System.ComponentModel.Container();

            // === PANEL CONTAINERS ===
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.panelFooter = new DevExpress.XtraEditors.PanelControl();
            this.panelGrid = new DevExpress.XtraEditors.PanelControl();

            // === HEADER CONTROLS ===
            this.lblUrunKoduBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblUrunKodu = new DevExpress.XtraEditors.LabelControl();
            this.lblUrunAdiBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblUrunAdi = new DevExpress.XtraEditors.LabelControl();
            this.lblRevizyonBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblRevizyon = new DevExpress.XtraEditors.LabelControl();
            this.lblReceteAdiBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblReceteAdi = new DevExpress.XtraEditors.LabelControl();
            this.separatorHeader = new DevExpress.XtraEditors.SeparatorControl();

            // === GRID ===
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMalzemeGrubu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHammaddeAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFireOrani = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSatirMaliyeti = new DevExpress.XtraGrid.Columns.GridColumn();

            // === FOOTER CONTROLS ===
            this.lblNetMalzemeBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblNetMalzemeDeger = new DevExpress.XtraEditors.LabelControl();
            this.lblFireBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblFireDeger = new DevExpress.XtraEditors.LabelControl();
            this.lblGugBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblGugDeger = new DevExpress.XtraEditors.LabelControl();
            this.separatorFooter = new DevExpress.XtraEditors.SeparatorControl();
            this.lblToplamBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblToplamDeger = new DevExpress.XtraEditors.LabelControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();

            // Begin Init
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).BeginInit();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorFooter)).BeginInit();
            this.SuspendLayout();

            // ========================================
            // panelHeader
            // ========================================
            this.panelHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(784, 110);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Controls.Add(this.lblRevizyonBaslik);
            this.panelHeader.Controls.Add(this.lblRevizyon);
            this.panelHeader.Controls.Add(this.lblReceteAdiBaslik);
            this.panelHeader.Controls.Add(this.lblReceteAdi);
            this.panelHeader.Controls.Add(this.lblUrunAdiBaslik);
            this.panelHeader.Controls.Add(this.lblUrunAdi);
            this.panelHeader.Controls.Add(this.lblUrunKoduBaslik);
            this.panelHeader.Controls.Add(this.lblUrunKodu);
            this.panelHeader.Controls.Add(this.separatorHeader);

            // ========================================
            // lblUrunKoduBaslik
            // ========================================
            this.lblUrunKoduBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUrunKoduBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblUrunKoduBaslik.Appearance.Options.UseFont = true;
            this.lblUrunKoduBaslik.Appearance.Options.UseForeColor = true;
            this.lblUrunKoduBaslik.Location = new System.Drawing.Point(16, 14);
            this.lblUrunKoduBaslik.Name = "lblUrunKoduBaslik";
            this.lblUrunKoduBaslik.Size = new System.Drawing.Size(82, 17);
            this.lblUrunKoduBaslik.TabIndex = 0;
            this.lblUrunKoduBaslik.Text = "Reçete Kodu:";

            // ========================================
            // lblUrunKodu
            // ========================================
            this.lblUrunKodu.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.lblUrunKodu.Appearance.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblUrunKodu.Appearance.Options.UseFont = true;
            this.lblUrunKodu.Appearance.Options.UseForeColor = true;
            this.lblUrunKodu.Location = new System.Drawing.Point(110, 14);
            this.lblUrunKodu.Name = "lblUrunKodu";
            this.lblUrunKodu.Size = new System.Drawing.Size(10, 17);
            this.lblUrunKodu.TabIndex = 1;
            this.lblUrunKodu.Text = "-";

            // ========================================
            // lblReceteAdiBaslik
            // ========================================
            this.lblReceteAdiBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblReceteAdiBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblReceteAdiBaslik.Appearance.Options.UseFont = true;
            this.lblReceteAdiBaslik.Appearance.Options.UseForeColor = true;
            this.lblReceteAdiBaslik.Location = new System.Drawing.Point(16, 38);
            this.lblReceteAdiBaslik.Name = "lblReceteAdiBaslik";
            this.lblReceteAdiBaslik.Size = new System.Drawing.Size(72, 17);
            this.lblReceteAdiBaslik.TabIndex = 2;
            this.lblReceteAdiBaslik.Text = "Reçete Adı:";

            // ========================================
            // lblReceteAdi
            // ========================================
            this.lblReceteAdi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.lblReceteAdi.Appearance.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblReceteAdi.Appearance.Options.UseFont = true;
            this.lblReceteAdi.Appearance.Options.UseForeColor = true;
            this.lblReceteAdi.Location = new System.Drawing.Point(110, 38);
            this.lblReceteAdi.Name = "lblReceteAdi";
            this.lblReceteAdi.Size = new System.Drawing.Size(10, 17);
            this.lblReceteAdi.TabIndex = 3;
            this.lblReceteAdi.Text = "-";

            // ========================================
            // lblUrunAdiBaslik
            // ========================================
            this.lblUrunAdiBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblUrunAdiBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblUrunAdiBaslik.Appearance.Options.UseFont = true;
            this.lblUrunAdiBaslik.Appearance.Options.UseForeColor = true;
            this.lblUrunAdiBaslik.Location = new System.Drawing.Point(400, 14);
            this.lblUrunAdiBaslik.Name = "lblUrunAdiBaslik";
            this.lblUrunAdiBaslik.Size = new System.Drawing.Size(67, 17);
            this.lblUrunAdiBaslik.TabIndex = 4;
            this.lblUrunAdiBaslik.Text = "Ürün Adı:";

            // ========================================
            // lblUrunAdi
            // ========================================
            this.lblUrunAdi.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.lblUrunAdi.Appearance.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblUrunAdi.Appearance.Options.UseFont = true;
            this.lblUrunAdi.Appearance.Options.UseForeColor = true;
            this.lblUrunAdi.Location = new System.Drawing.Point(480, 14);
            this.lblUrunAdi.Name = "lblUrunAdi";
            this.lblUrunAdi.Size = new System.Drawing.Size(10, 17);
            this.lblUrunAdi.TabIndex = 5;
            this.lblUrunAdi.Text = "-";

            // ========================================
            // lblRevizyonBaslik
            // ========================================
            this.lblRevizyonBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRevizyonBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblRevizyonBaslik.Appearance.Options.UseFont = true;
            this.lblRevizyonBaslik.Appearance.Options.UseForeColor = true;
            this.lblRevizyonBaslik.Location = new System.Drawing.Point(400, 38);
            this.lblRevizyonBaslik.Name = "lblRevizyonBaslik";
            this.lblRevizyonBaslik.Size = new System.Drawing.Size(82, 17);
            this.lblRevizyonBaslik.TabIndex = 6;
            this.lblRevizyonBaslik.Text = "Revizyon No:";

            // ========================================
            // lblRevizyon
            // ========================================
            this.lblRevizyon.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.lblRevizyon.Appearance.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblRevizyon.Appearance.Options.UseFont = true;
            this.lblRevizyon.Appearance.Options.UseForeColor = true;
            this.lblRevizyon.Location = new System.Drawing.Point(480, 38);
            this.lblRevizyon.Name = "lblRevizyon";
            this.lblRevizyon.Size = new System.Drawing.Size(10, 17);
            this.lblRevizyon.TabIndex = 7;
            this.lblRevizyon.Text = "-";

            // ========================================
            // separatorHeader
            // ========================================
            this.separatorHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.separatorHeader.Location = new System.Drawing.Point(0, 95);
            this.separatorHeader.Name = "separatorHeader";
            this.separatorHeader.Size = new System.Drawing.Size(784, 15);
            this.separatorHeader.TabIndex = 8;

            // ========================================
            // panelGrid
            // ========================================
            this.panelGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 110);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.panelGrid.Size = new System.Drawing.Size(784, 264);
            this.panelGrid.TabIndex = 1;
            this.panelGrid.Controls.Add(this.gridControl);

            // ========================================
            // gridControl
            // ========================================
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(8, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(768, 264);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView });

            // ========================================
            // gridView
            // ========================================
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.colMalzemeGrubu,
                this.colHammaddeAdi,
                this.colMiktar,
                this.colBirimFiyat,
                this.colFireOrani,
                this.colSatirMaliyeti
            });
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ColumnAutoWidth = true;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.gridView.Appearance.FooterPanel.Options.UseFont = true;

            // ========================================
            // colMalzemeGrubu
            // ========================================
            this.colMalzemeGrubu.Caption = "Malzeme Grubu";
            this.colMalzemeGrubu.FieldName = "MaterialGroupName";
            this.colMalzemeGrubu.Name = "colMalzemeGrubu";
            this.colMalzemeGrubu.Visible = true;
            this.colMalzemeGrubu.VisibleIndex = 0;
            this.colMalzemeGrubu.Width = 120;

            // ========================================
            // colHammaddeAdi
            // ========================================
            this.colHammaddeAdi.Caption = "Hammadde Adı";
            this.colHammaddeAdi.FieldName = "MaterialName";
            this.colHammaddeAdi.Name = "colHammaddeAdi";
            this.colHammaddeAdi.Visible = true;
            this.colHammaddeAdi.VisibleIndex = 1;
            this.colHammaddeAdi.Width = 180;

            // ========================================
            // colMiktar
            // ========================================
            this.colMiktar.Caption = "Miktar";
            this.colMiktar.FieldName = "Quantity";
            this.colMiktar.Name = "colMiktar";
            this.colMiktar.Visible = true;
            this.colMiktar.VisibleIndex = 2;
            this.colMiktar.Width = 80;
            this.colMiktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMiktar.DisplayFormat.FormatString = "n2";
            this.colMiktar.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // ========================================
            // colBirimFiyat
            // ========================================
            this.colBirimFiyat.Caption = "Birim Fiyat";
            this.colBirimFiyat.FieldName = "UnitPrice";
            this.colBirimFiyat.Name = "colBirimFiyat";
            this.colBirimFiyat.Visible = true;
            this.colBirimFiyat.VisibleIndex = 3;
            this.colBirimFiyat.Width = 100;
            this.colBirimFiyat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBirimFiyat.DisplayFormat.FormatString = "n4";
            this.colBirimFiyat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // ========================================
            // colFireOrani
            // ========================================
            this.colFireOrani.Caption = "Fire Oranı (%)";
            this.colFireOrani.FieldName = "WasteRate";
            this.colFireOrani.Name = "colFireOrani";
            this.colFireOrani.Visible = true;
            this.colFireOrani.VisibleIndex = 4;
            this.colFireOrani.Width = 90;
            this.colFireOrani.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFireOrani.DisplayFormat.FormatString = "n2";
            this.colFireOrani.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // ========================================
            // colSatirMaliyeti
            // ========================================
            this.colSatirMaliyeti.Caption = "Satır Maliyeti";
            this.colSatirMaliyeti.FieldName = "TotalMaterialCost";
            this.colSatirMaliyeti.Name = "colSatirMaliyeti";
            this.colSatirMaliyeti.Visible = true;
            this.colSatirMaliyeti.VisibleIndex = 5;
            this.colSatirMaliyeti.Width = 120;
            this.colSatirMaliyeti.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSatirMaliyeti.DisplayFormat.FormatString = "n2";
            this.colSatirMaliyeti.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSatirMaliyeti.AppearanceCell.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.colSatirMaliyeti.AppearanceCell.Options.UseFont = true;
            this.colSatirMaliyeti.Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalMaterialCost", "Toplam: {0:n2}"));

            // ========================================
            // panelFooter
            // ========================================
            this.panelFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 374);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(784, 187);
            this.panelFooter.TabIndex = 2;
            this.panelFooter.Controls.Add(this.btnKapat);
            this.panelFooter.Controls.Add(this.lblToplamDeger);
            this.panelFooter.Controls.Add(this.lblToplamBaslik);
            this.panelFooter.Controls.Add(this.separatorFooter);
            this.panelFooter.Controls.Add(this.lblGugDeger);
            this.panelFooter.Controls.Add(this.lblGugBaslik);
            this.panelFooter.Controls.Add(this.lblFireDeger);
            this.panelFooter.Controls.Add(this.lblFireBaslik);
            this.panelFooter.Controls.Add(this.lblNetMalzemeDeger);
            this.panelFooter.Controls.Add(this.lblNetMalzemeBaslik);

            // ========================================
            // lblNetMalzemeBaslik
            // ========================================
            this.lblNetMalzemeBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNetMalzemeBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblNetMalzemeBaslik.Appearance.Options.UseFont = true;
            this.lblNetMalzemeBaslik.Appearance.Options.UseForeColor = true;
            this.lblNetMalzemeBaslik.Location = new System.Drawing.Point(16, 12);
            this.lblNetMalzemeBaslik.Name = "lblNetMalzemeBaslik";
            this.lblNetMalzemeBaslik.Size = new System.Drawing.Size(143, 19);
            this.lblNetMalzemeBaslik.TabIndex = 0;
            this.lblNetMalzemeBaslik.Text = "Net Malzeme Maliyeti:";

            // ========================================
            // lblNetMalzemeDeger
            // ========================================
            this.lblNetMalzemeDeger.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblNetMalzemeDeger.Appearance.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblNetMalzemeDeger.Appearance.Options.UseFont = true;
            this.lblNetMalzemeDeger.Appearance.Options.UseForeColor = true;
            this.lblNetMalzemeDeger.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNetMalzemeDeger.Location = new System.Drawing.Point(540, 12);
            this.lblNetMalzemeDeger.Name = "lblNetMalzemeDeger";
            this.lblNetMalzemeDeger.Size = new System.Drawing.Size(228, 19);
            this.lblNetMalzemeDeger.TabIndex = 1;
            this.lblNetMalzemeDeger.Text = "0,00";
            this.lblNetMalzemeDeger.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // ========================================
            // lblFireBaslik
            // ========================================
            this.lblFireBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFireBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblFireBaslik.Appearance.Options.UseFont = true;
            this.lblFireBaslik.Appearance.Options.UseForeColor = true;
            this.lblFireBaslik.Location = new System.Drawing.Point(16, 38);
            this.lblFireBaslik.Name = "lblFireBaslik";
            this.lblFireBaslik.Size = new System.Drawing.Size(131, 19);
            this.lblFireBaslik.TabIndex = 2;
            this.lblFireBaslik.Text = "Toplam Fire Maliyeti:";

            // ========================================
            // lblFireDeger
            // ========================================
            this.lblFireDeger.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblFireDeger.Appearance.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblFireDeger.Appearance.Options.UseFont = true;
            this.lblFireDeger.Appearance.Options.UseForeColor = true;
            this.lblFireDeger.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFireDeger.Location = new System.Drawing.Point(540, 38);
            this.lblFireDeger.Name = "lblFireDeger";
            this.lblFireDeger.Size = new System.Drawing.Size(228, 19);
            this.lblFireDeger.TabIndex = 3;
            this.lblFireDeger.Text = "0,00";
            this.lblFireDeger.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // ========================================
            // lblGugBaslik
            // ========================================
            this.lblGugBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGugBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            this.lblGugBaslik.Appearance.Options.UseFont = true;
            this.lblGugBaslik.Appearance.Options.UseForeColor = true;
            this.lblGugBaslik.Location = new System.Drawing.Point(16, 64);
            this.lblGugBaslik.Name = "lblGugBaslik";
            this.lblGugBaslik.Size = new System.Drawing.Size(195, 19);
            this.lblGugBaslik.TabIndex = 4;
            this.lblGugBaslik.Text = "GÜG (Genel Üretim Gideri) Tutarı:";

            // ========================================
            // lblGugDeger
            // ========================================
            this.lblGugDeger.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblGugDeger.Appearance.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblGugDeger.Appearance.Options.UseFont = true;
            this.lblGugDeger.Appearance.Options.UseForeColor = true;
            this.lblGugDeger.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGugDeger.Location = new System.Drawing.Point(540, 64);
            this.lblGugDeger.Name = "lblGugDeger";
            this.lblGugDeger.Size = new System.Drawing.Size(228, 19);
            this.lblGugDeger.TabIndex = 5;
            this.lblGugDeger.Text = "0,00";
            this.lblGugDeger.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // ========================================
            // separatorFooter
            // ========================================
            this.separatorFooter.Location = new System.Drawing.Point(16, 90);
            this.separatorFooter.Name = "separatorFooter";
            this.separatorFooter.Size = new System.Drawing.Size(752, 15);
            this.separatorFooter.TabIndex = 6;

            // ========================================
            // lblToplamBaslik
            // ========================================
            this.lblToplamBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblToplamBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblToplamBaslik.Appearance.Options.UseFont = true;
            this.lblToplamBaslik.Appearance.Options.UseForeColor = true;
            this.lblToplamBaslik.Location = new System.Drawing.Point(16, 112);
            this.lblToplamBaslik.Name = "lblToplamBaslik";
            this.lblToplamBaslik.Size = new System.Drawing.Size(227, 21);
            this.lblToplamBaslik.TabIndex = 7;
            this.lblToplamBaslik.Text = "TOPLAM ÜRETİM MALİYETİ:";

            // ========================================
            // lblToplamDeger
            // ========================================
            this.lblToplamDeger.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblToplamDeger.Appearance.ForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.lblToplamDeger.Appearance.Options.UseFont = true;
            this.lblToplamDeger.Appearance.Options.UseForeColor = true;
            this.lblToplamDeger.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblToplamDeger.Location = new System.Drawing.Point(540, 110);
            this.lblToplamDeger.Name = "lblToplamDeger";
            this.lblToplamDeger.Size = new System.Drawing.Size(228, 23);
            this.lblToplamDeger.TabIndex = 8;
            this.lblToplamDeger.Text = "0,00";
            this.lblToplamDeger.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // ========================================
            // btnKapat
            // ========================================
            this.btnKapat.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnKapat.Appearance.Options.UseFont = true;
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.Location = new System.Drawing.Point(644, 148);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(124, 28);
            this.btnKapat.TabIndex = 9;
            this.btnKapat.Text = "Kapat";

            // ========================================
            // UrunMaliyetDetaylariForm
            // ========================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnKapat;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrunMaliyetDetaylariForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Maliyet Detayları ve Analizi";

            // End Init
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelFooter)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorFooter)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Panel Containers
        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.PanelControl panelFooter;
        private DevExpress.XtraEditors.PanelControl panelGrid;

        // Header Controls
        private DevExpress.XtraEditors.LabelControl lblUrunKoduBaslik;
        private DevExpress.XtraEditors.LabelControl lblUrunKodu;
        private DevExpress.XtraEditors.LabelControl lblReceteAdiBaslik;
        private DevExpress.XtraEditors.LabelControl lblReceteAdi;
        private DevExpress.XtraEditors.LabelControl lblUrunAdiBaslik;
        private DevExpress.XtraEditors.LabelControl lblUrunAdi;
        private DevExpress.XtraEditors.LabelControl lblRevizyonBaslik;
        private DevExpress.XtraEditors.LabelControl lblRevizyon;
        private DevExpress.XtraEditors.SeparatorControl separatorHeader;

        // Grid Controls
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colMalzemeGrubu;
        private DevExpress.XtraGrid.Columns.GridColumn colHammaddeAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colBirimFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn colFireOrani;
        private DevExpress.XtraGrid.Columns.GridColumn colSatirMaliyeti;

        // Footer Controls
        private DevExpress.XtraEditors.LabelControl lblNetMalzemeBaslik;
        private DevExpress.XtraEditors.LabelControl lblNetMalzemeDeger;
        private DevExpress.XtraEditors.LabelControl lblFireBaslik;
        private DevExpress.XtraEditors.LabelControl lblFireDeger;
        private DevExpress.XtraEditors.LabelControl lblGugBaslik;
        private DevExpress.XtraEditors.LabelControl lblGugDeger;
        private DevExpress.XtraEditors.SeparatorControl separatorFooter;
        private DevExpress.XtraEditors.LabelControl lblToplamBaslik;
        private DevExpress.XtraEditors.LabelControl lblToplamDeger;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
    }
}
