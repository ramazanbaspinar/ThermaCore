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

namespace WinBeyazEsya.Presentation.WinForms;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = default!;
    public static long? CurrentSessionId { get; set; }

    [STAThread]
    static void Main()
    {
        bool createdNew;
        var mutex = new Mutex(true, "Global\\WinBeyazEsyaERP_SingleInstance_Mutex", out createdNew);

        if (!createdNew)
        {
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
                WinBeyazEsya.Application.Interfaces.System.ITenantDatabaseService tenantDbService = new WinBeyazEsya.Infrastructure.System.TenantDatabaseManager();
                ITenantDatabaseSetupService sistemVeritabaniService = new WinBeyazEsya.Application.Services.System.TenantDatabaseSetupManager(null!, null!, tenantDbService, null!, null!, null!);

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
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.GenelForms.AnaForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.SirketForms.SirketListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.SirketForms.SirketEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.FabrikaForms.FabrikaListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.FabrikaForms.FabrikaEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.CodeTemplateForms.CodeTemplateListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.CodeTemplateForms.CodeTemplateEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.KodYonetimForms.KodLogListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.KodYonetimForms.KodLogEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.YetkilendirmeForms.RolListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.YetkilendirmeForms.RolEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.KullaniciForms.KullaniciListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.KullaniciForms.KullaniciEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TerminalForms.TerminalListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TerminalForms.TerminalEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.EmailParameterEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.SystemLicenseEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.GenelParametrelerEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.UserInterfaceTemplateListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.LisansForms.LicenseActivationForm>();
                
                // Definitions
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GenelGiderForms.GenelGiderListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GenelGiderForms.GenelGiderEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MaliyetParametreForms.MaliyetParametreEditForm>();                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.SacMaliyetForms.SacMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.SacMaliyetForms.SacMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TelMaliyetForms.TelMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TelMaliyetForms.TelMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.IzgaraMaliyetForms.IzgaraMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.IzgaraMaliyetForms.IzgaraMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TepsiMaliyetForms.TepsiMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TepsiMaliyetForms.TepsiMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.RezistansMaliyetForms.RezistansMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.RezistansMaliyetForms.RezistansMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KabloMaliyetForms.KabloMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KabloMaliyetForms.KabloMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MotorMaliyetForms.MotorMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MotorMaliyetForms.MotorMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.FanMaliyetForms.FanMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.FanMaliyetForms.FanMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.RotaryMaliyetForms.RotaryMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.RotaryMaliyetForms.RotaryMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TermostatMaliyetForms.TermostatMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TermostatMaliyetForms.TermostatMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TimerMaliyetForms.TimerMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TimerMaliyetForms.TimerMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.LambaMaliyetForms.LambaMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.LambaMaliyetForms.LambaMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PleytMaliyetForms.PleytMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PleytMaliyetForms.PleytMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazMusluguMaliyetForms.GazMusluguMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazMusluguMaliyetForms.GazMusluguMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ValfMaliyetForms.ValfMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ValfMaliyetForms.ValfMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BekGrubuMaliyetForms.BekGrubuMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BekGrubuMaliyetForms.BekGrubuMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.EnjektorMaliyetForms.EnjektorMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.EnjektorMaliyetForms.EnjektorMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TermokuplMaliyetForms.TermokuplMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TermokuplMaliyetForms.TermokuplMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.CakmakMaliyetForms.CakmakMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.CakmakMaliyetForms.CakmakMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AteslemeTrafosuMaliyetForms.AteslemeTrafosuMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AteslemeTrafosuMaliyetForms.AteslemeTrafosuMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazBorusuMaliyetForms.GazBorusuMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazBorusuMaliyetForms.GazBorusuMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.RakorMaliyetForms.RakorMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.RakorMaliyetForms.RakorMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PlastikParcaMaliyetForms.PlastikParcaMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PlastikParcaMaliyetForms.PlastikParcaMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KulpMaliyetForms.KulpMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KulpMaliyetForms.KulpMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.DugmeMaliyetForms.DugmeMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.DugmeMaliyetForms.DugmeMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.CamMaliyetForms.CamMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.CamMaliyetForms.CamMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BoyaMaliyetForms.BoyaMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BoyaMaliyetForms.BoyaMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.EmayeMaliyetForms.EmayeMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.EmayeMaliyetForms.EmayeMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.IzalasyonMaliyetForms.IzolasyonMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.IzalasyonMaliyetForms.IzolasyonMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ContaMaliyetForms.ContaMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ContaMaliyetForms.ContaMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.VidaMaliyetForms.VidaMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.VidaMaliyetForms.VidaMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MenteseMaliyetForms.MenteseMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MenteseMaliyetForms.MenteseMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KilitMaliyetForms.KilitMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KilitMaliyetForms.KilitMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BaglantiMaliyetForms.BaglantiElemaniMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BaglantiMaliyetForms.BaglantiElemaniMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AmbalajMalzemesiMaliyetForms.AmbalajMalzemesiMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AmbalajMaliyetForms.AmbalajMalzemesiMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MatbaaKilavuzMaliyetForms.MatbaaKilavuzMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MatbaaKilavuzMaliyetForms.MatbaaKilavuzMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.EtiketMaliyetForms.EtiketMaliyetListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.EtiketMaliyetForms.EtiketMaliyetEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KurlarForms.KurListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KurlarForms.KurEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.VergiForms.VergiOraniListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.VergiForms.VergiOraniEditForm>();

                // Production

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IzolasyonForms.IzolasyonListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IzolasyonForms.IzolasyonEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TelForms.TelListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TelForms.TelEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IzgaraForms.IzgaraListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IzgaraForms.IzgaraEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TepsiForms.TepsiListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TepsiForms.TepsiEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KulpForms.KulpListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KulpForms.KulpEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.RakorForms.RakorListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.RakorForms.RakorEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.KaliteStandartForms.KaliteStandartListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.KaliteStandartForms.KaliteStandartEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.YuzeyTipiForms.YuzeyTipiListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.YuzeyTipiForms.YuzeyTipiEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.SacForms.SacListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.SacForms.SacEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.BoyaForms.BoyaListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.BoyaForms.BoyaEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.EmayeForms.EmayeListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.EmayeForms.EmayeEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.VidaForms.VidaListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.VidaForms.VidaEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.RezistansForms.RezistansListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.RezistansForms.RezistansEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.RotaryForms.RotaryListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.RotaryForms.RotaryEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TermostatForms.TermostatEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TermostatForms.TermostatListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TimerForms.TimerEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TimerForms.TimerListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DugmeForms.DugmeListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DugmeForms.DugmeEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KulpForms.KulpListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KulpForms.KulpEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms.CamListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms.CamEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms.CamTipiForms.CamTipiListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms.CamTipiForms.CamTipiEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms.RenkOzellikForms.CamRenkListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms.RenkOzellikForms.CamRenkEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KabloForms.KabloListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KabloForms.KabloEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PleytForms.PleytListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PleytForms.PleytEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.LambaForms.LambaListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.LambaForms.LambaEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MotorForms.MotorListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MotorForms.MotorEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.FanForms.FanListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.FanForms.FanEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazForms.GazListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazForms.GazMusluguEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazBorusuForms.GazBorusuListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazBorusuForms.GazBorusuEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BekForms.BekListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BekForms.BekEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.EnjektorForms.EnjektorListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.EnjektorForms.EnjektorEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ValfForms.ValfListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ValfForms.ValfEditForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TermokuplForms.TermokuplListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TermokuplForms.TermokuplEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CakmakForms.CakmakListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CakmakForms.CakmakEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.AteslemeTrafosuForms.AteslemeTrafosuListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.AteslemeTrafosuForms.AteslemeTrafosuEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MenteseForms.MenteseListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MenteseForms.MenteseEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ContaForms.ContaListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ContaForms.ContaEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PlastikParcaForms.PlastikParcaListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PlastikParcaForms.PlastikParcaEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KilitForms.KilitListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KilitForms.KilitEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.AmbalajMalzemesiForms.AmbalajMalzemesiListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.AmbalajMalzemesiForms.AmbalajMalzemesiEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BaglantiElemaniForms.BaglantiElemaniListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BaglantiElemaniForms.BaglantiElemaniEditForm>();

                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MatbaaKilavuzForms.MatbaaKilavuzListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MatbaaKilavuzForms.MatbaaKilavuzEditForm>();
                
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.EtiketForms.EtiketListForm>();
                services.AddTransient<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.EtiketForms.EtiketEditForm>();
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
                    MessageBox.Show(licenseData.ErrorMessage, "WinBeyazEsya Lisans Kalkanı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    var activationForm = services.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.LisansForms.LicenseActivationForm>();
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
        if (ex.InnerException != null)
        {
            userMessage += "\nİç Hata: " + ex.InnerException.Message;
        }

        if (!userMessage.StartsWith("Güvenlik Kısıtlaması") && !userMessage.StartsWith("İşlem Başarısız"))
        {
            userMessage = "Sistemde beklenmeyen bir hata oluştu. Lütfen sistem yöneticinize bilgi veriniz.\n\nHata Nedeni: " + userMessage;
        }
        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataMesaji(userMessage);
    }
}

