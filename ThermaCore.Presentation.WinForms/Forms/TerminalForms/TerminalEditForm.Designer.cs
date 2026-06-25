namespace ThermaCore.Presentation.WinForms.Forms.TerminalForms
{
    partial class TerminalEditForm
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
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.MyDataLayoutControl();
            txtHardwareId = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            tglDurum = new ThermaCore.Presentation.WinForms.UserControls.MyToggleSwitch();
            txtAciklama = new ThermaCore.Presentation.WinForms.UserControls.MyMemoEdit();
            txtCihazAdi = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtHardwareId.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCihazAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
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
            myDataLayoutControl1.Controls.Add(txtHardwareId);
            myDataLayoutControl1.Controls.Add(tglDurum);
            myDataLayoutControl1.Controls.Add(txtAciklama);
            myDataLayoutControl1.Controls.Add(txtCihazAdi);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(398, 215);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // txtHardwareId
            // 
            txtHardwareId.EnterMoveNextControl = true;
            txtHardwareId.Location = new Point(145, 12);
            txtHardwareId.MenuManager = ribbon;
            txtHardwareId.Name = "txtHardwareId";
            txtHardwareId.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtHardwareId.Properties.Appearance.Options.UseFont = true;
            txtHardwareId.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtHardwareId.Properties.AppearanceDisabled.Options.UseFont = true;
            txtHardwareId.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtHardwareId.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtHardwareId.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtHardwareId.Properties.AppearanceFocused.Options.UseFont = true;
            txtHardwareId.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtHardwareId.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtHardwareId.Properties.MaxLength = 100;
            txtHardwareId.Properties.ReadOnly = true;
            txtHardwareId.Size = new Size(132, 22);
            txtHardwareId.StatusBarAciklama = null;
            txtHardwareId.StyleController = myDataLayoutControl1;
            txtHardwareId.TabIndex = 8;
            txtHardwareId.Tag = "HardwareId";
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
            tglDurum.TabIndex = 6;
            tglDurum.Tag = "IsActive";
            // 
            // txtAciklama
            // 
            txtAciklama.EnterMoveNextControl = true;
            txtAciklama.Location = new Point(145, 74);
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
            txtAciklama.Size = new Size(241, 129);
            txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            txtAciklama.StyleController = myDataLayoutControl1;
            txtAciklama.TabIndex = 5;
            txtAciklama.Tag = "Description";
            // 
            // txtCihazAdi
            // 
            txtCihazAdi.EnterMoveNextControl = true;
            txtCihazAdi.Location = new Point(145, 43);
            txtCihazAdi.MenuManager = ribbon;
            txtCihazAdi.Name = "txtCihazAdi";
            txtCihazAdi.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtCihazAdi.Properties.Appearance.Options.UseFont = true;
            txtCihazAdi.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtCihazAdi.Properties.AppearanceDisabled.Options.UseFont = true;
            txtCihazAdi.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtCihazAdi.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtCihazAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtCihazAdi.Properties.AppearanceFocused.Options.UseFont = true;
            txtCihazAdi.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtCihazAdi.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtCihazAdi.Properties.MaxLength = 100;
            txtCihazAdi.Properties.ReadOnly = true;
            txtCihazAdi.Size = new Size(241, 22);
            txtCihazAdi.StatusBarAciklama = null;
            txtCihazAdi.StyleController = myDataLayoutControl1;
            txtCihazAdi.TabIndex = 0;
            txtCihazAdi.Tag = "Code";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem4, layoutControlItem8, layoutControlItem2, layoutControlItem1 });
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
            Root.Size = new Size(398, 215);
            Root.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = txtAciklama;
            layoutControlItem4.Location = new Point(0, 62);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem4.Size = new Size(378, 133);
            layoutControlItem4.Text = "Açıklama";
            layoutControlItem4.TextSize = new Size(121, 15);
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem8.Control = tglDurum;
            layoutControlItem8.Location = new Point(279, 0);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem8.Size = new Size(99, 31);
            layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = txtHardwareId;
            layoutControlItem2.Location = new Point(0, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(269, 31);
            layoutControlItem2.Text = "Cihaz Donanım Kimliği";
            layoutControlItem2.TextSize = new Size(121, 15);
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtCihazAdi;
            layoutControlItem1.Location = new Point(0, 31);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem1.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem1.Size = new Size(378, 31);
            layoutControlItem1.Text = "Cihaz Adı";
            layoutControlItem1.TextSize = new Size(121, 15);
            // 
            // TerminalEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 374);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 375);
            Name = "TerminalEditForm";
            Text = " Terminal Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtHardwareId.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCihazAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.MyMemoEdit txtAciklama;
        private UserControls.MyTextEdit txtCihazAdi;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private UserControls.MyToggleSwitch tglDurum;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private UserControls.MyTextEdit txtHardwareId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}