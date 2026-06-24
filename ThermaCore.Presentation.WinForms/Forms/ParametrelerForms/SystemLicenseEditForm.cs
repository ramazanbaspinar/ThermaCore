using System;
using System.Linq;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.ParametrelerForms
{
    public partial class SystemLicenseEditForm : BaseEditForm
    {
        private readonly IMasterRepository<SystemLicense> _systemLicenseRepository;
        private readonly IMasterUnitOfWork _uow;

        public SystemLicenseEditForm(IMasterRepository<SystemLicense> systemLicenseRepository, IMasterUnitOfWork uow)
        {
            InitializeComponent();
            _systemLicenseRepository = systemLicenseRepository;
            _uow = uow;
            
            BaseKartTuru = ModuleType.SystemLicense;
            DataLayoutControl = myDataLayoutControl1;
            RequiresCodeTemplate = false; 

            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil };

            btnCihazMacGetir.Click += btnCihazMacGetir_Click;
            btnCihazIdGetir.Click += btnCihazIdGetir_Click;

            // Kilitlenecek (Sadece Bilgi Gösterimi) alanlar
            txtServerMacAddress.Properties.ReadOnly = true;
            txtServerCpuId.Properties.ReadOnly = true;
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
                    ServerMacAddress = entity.ServerMacAddress,
                    ServerCpuId = entity.ServerCpuId,
                    LicenseKey = entity.LicenseKey,
                    ExpirationDate = entity.ExpirationDate,
                    MaxTerminalCount = entity.MaxTerminalCount
                };

                txtServerMacAddress.Text = entity.ServerMacAddress;
                txtServerCpuId.Text = entity.ServerCpuId;
                txtLicenseKey.Text = entity.LicenseKey;
                dtExpirationDate.DateTime = entity.ExpirationDate;
                txtMaxTerminal.EditValue = entity.MaxTerminalCount;
                
                this.Id = entity.Id;
                BaseIslemTuru = ActionType.EntityUpdate;
            }
            else
            {
                CurrentEntity = new SystemLicenseDto();
                
                var hardware = ThermaCore.Domain.Helpers.NetworkHelper.GetHardwareFingerprints();
                txtServerMacAddress.Text = "";
                txtServerCpuId.Text = "";
                txtLicenseKey.Text = "";
                dtExpirationDate.DateTime = DateTime.Now.AddDays(30); // Default trial
                txtMaxTerminal.EditValue = 5; // Varsayılan deneme sürümü terminal sayısı
                
                BaseIslemTuru = ActionType.EntityInsert;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new SystemLicenseDto
            {
                Id = this.Id,
                ServerMacAddress = txtServerMacAddress.Text,
                ServerCpuId = txtServerCpuId.Text,
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
                    Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
                    ServerMacAddress = dto.ServerMacAddress,
                    ServerCpuId = dto.ServerCpuId,
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
                    entity.ServerMacAddress = dto.ServerMacAddress;
                    entity.ServerCpuId = dto.ServerCpuId;
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

        public void btnCihazMacGetir_Click(object sender, EventArgs e)
        {
            var hardware = ThermaCore.Domain.Helpers.NetworkHelper.GetHardwareFingerprints();
            txtServerMacAddress.Text = hardware.EthernetMacs.FirstOrDefault() ?? hardware.WifiMacs.FirstOrDefault() ?? "";
        }

        public void btnCihazIdGetir_Click(object sender, EventArgs e)
        {
            txtServerCpuId.Text = Environment.MachineName;
        }
    }
}