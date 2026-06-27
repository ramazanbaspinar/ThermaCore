namespace ThermaCore.Presentation.WinForms.Forms.FabrikaForms
{
    partial class FabrikaEditForm
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
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyDataLayoutControlPro();
            txtKod = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyKodTextEditPro();
            tglDurum = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyToggleSwitchPro();
            txtAciklama = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyMemoEditPro();
            txtFabrikaAdi = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyTextEditPro();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFabrikaAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(373, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(txtKod);
            myDataLayoutControl1.Controls.Add(tglDurum);
            myDataLayoutControl1.Controls.Add(txtAciklama);
            myDataLayoutControl1.Controls.Add(txtFabrikaAdi);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(373, 165);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // txtKod
            // 
            txtKod.EnterMoveNextControl = true;
            txtKod.Location = new Point(83, 12);
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
            txtKod.Size = new Size(169, 22);
            txtKod.StatusBarAciklama = "Kod Giriniz.";
            txtKod.StyleController = myDataLayoutControl1;
            txtKod.TabIndex = 2;
            // 
            // tglDurum
            // 
            tglDurum.EnterMoveNextControl = true;
            tglDurum.Location = new Point(266, 12);
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
            // 
            // txtAciklama
            // 
            txtAciklama.EnterMoveNextControl = true;
            txtAciklama.Location = new Point(83, 74);
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
            txtAciklama.Size = new Size(278, 79);
            txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            txtAciklama.StyleController = myDataLayoutControl1;
            txtAciklama.TabIndex = 1;
            // 
            // txtFabrikaAdi
            // 
            txtFabrikaAdi.EnterMoveNextControl = true;
            txtFabrikaAdi.Location = new Point(83, 43);
            txtFabrikaAdi.MenuManager = ribbon;
            txtFabrikaAdi.Name = "txtFabrikaAdi";
            txtFabrikaAdi.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtFabrikaAdi.Properties.Appearance.Options.UseFont = true;
            txtFabrikaAdi.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtFabrikaAdi.Properties.AppearanceDisabled.Options.UseFont = true;
            txtFabrikaAdi.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtFabrikaAdi.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtFabrikaAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtFabrikaAdi.Properties.AppearanceFocused.Options.UseFont = true;
            txtFabrikaAdi.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtFabrikaAdi.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtFabrikaAdi.Properties.MaxLength = 100;
            txtFabrikaAdi.Size = new Size(169, 22);
            txtFabrikaAdi.StatusBarAciklama = null;
            txtFabrikaAdi.StyleController = myDataLayoutControl1;
            txtFabrikaAdi.TabIndex = 0;
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem1 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 100D;
            columnDefinition2.SizeType = SizeType.Absolute;
            columnDefinition2.Width = 10D;
            columnDefinition3.SizeType = SizeType.Absolute;
            columnDefinition3.Width = 99D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1, columnDefinition2, columnDefinition3 });
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            rowDefinition2.Height = 31D;
            rowDefinition2.SizeType = SizeType.Absolute;
            rowDefinition3.Height = 100D;
            rowDefinition3.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3 });
            Root.Size = new Size(373, 165);
            Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = txtFabrikaAdi;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(244, 31);
            layoutControlItem2.Text = "Fabrika Adı";
            layoutControlItem2.TextSize = new Size(59, 15);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = txtAciklama;
            layoutControlItem3.Location = new Point(0, 62);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(353, 83);
            layoutControlItem3.Text = "Açıklama";
            layoutControlItem3.TextSize = new Size(59, 15);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = tglDurum;
            layoutControlItem4.Location = new Point(254, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem4.Size = new Size(99, 31);
            layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtKod;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(244, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(59, 15);
            // 
            // FabrikaEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 324);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(375, 325);
            Name = "FabrikaEditForm";
            Text = "Fabrika Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFabrikaAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControlPro myDataLayoutControl1;
        private UserControls.Controls.MyKodTextEditPro txtKod;
        private UserControls.Controls.MyToggleSwitchPro tglDurum;
        private UserControls.Controls.MyMemoEditPro txtAciklama;
        private UserControls.Controls.MyTextEditPro txtFabrikaAdi;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}