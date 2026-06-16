#pragma warning disable CS8618
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;
using ThermaCore.Application.Interfaces.Configuration;
using ThermaCore.Application.Interfaces.System;

namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
{
    public class BaglantiHataForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IAppConfigService _configService;
        private readonly ITenantDatabaseSetupService _sistemVeritabaniService;

        private Label lblWarningHeader;
        private Label lblWarningText;
        private Panel pnlSifreGiris;
        private TextEdit txtMasterSifre;
        private SimpleButton btnSifreDogrula;

        private const string MasterPassword = "ThermaCoreMaster!";

        public BaglantiHataForm(IAppConfigService configService, ITenantDatabaseSetupService sistemVeritabaniService)
        {
            _configService = configService;
            _sistemVeritabaniService = sistemVeritabaniService;
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = "Sistem Bağlantı Hatası - ThermaCore";
            this.Size = new Size(520, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.KeyPreview = true;
            this.IconOptions.ShowIcon = false;

            // Premium Koyu Tema Görünümü
            this.BackColor = Color.FromArgb(28, 28, 30);
            this.ForeColor = Color.FromArgb(242, 242, 247);

            // Başlık Label (Büyük ve Kırmızı/Crimson)
            lblWarningHeader = new Label
            {
                Text = "SİSTEM BAĞLANTI HATASI",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 69, 58), // Modern Crimson Red
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80
            };
            lblWarningHeader.DoubleClick += (s, e) => TogglePasswordPanel();

            // Açıklama Label (Net ve Okunabilir)
            lblWarningText = new Label
            {
                Text = "Sistem veritabanına ulaşılamıyor.\nLütfen IT Departmanı ile iletişime geçin.",
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                ForeColor = Color.FromArgb(209, 209, 214), // Soft White/Gray
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            lblWarningText.DoubleClick += (s, e) => TogglePasswordPanel();

            // Şifre Giriş Paneli (Başlangıçta Gizli)
            pnlSifreGiris = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 90,
                Visible = false,
                BackColor = Color.FromArgb(36, 36, 38)
            };

            Label lblSifreLabel = new Label
            {
                Text = "Kurulum Şifresi:",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(209, 209, 214),
                Location = new Point(30, 32),
                Width = 100,
                Height = 20
            };

            txtMasterSifre = new TextEdit
            {
                Location = new Point(140, 29),
                Width = 200,
                Properties = { PasswordChar = '*' }
            };
            txtMasterSifre.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtMasterSifre.Properties.Appearance.Options.UseFont = true;
            txtMasterSifre.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DogrulaVeKurulumaGec();
                }
            };

            btnSifreDogrula = new SimpleButton
            {
                Text = "Sihirbazı Aç",
                Location = new Point(360, 27),
                Width = 110,
                Height = 28
            };
            btnSifreDogrula.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSifreDogrula.Appearance.Options.UseFont = true;
            btnSifreDogrula.Click += (s, e) => DogrulaVeKurulumaGec();

            pnlSifreGiris.Controls.Add(lblSifreLabel);
            pnlSifreGiris.Controls.Add(txtMasterSifre);
            pnlSifreGiris.Controls.Add(btnSifreDogrula);

            this.Controls.Add(lblWarningText);
            this.Controls.Add(lblWarningHeader);
            this.Controls.Add(pnlSifreGiris);

            // Kısayol Tuşu Yakalama
            this.KeyDown += BaglantiHataForm_KeyDown;
            this.DoubleClick += (s, e) => TogglePasswordPanel();
        }

        private void BaglantiHataForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.S)
            {
                TogglePasswordPanel();
                e.Handled = true;
            }
        }

        private void TogglePasswordPanel()
        {
            pnlSifreGiris.Visible = !pnlSifreGiris.Visible;
            if (pnlSifreGiris.Visible)
            {
                txtMasterSifre.Focus();
            }
        }

        private void DogrulaVeKurulumaGec()
        {
            if (txtMasterSifre.Text == MasterPassword)
            {
                var wizard = new KurulumSihirbaziForm(_configService, _sistemVeritabaniService);
                this.Hide();
                wizard.ShowDialog();
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Hatalı Master Kurulum Şifresi! Lütfen tekrar deneyiniz.", "Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMasterSifre.Text = string.Empty;
                txtMasterSifre.Focus();
            }
        }
    }
}
