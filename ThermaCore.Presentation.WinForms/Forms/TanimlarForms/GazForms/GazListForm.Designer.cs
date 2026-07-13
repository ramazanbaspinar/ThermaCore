namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.GazForms
{
    partial class GazListForm
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
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMuslukAdi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colGazTipi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colEmniyetVentili = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colCikisAcisi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMilTipi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(711, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // longNavigator1
            // 
            longNavigator1.Dock = DockStyle.Bottom;
            longNavigator1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            longNavigator1.Location = new Point(0, 406);
            longNavigator1.Name = "longNavigator1";
            longNavigator1.Size = new Size(711, 30);
            longNavigator1.TabIndex = 2;
            // 
            // myGridControl1
            // 
            myGridControl1.Dock = DockStyle.Fill;
            myGridControl1.Location = new Point(0, 135);
            myGridControl1.MainView = myGridView1;
            myGridControl1.MenuManager = ribbon;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.Size = new Size(711, 271);
            myGridControl1.TabIndex = 3;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { myGridView1 });
            // 
            // myGridView1
            // 
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colMuslukAdi, colGazTipi, colEmniyetVentili, colCikisAcisi, colMilTipi });
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
            myGridView1.ViewCaption = "Gaz Tanımları";
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
            // colMuslukAdi
            // 
            colMuslukAdi.Caption = "Musluk Adı";
            colMuslukAdi.FieldName = "Name";
            colMuslukAdi.Name = "colMuslukAdi";
            colMuslukAdi.OptionsColumn.AllowEdit = false;
            colMuslukAdi.StatusBarAciklama = null;
            colMuslukAdi.StatusBarKisaYol = null;
            colMuslukAdi.StatusBarKisaYolAciklama = null;
            colMuslukAdi.Visible = true;
            colMuslukAdi.VisibleIndex = 1;
            colMuslukAdi.Width = 150;
            // 
            // colGazTipi
            // 
            colGazTipi.Caption = "Gaz Tipi";
            colGazTipi.FieldName = "GasType";
            colGazTipi.Name = "colGazTipi";
            colGazTipi.OptionsColumn.AllowEdit = false;
            colGazTipi.StatusBarAciklama = null;
            colGazTipi.StatusBarKisaYol = null;
            colGazTipi.StatusBarKisaYolAciklama = null;
            colGazTipi.Visible = true;
            colGazTipi.VisibleIndex = 2;
            colGazTipi.Width = 150;
            // 
            // colEmniyetVentili
            // 
            colEmniyetVentili.Caption = "Emniyet Ventili";
            colEmniyetVentili.FieldName = "HasSafetyValve";
            colEmniyetVentili.Name = "colEmniyetVentili";
            colEmniyetVentili.OptionsColumn.AllowEdit = false;
            colEmniyetVentili.StatusBarAciklama = null;
            colEmniyetVentili.StatusBarKisaYol = null;
            colEmniyetVentili.StatusBarKisaYolAciklama = null;
            colEmniyetVentili.Visible = true;
            colEmniyetVentili.VisibleIndex = 3;
            colEmniyetVentili.Width = 150;
            // 
            // colCikisAcisi
            // 
            colCikisAcisi.Caption = "Çıkış Açısı (Derece)";
            colCikisAcisi.FieldName = "OutletAngle";
            colCikisAcisi.Name = "colCikisAcisi";
            colCikisAcisi.OptionsColumn.AllowEdit = false;
            colCikisAcisi.StatusBarAciklama = null;
            colCikisAcisi.StatusBarKisaYol = null;
            colCikisAcisi.StatusBarKisaYolAciklama = null;
            colCikisAcisi.Visible = true;
            colCikisAcisi.VisibleIndex = 4;
            colCikisAcisi.Width = 150;
            // 
            // colMilTipi
            // 
            colMilTipi.Caption = "Mil Tipi";
            colMilTipi.FieldName = "ShaftType";
            colMilTipi.Name = "colMilTipi";
            colMilTipi.OptionsColumn.AllowEdit = false;
            colMilTipi.StatusBarAciklama = null;
            colMilTipi.StatusBarKisaYol = null;
            colMilTipi.StatusBarKisaYolAciklama = null;
            colMilTipi.Visible = true;
            colMilTipi.VisibleIndex = 5;
            colMilTipi.Width = 150;
            // 
            // GazListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 460);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "GazListForm";
            Text = "Gaz Tanımları";
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
        private UserControls.Grid.MyGridColumn colMuslukAdi;
        private UserControls.Grid.MyGridColumn colGazTipi;
        private UserControls.Grid.MyGridColumn colEmniyetVentili;
        private UserControls.Grid.MyGridColumn colCikisAcisi;
        private UserControls.Grid.MyGridColumn colMilTipi;
    }
}