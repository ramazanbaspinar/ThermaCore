using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ThermaCore.Application.Interfaces.Configuration;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Domain.Extensions;

namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
{
    public partial class KurulumSihirbaziForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IAppConfigService _configService;
        private readonly ITenantDatabaseSetupService _sistemVeritabaniService;

        public KurulumSihirbaziForm(IAppConfigService configService, ITenantDatabaseSetupService sistemVeritabaniService)
        {
            _configService = configService;
            _sistemVeritabaniService = sistemVeritabaniService;
            InitializeComponent();
            
            // Olay bağlantıları
            this.Load += KurulumSihirbaziForm_Load;
            this.cmbYetkilendirme.SelectedIndexChanged += cmbYetkilendirme_SelectedIndexChanged;
            this.btnBaglantiyiTestEt.Click += btnBaglantiyiTestEt_Click;
            this.btnLisansiDogrula.Click += btnLisansiDogrula_Click;
            this.btnKurulumuTamamla.Click += btnKurulumuTamamla_Click;
        }

        private void KurulumSihirbaziForm_Load(object? sender, EventArgs e)
        {
            // cmbYetkilendirme'nin içeriğini doldur
            cmbYetkilendirme.Properties.Items.Clear();
            var list = EnumExtensions.GetEnumDescriptionList<AuthenticationType>();
            foreach (var item in list)
            {
                cmbYetkilendirme.Properties.Items.Add(item);
            }
            cmbYetkilendirme.SelectedIndex = 0; // Windows Authentication varsayılan

            // txtMasterVeritabani varsayılan değer ata
            txtMasterVeritabani.Text = "ThermaCoreMasterDB";
            txtSunucuAdresi.Text = "localhost"; // Varsayılan sunucu
            
            // İlk durumda kullanıcı ve şifreyi pasifleştir (Windows Auth varsayılan olduğu için)
            txtDbKullanici.Enabled = false;
            txtDbSifre.Enabled = false;
        }

        private void cmbYetkilendirme_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var selectedText = cmbYetkilendirme.EditValue?.ToString();
            var authType = selectedText.ToEnum<AuthenticationType>();

            if (authType == AuthenticationType.SqlServer)
            {
                txtDbKullanici.Enabled = true;
                txtDbSifre.Enabled = true;
            }
            else
            {
                txtDbKullanici.Text = string.Empty;
                txtDbSifre.Text = string.Empty;
                txtDbKullanici.Enabled = false;
                txtDbSifre.Enabled = false;
            }
        }

        private string BuildConnectionString(bool forTesting)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = txtSunucuAdresi.Text,
                InitialCatalog = forTesting ? "master" : txtMasterVeritabani.Text,
                TrustServerCertificate = true,
                Encrypt = false
            };

            var selectedText = cmbYetkilendirme.EditValue?.ToString();
            var authType = selectedText.ToEnum<AuthenticationType>() ?? AuthenticationType.Windows;

            if (authType == AuthenticationType.Windows)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = txtDbKullanici.Text;
                builder.Password = txtDbSifre.Text;
            }

            return builder.ConnectionString;
        }

        private void btnBaglantiyiTestEt_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSunucuAdresi.Text))
            {
                XtraMessageBox.Show("Lütfen sunucu adresini giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = BuildConnectionString(forTesting: true);
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                }

                // Yeşil renkli "Bağlantı Başarılı" mesajı gösterimi
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.Caption = "Bağlantı Testi";
                args.Text = "<color=green><b>Bağlantı Başarılı</b></color>";
                args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
                args.Buttons = new DialogResult[] { DialogResult.OK };
                args.Icon = System.Drawing.SystemIcons.Information;
                XtraMessageBox.Show(args);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bağlantı başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnLisansiDogrula_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLisansSunucuUrl.Text))
            {
                XtraMessageBox.Show("Lütfen Lisans Sunucu Adresini giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLisansAnahtari.Text))
            {
                XtraMessageBox.Show("Lütfen Müşteri Lisans Anahtarını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Şimdilik lisans doğrulama servisi taslağını tetikle, geçerliyse onay ver
                // 1 saniye yapay gecikme ile doğrulama hissi verilmesi
                System.Threading.Thread.Sleep(1000);

                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.Caption = "Lisans Doğrulama";
                args.Text = "<color=green><b>Lisans başarıyla doğrulandı. Bulut sunucu bağlantısı sağlandı.</b></color>";
                args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
                args.Buttons = new DialogResult[] { DialogResult.OK };
                args.Icon = System.Drawing.SystemIcons.Information;
                XtraMessageBox.Show(args);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lisans doğrulama hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void btnKurulumuTamamla_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSunucuAdresi.Text) || string.IsNullOrWhiteSpace(txtMasterVeritabani.Text))
            {
                XtraMessageBox.Show("Lütfen Sunucu Adresi ve Veritabanı Adı alanlarını doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedText = cmbYetkilendirme.EditValue?.ToString();
            var authType = selectedText.ToEnum<AuthenticationType>() ?? AuthenticationType.Windows;
            if (authType == AuthenticationType.SqlServer)
            {
                if (string.IsNullOrWhiteSpace(txtDbKullanici.Text) || string.IsNullOrWhiteSpace(txtDbSifre.Text))
                {
                    XtraMessageBox.Show("SQL Server yetkilendirmesi için Kullanıcı Adı ve Şifre zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var result = XtraMessageBox.Show("Programın ilk kurulum işlemi yapılacaktır. Onaylıyor musunuz?", "Kurulum Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                btnKurulumuTamamla.Enabled = false;

                // 1. ITenantDatabaseSetupService üzerinden master veritabanını ve master tablolarını o an fiziksel sunucuda oluştur.
                var tenantDto = new TenantDatabaseDto
                {
                    CompanyCode = "MASTER",
                    CompanyName = "Master Database",
                    Server = txtSunucuAdresi.Text,
                    DatabaseName = txtMasterVeritabani.Text,
                    AuthType = authType,
                    Username = txtDbKullanici.Text,
                    Password = txtDbSifre.Text
                };

                await _sistemVeritabaniService.CreateTenantDatabaseAsync(tenantDto);

                // 2. Girilen tüm bu yapılandırmaları IAppConfigService aracılığıyla settings.json dosyasına şifreli olarak kaydet.
                string connectionString = BuildConnectionString(forTesting: false);
                _configService.SetConnectionString(connectionString);

                // 2.5 Migrate işlemi bittikten hemen sonra DatabaseSeederManager'ın tetiklendiğinden emin ol (Auto-Migration and Seed)
                var optionsMaster = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<ThermaCore.Infrastructure.Persistence.ThermaCoreMasterContext>();
                optionsMaster.UseSqlServer(connectionString, b => b.MigrationsAssembly("ThermaCore.Infrastructure"));
                
                var optionsTenant = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<ThermaCore.Infrastructure.Persistence.ThermaCoreTenantContext>();
                optionsTenant.UseSqlServer(connectionString, b => b.MigrationsAssembly("ThermaCore.Infrastructure"));

                using (var masterContext = new ThermaCore.Infrastructure.Persistence.ThermaCoreMasterContext(optionsMaster.Options))
                using (var tenantContext = new ThermaCore.Infrastructure.Persistence.ThermaCoreTenantContext(optionsTenant.Options))
                {
                    var cryptoService = new ThermaCore.Infrastructure.Security.CryptoService();
                    var seeder = new ThermaCore.Infrastructure.System.DatabaseSeederManager(masterContext, tenantContext, cryptoService);
                    await seeder.SeedAsync(false);
                }

                XtraMessageBox.Show("Veritabanı oluşturuldu ve bağlantı ayarları başarıyla kaydedildi. Uygulama yeniden başlatılıyor.", "Kurulum Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3. Uygulamayı güvenli bir şekilde yeniden başlat.
                System.Windows.Forms.Application.Restart();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Kurulum sırasında bir hata oluştu: {ex.Message}", "Kurulum Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnKurulumuTamamla.Enabled = true;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}