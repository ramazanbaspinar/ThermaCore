namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControlPro1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            txtAciklama = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyMemoEdit();
            txtBirimAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            tglDurum = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyToggleSwitch();
            txtKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyKodTextEdit();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControlPro1).BeginInit();
            myDataLayoutControlPro1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBirimAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).BeginInit();
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
            // myDataLayoutControlPro1
            // 
            myDataLayoutControlPro1.AllowCustomization = false;
            myDataLayoutControlPro1.Controls.Add(txtAciklama);
            myDataLayoutControlPro1.Controls.Add(txtBirimAdi);
            myDataLayoutControlPro1.Controls.Add(tglDurum);
            myDataLayoutControlPro1.Controls.Add(txtKod);
            myDataLayoutControlPro1.Dock = DockStyle.Fill;
            myDataLayoutControlPro1.Location = new Point(0, 135);
            myDataLayoutControlPro1.Name = "myDataLayoutControlPro1";
            myDataLayoutControlPro1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControlPro1.Root = Root;
            myDataLayoutControlPro1.Size = new Size(398, 140);
            myDataLayoutControlPro1.TabIndex = 0;
            myDataLayoutControlPro1.Text = "myDataLayoutControlPro1";
            // 
            // txtAciklama
            // 
            txtAciklama.EnterMoveNextControl = true;
            txtAciklama.Location = new Point(65, 74);
            txtAciklama.MenuManager = ribbon;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Properties.MaxLength = 500;
            txtAciklama.Size = new Size(321, 54);
            txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            txtAciklama.StyleController = myDataLayoutControlPro1;
            txtAciklama.TabIndex = 2;
            txtAciklama.Tag = "Description";
            // 
            // txtBirimAdi
            // 
            txtBirimAdi.EnterMoveNextControl = true;
            txtBirimAdi.Location = new Point(65, 43);
            txtBirimAdi.MenuManager = ribbon;
            txtBirimAdi.Name = "txtBirimAdi";
            txtBirimAdi.Properties.MaxLength = 100;
            txtBirimAdi.Size = new Size(321, 20);
            txtBirimAdi.StatusBarAciklama = "";
            txtBirimAdi.StyleController = myDataLayoutControlPro1;
            txtBirimAdi.TabIndex = 1;
            txtBirimAdi.Tag = "Name";
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
            tglDurum.StyleController = myDataLayoutControlPro1;
            tglDurum.TabIndex = 3;
            tglDurum.Tag = "IsActive";
            // 
            // txtKod
            // 
            txtKod.EnterMoveNextControl = true;
            txtKod.Location = new Point(65, 12);
            txtKod.MenuManager = ribbon;
            txtKod.Name = "txtKod";
            txtKod.Properties.Appearance.Options.UseTextOptions = true;
            txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtKod.Properties.MaxLength = 100;
            txtKod.Size = new Size(212, 20);
            txtKod.StatusBarAciklama = "Kod Giriniz.";
            txtKod.StyleController = myDataLayoutControlPro1;
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
            Root.Size = new Size(398, 140);
            Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtKod;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(269, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(41, 13);
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
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtBirimAdi;
            layoutControlItem3.Location = new Point(0, 31);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem3.Size = new Size(378, 31);
            layoutControlItem3.Text = "Birim Adı";
            layoutControlItem3.TextSize = new Size(41, 13);
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = txtAciklama;
            layoutControlItem4.Location = new Point(0, 62);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnSpan = 3;
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem4.Size = new Size(378, 58);
            layoutControlItem4.Text = "Açıklama";
            layoutControlItem4.TextSize = new Size(41, 13);
            // 
            // BirimEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 299);
            Controls.Add(myDataLayoutControlPro1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 300);
            Name = "BirimEditForm";
            Text = "Birim Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControlPro1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControlPro1).EndInit();
            myDataLayoutControlPro1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBirimAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).EndInit();
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

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControlPro1;
        private UserControls.Controls.MyTextEdit txtBirimAdi;
        private UserControls.Controls.MyToggleSwitch tglDurum;
        private UserControls.Controls.MyKodTextEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private UserControls.Controls.MyMemoEdit txtAciklama;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
