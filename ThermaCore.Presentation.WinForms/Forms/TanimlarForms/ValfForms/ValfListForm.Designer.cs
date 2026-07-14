namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.ValfForms
{
    partial class ValfListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValfListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colValfAdi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colValfTipi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colGazTipi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBasinc = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBaglantiOlcusu = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colCalismaSicaklikAraligi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(814, 135);
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
            longNavigator1.Location = new Point(0, 371);
            longNavigator1.Name = "longNavigator1";
            longNavigator1.Size = new Size(814, 30);
            longNavigator1.TabIndex = 2;
            // 
            // myGridControl1
            // 
            myGridControl1.Dock = DockStyle.Fill;
            myGridControl1.Location = new Point(0, 135);
            myGridControl1.MainView = myGridView1;
            myGridControl1.MenuManager = ribbon;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.Size = new Size(814, 236);
            myGridControl1.TabIndex = 3;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { myGridView1 });
            // 
            // myGridView1
            // 
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colValfAdi, colValfTipi, colGazTipi, colBasinc, colBaglantiOlcusu, colCalismaSicaklikAraligi });
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
            myGridView1.OptionsView.ShowViewCaption = true;
            myGridView1.StatusBarAciklama = null;
            myGridView1.StatusBarKisaYol = null;
            myGridView1.StatusBarKisaYolAciklama = null;
            myGridView1.ViewCaption = "Valf Tanımları";
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
            colKod.Width = 120;
            // 
            // colValfAdi
            // 
            colValfAdi.Caption = "Valf Adı";
            colValfAdi.FieldName = "Name";
            colValfAdi.Name = "colValfAdi";
            colValfAdi.OptionsColumn.AllowEdit = false;
            colValfAdi.StatusBarAciklama = null;
            colValfAdi.StatusBarKisaYol = null;
            colValfAdi.StatusBarKisaYolAciklama = null;
            colValfAdi.Visible = true;
            colValfAdi.VisibleIndex = 1;
            colValfAdi.Width = 150;
            // 
            // colValfTipi
            // 
            colValfTipi.Caption = "Valf Tipi";
            colValfTipi.FieldName = "ValveTypeName";
            colValfTipi.Name = "colValfTipi";
            colValfTipi.OptionsColumn.AllowEdit = false;
            colValfTipi.StatusBarAciklama = null;
            colValfTipi.StatusBarKisaYol = null;
            colValfTipi.StatusBarKisaYolAciklama = null;
            colValfTipi.Visible = true;
            colValfTipi.VisibleIndex = 2;
            colValfTipi.Width = 150;
            // 
            // colGazTipi
            // 
            colGazTipi.Caption = "Gaz Tipi";
            colGazTipi.FieldName = "GasTypeName";
            colGazTipi.Name = "colGazTipi";
            colGazTipi.OptionsColumn.AllowEdit = false;
            colGazTipi.StatusBarAciklama = null;
            colGazTipi.StatusBarKisaYol = null;
            colGazTipi.StatusBarKisaYolAciklama = null;
            colGazTipi.Visible = true;
            colGazTipi.VisibleIndex = 3;
            colGazTipi.Width = 150;
            // 
            // colBasinc
            // 
            colBasinc.Caption = "Maksimum Basınç (mbar)";
            colBasinc.FieldName = "MaxPressureMbar";
            colBasinc.Name = "colBasinc";
            colBasinc.OptionsColumn.AllowEdit = false;
            colBasinc.StatusBarAciklama = null;
            colBasinc.StatusBarKisaYol = null;
            colBasinc.StatusBarKisaYolAciklama = null;
            colBasinc.Visible = true;
            colBasinc.VisibleIndex = 4;
            colBasinc.Width = 150;
            // 
            // colBaglantiOlcusu
            // 
            colBaglantiOlcusu.Caption = "Bağlantı Ölçüsü";
            colBaglantiOlcusu.FieldName = "ConnectionSize";
            colBaglantiOlcusu.Name = "colBaglantiOlcusu";
            colBaglantiOlcusu.OptionsColumn.AllowEdit = false;
            colBaglantiOlcusu.StatusBarAciklama = null;
            colBaglantiOlcusu.StatusBarKisaYol = null;
            colBaglantiOlcusu.StatusBarKisaYolAciklama = null;
            colBaglantiOlcusu.Visible = true;
            colBaglantiOlcusu.VisibleIndex = 5;
            colBaglantiOlcusu.Width = 150;
            // 
            // colCalismaSicaklikAraligi
            // 
            colCalismaSicaklikAraligi.Caption = "Çalışma Sıcaklık Aralığı";
            colCalismaSicaklikAraligi.FieldName = "TemperatureRange";
            colCalismaSicaklikAraligi.Name = "colCalismaSicaklikAraligi";
            colCalismaSicaklikAraligi.OptionsColumn.AllowEdit = false;
            colCalismaSicaklikAraligi.StatusBarAciklama = null;
            colCalismaSicaklikAraligi.StatusBarKisaYol = null;
            colCalismaSicaklikAraligi.StatusBarKisaYolAciklama = null;
            colCalismaSicaklikAraligi.Visible = true;
            colCalismaSicaklikAraligi.VisibleIndex = 6;
            colCalismaSicaklikAraligi.Width = 150;
            // 
            // ValfListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "ValfListForm";
            Text = "Valf Tanımları";
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
        private UserControls.Grid.MyGridColumn colValfAdi;
        private UserControls.Grid.MyGridColumn colValfTipi;
        private UserControls.Grid.MyGridColumn colGazTipi;
        private UserControls.Grid.MyGridColumn colBasinc;
        private UserControls.Grid.MyGridColumn colBaglantiOlcusu;
        private UserControls.Grid.MyGridColumn colCalismaSicaklikAraligi;
    }
}