namespace ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms
{
    partial class KullaniciYetkiEditForm
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition5 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.MyDataLayoutControl();
            tglDurum = new ThermaCore.Presentation.WinForms.UserControls.MyToggleSwitch();
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
            txtAdSoyad = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            txtKod = new ThermaCore.Presentation.WinForms.UserControls.MyKodTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            btnModulEkle = new ThermaCore.Presentation.WinForms.UserControls.MySimpleButton();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            btnTumModulleriEkle = new ThermaCore.Presentation.WinForms.UserControls.MySimpleButton();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            btnSeciliModuluCikar = new ThermaCore.Presentation.WinForms.UserControls.MySimpleButton();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            btnTumunuTemizle = new ThermaCore.Presentation.WinForms.UserControls.MySimpleButton();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAdSoyad.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(609, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(btnTumunuTemizle);
            myDataLayoutControl1.Controls.Add(btnSeciliModuluCikar);
            myDataLayoutControl1.Controls.Add(btnTumModulleriEkle);
            myDataLayoutControl1.Controls.Add(btnModulEkle);
            myDataLayoutControl1.Controls.Add(tglDurum);
            myDataLayoutControl1.Controls.Add(treeList1);
            myDataLayoutControl1.Controls.Add(txtAdSoyad);
            myDataLayoutControl1.Controls.Add(txtKod);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(609, 243);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // tglDurum
            // 
            tglDurum.EnterMoveNextControl = true;
            tglDurum.Location = new Point(502, 12);
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
            tglDurum.TabIndex = 3;
            tglDurum.Tag = "IsActive";
            // 
            // treeList1
            // 
            treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { colModulAdi, colGorebilir, colEkleyebilir, colDuzenleyebilir, colSilebilir, colId, colParentId, colOzelYetkiler });
            treeList1.Location = new Point(12, 105);
            treeList1.MenuManager = ribbon;
            treeList1.Name = "treeList1";
            treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemCheckEdit1, repositoryItemCheckEdit2, repositoryItemCheckEdit3, repositoryItemCheckEdit4, repositoryItemButtonEdit1 });
            treeList1.Size = new Size(585, 126);
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
            // txtAdSoyad
            // 
            txtAdSoyad.EnterMoveNextControl = true;
            txtAdSoyad.Location = new Point(74, 43);
            txtAdSoyad.MenuManager = ribbon;
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtAdSoyad.Properties.Appearance.Options.UseFont = true;
            txtAdSoyad.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtAdSoyad.Properties.AppearanceDisabled.Options.UseFont = true;
            txtAdSoyad.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtAdSoyad.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtAdSoyad.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtAdSoyad.Properties.AppearanceFocused.Options.UseFont = true;
            txtAdSoyad.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtAdSoyad.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtAdSoyad.Properties.MaxLength = 100;
            txtAdSoyad.Properties.ReadOnly = true;
            txtAdSoyad.Size = new Size(424, 22);
            txtAdSoyad.StatusBarAciklama = null;
            txtAdSoyad.StyleController = myDataLayoutControl1;
            txtAdSoyad.TabIndex = 1;
            txtAdSoyad.Tag = "FullName";
            // 
            // txtKod
            // 
            txtKod.EnterMoveNextControl = true;
            txtKod.Location = new Point(74, 12);
            txtKod.MenuManager = ribbon;
            txtKod.Name = "txtKod";
            txtKod.Properties.Appearance.BackColor = Color.FromArgb(220, 235, 250);
            txtKod.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtKod.Properties.Appearance.Options.UseBackColor = true;
            txtKod.Properties.Appearance.Options.UseFont = true;
            txtKod.Properties.Appearance.Options.UseTextOptions = true;
            txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtKod.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtKod.Properties.AppearanceDisabled.Options.UseFont = true;
            txtKod.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtKod.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtKod.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtKod.Properties.AppearanceFocused.Options.UseFont = true;
            txtKod.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtKod.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtKod.Properties.MaxLength = 100;
            txtKod.Properties.ReadOnly = true;
            txtKod.Size = new Size(424, 22);
            txtKod.StatusBarAciklama = "Kod Giriniz.";
            txtKod.StyleController = myDataLayoutControl1;
            txtKod.TabIndex = 0;
            txtKod.Tag = "Code";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem5, layoutControlItem4, layoutControlItem6, layoutControlItem7, layoutControlItem8 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 100D;
            columnDefinition2.SizeType = SizeType.Percent;
            columnDefinition2.Width = 100D;
            columnDefinition3.SizeType = SizeType.Percent;
            columnDefinition3.Width = 100D;
            columnDefinition4.SizeType = SizeType.Percent;
            columnDefinition4.Width = 100D;
            columnDefinition5.SizeType = SizeType.Absolute;
            columnDefinition5.Width = 99D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1, columnDefinition2, columnDefinition3, columnDefinition4, columnDefinition5 });
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            rowDefinition2.Height = 31D;
            rowDefinition2.SizeType = SizeType.Absolute;
            rowDefinition3.Height = 31D;
            rowDefinition3.SizeType = SizeType.Absolute;
            rowDefinition4.Height = 100D;
            rowDefinition4.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4 });
            Root.Size = new Size(609, 243);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtKod;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.ColumnSpan = 4;
            layoutControlItem1.Size = new Size(490, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(50, 15);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = txtAdSoyad;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.ColumnSpan = 4;
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(490, 31);
            layoutControlItem2.Text = "Ad Soyad";
            layoutControlItem2.TextSize = new Size(50, 15);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = treeList1;
            layoutControlItem3.Location = new Point(0, 93);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 5;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem3.Size = new Size(589, 130);
            layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem5.Control = tglDurum;
            layoutControlItem5.Location = new Point(490, 0);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 4;
            layoutControlItem5.Size = new Size(99, 31);
            layoutControlItem5.TextVisible = false;
            // 
            // btnModulEkle
            // 
            btnModulEkle.Appearance.Font = new Font("Segoe UI", 9F);
            btnModulEkle.Appearance.Options.UseFont = true;
            btnModulEkle.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnModulEkle.AppearanceDisabled.Options.UseFont = true;
            btnModulEkle.AppearanceHovered.Font = new Font("Segoe UI", 9F);
            btnModulEkle.AppearanceHovered.Options.UseFont = true;
            btnModulEkle.AppearancePressed.Font = new Font("Segoe UI", 9F);
            btnModulEkle.AppearancePressed.Options.UseFont = true;
            btnModulEkle.Location = new Point(12, 74);
            btnModulEkle.Name = "btnModulEkle";
            btnModulEkle.Size = new Size(118, 22);
            btnModulEkle.StatusBarAciklama = null;
            btnModulEkle.StyleController = myDataLayoutControl1;
            btnModulEkle.TabIndex = 4;
            btnModulEkle.Text = "Modül Ekle";
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = btnModulEkle;
            layoutControlItem4.Location = new Point(0, 62);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem4.Size = new Size(122, 31);
            layoutControlItem4.TextVisible = false;
            // 
            // btnTumModulleriEkle
            // 
            btnTumModulleriEkle.Appearance.Font = new Font("Segoe UI", 9F);
            btnTumModulleriEkle.Appearance.Options.UseFont = true;
            btnTumModulleriEkle.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnTumModulleriEkle.AppearanceDisabled.Options.UseFont = true;
            btnTumModulleriEkle.AppearanceHovered.Font = new Font("Segoe UI", 9F);
            btnTumModulleriEkle.AppearanceHovered.Options.UseFont = true;
            btnTumModulleriEkle.AppearancePressed.Font = new Font("Segoe UI", 9F);
            btnTumModulleriEkle.AppearancePressed.Options.UseFont = true;
            btnTumModulleriEkle.Location = new Point(134, 74);
            btnTumModulleriEkle.Name = "btnTumModulleriEkle";
            btnTumModulleriEkle.Size = new Size(118, 22);
            btnTumModulleriEkle.StatusBarAciklama = null;
            btnTumModulleriEkle.StyleController = myDataLayoutControl1;
            btnTumModulleriEkle.TabIndex = 5;
            btnTumModulleriEkle.Text = "Tüm Modülleri Ekle";
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem6.Control = btnTumModulleriEkle;
            layoutControlItem6.Location = new Point(122, 62);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem6.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem6.Size = new Size(122, 31);
            layoutControlItem6.TextVisible = false;
            // 
            // btnSeciliModuluCikar
            // 
            btnSeciliModuluCikar.Appearance.Font = new Font("Segoe UI", 9F);
            btnSeciliModuluCikar.Appearance.Options.UseFont = true;
            btnSeciliModuluCikar.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnSeciliModuluCikar.AppearanceDisabled.Options.UseFont = true;
            btnSeciliModuluCikar.AppearanceHovered.Font = new Font("Segoe UI", 9F);
            btnSeciliModuluCikar.AppearanceHovered.Options.UseFont = true;
            btnSeciliModuluCikar.AppearancePressed.Font = new Font("Segoe UI", 9F);
            btnSeciliModuluCikar.AppearancePressed.Options.UseFont = true;
            btnSeciliModuluCikar.Location = new Point(256, 74);
            btnSeciliModuluCikar.Name = "btnSeciliModuluCikar";
            btnSeciliModuluCikar.Size = new Size(118, 22);
            btnSeciliModuluCikar.StatusBarAciklama = null;
            btnSeciliModuluCikar.StyleController = myDataLayoutControl1;
            btnSeciliModuluCikar.TabIndex = 6;
            btnSeciliModuluCikar.Text = "Seçili Modülü Çıkar";
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem7.Control = btnSeciliModuluCikar;
            layoutControlItem7.Location = new Point(244, 62);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem7.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem7.Size = new Size(122, 31);
            layoutControlItem7.TextVisible = false;
            // 
            // btnTumunuTemizle
            // 
            btnTumunuTemizle.Appearance.Font = new Font("Segoe UI", 9F);
            btnTumunuTemizle.Appearance.Options.UseFont = true;
            btnTumunuTemizle.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnTumunuTemizle.AppearanceDisabled.Options.UseFont = true;
            btnTumunuTemizle.AppearanceHovered.Font = new Font("Segoe UI", 9F);
            btnTumunuTemizle.AppearanceHovered.Options.UseFont = true;
            btnTumunuTemizle.AppearancePressed.Font = new Font("Segoe UI", 9F);
            btnTumunuTemizle.AppearancePressed.Options.UseFont = true;
            btnTumunuTemizle.Location = new Point(378, 74);
            btnTumunuTemizle.Name = "btnTumunuTemizle";
            btnTumunuTemizle.Size = new Size(120, 22);
            btnTumunuTemizle.StatusBarAciklama = null;
            btnTumunuTemizle.StyleController = myDataLayoutControl1;
            btnTumunuTemizle.TabIndex = 7;
            btnTumunuTemizle.Text = "Tümünü Temizle";
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem8.Control = btnTumunuTemizle;
            layoutControlItem8.Location = new Point(366, 62);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.OptionsTableLayoutItem.ColumnIndex = 3;
            layoutControlItem8.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem8.Size = new Size(124, 31);
            layoutControlItem8.TextVisible = false;
            // 
            // KullaniciYetkiEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 402);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            Name = "KullaniciYetkiEditForm";
            Text = "Kullanıcı Yetki Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)treeList1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit2).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit3).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemCheckEdit4).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAdSoyad.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.MyToggleSwitch tglDurum;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colModulAdi;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGorebilir;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEkleyebilir;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDuzenleyebilir;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSilebilir;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOzelYetkiler;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private UserControls.MyTextEdit txtAdSoyad;
        private UserControls.MyKodTextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private UserControls.MySimpleButton btnTumunuTemizle;
        private UserControls.MySimpleButton btnSeciliModuluCikar;
        private UserControls.MySimpleButton btnTumModulleriEkle;
        private UserControls.MySimpleButton btnModulEkle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}