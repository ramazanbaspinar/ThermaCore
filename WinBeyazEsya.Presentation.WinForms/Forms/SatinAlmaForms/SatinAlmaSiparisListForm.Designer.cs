namespace WinBeyazEsya.Presentation.WinForms.Forms.SatinAlmaForms
{
    partial class SatinAlmaSiparisListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatinAlmaSiparisListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSiparisTarihi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSiparisDurumu = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBelgeNo = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colCariHesapKodu = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colCariHesapUnvani = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTutar = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colDepo = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSiparisiOlusturan = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colAciklama = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(806, 153);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // btnDisariAktar
            // 
            btnDisariAktar.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnDisariAktar.ImageOptions.SvgImage");
            // 
            // longNavigator1
            // 
            longNavigator1.Dock = DockStyle.Bottom;
            longNavigator1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            longNavigator1.Location = new Point(0, 364);
            longNavigator1.Name = "longNavigator1";
            longNavigator1.Size = new Size(806, 30);
            longNavigator1.TabIndex = 2;
            // 
            // myGridControl1
            // 
            myGridControl1.Dock = DockStyle.Fill;
            myGridControl1.Location = new Point(0, 153);
            myGridControl1.MainView = myGridView1;
            myGridControl1.MenuManager = ribbon;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.Size = new Size(806, 211);
            myGridControl1.TabIndex = 3;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { myGridView1 });
            // 
            // myGridView1
            // 
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colSiparisTarihi, colSiparisDurumu, colKod, colBelgeNo, colCariHesapKodu, colCariHesapUnvani, colTutar, colDepo, colSiparisiOlusturan, colAciklama });
            myGridView1.GridControl = myGridControl1;
            myGridView1.GroupCount = 1;
            myGridView1.Name = "myGridView1";
            myGridView1.OptionsMenu.EnableColumnMenu = false;
            myGridView1.OptionsMenu.EnableFooterMenu = false;
            myGridView1.OptionsMenu.EnableGroupPanelMenu = false;
            myGridView1.OptionsNavigation.EnterMoveNextColumn = true;
            myGridView1.OptionsPrint.AutoWidth = false;
            myGridView1.OptionsPrint.PrintFooter = false;
            myGridView1.OptionsPrint.PrintGroupFooter = false;
            myGridView1.OptionsView.ColumnAutoWidth = false;
            myGridView1.OptionsView.EnableAppearanceEvenRow = true;
            myGridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            myGridView1.OptionsView.ShowAutoFilterRow = true;
            myGridView1.OptionsView.ShowGroupPanel = false;
            myGridView1.OptionsView.ShowViewCaption = true;
            myGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] { new DevExpress.XtraGrid.Columns.GridColumnSortInfo(colSiparisTarihi, DevExpress.Data.ColumnSortOrder.Descending) });
            myGridView1.StatusBarAciklama = null;
            myGridView1.StatusBarKisaYol = null;
            myGridView1.StatusBarKisaYolAciklama = null;
            myGridView1.ViewCaption = "Satınalma Siparişleri";
            // 
            // colId
            // 
            colId.Caption = "Id";
            colId.FieldName = "Id";
            colId.Name = "colId";
            colId.OptionsColumn.AllowEdit = false;
            colId.OptionsColumn.ShowInCustomizationForm = false;
            colId.StatusBarAciklama = null;
            colId.StatusBarKisaYol = null;
            colId.StatusBarKisaYolAciklama = null;
            // 
            // colSiparisTarihi
            // 
            colSiparisTarihi.Caption = "Sipariş Tarihi";
            colSiparisTarihi.FieldName = "OrderDate";
            colSiparisTarihi.Name = "colSiparisTarihi";
            colSiparisTarihi.OptionsColumn.AllowEdit = false;
            colSiparisTarihi.StatusBarAciklama = null;
            colSiparisTarihi.StatusBarKisaYol = null;
            colSiparisTarihi.StatusBarKisaYolAciklama = null;
            colSiparisTarihi.Visible = true;
            colSiparisTarihi.VisibleIndex = 0;
            // 
            // colSiparisDurumu
            // 
            colSiparisDurumu.Caption = "Sipariş Durumu";
            colSiparisDurumu.FieldName = "StatusName";
            colSiparisDurumu.Name = "colSiparisDurumu";
            colSiparisDurumu.OptionsColumn.AllowEdit = false;
            colSiparisDurumu.StatusBarAciklama = null;
            colSiparisDurumu.StatusBarKisaYol = null;
            colSiparisDurumu.StatusBarKisaYolAciklama = null;
            colSiparisDurumu.Visible = true;
            colSiparisDurumu.VisibleIndex = 2;
            colSiparisDurumu.Width = 125;
            // 
            // colKod
            // 
            colKod.AppearanceCell.Options.UseTextOptions = true;
            colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colKod.Caption = "Kod";
            colKod.FieldName = "Code";
            colKod.Name = "colKod";
            colKod.OptionsColumn.AllowEdit = false;
            colKod.StatusBarAciklama = null;
            colKod.StatusBarKisaYol = null;
            colKod.StatusBarKisaYolAciklama = null;
            colKod.Visible = true;
            colKod.VisibleIndex = 0;
            colKod.Width = 125;
            // 
            // colBelgeNo
            // 
            colBelgeNo.Caption = "Belge No (Tedarikçi Ref No)";
            colBelgeNo.FieldName = "DocumentNo";
            colBelgeNo.Name = "colBelgeNo";
            colBelgeNo.OptionsColumn.AllowEdit = false;
            colBelgeNo.StatusBarAciklama = null;
            colBelgeNo.StatusBarKisaYol = null;
            colBelgeNo.StatusBarKisaYolAciklama = null;
            colBelgeNo.Visible = true;
            colBelgeNo.VisibleIndex = 1;
            colBelgeNo.Width = 125;
            // 
            // colCariHesapKodu
            // 
            colCariHesapKodu.Caption = "Cari Hesap Kodu";
            colCariHesapKodu.FieldName = "SupplierCode";
            colCariHesapKodu.Name = "colCariHesapKodu";
            colCariHesapKodu.OptionsColumn.AllowEdit = false;
            colCariHesapKodu.StatusBarAciklama = null;
            colCariHesapKodu.StatusBarKisaYol = null;
            colCariHesapKodu.StatusBarKisaYolAciklama = null;
            colCariHesapKodu.Visible = true;
            colCariHesapKodu.VisibleIndex = 3;
            colCariHesapKodu.Width = 125;
            // 
            // colCariHesapUnvani
            // 
            colCariHesapUnvani.Caption = "Cari Hesap Unvanı (Tedarikçi)";
            colCariHesapUnvani.FieldName = "SupplierName";
            colCariHesapUnvani.Name = "colCariHesapUnvani";
            colCariHesapUnvani.OptionsColumn.AllowEdit = false;
            colCariHesapUnvani.StatusBarAciklama = null;
            colCariHesapUnvani.StatusBarKisaYol = null;
            colCariHesapUnvani.StatusBarKisaYolAciklama = null;
            colCariHesapUnvani.Visible = true;
            colCariHesapUnvani.VisibleIndex = 4;
            colCariHesapUnvani.Width = 125;
            // 
            // colTutar
            // 
            colTutar.Caption = "Tutar";
            colTutar.DisplayFormat.FormatString = "n2";
            colTutar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTutar.FieldName = "GrandTotal";
            colTutar.GroupFormat.FormatString = "n2";
            colTutar.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTutar.Name = "colTutar";
            colTutar.OptionsColumn.AllowEdit = false;
            colTutar.StatusBarAciklama = null;
            colTutar.StatusBarKisaYol = null;
            colTutar.StatusBarKisaYolAciklama = null;
            colTutar.Visible = true;
            colTutar.VisibleIndex = 5;
            colTutar.Width = 125;
            // 
            // colDepo
            // 
            colDepo.Caption = "Depo";
            colDepo.FieldName = "WarehouseName";
            colDepo.Name = "colDepo";
            colDepo.OptionsColumn.AllowEdit = false;
            colDepo.StatusBarAciklama = null;
            colDepo.StatusBarKisaYol = null;
            colDepo.StatusBarKisaYolAciklama = null;
            colDepo.Visible = true;
            colDepo.VisibleIndex = 6;
            colDepo.Width = 125;
            // 
            // colSiparisiOlusturan
            // 
            colSiparisiOlusturan.Caption = "Siparişi Oluşturan";
            colSiparisiOlusturan.FieldName = "CreatedFullName";
            colSiparisiOlusturan.Name = "colSiparisiOlusturan";
            colSiparisiOlusturan.OptionsColumn.AllowEdit = false;
            colSiparisiOlusturan.StatusBarAciklama = null;
            colSiparisiOlusturan.StatusBarKisaYol = null;
            colSiparisiOlusturan.StatusBarKisaYolAciklama = null;
            colSiparisiOlusturan.Visible = true;
            colSiparisiOlusturan.VisibleIndex = 7;
            colSiparisiOlusturan.Width = 125;
            // 
            // colAciklama
            // 
            colAciklama.Caption = "Açıklama";
            colAciklama.FieldName = "Description";
            colAciklama.Name = "colAciklama";
            colAciklama.OptionsColumn.AllowEdit = false;
            colAciklama.StatusBarAciklama = null;
            colAciklama.StatusBarKisaYol = null;
            colAciklama.StatusBarKisaYolAciklama = null;
            colAciklama.Visible = true;
            colAciklama.VisibleIndex = 8;
            colAciklama.Width = 125;
            // 
            // SatinAlmaSiparisListForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            Font = new Font("Segoe UI", 8.25F);
            IconOptions.ShowIcon = false;
            Name = "SatinAlmaSiparisListForm";
            Text = "Satınalma Siparişleri";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(longNavigator1, 0);
            Controls.SetChildIndex(myGridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator longNavigator1;
        private UserControls.Grid.MyGridControl myGridControl1;
        private UserControls.Grid.MyGridView myGridView1;
        private UserControls.Grid.MyGridColumn colId;
        private UserControls.Grid.MyGridColumn colSiparisTarihi;
        private UserControls.Grid.MyGridColumn colKod;
        private UserControls.Grid.MyGridColumn colCariHesapUnvani;
        private UserControls.Grid.MyGridColumn colTutar;
        private UserControls.Grid.MyGridColumn colDepo;
        private UserControls.Grid.MyGridColumn colCariHesapKodu;
        private UserControls.Grid.MyGridColumn colSiparisiOlusturan;
        private UserControls.Grid.MyGridColumn colSiparisDurumu;
        private UserControls.Grid.MyGridColumn colBelgeNo;
        private UserControls.Grid.MyGridColumn colAciklama;
    }
}