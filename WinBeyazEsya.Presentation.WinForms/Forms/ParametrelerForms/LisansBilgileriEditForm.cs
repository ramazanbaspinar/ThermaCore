using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms
{
    public partial class LisansBilgileriEditForm : BaseEditForm
    {
        private readonly IMasterRepository<SystemLicense> _systemLicenseRepository;
        private readonly IMasterUnitOfWork _uow;

        public LisansBilgileriEditForm(IMasterRepository<SystemLicense> systemLicenseRepository, IMasterUnitOfWork uow)
        {
            InitializeComponent();
            _systemLicenseRepository = systemLicenseRepository;
            _uow = uow;

            BaseKartTuru = ModuleType.SystemLicense;
            DataLayoutControl = myDataLayoutControl1;
            RequiresCodeTemplate = false;

            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil, btnKaydet, btnGerial };

            // Kilitlenecek (Sadece Bilgi Gösterimi) alanlar
            txtHardwareId.Properties.ReadOnly = true;
            txtLicenseKey.Properties.ReadOnly = true;
            dtExpirationDate.Properties.ReadOnly = true;
            txtMaxTerminal.Properties.ReadOnly = true;
        }

        public override void Yukle()
        {
            var entity = _systemLicenseRepository.GetAll().FirstOrDefault();
            if (entity != null)
            {
                CurrentEntity = new SystemLicenseDto
                {
                    Id = entity.Id,
                    ServerHardwareId = entity.ServerHardwareId,
                    LicenseKey = entity.LicenseKey,
                    ExpirationDate = entity.ExpirationDate,
                    MaxTerminalCount = entity.MaxTerminalCount
                };

                txtHardwareId.Text = entity.ServerHardwareId;
                txtLicenseKey.Text = entity.LicenseKey;
                dtExpirationDate.DateTime = entity.ExpirationDate;
                txtMaxTerminal.EditValue = entity.MaxTerminalCount;

                this.Id = entity.Id;
                BaseIslemTuru = ActionType.EntityUpdate;
            }
            else
            {
                CurrentEntity = new SystemLicenseDto();

                txtHardwareId.Text = "";
                txtLicenseKey.Text = "";
                dtExpirationDate.DateTime = DateTime.Now.AddDays(30); // Default trial
                txtMaxTerminal.EditValue = 5; // Varsayýlan deneme sürümü terminal sayýsý

                BaseIslemTuru = ActionType.EntityInsert;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new SystemLicenseDto
            {
                Id = this.Id,
                ServerHardwareId = txtHardwareId.Text,
                LicenseKey = txtLicenseKey.Text,
                ExpirationDate = dtExpirationDate.DateTime,
                MaxTerminalCount = Convert.ToInt32(txtMaxTerminal.EditValue)
            };
        }

        protected override bool EntityInsert()
        {
            try
            {
                var dto = (SystemLicenseDto)CurrentEntity;
                var entity = new SystemLicense
                {
                    Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(),
                    ServerHardwareId = dto.ServerHardwareId,
                    LicenseKey = dto.LicenseKey,
                    ExpirationDate = dto.ExpirationDate,
                    MaxTerminalCount = dto.MaxTerminalCount
                };

                _systemLicenseRepository.Add(entity);
                _uow.SaveChanges();

                this.Id = entity.Id;
                Messages.KayitBasariliMesaji();
                BaseIslemTuru = ActionType.EntityUpdate;
                return true;
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            try
            {
                var dto = (SystemLicenseDto)CurrentEntity;
                var entity = _systemLicenseRepository.GetById(this.Id);
                if (entity != null)
                {
                    entity.ServerHardwareId = dto.ServerHardwareId;
                    entity.LicenseKey = dto.LicenseKey;
                    entity.ExpirationDate = dto.ExpirationDate;
                    entity.MaxTerminalCount = dto.MaxTerminalCount;

                    _systemLicenseRepository.Update(entity);
                    _uow.SaveChanges();

                    Messages.KayitBasariliMesaji();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;
            }
        }

    }
}

