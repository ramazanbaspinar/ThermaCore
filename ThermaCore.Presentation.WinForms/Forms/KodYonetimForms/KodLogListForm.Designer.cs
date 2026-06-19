namespace ThermaCore.Presentation.WinForms.Forms.KodYonetimForms
{
    partial class KodLogListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KodLogListForm));
            longNavigator1 = new RbaYazilim.WinRezistans.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            myGridControl1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colModul = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSubeAdi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colFirmaKodu = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colTarihKey = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSonKodDegeri = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
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
            myGridView1.Appearance.Empty.BackColor = Color.WhiteSmoke;
            myGridView1.Appearance.Empty.Font = new Font("Segoe UI", 9.75F);
            myGridView1.Appearance.Empty.Options.UseBackColor = true;
            myGridView1.Appearance.Empty.Options.UseFont = true;
            myGridView1.Appearance.EvenRow.BackColor = Color.FromArgb(250, 250, 250);
            myGridView1.Appearance.EvenRow.Options.UseBackColor = true;
            myGridView1.Appearance.FocusedCell.BackColor = Color.FromArgb(255, 249, 219);
            myGridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            myGridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 249, 219);
            myGridView1.Appearance.FocusedRow.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            myGridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            myGridView1.Appearance.FocusedRow.Options.UseFont = true;
            myGridView1.Appearance.FooterPanel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            myGridView1.Appearance.FooterPanel.ForeColor = Color.FromArgb(64, 64, 64);
            myGridView1.Appearance.FooterPanel.Options.UseFont = true;
            myGridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            myGridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(46, 134, 193);
            myGridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            myGridView1.Appearance.HeaderPanel.ForeColor = Color.White;
            myGridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            myGridView1.Appearance.HeaderPanel.Options.UseFont = true;
            myGridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            myGridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            myGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            myGridView1.Appearance.HideSelectionRow.BackColor = Color.FromArgb(255, 249, 219);
            myGridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            myGridView1.Appearance.OddRow.BackColor = Color.White;
            myGridView1.Appearance.OddRow.Options.UseBackColor = true;
            myGridView1.Appearance.Row.BackColor = Color.White;
            myGridView1.Appearance.Row.Font = new Font("Segoe UI", 9.75F);
            myGridView1.Appearance.Row.ForeColor = Color.Black;
            myGridView1.Appearance.Row.Options.UseBackColor = true;
            myGridView1.Appearance.Row.Options.UseFont = true;
            myGridView1.Appearance.Row.Options.UseForeColor = true;
            myGridView1.Appearance.SelectedRow.BackColor = Color.FromArgb(204, 229, 255);
            myGridView1.Appearance.SelectedRow.ForeColor = Color.Black;
            myGridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            myGridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            myGridView1.Appearance.ViewCaption.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            myGridView1.Appearance.ViewCaption.ForeColor = Color.FromArgb(64, 64, 64);
            myGridView1.Appearance.ViewCaption.Options.UseFont = true;
            myGridView1.Appearance.ViewCaption.Options.UseForeColor = true;
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colModul, colSubeAdi, colFirmaKodu, colTarihKey, colSonKodDegeri });
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
            myGridView1.OptionsView.EnableAppearanceOddRow = true;
            myGridView1.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            myGridView1.OptionsView.RowAutoHeight = true;
            myGridView1.OptionsView.ShowAutoFilterRow = true;
            myGridView1.OptionsView.ShowGroupPanel = false;
            myGridView1.OptionsView.ShowViewCaption = true;
            myGridView1.StatusBarAciklama = null;
            myGridView1.StatusBarKisaYol = null;
            myGridView1.StatusBarKisaYolAciklama = null;
            myGridView1.ViewCaption = "Kod Logları";
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
            // colModul
            // 
            colModul.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colModul.AppearanceCell.Options.UseFont = true;
            colModul.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colModul.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colModul.AppearanceHeader.ForeColor = Color.White;
            colModul.AppearanceHeader.Options.UseBackColor = true;
            colModul.AppearanceHeader.Options.UseFont = true;
            colModul.AppearanceHeader.Options.UseForeColor = true;
            colModul.Caption = "Modül";
            colModul.FieldName = "Module";
            colModul.Name = "colModul";
            colModul.OptionsColumn.AllowEdit = false;
            colModul.StatusBarAciklama = null;
            colModul.StatusBarKisaYol = null;
            colModul.StatusBarKisaYolAciklama = null;
            colModul.Visible = true;
            colModul.VisibleIndex = 1;
            colModul.Width = 175;
            // 
            // colSubeAdi
            // 
            colSubeAdi.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colSubeAdi.AppearanceCell.Options.UseFont = true;
            colSubeAdi.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colSubeAdi.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colSubeAdi.AppearanceHeader.ForeColor = Color.White;
            colSubeAdi.AppearanceHeader.Options.UseBackColor = true;
            colSubeAdi.AppearanceHeader.Options.UseFont = true;
            colSubeAdi.AppearanceHeader.Options.UseForeColor = true;
            colSubeAdi.Caption = "Şube Adı";
            colSubeAdi.FieldName = "BranchName";
            colSubeAdi.Name = "colSubeAdi";
            colSubeAdi.OptionsColumn.AllowEdit = false;
            colSubeAdi.StatusBarAciklama = null;
            colSubeAdi.StatusBarKisaYol = null;
            colSubeAdi.StatusBarKisaYolAciklama = null;
            colSubeAdi.Visible = true;
            colSubeAdi.VisibleIndex = 0;
            colSubeAdi.Width = 175;
            // 
            // colFirmaKodu
            // 
            colFirmaKodu.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colFirmaKodu.AppearanceCell.Options.UseFont = true;
            colFirmaKodu.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colFirmaKodu.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colFirmaKodu.AppearanceHeader.ForeColor = Color.White;
            colFirmaKodu.AppearanceHeader.Options.UseBackColor = true;
            colFirmaKodu.AppearanceHeader.Options.UseFont = true;
            colFirmaKodu.AppearanceHeader.Options.UseForeColor = true;
            colFirmaKodu.Caption = "Firma Kodu";
            colFirmaKodu.FieldName = "CompanyCode";
            colFirmaKodu.Name = "colFirmaKodu";
            colFirmaKodu.OptionsColumn.AllowEdit = false;
            colFirmaKodu.StatusBarAciklama = null;
            colFirmaKodu.StatusBarKisaYol = null;
            colFirmaKodu.StatusBarKisaYolAciklama = null;
            colFirmaKodu.Visible = true;
            colFirmaKodu.VisibleIndex = 2;
            colFirmaKodu.Width = 175;
            // 
            // colTarihKey
            // 
            colTarihKey.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colTarihKey.AppearanceCell.Options.UseFont = true;
            colTarihKey.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colTarihKey.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colTarihKey.AppearanceHeader.ForeColor = Color.White;
            colTarihKey.AppearanceHeader.Options.UseBackColor = true;
            colTarihKey.AppearanceHeader.Options.UseFont = true;
            colTarihKey.AppearanceHeader.Options.UseForeColor = true;
            colTarihKey.Caption = "Tarih Key";
            colTarihKey.FieldName = "DateKey";
            colTarihKey.Name = "colTarihKey";
            colTarihKey.OptionsColumn.AllowEdit = false;
            colTarihKey.StatusBarAciklama = null;
            colTarihKey.StatusBarKisaYol = null;
            colTarihKey.StatusBarKisaYolAciklama = null;
            colTarihKey.Visible = true;
            colTarihKey.VisibleIndex = 3;
            colTarihKey.Width = 175;
            // 
            // colSonKodDegeri
            // 
            colSonKodDegeri.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colSonKodDegeri.AppearanceCell.Options.UseFont = true;
            colSonKodDegeri.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colSonKodDegeri.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colSonKodDegeri.AppearanceHeader.ForeColor = Color.White;
            colSonKodDegeri.AppearanceHeader.Options.UseBackColor = true;
            colSonKodDegeri.AppearanceHeader.Options.UseFont = true;
            colSonKodDegeri.AppearanceHeader.Options.UseForeColor = true;
            colSonKodDegeri.Caption = "Son Kod Değeri";
            colSonKodDegeri.FieldName = "LastCodeValue";
            colSonKodDegeri.Name = "colSonKodDegeri";
            colSonKodDegeri.OptionsColumn.AllowEdit = false;
            colSonKodDegeri.StatusBarAciklama = null;
            colSonKodDegeri.StatusBarKisaYol = null;
            colSonKodDegeri.StatusBarKisaYolAciklama = null;
            colSonKodDegeri.Visible = true;
            colSonKodDegeri.VisibleIndex = 4;
            colSonKodDegeri.Width = 175;
            // 
            // KodLogListForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(814, 425);
            Controls.Add(myGridControl1);
            Controls.Add(longNavigator1);
            IconOptions.ShowIcon = false;
            Name = "KodLogListForm";
            Text = "Kod Logları";
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
        private UserControls.Grid.MyGridColumn colModul;
        private UserControls.Grid.MyGridColumn colSubeAdi;
        private UserControls.Grid.MyGridColumn colFirmaKodu;
        private UserControls.Grid.MyGridColumn colTarihKey;
        private UserControls.Grid.MyGridColumn colSonKodDegeri;
    }
}