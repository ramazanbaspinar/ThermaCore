#pragma warning disable CS8618
namespace ThermaCore.Presentation.WinForms.UserControls.Table
{
    partial class KullaniciBazliYetkiProfilleriTable
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            this.tablo = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            this.colKartTuru = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            this.colGorebilir = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            this.repositoryCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colEkleyebilir = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            this.colDegistirebilir = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            this.colSilebilir = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // insUptNavigator
            // 
            this.insUptNavigator.Location = new System.Drawing.Point(0, 436);
            this.insUptNavigator.Size = new System.Drawing.Size(1003, 24);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.tablo;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryCheck});
            this.grid.Size = new System.Drawing.Size(1003, 436);
            this.grid.TabIndex = 6;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
            // 
            this.tablo.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.tablo.Appearance.Empty.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tablo.Appearance.Empty.Options.UseBackColor = true;
            this.tablo.Appearance.Empty.Options.UseFont = true;
            this.tablo.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.tablo.Appearance.EvenRow.Options.UseBackColor = true;
            this.tablo.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(219)))));
            this.tablo.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tablo.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(219)))));
            this.tablo.Appearance.FocusedRow.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tablo.Appearance.FocusedRow.Options.UseFont = true;
            this.tablo.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tablo.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.tablo.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.tablo.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.tablo.Appearance.HeaderPanel.Options.UseFont = true;
            this.tablo.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(219)))));
            this.tablo.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tablo.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.tablo.Appearance.OddRow.Options.UseBackColor = true;
            this.tablo.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.tablo.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tablo.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.tablo.Appearance.Row.Options.UseBackColor = true;
            this.tablo.Appearance.Row.Options.UseFont = true;
            this.tablo.Appearance.Row.Options.UseForeColor = true;
            this.tablo.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tablo.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.tablo.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tablo.Appearance.SelectedRow.Options.UseForeColor = true;
            this.tablo.Appearance.ViewCaption.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tablo.Appearance.ViewCaption.Options.UseFont = true;
            this.tablo.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKartTuru,
            this.colGorebilir,
            this.colEkleyebilir,
            this.colDegistirebilir,
            this.colSilebilir});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsView.ColumnAutoWidth = false;
            this.tablo.OptionsView.EnableAppearanceEvenRow = true;
            this.tablo.OptionsView.EnableAppearanceOddRow = true;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = null;
            this.tablo.StatusBarKisaYol = null;
            this.tablo.StatusBarKisaYolAciklama = null;
            this.tablo.ViewCaption = "Yetki İşlemleri";
            // 
            // colKartTuru
            // 
            this.colKartTuru.AppearanceCell.Options.UseTextOptions = true;
            this.colKartTuru.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKartTuru.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.colKartTuru.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.colKartTuru.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.colKartTuru.AppearanceHeader.Options.UseBackColor = true;
            this.colKartTuru.AppearanceHeader.Options.UseFont = true;
            this.colKartTuru.AppearanceHeader.Options.UseForeColor = true;
            this.colKartTuru.Caption = "Modül Adı";
            this.colKartTuru.FieldName = "KartTuru";
            this.colKartTuru.Name = "colKartTuru";
            this.colKartTuru.OptionsColumn.AllowEdit = false;
            this.colKartTuru.OptionsFilter.AllowAutoFilter = false;
            this.colKartTuru.OptionsFilter.AllowFilter = false;
            this.colKartTuru.StatusBarAciklama = null;
            this.colKartTuru.StatusBarKisaYol = null;
            this.colKartTuru.StatusBarKisaYolAciklama = null;
            this.colKartTuru.Visible = true;
            this.colKartTuru.VisibleIndex = 0;
            this.colKartTuru.Width = 175;
            // 
            // colGorebilir
            // 
            this.colGorebilir.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.colGorebilir.AppearanceCell.Options.UseFont = true;
            this.colGorebilir.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.colGorebilir.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.colGorebilir.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.colGorebilir.AppearanceHeader.Options.UseBackColor = true;
            this.colGorebilir.AppearanceHeader.Options.UseFont = true;
            this.colGorebilir.AppearanceHeader.Options.UseForeColor = true;
            this.colGorebilir.Caption = "Görebilir";
            this.colGorebilir.ColumnEdit = this.repositoryCheck;
            this.colGorebilir.FieldName = "Gorebilir";
            this.colGorebilir.Name = "colGorebilir";
            this.colGorebilir.OptionsFilter.AllowAutoFilter = false;
            this.colGorebilir.OptionsFilter.AllowFilter = false;
            this.colGorebilir.StatusBarAciklama = null;
            this.colGorebilir.StatusBarKisaYol = null;
            this.colGorebilir.StatusBarKisaYolAciklama = null;
            this.colGorebilir.Visible = true;
            this.colGorebilir.VisibleIndex = 1;
            this.colGorebilir.Width = 175;
            // 
            // repositoryCheck
            // 
            this.repositoryCheck.AutoHeight = false;
            this.repositoryCheck.Name = "repositoryCheck";
            this.repositoryCheck.ValueChecked = ((byte)(1));
            this.repositoryCheck.ValueGrayed = ((byte)(2));
            this.repositoryCheck.ValueUnchecked = ((byte)(0));
            // 
            // colEkleyebilir
            // 
            this.colEkleyebilir.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.colEkleyebilir.AppearanceCell.Options.UseFont = true;
            this.colEkleyebilir.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.colEkleyebilir.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.colEkleyebilir.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.colEkleyebilir.AppearanceHeader.Options.UseBackColor = true;
            this.colEkleyebilir.AppearanceHeader.Options.UseFont = true;
            this.colEkleyebilir.AppearanceHeader.Options.UseForeColor = true;
            this.colEkleyebilir.Caption = "Ekleyebilir";
            this.colEkleyebilir.ColumnEdit = this.repositoryCheck;
            this.colEkleyebilir.FieldName = "Ekleyebilir";
            this.colEkleyebilir.Name = "colEkleyebilir";
            this.colEkleyebilir.OptionsFilter.AllowAutoFilter = false;
            this.colEkleyebilir.OptionsFilter.AllowFilter = false;
            this.colEkleyebilir.StatusBarAciklama = null;
            this.colEkleyebilir.StatusBarKisaYol = null;
            this.colEkleyebilir.StatusBarKisaYolAciklama = null;
            this.colEkleyebilir.Visible = true;
            this.colEkleyebilir.VisibleIndex = 2;
            this.colEkleyebilir.Width = 175;
            // 
            // colDegistirebilir
            // 
            this.colDegistirebilir.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.colDegistirebilir.AppearanceCell.Options.UseFont = true;
            this.colDegistirebilir.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.colDegistirebilir.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.colDegistirebilir.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.colDegistirebilir.AppearanceHeader.Options.UseBackColor = true;
            this.colDegistirebilir.AppearanceHeader.Options.UseFont = true;
            this.colDegistirebilir.AppearanceHeader.Options.UseForeColor = true;
            this.colDegistirebilir.Caption = "Değiştirebilir";
            this.colDegistirebilir.ColumnEdit = this.repositoryCheck;
            this.colDegistirebilir.FieldName = "Degistirebilir";
            this.colDegistirebilir.Name = "colDegistirebilir";
            this.colDegistirebilir.OptionsFilter.AllowAutoFilter = false;
            this.colDegistirebilir.OptionsFilter.AllowFilter = false;
            this.colDegistirebilir.StatusBarAciklama = null;
            this.colDegistirebilir.StatusBarKisaYol = null;
            this.colDegistirebilir.StatusBarKisaYolAciklama = null;
            this.colDegistirebilir.Visible = true;
            this.colDegistirebilir.VisibleIndex = 3;
            this.colDegistirebilir.Width = 175;
            // 
            // colSilebilir
            // 
            this.colSilebilir.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.colSilebilir.AppearanceCell.Options.UseFont = true;
            this.colSilebilir.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.colSilebilir.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.colSilebilir.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.colSilebilir.AppearanceHeader.Options.UseBackColor = true;
            this.colSilebilir.AppearanceHeader.Options.UseFont = true;
            this.colSilebilir.AppearanceHeader.Options.UseForeColor = true;
            this.colSilebilir.Caption = "Silebilir";
            this.colSilebilir.ColumnEdit = this.repositoryCheck;
            this.colSilebilir.FieldName = "Silebilir";
            this.colSilebilir.Name = "colSilebilir";
            this.colSilebilir.OptionsFilter.AllowAutoFilter = false;
            this.colSilebilir.OptionsFilter.AllowFilter = false;
            this.colSilebilir.StatusBarAciklama = null;
            this.colSilebilir.StatusBarKisaYol = null;
            this.colSilebilir.StatusBarKisaYolAciklama = null;
            this.colSilebilir.Visible = true;
            this.colSilebilir.VisibleIndex = 4;
            this.colSilebilir.Width = 175;
            // 
            // KullaniciBazliYetkiProfilleriTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "KullaniciBazliYetkiProfilleriTable";
            this.Size = new System.Drawing.Size(1003, 460);
            this.Controls.SetChildIndex(this.insUptNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Grid.MyGridControl grid;
        private Grid.MyGridView tablo;
        private Grid.MyGridColumn colKartTuru;
        private Grid.MyGridColumn colGorebilir;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryCheck;
        private Grid.MyGridColumn colEkleyebilir;
        private Grid.MyGridColumn colDegistirebilir;
        private Grid.MyGridColumn colSilebilir;
    }
}




