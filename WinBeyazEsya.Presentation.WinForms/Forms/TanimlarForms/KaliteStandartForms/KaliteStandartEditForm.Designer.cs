namespace WinBeyazEsya.Presentation.WinForms.Forms.KaliteStandartForms
{
    partial class KaliteStandartEditForm
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition5 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition6 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition6 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition7 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition8 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            tglDurum = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyToggleSwitch();
            txtAciklama = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyMemoEdit();
            txtStandartAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            cmbMalzemeTuru = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyComboBoxEdit();
            txtKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyKodTextEdit();
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
            ((System.ComponentModel.ISupportInitialize)txtStandartAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbMalzemeTuru.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
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
            ribbon.Size = new Size(398, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(tglDurum);
            myDataLayoutControl1.Controls.Add(txtAciklama);
            myDataLayoutControl1.Controls.Add(txtStandartAdi);
            myDataLayoutControl1.Controls.Add(cmbMalzemeTuru);
            myDataLayoutControl1.Controls.Add(txtKod);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(398, 165);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
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
            tglDurum.TabIndex = 3;
            tglDurum.Tag = "IsActive";
            // 
            // txtAciklama
            // 
            txtAciklama.EnterMoveNextControl = true;
            txtAciklama.Location = new Point(90, 105);
            txtAciklama.MenuManager = ribbon;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Properties.MaxLength = 500;
            txtAciklama.Size = new Size(296, 48);
            txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            txtAciklama.StyleController = myDataLayoutControl1;
            txtAciklama.TabIndex = 2;
            txtAciklama.Tag = "Description";
            // 
            // txtStandartAdi
            // 
            txtStandartAdi.EnterMoveNextControl = true;
            txtStandartAdi.Location = new Point(90, 74);
            txtStandartAdi.MenuManager = ribbon;
            txtStandartAdi.Name = "txtStandartAdi";
            txtStandartAdi.Properties.MaxLength = 100;
            txtStandartAdi.Size = new Size(296, 20);
            txtStandartAdi.StatusBarAciklama = "";
            txtStandartAdi.StyleController = myDataLayoutControl1;
            txtStandartAdi.TabIndex = 1;
            txtStandartAdi.Tag = "Name";
            // 
            // cmbMalzemeTuru
            // 
            cmbMalzemeTuru.EnterMoveNextControl = true;
            cmbMalzemeTuru.Location = new Point(90, 43);
            cmbMalzemeTuru.MenuManager = ribbon;
            cmbMalzemeTuru.Name = "cmbMalzemeTuru";
            cmbMalzemeTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbMalzemeTuru.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbMalzemeTuru.Size = new Size(296, 20);
            cmbMalzemeTuru.StatusBarAciklama = "";
            cmbMalzemeTuru.StatusBarKisaYol = "F4 :";
            cmbMalzemeTuru.StatusBarKisaYolAciklama = "";
            cmbMalzemeTuru.StyleController = myDataLayoutControl1;
            cmbMalzemeTuru.TabIndex = 0;
            cmbMalzemeTuru.Tag = "MaterialGroup";
            // 
            // txtKod
            // 
            txtKod.EnterMoveNextControl = true;
            txtKod.Location = new Point(90, 12);
            txtKod.MenuManager = ribbon;
            txtKod.Name = "txtKod";
            txtKod.Properties.Appearance.Options.UseTextOptions = true;
            txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtKod.Properties.MaxLength = 100;
            txtKod.Size = new Size(187, 20);
            txtKod.StatusBarAciklama = "Kod Giriniz.";
            txtKod.StyleController = myDataLayoutControl1;
            txtKod.TabIndex = 4;
            txtKod.Tag = "Code";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition4.SizeType = SizeType.Percent;
            columnDefinition4.Width = 100D;
            columnDefinition5.SizeType = SizeType.Absolute;
            columnDefinition5.Width = 10D;
            columnDefinition6.SizeType = SizeType.Absolute;
            columnDefinition6.Width = 99D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition4, columnDefinition5, columnDefinition6 });
            rowDefinition5.Height = 31D;
            rowDefinition5.SizeType = SizeType.Absolute;
            rowDefinition6.Height = 31D;
            rowDefinition6.SizeType = SizeType.Absolute;
            rowDefinition7.Height = 31D;
            rowDefinition7.SizeType = SizeType.Absolute;
            rowDefinition8.Height = 100D;
            rowDefinition8.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition5, rowDefinition6, rowDefinition7, rowDefinition8 });
            Root.Size = new Size(398, 165);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtKod;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(269, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(66, 13);
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = cmbMalzemeTuru;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(378, 31);
            layoutControlItem2.Text = "Malzeme Türü";
            layoutControlItem2.TextSize = new Size(66, 13);
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtStandartAdi;
            layoutControlItem3.Location = new Point(0, 62);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(378, 31);
            layoutControlItem3.Text = "Standart Adı";
            layoutControlItem3.TextSize = new Size(66, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = txtAciklama;
            layoutControlItem4.Location = new Point(0, 93);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem4.Size = new Size(378, 52);
            layoutControlItem4.Tag = "";
            layoutControlItem4.Text = "Açıklama";
            layoutControlItem4.TextSize = new Size(66, 13);
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = tglDurum;
            layoutControlItem5.Location = new Point(279, 0);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem5.Size = new Size(99, 31);
            layoutControlItem5.TextVisible = false;
            // 
            // KaliteStandartEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 324);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 325);
            Name = "KaliteStandartEditForm";
            Text = "Kalite Standart Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStandartAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbMalzemeTuru.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
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

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MyTextEdit txtStandartAdi;
        private UserControls.Controls.MyComboBoxEdit cmbMalzemeTuru;
        private UserControls.Controls.MyKodTextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private UserControls.Controls.MyToggleSwitch tglDurum;
        private UserControls.Controls.MyMemoEdit txtAciklama;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}
