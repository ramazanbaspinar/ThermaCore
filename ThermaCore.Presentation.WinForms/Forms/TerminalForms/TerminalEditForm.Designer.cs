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
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.MyDataLayoutControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            txtCihazAdi = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            txtMacAdresi = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            txtIpAdresi = new ThermaCore.Presentation.WinForms.UserControls.MyTextEdit();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            txtAciklama = new ThermaCore.Presentation.WinForms.UserControls.MyMemoEdit();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            txtKod = new ThermaCore.Presentation.WinForms.UserControls.MyKodTextEdit();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCihazAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMacAdresi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIpAdresi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
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
            myDataLayoutControl1.Controls.Add(txtKod);
            myDataLayoutControl1.Controls.Add(txtAciklama);
            myDataLayoutControl1.Controls.Add(txtIpAdresi);
            myDataLayoutControl1.Controls.Add(txtMacAdresi);
            myDataLayoutControl1.Controls.Add(txtCihazAdi);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(398, 140);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
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
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1 });
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            rowDefinition2.Height = 31D;
            rowDefinition2.SizeType = SizeType.Absolute;
            rowDefinition3.Height = 31D;
            rowDefinition3.SizeType = SizeType.Absolute;
            rowDefinition4.Height = 31D;
            rowDefinition4.SizeType = SizeType.Absolute;
            rowDefinition5.Height = 100D;
            rowDefinition5.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4, rowDefinition5 });
            Root.Size = new Size(381, 166);
            Root.TextVisible = false;
            // 
            // txtCihazAdi
            // 
            txtCihazAdi.EnterMoveNextControl = true;
            txtCihazAdi.Location = new Point(83, 43);
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
            txtCihazAdi.Size = new Size(286, 22);
            txtCihazAdi.StatusBarAciklama = null;
            txtCihazAdi.StyleController = myDataLayoutControl1;
            txtCihazAdi.TabIndex = 0;
            txtCihazAdi.Tag = "DeviceName";
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem1.Control = txtCihazAdi;
            layoutControlItem1.Location = new Point(0, 31);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem1.Size = new Size(361, 31);
            layoutControlItem1.Text = "Cihaz Adı";
            layoutControlItem1.TextSize = new Size(59, 15);
            // 
            // txtMacAdresi
            // 
            txtMacAdresi.EnterMoveNextControl = true;
            txtMacAdresi.Location = new Point(83, 74);
            txtMacAdresi.MenuManager = ribbon;
            txtMacAdresi.Name = "txtMacAdresi";
            txtMacAdresi.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtMacAdresi.Properties.Appearance.Options.UseFont = true;
            txtMacAdresi.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtMacAdresi.Properties.AppearanceDisabled.Options.UseFont = true;
            txtMacAdresi.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtMacAdresi.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtMacAdresi.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtMacAdresi.Properties.AppearanceFocused.Options.UseFont = true;
            txtMacAdresi.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtMacAdresi.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtMacAdresi.Properties.MaxLength = 100;
            txtMacAdresi.Size = new Size(286, 22);
            txtMacAdresi.StatusBarAciklama = null;
            txtMacAdresi.StyleController = myDataLayoutControl1;
            txtMacAdresi.TabIndex = 1;
            txtMacAdresi.Tag = "MacAddress";
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem2.Control = txtMacAdresi;
            layoutControlItem2.Location = new Point(0, 62);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem2.Size = new Size(361, 31);
            layoutControlItem2.Text = "Mac Adresi";
            layoutControlItem2.TextSize = new Size(59, 15);
            // 
            // txtIpAdresi
            // 
            txtIpAdresi.EnterMoveNextControl = true;
            txtIpAdresi.Location = new Point(83, 105);
            txtIpAdresi.MenuManager = ribbon;
            txtIpAdresi.Name = "txtIpAdresi";
            txtIpAdresi.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtIpAdresi.Properties.Appearance.Options.UseFont = true;
            txtIpAdresi.Properties.AppearanceDisabled.Font = new Font("Segoe UI", 9F);
            txtIpAdresi.Properties.AppearanceDisabled.Options.UseFont = true;
            txtIpAdresi.Properties.AppearanceFocused.BackColor = Color.FromArgb(255, 255, 192);
            txtIpAdresi.Properties.AppearanceFocused.Font = new Font("Segoe UI", 9F);
            txtIpAdresi.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtIpAdresi.Properties.AppearanceFocused.Options.UseFont = true;
            txtIpAdresi.Properties.AppearanceReadOnly.Font = new Font("Segoe UI", 9F);
            txtIpAdresi.Properties.AppearanceReadOnly.Options.UseFont = true;
            txtIpAdresi.Properties.MaxLength = 100;
            txtIpAdresi.Size = new Size(286, 22);
            txtIpAdresi.StatusBarAciklama = null;
            txtIpAdresi.StyleController = myDataLayoutControl1;
            txtIpAdresi.TabIndex = 2;
            txtIpAdresi.Tag = "IpAddress";
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem3.Control = txtIpAdresi;
            layoutControlItem3.Location = new Point(0, 93);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem3.Size = new Size(361, 31);
            layoutControlItem3.Text = "IP Adresi";
            layoutControlItem3.TextSize = new Size(59, 15);
            // 
            // txtAciklama
            // 
            txtAciklama.EnterMoveNextControl = true;
            txtAciklama.Location = new Point(83, 136);
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
            txtAciklama.Size = new Size(286, 18);
            txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            txtAciklama.StyleController = myDataLayoutControl1;
            txtAciklama.TabIndex = 3;
            txtAciklama.Tag = "Description";
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem4.Control = txtAciklama;
            layoutControlItem4.Location = new Point(0, 124);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 4;
            layoutControlItem4.Size = new Size(361, 22);
            layoutControlItem4.Text = "Açıklama";
            layoutControlItem4.TextSize = new Size(59, 15);
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
            txtKod.Size = new Size(286, 22);
            txtKod.StatusBarAciklama = "Kod Giriniz.";
            txtKod.StyleController = myDataLayoutControl1;
            txtKod.TabIndex = 4;
            txtKod.Tag = "Code";
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.AppearanceItemCaption.Font = new Font("Segoe UI", 9F);
            layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            layoutControlItem5.Control = txtKod;
            layoutControlItem5.Location = new Point(0, 0);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(361, 31);
            layoutControlItem5.Text = "Kod";
            layoutControlItem5.TextSize = new Size(59, 15);
            // 
            // TerminalEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 299);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 300);
            Name = "TerminalEditForm";
            Text = "Terminal Tanım";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCihazAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMacAdresi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIpAdresi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.MyMemoEdit txtAciklama;
        private UserControls.MyTextEdit txtIpAdresi;
        private UserControls.MyTextEdit txtMacAdresi;
        private UserControls.MyTextEdit txtCihazAdi;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private UserControls.MyKodTextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}