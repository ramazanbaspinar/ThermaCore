using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using WinBeyazEsya.Application.Interfaces.Configuration;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Application.Services.Management;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public partial class GirisForm : XtraForm
    {
        // Enjekte edilecek servis bağımlılıkları (DI)
        private readonly IAuthService _authService;
        private readonly ITenantDatabaseService _tenantService;
        private readonly ILicenseService _licenseService;
        private readonly IHardwareInfoService _hardwareService;
        private readonly ISessionService _sessionService;
        private readonly IAppConfigService _appConfigService;
        private readonly WinBeyazEsya.Application.Interfaces.Updater.IAutoUpdateService _autoUpdateService;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        // DI Container üzerinden servisleri alan Constructor
        public GirisForm(
            IAuthService authService,
            ITenantDatabaseService tenantService,
            ILicenseService licenseService,
            IHardwareInfoService hardwareService,
            ISessionService sessionService,
            IAppConfigService appConfigService,
            WinBeyazEsya.Application.Interfaces.Updater.IAutoUpdateService autoUpdateService,
            Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            InitializeComponent();
            _authService = authService;
            _tenantService = tenantService;
            _licenseService = licenseService;
            _hardwareService = hardwareService;
            _sessionService = sessionService;
            _appConfigService = appConfigService;
            _autoUpdateService = autoUpdateService;
            _configuration = configuration;

            // Event bağlamaları (Designer'da yoksa diye kodla da bağlanabilir)
            this.Load += GirisForm_Load;
            this.Activated += frmLogin_Activated;
            this.btnGiris.Click += btnGiris_Click;
            this.txtKullaniciAdi.Leave += txtKullaniciAdi_Leave;
            this.gluSirket.EditValueChanged += gluSirket_EditValueChanged;
            this.picExit.Click += picExit_Click;
        }

        private async void GirisForm_Load(object? sender, EventArgs e)
        {
            // --- Kritik Güncelleme Kontrolü ---
            try
            {
                Serilog.Log.Information("Giriş formu yüklendi. Güncelleme kontrolü yapılıyor...");
                // UpdatePath, Tenant DB'deki SystemParameter tablosunda olduğu için,
                // henüz giriş yapılmamışken varsayılan bir Tenant ConnectionString'i atamamız gerekir.
                var currentTenantService = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.System.ICurrentTenantService>();
                if (string.IsNullOrEmpty(currentTenantService.ConnectionString))
                {
                    long lastTenantId = _appConfigService.GetLastTenantId();
                    currentTenantService.ConnectionString = await _authService.GetDefaultTenantConnectionStringAsync(lastTenantId);
                }

                var manifest = await _autoUpdateService.CheckForUpdatesAsync();
                string currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0.0";

                if (manifest != null && manifest.Version != currentVersion)
                {
                    Serilog.Log.Information("Yeni versiyon bulundu. Mevcut: {CurrentVersion}, Yeni: {NewVersion}", currentVersion, manifest.Version);
                    this.Enabled = false; // Kullanıcının giriş yapmasını engelle

                    using (var bildirimForm = new GuncellemeBildirimForm(currentVersion, manifest.Version, manifest.IsCritical))
                    {
                        var dialogResult = bildirimForm.ShowDialog(this);
                        if (dialogResult != DialogResult.OK)
                        {
                            if (manifest.IsCritical)
                            {
                                System.Windows.Forms.Application.Exit();
                                Environment.Exit(0);
                                return;
                            }
                            else
                            {
                                this.Enabled = true;
                                // Kullanıcı "Daha Sonra" dedi, giriş ekranına devam
                                goto SkipUpdate;
                            }
                        }
                    }

                    string appPath = AppDomain.CurrentDomain.BaseDirectory;
                    bool isReady = _autoUpdateService.IsUpdateReady(appPath, out var cachedManifest);

                    bool downloaded = false;
                    if (isReady && cachedManifest != null && cachedManifest.Version == manifest.Version)
                    {
                        downloaded = true;
                    }
                    else
                    {
                        downloaded = await _autoUpdateService.DownloadUpdatesAsync(manifest, appPath);
                    }

                    if (downloaded)
                    {
                        string serverUrl = await _autoUpdateService.GetUpdateServerUrlAsync();
                        string updaterPath = System.IO.Path.Combine(appPath, "WinBeyazEsya.Updater.exe");
                        if (System.IO.File.Exists(updaterPath))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = updaterPath,
                                Arguments = $"--url \"{serverUrl}\"",
                                WorkingDirectory = appPath,
                                UseShellExecute = true
                            });
                            System.Threading.Thread.Sleep(500);
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Güncelleyici program bulunamadı (WinBeyazEsya.Updater.exe). Lütfen sistem yöneticinize başvurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Güncelleme indirilemedi, lütfen sistem yöneticinize başvurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    System.Windows.Forms.Application.Exit();
                    Environment.Exit(0);
                    return; // Kodun devamının çalışmaması için
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Warning(ex, "Güncelleme kontrolü sırasında bir hata oluştu veya atlandı.");
            }
        SkipUpdate:
            // --- Kritik Güncelleme Kontrolü Bitiş ---

            // 1. Temiz Versiyon Formatlaması (.NET 8 Source Link Commit Hash'ini temizle)
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (version != null)
            {
                lblVersiyon.Text = $"Versiyon: {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            }
            else
            {
                lblVersiyon.Text = "Versiyon: 1.0.0.0";
            }

            // 2. Lisans Formatlaması (Karmaşık hash'i UI'da gösterme)
            WinBeyazEsya.Domain.Enums.LicenseStatus status = _licenseService.CheckLicense(out string message);

            if (status == WinBeyazEsya.Domain.Enums.LicenseStatus.Valid)
            {
                lblLisansKalanGun.Text = $"Lisans Durumu:{message} Gün Kaldı";
            }
            else
            {
                lblLisansKalanGun.Text = "Lisans Durumu:Geçersiz / Süresi Dolmuş";
            }

            string lastUser = _appConfigService.GetLastLoginUser();
            if (!string.IsNullOrEmpty(lastUser))
            {
                txtKullaniciAdi.Text = lastUser;
                chcBeniHatirla.Checked = true;
                // Leave eventindeki işlemleri asenkron olarak manuel tetikleyip son tenant'ı seç
                _ = LoadUserTenantsAsync(lastUser);
            }
        }

        private async Task LoadUserTenantsAsync(string username)
        {
            try
            {
                var tenants = await _authService.GetAllowedTenantsByUsernameAsync(username);
                if (tenants != null && tenants.Count > 0)
                {
                    gluSirket.Properties.DataSource = tenants;
                    gluSirket.Properties.DisplayMember = "CompanyName";
                    gluSirket.Properties.ValueMember = "Id";

                    long lastTenantId = _appConfigService.GetLastTenantId();
                    if (lastTenantId > 0)
                    {
                        gluSirket.EditValue = lastTenantId;
                    }
                }
            }
            catch { /* Ignore background load errors */ }
        }

        private async void txtKullaniciAdi_Leave(object? sender, EventArgs e)
        {
            // 2. Kullanıcı Adı Doğrulama ve Şirket Yükleme
            string username = txtKullaniciAdi.Text.Trim();
            if (string.IsNullOrEmpty(username)) return;

            try
            {
                // Kullanıcının Master DB'de tanımlı ve yetkili olduğu Tenant'ları getirir
                var tenants = await _authService.GetAllowedTenantsByUsernameAsync(username);

                if (tenants != null && tenants.Count > 0)
                {
                    gluSirket.Properties.DataSource = tenants;
                    gluSirket.Properties.DisplayMember = "CompanyName"; // DB'den gelen Şirket Adı kolonu
                    gluSirket.Properties.ValueMember = "Id";     // DB'den gelen Şirket Id kolonu

                    if (gluSirket.EditValue != null && !tenants.Any(t => t.Id == Convert.ToInt64(gluSirket.EditValue)))
                    {
                        gluSirket.EditValue = null;
                    }
                }
                else
                {
                    gluSirket.Properties.DataSource = null;
                    gluSirket.EditValue = null;
                    Messages.UyariBasligi("Bu kullanıcıya tanımlı herhangi bir şirket (Tenant) bulunamadı.", "Uyarı");
                }
            }
            catch (Exception ex)
            {
                Messages.HataBasligi("Şirket bilgileri getirilirken hata oluştu: " + ex.Message, "Hata");
            }
        }

        private void gluSirket_EditValueChanged(object? sender, EventArgs e)
        {
            // Fabrika UI'dan kaldırılmıştır. Seçim Login sonrası yapılacaktır.
        }

        private async void btnGiris_Click(object? sender, EventArgs e)
        {
            // 4. Giriş İşlemi
            string username = txtKullaniciAdi.Text.Trim();
            string password = txtSifre.Text;

            if (gluSirket.EditValue == null)
            {
                Messages.UyariBasligi("Lütfen giriş yapılacak şirketi seçiniz.", "Uyarı");
                return;
            }

            long tenantId = Convert.ToInt64(gluSirket.EditValue);

            try
            {
                // Şifre doğrulama ve giriş denemesi (Master DB üzerinden)
                var loginResult = await _authService.LoginAsync(username, password, tenantId);

                if (loginResult != null && loginResult.IsSuccess)
                {
                    Serilog.Log.Information("Giriş başarılı. Kullanıcı: {Username}, Şirket ID: {TenantId}", username, tenantId);
                    // Tenant Routing: Seçili şirketin veritabanı bağlantı cümlesini aktif (Scoped) Context'e ayarla
                    // _tenantService.SetCurrentTenantConnectionString(loginResult.TenantConnectionString);

                    // Donanım bilgisi alarak Terminal / Cihaz yetki kontrolü (Hardware Fingerprint)
                    string fingerprint = _hardwareService.GetMachineFingerprint();
                    bool isTerminalValid = await _authService.CheckTerminalAccessAsync(username, fingerprint, tenantId);

                    if (!isTerminalValid)
                    {
                        Messages.HataBasligi("Bu bilgisayardan/cihazdan (Terminal) bu şirkete giriş yapma yetkiniz bulunmamaktadır.", "Erişim Engellendi");
                        return;
                    }

                    // Oturum (Session) bilgilerini Master DB'ye kaydet
                    string ipAddress = WinBeyazEsya.Domain.Helpers.NetworkHelper.GetLocalIpAddress();
                    string pcName = Environment.MachineName;
                    await _sessionService.StartSessionAsync(loginResult.UserId, ipAddress, pcName);

                    if (loginResult.SessionId.HasValue)
                    {
                        Program.CurrentSessionId = loginResult.SessionId.Value;
                    }

                    // Başarılı Girişte Hafızaya Yazma (Settings Cache)
                    if (chcBeniHatirla.Checked)
                    {
                        _appConfigService.SetLastLoginUser(username);
                        _appConfigService.SetLastTenantId(tenantId);
                    }
                    else
                    {
                        _appConfigService.SetLastLoginUser(string.Empty);
                        _appConfigService.SetLastTenantId(0);
                    }

                    var currentTenantService = Program.ServiceProvider.GetRequiredService<ICurrentTenantService>();
                    currentTenantService.TenantId = tenantId;
                    currentTenantService.UserId = loginResult.UserId;
                    currentTenantService.TenantName = gluSirket.Text;
                    currentTenantService.ConnectionString = loginResult.TenantConnectionString;

                    this.Hide();

                    var anaForm = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.GenelForms.AnaForm>();
                    anaForm.Show();
                }
                else
                {
                    if (loginResult != null && !string.IsNullOrEmpty(loginResult.ErrorMessage))
                    {
                        Serilog.Log.Warning("Giriş başarısız. Kullanıcı: {Username}, Neden: {ErrorMessage}", username, loginResult.ErrorMessage);
                        Messages.UyariBasligi(loginResult.ErrorMessage, "Uyarı");
                    }
                    else
                    {
                        Serilog.Log.Warning("Giriş başarısız. Kullanıcı adı veya şifre hatalı. Kullanıcı: {Username}", username);
                        Messages.HataBasligi("Kullanıcı adı veya şifre hatalı.", "Hata");
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex, "Giriş işlemi sırasında beklenmeyen bir hata oluştu. Kullanıcı: {Username}", username);
                if (ex.Message.StartsWith("Güvenlik İhlali"))
                    Messages.HataBasligi(ex.Message, "Erişim Engellendi");
                else
                    Messages.HataBasligi("Giriş yapılırken beklenmeyen bir hata oluştu: " + ex.Message, "Hata");
            }
        }

        private void picPassword_MouseDown(object? sender, MouseEventArgs e)
        {
            txtSifre.Properties.UseSystemPasswordChar = false;
        }

        private void picPassword_MouseUp(object? sender, MouseEventArgs e)
        {
            txtSifre.Properties.UseSystemPasswordChar = true;
        }

        private void frmLogin_Activated(object? sender, EventArgs e)
        {
            if (chcBeniHatirla.Checked && !string.IsNullOrEmpty(txtKullaniciAdi.Text))
                txtSifre.Focus();
            else if (!string.IsNullOrEmpty(txtKullaniciAdi.Text))
                txtSifre.Focus();
            else
                txtKullaniciAdi.Focus();
        }

        private void picExit_Click(object? sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[""].ConnectionString;
        }
    }
}


