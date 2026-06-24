namespace ThermaCore.Presentation.WinForms.Forms.ParametrelerForms
{
    partial class SystemLicenseEditForm
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
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.MyDataLayoutControl();
            txtLicenseKey = new ThermaCore.Presentation.WinForms.UserControls.MyMemoEdit();
            btnCihazMacGetir = new ThermaCore.Presentation.WinForms.UserControls.MySimpleButton();
            btnCihazIdGetir = new ThermaCore.Presentation.WinForms.UserControls.MySimpleButton();
            dtExpirationDate = new ThermaCore.Presentation.WinForms.UserControls.MyDateEdit();
            txtServerCpuId = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            txtServerMacAddress = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            txtMaxTerminal = new ThermaCore.Presentation.WinForms.UserControls.MySpinEdit();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtLicenseKey.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtServerCpuId.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtServerMacAddress.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMaxTerminal.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
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
            myDataLayoutControl1.Controls.Add(txtMaxTerminal);
            myDataLayoutControl1.Controls.Add(txtLicenseKey);
            myDataLayoutControl1.Controls.Add(btnCihazMacGetir);
            myDataLayoutControl1.Controls.Add(btnCihazIdGetir);
            myDataLayoutControl1.Controls.Add(dtExpirationDate);
            myDataLayoutControl1.Controls.Add(txtServerCpuId);
            myDataLayoutControl1.Controls.Add(txtServerMacAddress);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(373, 190);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // txtLicenseKey
            // 
            txtLicenseKey.EnterMoveNextControl = true;
            txtLicenseKey.Location = new Point(134, 74);
            txtLicenseKey.MenuManager = ribbon;
            txtLicenseKey.Name = "txtLicenseKey";
            txtLicenseKey.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtLicenseKey.Properties.Appearance.Options.UseFont = true;
            txtLicenseKey.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtLicenseKey.Properties.AppearanceDisabled.Options.UseFont = true;
            txtLicenseKey.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtLicenseKey.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtLicenseKey.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtLicenseKey.Properties.AppearanceFocused.Options.UseFont = true;
            txtLicenseKey.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtLicenseKey.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtLicenseKey.Properties.MaxLength = 500;
            txtLicenseKey.Size = new Size(227, 42);
            txtLicenseKey.StatusBarAciklama = "Açıklama Giriniz.";
            txtLicenseKey.StyleController = myDataLayoutControl1;
            txtLicenseKey.TabIndex = 4;
            txtLicenseKey.Tag = "LicenseKey";
            // 
            // btnCihazMacGetir
            // 
            btnCihazMacGetir.Appearance.Font = new Font("Segoe UI", 9F);
            btnCihazMacGetir.Appearance.Options.UseFont = true;
            btnCihazMacGetir.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnCihazMacGetir.AppearanceDisabled.Options.UseFont = true;
            btnCihazMacGetir.AppearanceHovered.Font = new Font("Segoe UI", 9F);
            btnCihazMacGetir.AppearanceHovered.Options.UseFont = true;
            btnCihazMacGetir.AppearancePressed.Font = new Font("Segoe UI", 9F);
            btnCihazMacGetir.AppearancePressed.Options.UseFont = true;
            btnCihazMacGetir.Location = new Point(266, 12);
            btnCihazMacGetir.Name = "btnCihazMacGetir";
            btnCihazMacGetir.Size = new Size(95, 22);
            btnCihazMacGetir.StatusBarAciklama = null;
            btnCihazMacGetir.StyleController = myDataLayoutControl1;
            btnCihazMacGetir.TabIndex = 5;
            btnCihazMacGetir.Text = "Cihaz Mac Getir";
            // 
            // btnCihazIdGetir
            // 
            btnCihazIdGetir.Appearance.Font = new Font("Segoe UI", 9F);
            btnCihazIdGetir.Appearance.Options.UseFont = true;
            btnCihazIdGetir.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            btnCihazIdGetir.AppearanceDisabled.Options.UseFont = true;
            btnCihazIdGetir.AppearanceHovered.Font = new Font("Segoe UI", 9F);
            btnCihazIdGetir.AppearanceHovered.Options.UseFont = true;
            btnCihazIdGetir.AppearancePressed.Font = new Font("Segoe UI", 9F);
            btnCihazIdGetir.AppearancePressed.Options.UseFont = true;
            btnCihazIdGetir.Location = new Point(266, 43);
            btnCihazIdGetir.Name = "btnCihazIdGetir";
            btnCihazIdGetir.Size = new Size(95, 22);
            btnCihazIdGetir.StatusBarAciklama = null;
            btnCihazIdGetir.StyleController = myDataLayoutControl1;
            btnCihazIdGetir.TabIndex = 6;
            btnCihazIdGetir.Text = "Cihaz ID Getir";
            // 
            // dtExpirationDate
            // 
            dtExpirationDate.EditValue = null;
            dtExpirationDate.EnterMoveNextControl = true;
            dtExpirationDate.Location = new Point(134, 151);
            dtExpirationDate.MenuManager = ribbon;
            dtExpirationDate.Name = "dtExpirationDate";
            dtExpirationDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            dtExpirationDate.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            dtExpirationDate.Properties.Appearance.Options.UseFont = true;
            dtExpirationDate.Properties.Appearance.Options.UseTextOptions = true;
            dtExpirationDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            dtExpirationDate.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            dtExpirationDate.Properties.AppearanceDisabled.Options.UseFont = true;
            dtExpirationDate.Properties.AppearanceDropDown.Font = new Font("Segoe UI", 9F);
            dtExpirationDate.Properties.AppearanceDropDown.Options.UseFont = true;
            dtExpirationDate.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            dtExpirationDate.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            dtExpirationDate.Properties.AppearanceFocused.Options.UseBackColor = true;
            dtExpirationDate.Properties.AppearanceFocused.Options.UseFont = true;
            dtExpirationDate.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            dtExpirationDate.Properties.AppearanceReadOnly.Options.UseFont = true;
            dtExpirationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtExpirationDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtExpirationDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            dtExpirationDate.Properties.MaskSettings.Set("useAdvancingCaret", true);
            dtExpirationDate.Properties.ReadOnly = true;
            dtExpirationDate.Size = new Size(128, 22);
            dtExpirationDate.StatusBarAciklama = null;
            dtExpirationDate.StatusBarKisaYol = "F4 :";
            dtExpirationDate.StatusBarKisaYolAciklama = "Tarih Seç";
            dtExpirationDate.StyleController = myDataLayoutControl1;
            dtExpirationDate.TabIndex = 3;
            dtExpirationDate.Tag = "ExpirationDate";
            // 
            // txtServerCpuId
            // 
            txtServerCpuId.EnterMoveNextControl = true;
            txtServerCpuId.Location = new Point(134, 43);
            txtServerCpuId.MenuManager = ribbon;
            txtServerCpuId.Name = "txtServerCpuId";
            txtServerCpuId.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtServerCpuId.Properties.Appearance.Options.UseFont = true;
            txtServerCpuId.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtServerCpuId.Properties.AppearanceDisabled.Options.UseFont = true;
            txtServerCpuId.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtServerCpuId.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtServerCpuId.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtServerCpuId.Properties.AppearanceFocused.Options.UseFont = true;
            txtServerCpuId.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtServerCpuId.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtServerCpuId.Properties.MaxLength = 100;
            txtServerCpuId.Size = new Size(128, 22);
            txtServerCpuId.StatusBarAciklama = null;
            txtServerCpuId.StyleController = myDataLayoutControl1;
            txtServerCpuId.TabIndex = 1;
            txtServerCpuId.Tag = "ServerCpuId";
            // 
            // txtServerMacAddress
            // 
            txtServerMacAddress.EnterMoveNextControl = true;
            txtServerMacAddress.Location = new Point(134, 12);
            txtServerMacAddress.MenuManager = ribbon;
            txtServerMacAddress.Name = "txtServerMacAddress";
            txtServerMacAddress.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtServerMacAddress.Properties.Appearance.Options.UseFont = true;
            txtServerMacAddress.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtServerMacAddress.Properties.AppearanceDisabled.Options.UseFont = true;
            txtServerMacAddress.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtServerMacAddress.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtServerMacAddress.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtServerMacAddress.Properties.AppearanceFocused.Options.UseFont = true;
            txtServerMacAddress.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtServerMacAddress.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtServerMacAddress.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            txtServerMacAddress.Properties.MaskSettings.Set("mask", "([0-9A-Fa-f]{2}:){5}[0-9A-Fa-f]{2}");
            txtServerMacAddress.Properties.MaxLength = 100;
            txtServerMacAddress.Size = new Size(128, 22);
            txtServerMacAddress.StatusBarAciklama = null;
            txtServerMacAddress.StyleController = myDataLayoutControl1;
            txtServerMacAddress.TabIndex = 0;
            txtServerMacAddress.Tag = "ServerMacAddress";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem7, layoutControlItem3 });
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
            rowDefinition4.Height = 31D;
            rowDefinition4.SizeType = SizeType.Absolute;
            rowDefinition5.Height = 31D;
            rowDefinition5.SizeType = SizeType.Absolute;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4, rowDefinition5 });
            Root.Size = new Size(373, 190);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtServerMacAddress;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(254, 31);
            layoutControlItem1.Text = "Server Mac Adresi";
            layoutControlItem1.TextSize = new Size(110, 15);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = txtServerCpuId;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(254, 31);
            layoutControlItem2.Text = "Server CPU ID";
            layoutControlItem2.TextSize = new Size(110, 15);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = dtExpirationDate;
            layoutControlItem4.Location = new Point(0, 139);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 4;
            layoutControlItem4.Size = new Size(254, 31);
            layoutControlItem4.Text = "Geçerlilik Bitiş Tarihi";
            layoutControlItem4.TextSize = new Size(110, 15);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem5.Control = btnCihazIdGetir;
            layoutControlItem5.Location = new Point(254, 31);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem5.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem5.Size = new Size(99, 31);
            layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem6.Control = btnCihazMacGetir;
            layoutControlItem6.Location = new Point(254, 0);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem6.Size = new Size(99, 31);
            layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem7.Control = txtLicenseKey;
            layoutControlItem7.Location = new Point(0, 62);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem7.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem7.Size = new Size(353, 46);
            layoutControlItem7.Text = "Lisans Anahtarı";
            layoutControlItem7.TextSize = new Size(110, 15);
            // 
            // txtMaxTerminal
            // 
            txtMaxTerminal.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtMaxTerminal.EnterMoveNextControl = true;
            txtMaxTerminal.Location = new Point(134, 120);
            txtMaxTerminal.MenuManager = ribbon;
            txtMaxTerminal.Name = "txtMaxTerminal";
            txtMaxTerminal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtMaxTerminal.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtMaxTerminal.Properties.Appearance.Options.UseFont = true;
            txtMaxTerminal.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtMaxTerminal.Properties.AppearanceDisabled.Options.UseFont = true;
            txtMaxTerminal.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtMaxTerminal.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtMaxTerminal.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtMaxTerminal.Properties.AppearanceFocused.Options.UseFont = true;
            txtMaxTerminal.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtMaxTerminal.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtMaxTerminal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtMaxTerminal.Properties.MaskSettings.Set("mask", "n0");
            txtMaxTerminal.Properties.ReadOnly = true;
            txtMaxTerminal.Size = new Size(128, 22);
            txtMaxTerminal.StatusBarAciklama = null;
            txtMaxTerminal.StyleController = myDataLayoutControl1;
            txtMaxTerminal.TabIndex = 2;
            txtMaxTerminal.Tag = "MaxTerminal";
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = txtMaxTerminal;
            layoutControlItem3.Location = new Point(0, 108);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem3.Size = new Size(254, 31);
            layoutControlItem3.Text = "Maksimum Terminal";
            layoutControlItem3.TextSize = new Size(110, 15);
            // 
            // SystemLicenseEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 349);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(375, 350);
            Name = "SystemLicenseEditForm";
            Text = "Lisans Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtLicenseKey.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtServerCpuId.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtServerMacAddress.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMaxTerminal.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.MyDateEdit dtExpirationDate;
        private UserControls.MyTextEdit txtServerCpuId;
        private UserControls.MyTextEdit txtServerMacAddress;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private UserControls.MySimpleButton btnCihazMacGetir;
        private UserControls.MySimpleButton btnCihazIdGetir;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private UserControls.MyMemoEdit txtLicenseKey;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private UserControls.MySpinEdit txtMaxTerminal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}