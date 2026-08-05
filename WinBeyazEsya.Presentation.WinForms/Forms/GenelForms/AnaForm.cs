using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using WinBeyazEsya.Application.Interfaces.System; // ICurrentTenantService ve ISessionService için
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public partial class AnaForm : XtraForm
    {
        private bool _programiOtomatikKapat = false;

        // DI Konteynerinden Gelecek Servisler
        private readonly IServiceProvider _serviceProvider;
        private readonly ICurrentTenantService _currentTenantService;
        private readonly ISessionService _sessionService;

        public AnaForm(
            IServiceProvider serviceProvider,
            ICurrentTenantService currentTenantService,
            ISessionService sessionService)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _currentTenantService = currentTenantService;
            _sessionService = sessionService;

            EventsLoad();
        }

        private void EventsLoad()
        {
            Load += AnaForm_Load;
            Shown += AnaForm_Shown;
            FormClosing += AnaForm_FormClosing;
            KeyDown += Control_KeyDown;

            if (miEmailParameter != null)
                miEmailParameter.Click += (s, e) =>
                {
                    var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.EmailParameterEditForm>();
                    form.ShowDialog();
                };

            if (miSystemLicense != null)
                miSystemLicense.Click += (s, e) =>
                {
                    var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.SystemLicenseEditForm>();
                    form.ShowDialog();
                };

            if (miMaliyetParametreleri != null)
            {
                miMaliyetParametreleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MaliyetParametreleri;
                miMaliyetParametreleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MaliyetParametreleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MaliyetParametreForms.MaliyetParametreEditForm>();
                        form.ShowDialog();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            // Dinamik Yükleme Click Eventleri
            if (miGenelParametreler != null)
                miGenelParametreler.Click += miGenelParametreler_Click;

            if (miSirketTanimlari != null)
                miSirketTanimlari.Click += miSirketTanimlari_Click;

            if (miBirimTanimlari != null)
                miBirimTanimlari.Click += miBirimTanimlari_Click;

            if (miKurTanimlari != null)
                miKurTanimlari.Click += miKurTanimlari_Click;

            if (miKdvOranlari != null)
                miKdvOranlari.Click += miKdvOranlari_Click;

            if (miOtvOranlari != null)
                miOtvOranlari.Click += miOtvOranlari_Click;


            if (miKullaniciArayuzSablonlari != null)
                miKullaniciArayuzSablonlari.Click += (s, e) =>
                {
                    FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.UserInterfaceTemplateListForm>();
                };

            if (miCodeTemplatelari != null)
                miCodeTemplatelari.Click += miCodeTemplatelari_Click;

            if (miYetkiGruplariRoller != null)
                miYetkiGruplariRoller.Click += miYetkiGruplariRoller_Click;

            if (miKullaniciTanimlari != null)
                miKullaniciTanimlari.Click += KullaniciTanimlari_Click;

            if (miTerminalYonetim != null)
                miTerminalYonetim.Click += miTerminalYonetim_Click;

            if (miTermostatTanimlari != null)
                miTermostatTanimlari.Click += MiTermostatTanimlari_Click;

            if (miTimerTanimlari != null)
                miTimerTanimlari.Click += MiTimerTanimlari_Click;


            if (miDugmeTanimlari != null)
            {
                miDugmeTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.DugmeTanimlari;
                miDugmeTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.DugmeTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DugmeForms.DugmeListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }
            if (miKaliteStandartTanimlari != null)
            {
                miKaliteStandartTanimlari.Click += miKaliteStandartTanimlari_Click;
            }



            if (miSacTanimlari != null)
            {
                miSacTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.SacTanimlari;
                miSacTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.SacTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.SacForms.SacListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miRakorTanimlari != null)
            {
                miRakorTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.RakorTanimlari;
                miRakorTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.RakorTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.RakorForms.RakorListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miTelTanimlari != null)
            {
                miTelTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TelTanimlari;
                miTelTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TelTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TelForms.TelListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miBoyaTanimlari != null)
            {
                miBoyaTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.BoyaTanimlari;
                miBoyaTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.BoyaTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.BoyaForms.BoyaListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miCamTanimlari != null)
            {
                miCamTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.CamTanimlari;
                miCamTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.CamTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms.CamListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miEmayeTanimlari != null)
            {
                miEmayeTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.EmayeTanimlari;
                miEmayeTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.EmayeTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.EmayeForms.EmayeListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miVidaTanimlari != null)
            {
                miVidaTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.VidaTanimlari;
                miVidaTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.VidaTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.VidaForms.VidaListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miRezistansTanimlari != null)
            {
                miRezistansTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.RezistansTanimlari;
                miRezistansTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.RezistansTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.RezistansForms.RezistansListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miAnahtarRotaryTanimlari != null)
            {
                miAnahtarRotaryTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.AnahtarRotaryTanimlari;
                miAnahtarRotaryTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.AnahtarRotaryTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.RotaryForms.RotaryListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miKulpTanimlari != null)
            {
                miKulpTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KulpTanimlari;
                miKulpTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.KulpTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KulpForms.KulpListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miKabloTanimlari != null)
            {
                miKabloTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KabloTanimlari;
                miKabloTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.KabloTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KabloForms.KabloListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miPleytIsiticiTanimlari != null)
            {
                miPleytIsiticiTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.PleytIsiticiTanimlari;
                miPleytIsiticiTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.PleytIsiticiTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PleytForms.PleytListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miLambaTanimlari != null)
            {
                miLambaTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.LambaTanimlari;
                miLambaTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.LambaTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.LambaForms.LambaListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miMotorTanimlari != null)
            {
                miMotorTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MotorTanimlari;
                miMotorTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MotorTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MotorForms.MotorListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miFanTanimlari != null)
            {
                miFanTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.FanTanimlari;
                miFanTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.FanTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.FanForms.FanListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miGazMusluguTanimlari != null)
            {
                miGazMusluguTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.GazMusluguTanimlari;
                miGazMusluguTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.GazMusluguTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazForms.GazListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miBekGrubuTanimlari != null)
            {
                miBekGrubuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.BekGrubuTanimlari;
                miBekGrubuTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.BekGrubuTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BekForms.BekListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miEnjektorTanimlari != null)
            {
                miEnjektorTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.EnjektorTanimlari;
                miEnjektorTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.EnjektorTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.EnjektorForms.EnjektorListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miValfTanimlari != null)
            {
                miValfTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.ValfTanimlari;
                miValfTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.ValfTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ValfForms.ValfListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miTermokuplTanimlari != null)
            {
                miTermokuplTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TermokuplTanimlari;
                miTermokuplTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TermokuplTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TermokuplForms.TermokuplListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miCakmakTanimlari != null)
            {
                miCakmakTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.CakmakTanimlari;
                miCakmakTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.CakmakTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CakmakForms.CakmakListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miAteslemeTrafosuTanimlari != null)
            {
                miAteslemeTrafosuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.AteslemeTrafosuTanimlari;
                miAteslemeTrafosuTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.AteslemeTrafosuTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.AteslemeTrafosuForms.AteslemeTrafosuListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miIzolasyonTanimlari != null)
            {
                miIzolasyonTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.IzolasyonTanimlari;
                miIzolasyonTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.IzolasyonTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IzolasyonForms.IzolasyonListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miGazBorusuTanimlari != null)
            {
                miGazBorusuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.GazBorusuTanimlari;
                miGazBorusuTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.GazBorusuTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazBorusuForms.GazBorusuListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miMenteseTanimlari != null)
            {
                miMenteseTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MenteseTanimlari;
                miMenteseTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MenteseTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MenteseForms.MenteseListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miContaTanimlari != null)
            {
                miContaTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.ContaTanimlari;
                miContaTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.ContaTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ContaForms.ContaListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miIzgaraTanimlari != null)
            {
                miIzgaraTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.IzgaraTanimlari;
                miIzgaraTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.IzgaraTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IzgaraForms.IzgaraListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miTepsiTanimlari != null)
            {
                miTepsiTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TepsiTanimlari;
                miTepsiTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TepsiTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TepsiForms.TepsiListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miPlastikParcaTanimlari != null)
            {
                miPlastikParcaTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.PlastikParcaTanimlari;
                miPlastikParcaTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.PlastikParcaTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PlastikParcaForms.PlastikParcaListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miKilitTanimlari != null)
            {
                miKilitTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KilitTanimlari;
                miKilitTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.KilitTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KilitForms.KilitListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miBaglantiElemaniTanimlari != null)
            {
                miBaglantiElemaniTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.BaglantiElemaniTanimlari;
                miBaglantiElemaniTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.BaglantiElemaniTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BaglantiElemaniForms.BaglantiElemaniListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miAmbalajMalzemesiTanimlari != null)
            {
                miAmbalajMalzemesiTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.AmbalajMalzemesiTanimlari;
                miAmbalajMalzemesiTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.AmbalajMalzemesiTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.AmbalajMalzemesiForms.AmbalajMalzemesiListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miMatbaaTanimlari != null)
            {
                miMatbaaTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MatbaaTanimlari;
                miMatbaaTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MatbaaTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MatbaaKilavuzForms.MatbaaKilavuzListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miEtiketTanimlari != null)
            {
                miEtiketTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.EtiketTanimlari;
                miEtiketTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.EtiketTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.EtiketForms.EtiketListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }
            if (miGenelGiderler != null)
            {
                miGenelGiderler.Tag = WinBeyazEsya.Domain.Enums.ModuleType.GenelGiderTanimlari;
                miGenelGiderler.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.GenelGiderTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GenelGiderForms.GenelGiderListForm>();
                    }
                    else
                    {
                        WinBeyazEsya.Presentation.WinForms.Helpers.Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır.");
                    }
                };
            }

            if (miSacMaliyetleri != null)
            {
                miSacMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.SacMaliyetleri;
                miSacMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.SacMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.SacMaliyetForms.SacMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miTelMaliyetleri != null)
            {
                miTelMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TelMaliyetleri;
                miTelMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TelMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TelMaliyetForms.TelMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miIzgaraMaliyetleri != null)
            {
                miIzgaraMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.IzgaraMaliyetleri;
                miIzgaraMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.IzgaraMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.IzgaraMaliyetForms.IzgaraMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miTepsiMaliyetleri != null)
            {
                miTepsiMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TepsiMaliyetleri;
                miTepsiMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TepsiMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TepsiMaliyetForms.TepsiMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miRezistansMaliyetleri != null)
            {
                miRezistansMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.RezistansMaliyetleri;
                miRezistansMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.RezistansMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.RezistansMaliyetForms.RezistansMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miKabloMaliyetleri != null)
            {
                miKabloMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KabloMaliyetleri;
                miKabloMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.KabloMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KabloMaliyetForms.KabloMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miMotorMaliyetleri != null)
            {
                miMotorMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MotorMaliyetleri;
                miMotorMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MotorMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MotorMaliyetForms.MotorMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miFanMaliyetleri != null)
            {
                miFanMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.FanMaliyetleri;
                miFanMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.FanMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.FanMaliyetForms.FanMaliyetEditForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miAnahtarRotaryMaliyetleri != null)
            {
                miAnahtarRotaryMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.RotaryMaliyetleri;
                miAnahtarRotaryMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.RotaryMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.RotaryMaliyetForms.RotaryMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miTermostatMaliyetleri != null)
            {
                miTermostatMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TermostatMaliyetleri;
                miTermostatMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TermostatMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TermostatMaliyetForms.TermostatMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miTimerZamanlayiciMaliyetleri != null)
            {
                miTimerZamanlayiciMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TimerMaliyetleri;
                miTimerZamanlayiciMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TimerMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TimerMaliyetForms.TimerMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miLambaMaliyetleri != null)
            {
                miLambaMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.LambaMaliyetleri;
                miLambaMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.LambaMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.LambaMaliyetForms.LambaMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miPleytIsiticiMaliyetleri != null)
            {
                miPleytIsiticiMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.PleytMaliyetleri;
                miPleytIsiticiMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.PleytMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PleytMaliyetForms.PleytMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miGazMusluguMaliyetleri != null)
            {
                miGazMusluguMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.GazMusluguMaliyetleri;
                miGazMusluguMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.GazMusluguMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazMusluguMaliyetForms.GazMusluguMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miValfMaliyetleri != null)
            {
                miValfMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.ValfMaliyetleri;
                miValfMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.ValfMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ValfMaliyetForms.ValfMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miBekMaliyetleri != null)
            {
                miBekMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.BekMaliyetleri;
                miBekMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.BekMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BekGrubuMaliyetForms.BekGrubuMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miEnjektorMaliyetleri != null)
            {
                miEnjektorMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.EnjektorMaliyetleri;
                miEnjektorMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.EnjektorMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.EnjektorMaliyetForms.EnjektorMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miTermokuplEmniyetMaliyetleri != null)
            {
                miTermokuplEmniyetMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TermokuplMaliyetleri;
                miTermokuplEmniyetMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TermokuplMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TermokuplMaliyetForms.TermokuplMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miCakmakBujiMaliyetleri != null)
            {
                miCakmakBujiMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.CakmakMaliyetleri;
                miCakmakBujiMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.CakmakMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.CakmakMaliyetForms.CakmakMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miAteslemeTrafosuMaliyetleri != null)
            {
                miAteslemeTrafosuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.AteslemeTrafosuMaliyetleri;
                miAteslemeTrafosuMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.AteslemeTrafosuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AteslemeTrafosuMaliyetForms.AteslemeTrafosuMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miGazBorusuMaliyetleri != null)
            {
                miGazBorusuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.GazBorusuMaliyetleri;
                miGazBorusuMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.GazBorusuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazBorusuMaliyetForms.GazBorusuMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miRakorMaliyetleri != null)
            {
                miRakorMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.RakorMaliyetleri;
                miRakorMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.RakorMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.RakorMaliyetForms.RakorMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miPlastikParcaMaliyetleri != null)
            {
                miPlastikParcaMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.PlastikParcaMaliyetleri;
                miPlastikParcaMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.PlastikParcaMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PlastikParcaMaliyetForms.PlastikParcaMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miKulpMaliyetleri != null)
            {
                miKulpMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KulpMaliyetleri;
                miKulpMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.KulpMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KulpMaliyetForms.KulpMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miDugmeMaliyetleri != null)
            {
                miDugmeMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.DugmeMaliyetleri;
                miDugmeMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.DugmeMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.DugmeMaliyetForms.DugmeMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miCamMaliyetleri != null)
            {
                miCamMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.CamMaliyetleri;
                miCamMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.CamMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.CamMaliyetForms.CamMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miBoyaMaliyetleri != null)
            {
                miBoyaMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.BoyaMaliyetleri;
                miBoyaMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.BoyaMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BoyaMaliyetForms.BoyaMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miEmayeMaliyetleri != null)
            {
                miEmayeMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.EmayeMaliyetleri;
                miEmayeMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.EmayeMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.EmayeMaliyetForms.EmayeMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miIzolasyonMaliyetleri != null)
            {
                miIzolasyonMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.IzolasyonMaliyetleri;
                miIzolasyonMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.IzolasyonMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.IzalasyonMaliyetForms.IzolasyonMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miContaMaliyetleri != null)
            {
                miContaMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.ContaMaliyetleri;
                miContaMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.ContaMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ContaMaliyetForms.ContaMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miVidaMaliyetleri != null)
            {
                miVidaMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.VidaMaliyetleri;
                miVidaMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.VidaMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.VidaMaliyetForms.VidaMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miMenteseMaliyetleri != null)
            {
                miMenteseMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MenteseMaliyetleri;
                miMenteseMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MenteseMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MenteseMaliyetForms.MenteseMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miKilitMaliyetleri != null)
            {
                miKilitMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KilitMaliyetleri;
                miKilitMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.KilitMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KilitMaliyetForms.KilitMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miBaglantiElemaniMaliyeti != null)
            {
                miBaglantiElemaniMaliyeti.Tag = WinBeyazEsya.Domain.Enums.ModuleType.BaglantiElemaniMaliyetleri;
                miBaglantiElemaniMaliyeti.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.BaglantiElemaniMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.BaglantiMaliyetForms.BaglantiElemaniMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miAmbalajMalzemesiMaliyetleri != null)
            {
                miAmbalajMalzemesiMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.AmbalajMalzemesiMaliyetleri;
                miAmbalajMalzemesiMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.AmbalajMalzemesiMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AmbalajMalzemesiMaliyetForms.AmbalajMalzemesiMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miMatbaaKilavuzMaliyetleri != null)
            {
                miMatbaaKilavuzMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MatbaaKilavuzMaliyetleri;
                miMatbaaKilavuzMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MatbaaKilavuzMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MatbaaKilavuzMaliyetForms.MatbaaKilavuzMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miEtiketMaliyetleri != null)
            {
                miEtiketMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.EtiketMaliyetleri;
                miEtiketMaliyetleri.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.EtiketMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.EtiketMaliyetForms.EtiketMaliyetListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (xtraTabbedMdiManager != null)
            {
                xtraTabbedMdiManager.PageAdded += XtraTabbedMdiManager_PageAdded;
                xtraTabbedMdiManager.PageRemoved += XtraTabbedMdiManager_PageRemoved;
            }

            foreach (Control control in Controls)
                control.KeyDown += Control_KeyDown;
        }

        private void Control_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void AnaForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (_programiOtomatikKapat)
            {
                CloseSessionAndExit();
            }
            else
            {
                // Eski Messages yapısı temizlendiği için standart MessageBox'a çevrildi
                var cevap = Messages.KapatMesaj();

                if (cevap == DialogResult.Yes)
                {
                    CloseSessionAndExit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void CloseSessionAndExit()
        {
            if (Program.CurrentSessionId.HasValue)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var repo = scope.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.System.UserSession>>();
                    var uow = scope.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Repositories.IMasterUnitOfWork>();

                    var session = repo.Find(s => s.Id == Program.CurrentSessionId.Value).FirstOrDefault();
                    if (session != null)
                    {
                        session.LogoutTime = DateTime.Now;
                        session.Status = WinBeyazEsya.Domain.Enums.SessionStatus.Closed;
                        repo.Update(session);
                        uow.SaveChanges();
                    }
                }
                catch
                {
                    // Hata yutulsun, kapanmaya engel olmasın.
                }
            }
            
            // Eğer Updater hazırsa çalıştır
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string updaterPath = System.IO.Path.Combine(appPath, "WinBeyazEsya.Updater.exe");
            string manifestPath = System.IO.Path.Combine(appPath, "Temp", "UpdateCache", "update_manifest.json");

            if (System.IO.File.Exists(updaterPath) && System.IO.File.Exists(manifestPath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = updaterPath,
                    WorkingDirectory = appPath,
                    UseShellExecute = true
                });
                System.Threading.Thread.Sleep(500); // Process'in ayağa kalkması için kısa bir süre tanı
            }

            Environment.Exit(0);
        }

        private void AnaForm_Load(object? sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Seçili firma ve kullanıcı bilgilerini bar başlıklarına (veya pencere başlığına) yazdır
                Text = $"İtimat ERP --- Bilgisayar: {Environment.MachineName}";

                var scopeFactory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();

                string currentConnString = _currentTenantService.ConnectionString;
                long currentTenantId = _currentTenantService.TenantId;
                string currentTenantName = _currentTenantService.TenantName;
                long currentUserId = _currentTenantService.UserId;

                // Fire & Forget TCMB Kurlarını Senkronize Et
                Task.Run(async () =>
                {
                    try
                    {
                        using var scope = scopeFactory.CreateScope();

                        // Otomatik Güncelleme Kontrolü
                        try
                        {
                            var updateService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Updater.IAutoUpdateService>();
                            string appPath = AppDomain.CurrentDomain.BaseDirectory;

                            var manifest = await updateService.CheckForUpdatesAsync();
                            string currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0.0";
                            
                            if (manifest != null && manifest.Version != currentVersion)
                            {
                                if (!manifest.IsCritical)
                                {
                                    bool success = await updateService.DownloadUpdatesAsync(manifest, appPath);
                                    if (success)
                                    {
                                        this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                                        {
                                            DevExpress.XtraBars.Alerter.AlertControl alertControl = new DevExpress.XtraBars.Alerter.AlertControl();
                                            alertControl.Show(this, "Güncelleme Hazır", "Yeni bir güncelleme arka planda indirildi. Programı kapattığınızda otomatik olarak kurulacaktır.");
                                        });
                                    }
                                }
                            }
                            else if (manifest != null && manifest.Version == currentVersion)
                            {
                                // Günceliz! Sürüm notları daha önce gösterilmediyse göster
                                string versionFilePath = System.IO.Path.Combine(appPath, "last_version.txt");
                                string lastRunVersion = "";
                                if (System.IO.File.Exists(versionFilePath))
                                {
                                    lastRunVersion = System.IO.File.ReadAllText(versionFilePath);
                                }

                                if (lastRunVersion != currentVersion && manifest.ReleaseNotes != null && manifest.ReleaseNotes.Count > 0)
                                {
                                    this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                                    {
                                        using (var notesForm = new WinBeyazEsya.Presentation.WinForms.Forms.GenelForms.ReleaseNotesForm(manifest.Version, manifest.ReleaseNotes))
                                        {
                                            notesForm.ShowDialog(this);
                                        }
                                        
                                        // Versiyon bilgisini dosyaya kaydet
                                        try 
                                        { 
                                            System.IO.File.WriteAllText(versionFilePath, currentVersion);
                                        } 
                                        catch { }
                                    });
                                }
                            }
                        }
                        catch { /* Sessiz hata */ }

                        // Scope içerisinde yeni üretilen ICurrentTenantService'e ana context'teki bilgileri aktar
                        var backgroundTenantService = scope.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.System.ICurrentTenantService>();
                        backgroundTenantService.ConnectionString = currentConnString;
                        backgroundTenantService.TenantId = currentTenantId;
                        backgroundTenantService.TenantName = currentTenantName;
                        backgroundTenantService.UserId = currentUserId;

                        var exchangeRateService = scope.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.System.IExchangeRateService>();
                        await exchangeRateService.SyncTcmbRatesAsync();

                        // Veritabanından (TenantDB) en güncel USD ve EUR EffectiveSellingRate değerlerini oku.
                        var exchangeRateRepository = scope.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Repositories.IRepository<WinBeyazEsya.Domain.Entities.Management.ExchangeRate>>();

                        var usdRate = exchangeRateRepository.Find(x => x.CurrencyCode == "USD").OrderByDescending(x => x.RateDate).FirstOrDefault();
                        var eurRate = exchangeRateRepository.Find(x => x.CurrencyCode == "EUR").OrderByDescending(x => x.RateDate).FirstOrDefault();

                        this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                        {
                            if (usdRate != null && eurRate != null)
                            {
                                string kurTarihiEk = usdRate.RateDate.Date == DateTime.Now.Date ? "" : $" (Kur Tarihi: {usdRate.RateDate:dd.MM.yyyy})";
                                lblMenuSripBilgi.Text = $"{DateTime.Now:dd.MM.yyyy} | USD: {usdRate.EffectiveSellingRate:F4} - EUR: {eurRate.EffectiveSellingRate:F4}{kurTarihiEk}";
                            }
                            else
                            {
                                lblMenuSripBilgi.Text = $"{DateTime.Now:dd.MM.yyyy} | Kur Bilgisi Alınamadı";
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[AnaForm] TCMB Kurları arka plan senkronizasyon hatası: {ex.Message}");
                        this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                        {
                            lblMenuSripBilgi.Text = "Bağlantı Hatası: Kurlar Alınamadı";
                        });
                    }
                });

                // TODO: OnaylanmamisKayitlariKontrolEtAsync(); (İş kuralları Application katmanına taşınacak)
                // TODO: AylikMetreBilgisiGetirAsync(); (EF Core sorguları Application katmanına taşınacak)

                SetMenuTags();
                if (menuStrip != null)
                {
                    ApplyMenuPermissions(menuStrip.Items);
                }
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Hata");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void SetMenuTags()
        {
            // Tasarımcıdan (Designer) verilecek.
        }

        private void ApplyMenuPermissions(ToolStripItemCollection items)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService == null) return;

            var userRepo = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.Management.User>>();
            var user = userRepo?.GetById(_currentTenantService.UserId);
            bool isSuperAdmin = user != null && (user.Code.ToLower() == "winbeyazesya");

            ApplyMenuPermissionsRecursive(items, authService, isSuperAdmin);
        }

        private void ApplyMenuPermissionsRecursive(ToolStripItemCollection items, WinBeyazEsya.Application.Services.Management.IAuthService authService, bool isSuperAdmin)
        {
            foreach (ToolStripItem item in items)
            {
                if (isSuperAdmin)
                {
                    item.Visible = true;
                    if (item is ToolStripMenuItem mi && mi.DropDownItems.Count > 0)
                    {
                        ApplyMenuPermissionsRecursive(mi.DropDownItems, authService, isSuperAdmin);
                    }
                    continue;
                }

                bool hasVisibleChildren = false;

                if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0)
                {
                    ApplyMenuPermissionsRecursive(menuItem.DropDownItems, authService, isSuperAdmin);

                    foreach (ToolStripItem child in menuItem.DropDownItems)
                    {
                        if (child.Available)
                        {
                            hasVisibleChildren = true;
                            break;
                        }
                    }
                }

                if (item is ToolStripMenuItem parentMenu && parentMenu.DropDownItems.Count > 0)
                {
                    // Eğer menünün altında başka menüler varsa (yani bir kategori/klasör ise)
                    // Tag'i olsa bile veritabanındaki (CanRead=false) değerine bakma! Sadece altındakilerin durumuna bak.
                    item.Visible = hasVisibleChildren;
                }
                else if (item.Tag is WinBeyazEsya.Domain.Enums.ModuleType moduleType)
                {
                    bool hasAccess = authService.HasPermission(moduleType, WinBeyazEsya.Domain.Enums.PermissionType.CanView);
                    item.Visible = hasAccess;
                }
                else if (item.Tag is string tagStr)
                {
                    if (Enum.TryParse(tagStr.Trim(), true, out WinBeyazEsya.Domain.Enums.ModuleType parsedModuleType))
                    {
                        bool hasAccess = authService.HasPermission(parsedModuleType, WinBeyazEsya.Domain.Enums.PermissionType.CanView);
                        item.Visible = hasAccess;
                    }
                    else
                    {
                        // Geçersiz bir tag verilmişse güvenlik gereği gizli tut.
                        item.Visible = false;
                    }
                }
            }
        }

        private async void AnaForm_Shown(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            var appConfigService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Configuration.IAppConfigService>();

            long userId = _currentTenantService.UserId;
            long tenantId = _currentTenantService.TenantId;

            var allowedBranches = await authService.GetAllowedBranchesAsync(userId, tenantId);

            if (allowedBranches == null || allowedBranches.Count == 0)
            {
                var userRepo = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.Management.User>>();
                var user = userRepo.Find(u => u.Id == userId).FirstOrDefault();

                if (user != null && (user.Code.ToLower() == "winbeyazesya"))
                {
                    _currentTenantService.BranchId = 0;
                    _currentTenantService.BranchName = "Şube Yok / Kurulum Modu";
                }
                else
                {
                    Messages.HataBasligi("Giriş yaptığınız şirkette hiçbir fabrika/şube yetkiniz bulunmuyor. Oturum kapatılacaktır.", "Yetkisiz Erişim");
                    _programiOtomatikKapat = true;
                    System.Windows.Forms.Application.Exit();
                    return;
                }
            }
            else if (allowedBranches.Count == 1)
            {
                _currentTenantService.BranchId = allowedBranches[0].Id;
                _currentTenantService.BranchName = allowedBranches[0].BranchName;
            }
            else
            {
                long rememberedBranchId = appConfigService.GetLastBranchId();
                var rememberedBranch = allowedBranches.FirstOrDefault(b => b.Id == rememberedBranchId);

                if (rememberedBranch != null)
                {
                    _currentTenantService.BranchId = rememberedBranch.Id;
                    _currentTenantService.BranchName = rememberedBranch.BranchName;
                }
                else
                {
                    using (var frm = new SubeSecimForm(allowedBranches))
                    {
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            _currentTenantService.BranchId = frm.SeciliSubeId;
                            _currentTenantService.BranchName = frm.SeciliSubeAdi;

                            if (frm.SecimiHatirla)
                            {
                                appConfigService.SetLastBranchId(frm.SeciliSubeId);
                            }
                        }
                        else
                        {
                            _programiOtomatikKapat = true;
                            System.Windows.Forms.Application.Exit();
                            return;
                        }
                    }
                }
            }

            this.Text = $"İtimat ERP --- Bilgisayar: {Environment.MachineName} | Şirket: {_currentTenantService.TenantName} | Fabrika: {_currentTenantService.BranchName}";

            // Sistemin açılışını kitlemeden arkadan kontrol işlemi başlatalım
            _ = Task.Run(async () => await EksikSablonlariKontrolEtAsync());
        }

        private async Task EksikSablonlariKontrolEtAsync()
        {
            try
            {
                var requiredModules = Enum.GetValues(typeof(WinBeyazEsya.Domain.Enums.ModuleType))
                    .Cast<WinBeyazEsya.Domain.Enums.ModuleType>()
                    .Where(m =>
                    {
                        var field = typeof(WinBeyazEsya.Domain.Enums.ModuleType).GetField(m.ToString());
                        return field != null && Attribute.IsDefined(field, typeof(WinBeyazEsya.Domain.Attributes.RequiresCodeTemplateAttribute));
                    })
                    .ToArray();

                using var scope = _serviceProvider.CreateScope();
                var sablonRepo = scope.ServiceProvider.GetService<WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.Management.CodeTemplate>>();

                if (sablonRepo == null) return;

                var missingModules = new System.Collections.Generic.List<string>();

                foreach (var module in requiredModules)
                {
                    var hasTemplate = System.Linq.Enumerable.Any(sablonRepo.Find(x => x.Module == module && !x.IsDeleted));
                    if (!hasTemplate)
                    {
                        var field = typeof(WinBeyazEsya.Domain.Enums.ModuleType).GetField(module.ToString());
                        var attr = (System.ComponentModel.DescriptionAttribute?)Attribute.GetCustomAttribute(field!, typeof(System.ComponentModel.DescriptionAttribute));
                        string desc = attr != null ? attr.Description : module.ToString();

                        missingModules.Add(desc);
                    }
                }

                if (missingModules.Count > 0)
                {
                    int totalMissing = missingModules.Count;
                    var displayList = missingModules.Take(2).ToList();

                    string moduleList = string.Join("\n- ", displayList);
                    string countMsg = totalMissing > 2 ? $"\n... ve {totalMissing - 2} modül daha eksik." : "";

                    string msg = $"Sistemin standartlara uygun çalışması için aşağıdaki modüllerin Kod Şablonları eksiktir:\n\n- {moduleList}{countMsg}\n\nLütfen Sistem Yönetimi'nden tanımlayınız.";

                    this.BeginInvoke(new Action(() =>
                    {
                        XtraMessageBox.Show(this, msg, "Eksik Kod Şablonları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
            }
            catch (Exception)
            {
            }
        }

        #region MDI Yöneticisi ve Form Açıcı

        /// <summary>
        /// Sadece DI (IServiceProvider) üzerinden belirtilen T tipindeki formu MDI Child olarak açar veya öne getirir.
        /// Eski switch/case ve ModulTuru bağımlılığı kaldırılmıştır.
        /// </summary>
        private void FormYukle<T>() where T : XtraForm
        {
            // Önce sekme açık mı diye kontrol et
            foreach (Form form in MdiChildren)
            {
                if (form is T existingForm)
                {
                    xtraTabbedMdiManager.SelectedPage = xtraTabbedMdiManager.Pages[existingForm];
                    existingForm.Activate();
                    return;
                }
            }

                        // Açıksa öne getirir, değilse yeni bir IServiceScope oluşturup formu oradan çözer (Scoped DI isolation)
            try
            {
                var scopeFactory = _serviceProvider.GetRequiredService<Microsoft.Extensions.DependencyInjection.IServiceScopeFactory>();
                var scope = scopeFactory.CreateScope();
                
                var newForm = scope.ServiceProvider.GetRequiredService<T>();
                newForm.MdiParent = this;
                
                // Form kapandığında scope'u dispose et ki DbContext'ler bellekten temizlensin
                newForm.FormClosed += (s, e) => scope.Dispose();
                
                newForm.Show();
            }
            catch (Exception ex)
            {
                Messages.HataBasligi($"Form yüklenirken hata oluştu. Lütfen formun DI konteynerine (AddTransient) eklendiğinden emin olun.\n\nDetay: {ex.Message}", "DI Çözümleme Hatası");
            }
        }

        private void XtraTabbedMdiManager_PageRemoved(object? sender, MdiTabPageEventArgs e)
        {
            if (((XtraTabbedMdiManager)sender).Pages.Count == 0)
            {
                // MDI sekmesi kalmadığında arka plandaki resim/logo gösterilebilir
                if (btnAnaFormResim != null) btnAnaFormResim.Visible = true;
            }
        }

        private void XtraTabbedMdiManager_PageAdded(object? sender, MdiTabPageEventArgs e)
        {
            if (btnAnaFormResim != null) btnAnaFormResim.Visible = false;
        }

        #endregion

        #region Buton Olayları (Geçici Test Olarak Bırakılanlar)

        private void miGenelParametreler_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.GenelParametreler, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.GenelParametrelerEditForm>();
                form.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miSirketTanimlari_Click(object? sender, EventArgs e)
        {
            FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.SirketForms.SirketListForm>();
        }

        private void miBirimTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.BirimTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miKurTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.KurTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KurlarForms.KurListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miKdvOranlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.KdvOranlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                // Parametre geçmek için ActivatorUtilities kullanıp yeni form oluşturup öne getireceğiz
                var form = ActivatorUtilities.CreateInstance<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.VergiForms.VergiOraniListForm>(_serviceProvider, WinBeyazEsya.Domain.Enums.TaxType.Kdv);
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miOtvOranlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.OtvOranlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                var form = ActivatorUtilities.CreateInstance<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.VergiForms.VergiOraniListForm>(_serviceProvider, WinBeyazEsya.Domain.Enums.TaxType.Otv);
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miCodeTemplatelari_Click(object? sender, EventArgs e)
        {
            FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.CodeTemplateForms.CodeTemplateListForm>();
        }

        private void miYetkiGruplariRoller_Click(object? sender, EventArgs e)
        {
            FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.YetkilendirmeForms.RolListForm>();
        }

        private void KullaniciTanimlari_Click(object? sender, EventArgs e)
        {
            FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.KullaniciForms.KullaniciListForm>();
        }

        private void miTerminalYonetim_Click(object? sender, EventArgs e)
        {
            FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TerminalForms.TerminalListForm>();
        }



        private void miKaliteStandartTanimlari_Click(object? sender, EventArgs e)
        {
            FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.KaliteStandartForms.KaliteStandartListForm>();
        }

        private void miYuzeyTipiTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.YuzeyTipiTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.YuzeyTipiForms.YuzeyTipiListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnMusteriCariKartlar_Click(object? sender, EventArgs e)
        {
            // TODO: İleride MusteriCariListForm yazılıp DI'a eklendiğinde alttaki kod aktif edilecek:
            // FormYukle<MusteriCariListForm>();
            Messages.BilgiBasligi("Müşteri Cari Kartları formuna yönlendirme eklenecek.", "Bilgi");
        }

        private void BtnProgramGuncelle_Click(object? sender, EventArgs e)
        {
            Messages.BilgiBasligi("Güncelleme sistemi (Update.exe) WinBeyazEsya altyapısına göre yeniden yazılacaktır.", "Bilgi");
        }

        public async void FabrikaDegistir()
        {
            var appConfigService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Configuration.IAppConfigService>();
            appConfigService.SetLastBranchId(0); // RememberedBranchId'yi sıfırla

            // Tüm sekmeleri kapat
            foreach (Form form in MdiChildren)
            {
                form.Close();
            }

            // Yeniden şube seçimi yapılması için Shown olayındaki mantığı tetikleyelim
            var authService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            var allowedBranches = await authService.GetAllowedBranchesAsync(_currentTenantService.UserId, _currentTenantService.TenantId);

            if (allowedBranches != null && allowedBranches.Count > 1)
            {
                using (var frm = new SubeSecimForm(allowedBranches))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        _currentTenantService.BranchId = frm.SeciliSubeId;
                        _currentTenantService.BranchName = frm.SeciliSubeAdi;

                        if (frm.SecimiHatirla)
                        {
                            appConfigService.SetLastBranchId(frm.SeciliSubeId);
                        }

                        this.Text = $"İtimat ERP | Şirket: {_currentTenantService.TenantName} | Fabrika: {_currentTenantService.BranchName}";
                    }
                }
            }
            else
            {
                Messages.BilgiBasligi("Geçiş yapabileceğiniz başka bir fabrika/şube yetkiniz bulunmamaktadır.", "Bilgi");
            }
        }

        #endregion

        #region Temizlenen ve Yorum Satırına Alınan Eski İş Mantıkları (EF Core, BLL vb.)

        /*
        private async Task OnaylanmamisKayitlariKontrolEtAsync()
        {
            // CRITICAL: Form katmanı EF Core'u bilmemeli! 
            // using (var context = new WinRezistansContext()) { ... } kalıntıları Application'da IOnayService'e taşınacak.
        }

        private async Task AylikMetreBilgisiGetirAsync()
        {
             // CRITICAL: Direkt EF SQL veya BLL kullanımı yasak!
             // using (var context = new WinRezistansContext())
             // {
             //     var result = await context.Database.SqlQuery<DateTime>("SELECT GETDATE()").FirstOrDefaultAsync();
             // }
        }

        private void BaslatUpdateExe()
        {
            // ... Eski güncelleme işlemi ...
        }
        */

        private void MiTermostatTanimlari_Click(object sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TermostatTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TermostatForms.TermostatListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MiTimerTanimlari_Click(object sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TimerTanimlari, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TimerForms.TimerListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}




