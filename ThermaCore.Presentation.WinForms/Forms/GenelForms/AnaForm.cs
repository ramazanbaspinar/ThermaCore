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
            
            // Dinamik Yükleme Click Eventleri
            if (miSirketTanimlari != null)
                miSirketTanimlari.Click += miSirketTanimlari_Click;

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
                // TODO: await _sessionService.EndSessionAsync(currentUserId);
                System.Windows.Forms.Application.ExitThread();
            }
            else
            {
                // Eski Messages yapısı temizlendiği için standart MessageBox'a çevrildi
                var cevap = Messages.KapatMesaj();

                if (cevap == DialogResult.Yes)
                {
                    // TODO: await _sessionService.EndSessionAsync(currentUserId);
                    System.Windows.Forms.Application.ExitThread();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void AnaForm_Load(object? sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Seçili firma ve kullanıcı bilgilerini bar başlıklarına (veya pencere başlığına) yazdır
                Text = $"ThermaCore ERP --- Bilgisayar: {Environment.MachineName}";

                // TODO: GuncelDovizBilgisiniYazdir(); (Döviz kurları için dış API / IDovizService eklenecek)
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
            
            ApplyMenuPermissionsRecursive(items, authService);
        }

        private void ApplyMenuPermissionsRecursive(ToolStripItemCollection items, ThermaCore.Application.Services.Management.IAuthService authService)
        {
            foreach (ToolStripItem item in items)
            {
                bool hasVisibleChildren = false;
                
                if (item is ToolStripMenuItem menuItem && menuItem.DropDownItems.Count > 0)
                {
                    ApplyMenuPermissionsRecursive(menuItem.DropDownItems, authService);

                    foreach (ToolStripItem child in menuItem.DropDownItems)
                    {
                        if (child.Visible)
                        {
                            hasVisibleChildren = true;
                            break;
                        }
                    }
                }

                if (item.Tag is ThermaCore.Domain.Enums.ModuleType moduleType)
                {
                    bool hasAccess = authService.HasPermission(moduleType, ThermaCore.Domain.Enums.PermissionType.CanView);
                    item.Visible = hasAccess;
                }
                else if (item.Tag is string tagStr && Enum.TryParse(tagStr, true, out ThermaCore.Domain.Enums.ModuleType parsedModuleType))
                {
                    bool hasAccess = authService.HasPermission(parsedModuleType, ThermaCore.Domain.Enums.PermissionType.CanView);
                    item.Visible = hasAccess;
                }
                else if (item is ToolStripMenuItem parentItem && parentItem.DropDownItems.Count > 0)
                {
                    item.Visible = hasVisibleChildren;
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
                Messages.HataBasligi("Giriş yaptığınız şirkette hiçbir fabrika/şube yetkiniz bulunmuyor. Oturum kapatılacaktır.", "Yetkisiz Erişim");
                _programiOtomatikKapat = true;
                System.Windows.Forms.Application.Exit();
                return;
            }

            if (allowedBranches.Count == 1)
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
                var requiredModules = new[] 
                { 
                    ThermaCore.Domain.Enums.ModuleType.Factory, 
                    ThermaCore.Domain.Enums.ModuleType.YetkiGruplari
                };

                using var scope = _serviceProvider.CreateScope();
                var sablonRepo = scope.ServiceProvider.GetService<ThermaCore.Application.Interfaces.Repositories.IRepository<ThermaCore.Domain.Entities.Management.CodeTemplate>>();
                
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

        private void miSirketTanimlari_Click(object? sender, EventArgs e)
        {
            FormYukle<ThermaCore.Presentation.WinForms.Forms.SirketForms.SirketListForm>();
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
