namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.RakorForms
{
    partial class RakorListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RakorListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colRakorAdi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colRakorTipi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMateryal = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colDisOlcusu = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colAgirlik = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colAciklama = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colRakorAdi, colRakorTipi, colMateryal, colDisOlcusu, colAgirlik, colAciklama });
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
            myGridView1.ViewCaption = "Rakor Tanımları";
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
            // colRakorAdi
            // 
            colRakorAdi.Caption = "Rakor Adı";
            colRakorAdi.FieldName = "Name";
            colRakorAdi.Name = "colRakorAdi";
            colRakorAdi.OptionsColumn.AllowEdit = false;
            colRakorAdi.StatusBarAciklama = null;
            colRakorAdi.StatusBarKisaYol = null;
            colRakorAdi.StatusBarKisaYolAciklama = null;
            colRakorAdi.Visible = true;
            colRakorAdi.VisibleIndex = 1;
            colRakorAdi.Width = 150;
            // 
            // colRakorTipi
            // 
            colRakorTipi.Caption = "Rakor Tipi";
            colRakorTipi.FieldName = "FittingTypeName";
            colRakorTipi.Name = "colRakorTipi";
            colRakorTipi.OptionsColumn.AllowEdit = false;
            colRakorTipi.StatusBarAciklama = null;
            colRakorTipi.StatusBarKisaYol = null;
            colRakorTipi.StatusBarKisaYolAciklama = null;
            colRakorTipi.Visible = true;
            colRakorTipi.VisibleIndex = 2;
            colRakorTipi.Width = 150;
            // 
            // colMateryal
            // 
            colMateryal.Caption = "Materyal";
            colMateryal.FieldName = "MaterialTypeName";
            colMateryal.Name = "colMateryal";
            colMateryal.OptionsColumn.AllowEdit = false;
            colMateryal.StatusBarAciklama = null;
            colMateryal.StatusBarKisaYol = null;
            colMateryal.StatusBarKisaYolAciklama = null;
            colMateryal.Visible = true;
            colMateryal.VisibleIndex = 3;
            colMateryal.Width = 150;
            // 
            // colDisOlcusu
            // 
            colDisOlcusu.Caption = "Diş Ölçüsü";
            colDisOlcusu.FieldName = "ThreadSize";
            colDisOlcusu.Name = "colDisOlcusu";
            colDisOlcusu.OptionsColumn.AllowEdit = false;
            colDisOlcusu.StatusBarAciklama = null;
            colDisOlcusu.StatusBarKisaYol = null;
            colDisOlcusu.StatusBarKisaYolAciklama = null;
            colDisOlcusu.Visible = true;
            colDisOlcusu.VisibleIndex = 4;
            colDisOlcusu.Width = 150;
            // 
            // colAgirlik
            // 
            colAgirlik.Caption = "Ağırlık (Gr)";
            colAgirlik.FieldName = "WeightGr";
            colAgirlik.Name = "colAgirlik";
            colAgirlik.OptionsColumn.AllowEdit = false;
            colAgirlik.StatusBarAciklama = null;
            colAgirlik.StatusBarKisaYol = null;
            colAgirlik.StatusBarKisaYolAciklama = null;
            colAgirlik.Visible = true;
            colAgirlik.VisibleIndex = 5;
            colAgirlik.Width = 150;
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
            colAciklama.VisibleIndex = 6;
            colAciklama.Width = 150;
            // 
            // RakorListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "RakorListForm";
            Text = "Rakor Tanımları";
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
        private UserControls.Grid.MyGridColumn colRakorAdi;
        private UserControls.Grid.MyGridColumn colRakorTipi;
        private UserControls.Grid.MyGridColumn colMateryal;
        private UserControls.Grid.MyGridColumn colDisOlcusu;
        private UserControls.Grid.MyGridColumn colAgirlik;
        private UserControls.Grid.MyGridColumn colAciklama;
    }
}