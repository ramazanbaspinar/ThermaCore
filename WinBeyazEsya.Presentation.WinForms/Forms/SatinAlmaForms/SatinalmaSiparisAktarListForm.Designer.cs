namespace WinBeyazEsya.Presentation.WinForms.Forms.SatinalmaForms
{
    partial class SatinalmaSiparisAktarListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatinalmaSiparisAktarListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSiparisTarihi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBelgeKodu = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMalzemeAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colIstenenMiktar = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colGelenMiktar = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBekleyenMiktar = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBirim = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBirimFiyat = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colDovizTuru = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTeslimatDeposu = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTerminTarihi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colSiparisTarihi, colKod, colBelgeKodu, colMalzemeAdi, colIstenenMiktar, colGelenMiktar, colBekleyenMiktar, colBirim, colBirimFiyat, colDovizTuru, colTeslimatDeposu, colTerminTarihi });
            myGridView1.GridControl = myGridControl1;
            myGridView1.Name = "myGridView1";
            myGridView1.OptionsMenu.EnableColumnMenu = false;
            myGridView1.OptionsMenu.EnableFooterMenu = false;
            myGridView1.OptionsMenu.EnableGroupPanelMenu = false;
            myGridView1.OptionsNavigation.EnterMoveNextColumn = true;
            myGridView1.OptionsPrint.AutoWidth = false;
            myGridView1.OptionsPrint.PrintFooter = false;
            myGridView1.OptionsPrint.PrintGroupFooter = false;
            myGridView1.OptionsSelection.MultiSelect = true;
            myGridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            myGridView1.OptionsView.ColumnAutoWidth = false;
            myGridView1.OptionsView.EnableAppearanceEvenRow = true;
            myGridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            myGridView1.OptionsView.ShowAutoFilterRow = true;
            myGridView1.OptionsView.ShowGroupPanel = false;
            myGridView1.OptionsView.ShowViewCaption = true;
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
            colSiparisTarihi.VisibleIndex = 1;
            colSiparisTarihi.Width = 125;
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
            colKod.VisibleIndex = 2;
            colKod.Width = 125;
            // 
            // colBelgeKodu
            // 
            colBelgeKodu.Caption = "Belge Kodu (Tedarikçi Ref No)";
            colBelgeKodu.FieldName = "DocumentNo";
            colBelgeKodu.Name = "colBelgeKodu";
            colBelgeKodu.OptionsColumn.AllowEdit = false;
            colBelgeKodu.StatusBarAciklama = null;
            colBelgeKodu.StatusBarKisaYol = null;
            colBelgeKodu.StatusBarKisaYolAciklama = null;
            colBelgeKodu.Visible = true;
            colBelgeKodu.VisibleIndex = 3;
            colBelgeKodu.Width = 125;
            // 
            // colMalzemeAdi
            // 
            colMalzemeAdi.Caption = "Malzeme Adı";
            colMalzemeAdi.FieldName = "MaterialName";
            colMalzemeAdi.Name = "colMalzemeAdi";
            colMalzemeAdi.OptionsColumn.AllowEdit = false;
            colMalzemeAdi.StatusBarAciklama = null;
            colMalzemeAdi.StatusBarKisaYol = null;
            colMalzemeAdi.StatusBarKisaYolAciklama = null;
            colMalzemeAdi.Visible = true;
            colMalzemeAdi.VisibleIndex = 4;
            colMalzemeAdi.Width = 125;
            // 
            // colIstenenMiktar
            // 
            colIstenenMiktar.Caption = "İstenen Miktar";
            colIstenenMiktar.DisplayFormat.FormatString = "n2";
            colIstenenMiktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colIstenenMiktar.FieldName = "Quantity";
            colIstenenMiktar.GroupFormat.FormatString = "n2";
            colIstenenMiktar.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colIstenenMiktar.Name = "colIstenenMiktar";
            colIstenenMiktar.OptionsColumn.AllowEdit = false;
            colIstenenMiktar.StatusBarAciklama = null;
            colIstenenMiktar.StatusBarKisaYol = null;
            colIstenenMiktar.StatusBarKisaYolAciklama = null;
            colIstenenMiktar.Visible = true;
            colIstenenMiktar.VisibleIndex = 5;
            colIstenenMiktar.Width = 125;
            // 
            // colGelenMiktar
            // 
            colGelenMiktar.Caption = "Gelen Miktar";
            colGelenMiktar.DisplayFormat.FormatString = "n2";
            colGelenMiktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colGelenMiktar.FieldName = "ReceivedQuantity";
            colGelenMiktar.GroupFormat.FormatString = "n2";
            colGelenMiktar.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colGelenMiktar.Name = "colGelenMiktar";
            colGelenMiktar.OptionsColumn.AllowEdit = false;
            colGelenMiktar.StatusBarAciklama = null;
            colGelenMiktar.StatusBarKisaYol = null;
            colGelenMiktar.StatusBarKisaYolAciklama = null;
            colGelenMiktar.Visible = true;
            colGelenMiktar.VisibleIndex = 6;
            colGelenMiktar.Width = 125;
            // 
            // colBekleyenMiktar
            // 
            colBekleyenMiktar.Caption = "Bekleyen Miktar";
            colBekleyenMiktar.DisplayFormat.FormatString = "n2";
            colBekleyenMiktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBekleyenMiktar.FieldName = "PendingQuantity";
            colBekleyenMiktar.GroupFormat.FormatString = "n2";
            colBekleyenMiktar.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBekleyenMiktar.Name = "colBekleyenMiktar";
            colBekleyenMiktar.OptionsColumn.AllowEdit = false;
            colBekleyenMiktar.StatusBarAciklama = null;
            colBekleyenMiktar.StatusBarKisaYol = null;
            colBekleyenMiktar.StatusBarKisaYolAciklama = null;
            colBekleyenMiktar.Visible = true;
            colBekleyenMiktar.VisibleIndex = 7;
            colBekleyenMiktar.Width = 125;
            // 
            // colBirim
            // 
            colBirim.Caption = "Birim";
            colBirim.FieldName = "UnitName";
            colBirim.Name = "colBirim";
            colBirim.OptionsColumn.AllowEdit = false;
            colBirim.StatusBarAciklama = null;
            colBirim.StatusBarKisaYol = null;
            colBirim.StatusBarKisaYolAciklama = null;
            colBirim.Width = 125;
            // 
            // colBirimFiyat
            // 
            colBirimFiyat.Caption = "Birim Fiyat";
            colBirimFiyat.DisplayFormat.FormatString = "n4";
            colBirimFiyat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBirimFiyat.FieldName = "UnitPrice";
            colBirimFiyat.GroupFormat.FormatString = "n4";
            colBirimFiyat.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colBirimFiyat.Name = "colBirimFiyat";
            colBirimFiyat.OptionsColumn.AllowEdit = false;
            colBirimFiyat.StatusBarAciklama = null;
            colBirimFiyat.StatusBarKisaYol = null;
            colBirimFiyat.StatusBarKisaYolAciklama = null;
            colBirimFiyat.Visible = true;
            colBirimFiyat.VisibleIndex = 8;
            colBirimFiyat.Width = 125;
            // 
            // colDovizTuru
            // 
            colDovizTuru.Caption = "Dövüz Türü";
            colDovizTuru.FieldName = "CurrencyCode";
            colDovizTuru.Name = "colDovizTuru";
            colDovizTuru.OptionsColumn.AllowEdit = false;
            colDovizTuru.StatusBarAciklama = null;
            colDovizTuru.StatusBarKisaYol = null;
            colDovizTuru.StatusBarKisaYolAciklama = null;
            colDovizTuru.Visible = true;
            colDovizTuru.VisibleIndex = 9;
            colDovizTuru.Width = 125;
            // 
            // colTeslimatDeposu
            // 
            colTeslimatDeposu.Caption = "Teslimat Deposu";
            colTeslimatDeposu.FieldName = "WarehouseName";
            colTeslimatDeposu.Name = "colTeslimatDeposu";
            colTeslimatDeposu.OptionsColumn.AllowEdit = false;
            colTeslimatDeposu.StatusBarAciklama = null;
            colTeslimatDeposu.StatusBarKisaYol = null;
            colTeslimatDeposu.StatusBarKisaYolAciklama = null;
            colTeslimatDeposu.Visible = true;
            colTeslimatDeposu.VisibleIndex = 10;
            colTeslimatDeposu.Width = 125;
            // 
            // colTerminTarihi
            // 
            colTerminTarihi.Caption = "Termin Tarihi";
            colTerminTarihi.FieldName = "DeliveryDate";
            colTerminTarihi.Name = "colTerminTarihi";
            colTerminTarihi.OptionsColumn.AllowEdit = false;
            colTerminTarihi.StatusBarAciklama = null;
            colTerminTarihi.StatusBarKisaYol = null;
            colTerminTarihi.StatusBarKisaYolAciklama = null;
            colTerminTarihi.Visible = true;
            colTerminTarihi.VisibleIndex = 11;
            colTerminTarihi.Width = 125;
            // 
            // SatinalmaSiparisAktarListForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            Font = new Font("Segoe UI", 8.25F);
            IconOptions.ShowIcon = false;
            Name = "SatinalmaSiparisAktarListForm";
            Text = "Satınalma Siparişi Aktar";
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
        private UserControls.Grid.MyGridColumn colKod;
        private UserControls.Grid.MyGridColumn colSiparisTarihi;
        private UserControls.Grid.MyGridColumn colBelgeKodu;
        private UserControls.Grid.MyGridColumn colMalzemeAdi;
        private UserControls.Grid.MyGridColumn colIstenenMiktar;
        private UserControls.Grid.MyGridColumn colGelenMiktar;
        private UserControls.Grid.MyGridColumn colBekleyenMiktar;
        private UserControls.Grid.MyGridColumn colBirim;
        private UserControls.Grid.MyGridColumn colBirimFiyat;
        private UserControls.Grid.MyGridColumn colDovizTuru;
        private UserControls.Grid.MyGridColumn colTeslimatDeposu;
        private UserControls.Grid.MyGridColumn colTerminTarihi;
    }
}