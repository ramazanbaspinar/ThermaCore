namespace WinBeyazEsya.Presentation.WinForms.Forms.StokYonetimiForms
{
    partial class StokBakiyeListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokBakiyeListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colDepoAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMalzemeKodu = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMalzemeAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBirim = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colGirenMiktar = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colCikanMiktar = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKalanBakiye = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colDepoAdi, colMalzemeKodu, colMalzemeAdi, colBirim, colGirenMiktar, colCikanMiktar, colKalanBakiye });
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
            myGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] { new DevExpress.XtraGrid.Columns.GridColumnSortInfo(colDepoAdi, DevExpress.Data.ColumnSortOrder.Ascending) });
            myGridView1.StatusBarAciklama = null;
            myGridView1.StatusBarKisaYol = null;
            myGridView1.StatusBarKisaYolAciklama = null;
            myGridView1.ViewCaption = "Stok Bakiye ve Depo Durum İzleme";
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
            // colDepoAdi
            // 
            colDepoAdi.Caption = "Depo Adı";
            colDepoAdi.FieldName = "WarehouseName";
            colDepoAdi.Name = "colDepoAdi";
            colDepoAdi.OptionsColumn.AllowEdit = false;
            colDepoAdi.StatusBarAciklama = null;
            colDepoAdi.StatusBarKisaYol = null;
            colDepoAdi.StatusBarKisaYolAciklama = null;
            colDepoAdi.Visible = true;
            colDepoAdi.VisibleIndex = 0;
            colDepoAdi.Width = 125;
            // 
            // colMalzemeKodu
            // 
            colMalzemeKodu.Caption = "Malzeme Kodu";
            colMalzemeKodu.FieldName = "MaterialCode";
            colMalzemeKodu.Name = "colMalzemeKodu";
            colMalzemeKodu.OptionsColumn.AllowEdit = false;
            colMalzemeKodu.StatusBarAciklama = null;
            colMalzemeKodu.StatusBarKisaYol = null;
            colMalzemeKodu.StatusBarKisaYolAciklama = null;
            colMalzemeKodu.Visible = true;
            colMalzemeKodu.VisibleIndex = 0;
            colMalzemeKodu.Width = 125;
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
            colMalzemeAdi.VisibleIndex = 1;
            colMalzemeAdi.Width = 125;
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
            colBirim.Visible = true;
            colBirim.VisibleIndex = 2;
            colBirim.Width = 125;
            // 
            // colGirenMiktar
            // 
            colGirenMiktar.Caption = "Giren Miktar";
            colGirenMiktar.DisplayFormat.FormatString = "n2";
            colGirenMiktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colGirenMiktar.FieldName = "TotalIn";
            colGirenMiktar.GroupFormat.FormatString = "n2";
            colGirenMiktar.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colGirenMiktar.Name = "colGirenMiktar";
            colGirenMiktar.OptionsColumn.AllowEdit = false;
            colGirenMiktar.StatusBarAciklama = null;
            colGirenMiktar.StatusBarKisaYol = null;
            colGirenMiktar.StatusBarKisaYolAciklama = null;
            colGirenMiktar.Visible = true;
            colGirenMiktar.VisibleIndex = 3;
            colGirenMiktar.Width = 125;
            // 
            // colCikanMiktar
            // 
            colCikanMiktar.Caption = "Çıkan Miktar";
            colCikanMiktar.DisplayFormat.FormatString = "n2";
            colCikanMiktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCikanMiktar.FieldName = "TotalOut";
            colCikanMiktar.GroupFormat.FormatString = "n2";
            colCikanMiktar.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colCikanMiktar.Name = "colCikanMiktar";
            colCikanMiktar.OptionsColumn.AllowEdit = false;
            colCikanMiktar.StatusBarAciklama = null;
            colCikanMiktar.StatusBarKisaYol = null;
            colCikanMiktar.StatusBarKisaYolAciklama = null;
            colCikanMiktar.Visible = true;
            colCikanMiktar.VisibleIndex = 4;
            colCikanMiktar.Width = 125;
            // 
            // colKalanBakiye
            // 
            colKalanBakiye.AppearanceCell.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            colKalanBakiye.AppearanceCell.Options.UseFont = true;
            colKalanBakiye.Caption = "Kalan Bakiye";
            colKalanBakiye.DisplayFormat.FormatString = "n2";
            colKalanBakiye.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colKalanBakiye.FieldName = "Balance";
            colKalanBakiye.GroupFormat.FormatString = "n2";
            colKalanBakiye.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colKalanBakiye.Name = "colKalanBakiye";
            colKalanBakiye.OptionsColumn.AllowEdit = false;
            colKalanBakiye.StatusBarAciklama = null;
            colKalanBakiye.StatusBarKisaYol = null;
            colKalanBakiye.StatusBarKisaYolAciklama = null;
            colKalanBakiye.Visible = true;
            colKalanBakiye.VisibleIndex = 5;
            colKalanBakiye.Width = 125;
            // 
            // StokBakiyeListForm
            // 
            Appearance.Options.UseFont = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            Font = new Font("Segoe UI", 8.25F);
            IconOptions.ShowIcon = false;
            Name = "StokBakiyeListForm";
            Text = "Stok Bakiye ve Depo Durum İzleme";
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
        private UserControls.Grid.MyGridColumn colDepoAdi;
        private UserControls.Grid.MyGridColumn colMalzemeKodu;
        private UserControls.Grid.MyGridColumn colMalzemeAdi;
        private UserControls.Grid.MyGridColumn colBirim;
        private UserControls.Grid.MyGridColumn colGirenMiktar;
        private UserControls.Grid.MyGridColumn colCikanMiktar;
        private UserControls.Grid.MyGridColumn colKalanBakiye;
    }
}