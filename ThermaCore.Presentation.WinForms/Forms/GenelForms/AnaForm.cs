using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThermaCore.Application.Interfaces.System; // ICurrentTenantService ve ISessionService için
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.GenelForms
{
    public partial class AnaForm : XtraForm
    {
        private bool _programiOtomatikKapat;
        
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
            FormClosing += AnaForm_FormClosing;
            KeyDown += Control_KeyDown;
            
            if (miSirketTanimlari != null)
                miSirketTanimlari.Click += miSirketTanimlari_Click;

            if (miFabrikaSubeTanimlari != null)
                miFabrikaSubeTanimlari.Click += miFabrikaSubeTanimlari_Click;

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
                Text = $"THERMACORE --- Bilgisayar: {Environment.MachineName} | Seçili Firma ID: {_currentTenantService?.TenantId}";

                // TODO: GuncelDovizBilgisiniYazdir(); (Döviz kurları için dış API / IDovizService eklenecek)
                // TODO: OnaylanmamisKayitlariKontrolEtAsync(); (İş kuralları Application katmanına taşınacak)
                // TODO: AylikMetreBilgisiGetirAsync(); (EF Core sorguları Application katmanına taşınacak)
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

        private void miFabrikaSubeTanimlari_Click(object? sender, EventArgs e)
        {
            Messages.UyariMesaji("Fabrika ve Şube tanımlarına erişmek için lütfen önce 'Şirket Tanımları' ekranını açınız ve ilgili şirketi seçerek 'Bağlı Kartlar -> Fabrika Kartları' yolunu izleyiniz.");
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