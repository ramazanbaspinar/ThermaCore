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
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.MyDataLayoutControl();
            txtMaxTerminal = new ThermaCore.Presentation.WinForms.UserControls.MySpinEdit();
            txtLicenseKey = new ThermaCore.Presentation.WinForms.UserControls.MyMemoEdit();
            dtExpirationDate = new ThermaCore.Presentation.WinForms.UserControls.MyDateEdit();
            txtHardwareId = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtMaxTerminal.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLicenseKey.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHardwareId.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
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
            myDataLayoutControl1.Controls.Add(txtMaxTerminal);
            myDataLayoutControl1.Controls.Add(txtLicenseKey);
            myDataLayoutControl1.Controls.Add(dtExpirationDate);
            myDataLayoutControl1.Controls.Add(txtHardwareId);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(398, 190);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // txtMaxTerminal
            // 
            txtMaxTerminal.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtMaxTerminal.EnterMoveNextControl = true;
            txtMaxTerminal.Location = new Point(198, 120);
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
            txtMaxTerminal.Size = new Size(188, 22);
            txtMaxTerminal.StatusBarAciklama = null;
            txtMaxTerminal.StyleController = myDataLayoutControl1;
            txtMaxTerminal.TabIndex = 2;
            txtMaxTerminal.Tag = "MaxTerminal";
            // 
            // txtLicenseKey
            // 
            txtLicenseKey.EnterMoveNextControl = true;
            txtLicenseKey.Location = new Point(198, 43);
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
            txtLicenseKey.Properties.ReadOnly = true;
            txtLicenseKey.Size = new Size(188, 73);
            txtLicenseKey.StatusBarAciklama = "Açıklama Giriniz.";
            txtLicenseKey.StyleController = myDataLayoutControl1;
            txtLicenseKey.TabIndex = 1;
            txtLicenseKey.Tag = "LicenseKey";
            // 
            // dtExpirationDate
            // 
            dtExpirationDate.EditValue = null;
            dtExpirationDate.EnterMoveNextControl = true;
            dtExpirationDate.Location = new Point(198, 151);
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
            dtExpirationDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            dtExpirationDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            dtExpirationDate.Properties.MaskSettings.Set("useAdvancingCaret", true);
            dtExpirationDate.Properties.ReadOnly = true;
            dtExpirationDate.Size = new Size(188, 22);
            dtExpirationDate.StatusBarAciklama = null;
            dtExpirationDate.StatusBarKisaYol = "F4 :";
            dtExpirationDate.StatusBarKisaYolAciklama = "Tarih Seç";
            dtExpirationDate.StyleController = myDataLayoutControl1;
            dtExpirationDate.TabIndex = 3;
            dtExpirationDate.Tag = "ExpirationDate";
            // 
            // txtHardwareId
            // 
            txtHardwareId.EnterMoveNextControl = true;
            txtHardwareId.Location = new Point(198, 12);
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
            txtHardwareId.Size = new Size(188, 22);
            txtHardwareId.StatusBarAciklama = null;
            txtHardwareId.StyleController = myDataLayoutControl1;
            txtHardwareId.TabIndex = 0;
            txtHardwareId.Tag = "ServerHardwareId";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem4, layoutControlItem7, layoutControlItem3 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition1.SizeType = SizeType.Percent;
            columnDefinition1.Width = 100D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1 });
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            rowDefinition2.Height = 100D;
            rowDefinition2.SizeType = SizeType.Percent;
            rowDefinition3.Height = 31D;
            rowDefinition3.SizeType = SizeType.Absolute;
            rowDefinition4.Height = 31D;
            rowDefinition4.SizeType = SizeType.Absolute;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4 });
            Root.Size = new Size(398, 190);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtHardwareId;
            layoutControlItem1.CustomizationFormText = "Server Makine Kimliği";
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(378, 31);
            layoutControlItem1.Text = "Sunucu Donanım Kimliği (HWID)";
            layoutControlItem1.TextSize = new Size(174, 15);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = dtExpirationDate;
            layoutControlItem4.Location = new Point(0, 139);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem4.Size = new Size(378, 31);
            layoutControlItem4.Text = "Geçerlilik Bitiş Tarihi";
            layoutControlItem4.TextSize = new Size(174, 15);
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem7.Control = txtLicenseKey;
            layoutControlItem7.Location = new Point(0, 31);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem7.Size = new Size(378, 77);
            layoutControlItem7.Text = "Lisans Anahtarı";
            layoutControlItem7.TextSize = new Size(174, 15);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = txtMaxTerminal;
            layoutControlItem3.Location = new Point(0, 108);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(378, 31);
            layoutControlItem3.Text = "Maksimum Terminal";
            layoutControlItem3.TextSize = new Size(174, 15);
            // 
            // SystemLicenseEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 349);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 350);
            Name = "SystemLicenseEditForm";
            Text = "Lisans Bilgileri";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtMaxTerminal.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLicenseKey.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHardwareId.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.MyDataLayoutControl myDataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.MyDateEdit dtExpirationDate;
        private UserControls.MyTextEdit txtHardwareId;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private UserControls.MyMemoEdit txtLicenseKey;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private UserControls.MySpinEdit txtMaxTerminal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}