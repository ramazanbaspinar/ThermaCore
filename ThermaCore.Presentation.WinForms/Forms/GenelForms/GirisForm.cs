using DevExpress.XtraEditors;
using System;
using System.Configuration;
using System.Windows.Forms;
using System.Threading.Tasks;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Application.Services.Management; // IAuthService'in bulunduğu doğru namespace

namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
{
    public partial class GirisForm : XtraForm
    {
        // Enjekte edilecek servis bağımlılıkları (DI)
        private readonly IAuthService _authService;
        private readonly ITenantDatabaseService _tenantService;
        private readonly ILicenseService _licenseService;
        private readonly IHardwareInfoService _hardwareService;
        private readonly ISessionService _sessionService;

        // DI Container üzerinden servisleri alan Constructor
        public GirisForm(
            IAuthService authService,
            ITenantDatabaseService tenantService,
            ILicenseService licenseService,
            IHardwareInfoService hardwareService,
            ISessionService sessionService)
        {
            InitializeComponent();
            _authService = authService;
            _tenantService = tenantService;
            _licenseService = licenseService;
            _hardwareService = hardwareService;
            _sessionService = sessionService;

            // Event bağlamaları (Designer'da yoksa diye kodla da bağlanabilir)
            this.Load += GirisForm_Load;
            this.btnGiris.Click += btnGiris_Click;
            this.txtKullaniciAdi.Leave += txtKullaniciAdi_Leave;
            this.gluSirket.EditValueChanged += gluSirket_EditValueChanged;
        }

        private void GirisForm_Load(object? sender, EventArgs e)
        {
            // 1. Temiz Versiyon Formatlaması (.NET 8 Source Link Commit Hash'ini temizle)
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            if (version != null)
            {
                lblVersiyon.Text = $"Versiyon: {version.Major}.{version.Minor}.{version.Build}";
            }
            else
            {
                lblVersiyon.Text = "Versiyon: 1.0.0";
            }
            
            // 2. Lisans Formatlaması (Karmaşık hash'i UI'da gösterme)
            ThermaCore.Domain.Enums.LicenseStatus status = _licenseService.CheckLicense(out string message);
            
            if (status == ThermaCore.Domain.Enums.LicenseStatus.Valid)
            {
                // İsteğe bağlı olarak kalan gün verisi parse edilip yazdırılabilir. Şimdilik sade tutuyoruz.
                lblLisansKalanGun.Text = "Lisans Durumu: Geçerli"; 
            }
            else
            {
                lblLisansKalanGun.Text = "Lisans Durumu: Geçersiz / Süresi Dolmuş";
            }
        }

        private async void txtKullaniciAdi_Leave(object? sender, EventArgs e)
        {
            // 2. Kullanıcı Adı Doğrulama ve Firma Yükleme
            string username = txtKullaniciAdi.Text.Trim();
            if (string.IsNullOrEmpty(username)) return;

            try
            {
                // Kullanıcının Master DB'de tanımlı ve yetkili olduğu Tenant'ları getirir
                var tenants = await _authService.GetAllowedTenantsByUsernameAsync(username);
                
                if (tenants != null)
                {
                    gluSirket.Properties.DataSource = tenants;
                    gluSirket.Properties.DisplayMember = "Name"; // DB'den gelen Firma Adı kolonu
                    gluSirket.Properties.ValueMember = "Id";     // DB'den gelen Firma Id kolonu
                }
                else
                {
                    XtraMessageBox.Show("Bu kullanıcıya tanımlı herhangi bir firma (Tenant) bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Firma bilgileri getirilirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gluSirket_EditValueChanged(object? sender, EventArgs e)
        {
            // 3. Cascading Dropdown (Şirket -> Fabrika)
            // Sistemde henüz Fabrika yapısı (Şube/Plant) detaylandırılmadığı için gluFabrika devre dışı bırakılmıştır.
            gluFabrika.Enabled = false;
            gluFabrika.ToolTip = "Sistemde fabrika ayrımı aktif değildir.";

            /* 
             * İleride fabrika mimarisi eklendiğinde aşağıdaki gibi doldurulabilir:
             * long seciliSirketId = Convert.ToInt64(gluSirket.EditValue);
             * gluFabrika.Properties.DataSource = await _authService.GetFactoriesByTenantIdAsync(seciliSirketId);
             */
        }

        private async void btnGiris_Click(object? sender, EventArgs e)
        {
            // 4. Giriş İşlemi
            string username = txtKullaniciAdi.Text.Trim();
            string password = txtSifre.Text;
            
            if (gluSirket.EditValue == null)
            {
                XtraMessageBox.Show("Lütfen giriş yapılacak firmayı (Sirket) seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long tenantId = Convert.ToInt64(gluSirket.EditValue);

            try
            {
                // Şifre doğrulama ve giriş denemesi (Master DB üzerinden)
                var loginResult = await _authService.LoginAsync(username, password, tenantId);
                
                if (loginResult != null && loginResult.IsSuccess)
                {
                    // Tenant Routing: Seçili firmanın veritabanı bağlantı cümlesini aktif (Scoped) Context'e ayarla
                    // _tenantService.SetCurrentTenantConnectionString(loginResult.TenantConnectionString);

                    // Donanım bilgisi alarak Terminal / Cihaz yetki kontrolü (Hardware Fingerprint)
                    string fingerprint = _hardwareService.GetMachineFingerprint();
                    bool isTerminalValid = await _authService.CheckTerminalAccessAsync(fingerprint, tenantId);

                    if (!isTerminalValid)
                    {
                        XtraMessageBox.Show("Bu bilgisayardan/cihazdan (Terminal) bu firmaya giriş yapma yetkiniz bulunmamaktadır.", "Erişim Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Oturum (Session) bilgilerini Master DB'ye kaydet
                    string ipAddress = "127.0.0.1"; // UI Helper ile alınabilir
                    string pcName = Environment.MachineName;
                    await _sessionService.StartSessionAsync(loginResult.UserId, ipAddress, pcName);

                    // Mevcut formu gizle, Ana Formu göster
                    this.Hide();
                    
                    // TODO: İleride yazılacak MainForm örneği
                    // MainForm mainForm = new MainForm(); 
                    // mainForm.Show();
                    
                    XtraMessageBox.Show("Giriş Başarılı! Ana sayfaya yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Giriş yapılırken beklenmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (!string.IsNullOrEmpty(txtKullaniciAdi.Text))
                txtSifre.Focus();
            else
                txtKullaniciAdi.Focus();
        }

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[""].ConnectionString;
        }
    }
}
