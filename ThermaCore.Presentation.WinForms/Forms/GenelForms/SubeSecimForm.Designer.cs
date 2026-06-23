namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
{
    partial class SubeSecimForm
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
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.MyDataLayoutControl();
            myGridControl1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridControl();
            myGridView1 = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridView();
            colId = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colKod = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            colSubeFabAdi = new ThermaCore.Presentation.WinForms.UserControls.Grid.MyGridColumn();
            btnIptalCikis = new ThermaCore.Presentation.WinForms.UserControls.MySimpleButton();
            btnSecVeBasla = new ThermaCore.Presentation.WinForms.UserControls.MySimpleButton();
            myCheckEdit1 = new ThermaCore.Presentation.WinForms.UserControls.MyCheckEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)myGridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myCheckEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            SuspendLayout();
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(myGridControl1);
            myDataLayoutControl1.Controls.Add(btnIptalCikis);
            myDataLayoutControl1.Controls.Add(btnSecVeBasla);
            myDataLayoutControl1.Controls.Add(myCheckEdit1);
            myDataLayoutControl1.Controls.Add(labelControl1);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 0);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(625, 350);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // myGridControl1
            // 
            myGridControl1.Location = new Point(12, 43);
            myGridControl1.MainView = myGridView1;
            myGridControl1.Name = "myGridControl1";
            myGridControl1.Size = new Size(601, 229);
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
            myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colId, colKod, colSubeFabAdi });
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
            // colKod
            // 
            colKod.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colKod.AppearanceCell.Options.UseTextOptions = true;
            colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colKod.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colKod.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colKod.AppearanceHeader.ForeColor = Color.White;
            colKod.AppearanceHeader.Options.UseBackColor = true;
            colKod.AppearanceHeader.Options.UseFont = true;
            colKod.AppearanceHeader.Options.UseForeColor = true;
            colKod.Caption = "Kod";
            colKod.FieldName = "Code";
            colKod.Name = "colKod";
            colKod.OptionsColumn.AllowEdit = false;
            colKod.StatusBarAciklama = null;
            colKod.StatusBarKisaYol = null;
            colKod.StatusBarKisaYolAciklama = null;
            colKod.Visible = true;
            colKod.VisibleIndex = 0;
            colKod.Width = 175;
            // 
            // colSubeFabAdi
            // 
            colSubeFabAdi.AppearanceCell.Font = new Font("Segoe UI", 9.75F);
            colSubeFabAdi.AppearanceCell.Options.UseFont = true;
            colSubeFabAdi.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
            colSubeFabAdi.AppearanceHeader.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            colSubeFabAdi.AppearanceHeader.ForeColor = Color.White;
            colSubeFabAdi.AppearanceHeader.Options.UseBackColor = true;
            colSubeFabAdi.AppearanceHeader.Options.UseFont = true;
            colSubeFabAdi.AppearanceHeader.Options.UseForeColor = true;
            colSubeFabAdi.Caption = "Şube / Fabrika Adı";
            colSubeFabAdi.FieldName = "BranchName";
            colSubeFabAdi.Name = "colSubeFabAdi";
            colSubeFabAdi.OptionsColumn.AllowEdit = false;
            colSubeFabAdi.StatusBarAciklama = null;
            colSubeFabAdi.StatusBarKisaYol = null;
            colSubeFabAdi.StatusBarKisaYolAciklama = null;
            colSubeFabAdi.Visible = true;
            colSubeFabAdi.VisibleIndex = 1;
            colSubeFabAdi.Width = 175;
            // 
            // btnIptalCikis
            // 
            btnIptalCikis.Appearance.Font = new Font("Segoe UI", 9F);
            btnIptalCikis.Appearance.Options.UseFont = true;
            btnIptalCikis.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnIptalCikis.AppearanceDisabled.Options.UseFont = true;
            btnIptalCikis.AppearanceHovered.Font = new Font("Segoe UI", 9F);
            btnIptalCikis.AppearanceHovered.Options.UseFont = true;
            btnIptalCikis.AppearancePressed.Font = new Font("Segoe UI", 9F);
            btnIptalCikis.AppearancePressed.Options.UseFont = true;
            btnIptalCikis.ImageOptions.SvgImage = Properties.Resources.clearheaderandfooter;
            btnIptalCikis.Location = new Point(314, 307);
            btnIptalCikis.Name = "btnIptalCikis";
            btnIptalCikis.Size = new Size(299, 31);
            btnIptalCikis.StatusBarAciklama = null;
            btnIptalCikis.StyleController = myDataLayoutControl1;
            btnIptalCikis.TabIndex = 4;
            btnIptalCikis.Text = "İptal / Çıkış";
            // 
            // btnSecVeBasla
            // 
            btnSecVeBasla.Appearance.Font = new Font("Segoe UI", 9F);
            btnSecVeBasla.Appearance.Options.UseFont = true;
            btnSecVeBasla.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnSecVeBasla.AppearanceDisabled.Options.UseFont = true;
            btnSecVeBasla.AppearanceHovered.Font = new Font("Segoe UI", 9F);
            btnSecVeBasla.AppearanceHovered.Options.UseFont = true;
            btnSecVeBasla.AppearancePressed.Font = new Font("Segoe UI", 9F);
            btnSecVeBasla.AppearancePressed.Options.UseFont = true;
            btnSecVeBasla.ImageOptions.SvgImage = Properties.Resources.bo_validation;
            btnSecVeBasla.Location = new Point(12, 307);
            btnSecVeBasla.Name = "btnSecVeBasla";
            btnSecVeBasla.Size = new Size(298, 31);
            btnSecVeBasla.StatusBarAciklama = null;
            btnSecVeBasla.StyleController = myDataLayoutControl1;
            btnSecVeBasla.TabIndex = 3;
            btnSecVeBasla.Text = "Seç ve Başla";
            // 
            // myCheckEdit1
            // 
            myCheckEdit1.EnterMoveNextControl = true;
            myCheckEdit1.Location = new Point(12, 276);
            myCheckEdit1.Name = "myCheckEdit1";
            myCheckEdit1.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            myCheckEdit1.Properties.Appearance.Options.UseFont = true;
            myCheckEdit1.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            myCheckEdit1.Properties.AppearanceDisabled.Options.UseFont = true;
            myCheckEdit1.Properties.AppearanceFocused.BackColor = Color.Transparent;
            myCheckEdit1.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            myCheckEdit1.Properties.AppearanceFocused.Options.UseBackColor = true;
            myCheckEdit1.Properties.AppearanceFocused.Options.UseFont = true;
            myCheckEdit1.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            myCheckEdit1.Properties.AppearanceReadOnly.Options.UseFont = true;
            myCheckEdit1.Properties.Caption = "Bu seçimimi hatırla (Girişte tekrar sorma)";
            myCheckEdit1.Size = new Size(298, 20);
            myCheckEdit1.StatusBarAciklama = null;
            myCheckEdit1.StyleController = myDataLayoutControl1;
            myCheckEdit1.TabIndex = 2;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelControl1.Appearance.ForeColor = Color.Maroon;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Location = new Point(12, 12);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(601, 27);
            labelControl1.StyleController = myDataLayoutControl1;
            labelControl1.TabIndex = 0;
            labelControl1.Text = "Birden fazla fabrikada işlem yetkiniz bulunmaktadır. Lütfen giriş yapmak istediğiniz şubeyi seçin";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 100D;
            columnDefinition2.SizeType = SizeType.Percent;
            columnDefinition2.Width = 100D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1, columnDefinition2 });
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            rowDefinition2.Height = 100D;
            rowDefinition2.SizeType = SizeType.Percent;
            rowDefinition3.Height = 31D;
            rowDefinition3.SizeType = SizeType.Absolute;
            rowDefinition4.Height = 35D;
            rowDefinition4.SizeType = SizeType.Absolute;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4 });
            Root.Size = new Size(625, 350);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = labelControl1;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.MinSize = new Size(67, 17);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem1.Size = new Size(605, 31);
            layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = myCheckEdit1;
            layoutControlItem2.Location = new Point(0, 264);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem2.Size = new Size(302, 31);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = btnSecVeBasla;
            layoutControlItem3.Location = new Point(0, 295);
            layoutControlItem3.MinSize = new Size(109, 40);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem3.Size = new Size(302, 35);
            layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = btnIptalCikis;
            layoutControlItem4.Location = new Point(302, 295);
            layoutControlItem4.MinSize = new Size(105, 40);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem4.Size = new Size(303, 35);
            layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem5.Control = myGridControl1;
            layoutControlItem5.Location = new Point(0, 31);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem5.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem5.Size = new Size(605, 233);
            layoutControlItem5.TextVisible = false;
            // 
            // SubeSecimForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 350);
            Controls.Add(myDataLayoutControl1);
            FormBorderStyle = FormBorderStyle.None;
            IconOptions.ShowIcon = false;
            MaximizeBox = false;
            MaximumSize = new Size(625, 350);
            MinimizeBox = false;
            MinimumSize = new Size(625, 350);
            Name = "SubeSecimForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Şube / Fabrika Seçimi";
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)myGridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)myGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)myCheckEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private UserControls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.Grid.MyGridControl myGridControl1;
        private UserControls.Grid.MyGridView myGridView1;
        private UserControls.Grid.MyGridColumn colId;
        private UserControls.Grid.MyGridColumn colKod;
        private UserControls.MySimpleButton btnIptalCikis;
        private UserControls.MySimpleButton btnSecVeBasla;
        private UserControls.MyCheckEdit myCheckEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private UserControls.Grid.MyGridColumn colSubeFabAdi;
    }
}