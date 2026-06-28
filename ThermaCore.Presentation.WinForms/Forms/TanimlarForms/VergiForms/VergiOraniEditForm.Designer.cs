namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.VergiForms
{
    partial class VergiOraniEditForm
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
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            cmbVergiTuru = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyComboBoxEdit();
            myMemoEdit1 = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyMemoEdit();
            txtOran = new ThermaCore.Presentation.WinForms.UserControls.Controls.MySpinEdit();
            tglDurum = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyToggleSwitch();
            txtKod = new ThermaCore.Presentation.WinForms.UserControls.Controls.MyKodTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbVergiTuru.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myMemoEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtOran.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
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
            myDataLayoutControl1.Controls.Add(cmbVergiTuru);
            myDataLayoutControl1.Controls.Add(myMemoEdit1);
            myDataLayoutControl1.Controls.Add(txtOran);
            myDataLayoutControl1.Controls.Add(tglDurum);
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
            // cmbVergiTuru
            // 
            cmbVergiTuru.EnterMoveNextControl = true;
            cmbVergiTuru.Location = new Point(100, 12);
            cmbVergiTuru.MenuManager = ribbon;
            cmbVergiTuru.Name = "cmbVergiTuru";
            cmbVergiTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbVergiTuru.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbVergiTuru.Size = new Size(177, 20);
            cmbVergiTuru.StatusBarAciklama = "";
            cmbVergiTuru.StatusBarKisaYol = "F4 :";
            cmbVergiTuru.StatusBarKisaYolAciklama = "";
            cmbVergiTuru.StyleController = myDataLayoutControl1;
            cmbVergiTuru.TabIndex = 0;
            cmbVergiTuru.Tag = "TaxType";
            // 
            // myMemoEdit1
            // 
            myMemoEdit1.EnterMoveNextControl = true;
            myMemoEdit1.Location = new Point(100, 105);
            myMemoEdit1.MenuManager = ribbon;
            myMemoEdit1.Name = "myMemoEdit1";
            myMemoEdit1.Properties.MaxLength = 500;
            myMemoEdit1.Size = new Size(286, 23);
            myMemoEdit1.StatusBarAciklama = "Açıklama Giriniz.";
            myMemoEdit1.StyleController = myDataLayoutControl1;
            myMemoEdit1.TabIndex = 3;
            myMemoEdit1.Tag = "Description";
            // 
            // txtOran
            // 
            txtOran.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            txtOran.EnterMoveNextControl = true;
            txtOran.Location = new Point(100, 74);
            txtOran.MenuManager = ribbon;
            txtOran.Name = "txtOran";
            txtOran.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            txtOran.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtOran.Properties.DisplayFormat.FormatString = "n2";
            txtOran.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtOran.Properties.EditFormat.FormatString = "n2";
            txtOran.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtOran.Properties.MaskSettings.Set("mask", "n2");
            txtOran.Properties.MaxValue = new decimal(new int[] { 100, 0, 0, 0 });
            txtOran.Size = new Size(286, 20);
            txtOran.StatusBarAciklama = "";
            txtOran.StyleController = myDataLayoutControl1;
            txtOran.TabIndex = 2;
            txtOran.Tag = "Rate";
            // 
            // tglDurum
            // 
            tglDurum.EnterMoveNextControl = true;
            tglDurum.Location = new Point(291, 12);
            tglDurum.MenuManager = ribbon;
            tglDurum.Name = "tglDurum";
            tglDurum.Properties.AutoHeight = false;
            tglDurum.Properties.AutoWidth = true;
            tglDurum.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            tglDurum.Properties.OffText = "Pasif";
            tglDurum.Properties.OnText = "Aktif";
            tglDurum.Size = new Size(77, 27);
            tglDurum.StatusBarAciklama = "Kayıtın Kullanım Durumunu Seçiniz.";
            tglDurum.StyleController = myDataLayoutControl1;
            tglDurum.TabIndex = 4;
            tglDurum.Tag = "IsActive";
            // 
            // txtKod
            // 
            txtKod.EnterMoveNextControl = true;
            txtKod.Location = new Point(100, 43);
            txtKod.MenuManager = ribbon;
            txtKod.Name = "txtKod";
            txtKod.Properties.Appearance.Options.UseTextOptions = true;
            txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtKod.Properties.MaxLength = 100;
            txtKod.Size = new Size(286, 20);
            txtKod.StatusBarAciklama = "Kod Giriniz.";
            txtKod.StyleController = myDataLayoutControl1;
            txtKod.TabIndex = 1;
            txtKod.Tag = "Code";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem3, layoutControlItem4, layoutControlItem2, layoutControlItem5 });
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
            rowDefinition3.Height = 31D;
            rowDefinition3.SizeType = SizeType.Absolute;
            rowDefinition4.Height = 100D;
            rowDefinition4.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4 });
            Root.Size = new Size(398, 140);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtKod;
            layoutControlItem1.Location = new Point(0, 31);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem1.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem1.Size = new Size(378, 31);
            layoutControlItem1.Text = "Vergi Kodu / Adı";
            layoutControlItem1.TextSize = new Size(76, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtOran;
            layoutControlItem3.Location = new Point(0, 62);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(378, 31);
            layoutControlItem3.Text = "Vergi Oranı (%)";
            layoutControlItem3.TextSize = new Size(76, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = myMemoEdit1;
            layoutControlItem4.Location = new Point(0, 93);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem4.Size = new Size(378, 27);
            layoutControlItem4.Text = "Açıklama";
            layoutControlItem4.TextSize = new Size(76, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = tglDurum;
            layoutControlItem2.Location = new Point(279, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem2.Size = new Size(99, 31);
            layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = cmbVergiTuru;
            layoutControlItem5.Location = new Point(0, 0);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.Size = new Size(269, 31);
            layoutControlItem5.Text = "Vergi Türü";
            layoutControlItem5.TextSize = new Size(76, 13);
            // 
            // VergiOraniEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 299);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 300);
            Name = "VergiOraniEditForm";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cmbVergiTuru.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)myMemoEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtOran.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MyMemoEdit myMemoEdit1;
        private UserControls.Controls.MySpinEdit txtOran;
        private UserControls.Controls.MyToggleSwitch tglDurum;
        private UserControls.Controls.MyKodTextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private UserControls.Controls.MyComboBoxEdit cmbVergiTuru;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}