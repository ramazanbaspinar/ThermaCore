using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.Security;
using ThermaCore.Application.Interfaces.System;
using FluentValidation;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using System.Linq;

namespace ThermaCore.Presentation.WinForms.Forms.SirketForms
{
    public partial class SirketEditForm : BaseEditForm
    {
        private readonly ITenantDatabaseSetupService _tenantDatabaseSetupService = default!;
        private readonly ITenantDatabaseCrudService _tenantDatabaseCrudService = default!;
        private readonly IMasterUnitOfWork _uow = default!;
        private readonly ICryptoService _cryptoService = default!;

        public SirketEditForm()
        {
            InitializeComponent();
        }

        public SirketEditForm(ITenantDatabaseSetupService tenantDatabaseSetupService, ITenantDatabaseCrudService tenantDatabaseCrudService, IMasterUnitOfWork uow, ICryptoService cryptoService)
        {
            InitializeComponent();
            _tenantDatabaseSetupService = tenantDatabaseSetupService;
            _tenantDatabaseCrudService = tenantDatabaseCrudService;
            _uow = uow;
            _cryptoService = cryptoService;
            this.BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.SirketTanimlari;
            DataLayoutControl = myDataLayoutControl1;
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
            
            txtAuthType.SelectedIndexChanged += TxtAuthType_SelectedIndexChanged;
        }

        private void TxtAuthType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtAuthType.SelectedItem?.ToString() == AuthenticationType.Windows.ToName())
            {
                txtSqlKullaniciAdi.Enabled = false;
                txtSqlSifre.Enabled = false;
                txtSqlKullaniciAdi.Text = "";
                txtSqlSifre.Text = "";
            }
            else
            {
                txtSqlKullaniciAdi.Enabled = true;
                txtSqlSifre.Enabled = true;
            }
            
            Control_EditValueChanged(sender, e);
        }

        private void ComboBoxVeriYukle()
        {
            txtAuthType.Properties.Items.Clear();
            txtAuthType.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<AuthenticationType>().ToArray());
        }

        public override void Yukle()
        {
            ComboBoxVeriYukle();

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var dto = _tenantDatabaseCrudService.GetById(Id);
                if (dto != null)
                {
                    txtSirketKodu.Text = dto.Code;
                    txtSirketAdi.Text = dto.CompanyName;
                    txtVeritabaniAdi.Text = dto.DatabaseName;
                    txtServer.Text = dto.Server;
                    txtSqlKullaniciAdi.Text = dto.Username;
                    try { txtSqlSifre.Text = string.IsNullOrEmpty(dto.Password) ? "" : _cryptoService.Decrypt(dto.Password); } catch { txtSqlSifre.Text = dto.Password; }
                    txtAuthType.SelectedItem = dto.AuthType.ToName(); // Bunu sona aldık ki Windows seçiliyse üsttekileri tekrar silsin
                    txtSirketKodu.Enabled = false;
                    myToggleSwitch1.IsOn = dto.IsActive;
                }
            }
            else
            {
                txtSirketKodu.Text = "";
                txtSirketAdi.Text = "";
                txtVeritabaniAdi.Text = "";
                txtServer.Text = "";
                txtAuthType.SelectedItem = AuthenticationType.Windows.ToName();
                txtSqlKullaniciAdi.Text = "";
                txtSqlSifre.Text = "";
                txtSirketKodu.Enabled = true;
                myToggleSwitch1.IsOn = true;
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
                DatabaseName = txtVeritabaniAdi.Text.Replace(" ", "_"), // Veritabanı adındaki boşlukları alt çizgiye çeviriyoruz
                Server = txtServer.Text,
                AuthType = string.IsNullOrWhiteSpace(txtAuthType.EditValue?.ToString()) ? AuthenticationType.Windows : txtAuthType.EditValue.ToString()!.GetEnum<AuthenticationType>(),
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
            catch (FluentValidation.ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                var baseEx = ex.GetBaseException();
                if (baseEx is Microsoft.Data.SqlClient.SqlException sqlEx)
                {
                    if (sqlEx.Number == 2 || sqlEx.Number == 53 || sqlEx.Number == -2)
                        Messages.HataBasligi("Belirttiğiniz sunucuya ulaşılamıyor. Lütfen Sunucu Adı/IP bilgisinin doğru olduğundan ve sunucunun açık olduğundan emin olunuz.", "Sunucu Bağlantı Hatası");
                    else if (sqlEx.Number == 18456)
                        Messages.HataBasligi("Girdiğiniz SQL Kullanıcı Adı veya Şifresi hatalı. Lütfen kimlik bilgilerini kontrol ediniz.", "Yetki Hatası");
                    else
                        Messages.HataBasligi($"Veritabanı sunucusu işlemi reddetti:\n{sqlEx.Message}", "Veritabanı Hatası");
                }
                else if (baseEx.Message.Contains("transient failure") || baseEx.Message.Contains("EnableRetryOnFailure"))
                {
                    Messages.HataBasligi("Veritabanı sunucusu ile bağlantı kurulamadı. Girdiğiniz sunucu adresinin ve bağlantı bilgilerinin doğru olduğundan emin olunuz.", "Bağlantı Hatası");
                }
                else
                {
                    Messages.HataBasligi($"Kurulum sırasında kritik bir hata oluştu:\n\n{baseEx.Message}", "Veritabanı Oluşturma Hatası");
                }
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
                
                var existingDto = _tenantDatabaseCrudService.GetById(dto.Id);
                if (existingDto != null)
                {
                    dto.Password = string.IsNullOrEmpty(dto.Password) ? "" : _cryptoService.Encrypt(dto.Password);
                    _tenantDatabaseCrudService.Update(dto);

                    Messages.BilgiBasligi("Mevcut Şirket bilgileri başarıyla güncellendi.", "Bilgi");
                    return true;
                }
                return false;
            }
            catch (FluentValidation.ValidationException)
            {
                throw;
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

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Messages.SilMesaj("Şirket") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var existingDto = _tenantDatabaseCrudService.GetById(Id);
                    if (existingDto != null)
                    {
                        _tenantDatabaseCrudService.Delete(existingDto.Id);
                        RefreshYapilacak = true;
                        Messages.SilindiMesaj();
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi($"Silme işlemi sırasında hata oluştu:\n\n{ex.Message}", "Hata");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        protected override void FocusControlByPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Code": txtSirketKodu.Focus(); break;
                case "CompanyName": txtSirketAdi.Focus(); break;
                case "DatabaseName": txtVeritabaniAdi.Focus(); break;
                case "Server": txtServer.Focus(); break;
                case "Username": txtSqlKullaniciAdi.Focus(); break;
                case "Password": txtSqlSifre.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return !_tenantDatabaseCrudService.GetAll().Any(x => x.Code == code);
        }
    }
}