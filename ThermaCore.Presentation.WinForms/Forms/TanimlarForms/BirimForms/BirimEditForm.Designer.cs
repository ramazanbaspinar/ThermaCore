namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms
{
    partial class BirimEditForm
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
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.MyDataLayoutControl();
            tglDurum = new ThermaCore.Presentation.WinForms.UserControls.MyToggleSwitch();
            txtAciklama = new ThermaCore.Presentation.WinForms.UserControls.MyMemoEdit();
            txtBirimAdi = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            txtKod = new ThermaCore.Presentation.WinForms.UserControls.MyKodTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBirimAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(398, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(tglDurum);
            myDataLayoutControl1.Controls.Add(txtAciklama);
            myDataLayoutControl1.Controls.Add(txtBirimAdi);
            myDataLayoutControl1.Controls.Add(txtKod);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(398, 140);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // tglDurum
            // 
            tglDurum.EnterMoveNextControl = true;
            tglDurum.Location = new Point(291, 12);
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
            txtAciklama.Size = new Size(313, 54);
            txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            txtAciklama.StyleController = myDataLayoutControl1;
            txtAciklama.TabIndex = 2;
            txtAciklama.Tag = "Description";
            // 
            // txtBirimAdi
            // 
            txtBirimAdi.EnterMoveNextControl = true;
            txtBirimAdi.Location = new Point(73, 43);
            txtBirimAdi.MenuManager = ribbon;
            txtBirimAdi.Name = "txtBirimAdi";
            txtBirimAdi.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtBirimAdi.Properties.Appearance.Options.UseFont = true;
            txtBirimAdi.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtBirimAdi.Properties.AppearanceDisabled.Options.UseFont = true;
            txtBirimAdi.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtBirimAdi.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtBirimAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtBirimAdi.Properties.AppearanceFocused.Options.UseFont = true;
            txtBirimAdi.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtBirimAdi.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtBirimAdi.Properties.MaxLength = 100;
            txtBirimAdi.Size = new Size(313, 22);
            txtBirimAdi.StatusBarAciklama = null;
            txtBirimAdi.StyleController = myDataLayoutControl1;
            txtBirimAdi.TabIndex = 1;
            txtBirimAdi.Tag = "Name";
            // 
            // txtKod
            // 
            txtKod.EnterMoveNextControl = true;
            txtKod.Location = new Point(73, 12);
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
            txtKod.Size = new Size(214, 22);
            txtKod.StatusBarAciklama = "Kod Giriniz.";
            txtKod.StyleController = myDataLayoutControl1;
            txtKod.TabIndex = 0;
            txtKod.Tag = "Code";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4 });
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
            rowDefinition3.Height = 100D;
            rowDefinition3.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3 });
            Root.Size = new Size(398, 140);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtKod;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(279, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(49, 15);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = txtBirimAdi;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(378, 31);
            layoutControlItem2.Text = "Birim Adı";
            layoutControlItem2.TextSize = new Size(49, 15);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = txtAciklama;
            layoutControlItem3.Location = new Point(0, 62);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(378, 58);
            layoutControlItem3.Text = "Açıklama";
            layoutControlItem3.TextSize = new Size(49, 15);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = tglDurum;
            layoutControlItem4.Location = new Point(279, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem4.Size = new Size(99, 31);
            layoutControlItem4.TextVisible = false;
            // 
            // BirimEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 299);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 300);
            Name = "BirimEditForm";
            Text = "Birim Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBirimAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.MyTextEdit txtBirimAdi;
        private UserControls.MyKodTextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private UserControls.MyMemoEdit txtAciklama;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private UserControls.MyToggleSwitch tglDurum;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}