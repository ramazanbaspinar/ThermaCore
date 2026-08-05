namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BaglantiElemaniForms
{
    partial class BaglantiElemaniListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaglantiElemaniListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colBaglantiElemaniAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colElemanTipi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colMateryal = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKaliteStandarti = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colAgirlik = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colAciklama = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colBaglantiElemaniAdi, colElemanTipi, colMateryal, colKaliteStandarti, colAgirlik, colAciklama });
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
            myGridView1.ViewCaption = "Bağlantı Elemanları Tanımları";
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
            // colBaglantiElemaniAdi
            // 
            colBaglantiElemaniAdi.Caption = "Bağlantı Elemanı Adı";
            colBaglantiElemaniAdi.FieldName = "Name";
            colBaglantiElemaniAdi.Name = "colBaglantiElemaniAdi";
            colBaglantiElemaniAdi.OptionsColumn.AllowEdit = false;
            colBaglantiElemaniAdi.StatusBarAciklama = null;
            colBaglantiElemaniAdi.StatusBarKisaYol = null;
            colBaglantiElemaniAdi.StatusBarKisaYolAciklama = null;
            colBaglantiElemaniAdi.Visible = true;
            colBaglantiElemaniAdi.VisibleIndex = 1;
            colBaglantiElemaniAdi.Width = 150;
            // 
            // colElemanTipi
            // 
            colElemanTipi.Caption = "Eleman Tipi";
            colElemanTipi.FieldName = "FastenerType";
            colElemanTipi.Name = "colElemanTipi";
            colElemanTipi.OptionsColumn.AllowEdit = false;
            colElemanTipi.StatusBarAciklama = null;
            colElemanTipi.StatusBarKisaYol = null;
            colElemanTipi.StatusBarKisaYolAciklama = null;
            colElemanTipi.Visible = true;
            colElemanTipi.VisibleIndex = 2;
            colElemanTipi.Width = 150;
            // 
            // colMateryal
            // 
            colMateryal.Caption = "Materyal";
            colMateryal.FieldName = "MaterialType";
            colMateryal.Name = "colMateryal";
            colMateryal.OptionsColumn.AllowEdit = false;
            colMateryal.StatusBarAciklama = null;
            colMateryal.StatusBarKisaYol = null;
            colMateryal.StatusBarKisaYolAciklama = null;
            colMateryal.Visible = true;
            colMateryal.VisibleIndex = 3;
            colMateryal.Width = 150;
            // 
            // colKaliteStandarti
            // 
            colKaliteStandarti.Caption = "Kalite Standartı";
            colKaliteStandarti.FieldName = "Standard";
            colKaliteStandarti.Name = "colKaliteStandarti";
            colKaliteStandarti.OptionsColumn.AllowEdit = false;
            colKaliteStandarti.StatusBarAciklama = null;
            colKaliteStandarti.StatusBarKisaYol = null;
            colKaliteStandarti.StatusBarKisaYolAciklama = null;
            colKaliteStandarti.Visible = true;
            colKaliteStandarti.VisibleIndex = 4;
            colKaliteStandarti.Width = 150;
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
            // BaglantiElemaniListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "BaglantiElemaniListForm";
            Text = "Bağlantı Elemanı Tanımları";
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
        private UserControls.Grid.MyGridColumn colBaglantiElemaniAdi;
        private UserControls.Grid.MyGridColumn colElemanTipi;
        private UserControls.Grid.MyGridColumn colMateryal;
        private UserControls.Grid.MyGridColumn colKaliteStandarti;
        private UserControls.Grid.MyGridColumn colAgirlik;
        private UserControls.Grid.MyGridColumn colAciklama;
    }
}
