namespace WinBeyazEsya.Presentation.WinForms.Forms.YetkilendirmeForms
{
    partial class OzelYetkiEditForm
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            myGridControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colYetkiAciklamasi = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSecim = new WinBeyazEsya.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            myDataLayoutControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            btnIptal = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MySimpleButton();
            btnTamam = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MySimpleButton();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            SuspendLayout();
            // 
            // myGridControl1
            // 
            myGridControl1.Location = new Point(12, 12);
            myGridControl1.MainView = myGridView1;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit1 });
            myGridControl1.Size = new Size(374, 413);
            myGridControl1.TabIndex = 1;
            myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { myGridView1 });
            // 
            // myGridView1
            // 
            myGridView1.Appearance.Empty.BackColor = Color.FromArgb(245, 245, 245);
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colYetkiAciklamasi, colSecim });
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
            // colYetkiAciklamasi
            // 
            colYetkiAciklamasi.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colYetkiAciklamasi.AppearanceCell.Options.UseFont = true;
            colYetkiAciklamasi.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colYetkiAciklamasi.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colYetkiAciklamasi.AppearanceHeader.ForeColor = Color.White;
            colYetkiAciklamasi.AppearanceHeader.Options.UseBackColor = true;
            colYetkiAciklamasi.AppearanceHeader.Options.UseFont = true;
            colYetkiAciklamasi.AppearanceHeader.Options.UseForeColor = true;
            colYetkiAciklamasi.Caption = "Yetki Açıklaması";
            colYetkiAciklamasi.FieldName = "YetkiAciklamasi";
            colYetkiAciklamasi.Name = "colYetkiAciklamasi";
            colYetkiAciklamasi.OptionsColumn.AllowEdit = false;
            colYetkiAciklamasi.StatusBarAciklama = null;
            colYetkiAciklamasi.StatusBarKisaYol = null;
            colYetkiAciklamasi.StatusBarKisaYolAciklama = null;
            colYetkiAciklamasi.Visible = true;
            colYetkiAciklamasi.VisibleIndex = 0;
            colYetkiAciklamasi.Width = 175;
            // 
            // colSecim
            // 
            colSecim.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colSecim.AppearanceCell.Options.UseFont = true;
            colSecim.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colSecim.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colSecim.AppearanceHeader.ForeColor = Color.White;
            colSecim.AppearanceHeader.Options.UseBackColor = true;
            colSecim.AppearanceHeader.Options.UseFont = true;
            colSecim.AppearanceHeader.Options.UseForeColor = true;
            colSecim.Caption = "Seçim";
            colSecim.ColumnEdit = repositoryItemCheckEdit1;
            colSecim.FieldName = "Secim";
            colSecim.Name = "colSecim";
            colSecim.OptionsColumn.AllowEdit = false;
            colSecim.StatusBarAciklama = null;
            colSecim.StatusBarKisaYol = null;
            colSecim.StatusBarKisaYolAciklama = null;
            colSecim.Visible = true;
            colSecim.VisibleIndex = 1;
            colSecim.Width = 175;
            // 
            // repositoryItemCheckEdit1
            // 
            repositoryItemCheckEdit1.AutoHeight = false;
            repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(btnIptal);
            myDataLayoutControl1.Controls.Add(btnTamam);
            myDataLayoutControl1.Controls.Add(myGridControl1);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 0);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(398, 468);
            myDataLayoutControl1.TabIndex = 2;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // btnIptal
            // 
            btnIptal.Appearance.Font = new Font("Segoe UI", 9F);
            btnIptal.Appearance.Options.UseFont = true;
            btnIptal.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnIptal.AppearanceDisabled.Options.UseFont = true;
            btnIptal.AppearanceHovered.Font = new Font("Segoe UI", 9F);
            btnIptal.AppearanceHovered.Options.UseFont = true;
            btnIptal.AppearancePressed.Font = new Font("Segoe UI", 9F);
            btnIptal.AppearancePressed.Options.UseFont = true;
            btnIptal.Location = new Point(201, 429);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(185, 22);
            btnIptal.StatusBarAciklama = null;
            btnIptal.StyleController = myDataLayoutControl1;
            btnIptal.TabIndex = 5;
            btnIptal.Text = "İptal";
            // 
            // btnTamam
            // 
            btnTamam.Appearance.Font = new Font("Segoe UI", 9F);
            btnTamam.Appearance.Options.UseFont = true;
            btnTamam.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnTamam.AppearanceDisabled.Options.UseFont = true;
            btnTamam.AppearanceHovered.Font = new Font("Segoe UI", 9F);
            btnTamam.AppearanceHovered.Options.UseFont = true;
            btnTamam.AppearancePressed.Font = new Font("Segoe UI", 9F);
            btnTamam.AppearancePressed.Options.UseFont = true;
            btnTamam.Location = new Point(12, 429);
            btnTamam.Name = "btnTamam";
            btnTamam.Size = new Size(185, 22);
            btnTamam.StatusBarAciklama = null;
            btnTamam.StyleController = myDataLayoutControl1;
            btnTamam.TabIndex = 4;
            btnTamam.Text = "Tamam";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 100D;
            columnDefinition2.SizeType = SizeType.Percent;
            columnDefinition2.Width = 100D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1, columnDefinition2 });
            rowDefinition1.Height = 100D;
            rowDefinition1.SizeType = SizeType.Percent;
            rowDefinition2.Height = 31D;
            rowDefinition2.SizeType = SizeType.Absolute;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2 });
            Root.Size = new Size(398, 468);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = myGridControl1;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem1.Size = new Size(378, 417);
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = btnTamam;
            layoutControlItem2.Location = new Point(0, 417);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(189, 31);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = btnIptal;
            layoutControlItem3.Location = new Point(189, 417);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem3.Size = new Size(189, 31);
            layoutControlItem3.TextVisible = false;
            // 
            // OzelYetkiEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 468);
            Controls.Add(myDataLayoutControl1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            Name = "OzelYetkiEditForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Özel Yetkiler";
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private UserControls.Grid.MyGridControl myGridControl1;
        private UserControls.Grid.MyGridView myGridView1;
        private UserControls.Grid.MyGridColumn colId;
        private UserControls.Grid.MyGridColumn colYetkiAciklamasi;
        private UserControls.Grid.MyGridColumn colSecim;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MySimpleButton btnIptal;
        private UserControls.Controls.MySimpleButton btnTamam;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
