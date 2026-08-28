namespace WinBeyazEsya.Presentation.WinForms.Forms.SatinAlmaForms
{
    partial class SatinalmaSiparisSevkBilgileriListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SatinalmaSiparisSevkBilgileriListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMalzeme = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMiktar = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBirim = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTarih = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colIrsaliyeKodu = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBelgeNo = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colMalzeme, colMiktar, colBirim, colTarih, colIrsaliyeKodu, colBelgeNo });
            myGridView1.GridControl = myGridControl1;
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
            myGridView1.StatusBarAciklama = null;
            myGridView1.StatusBarKisaYol = null;
            myGridView1.StatusBarKisaYolAciklama = null;
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
            // colMalzeme
            // 
            colMalzeme.Caption = "Malzeme";
            colMalzeme.FieldName = "MaterialName";
            colMalzeme.Name = "colMalzeme";
            colMalzeme.OptionsColumn.AllowEdit = false;
            colMalzeme.StatusBarAciklama = null;
            colMalzeme.StatusBarKisaYol = null;
            colMalzeme.StatusBarKisaYolAciklama = null;
            colMalzeme.Visible = true;
            colMalzeme.VisibleIndex = 0;
            colMalzeme.Width = 125;
            // 
            // colMiktar
            // 
            colMiktar.Caption = "Miktar";
            colMiktar.DisplayFormat.FormatString = "n2";
            colMiktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colMiktar.FieldName = "Quantity";
            colMiktar.GroupFormat.FormatString = "n2";
            colMiktar.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colMiktar.Name = "colMiktar";
            colMiktar.OptionsColumn.AllowEdit = false;
            colMiktar.StatusBarAciklama = null;
            colMiktar.StatusBarKisaYol = null;
            colMiktar.StatusBarKisaYolAciklama = null;
            colMiktar.Visible = true;
            colMiktar.VisibleIndex = 1;
            colMiktar.Width = 125;
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
            // colTarih
            // 
            colTarih.Caption = "Tarih";
            colTarih.FieldName = "ReceiptDate";
            colTarih.Name = "colTarih";
            colTarih.OptionsColumn.AllowEdit = false;
            colTarih.StatusBarAciklama = null;
            colTarih.StatusBarKisaYol = null;
            colTarih.StatusBarKisaYolAciklama = null;
            colTarih.Visible = true;
            colTarih.VisibleIndex = 3;
            colTarih.Width = 125;
            // 
            // colIrsaliyeKodu
            // 
            colIrsaliyeKodu.Caption = "İrsaliye Kodu";
            colIrsaliyeKodu.FieldName = "ReceiptCode";
            colIrsaliyeKodu.Name = "colIrsaliyeKodu";
            colIrsaliyeKodu.OptionsColumn.AllowEdit = false;
            colIrsaliyeKodu.StatusBarAciklama = null;
            colIrsaliyeKodu.StatusBarKisaYol = null;
            colIrsaliyeKodu.StatusBarKisaYolAciklama = null;
            colIrsaliyeKodu.Visible = true;
            colIrsaliyeKodu.VisibleIndex = 4;
            colIrsaliyeKodu.Width = 125;
            // 
            // colBelgeNo
            // 
            colBelgeNo.Caption = "Belge No";
            colBelgeNo.FieldName = "DocumentNo";
            colBelgeNo.Name = "colBelgeNo";
            colBelgeNo.OptionsColumn.AllowEdit = false;
            colBelgeNo.StatusBarAciklama = null;
            colBelgeNo.StatusBarKisaYol = null;
            colBelgeNo.StatusBarKisaYolAciklama = null;
            colBelgeNo.Visible = true;
            colBelgeNo.VisibleIndex = 5;
            colBelgeNo.Width = 125;
            // 
            // SatinalmaSiparisSevkBilgileriListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "SatinalmaSiparisSevkBilgileriListForm";
            Text = "Sevk Bilgileri";
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
        private UserControls.Grid.MyGridColumn colMalzeme;
        private UserControls.Grid.MyGridColumn colMiktar;
        private UserControls.Grid.MyGridColumn colBirim;
        private UserControls.Grid.MyGridColumn colTarih;
        private UserControls.Grid.MyGridColumn colIrsaliyeKodu;
        private UserControls.Grid.MyGridColumn colBelgeNo;
    }
}