namespace ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms
{
    partial class RolEditForm
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
            tglDurum = new ThermaCore.Presentation.WinForms.UserControls.MyToggleSwitch();
            txtAciklama = new ThermaCore.Presentation.WinForms.UserControls.MyMemoEdit();
            treeList1 = new DevExpress.XtraTreeList.TreeList();
            colModulAdi = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colGorebilir = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colEkleyebilir = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colDuzenleyebilir = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colSilebilir = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            colOzelYetkiler = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            txtRolAdi = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            txtRolKodu = new ThermaCore.Presentation.WinForms.UserControls.MyKodTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRolAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRolKodu.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(498, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(tglDurum);
            myDataLayoutControl1.Controls.Add(txtAciklama);
            myDataLayoutControl1.Controls.Add(treeList1);
            myDataLayoutControl1.Controls.Add(txtRolAdi);
            myDataLayoutControl1.Controls.Add(txtRolKodu);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(498, 240);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // tglDurum
            // 
            tglDurum.EnterMoveNextControl = true;
            tglDurum.Location = new Point(391, 12);
            tglDurum.MenuManager = ribbon;
            tglDurum.Name = "tglDurum";
            tglDurum.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            tglDurum.Properties.Appearance.Options.UseFont = true;
            tglDurum.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            tglDurum.Properties.AppearanceDisabled.Options.UseFont = true;
            tglDurum.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            tglDurum.Properties.AppearanceFocused.Options.UseFont = true;
            tglDurum.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            tglDurum.Properties.AppearanceReadOnly.Options.UseFont = true;
            tglDurum.Properties.AutoHeight = false;
            tglDurum.Properties.AutoWidth = true;
            tglDurum.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            tglDurum.Properties.OffText = "Pasif";
            tglDurum.Properties.OnText = "Aktif";
            tglDurum.Size = new Size(85, 27);
            tglDurum.StatusBarAciklama = "Kayıtın Kullanım Durumunu Seçiniz.";
            tglDurum.StyleController = myDataLayoutControl1;
            tglDurum.TabIndex = 4;
            // 
            // txtAciklama
            // 
            txtAciklama.EnterMoveNextControl = true;
            txtAciklama.Location = new Point(73, 74);
            txtAciklama.MenuManager = ribbon;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtAciklama.Properties.Appearance.Options.UseFont = true;
            txtAciklama.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtAciklama.Properties.AppearanceDisabled.Options.UseFont = true;
            txtAciklama.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtAciklama.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtAciklama.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtAciklama.Properties.AppearanceFocused.Options.UseFont = true;
            txtAciklama.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtAciklama.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtAciklama.Properties.MaxLength = 500;
            txtAciklama.Size = new Size(413, 27);
            txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            txtAciklama.StyleController = myDataLayoutControl1;
            txtAciklama.TabIndex = 1;
            txtAciklama.Tag = "Description";
            // 
            // treeList1
            // 
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colModulAdi, colGorebilir, colEkleyebilir, colDuzenleyebilir, colSilebilir, colId, colParentId, colOzelYetkiler });
            treeList1.Location = new Point(12, 105);
            treeList1.MenuManager = ribbon;
            treeList1.Name = "treeList1";
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit1, repositoryItemCheckEdit2, repositoryItemCheckEdit3, repositoryItemCheckEdit4, repositoryItemButtonEdit1 });
            treeList1.Size = new Size(474, 123);
            treeList1.TabIndex = 2;
            // 
            // colModulAdi
            // 
            colModulAdi.Caption = "Modül Adı";
            colModulAdi.FieldName = "ModuleName";
            colModulAdi.Name = "colModulAdi";
            colModulAdi.Visible = true;
            colModulAdi.VisibleIndex = 0;
            // 
            // colGorebilir
            // 
            colGorebilir.Caption = "Görebilir";
            colGorebilir.ColumnEdit = repositoryItemCheckEdit1;
            colGorebilir.FieldName = "CanRead";
            colGorebilir.Name = "colGorebilir";
            colGorebilir.Visible = true;
            colGorebilir.VisibleIndex = 1;
            // 
            // repositoryItemCheckEdit1
            // 
            repositoryItemCheckEdit1.AutoHeight = false;
            repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colEkleyebilir
            // 
            colEkleyebilir.Caption = "Ekleyebilir";
            colEkleyebilir.ColumnEdit = repositoryItemCheckEdit2;
            colEkleyebilir.FieldName = "CanCreate";
            colEkleyebilir.Name = "colEkleyebilir";
            colEkleyebilir.Visible = true;
            colEkleyebilir.VisibleIndex = 2;
            // 
            // repositoryItemCheckEdit2
            // 
            repositoryItemCheckEdit2.AutoHeight = false;
            repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // colDuzenleyebilir
            // 
            colDuzenleyebilir.Caption = "Düzenleyebilir";
            colDuzenleyebilir.ColumnEdit = repositoryItemCheckEdit3;
            colDuzenleyebilir.FieldName = "CanUpdate";
            colDuzenleyebilir.Name = "colDuzenleyebilir";
            colDuzenleyebilir.Visible = true;
            colDuzenleyebilir.VisibleIndex = 3;
            // 
            // repositoryItemCheckEdit3
            // 
            repositoryItemCheckEdit3.AutoHeight = false;
            repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // colSilebilir
            // 
            colSilebilir.Caption = "Silebilir";
            colSilebilir.ColumnEdit = repositoryItemCheckEdit4;
            colSilebilir.FieldName = "CanDelete";
            colSilebilir.Name = "colSilebilir";
            colSilebilir.Visible = true;
            colSilebilir.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit4
            // 
            repositoryItemCheckEdit4.AutoHeight = false;
            repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // colId
            // 
            colId.Caption = "coltreeListColumn5";
            colId.FieldName = "Id";
            colId.Name = "colId";
            // 
            // colParentId
            // 
            colParentId.Caption = "coltreeListColumn6";
            colParentId.FieldName = "ParentId";
            colParentId.Name = "colParentId";
            // 
            // colOzelYetkiler
            // 
            colOzelYetkiler.Caption = "Özel Yetkiler";
            colOzelYetkiler.ColumnEdit = repositoryItemButtonEdit1;
            colOzelYetkiler.FieldName = "SpecialPermissions";
            colOzelYetkiler.Name = "colOzelYetkiler";
            colOzelYetkiler.Visible = true;
            colOzelYetkiler.VisibleIndex = 5;
            // 
            // repositoryItemButtonEdit1
            // 
            repositoryItemButtonEdit1.AutoHeight = false;
            repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton() });
            repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // txtRolAdi
            // 
            txtRolAdi.EnterMoveNextControl = true;
            txtRolAdi.Location = new Point(73, 43);
            txtRolAdi.MenuManager = ribbon;
            txtRolAdi.Name = "txtRolAdi";
            txtRolAdi.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtRolAdi.Properties.Appearance.Options.UseFont = true;
            txtRolAdi.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtRolAdi.Properties.AppearanceDisabled.Options.UseFont = true;
            txtRolAdi.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtRolAdi.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtRolAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtRolAdi.Properties.AppearanceFocused.Options.UseFont = true;
            txtRolAdi.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtRolAdi.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtRolAdi.Properties.MaxLength = 100;
            txtRolAdi.Size = new Size(314, 22);
            txtRolAdi.StatusBarAciklama = null;
            txtRolAdi.StyleController = myDataLayoutControl1;
            txtRolAdi.TabIndex = 0;
            txtRolAdi.Tag = "RoleName";
            // 
            // txtRolKodu
            // 
            txtRolKodu.EnterMoveNextControl = true;
            txtRolKodu.Location = new Point(73, 12);
            txtRolKodu.MenuManager = ribbon;
            txtRolKodu.Name = "txtRolKodu";
            txtRolKodu.Properties.Appearance.BackColor = Color.FromArgb(220, 235, 250);
            txtRolKodu.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtRolKodu.Properties.Appearance.Options.UseBackColor = true;
            txtRolKodu.Properties.Appearance.Options.UseFont = true;
            txtRolKodu.Properties.Appearance.Options.UseTextOptions = true;
            txtRolKodu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtRolKodu.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtRolKodu.Properties.AppearanceDisabled.Options.UseFont = true;
            txtRolKodu.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtRolKodu.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtRolKodu.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtRolKodu.Properties.AppearanceFocused.Options.UseFont = true;
            txtRolKodu.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtRolKodu.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtRolKodu.Properties.MaxLength = 100;
            txtRolKodu.Properties.ReadOnly = true;
            txtRolKodu.Size = new Size(314, 22);
            txtRolKodu.StatusBarAciklama = "Kod Giriniz.";
            txtRolKodu.StyleController = myDataLayoutControl1;
            txtRolKodu.TabIndex = 3;
            txtRolKodu.Tag = "Code";
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
            columnDefinition2.SizeType = SizeType.Absolute;
            columnDefinition2.Width = 99D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1, columnDefinition2 });
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            rowDefinition2.Height = 31D;
            rowDefinition2.SizeType = SizeType.Absolute;
            rowDefinition3.Height = 31D;
            rowDefinition3.SizeType = SizeType.Absolute;
            rowDefinition4.Height = 100D;
            rowDefinition4.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4 });
            Root.Size = new Size(498, 240);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtRolKodu;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(379, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(49, 15);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = txtRolAdi;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(379, 31);
            layoutControlItem2.Text = "Rol Adı";
            layoutControlItem2.TextSize = new Size(49, 15);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = treeList1;
            layoutControlItem3.Location = new Point(0, 93);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem3.Size = new Size(478, 127);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = txtAciklama;
            layoutControlItem4.Location = new Point(0, 62);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem4.Size = new Size(478, 31);
            layoutControlItem4.Text = "Açıklama";
            layoutControlItem4.TextSize = new Size(49, 15);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem5.Control = tglDurum;
            layoutControlItem5.Location = new Point(379, 0);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem5.Size = new Size(99, 31);
            layoutControlItem5.TextVisible = false;
            // 
            // RolEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 399);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(500, 400);
            Name = "RolEditForm";
            Text = "Rol Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit2).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit3).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit4).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRolAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRolKodu.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.MyTextEdit txtRolAdi;
        private UserControls.MyKodTextEdit txtRolKodu;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModulAdi;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGorebilir;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEkleyebilir;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDuzenleyebilir;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSilebilir;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private UserControls.MyMemoEdit txtAciklama;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOzelYetkiler;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private UserControls.MyToggleSwitch tglDurum;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}