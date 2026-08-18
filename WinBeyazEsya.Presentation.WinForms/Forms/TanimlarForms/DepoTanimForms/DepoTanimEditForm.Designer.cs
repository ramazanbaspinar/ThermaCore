namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DepoTanimForms
{
    partial class DepoTanimEditForm
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
            myDataLayoutControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            tglDurum = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyToggleSwitch();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            txtKod = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyKodTextEdit();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            txtDepoAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            txtYetkili = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            txtAciklama = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyMemoEdit();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDepoAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtYetkili.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(448, 155);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(txtAciklama);
            myDataLayoutControl1.Controls.Add(txtYetkili);
            myDataLayoutControl1.Controls.Add(txtDepoAdi);
            myDataLayoutControl1.Controls.Add(txtKod);
            myDataLayoutControl1.Controls.Add(tglDurum);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 155);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(448, 163);
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
            columnDefinition2.SizeType = SizeType.Absolute;
            columnDefinition2.Width = 99D;
            Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] { columnDefinition1, columnDefinition2 });
            rowDefinition1.Height = 31D;
            rowDefinition1.SizeType = SizeType.Absolute;
            rowDefinition2.Height = 31D;
            rowDefinition2.SizeType = SizeType.Absolute;
            rowDefinition3.Height = 31D;
            rowDefinition3.SizeType = SizeType.Absolute;
            rowDefinition4.Height = 100D;
            rowDefinition4.SizeType = SizeType.Percent;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4 });
            Root.Size = new Size(448, 163);
            Root.TextVisible = false;
            // 
            // tglDurum
            // 
            tglDurum.EnterMoveNextControl = true;
            tglDurum.Location = new Point(341, 12);
            tglDurum.MenuManager = ribbon;
            tglDurum.Name = "tglDurum";
            tglDurum.Properties.AutoHeight = false;
            tglDurum.Properties.AutoWidth = true;
            tglDurum.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            tglDurum.Properties.OffText = "Pasif";
            tglDurum.Properties.OnText = "Aktif";
            tglDurum.Size = new Size(81, 27);
            tglDurum.StatusBarAciklama = "Kayıtın Kullanım Durumunu Seçiniz.";
            tglDurum.StyleController = myDataLayoutControl1;
            tglDurum.TabIndex = 3;
            tglDurum.Tag = "IsActive";
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = tglDurum;
            layoutControlItem1.Location = new Point(329, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 1;
            layoutControlItem1.Size = new Size(99, 31);
            layoutControlItem1.TextVisible = false;
            // 
            // txtKod
            // 
            txtKod.EnterMoveNextControl = true;
            txtKod.Location = new Point(74, 12);
            txtKod.MenuManager = ribbon;
            txtKod.Name = "txtKod";
            txtKod.Properties.Appearance.Options.UseTextOptions = true;
            txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtKod.Properties.MaxLength = 100;
            txtKod.Size = new Size(263, 22);
            txtKod.StatusBarAciklama = "Kod Giriniz.";
            txtKod.StyleController = myDataLayoutControl1;
            txtKod.TabIndex = 4;
            txtKod.Tag = "Code";
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtKod;
            layoutControlItem2.Location = new Point(0, 0);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.Size = new Size(329, 31);
            layoutControlItem2.Text = "Kod";
            layoutControlItem2.TextSize = new Size(50, 13);
            // 
            // txtDepoAdi
            // 
            txtDepoAdi.EnterMoveNextControl = true;
            txtDepoAdi.Location = new Point(74, 43);
            txtDepoAdi.MenuManager = ribbon;
            txtDepoAdi.Name = "txtDepoAdi";
            txtDepoAdi.Properties.MaxLength = 100;
            txtDepoAdi.Size = new Size(362, 22);
            txtDepoAdi.StatusBarAciklama = "";
            txtDepoAdi.StyleController = myDataLayoutControl1;
            txtDepoAdi.TabIndex = 0;
            txtDepoAdi.Tag = "Name";
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtDepoAdi;
            layoutControlItem3.Location = new Point(0, 31);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem3.Size = new Size(428, 31);
            layoutControlItem3.Text = "Depo Adı";
            layoutControlItem3.TextSize = new Size(50, 13);
            // 
            // txtYetkili
            // 
            txtYetkili.EnterMoveNextControl = true;
            txtYetkili.Location = new Point(74, 74);
            txtYetkili.MenuManager = ribbon;
            txtYetkili.Name = "txtYetkili";
            txtYetkili.Properties.MaxLength = 100;
            txtYetkili.Size = new Size(362, 22);
            txtYetkili.StatusBarAciklama = "";
            txtYetkili.StyleController = myDataLayoutControl1;
            txtYetkili.TabIndex = 1;
            txtYetkili.Tag = "AuthorizedPerson";
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = txtYetkili;
            layoutControlItem4.Location = new Point(0, 62);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem4.Size = new Size(428, 31);
            layoutControlItem4.Text = "Yetkili Kişi";
            layoutControlItem4.TextSize = new Size(50, 13);
            // 
            // txtAciklama
            // 
            txtAciklama.EnterMoveNextControl = true;
            txtAciklama.Location = new Point(74, 105);
            txtAciklama.MenuManager = ribbon;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Properties.MaxLength = 500;
            txtAciklama.Size = new Size(362, 46);
            txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            txtAciklama.StyleController = myDataLayoutControl1;
            txtAciklama.TabIndex = 2;
            txtAciklama.Tag = "Description";
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = txtAciklama;
            layoutControlItem5.Location = new Point(0, 93);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.OptionsTableLayoutItem.ColumnSpan = 2;
            layoutControlItem5.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem5.Size = new Size(428, 50);
            layoutControlItem5.Text = "Açıklama";
            layoutControlItem5.TextSize = new Size(50, 13);
            // 
            // DepoTanimEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 349);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(450, 350);
            Name = "DepoTanimEditForm";
            Text = "Depo Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)tglDurum.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtKod.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDepoAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtYetkili.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAciklama.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MyMemoEdit txtAciklama;
        private UserControls.Controls.MyTextEdit txtYetkili;
        private UserControls.Controls.MyTextEdit txtDepoAdi;
        private UserControls.Controls.MyKodTextEdit txtKod;
        private UserControls.Controls.MyToggleSwitch tglDurum;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}