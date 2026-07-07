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
using ThermaCore.Application.Interfaces.System; // ICurrentTenantService ve ISessionService için
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
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
                    var form = _serviceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.ParametrelerForms.EmailParameterEditForm>();
                    form.ShowDialog();
                };
            
            if (miSystemLicense != null)
                miSystemLicense.Click += (s, e) => 
                {
                    var form = _serviceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.ParametrelerForms.SystemLicenseEditForm>();
                    form.ShowDialog();
                };
            
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
                    FormYukle<ThermaCore.Presentation.WinForms.Forms.ParametrelerForms.UserInterfaceTemplateListForm>();
                };

            if (miCodeTemplatelari != null)
                miCodeTemplatelari.Click += miCodeTemplatelari_Click;

            if (miYetkiGruplariRoller != null)
                miYetkiGruplariRoller.Click += miYetkiGruplariRoller_Click;
            
            if (miKullaniciTanimlari != null)
                miKullaniciTanimlari.Click += KullaniciTanimlari_Click;

            if (miTerminalYonetim != null)
                miTerminalYonetim.Click += miTerminalYonetim_Click;


                
            if (miKaliteStandartTanimlari != null)
            {
                miKaliteStandartTanimlari.Click += miKaliteStandartTanimlari_Click;
            }



            if (miSacTanimlari != null)
            {
                miSacTanimlari.Tag = ThermaCore.Domain.Enums.ModuleType.SacTanimlari;
                miSacTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.SacTanimlari, ThermaCore.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<ThermaCore.Presentation.WinForms.Forms.SacForms.SacListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miBoyaTanimlari != null)
            {
                miBoyaTanimlari.Tag = ThermaCore.Domain.Enums.ModuleType.BoyaTanimlari;
                miBoyaTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.BoyaTanimlari, ThermaCore.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<ThermaCore.Presentation.WinForms.Forms.BoyaForms.BoyaListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miEmayeTanimlari != null)
            {
                miEmayeTanimlari.Tag = ThermaCore.Domain.Enums.ModuleType.EmayeTanimlari;
                miEmayeTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.EmayeTanimlari, ThermaCore.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<ThermaCore.Presentation.WinForms.Forms.EmayeForms.EmayeListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }

            if (miVidaTanimlari != null)
            {
                miVidaTanimlari.Tag = ThermaCore.Domain.Enums.ModuleType.VidaTanimlari;
                miVidaTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.VidaTanimlari, ThermaCore.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<ThermaCore.Presentation.WinForms.Forms.VidaForms.VidaListForm>();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };
            }
            
            if (miRezistansTanimlari != null)
            {
                miRezistansTanimlari.Tag = ThermaCore.Domain.Enums.ModuleType.RezistansTanimlari;
                miRezistansTanimlari.Click += (s, e) =>
                {
                    var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
                    if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.RezistansTanimlari, ThermaCore.Domain.Enums.PermissionType.CanView))
                    {
                        FormYukle<ThermaCore.Presentation.WinForms.Forms.RezistansForms.RezistansListForm>();
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
            e.Cancel = true;

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
                    var repo = scope.ServiceProvider.GetRequiredService<ThermaCore.Application.Interfaces.Repositories.IMasterRepository<ThermaCore.Domain.Entities.System.UserSession>>();
                    var uow = scope.ServiceProvider.GetRequiredService<ThermaCore.Application.Interfaces.Repositories.IMasterUnitOfWork>();

                    var session = repo.Find(s => s.Id == Program.CurrentSessionId.Value).FirstOrDefault();
                    if (session != null)
                    {
                        session.LogoutTime = DateTime.Now;
                        session.Status = ThermaCore.Domain.Enums.SessionStatus.Closed;
                        repo.Update(session);
                        uow.SaveChanges();
                    }
                }
                catch
                {
                    // Hata yutulsun, kapanmaya engel olmasın.
                }
            }
            System.Windows.Forms.Application.ExitThread();
        }

        private void AnaForm_Load(object? sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Seçili firma ve kullanıcı bilgilerini bar başlıklarına (veya pencere başlığına) yazdır
                Text = $"ThermaCore ERP --- Bilgisayar: {Environment.MachineName}";

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
                        
                        // Scope içerisinde yeni üretilen ICurrentTenantService'e ana context'teki bilgileri aktar
                        var backgroundTenantService = scope.ServiceProvider.GetRequiredService<ThermaCore.Application.Interfaces.System.ICurrentTenantService>();
                        backgroundTenantService.ConnectionString = currentConnString;
                        backgroundTenantService.TenantId = currentTenantId;
                        backgroundTenantService.TenantName = currentTenantName;
                        backgroundTenantService.UserId = currentUserId;

                        var exchangeRateService = scope.ServiceProvider.GetRequiredService<ThermaCore.Application.Interfaces.System.IExchangeRateService>();
                        await exchangeRateService.SyncTcmbRatesAsync();
                        
                        // Veritabanından (TenantDB) en güncel USD ve EUR EffectiveSellingRate değerlerini oku.
                        var exchangeRateRepository = scope.ServiceProvider.GetRequiredService<ThermaCore.Application.Interfaces.Repositories.IRepository<ThermaCore.Domain.Entities.Management.ExchangeRate>>();
                        
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
            var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
            if (authService == null) return;
            
            var userRepo = _serviceProvider.GetService<ThermaCore.Application.Interfaces.Repositories.IMasterRepository<ThermaCore.Domain.Entities.Management.User>>();
            var user = userRepo?.GetById(_currentTenantService.UserId);
            bool isSuperAdmin = user != null && (user.Code.ToLower() == "admin" || user.Code.ToLower() == "thermacore");

            ApplyMenuPermissionsRecursive(items, authService, isSuperAdmin);
        }

        private void ApplyMenuPermissionsRecursive(ToolStripItemCollection items, ThermaCore.Application.Services.Management.IAuthService authService, bool isSuperAdmin)
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
                else if (item.Tag is ThermaCore.Domain.Enums.ModuleType moduleType)
                {
                    bool hasAccess = authService.HasPermission(moduleType, ThermaCore.Domain.Enums.PermissionType.CanView);
                    item.Visible = hasAccess;
                }
                else if (item.Tag is string tagStr)
                {
                    if (Enum.TryParse(tagStr.Trim(), true, out ThermaCore.Domain.Enums.ModuleType parsedModuleType))
                    {
                        bool hasAccess = authService.HasPermission(parsedModuleType, ThermaCore.Domain.Enums.PermissionType.CanView);
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
            var authService = _serviceProvider.GetRequiredService<ThermaCore.Application.Services.Management.IAuthService>();
            var appConfigService = _serviceProvider.GetRequiredService<ThermaCore.Application.Interfaces.Configuration.IAppConfigService>();

            long userId = _currentTenantService.UserId;
            long tenantId = _currentTenantService.TenantId;

            var allowedBranches = await authService.GetAllowedBranchesAsync(userId, tenantId);

            if (allowedBranches == null || allowedBranches.Count == 0)
            {
                var userRepo = _serviceProvider.GetRequiredService<ThermaCore.Application.Interfaces.Repositories.IMasterRepository<ThermaCore.Domain.Entities.Management.User>>();
                var user = userRepo.Find(u => u.Id == userId).FirstOrDefault();

                if (user != null && (user.Code.ToLower() == "admin" || user.Code.ToLower() == "thermacore"))
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

            this.Text = $"ThermaCore ERP --- Bilgisayar: {Environment.MachineName} | Şirket: {_currentTenantService.TenantName} | Fabrika: {_currentTenantService.BranchName}";

            // Sistemin açılışını kitlemeden arkadan kontrol işlemi başlatalım
            _ = Task.Run(async () => await EksikSablonlariKontrolEtAsync());
        }

        private async Task EksikSablonlariKontrolEtAsync()
        {
            try
            {
                var requiredModules = Enum.GetValues(typeof(ThermaCore.Domain.Enums.ModuleType))
                    .Cast<ThermaCore.Domain.Enums.ModuleType>()
                    .Where(m => 
                    {
                        var field = typeof(ThermaCore.Domain.Enums.ModuleType).GetField(m.ToString());
                        return field != null && Attribute.IsDefined(field, typeof(ThermaCore.Domain.Attributes.RequiresCodeTemplateAttribute));
                    })
                    .ToArray();

                using var scope = _serviceProvider.CreateScope();
                var sablonRepo = scope.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Repositories.IMasterRepository<ThermaCore.Domain.Entities.Management.CodeTemplate>>();
                
                if (sablonRepo == null) return;

                var missingModules = new System.Collections.Generic.List<string>();

                foreach (var module in requiredModules)
                {
                    var hasTemplate = System.Linq.Enumerable.Any(sablonRepo.Find(x => x.Module == module && !x.IsDeleted));
                    if (!hasTemplate)
                    {
                        var field = typeof(ThermaCore.Domain.Enums.ModuleType).GetField(module.ToString());
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

            // Açıksa öne getirir, değilse DI container üzerinden yeni bir instance oluşturur (Transient form)
            try
            {
                var newForm = _serviceProvider.GetRequiredService<T>();
                newForm.MdiParent = this;
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
            var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.GenelParametreler, ThermaCore.Domain.Enums.PermissionType.CanView))
            {
                var form = _serviceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.ParametrelerForms.GenelParametrelerEditForm>();
                form.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miSirketTanimlari_Click(object? sender, EventArgs e)
        {
            FormYukle<ThermaCore.Presentation.WinForms.Forms.SirketForms.SirketListForm>();
        }

        private void miBirimTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.BirimTanimlari, ThermaCore.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miKurTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.KurTanimlari, ThermaCore.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.KurlarForms.KurListForm>();
            }
            else
            {
                XtraMessageBox.Show("Bu ekrana erişim yetkiniz bulunmamaktadır.", "Yetkisiz Erişim", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void miKdvOranlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.KdvOranlari, ThermaCore.Domain.Enums.PermissionType.CanView))
            {
                // Parametre geçmek için ActivatorUtilities kullanıp yeni form oluşturup öne getireceğiz
                var form = ActivatorUtilities.CreateInstance<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.VergiForms.VergiOraniListForm>(_serviceProvider, ThermaCore.Domain.Enums.TaxType.Kdv);
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
            var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.OtvOranlari, ThermaCore.Domain.Enums.PermissionType.CanView))
            {
                var form = ActivatorUtilities.CreateInstance<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.VergiForms.VergiOraniListForm>(_serviceProvider, ThermaCore.Domain.Enums.TaxType.Otv);
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
            FormYukle<ThermaCore.Presentation.WinForms.Forms.CodeTemplateForms.CodeTemplateListForm>();
        }

        private void miYetkiGruplariRoller_Click(object? sender, EventArgs e)
        {
            FormYukle<ThermaCore.Presentation.WinForms.Forms.YetkilendirmeForms.RolListForm>();
        }

        private void KullaniciTanimlari_Click(object? sender, EventArgs e)
        {
            FormYukle<ThermaCore.Presentation.WinForms.Forms.KullaniciForms.KullaniciListForm>();
        }

        private void miTerminalYonetim_Click(object? sender, EventArgs e)
        {
            FormYukle<ThermaCore.Presentation.WinForms.Forms.TerminalForms.TerminalListForm>();
        }



        private void miKaliteStandartTanimlari_Click(object? sender, EventArgs e)
        {
            FormYukle<ThermaCore.Presentation.WinForms.Forms.KaliteStandartForms.KaliteStandartListForm>();
        }

        private void miYuzeyTipiTanimlari_Click(object? sender, EventArgs e)
        {
            var authService = _serviceProvider.GetService<ThermaCore.Application.Services.Management.IAuthService>();
            if (authService != null && authService.HasPermission(ThermaCore.Domain.Enums.ModuleType.YuzeyTipiTanimlari, ThermaCore.Domain.Enums.PermissionType.CanView))
            {
                FormYukle<ThermaCore.Presentation.WinForms.Forms.YuzeyTipiForms.YuzeyTipiListForm>();
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
            Messages.BilgiBasligi("Güncelleme sistemi (Update.exe) ThermaCore altyapısına göre yeniden yazılacaktır.", "Bilgi");
        }

        public async void FabrikaDegistir()
        {
            var appConfigService = _serviceProvider.GetRequiredService<ThermaCore.Application.Interfaces.Configuration.IAppConfigService>();
            appConfigService.SetLastBranchId(0); // RememberedBranchId'yi sıfırla
            
            // Tüm sekmeleri kapat
            foreach (Form form in MdiChildren)
            {
                form.Close();
            }

            // Yeniden şube seçimi yapılması için Shown olayındaki mantığı tetikleyelim
            var authService = _serviceProvider.GetRequiredService<ThermaCore.Application.Services.Management.IAuthService>();
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

                        this.Text = $"ThermaCore ERP | Şirket: {_currentTenantService.TenantName} | Fabrika: {_currentTenantService.BranchName}";
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
        private bool VersiyonKontroluYap()
        {
            // ... Eski versiyon kontrolü iptal edildi ...
            return true;
        }

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

        private async void TimerDoviz_Tick(object sender, EventArgs e)
        {
            // ... IDovizService yazılıp entegre edilmelidir ...
        }

        private async Task DovizVerileriGuncelleAsync() { }

        private void GuncelDovizBilgisiniYazdir() { }
        */

        #endregion
    }
}
