using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinBeyazEsya.Application;
using WinBeyazEsya.Application.Interfaces.Configuration;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Infrastructure;
using WinBeyazEsya.Infrastructure.Configuration;
using WinBeyazEsya.Presentation.WinForms.Forms.GenelForms;
using Serilog;

namespace WinBeyazEsya.Presentation.WinForms;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = default!;
    public static long? CurrentSessionId { get; set; }

    [STAThread]
    static void Main()
    {
        // 1. Serilog Konfigürasyonu
        string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        if (!Directory.Exists(logDir))
        {
            Directory.CreateDirectory(logDir);
        }

        Serilog.Log.Logger = new Serilog.LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(
                path: Path.Combine(logDir, "WinBeyazEsya_Log_.txt"),
                rollingInterval: Serilog.RollingInterval.Day,
                retainedFileCountLimit: 30,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level:u3}] [{SourceContext}] {Message:lj} {Exception}{NewLine}")
            .CreateLogger();

        try
        {
            Serilog.Log.Information("Uygulama başlatılıyor...");

            bool createdNew;
            var mutex = new Mutex(true, "Global\\WinBeyazEsyaERP_SingleInstance_Mutex", out createdNew);

            if (!createdNew)
            {
                Serilog.Log.Warning("Uygulama zaten açık. İkinci instance engellendi.");
                MessageBox.Show("WinBeyazEsya ERP zaten çalışıyor! Lütfen açık olan uygulamayı kullanınız veya görev çubuğunu kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                try
                {
                    var cultureInfo = new CultureInfo("tr-TR");
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                    Thread.CurrentThread.CurrentUICulture = cultureInfo;
                    
                    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

                    DevExpress.Utils.FormatInfo.AlwaysUseThreadFormat = true;
                }
                catch (Exception ex)
                {
                    Serilog.Log.Warning(ex, "Kültür (Culture) ayarlanırken bir hata oluştu.");
                }

                System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                System.Threading.Tasks.TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

                ApplicationConfiguration.Initialize();

                // ---- ÖZEL TEMA ENTEGRASYONU ----
                try
                {
                    // 1. DevExpress arayüzünü "Compact" (Sıkıştırılmış/Dar) moda al
                    DevExpress.XtraEditors.WindowsFormsSettings.CompactUIMode = DevExpress.Utils.DefaultBoolean.True;

                    // 2. DLL içindeki temayı projeye kaydet
                    System.Reflection.Assembly asm = typeof(DevExpress.UserSkins.WinBeyazEsyaSkin).Assembly;
                    DevExpress.XtraEditors.WindowsFormsSettings.RegisterUserSkins(asm);

                    // 3. Temayı varsayılan olarak uygula
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("WinBeyazEsyaSkin");
                }
                catch (Exception ex)
                {
                    Serilog.Log.Warning(ex, "Özel tema (WinBeyazEsyaSkin) yüklenemedi. DevExpress varsayılan teması kullanılacak.");
                }
                // ------------------------------------------------------

                IAppConfigService configService = new AppConfigService();
                string connectionString = configService.GetConnectionString();

                bool isConnected = false;
                if (!string.IsNullOrEmpty(connectionString))
                {
                    try
                    {
                        using (var conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            isConnected = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Error(ex, "Veritabanı bağlantı testi başarısız oldu.");
                        isConnected = false;
                    }
                }

                if (!isConnected)
                {
                    var entryAssembly = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name;
                    if (entryAssembly != null && (entryAssembly.StartsWith("ef") || entryAssembly.StartsWith("dotnet-ef")))
                    {
                        // EF Core aracı çalışıyorsa
                    }
                    else
                    {
                        WinBeyazEsya.Application.Interfaces.System.ITenantDatabaseService tenantDbService = new WinBeyazEsya.Infrastructure.System.TenantDatabaseManager();
                        ITenantDatabaseSetupService sistemVeritabaniService = new WinBeyazEsya.Application.Services.System.TenantDatabaseSetupManager(null!, null!, tenantDbService, null!, null!, null!);

                        System.Windows.Forms.Application.Run(new BaglantiHataForm(configService, sistemVeritabaniService));
                        return;
                    }
                }

                var host = Host.CreateDefaultBuilder()
                    .UseSerilog() // Serilog'u .NET Host mekanizmasına entegre et
                    .ConfigureServices((context, services) =>
                    {
                        services.AddApplicationServices();
                        services.AddInfrastructureServices(connectionString);

                        services.AddTransient<GirisForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.GenelForms.AnaForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.SirketForms.SirketListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.SirketForms.SirketEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.FabrikaForms.FabrikaListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.FabrikaForms.FabrikaEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.CodeTemplateForms.KodSablonlariListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.CodeTemplateForms.KodSablonlariEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.KodYonetimForms.KodLogListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.KodYonetimForms.KodLogEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.YetkilendirmeForms.RolListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.YetkilendirmeForms.RolEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.KullaniciForms.KullaniciListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.KullaniciForms.KullaniciEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TerminalForms.TerminalListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TerminalForms.TerminalEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.EmailParameterEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.LisansBilgileriEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.GenelParametrelerEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.KullanıcıArayuzSablonlariListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.LisansForms.LisansAktivasyonForm>();
                        
                        // Definitions
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GenelGiderForms.GenelGiderListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GenelGiderForms.GenelGiderEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MaliyetParametreForms.MaliyetParametreEditForm>();                
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ElektrikVeElektronikGrubuMForms.ElektrikVeElektronikGrubuMListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ElektrikVeElektronikGrubuMForms.ElektrikVeElektronikGrubuMEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MetalVeSacGrubuMForms.MetalVeSacGrubuMaliyetListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MetalVeSacGrubuMForms.MetalVeSacGrubuMaliyetEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazVeAteslemeGrubuMForms.GazVeAteslemeGrubuMListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazVeAteslemeGrubuMForms.GazVeAteslemeGrubuMEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PlastikVeGorselAksamGrubuMForms.PlastikVeGorselAksamGrubuMListForms>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PlastikVeGorselAksamGrubuMForms.PlastikVeGorselAksamGrubuMEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KimyaVeYalitimGrubuMForms.KimyaVeYalitimGrubuMListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KimyaVeYalitimGrubuMForms.KimyaVeYalitimGrubuMEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MekanikVeHirdavatGrubuMForms.MekanikVeHirdavatGrubuMListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MekanikVeHirdavatGrubuMForms.MekanikVeHirdavatGrubuMEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AmbalajVeMatbaaGrubuMForms.AmbalajVeMatbaaGrubuMListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AmbalajVeMatbaaGrubuMForms.AmbalajVeMatbaaGrubuMEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TelVeIzgaraGrubuMForms.TelVeIzgaraGrubuMListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TelVeIzgaraGrubuMForms.TelVeIzgaraGrubuMEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.DigerMalzemeGrubuMForms.DigerMalzemeGrubuMListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.DigerMalzemeGrubuMForms.DigerMalzemeGrubuMEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimEditForm>();
                        
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KurlarForms.KurListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KurlarForms.KurEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.VergiForms.VergiOraniListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.VergiForms.VergiOraniEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MetalVeSacGrubuForms.MetalVeSacGrubuListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MetalVeSacGrubuForms.MetalVeSacGrubuEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ElektrikVeElektronikGrubuForms.ElektrikVeElektronikGrubuListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ElektrikVeElektronikGrubuForms.ElektrikVeElektronikGrubuEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazveAteslemeGrubuForms.GazveAteslemeGrubuListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazveAteslemeGrubuForms.GazveAteslemeGrubuEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PlastikVeGorselAksamGrubuForms.PlastikVeGorselAksamGrubuListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PlastikVeGorselAksamGrubuForms.PlastikVeGorselAksamGrubuEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KimyaVeYalitimGrubuForms.KimyaVeYalitimGrubuListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KimyaVeYalitimGrubuForms.KimyaVeYalitimGrubuEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MekanikVeHirdavatGrubuForms.MekanikVeHirdavatGrubuListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MekanikVeHirdavatGrubuForms.MekanikVeHirdavatGrubuEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.AmbalajVeMatbaaGrubuForms.AmbalajVeMatbaaGrubuListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.AmbalajVeMatbaaGrubuForms.AmbalajVeMatbaaGrubuEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.UlkeTanimForm.UlkeTanimListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.UlkeTanimForm.UlkeTanimEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlTanimForms.IlTanimListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlTanimForms.IlTanimEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlceTanimForms.IlceTanimListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlceTanimForms.IlceTanimEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CariTanimForms.CariTanimListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CariTanimForms.CariTanimEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TelVeIzgaraForms.TelVeIzgaraGrubuListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TelVeIzgaraForms.TelVeIzgaraGrubuEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DigerMalzemeGrubuForms.DigerMalzemeGrubuListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DigerMalzemeGrubuForms.DigerMalzemeGrubuEditForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MamulForms.MamulListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MamulForms.MamulEditForm>();

                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.UretimForms.UrunReceteListForm>();
                        services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.UretimForms.UrunReceteEditForm>();
                    })
                    .Build();

                ServiceProvider = host.Services;

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var licenseRepo = services.GetRequiredService<WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.Management.SystemLicense>>();
                        var activeLicense = licenseRepo.Find(x => true).FirstOrDefault();
                        
                        var licenseValidator = services.GetRequiredService<WinBeyazEsya.Application.Interfaces.Security.ILicenseValidator>();

                        string key = activeLicense != null ? activeLicense.LicenseKey : "";
                        var licenseData = licenseValidator.ValidateLicense(key);

                        if (!licenseData.IsValid)
                        {
                            Serilog.Log.Warning("Lisans geçersiz: {ErrorMessage}", licenseData.ErrorMessage);
                            MessageBox.Show(licenseData.ErrorMessage, "WinBeyazEsya Lisans Kalkanı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            var activationForm = services.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.LisansForms.LisansAktivasyonForm>();
                            if (activationForm.ShowDialog() != DialogResult.OK)
                            {
                                return;
                            }
                            
                            // Aktivasyon başarılı olduysa lisansı tekrar doğrula
                            activeLicense = licenseRepo.Find(x => true).FirstOrDefault();
                            string updatedKey = activeLicense != null ? activeLicense.LicenseKey : "";
                            licenseData = licenseValidator.ValidateLicense(updatedKey);

                            if (!licenseData.IsValid)
                            {
                                return; // Olası bir hata durumunda güvenli çıkış
                            }
                        }

                        licenseValidator.UpdateLastKnownGoodTime();

                        var seederService = services.GetRequiredService<IDatabaseSeederService>();
                        seederService.SeedAsync(true).GetAwaiter().GetResult();
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Fatal(ex, "Başlangıç servisleri yüklenirken kritik bir hata oluştu.");
                        string errMsg = ex.Message;
                        if (ex.InnerException != null)
                        {
                            errMsg += "\nInner Exception: " + ex.InnerException.Message;
                        }
                        MessageBox.Show($"Başlangıç hatası: {errMsg}", "WinBeyazEsya", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var entryAssembly2 = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name;
                if (entryAssembly2 != null && (entryAssembly2.StartsWith("ef") || entryAssembly2.StartsWith("dotnet-ef")))
                {
                    return;
                }

                var mainForm = host.Services.GetRequiredService<GirisForm>();
                System.Windows.Forms.Application.Run(mainForm);
            }
            finally
            {
                mutex.ReleaseMutex();
                mutex.Dispose();
            }
        }
        catch (Exception ex)
        {
            Serilog.Log.Fatal(ex, "Uygulama çalıştırılırken beklenmeyen bir çökme yaşandı (Main bloğu).");
        }
        finally
        {
            Serilog.Log.Information("Uygulama sonlandırıldı.");
            Serilog.Log.CloseAndFlush();
        }
    }

    private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        HandleException(e.Exception, "UI Thread (Application_ThreadException)");
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception ex)
        {
            HandleException(ex, "Background Thread (CurrentDomain_UnhandledException)");
        }
    }

    private static void TaskScheduler_UnobservedTaskException(object? sender, System.Threading.Tasks.UnobservedTaskExceptionEventArgs e)
    {
        HandleException(e.Exception, "Unobserved Task (TaskScheduler_UnobservedTaskException)");
        e.SetObserved(); // Uygulamanın çökmesini engelle
    }

    private static void HandleException(Exception ex, string source)
    {
        Serilog.Log.Fatal(ex, "Sistemde beklenmeyen bir hata oluştu. Kaynak: {ErrorSource}", source);

        bool isConnectionError = false;
        var currentEx = ex;

        while (currentEx != null)
        {
            if (currentEx is Microsoft.Data.SqlClient.SqlException || 
                (currentEx.GetType().Name.Contains("DbUpdateException") && currentEx.InnerException is Microsoft.Data.SqlClient.SqlException) ||
                (currentEx is System.InvalidOperationException invEx && invEx.Message.Contains("connection")))
            {
                isConnectionError = true;
                break;
            }
            currentEx = currentEx.InnerException;
        }

        if (isConnectionError)
        {
            SafeShowOnUIThread("İşleminiz sunucu bağlantısı koptuğu için tamamlanamadı.\nBağlantının gelmesini bekleyiniz.", "Bağlantı Koptu", MessageBoxIcon.Warning);
            return;
        }

        string userMessage = ex.Message;
        if (ex.InnerException != null)
        {
            userMessage += "\nİç Hata: " + ex.InnerException.Message;
        }

        if (!userMessage.StartsWith("Güvenlik Kısıtlaması") && !userMessage.StartsWith("İşlem Başarısız"))
        {
            userMessage = "Sistemde beklenmeyen bir hata oluştu. Lütfen sistem yöneticinize bilgi veriniz.\n\nHata Nedeni: " + userMessage;
        }

        SafeShowOnUIThread(userMessage, "Hata", MessageBoxIcon.Error);
    }

    /// <summary>
    /// BeginInvoke kullanarak mesajı UI Thread'e asenkron gönderir.
    /// Böylece UI Thread bloklanmış olsa bile deadlock oluşmaz;
    /// mesaj kuyrukta bekler ve thread boşaldığında gösterilir.
    /// </summary>
    private static void SafeShowOnUIThread(string message, string title, MessageBoxIcon icon)
    {
        try
        {
            var mainForm = System.Windows.Forms.Application.OpenForms.Count > 0
                ? System.Windows.Forms.Application.OpenForms[0]
                : null;

            if (mainForm != null && mainForm.IsHandleCreated && !mainForm.IsDisposed)
            {
                mainForm.BeginInvoke(new System.Action(() =>
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(mainForm, message, title, MessageBoxButtons.OK, icon);
                }));
            }
            else
            {
                // Açık form yoksa standart MessageBox (son çare)
                MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
            }
        }
        catch (Exception logEx)
        {
            Serilog.Log.Error(logEx, "SafeShowOnUIThread hatası.");
        }
    }
}
