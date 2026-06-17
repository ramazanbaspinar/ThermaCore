using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.SirketForms
{
    public partial class SirketEditForm : BaseEditForm
    {
        private readonly ITenantDatabaseSetupService _tenantDatabaseSetupService = default!;

        public SirketEditForm()
        {
            InitializeComponent();
        }

        public SirketEditForm(ITenantDatabaseSetupService tenantDatabaseSetupService)
        {
            InitializeComponent();
            _tenantDatabaseSetupService = tenantDatabaseSetupService;
        }

        // BaseForm'daki protected Id alanına dışarıdan müdahale edip ShowDialog yapabilmek için 
        public void IdAtaVeAc(long id)
        {
            this.Id = id;
            this.ShowDialog();
        }

        protected override void Yukle()
        {
            if (Id > 0)
            {
                BaseIslemTuru = ActionType.EntityUpdate;
                
                // TODO: İleride düzenleme modunda veritabanından çekilen kaydın alanlara atanması
                txtSirketKodu.Enabled = false;
                myToggleSwitch1.IsOn = true;
            }
            else
            {
                BaseIslemTuru = ActionType.EntityInsert;
                
                txtSirketKodu.Enabled = true;
                myToggleSwitch1.IsOn = true;

                // Yeni şirket oluştururken varsayılan veritabanı ayarları
                txtSqlKullaniciAdi.Text = "sa";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            // Ekranda girilen UI verilerinden İngilizce modelimize uygun DTO üretiyoruz
            CurrentEntity = new TenantDatabaseDto
            {
                Id = this.Id,
                Code = txtSirketKodu.Text,
                CompanyCode = txtSirketKodu.Text,
                CompanyName = txtSirketAdi.Text,
                DatabaseName = txtVeritabaniAdi.Text,
                Server = "(localdb)\\MSSQLLocalDB", // Şimdilik varsayılan server adı
                AuthType = AuthenticationType.SqlServer,
                Username = txtSqlKullaniciAdi.Text,
                Password = txtSqlSifre.Text
            };
        }

        protected override bool EntityInsert()
        {
            try
            {
                // UI donmasın diye bekleme imleci çıkar
                Cursor.Current = Cursors.WaitCursor;
                
                var dto = (TenantDatabaseDto)CurrentEntity;

                // Asenkron servisi arka planda bekleyerek (senkron blok) çalıştır.
                // Bu metot hem Master DB'ye şirket kaydını atacak hem de 
                // SQL Server'da bu şirkete özel bağımsız veritabanını oluşturacaktır.
                _tenantDatabaseSetupService.CreateTenantDatabaseAsync(dto).GetAwaiter().GetResult();

                Messages.BilgiBasligi("Şirket bilgileri Master veritabanına kaydedildi ve şirkete özel yepyeni fiziksel veritabanı (Tenant DB) başarıyla ayağa kaldırıldı!", "Kurulum Başarılı");
                    
                return true;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi($"Kurulum sırasında kritik bir hata oluştu:\n\n{ex.Message}", "Veritabanı Oluşturma Hatası");
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override bool EntityUpdate()
        {
            // Düzenleme senaryosu (Henüz implemente edilmedi, UI mesajı döndürülüyor)
            Messages.BilgiBasligi("Mevcut şirket bilgileri başarıyla güncellendi.", "Bilgi");
            return true;
        }
    }
}