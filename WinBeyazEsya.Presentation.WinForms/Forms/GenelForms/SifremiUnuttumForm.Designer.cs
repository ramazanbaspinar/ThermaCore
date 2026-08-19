namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    partial class SifremiUnuttumForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblBaslik = new DevExpress.XtraEditors.LabelControl();
            this.lblAltBaslik = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.lblBilgiMesaji = new DevExpress.XtraEditors.LabelControl();
            this.txtDogrulamaKodu = new DevExpress.XtraEditors.TextEdit();
            this.txtYeniParola = new DevExpress.XtraEditors.TextEdit();
            this.txtYeniParolaTekrar = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.grpKullaniciBilgileri = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemKullaniciAdi = new DevExpress.XtraLayout.LayoutControlItem();
            this.grpSifirlama = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemBilgi = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemKodu = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemParola = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemParolaTekrar = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnKodGonder = new DevExpress.XtraEditors.SimpleButton();
            this.btnSifreGuncelle = new DevExpress.XtraEditors.SimpleButton();
            
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDogrulamaKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniParola.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniParolaTekrar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpKullaniciBilgileri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemKullaniciAdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSifirlama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBilgi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemParola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemParolaTekrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.pnlHeader.Controls.Add(this.lblBaslik);
            this.pnlHeader.Controls.Add(this.lblAltBaslik);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(350, 68);
            this.pnlHeader.TabIndex = 0;
            
            // 
            // lblBaslik
            // 
            this.lblBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Appearance.Options.UseFont = true;
            this.lblBaslik.Appearance.Options.UseForeColor = true;
            this.lblBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBaslik.Location = new System.Drawing.Point(15, 12);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(320, 28);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "🔑  Şifremi Unuttum";
            
            // 
            // lblAltBaslik
            // 
            this.lblAltBaslik.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblAltBaslik.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblAltBaslik.Appearance.Options.UseFont = true;
            this.lblAltBaslik.Appearance.Options.UseForeColor = true;
            this.lblAltBaslik.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAltBaslik.Location = new System.Drawing.Point(15, 42);
            this.lblAltBaslik.Name = "lblAltBaslik";
            this.lblAltBaslik.Size = new System.Drawing.Size(320, 18);
            this.lblAltBaslik.TabIndex = 1;
            this.lblAltBaslik.Text = "Hesabınızı kurtarmak için doğrulama adımlarını izleyin.";
            
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtKullaniciAdi);
            this.layoutControl1.Controls.Add(this.lblBilgiMesaji);
            this.layoutControl1.Controls.Add(this.txtDogrulamaKodu);
            this.layoutControl1.Controls.Add(this.txtYeniParola);
            this.layoutControl1.Controls.Add(this.txtYeniParolaTekrar);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 68);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(350, 227);
            this.layoutControl1.TabIndex = 1;
            
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.EnterMoveNextControl = true;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(26, 56);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.txtKullaniciAdi.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.txtKullaniciAdi.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(298, 26);
            this.txtKullaniciAdi.StyleController = this.layoutControl1;
            this.txtKullaniciAdi.TabIndex = 0;
            
            // 
            // lblBilgiMesaji
            // 
            this.lblBilgiMesaji.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold);
            this.lblBilgiMesaji.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(100)))));
            this.lblBilgiMesaji.Appearance.Options.UseFont = true;
            this.lblBilgiMesaji.Appearance.Options.UseForeColor = true;
            this.lblBilgiMesaji.Location = new System.Drawing.Point(26, 96);
            this.lblBilgiMesaji.Name = "lblBilgiMesaji";
            this.lblBilgiMesaji.Size = new System.Drawing.Size(298, 15);
            this.lblBilgiMesaji.StyleController = this.layoutControl1;
            this.lblBilgiMesaji.TabIndex = 4;
            this.lblBilgiMesaji.Text = "Bilgi Mesajı";
            
            // 
            // txtDogrulamaKodu
            // 
            this.txtDogrulamaKodu.EnterMoveNextControl = true;
            this.txtDogrulamaKodu.Location = new System.Drawing.Point(26, 134);
            this.txtDogrulamaKodu.Name = "txtDogrulamaKodu";
            this.txtDogrulamaKodu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtDogrulamaKodu.Properties.Appearance.Options.UseFont = true;
            this.txtDogrulamaKodu.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.txtDogrulamaKodu.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtDogrulamaKodu.Properties.MaxLength = 6;
            this.txtDogrulamaKodu.Size = new System.Drawing.Size(298, 26);
            this.txtDogrulamaKodu.StyleController = this.layoutControl1;
            this.txtDogrulamaKodu.TabIndex = 1;
            
            // 
            // txtYeniParola
            // 
            this.txtYeniParola.EnterMoveNextControl = true;
            this.txtYeniParola.Location = new System.Drawing.Point(26, 182);
            this.txtYeniParola.Name = "txtYeniParola";
            this.txtYeniParola.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYeniParola.Properties.Appearance.Options.UseFont = true;
            this.txtYeniParola.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.txtYeniParola.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtYeniParola.Properties.UseSystemPasswordChar = true;
            this.txtYeniParola.Size = new System.Drawing.Size(298, 26);
            this.txtYeniParola.StyleController = this.layoutControl1;
            this.txtYeniParola.TabIndex = 2;
            
            // 
            // txtYeniParolaTekrar
            // 
            this.txtYeniParolaTekrar.EnterMoveNextControl = true;
            this.txtYeniParolaTekrar.Location = new System.Drawing.Point(26, 230);
            this.txtYeniParolaTekrar.Name = "txtYeniParolaTekrar";
            this.txtYeniParolaTekrar.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYeniParolaTekrar.Properties.Appearance.Options.UseFont = true;
            this.txtYeniParolaTekrar.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.txtYeniParolaTekrar.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtYeniParolaTekrar.Properties.UseSystemPasswordChar = true;
            this.txtYeniParolaTekrar.Size = new System.Drawing.Size(298, 26);
            this.txtYeniParolaTekrar.StyleController = this.layoutControl1;
            this.txtYeniParolaTekrar.TabIndex = 3;
            
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.grpKullaniciBilgileri,
            this.grpSifirlama,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 6, 6);
            this.Root.Size = new System.Drawing.Size(350, 300);
            this.Root.TextVisible = false;
            
            // 
            // grpKullaniciBilgileri
            // 
            this.grpKullaniciBilgileri.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpKullaniciBilgileri.AppearanceGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.grpKullaniciBilgileri.AppearanceGroup.Options.UseFont = true;
            this.grpKullaniciBilgileri.AppearanceGroup.Options.UseForeColor = true;
            this.grpKullaniciBilgileri.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemKullaniciAdi});
            this.grpKullaniciBilgileri.Location = new System.Drawing.Point(0, 0);
            this.grpKullaniciBilgileri.Name = "grpKullaniciBilgileri";
            this.grpKullaniciBilgileri.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.grpKullaniciBilgileri.Size = new System.Drawing.Size(330, 78);
            this.grpKullaniciBilgileri.Text = "1. Adım: Kullanıcı Doğrulama";
            
            // 
            // layoutControlItemKullaniciAdi
            // 
            this.layoutControlItemKullaniciAdi.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.layoutControlItemKullaniciAdi.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.layoutControlItemKullaniciAdi.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItemKullaniciAdi.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItemKullaniciAdi.Control = this.txtKullaniciAdi;
            this.layoutControlItemKullaniciAdi.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemKullaniciAdi.Name = "layoutControlItemKullaniciAdi";
            this.layoutControlItemKullaniciAdi.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 6);
            this.layoutControlItemKullaniciAdi.Size = new System.Drawing.Size(306, 48);
            this.layoutControlItemKullaniciAdi.Text = "Kullanıcı Adı";
            this.layoutControlItemKullaniciAdi.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemKullaniciAdi.TextSize = new System.Drawing.Size(79, 15);
            
            // 
            // grpSifirlama
            // 
            this.grpSifirlama.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpSifirlama.AppearanceGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.grpSifirlama.AppearanceGroup.Options.UseFont = true;
            this.grpSifirlama.AppearanceGroup.Options.UseForeColor = true;
            this.grpSifirlama.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemBilgi,
            this.layoutControlItemKodu,
            this.layoutControlItemParola,
            this.layoutControlItemParolaTekrar});
            this.grpSifirlama.Location = new System.Drawing.Point(0, 78);
            this.grpSifirlama.Name = "grpSifirlama";
            this.grpSifirlama.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.grpSifirlama.Size = new System.Drawing.Size(330, 201);
            this.grpSifirlama.Text = "2. Adım: Şifre Yenileme";
            this.grpSifirlama.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            
            // 
            // layoutControlItemBilgi
            // 
            this.layoutControlItemBilgi.Control = this.lblBilgiMesaji;
            this.layoutControlItemBilgi.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemBilgi.Name = "layoutControlItemBilgi";
            this.layoutControlItemBilgi.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 8);
            this.layoutControlItemBilgi.Size = new System.Drawing.Size(306, 27);
            this.layoutControlItemBilgi.TextVisible = false;
            
            // 
            // layoutControlItemKodu
            // 
            this.layoutControlItemKodu.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.layoutControlItemKodu.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.layoutControlItemKodu.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItemKodu.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItemKodu.Control = this.txtDogrulamaKodu;
            this.layoutControlItemKodu.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItemKodu.Name = "layoutControlItemKodu";
            this.layoutControlItemKodu.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 6);
            this.layoutControlItemKodu.Size = new System.Drawing.Size(306, 48);
            this.layoutControlItemKodu.Text = "Doğrulama Kodu (6 Hane)";
            this.layoutControlItemKodu.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemKodu.TextSize = new System.Drawing.Size(130, 15);
            
            // 
            // layoutControlItemParola
            // 
            this.layoutControlItemParola.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.layoutControlItemParola.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.layoutControlItemParola.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItemParola.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItemParola.Control = this.txtYeniParola;
            this.layoutControlItemParola.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItemParola.Name = "layoutControlItemParola";
            this.layoutControlItemParola.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 6);
            this.layoutControlItemParola.Size = new System.Drawing.Size(306, 48);
            this.layoutControlItemParola.Text = "Yeni Parola";
            this.layoutControlItemParola.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemParola.TextSize = new System.Drawing.Size(130, 15);
            
            // 
            // layoutControlItemParolaTekrar
            // 
            this.layoutControlItemParolaTekrar.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.layoutControlItemParolaTekrar.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.layoutControlItemParolaTekrar.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItemParolaTekrar.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItemParolaTekrar.Control = this.txtYeniParolaTekrar;
            this.layoutControlItemParolaTekrar.Location = new System.Drawing.Point(0, 123);
            this.layoutControlItemParolaTekrar.Name = "layoutControlItemParolaTekrar";
            this.layoutControlItemParolaTekrar.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 6);
            this.layoutControlItemParolaTekrar.Size = new System.Drawing.Size(306, 48);
            this.layoutControlItemParolaTekrar.Text = "Yeni Parola Tekrar";
            this.layoutControlItemParolaTekrar.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItemParolaTekrar.TextSize = new System.Drawing.Size(130, 15);
            
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 279);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(330, 9);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnVazgec);
            this.panelControl1.Controls.Add(this.btnKodGonder);
            this.panelControl1.Controls.Add(this.btnSifreGuncelle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 295);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(350, 55);
            this.panelControl1.TabIndex = 2;
            
            // 
            // btnVazgec
            // 
            this.btnVazgec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVazgec.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVazgec.Appearance.Options.UseFont = true;
            this.btnVazgec.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVazgec.Location = new System.Drawing.Point(242, 12);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(95, 32);
            this.btnVazgec.TabIndex = 1;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            
            // 
            // btnKodGonder
            // 
            this.btnKodGonder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKodGonder.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnKodGonder.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnKodGonder.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKodGonder.Appearance.Options.UseBackColor = true;
            this.btnKodGonder.Appearance.Options.UseFont = true;
            this.btnKodGonder.Appearance.Options.UseForeColor = true;
            this.btnKodGonder.Location = new System.Drawing.Point(100, 12);
            this.btnKodGonder.Name = "btnKodGonder";
            this.btnKodGonder.Size = new System.Drawing.Size(130, 32);
            this.btnKodGonder.TabIndex = 0;
            this.btnKodGonder.Text = "Kod Gönder";
            this.btnKodGonder.Click += new System.EventHandler(this.btnKodGonder_Click);
            
            // 
            // btnSifreGuncelle
            // 
            this.btnSifreGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSifreGuncelle.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(29)))), ((int)(((byte)(35)))));
            this.btnSifreGuncelle.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSifreGuncelle.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSifreGuncelle.Appearance.Options.UseBackColor = true;
            this.btnSifreGuncelle.Appearance.Options.UseFont = true;
            this.btnSifreGuncelle.Appearance.Options.UseForeColor = true;
            this.btnSifreGuncelle.Location = new System.Drawing.Point(100, 12);
            this.btnSifreGuncelle.Name = "btnSifreGuncelle";
            this.btnSifreGuncelle.Size = new System.Drawing.Size(130, 32);
            this.btnSifreGuncelle.TabIndex = 2;
            this.btnSifreGuncelle.Text = "Şifreyi Güncelle";
            this.btnSifreGuncelle.Visible = false;
            this.btnSifreGuncelle.Click += new System.EventHandler(this.btnSifreGuncelle_Click);
            
            // 
            // SifremiUnuttumForm
            // 
            this.AcceptButton = this.btnKodGonder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnVazgec;
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SifremiUnuttumForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifremi Unuttum";
            
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDogrulamaKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniParola.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYeniParolaTekrar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpKullaniciBilgileri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemKullaniciAdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSifirlama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBilgi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemParola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemParolaTekrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblBaslik;
        private DevExpress.XtraEditors.LabelControl lblAltBaslik;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup grpKullaniciBilgileri;
        private DevExpress.XtraLayout.LayoutControlGroup grpSifirlama;
        private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl lblBilgiMesaji;
        private DevExpress.XtraEditors.TextEdit txtDogrulamaKodu;
        private DevExpress.XtraEditors.TextEdit txtYeniParola;
        private DevExpress.XtraEditors.TextEdit txtYeniParolaTekrar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemKullaniciAdi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBilgi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemKodu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemParola;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemParolaTekrar;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnKodGonder;
        private DevExpress.XtraEditors.SimpleButton btnSifreGuncelle;
    }
}
