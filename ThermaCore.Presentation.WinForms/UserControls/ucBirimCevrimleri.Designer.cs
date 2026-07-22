namespace ThermaCore.Presentation.WinForms.UserControls
{
    partial class ucBirimCevrimleri
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            myGridControl1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            gvBirimCevrimleri = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colHedefBirim = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colCarpan = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            colBolen = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            colAnaBirim = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvBirimCevrimleri).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemGridLookUpEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemGridLookUpEdit1View).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSpinEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSpinEdit2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).BeginInit();
            SuspendLayout();
            // 
            // myGridControl1
            // 
            myGridControl1.Dock = DockStyle.Fill;
            myGridControl1.Location = new Point(0, 0);
            myGridControl1.MainView = gvBirimCevrimleri;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemGridLookUpEdit1, repositoryItemSpinEdit1, repositoryItemSpinEdit2, repositoryItemCheckEdit1 });
            myGridControl1.Size = new Size(989, 377);
            myGridControl1.TabIndex = 0;
            myGridControl1.UseEmbeddedNavigator = true;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvBirimCevrimleri });
            // 
            // gvBirimCevrimleri
            // 
            gvBirimCevrimleri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colHedefBirim, colCarpan, colBolen, colAnaBirim });
            gvBirimCevrimleri.GridControl = myGridControl1;
            gvBirimCevrimleri.Name = "gvBirimCevrimleri";
            gvBirimCevrimleri.OptionsMenu.EnableColumnMenu = false;
            gvBirimCevrimleri.OptionsMenu.EnableFooterMenu = false;
            gvBirimCevrimleri.OptionsMenu.EnableGroupPanelMenu = false;
            gvBirimCevrimleri.OptionsNavigation.EnterMoveNextColumn = true;
            gvBirimCevrimleri.OptionsPrint.AutoWidth = false;
            gvBirimCevrimleri.OptionsPrint.PrintFooter = false;
            gvBirimCevrimleri.OptionsPrint.PrintGroupFooter = false;
            gvBirimCevrimleri.OptionsView.ColumnAutoWidth = false;
            gvBirimCevrimleri.OptionsView.EnableAppearanceEvenRow = true;
            gvBirimCevrimleri.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            gvBirimCevrimleri.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gvBirimCevrimleri.OptionsView.ShowAutoFilterRow = true;
            gvBirimCevrimleri.OptionsView.ShowGroupPanel = false;
            gvBirimCevrimleri.OptionsView.ShowViewCaption = true;
            gvBirimCevrimleri.StatusBarAciklama = null;
            gvBirimCevrimleri.StatusBarKisaYol = null;
            gvBirimCevrimleri.StatusBarKisaYolAciklama = null;
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
            // colHedefBirim
            // 
            colHedefBirim.Caption = "Hedef Birim";
            colHedefBirim.ColumnEdit = repositoryItemGridLookUpEdit1;
            colHedefBirim.FieldName = "UnitId";
            colHedefBirim.Name = "colHedefBirim";
            colHedefBirim.StatusBarAciklama = null;
            colHedefBirim.StatusBarKisaYol = null;
            colHedefBirim.StatusBarKisaYolAciklama = null;
            colHedefBirim.Visible = true;
            colHedefBirim.VisibleIndex = 0;
            colHedefBirim.Width = 125;
            // 
            // colCarpan
            // 
            colCarpan.Caption = "Çarpan";
            colCarpan.ColumnEdit = repositoryItemSpinEdit1;
            colCarpan.FieldName = "Multiplier";
            colCarpan.Name = "colCarpan";
            colCarpan.StatusBarAciklama = null;
            colCarpan.StatusBarKisaYol = null;
            colCarpan.StatusBarKisaYolAciklama = null;
            colCarpan.Visible = true;
            colCarpan.VisibleIndex = 1;
            colCarpan.Width = 125;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            repositoryItemGridLookUpEdit1.AutoHeight = false;
            repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            repositoryItemGridLookUpEdit1.PopupView = repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemSpinEdit1
            // 
            repositoryItemSpinEdit1.AutoHeight = false;
            repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // colBolen
            // 
            colBolen.Caption = "Bölen";
            colBolen.ColumnEdit = repositoryItemSpinEdit2;
            colBolen.FieldName = "Divisor";
            colBolen.Name = "colBolen";
            colBolen.StatusBarAciklama = null;
            colBolen.StatusBarKisaYol = null;
            colBolen.StatusBarKisaYolAciklama = null;
            colBolen.Visible = true;
            colBolen.VisibleIndex = 2;
            colBolen.Width = 125;
            // 
            // repositoryItemSpinEdit2
            // 
            repositoryItemSpinEdit2.AutoHeight = false;
            repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // colAnaBirim
            // 
            colAnaBirim.Caption = "Ana Birim";
            colAnaBirim.ColumnEdit = repositoryItemCheckEdit1;
            colAnaBirim.FieldName = "IsMainUnit";
            colAnaBirim.Name = "colAnaBirim";
            colAnaBirim.StatusBarAciklama = null;
            colAnaBirim.StatusBarKisaYol = null;
            colAnaBirim.StatusBarKisaYolAciklama = null;
            colAnaBirim.Visible = true;
            colAnaBirim.VisibleIndex = 3;
            colAnaBirim.Width = 125;
            // 
            // repositoryItemCheckEdit1
            // 
            repositoryItemCheckEdit1.AutoHeight = false;
            repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // ucBirimCevrimleri
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(myGridControl1);
            Name = "ucBirimCevrimleri";
            Size = new Size(989, 377);
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvBirimCevrimleri).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemGridLookUpEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemGridLookUpEdit1View).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSpinEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemSpinEdit2).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Grid.MyGridControl myGridControl1;
        private Grid.MyGridView gvBirimCevrimleri;
        private Grid.MyGridColumn colId;
        private Grid.MyGridColumn colHedefBirim;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private Grid.MyGridColumn colCarpan;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private Grid.MyGridColumn colBolen;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private Grid.MyGridColumn colAnaBirim;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}
