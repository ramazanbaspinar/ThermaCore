namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.KurlarForms
{
    partial class KurListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KurListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControlPro1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridViewPro1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTarih = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colDoviz = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colGecerliAlis = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colGecerliSatis = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTcmbAlis = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTcmbSatis = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridControlPro1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridViewPro1).BeginInit();
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
            // myGridControlPro1
            // 
            myGridControlPro1.Dock = DockStyle.Fill;
            myGridControlPro1.Location = new Point(0, 135);
            myGridControlPro1.MainView = myGridViewPro1;
            myGridControlPro1.MenuManager = ribbon;
            myGridControlPro1.Name = "myGridControlPro1";
            myGridControlPro1.Size = new Size(814, 236);
            myGridControlPro1.TabIndex = 3;
            myGridControlPro1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { myGridViewPro1 });
            // 
            // myGridViewPro1
            // 
            myGridViewPro1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colTarih, colDoviz, colGecerliAlis, colGecerliSatis, colTcmbAlis, colTcmbSatis });
            myGridViewPro1.GridControl = myGridControlPro1;
            myGridViewPro1.GroupCount = 1;
            myGridViewPro1.Name = "myGridViewPro1";
            myGridViewPro1.OptionsMenu.EnableColumnMenu = false;
            myGridViewPro1.OptionsMenu.EnableFooterMenu = false;
            myGridViewPro1.OptionsMenu.EnableGroupPanelMenu = false;
            myGridViewPro1.OptionsNavigation.EnterMoveNextColumn = true;
            myGridViewPro1.OptionsPrint.AutoWidth = false;
            myGridViewPro1.OptionsPrint.PrintFooter = false;
            myGridViewPro1.OptionsPrint.PrintGroupFooter = false;
            myGridViewPro1.OptionsView.ColumnAutoWidth = false;
            myGridViewPro1.OptionsView.EnableAppearanceEvenRow = true;
            myGridViewPro1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            myGridViewPro1.OptionsView.ShowAutoFilterRow = true;
            myGridViewPro1.OptionsView.ShowGroupPanel = false;
            myGridViewPro1.OptionsView.ShowViewCaption = true;
            myGridViewPro1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] { new DevExpress.XtraGrid.Columns.GridColumnSortInfo(colTarih, DevExpress.Data.ColumnSortOrder.Ascending) });
            myGridViewPro1.StatusBarAciklama = null;
            myGridViewPro1.StatusBarKisaYol = null;
            myGridViewPro1.StatusBarKisaYolAciklama = null;
            myGridViewPro1.ViewCaption = "Kur Tanımları";
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
            // colTarih
            // 
            colTarih.Caption = "Tarih";
            colTarih.FieldName = "RateDate";
            colTarih.Name = "colTarih";
            colTarih.OptionsColumn.AllowEdit = false;
            colTarih.StatusBarAciklama = null;
            colTarih.StatusBarKisaYol = null;
            colTarih.StatusBarKisaYolAciklama = null;
            colTarih.Visible = true;
            colTarih.VisibleIndex = 0;
            // 
            // colDoviz
            // 
            colDoviz.Caption = "Döviz";
            colDoviz.FieldName = "CurrencyCode";
            colDoviz.Name = "colDoviz";
            colDoviz.OptionsColumn.AllowEdit = false;
            colDoviz.StatusBarAciklama = null;
            colDoviz.StatusBarKisaYol = null;
            colDoviz.StatusBarKisaYolAciklama = null;
            colDoviz.Visible = true;
            colDoviz.VisibleIndex = 0;
            // 
            // colGecerliAlis
            // 
            colGecerliAlis.Caption = "Geçerli Alış";
            colGecerliAlis.DisplayFormat.FormatString = "n4";
            colGecerliAlis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colGecerliAlis.FieldName = "EffectiveBuyingRate";
            colGecerliAlis.Name = "colGecerliAlis";
            colGecerliAlis.OptionsColumn.AllowEdit = false;
            colGecerliAlis.StatusBarAciklama = null;
            colGecerliAlis.StatusBarKisaYol = null;
            colGecerliAlis.StatusBarKisaYolAciklama = null;
            colGecerliAlis.Visible = true;
            colGecerliAlis.VisibleIndex = 1;
            // 
            // colGecerliSatis
            // 
            colGecerliSatis.Caption = "Geçerli Satış";
            colGecerliSatis.DisplayFormat.FormatString = "n4";
            colGecerliSatis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colGecerliSatis.FieldName = "EffectiveSellingRate";
            colGecerliSatis.Name = "colGecerliSatis";
            colGecerliSatis.OptionsColumn.AllowEdit = false;
            colGecerliSatis.StatusBarAciklama = null;
            colGecerliSatis.StatusBarKisaYol = null;
            colGecerliSatis.StatusBarKisaYolAciklama = null;
            colGecerliSatis.Visible = true;
            colGecerliSatis.VisibleIndex = 2;
            // 
            // colTcmbAlis
            // 
            colTcmbAlis.Caption = "TCMB Alış";
            colTcmbAlis.DisplayFormat.FormatString = "n4";
            colTcmbAlis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTcmbAlis.FieldName = "TcmbBuyingRate";
            colTcmbAlis.Name = "colTcmbAlis";
            colTcmbAlis.OptionsColumn.AllowEdit = false;
            colTcmbAlis.StatusBarAciklama = null;
            colTcmbAlis.StatusBarKisaYol = null;
            colTcmbAlis.StatusBarKisaYolAciklama = null;
            colTcmbAlis.Visible = true;
            colTcmbAlis.VisibleIndex = 3;
            // 
            // colTcmbSatis
            // 
            colTcmbSatis.Caption = "TCMB Satış";
            colTcmbSatis.DisplayFormat.FormatString = "n4";
            colTcmbSatis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colTcmbSatis.FieldName = "TcmbSellingRate";
            colTcmbSatis.Name = "colTcmbSatis";
            colTcmbSatis.OptionsColumn.AllowEdit = false;
            colTcmbSatis.StatusBarAciklama = null;
            colTcmbSatis.StatusBarKisaYol = null;
            colTcmbSatis.StatusBarKisaYolAciklama = null;
            colTcmbSatis.Visible = true;
            colTcmbSatis.VisibleIndex = 4;
            // 
            // KurListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(myGridControlPro1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "KurListForm";
            Text = "Kur Tanımları";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(longNavigator1, 0);
            Controls.SetChildIndex(myGridControlPro1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myGridControlPro1).EndInit();
            ((System.ComponentModel.ISupportInitialize)myGridViewPro1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator longNavigator1;
        private UserControls.Grid.MyGridControl myGridControlPro1;
        private UserControls.Grid.MyGridView myGridViewPro1;
        private UserControls.Grid.MyGridColumn colId;
        private UserControls.Grid.MyGridColumn colTarih;
        private UserControls.Grid.MyGridColumn colDoviz;
        private UserControls.Grid.MyGridColumn colGecerliAlis;
        private UserControls.Grid.MyGridColumn colGecerliSatis;
        private UserControls.Grid.MyGridColumn colTcmbAlis;
        private UserControls.Grid.MyGridColumn colTcmbSatis;
    }
}