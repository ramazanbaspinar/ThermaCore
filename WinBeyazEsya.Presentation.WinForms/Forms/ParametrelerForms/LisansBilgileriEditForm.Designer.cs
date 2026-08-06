namespace WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms
{
    partial class LisansBilgileriEditForm
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
            myDataLayoutControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            dtExpirationDate = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDateEdit();
            txtMaxTerminal = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MySpinEdit();
            txtLicenseKey = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyMemoEdit();
            txtHardwareId = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyKodTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMaxTerminal.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLicenseKey.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHardwareId.Properties).BeginInit();
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
            myDataLayoutControl1.Controls.Add(dtExpirationDate);
            myDataLayoutControl1.Controls.Add(txtMaxTerminal);
            myDataLayoutControl1.Controls.Add(txtLicenseKey);
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
            // dtExpirationDate
            // 
            dtExpirationDate.EditValue = null;
            dtExpirationDate.EnterMoveNextControl = true;
            dtExpirationDate.Location = new Point(173, 151);
            dtExpirationDate.MenuManager = ribbon;
            dtExpirationDate.Name = "dtExpirationDate";
            dtExpirationDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            dtExpirationDate.Properties.Appearance.Options.UseTextOptions = true;
            dtExpirationDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            dtExpirationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtExpirationDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtExpirationDate.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            dtExpirationDate.Properties.MaskSettings.Set("useAdvancingCaret", true);
            dtExpirationDate.Properties.ReadOnly = true;
            dtExpirationDate.Size = new Size(213, 20);
            dtExpirationDate.StatusBarAciklama = "";
            dtExpirationDate.StatusBarKisaYol = "F4 :";
            dtExpirationDate.StatusBarKisaYolAciklama = "Tarih Seç";
            dtExpirationDate.StyleController = myDataLayoutControl1;
            dtExpirationDate.TabIndex = 3;
            dtExpirationDate.Tag = "ExpirationDate";
            // 
            // txtMaxTerminal
            // 
            txtMaxTerminal.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtMaxTerminal.EnterMoveNextControl = true;
            txtMaxTerminal.Location = new Point(173, 120);
            txtMaxTerminal.MenuManager = ribbon;
            txtMaxTerminal.Name = "txtMaxTerminal";
            txtMaxTerminal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtMaxTerminal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtMaxTerminal.Properties.MaskSettings.Set("mask", "n0");
            txtMaxTerminal.Properties.ReadOnly = true;
            txtMaxTerminal.Size = new Size(213, 20);
            txtMaxTerminal.StatusBarAciklama = "";
            txtMaxTerminal.StyleController = myDataLayoutControl1;
            txtMaxTerminal.TabIndex = 2;
            txtMaxTerminal.Tag = "MaxTerminal";
            // 
            // txtLicenseKey
            // 
            txtLicenseKey.EnterMoveNextControl = true;
            txtLicenseKey.Location = new Point(173, 43);
            txtLicenseKey.MenuManager = ribbon;
            txtLicenseKey.Name = "txtLicenseKey";
            txtLicenseKey.Properties.MaxLength = 500;
            txtLicenseKey.Properties.ReadOnly = true;
            txtLicenseKey.Size = new Size(213, 73);
            txtLicenseKey.StatusBarAciklama = "Açıklama Giriniz.";
            txtLicenseKey.StyleController = myDataLayoutControl1;
            txtLicenseKey.TabIndex = 1;
            txtLicenseKey.Tag = "LicenseKey";
            // 
            // txtHardwareId
            // 
            txtHardwareId.EnterMoveNextControl = true;
            txtHardwareId.Location = new Point(173, 12);
            txtHardwareId.MenuManager = ribbon;
            txtHardwareId.Name = "txtHardwareId";
            txtHardwareId.Properties.Appearance.Options.UseTextOptions = true;
            txtHardwareId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtHardwareId.Properties.MaxLength = 100;
            txtHardwareId.Properties.ReadOnly = true;
            txtHardwareId.Size = new Size(213, 20);
            txtHardwareId.StatusBarAciklama = "Kod Giriniz.";
            txtHardwareId.StyleController = myDataLayoutControl1;
            txtHardwareId.TabIndex = 0;
            txtHardwareId.Tag = "ServerHardwareId";
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
            layoutControlItem1.Control = txtHardwareId;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(378, 31);
            layoutControlItem1.Text = "Sunucu Donanım Kimliği (HWID)";
            layoutControlItem1.TextSize = new Size(149, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtLicenseKey;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(378, 77);
            layoutControlItem2.Text = "Lisans Anahtarı";
            layoutControlItem2.TextSize = new Size(149, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtMaxTerminal;
            layoutControlItem3.Location = new Point(0, 108);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(378, 31);
            layoutControlItem3.Text = "Maksimum Terminal";
            layoutControlItem3.TextSize = new Size(149, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = dtExpirationDate;
            layoutControlItem4.Location = new Point(0, 139);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem4.Size = new Size(378, 31);
            layoutControlItem4.Text = "Geçerlilik Bitiş Tarihi";
            layoutControlItem4.TextSize = new Size(149, 13);
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
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtExpirationDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMaxTerminal.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLicenseKey.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHardwareId.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MyMemoEdit txtLicenseKey;
        private UserControls.Controls.MyKodTextEdit txtHardwareId;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private UserControls.Controls.MyDateEdit dtExpirationDate;
        private UserControls.Controls.MySpinEdit txtMaxTerminal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
