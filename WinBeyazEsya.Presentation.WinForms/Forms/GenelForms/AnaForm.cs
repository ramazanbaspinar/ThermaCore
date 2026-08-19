using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.System; // ICurrentTenantService ve ISessionService için
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.GenelForms
{
    public partial class AnaForm : XtraForm
    {
        private bool _programiOtomatikKapat = false;
        private string _currencyInfo = "Yükleniyor...";
        private System.Windows.Forms.Timer _clockTimer;
        private DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle _overlayHandle = null;
        // DI Konteynerinden Gelecek Servisler
        private readonly IServiceProvider _serviceProvider;
        private readonly ICurrentTenantService _currentTenantService;
        private readonly ISessionService _sessionService;
        private UserControls.MasaustuUserControl _masaustuControl;

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
            InitializeMasaustuControl();
        }

        private void EventsLoad()
        {
            Load += AnaForm_Load;
            Shown += AnaForm_Shown;
            FormClosing += AnaForm_FormClosing;
            KeyDown += Control_KeyDown;

            _clockTimer = new System.Windows.Forms.Timer();
            _clockTimer.Interval = 1000;
            _clockTimer.Tick += (s, e) =>
            {
                // Bağlantı koptuğunda (overlay aktifken) saat güncellemesini durdur
                // yoksa "Bağlantı Koptu" yazısını her saniye ezer
                if (_overlayHandle != null) return;

                if (barTrhSaatBilgisi != null)
                    barTrhSaatBilgisi.Caption = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}";

                if (barDovizBilgi != null)
                    barDovizBilgi.Caption = $"Döviz: {_currencyInfo}";
            };
            _clockTimer.Start();

            if (aceBirimTanimlari != null) aceBirimTanimlari.Click += miBirimTanimlari_Click;
            if (aceKurTanimlari != null) aceKurTanimlari.Click += miKurTanimlari_Click;
            if (aceKdvOranlari != null) aceKdvOranlari.Click += miKdvOranlari_Click;
            if (aceOtvOranlari != null) aceOtvOranlari.Click += miOtvOranlari_Click;
            if (aceMetalVeSacGrubuTanimlari != null) aceMetalVeSacGrubuTanimlari.Click += miMetalVeSacGrubuTanimlari_Click;
            if (aceElektrikVeElektronikGrubuTanimlari != null) aceElektrikVeElektronikGrubuTanimlari.Click += miElektrikVeElektronikGrubuTanimlari_Click;
            if (aceGazVeAteslemeGrubuTanimlari != null) aceGazVeAteslemeGrubuTanimlari.Click += miGazveAteslemeGrubuTanimlari_Click;
            if (acePlastikVeGorselAksamGrubuTanimlari != null) acePlastikVeGorselAksamGrubuTanimlari.Click += miPlastikVeGorselAksamGrubuTanimlari_Click;
            if (aceKimyaVeYalitimGrubuTanimlari != null) aceKimyaVeYalitimGrubuTanimlari.Click += miKimyaVeYalitimGrubuTanimlari_Click;
            if (aceMekanikVeHirdavatGrubuTanimlari != null) aceMekanikVeHirdavatGrubuTanimlari.Click += miMekanikVeHirdavatGrubuTanimlari_Click;
            if (aceAmbalajVeMatbaaGrubuTanimlari != null) aceAmbalajVeMatbaaGrubuTanimlari.Click += miAmbalajVeMatbaaGrubuTanimlari_Click;
            if (aceTelVeIzgaraGrubuTanimlari != null) aceTelVeIzgaraGrubuTanimlari.Click += miTelVeIzgaraGrubuTanimlari_Click;
            if (aceDigerMalzemeGrubuTanimlari != null) aceDigerMalzemeGrubuTanimlari.Click += miDigerMalzemeGrubuTanimlari_Click;
            if (aceSirketTanimlari != null) aceSirketTanimlari.Click += miSirketTanimlari_Click;
            if (aceUrunMamulTanimlari != null)
                aceUrunMamulTanimlari.Click += (s, e) =>
                {
                    FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MamulForms.MamulListForm>();
                };
            if (aceUrunMamulReceteleri != null)
                aceUrunMamulReceteleri.Click += (s, e) =>
                {
                    FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.UretimForms.UrunReceteListForm>();
                };
            if (aceDepoTanimlari != null)
                aceDepoTanimlari.Click += (s, e) =>
                {
                    FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DepoTanimForms.DepoTanimListForm>();
                };
            if (aceKullaniciTanimlari != null) aceKullaniciTanimlari.Click += KullaniciTanimlari_Click;
            if (aceYetkiGruplariRoller != null) aceYetkiGruplariRoller.Click += miYetkiGruplariRoller_Click;
            if (aceTerminalCihazYonetimi != null) aceTerminalCihazYonetimi.Click += miTerminalYonetim_Click;
            if (aceParolaDegistir != null) aceParolaDegistir.Click += aceParolaDegistir_Click;
            if (btnFabrikaDegistir != null) btnFabrikaDegistir.ItemClick += btnFabrikaDegistir_ItemClick;
            if (aceKodSablonlari != null) aceKodSablonlari.Click += miCodeTemplatelari_Click;
            if (aceGenelParametreler != null) aceGenelParametreler.Click += miGenelParametreler_Click;

            if (aceKullaniciArayuzSablonlari != null)
                aceKullaniciArayuzSablonlari.Click += (s, e) =>
                {
                    FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.KullanıcıArayuzSablonlariListForm>();
                };

            if (aceGenelGiderler != null)
                aceGenelGiderler.Click += (s, e) =>
                {
                    FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GenelGiderForms.GenelGiderListForm>();
                };

            if (aceMaliyetParametreleri != null)
                aceMaliyetParametreleri.Click += (s, e) =>
                {
                    var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MaliyetParametreForms.MaliyetParametreEditForm>();
                    form.ShowDialog();
                };
            if (aceElektrikVeElektronikGrubuMaliyetleri != null)
                aceElektrikVeElektronikGrubuMaliyetleri.Click += miElektrikVeElektronikGrubuMaliyetleri_Click;
            if (aceMetalVeSacGrubuMaliyetleri != null)
                aceMetalVeSacGrubuMaliyetleri.Click += miMetalVeSacGrubuMaliyetleri_Click;
            if (aceGazVeAteslemeGrubuMaliyetleri != null)
                aceGazVeAteslemeGrubuMaliyetleri.Click += miGazVeAteslemeGrubuMaliyetleri_Click;
            if (acePlastikVeGorselAksamGrubuMaliyetleri != null)
                acePlastikVeGorselAksamGrubuMaliyetleri.Click += miPlastikVeGorselAksamGrubuMaliyetleri_Click;
            if (aceKimyaVeYalitimGrubuMaliyetleri != null)
                aceKimyaVeYalitimGrubuMaliyetleri.Click += miKimyaVeYalitimGrubuMaliyetleri_Click;
            if (aceMekanikVeHirdavatGrubuMaliyetleri != null)
                aceMekanikVeHirdavatGrubuMaliyetleri.Click += miMekanikVeHirdavatGrubuMaliyetleri_Click;
            if (aceAmbalajVeMatbaaGrubuMaliyetleri != null)
                aceAmbalajVeMatbaaGrubuMaliyetleri.Click += miAmbalajVeMatbaaGrubuMaliyetleri_Click;
            if (aceTelVeIzgaraGrubuMaliyetleri != null)
                aceTelVeIzgaraGrubuMaliyetleri.Click += miTelVeIzgaraGrubuMaliyetleri_Click;
            if (aceDigerMalzemeGrubuMaliyetleri != null)
                aceDigerMalzemeGrubuMaliyetleri.Click += miDigerMalzemeGrubuMaliyetleri_Click;

            if (aceEmailParametreleri != null)
                aceEmailParametreleri.Click += (s, e) =>
                {
                    var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.EmailParameterEditForm>();
                    form.ShowDialog();
                };
            if (aceLisansBilgileri != null)
                aceLisansBilgileri.Click += (s, e) =>
                {
                    var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.LisansBilgileriEditForm>();
                    form.ShowDialog();
                };

            if (miEmailParameter != null)
                miEmailParameter.Click += (s, e) =>
                {
                    var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.EmailParameterEditForm>();
                    form.ShowDialog();
                };

            if (miSystemLicense != null)
                miSystemLicense.Click += (s, e) =>
                {
                    var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.LisansBilgileriEditForm>();
                    form.ShowDialog();
                };

            // Dinamik Yükleme Click Eventleri
            if (miGenelParametreler != null)
                miGenelParametreler.Click += miGenelParametreler_Click;

            if (aceUlkeTanimlari != null)
                aceUlkeTanimlari.Click += (s, e) => FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.UlkeTanimForm.UlkeTanimListForm>();

            if (aceCariTanimlari != null)
                aceCariTanimlari.Click += (s, e) => FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CariTanimForms.CariTanimListForm>();

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
                    FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms.KullanıcıArayuzSablonlariListForm>();
                };

            if (miCodeTemplatelari != null)
                miCodeTemplatelari.Click += miCodeTemplatelari_Click;

            if (miYetkiGruplariRoller != null)
                miYetkiGruplariRoller.Click += miYetkiGruplariRoller_Click;

            if (miKullaniciTanimlari != null)
                miKullaniciTanimlari.Click += KullaniciTanimlari_Click;

            if (miTerminalYonetim != null)
                miTerminalYonetim.Click += miTerminalYonetim_Click;

            if (xtraTabbedMdiManager != null)
            {
                xtraTabbedMdiManager.PageAdded += XtraTabbedMdiManager_PageAdded;
                xtraTabbedMdiManager.PageRemoved += XtraTabbedMdiManager_PageRemoved;
            }

            foreach (Control control in Controls)
                control.KeyDown += Control_KeyDown;
        }

        /// <summary>
        /// Masaüstü Dashboard kontrolünü oluşturur ve AnaForm'a ekler.
        /// btnAnaFormResim'in üzerinde, Dock=Fill olarak konumlanır.
        /// Tile tıklamaları mevcut FormYukle&lt;T&gt;() reflection mekanizmasını kullanır.
        /// </summary>
        private void InitializeMasaustuControl()
        {
            _masaustuControl = new UserControls.MasaustuUserControl();
            _masaustuControl.Dock = DockStyle.Fill;

            // Tile tıklandığında formu aç — LoadFavorites'daki reflection pattern ile aynı
            _masaustuControl.OnFavoriteClicked = (formTypeFullName) =>
            {
                Type? type = Type.GetType(formTypeFullName);
                if (type != null)
                {
                    var method = this.GetType().GetMethod("FormYukle",
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (method != null)
                    {
                        var genericMethod = method.MakeGenericMethod(type);
                        genericMethod.Invoke(this, null);
                    }
                }
            };

            // 🚨 Global Arama (Accordion) Entegrasyonu
            DevExpress.XtraEditors.SearchControl _dummyAccordionSearch = new DevExpress.XtraEditors.SearchControl();
            _dummyAccordionSearch.Client = accordionControl1;

            _masaustuControl.SearchTextChanged += (s, text) =>
            {
                if (accordionControl1 != null)
                {
                    _dummyAccordionSearch.Text = text;
                }
            };

            // Controls'a ekle ve Z-order'da btnAnaFormResim'in önüne getir
            this.Controls.Add(_masaustuControl);
            _masaustuControl.BringToFront();
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
                // Seçili firma ve kullanıcı bilgilerini bar başlıklarına (veya pencere başlığına) yazdır

                var scopeFactory = _serviceProvider.GetRequiredService<IServiceScopeFactory>();

                string currentConnString = _currentTenantService.ConnectionString;
                long currentTenantId = _currentTenantService.TenantId;
                string currentTenantName = _currentTenantService.TenantName;
                long currentUserId = _currentTenantService.UserId;

                var userService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Management.IUserService>();
                var currentUser = userService.GetById(currentUserId);
                string userFullName = currentUser != null ? $"{currentUser.FirstName} {currentUser.LastName}" : "Bilinmeyen Kullanıcı";

                this.Text = $"WinBeyazEsya ERP --- Bilgisayar: {Environment.MachineName} | Kullanıcı: {userFullName} | Şirket: {currentTenantName} | Fabrika: {_currentTenantService.BranchName}";

                _ = StartHeartbeatAsync();

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
                                // Günceliz! Sürüm notları daha önce gösterilmediyse göster (kullanıcı bazlı)
                                var appConfigService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Configuration.IAppConfigService>();
                                string lastSeenVersion = appConfigService?.GetLastSeenVersion() ?? "";

                                if (lastSeenVersion != currentVersion && manifest.ReleaseNotes != null && manifest.ReleaseNotes.Count > 0)
                                {
                                    this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                                    {
                                        using (var notesForm = new WinBeyazEsya.Presentation.WinForms.Forms.GenelForms.SurumNotlariForm(manifest.Version, manifest.ReleaseNotes))
                                        {
                                            notesForm.ShowDialog(this);
                                        }

                                        // Kullanıcı ayarına mevcut versiyonu kaydet
                                        try
                                        {
                                            appConfigService?.SetLastSeenVersion(currentVersion);
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
                                _currencyInfo = $"USD: {usdRate.EffectiveSellingRate:F4} - EUR: {eurRate.EffectiveSellingRate:F4}{kurTarihiEk}";
                            }
                            else
                            {
                                _currencyInfo = "Kur Bilgisi Alınamadı";
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[AnaForm] TCMB Kurları arka plan senkronizasyon hatası: {ex.Message}");
                        this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                        {
                            _currencyInfo = "Bağlantı Hatası: Kurlar Alınamadı";
                        });
                    }
                });

                // TODO: OnaylanmamisKayitlariKontrolEtAsync(); (İş kuralları Application katmanına taşınacak)
                // TODO: AylikMetreBilgisiGetirAsync(); (EF Core sorguları Application katmanına taşınacak)

                SetMenuTags();
                ApplyAccordionPermissions();
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Hata");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                LoadFavorites();
            }
        }

        private void SetMenuTags()
        {
            aceAyarlar.Tag = WinBeyazEsya.Domain.Enums.ModuleType.Ayarlar;
            aceTanimlar.Tag = WinBeyazEsya.Domain.Enums.ModuleType.Tanimlar;
            aceMaliyet.Tag = WinBeyazEsya.Domain.Enums.ModuleType.Maliyetler;

            aceKurumsalTanimlar.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KurumsalTanimlar;
            aceGuvenlikVeYetkilendirme.Tag = WinBeyazEsya.Domain.Enums.ModuleType.GuvenlikVeYetkilendirme;
            aceParametreler.Tag = WinBeyazEsya.Domain.Enums.ModuleType.Parametreler;
            aceTemelTanimlar.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TemelTanimlar;

            aceSirketTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.SirketTanimlari;

            if (aceUlkeTanimlari != null) aceUlkeTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.Country;
            if (aceCariTanimlari != null) aceCariTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.CurrentAccount;
            if (aceDepoTanimlari != null) aceDepoTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.Warehouse;

            aceYetkiGruplariRoller.Tag = WinBeyazEsya.Domain.Enums.ModuleType.YetkiGruplari;
            aceKullaniciTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.User;
            aceTerminalCihazYonetimi.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TerminalYonetimi;

            aceKullaniciArayuzSablonlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.UserInterfaceTemplate;
            aceKodSablonlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.CodeTemplateYonetimi;
            aceEmailParametreleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.EmailParameter;
            aceLisansBilgileri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.SystemLicense;
            aceGenelParametreler.Tag = WinBeyazEsya.Domain.Enums.ModuleType.GenelParametreler;

            aceBirimTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.BirimTanimlari;
            aceKurTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KurTanimlari;
            aceKdvOranlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KdvOranlari;
            aceOtvOranlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.OtvOranlari;

            if (aceUrunMamulTanimlari != null) aceUrunMamulTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.FinishedGood;
            if (aceUrunMamulReceteleri != null) aceUrunMamulReceteleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.ProductRecipe;
            aceMetalVeSacGrubuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MetalVeSacGrubu;
            aceElektrikVeElektronikGrubuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.ElektrikVeElektronikGrubu;
            aceGazVeAteslemeGrubuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.GazveAteslemeGrubu;
            if (acePlastikVeGorselAksamGrubuTanimlari != null) acePlastikVeGorselAksamGrubuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.PlastikVeGorselAksamGrubu;
            if (aceKimyaVeYalitimGrubuTanimlari != null) aceKimyaVeYalitimGrubuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KimyaVeYalitimGrubu;
            if (aceMekanikVeHirdavatGrubuTanimlari != null) aceMekanikVeHirdavatGrubuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MekanikVeHirdavatGrubu;
            if (aceAmbalajVeMatbaaGrubuTanimlari != null) aceAmbalajVeMatbaaGrubuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.AmbalajVeMatbaaGrubu;
            if (aceTelVeIzgaraGrubuTanimlari != null) aceTelVeIzgaraGrubuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TelVeIzgaraGrubu;
            if (aceDigerMalzemeGrubuTanimlari != null) aceDigerMalzemeGrubuTanimlari.Tag = WinBeyazEsya.Domain.Enums.ModuleType.DigerMalzemeGrubu;

            if (aceGenelGiderler != null) aceGenelGiderler.Tag = WinBeyazEsya.Domain.Enums.ModuleType.GenelGiderler;
            if (aceMaliyetParametreleri != null) aceMaliyetParametreleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MaliyetParametreleri;
            if (aceElektrikVeElektronikGrubuMaliyetleri != null) aceElektrikVeElektronikGrubuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.ElektrikVeElektronikGrubuMaliyetleri;
            if (aceMetalVeSacGrubuMaliyetleri != null) aceMetalVeSacGrubuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MetalVeSacGrubuMaliyetleri;
            if (aceGazVeAteslemeGrubuMaliyetleri != null) aceGazVeAteslemeGrubuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.GazVeAteslemeGrubuMaliyetleri;
            if (acePlastikVeGorselAksamGrubuMaliyetleri != null) acePlastikVeGorselAksamGrubuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.PlastikVeGorselAksamGrubuMaliyetleri;
            if (aceKimyaVeYalitimGrubuMaliyetleri != null) aceKimyaVeYalitimGrubuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.KimyaVeYalitimGrubuMaliyetleri;
            if (aceMekanikVeHirdavatGrubuMaliyetleri != null) aceMekanikVeHirdavatGrubuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.MekanikVeHirdavatGrubuMaliyetleri;
            if (aceAmbalajVeMatbaaGrubuMaliyetleri != null) aceAmbalajVeMatbaaGrubuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.AmbalajVeMatbaaGrubuMaliyetleri;
            if (aceTelVeIzgaraGrubuMaliyetleri != null) aceTelVeIzgaraGrubuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.TelVeIzgaraGrubuMaliyetleri;
            if (aceDigerMalzemeGrubuMaliyetleri != null) aceDigerMalzemeGrubuMaliyetleri.Tag = WinBeyazEsya.Domain.Enums.ModuleType.DigerMalzemeGrubuMaliyetleri;
        }

        private void ApplyAccordionPermissions()
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService == null) return;

            var userRepo = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.Management.User>>();
            var user = userRepo?.GetById(_currentTenantService.UserId);
            bool isSuperAdmin = user != null && (user.Code.ToLower() == "winbeyazesya");

            ApplyAccordionPermissionsRecursive(accordionControl1.Elements, authService, isSuperAdmin);
        }

        private void ApplyAccordionPermissionsRecursive(DevExpress.XtraBars.Navigation.AccordionControlElementCollection elements, WinBeyazEsya.Application.Services.Management.IAuthService authService, bool isSuperAdmin)
        {
            foreach (DevExpress.XtraBars.Navigation.AccordionControlElement element in elements)
            {
                if (isSuperAdmin)
                {
                    element.Visible = true;
                    if (element.Elements.Count > 0)
                    {
                        ApplyAccordionPermissionsRecursive(element.Elements, authService, isSuperAdmin);
                    }
                    continue;
                }

                bool hasVisibleChildren = false;

                if (element.Elements.Count > 0)
                {
                    ApplyAccordionPermissionsRecursive(element.Elements, authService, isSuperAdmin);

                    foreach (DevExpress.XtraBars.Navigation.AccordionControlElement child in element.Elements)
                    {
                        if (child.Visible)
                        {
                            hasVisibleChildren = true;
                            break;
                        }
                    }
                }

                if (element.Elements.Count > 0)
                {
                    // Klasörse, içi doluysa göster
                    element.Visible = hasVisibleChildren;
                }
                else if (element.Tag is WinBeyazEsya.Domain.Enums.ModuleType moduleType)
                {
                    bool hasAccess = authService.HasPermission(moduleType, WinBeyazEsya.Domain.Enums.PermissionType.CanView);
                    element.Visible = hasAccess;
                }
                else if (element.Tag is string tagStr)
                {
                    if (Enum.TryParse(tagStr.Trim(), true, out WinBeyazEsya.Domain.Enums.ModuleType parsedModuleType))
                    {
                        bool hasAccess = authService.HasPermission(parsedModuleType, WinBeyazEsya.Domain.Enums.PermissionType.CanView);
                        element.Visible = hasAccess;
                    }
                    else
                    {
                        element.Visible = true;
                    }
                }
                else
                {
                    element.Visible = true; // Favoriler vs.
                }
            }
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
                bool askBranchAtStartup = appConfigService.GetAskBranchAtStartup();
                var rememberedBranch = allowedBranches.FirstOrDefault(b => b.Id == rememberedBranchId);

                if (!askBranchAtStartup && rememberedBranch != null)
                {
                    _currentTenantService.BranchId = rememberedBranch.Id;
                    _currentTenantService.BranchName = rememberedBranch.BranchName;
                }
                else
                {
                    using (var frm = new SubeSecimForm(allowedBranches, rememberedBranchId, askBranchAtStartup))
                    {
                        if (frm.ShowDialog(this) == DialogResult.OK)
                        {
                            _currentTenantService.BranchId = frm.SeciliSubeId;
                            _currentTenantService.BranchName = frm.SeciliSubeAdi;

                            if (frm.VarsayilanYap)
                            {
                                appConfigService.SetLastBranchId(frm.SeciliSubeId);
                            }
                            else
                            {
                                appConfigService.SetLastBranchId(0);
                            }

                            appConfigService.SetAskBranchAtStartup(frm.AcilistaSor);
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

            var userService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Management.IUserService>();
            var currentUser = userService.GetById(_currentTenantService.UserId);
            string userFullName = currentUser != null ? $"{currentUser.FirstName} {currentUser.LastName}" : "Bilinmeyen Kullanıcı";
            this.Text = $"WinBeyazEsya ERP --- Bilgisayar: {Environment.MachineName} | Kullanıcı: {userFullName} | Şirket: {_currentTenantService.TenantName} | Fabrika: {_currentTenantService.BranchName}";

            if (allowedBranches != null && allowedBranches.Count > 1)
            {
                if (btnFabrikaDegistir != null)
                {
                    btnFabrikaDegistir.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnFabrikaDegistir.Caption = $"🏢 Aktif Fabrika: {_currentTenantService.BranchName} [Değiştir]";
                }
            }
            else
            {
                if (btnFabrikaDegistir != null)
                {
                    btnFabrikaDegistir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }

            // Sistemin açılışını kitlemeden arkadan kontrol işlemi başlatalım
            _ = Task.Run(async () => await EksikSablonlariKontrolEtAsync());
        }

        private async void btnFabrikaDegistir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var authService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            var allowedBranches = await authService.GetAllowedBranchesAsync(_currentTenantService.UserId, _currentTenantService.TenantId);

            if (allowedBranches != null && allowedBranches.Count > 1)
            {
                var appConfigService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Configuration.IAppConfigService>();
                long rememberedBranchId = appConfigService.GetLastBranchId();
                bool askBranchAtStartup = appConfigService.GetAskBranchAtStartup();

                using (var frm = new SubeSecimForm(allowedBranches, rememberedBranchId, askBranchAtStartup))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        // Ayarları güncelle
                        if (frm.VarsayilanYap)
                        {
                            appConfigService.SetLastBranchId(frm.SeciliSubeId);
                        }
                        else
                        {
                            appConfigService.SetLastBranchId(0);
                        }
                        appConfigService.SetAskBranchAtStartup(frm.AcilistaSor);

                        // GÜVENLİK KURALI: O anki açık olan tüm MDI formlarını kapat
                        foreach (System.Windows.Forms.Form child in this.MdiChildren)
                        {
                            child.Close();
                        }

                        // Servisi yeni fabrikaya göre güncelle
                        _currentTenantService.BranchId = frm.SeciliSubeId;
                        _currentTenantService.BranchName = frm.SeciliSubeAdi;

                        // Bar üzerindeki yazıyı güncelle
                        btnFabrikaDegistir.Caption = $"🏢 Aktif Fabrika: {frm.SeciliSubeAdi} [Değiştir]";
                        var userService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Management.IUserService>();
                        var currentUser = userService.GetById(_currentTenantService.UserId);
                        string userFullName = currentUser != null ? $"{currentUser.FirstName} {currentUser.LastName}" : "Bilinmeyen Kullanıcı";
                        this.Text = $"WinBeyazEsya ERP --- Bilgisayar: {Environment.MachineName} | Kullanıcı: {userFullName} | Şirket: {_currentTenantService.TenantName} | Fabrika: {_currentTenantService.BranchName}";
                    }
                }
            }
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
                // MDI sekmesi kalmadığında arka plan ve masaüstü ekranını göster
                if (btnAnaFormResim != null) btnAnaFormResim.Visible = true;

                if (_masaustuControl != null)
                {
                    _masaustuControl.Visible = true;
                    _masaustuControl.BringToFront();
                    // Formlar açıkken değişmiş olabilecek favorileri yenile
                    LoadFavorites();
                }
            }
        }

        private void XtraTabbedMdiManager_PageAdded(object? sender, MdiTabPageEventArgs e)
        {
            if (btnAnaFormResim != null) btnAnaFormResim.Visible = false;
            if (_masaustuControl != null) _masaustuControl.Visible = false;
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


        public void LoadFavorites()
        {
            if (_serviceProvider == null || aceFavoriler == null) return;

            var favoriteService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Management.IUserFavoriteService>();
            if (favoriteService == null) return;

            aceFavoriler.Elements.Clear();
            var favorites = favoriteService.GetUserFavorites(_currentTenantService.UserId);

            foreach (var fav in favorites)
            {
                var el = new DevExpress.XtraBars.Navigation.AccordionControlElement();
                el.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
                el.Text = fav.FormCaption;
                el.Tag = fav.FormTypeFullName;

                el.Click += (s, e) =>
                {
                    Type? type = Type.GetType(fav.FormTypeFullName);
                    if (type != null)
                    {
                        var method = this.GetType().GetMethod("FormYukle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        if (method != null)
                        {
                            var genericMethod = method.MakeGenericMethod(type);
                            genericMethod.Invoke(this, null);
                        }
                        else
                        {
                            method = this.GetType().GetMethod("FormYukle", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                            if (method != null)
                            {
                                var genericMethod = method.MakeGenericMethod(type);
                                genericMethod.Invoke(this, null);
                            }
                        }
                    }
                };
                aceFavoriler.Elements.Add(el);
            }

            // Masaüstü TileControl'ünü de güncelle (accordion ile senkron)
            _masaustuControl?.LoadFavorites(favorites);
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

        private void miMetalVeSacGrubuTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MetalVeSacGrubu, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MetalVeSacGrubuForms.MetalVeSacGrubuListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miElektrikVeElektronikGrubuTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.ElektrikVeElektronikGrubu, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ElektrikVeElektronikGrubuForms.ElektrikVeElektronikGrubuListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miElektrikVeElektronikGrubuMaliyetleri_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.ElektrikVeElektronikGrubuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.ElektrikVeElektronikGrubuMForms.ElektrikVeElektronikGrubuMListForm>();
            }
        }

        private void miMetalVeSacGrubuMaliyetleri_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MetalVeSacGrubuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MetalVeSacGrubuMForms.MetalVeSacGrubuMaliyetListForm>();
            }
        }

        private void miGazVeAteslemeGrubuMaliyetleri_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.GazVeAteslemeGrubuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.GazVeAteslemeGrubuMForms.GazVeAteslemeGrubuMListForm>();
            }
        }

        private void miPlastikVeGorselAksamGrubuMaliyetleri_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.PlastikVeGorselAksamGrubuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.PlastikVeGorselAksamGrubuMForms.PlastikVeGorselAksamGrubuMListForms>();
            }
        }

        private void miKimyaVeYalitimGrubuMaliyetleri_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.KimyaVeYalitimGrubuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.KimyaVeYalitimGrubuMForms.KimyaVeYalitimGrubuMListForm>();
            }
        }

        private void miMekanikVeHirdavatGrubuMaliyetleri_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MekanikVeHirdavatGrubuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MekanikVeHirdavatGrubuMForms.MekanikVeHirdavatGrubuMListForm>();
            }
        }

        private void miAmbalajVeMatbaaGrubuMaliyetleri_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.AmbalajVeMatbaaGrubuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.AmbalajVeMatbaaGrubuMForms.AmbalajVeMatbaaGrubuMListForm>();
            }
        }

        private void miTelVeIzgaraGrubuMaliyetleri_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TelVeIzgaraGrubuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.TelVeIzgaraGrubuMForms.TelVeIzgaraGrubuMListForm>();
            }
        }

        private void miDigerMalzemeGrubuMaliyetleri_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.DigerMalzemeGrubuMaliyetleri, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.DigerMalzemeGrubuMForms.DigerMalzemeGrubuMListForm>();
            }
        }

        private void miGazveAteslemeGrubuTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.GazveAteslemeGrubu, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.GazveAteslemeGrubuForms.GazveAteslemeGrubuListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miPlastikVeGorselAksamGrubuTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.PlastikVeGorselAksamGrubu, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PlastikVeGorselAksamGrubuForms.PlastikVeGorselAksamGrubuListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miKimyaVeYalitimGrubuTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.KimyaVeYalitimGrubu, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KimyaVeYalitimGrubuForms.KimyaVeYalitimGrubuListForm>();
            }
            else
            {
                Messages.YetkisizGirisMesaji();
            }
        }

        private void miMekanikVeHirdavatGrubuTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.MekanikVeHirdavatGrubu, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MekanikVeHirdavatGrubuForms.MekanikVeHirdavatGrubuListForm>();
            }
            else
            {
                Messages.YetkisizGirisMesaji();
            }
        }

        private void miAmbalajVeMatbaaGrubuTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.AmbalajVeMatbaaGrubu, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.AmbalajVeMatbaaGrubuForms.AmbalajVeMatbaaGrubuListForm>();
            }
            else
            {
                Messages.YetkisizGirisMesaji();
            }
        }

        private void miTelVeIzgaraGrubuTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.TelVeIzgaraGrubu, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TelVeIzgaraForms.TelVeIzgaraGrubuListForm>();
            }
            else
            {
                Messages.YetkisizGirisMesaji();
            }
        }

        private void miDigerMalzemeGrubuTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<WinBeyazEsya.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(WinBeyazEsya.Domain.Enums.ModuleType.DigerMalzemeGrubu, WinBeyazEsya.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DigerMalzemeGrubuForms.DigerMalzemeGrubuListForm>();
            }
            else
            {
                Messages.YetkisizGirisMesaji();
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
            FormYukle<WinBeyazEsya.Presentation.WinForms.Forms.CodeTemplateForms.KodSablonlariListForm>();
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

        private void aceParolaDegistir_Click(object? sender, EventArgs e)
        {
            var userService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Management.IUserService>();
            using (var form = new WinBeyazEsya.Presentation.WinForms.Forms.GenelForms.ParolaDegistirForm(userService, _currentTenantService.UserId))
            {
                form.ShowDialog(this);
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
                long rememberedBranchId = appConfigService.GetLastBranchId();
                bool askBranchAtStartup = appConfigService.GetAskBranchAtStartup();

                using (var frm = new SubeSecimForm(allowedBranches, rememberedBranchId, askBranchAtStartup))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        _currentTenantService.BranchId = frm.SeciliSubeId;
                        _currentTenantService.BranchName = frm.SeciliSubeAdi;

                        if (frm.VarsayilanYap)
                        {
                            appConfigService.SetLastBranchId(frm.SeciliSubeId);
                        }
                        else
                        {
                            appConfigService.SetLastBranchId(0);
                        }
                        appConfigService.SetAskBranchAtStartup(frm.AcilistaSor);

                        var userService = _serviceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Management.IUserService>();
                        var currentUser = userService.GetById(_currentTenantService.UserId);
                        string userFullName = currentUser != null ? $"{currentUser.FirstName} {currentUser.LastName}" : "Bilinmeyen Kullanıcı";
                        this.Text = $"WinBeyazEsya ERP --- Bilgisayar: {Environment.MachineName} | Kullanıcı: {userFullName} | Şirket: {_currentTenantService.TenantName} | Fabrika: {_currentTenantService.BranchName}";
                        if (btnFabrikaDegistir != null)
                        {
                            btnFabrikaDegistir.Caption = $"🏢 Aktif Fabrika: {_currentTenantService.BranchName} [Değiştir]";
                        }
                    }
                }
            }
            else
            {
                Messages.BilgiBasligi("Geçiş yapabileceğiniz başka bir fabrika/şube yetkiniz bulunmamaktadır.", "Bilgi");
            }
        }

        #endregion
        private async System.Threading.Tasks.Task StartHeartbeatAsync()
        {
            while (true)
            {
                await System.Threading.Tasks.Task.Delay(5000);

                if (IsDisposed || Disposing)
                    break;

                bool isConnected = false;
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var monitorService = scope.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.System.IConnectionMonitorService>();
                        isConnected = await monitorService.CheckConnectionAsync();
                    }
                }
                catch
                {
                    isConnected = false;
                }

                this.Invoke((System.Windows.Forms.MethodInvoker)delegate
                {
                    if (IsDisposed || Disposing) return;

                    if (!isConnected)
                    {
                        if (_overlayHandle == null)
                        {
                            var options = new DevExpress.XtraSplashScreen.OverlayWindowOptions(
                                startupDelay: 0,
                                customPainter: new CenteredTextOverlayPainter()
                            );
                            _overlayHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(this, options);
                        }

                        if (barTrhSaatBilgisi != null)
                        {
                            barTrhSaatBilgisi.Caption = "Bağlantı Koptu, Yeniden Deneniyor...";
                            barTrhSaatBilgisi.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        if (_overlayHandle != null)
                        {
                            DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(_overlayHandle);
                            _overlayHandle = null;
                        }

                        if (barTrhSaatBilgisi != null)
                        {
                            barTrhSaatBilgisi.Caption = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss}";
                            barTrhSaatBilgisi.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Empty;
                        }
                    }
                });
            }
        }
    }

    /// <summary>
    /// Bağlantı koptuğunda DevExpress'in varsayılan spinner animasyonunu KORUYARAK,
    /// altına profesyonel, ortalanmış ve renkli bir bilgilendirme metni çizer.
    /// </summary>
    class CenteredTextOverlayPainter : DevExpress.XtraSplashScreen.OverlayWindowPainterBase
    {
        protected override void Draw(DevExpress.XtraSplashScreen.OverlayWindowCustomDrawContext context)
        {
            // context.Handled = true; YAZMIYORUZ! DevExpress varsayılan animasyonu (spinner) kendisi çizsin.
            // Biz sadece üzerine sade ve kurumsal metnimizi ekliyoruz.

            var g = context.DrawArgs.Cache.Graphics;
            var bounds = context.DrawArgs.Bounds;

            string text = "Sunucu bağlantısı koptu...\nYeniden bağlanmaya çalışılıyor, lütfen bekleyiniz.";

            using (var font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular))
            using (var format = new System.Drawing.StringFormat())
            using (var brush = new System.Drawing.SolidBrush(System.Drawing.Color.White))
            {
                format.Alignment = System.Drawing.StringAlignment.Center;
                format.LineAlignment = System.Drawing.StringAlignment.Center;

                // Ekran merkezinin biraz altına (spinner'ın altına) kaydır
                var textBounds = bounds;
                textBounds.Y += 80;

                g.DrawString(text, font, brush, textBounds, format);
            }
        }
    }
}




