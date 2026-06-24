using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThermaCore.Application;
using ThermaCore.Application.Interfaces.Configuration;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Enums;
using ThermaCore.Infrastructure;
using ThermaCore.Infrastructure.Configuration;
using ThermaCore.Presentation.WinForms.Forms.GenelForms;

namespace ThermaCore.Presentation.WinForms;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = default!;
    public static long? CurrentSessionId { get; set; }

    [STAThread]
    static void Main()
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
        catch
        {
            // Kültür bulunamazsa program çökmek yerine varsayılan olarak çalışmaya devam etsin.
        }

        System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

        ApplicationConfiguration.Initialize();

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
            catch
            {
                isConnected = false;
            }
        }

        if (!isConnected)
        {
            var entryAssembly = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name;
            if (entryAssembly != null && (entryAssembly.StartsWith("ef") || entryAssembly.StartsWith("dotnet-ef")))
            {
                // EF Core aracı çalışıyorsa, WinForms'u bloke etmeden ilerlemesi için host'u oluşturmalıyız
            }
            else
            {
                // Kurulum sihirbazı ve veritabanı servisleri için bağımlılıkları manuel çözüyoruz
                ThermaCore.Application.Interfaces.System.ITenantDatabaseService tenantDbService = new ThermaCore.Infrastructure.System.TenantDatabaseManager();
                ITenantDatabaseSetupService sistemVeritabaniService = new ThermaCore.Application.Services.System.TenantDatabaseSetupManager(null!, null!, tenantDbService, null!, null!, null!);

                System.Windows.Forms.Application.Run(new BaglantiHataForm(configService, sistemVeritabaniService));
                return;
            }
        }

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddApplicationServices();
                services.AddInfrastructureServices(connectionString);

                services.AddTransient<GirisForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.GenelForms.AnaForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.SirketForms.SirketListForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.SirketForms.SirketEditForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.FabrikaForms.FabrikaListForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.FabrikaForms.FabrikaEditForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.CodeTemplateForms.CodeTemplateListForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.CodeTemplateForms.CodeTemplateEditForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.KodYonetimForms.KodLogListForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.KodYonetimForms.KodLogEditForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms.RolListForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms.RolEditForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.KullaniciForms.KullaniciListForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.KullaniciForms.KullaniciEditForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.TerminalForms.TerminalListForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.TerminalForms.TerminalEditForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.ParametrelerForms.EmailParameterEditForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.ParametrelerForms.SystemLicenseEditForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.ParametrelerForms.UserInterfaceTemplateListForm>();
                services.AddTransient<ThermaCore.Presentation.WinForms.Forms.LisansForms.LicenseActivationForm>();
            })
            .Build();

        ServiceProvider = host.Services;

        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var licenseRepo = services.GetRequiredService<ThermaCore.Application.Interfaces.Repositories.IMasterRepository<ThermaCore.Domain.Entities.Management.SystemLicense>>();
                var activeLicense = licenseRepo.Find(x => true).FirstOrDefault();
                
                var licenseValidator = services.GetRequiredService<ThermaCore.Application.Interfaces.Security.ILicenseValidator>();

                if (licenseValidator.IsTimeTampered())
                {
                    MessageBox.Show("Sistem saati geriye alınmış veya manipüle edilmiş. Güvenlik ihlali tespit edildi.", "ThermaCore Lisans Kalkanı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string key = activeLicense != null ? activeLicense.LicenseKey : "";
                var licenseData = licenseValidator.ValidateLicense(key);

                if (!licenseData.IsValid)
                {
                    var activationForm = services.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.LisansForms.LicenseActivationForm>();
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

                var seederService = services.GetRequiredService<IDatabaseSeederService>();
                seederService.SeedAsync(true).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;
                if (ex.InnerException != null)
                {
                    errMsg += "\nInner Exception: " + ex.InnerException.Message;
                }
                MessageBox.Show($"Başlangıç hatası: {errMsg}", "ThermaCore", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        HandleException(e.Exception);
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception ex)
        {
            HandleException(ex);
        }
    }

    private static void HandleException(Exception ex)
    {
        try
        {
            string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            string logFile = Path.Combine(logDir, $"ErrorLog_{DateTime.Now:yyyyMMdd}.txt");
            string logContent = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] ERROR: {ex.Message}{Environment.NewLine}STACK TRACE:{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}--------------------------------------------------{Environment.NewLine}";
            
            File.AppendAllText(logFile, logContent);
        }
        catch { }

        string userMessage = ex.Message;
        if (!userMessage.StartsWith("Güvenlik Kısıtlaması") && !userMessage.StartsWith("İşlem Başarısız"))
        {
            userMessage = "Sistemde beklenmeyen bir hata oluştu. Lütfen sistem yöneticinize bilgi veriniz.\n\nHata Nedeni: " + ex.Message;
        }
        ThermaCore.Presentation.WinForms.Helpers.Messages.HataMesaji(userMessage);
    }
}
