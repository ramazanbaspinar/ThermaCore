using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MaliyetParametreForms
{
    public partial class MaliyetParametreEditForm : BaseEditForm
    {
        private readonly IMaliyetParametreService _maliyetParametreService;
        private MaliyetParametreDto _currentDto;

        public MaliyetParametreEditForm(IMaliyetParametreService maliyetParametreService)
        {
            InitializeComponent();
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.MaliyetParametreleri;
            _maliyetParametreService = maliyetParametreService;

            BaseIslemTuru = ActionType.EntityUpdate;
            BaseKartTuru = ModuleType.MaliyetParametreleri;
            KayitSonrasiFormuKapat = false; // Singleton form olduğu için kaydetten sonra kapanmamalı
            DataLayoutControls = new object[] { myDataLayoutControl1 };
        }

        public MaliyetParametreEditForm()
        {
            InitializeComponent();
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.MaliyetParametreleri;
            
            if (Program.ServiceProvider != null)
            {
                _maliyetParametreService = Program.ServiceProvider.GetService<IMaliyetParametreService>();
            }
        }

        public override void Yukle()
        {
            if (btnYeni != null) btnYeni.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnSil != null) btnSil.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            try
            {
                _currentDto = _maliyetParametreService?.GetMaliyetParametreAsync().GetAwaiter().GetResult();
                
                if (_currentDto == null || _currentDto.Id == 0)
                {
                    _currentDto = new MaliyetParametreDto { Id = 0 };
                    BaseIslemTuru = ActionType.EntityInsert;
                }
                else
                {
                    BaseIslemTuru = ActionType.EntityUpdate;
                }
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Hata");
                _currentDto = new MaliyetParametreDto { Id = 0 };
                BaseIslemTuru = ActionType.EntityInsert;
            }

            CurrentEntity = _currentDto;
            OldEntity = CloneEntity(CurrentEntity);

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            if (_currentDto == null) return;
            
            if (txtVadeFarkiOrani != null) txtVadeFarkiOrani.Value = _currentDto.MaturityDifferenceRate;
            if (txtFireOrani != null) txtFireOrani.Value = _currentDto.WastageRate;
            if (txtOrtalamaUretimDegeri != null) txtOrtalamaUretimDegeri.Value = _currentDto.AverageProductionValue;
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new MaliyetParametreDto 
            {
                Id = _currentDto?.Id ?? 0,
                BranchId = _currentDto?.BranchId ?? 0, // KORUMA: UI tarafında da BranchId taşınsın
                MaturityDifferenceRate = txtVadeFarkiOrani?.Value ?? 0,
                WastageRate = txtFireOrani?.Value ?? 0,
                AverageProductionValue = txtOrtalamaUretimDegeri?.Value ?? 0
            };
            
            CurrentEntity = dto;
        }

        protected override bool EntityInsert()
        {
            return SingletonKaydet();
        }

        protected override bool EntityUpdate()
        {
            return SingletonKaydet();
        }

        private bool SingletonKaydet()
        {
            try
            {

                GuncelNesneOlustur();
                _currentDto = (MaliyetParametreDto)CurrentEntity;

                _maliyetParametreService.SaveParametreAsync(_currentDto).GetAwaiter().GetResult();
                return true;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Kayıt Hatası");
                return false;
            }
        }
    }
}




