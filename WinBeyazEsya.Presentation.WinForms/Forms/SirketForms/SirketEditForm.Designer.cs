namespace WinBeyazEsya.Presentation.WinForms.Forms.SirketForms
{
    partial class SirketEditForm
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
            DevExpress.XtraLayout.RowDefinition rowDefinition5 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition6 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition7 = new DevExpress.XtraLayout.RowDefinition();
            myDataLayoutControl1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyDataLayoutControl();
            Root = new DevExpress.XtraLayout.LayoutControlGroup();
            txtSirketKodu = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyKodTextEdit();
            layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            txtSirketAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            txtVeritabaniAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            txtServer = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            txtAuthType = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyComboBoxEdit();
            layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            txtSqlKullaniciAdi = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            txtSqlSifre = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyTextEdit();
            layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            myToggleSwitch1 = new WinBeyazEsya.Presentation.WinForms.UserControls.Controls.MyToggleSwitch();
            layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)ribbon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).BeginInit();
            myDataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Root).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSirketKodu.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSirketAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVeritabaniAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtServer.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAuthType.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSqlKullaniciAdi.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSqlSifre.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)myToggleSwitch1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
            SuspendLayout();
            // 
            // ribbon
            // 
            ribbon.ExpandCollapseItem.Id = 0;
            ribbon.Size = new Size(393, 135);
            ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl1
            // 
            myDataLayoutControl1.AllowCustomization = false;
            myDataLayoutControl1.Controls.Add(myToggleSwitch1);
            myDataLayoutControl1.Controls.Add(txtSqlSifre);
            myDataLayoutControl1.Controls.Add(txtSqlKullaniciAdi);
            myDataLayoutControl1.Controls.Add(txtAuthType);
            myDataLayoutControl1.Controls.Add(txtServer);
            myDataLayoutControl1.Controls.Add(txtVeritabaniAdi);
            myDataLayoutControl1.Controls.Add(txtSirketAdi);
            myDataLayoutControl1.Controls.Add(txtSirketKodu);
            myDataLayoutControl1.Dock = DockStyle.Fill;
            myDataLayoutControl1.Location = new Point(0, 135);
            myDataLayoutControl1.Name = "myDataLayoutControl1";
            myDataLayoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            myDataLayoutControl1.Root = Root;
            myDataLayoutControl1.Size = new Size(393, 215);
            myDataLayoutControl1.TabIndex = 0;
            myDataLayoutControl1.Text = "myDataLayoutControl1";
            // 
            // Root
            // 
            Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            Root.GroupBordersVisible = false;
            Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItem7, layoutControlItem8 });
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
            rowDefinition4.Height = 31D;
            rowDefinition4.SizeType = SizeType.Absolute;
            rowDefinition5.Height = 31D;
            rowDefinition5.SizeType = SizeType.Absolute;
            rowDefinition6.Height = 31D;
            rowDefinition6.SizeType = SizeType.Absolute;
            rowDefinition7.Height = 31D;
            rowDefinition7.SizeType = SizeType.Absolute;
            Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] { rowDefinition1, rowDefinition2, rowDefinition3, rowDefinition4, rowDefinition5, rowDefinition6, rowDefinition7 });
            Root.Size = new Size(376, 237);
            Root.TextVisible = false;
            // 
            // txtSirketKodu
            // 
            txtSirketKodu.EnterMoveNextControl = true;
            txtSirketKodu.Location = new Point(101, 12);
            txtSirketKodu.MenuManager = ribbon;
            txtSirketKodu.Name = "txtSirketKodu";
            txtSirketKodu.Properties.Appearance.Options.UseTextOptions = true;
            txtSirketKodu.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            txtSirketKodu.Properties.MaxLength = 100;
            txtSirketKodu.Size = new Size(154, 20);
            txtSirketKodu.StatusBarAciklama = "Kod Giriniz.";
            txtSirketKodu.StyleController = myDataLayoutControl1;
            txtSirketKodu.TabIndex = 0;
            txtSirketKodu.Tag = "CompanyCode";
            // 
            // layoutControlItem1
            // 
            layoutControlItem1.Control = txtSirketKodu;
            layoutControlItem1.Location = new Point(0, 0);
            layoutControlItem1.Name = "layoutControlItem1";
            layoutControlItem1.Size = new Size(247, 31);
            layoutControlItem1.Text = "Şirket Kodu";
            layoutControlItem1.TextSize = new Size(77, 13);
            // 
            // txtSirketAdi
            // 
            txtSirketAdi.EnterMoveNextControl = true;
            txtSirketAdi.Location = new Point(101, 43);
            txtSirketAdi.MenuManager = ribbon;
            txtSirketAdi.Name = "txtSirketAdi";
            txtSirketAdi.Properties.MaxLength = 100;
            txtSirketAdi.Size = new Size(154, 20);
            txtSirketAdi.StatusBarAciklama = "";
            txtSirketAdi.StyleController = myDataLayoutControl1;
            txtSirketAdi.TabIndex = 1;
            txtSirketAdi.Tag = "CompanyName";
            // 
            // layoutControlItem2
            // 
            layoutControlItem2.Control = txtSirketAdi;
            layoutControlItem2.Location = new Point(0, 31);
            layoutControlItem2.Name = "layoutControlItem2";
            layoutControlItem2.OptionsTableLayoutItem.RowIndex = 1;
            layoutControlItem2.Size = new Size(247, 31);
            layoutControlItem2.Text = "Şirket Adı";
            layoutControlItem2.TextSize = new Size(77, 13);
            // 
            // txtVeritabaniAdi
            // 
            txtVeritabaniAdi.EnterMoveNextControl = true;
            txtVeritabaniAdi.Location = new Point(101, 74);
            txtVeritabaniAdi.MenuManager = ribbon;
            txtVeritabaniAdi.Name = "txtVeritabaniAdi";
            txtVeritabaniAdi.Properties.MaxLength = 100;
            txtVeritabaniAdi.Size = new Size(154, 20);
            txtVeritabaniAdi.StatusBarAciklama = "";
            txtVeritabaniAdi.StyleController = myDataLayoutControl1;
            txtVeritabaniAdi.TabIndex = 2;
            txtVeritabaniAdi.Tag = "DatabaseName";
            // 
            // layoutControlItem3
            // 
            layoutControlItem3.Control = txtVeritabaniAdi;
            layoutControlItem3.Location = new Point(0, 62);
            layoutControlItem3.Name = "layoutControlItem3";
            layoutControlItem3.OptionsTableLayoutItem.RowIndex = 2;
            layoutControlItem3.Size = new Size(247, 31);
            layoutControlItem3.Text = "Veritabanı Adı";
            layoutControlItem3.TextSize = new Size(77, 13);
            // 
            // txtServer
            // 
            txtServer.EnterMoveNextControl = true;
            txtServer.Location = new Point(101, 105);
            txtServer.MenuManager = ribbon;
            txtServer.Name = "txtServer";
            txtServer.Properties.MaxLength = 100;
            txtServer.Size = new Size(154, 20);
            txtServer.StatusBarAciklama = "";
            txtServer.StyleController = myDataLayoutControl1;
            txtServer.TabIndex = 3;
            txtServer.Tag = "Server";
            // 
            // layoutControlItem4
            // 
            layoutControlItem4.Control = txtServer;
            layoutControlItem4.Location = new Point(0, 93);
            layoutControlItem4.Name = "layoutControlItem4";
            layoutControlItem4.OptionsTableLayoutItem.RowIndex = 3;
            layoutControlItem4.Size = new Size(247, 31);
            layoutControlItem4.Text = "Sunucu Adresi";
            layoutControlItem4.TextSize = new Size(77, 13);
            // 
            // txtAuthType
            // 
            txtAuthType.EnterMoveNextControl = true;
            txtAuthType.Location = new Point(101, 136);
            txtAuthType.MenuManager = ribbon;
            txtAuthType.Name = "txtAuthType";
            txtAuthType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            txtAuthType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            txtAuthType.Size = new Size(154, 20);
            txtAuthType.StatusBarAciklama = "";
            txtAuthType.StatusBarKisaYol = "F4 :";
            txtAuthType.StatusBarKisaYolAciklama = "";
            txtAuthType.StyleController = myDataLayoutControl1;
            txtAuthType.TabIndex = 4;
            txtAuthType.Tag = "AuthType";
            // 
            // layoutControlItem5
            // 
            layoutControlItem5.Control = txtAuthType;
            layoutControlItem5.Location = new Point(0, 124);
            layoutControlItem5.Name = "layoutControlItem5";
            layoutControlItem5.OptionsTableLayoutItem.RowIndex = 4;
            layoutControlItem5.Size = new Size(247, 31);
            layoutControlItem5.Text = "Yetki Türü";
            layoutControlItem5.TextSize = new Size(77, 13);
            // 
            // txtSqlKullaniciAdi
            // 
            txtSqlKullaniciAdi.EnterMoveNextControl = true;
            txtSqlKullaniciAdi.Location = new Point(101, 167);
            txtSqlKullaniciAdi.MenuManager = ribbon;
            txtSqlKullaniciAdi.Name = "txtSqlKullaniciAdi";
            txtSqlKullaniciAdi.Properties.MaxLength = 100;
            txtSqlKullaniciAdi.Size = new Size(154, 20);
            txtSqlKullaniciAdi.StatusBarAciklama = "";
            txtSqlKullaniciAdi.StyleController = myDataLayoutControl1;
            txtSqlKullaniciAdi.TabIndex = 5;
            txtSqlKullaniciAdi.Tag = "Username";
            // 
            // layoutControlItem6
            // 
            layoutControlItem6.Control = txtSqlKullaniciAdi;
            layoutControlItem6.Location = new Point(0, 155);
            layoutControlItem6.Name = "layoutControlItem6";
            layoutControlItem6.OptionsTableLayoutItem.RowIndex = 5;
            layoutControlItem6.Size = new Size(247, 31);
            layoutControlItem6.Text = "SQL Kullanıcı Adı";
            layoutControlItem6.TextSize = new Size(77, 13);
            // 
            // txtSqlSifre
            // 
            txtSqlSifre.EnterMoveNextControl = true;
            txtSqlSifre.Location = new Point(101, 198);
            txtSqlSifre.MenuManager = ribbon;
            txtSqlSifre.Name = "txtSqlSifre";
            txtSqlSifre.Properties.MaxLength = 100;
            txtSqlSifre.Properties.UseSystemPasswordChar = true;
            txtSqlSifre.Size = new Size(154, 20);
            txtSqlSifre.StatusBarAciklama = "";
            txtSqlSifre.StyleController = myDataLayoutControl1;
            txtSqlSifre.TabIndex = 6;
            txtSqlSifre.Tag = "Password";
            // 
            // layoutControlItem7
            // 
            layoutControlItem7.Control = txtSqlSifre;
            layoutControlItem7.Location = new Point(0, 186);
            layoutControlItem7.Name = "layoutControlItem7";
            layoutControlItem7.OptionsTableLayoutItem.RowIndex = 6;
            layoutControlItem7.Size = new Size(247, 31);
            layoutControlItem7.Text = "SQL Şifre";
            layoutControlItem7.TextSize = new Size(77, 13);
            // 
            // myToggleSwitch1
            // 
            myToggleSwitch1.EnterMoveNextControl = true;
            myToggleSwitch1.Location = new Point(269, 12);
            myToggleSwitch1.MenuManager = ribbon;
            myToggleSwitch1.Name = "myToggleSwitch1";
            myToggleSwitch1.Properties.AutoHeight = false;
            myToggleSwitch1.Properties.AutoWidth = true;
            myToggleSwitch1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            myToggleSwitch1.Properties.OffText = "Pasif";
            myToggleSwitch1.Properties.OnText = "Aktif";
            myToggleSwitch1.Size = new Size(77, 27);
            myToggleSwitch1.StatusBarAciklama = "Kayıtın Kullanım Durumunu Seçiniz.";
            myToggleSwitch1.StyleController = myDataLayoutControl1;
            myToggleSwitch1.TabIndex = 7;
            myToggleSwitch1.Tag = "IsActive";
            // 
            // layoutControlItem8
            // 
            layoutControlItem8.Control = myToggleSwitch1;
            layoutControlItem8.Location = new Point(257, 0);
            layoutControlItem8.Name = "layoutControlItem8";
            layoutControlItem8.OptionsTableLayoutItem.ColumnIndex = 2;
            layoutControlItem8.Size = new Size(99, 31);
            layoutControlItem8.TextVisible = false;
            // 
            // SirketEditForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 374);
            Controls.Add(myDataLayoutControl1);
            IconOptions.ShowIcon = false;
            MinimumSize = new Size(395, 375);
            Name = "SirketEditForm";
            Text = "Şirket Tanımı";
            Controls.SetChildIndex(ribbon, 0);
            Controls.SetChildIndex(myDataLayoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)ribbon).EndInit();
            ((System.ComponentModel.ISupportInitialize)myDataLayoutControl1).EndInit();
            myDataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Root).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSirketKodu.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSirketAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVeritabaniAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtServer.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAuthType.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSqlKullaniciAdi.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSqlSifre.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
            ((System.ComponentModel.ISupportInitialize)myToggleSwitch1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl1;
        private UserControls.Controls.MyTextEdit txtServer;
        private UserControls.Controls.MyTextEdit txtVeritabaniAdi;
        private UserControls.Controls.MyTextEdit txtSirketAdi;
        private UserControls.Controls.MyKodTextEdit txtSirketKodu;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private UserControls.Controls.MyToggleSwitch myToggleSwitch1;
        private UserControls.Controls.MyTextEdit txtSqlSifre;
        private UserControls.Controls.MyTextEdit txtSqlKullaniciAdi;
        private UserControls.Controls.MyComboBoxEdit txtAuthType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}
