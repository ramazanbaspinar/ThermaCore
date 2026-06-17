using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.SirketForms
{
    public partial class SirketEditForm : BaseEditForm
    {
        private readonly ITenantDatabaseSetupService _tenantDatabaseSetupService = default!;
        private readonly IMasterRepository<TenantDatabase> _tenantRepository = default!;
        private readonly IMasterUnitOfWork _uow = default!;

        public SirketEditForm()
        {
            InitializeComponent();
        }

        public SirketEditForm(ITenantDatabaseSetupService tenantDatabaseSetupService, IMasterRepository<TenantDatabase> tenantRepository, IMasterUnitOfWork uow)
        {
            InitializeComponent();
            _tenantDatabaseSetupService = tenantDatabaseSetupService;
            _tenantRepository = tenantRepository;
            _uow = uow;
        }

        // BaseForm'daki protected Id alanına dışarıdan müdahale edip ShowDialog yapabilmek için 


        protected override void EventsLoad()
        {
            base.EventsLoad();

            // Wire control changes to dirty tracking
            txtSirketKodu.EditValueChanged += Control_EditValueChanged;
            txtSirketAdi.EditValueChanged += Control_EditValueChanged;
            txtVeritabaniAdi.EditValueChanged += Control_EditValueChanged;
            txtSqlKullaniciAdi.EditValueChanged += Control_EditValueChanged;
            txtSqlSifre.EditValueChanged += Control_EditValueChanged;
            myToggleSwitch1.EditValueChanged += Control_EditValueChanged;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var entity = _tenantRepository.GetById(Id);
                if (entity != null)
                {
                    txtSirketKodu.Text = entity.Code;
                    txtSirketAdi.Text = entity.CompanyName;
                    txtVeritabaniAdi.Text = entity.DatabaseName;
                    txtSqlKullaniciAdi.Text = entity.Username;
                    txtSqlSifre.Text = entity.Password;
                    txtSirketKodu.Enabled = false;
                    myToggleSwitch1.IsOn = entity.IsActive;
                }
            }
            else
            {
                txtSirketKodu.Enabled = true;
                myToggleSwitch1.IsOn = true;

                // Yeni şirket oluştururken varsayılan veritabanı ayarları
                txtSqlKullaniciAdi.Text = ""; // LocalDB Windows Auth gerektirir
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
                AuthType = AuthenticationType.Windows, // LocalDB için varsayılan Windows Auth
                Username = txtSqlKullaniciAdi.Text,
                Password = txtSqlSifre.Text,
                IsActive = myToggleSwitch1.IsOn
            };
        }

        protected override bool EntityInsert()
        {
            try
            {
                // UI donmasın diye bekleme imleci çıkar
                Cursor.Current = Cursors.WaitCursor;
                
                var dto = (TenantDatabaseDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(dto);
                this.Id = dto.Id;

                // Asenkron servisi Task.Run içerisinde bekleyerek (UI deadlock önlemek için) çalıştır.
                System.Threading.Tasks.Task.Run(async () => 
                {
                    await _tenantDatabaseSetupService.CreateTenantDatabaseAsync(dto);
                }).GetAwaiter().GetResult();

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
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var dto = (TenantDatabaseDto)CurrentEntity;
                
                var entity = _tenantRepository.GetById(dto.Id);
                if (entity != null)
                {
                    entity.CompanyName = dto.CompanyName;
                    entity.DatabaseName = dto.DatabaseName;
                    entity.Server = dto.Server;
                    entity.AuthType = dto.AuthType;
                    entity.Username = dto.Username;
                    entity.Password = dto.Password;
                    entity.IsActive = dto.IsActive;
                    
                    _tenantRepository.Update(entity);
                    _uow.SaveChanges();
                    Messages.BilgiBasligi("Mevcut Şirket bilgileri başarıyla güncellendi.", "Bilgi");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi($"Güncelleme sırasında hata oluştu:\n\n{ex.Message}", "Hata");
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}