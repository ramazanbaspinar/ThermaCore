namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms.CamTipiForms
{
    partial class CamTipiEditForm
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition4 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition4 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition6 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            txtCamTipiAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            txtKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyKodTextEdit();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            txtAciklama = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyMemoEdit();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            tglDurum = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyToggleSwitch();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCamTipiAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).BeginInit();
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
            myDataLayoutControl1.Controls.Add(txtKod);
            myDataLayoutControl1.Controls.Add(txtCamTipiAdi);
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
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem2, layoutControlItem1, layoutControlItem3, layoutControlItem4 });
            Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            Root.Name = "Root";
            columnDefinition3.SizeType = SizeType.Percent;
            columnDefinition3.Width = 100D;
            columnDefinition4.SizeType = SizeType.Absolute;
            columnDefinition4.Width = 99D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition3, columnDefinition4 });
            rowDefinition4.Height = 31D;
            rowDefinition4.SizeType = SizeType.Absolute;
            rowDefinition5.Height = 31D;
            rowDefinition5.SizeType = SizeType.Absolute;
            rowDefinition6.Height = 100D;
            rowDefinition6.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition4, rowDefinition5, rowDefinition6 });
            Root.Size = new Size(398, 140);
            Root.TextVisible = false;
            // 
            // txtCamTipiAdi
            // 
            txtCamTipiAdi.EnterMoveNextControl = true;
            txtCamTipiAdi.Location = new Point(82, 43);
            txtCamTipiAdi.MenuManager = ribbon;
            txtCamTipiAdi.Name = "txtCamTipiAdi";
            txtCamTipiAdi.Properties.MaxLength = 100;
            txtCamTipiAdi.Size = new Size(304, 20);
            txtCamTipiAdi.StatusBarAciklama = "";
            txtCamTipiAdi.StyleController = myDataLayoutControl1;
            txtCamTipiAdi.TabIndex = 0;
            txtCamTipiAdi.Tag = "Name";
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtCamTipiAdi;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(378, 31);
            layoutControlItem2.Text = "Cam Tipi Adı";
            layoutControlItem2.TextSize = new Size(58, 13);
            // 
            // txtKod
            // 
            txtKod.EnterMoveNextControl = true;
            txtKod.Location = new Point(82, 12);
            txtKod.MenuManager = ribbon;
            txtKod.Name = "txtKod";
            txtKod.Properties.Appearance.Options.UseTextOptions = true;
            txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtKod.Properties.MaxLength = 100;
            txtKod.Size = new Size(205, 20);
            txtKod.StatusBarAciklama = "Kod Giriniz.";
            txtKod.StyleController = myDataLayoutControl1;
            txtKod.TabIndex = 3;
            txtKod.Tag = "Code";
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtKod;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(279, 31);
            layoutControlItem1.Text = "Kod";
            layoutControlItem1.TextSize = new Size(58, 13);
            // 
            // txtAciklama
            // 
            txtAciklama.EnterMoveNextControl = true;
            txtAciklama.Location = new Point(82, 74);
            txtAciklama.MenuManager = ribbon;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Properties.MaxLength = 500;
            txtAciklama.Size = new Size(304, 54);
            txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            txtAciklama.StyleController = myDataLayoutControl1;
            txtAciklama.TabIndex = 1;
            txtAciklama.Tag = "Description";
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtAciklama;
            layoutControlItem3.Location = new Point(0, 62);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(378, 58);
            layoutControlItem3.Text = "Açıklama";
            layoutControlItem3.TextSize = new Size(58, 13);
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
            tglDurum.TabIndex = 2;
            tglDurum.Tag = "IsActive";
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = tglDurum;
            layoutControlItem4.Location = new Point(279, 0);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem4.Size = new Size(99, 31);
            layoutControlItem4.TextVisible = false;
            // 
            // CamTipiEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 299);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(400, 300);
            Name = "CamTipiEditForm";
            Text = "Cam Tipi Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCamTipiAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MyToggleSwitch tglDurum;
        private UserControls.Controls.MyMemoEdit txtAciklama;
        private UserControls.Controls.MyKodTextEdit txtKod;
        private UserControls.Controls.MyTextEdit txtCamTipiAdi;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
