namespace ThermaCore.Presentation.WinForms.Forms.RezistansForms
{
    partial class RezistansListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RezistansListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colRezistansAdi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colVolt = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colWatt = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBoruBoyu = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBoruCapi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colRezistansAdi, colVolt, colWatt, colBoruBoyu, colBoruCapi });
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
            myGridView1.ViewCaption = "Rezistans Tanımları";
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
            // colRezistansAdi
            // 
            colRezistansAdi.Caption = "Rezistans Adı";
            colRezistansAdi.FieldName = "Name";
            colRezistansAdi.Name = "colRezistansAdi";
            colRezistansAdi.OptionsColumn.AllowEdit = false;
            colRezistansAdi.StatusBarAciklama = null;
            colRezistansAdi.StatusBarKisaYol = null;
            colRezistansAdi.StatusBarKisaYolAciklama = null;
            colRezistansAdi.Visible = true;
            colRezistansAdi.VisibleIndex = 1;
            colRezistansAdi.Width = 150;
            // 
            // colVolt
            // 
            colVolt.Caption = "Volt";
            colVolt.FieldName = "Voltage";
            colVolt.Name = "colVolt";
            colVolt.OptionsColumn.AllowEdit = false;
            colVolt.StatusBarAciklama = null;
            colVolt.StatusBarKisaYol = null;
            colVolt.StatusBarKisaYolAciklama = null;
            colVolt.Visible = true;
            colVolt.VisibleIndex = 2;
            colVolt.Width = 150;
            // 
            // colWatt
            // 
            colWatt.Caption = "Watt";
            colWatt.FieldName = "PowerWatt";
            colWatt.Name = "colWatt";
            colWatt.OptionsColumn.AllowEdit = false;
            colWatt.StatusBarAciklama = null;
            colWatt.StatusBarKisaYol = null;
            colWatt.StatusBarKisaYolAciklama = null;
            colWatt.Visible = true;
            colWatt.VisibleIndex = 3;
            colWatt.Width = 150;
            // 
            // colBoruBoyu
            // 
            colBoruBoyu.Caption = "Boru Boyu(mm)";
            colBoruBoyu.FieldName = "LengthMm";
            colBoruBoyu.Name = "colBoruBoyu";
            colBoruBoyu.OptionsColumn.AllowEdit = false;
            colBoruBoyu.StatusBarAciklama = null;
            colBoruBoyu.StatusBarKisaYol = null;
            colBoruBoyu.StatusBarKisaYolAciklama = null;
            colBoruBoyu.Visible = true;
            colBoruBoyu.VisibleIndex = 4;
            colBoruBoyu.Width = 150;
            // 
            // colBoruCapi
            // 
            colBoruCapi.Caption = "Boru Capı(mm)";
            colBoruCapi.FieldName = "TubeDiameterMm";
            colBoruCapi.Name = "colBoruCapi";
            colBoruCapi.OptionsColumn.AllowEdit = false;
            colBoruCapi.StatusBarAciklama = null;
            colBoruCapi.StatusBarKisaYol = null;
            colBoruCapi.StatusBarKisaYolAciklama = null;
            colBoruCapi.Visible = true;
            colBoruCapi.VisibleIndex = 5;
            colBoruCapi.Width = 150;
            // 
            // RezistansListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "RezistansListForm";
            Text = "Rezistans Tanımları";
            Load += RezistansListForm_Load;
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
        private UserControls.Grid.MyGridColumn colRezistansAdi;
        private UserControls.Grid.MyGridColumn colVolt;
        private UserControls.Grid.MyGridColumn colWatt;
        private UserControls.Grid.MyGridColumn colBoruBoyu;
        private UserControls.Grid.MyGridColumn colBoruCapi;
    }
}