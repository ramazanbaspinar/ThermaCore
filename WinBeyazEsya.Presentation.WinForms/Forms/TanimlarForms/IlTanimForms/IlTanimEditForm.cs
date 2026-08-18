using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlTanimForms
{
    public partial class IlTanimEditForm : BaseEditForm
    {
        private readonly ICityService _cityService = default!;
        private long _countryId = 0;

        protected override string CodeControlName => "txtCode";

        public IlTanimEditForm() { InitializeComponent(); }

        public IlTanimEditForm(ICityService cityService)
        {
            InitializeComponent();
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _cityService = cityService;
                Bll = _cityService;
            }
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.City;
            RequiresCodeTemplate = false;
        }

        public void SetUlke(long countryId)
        {
            _countryId = countryId;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                CurrentEntity = new CityDto { IsActive = true, CountryId = _countryId };
                Id = BaseIslemTuru.IdOlustur(OldEntity);
            }
            else
            {
                CurrentEntity = _cityService.GetById(Id);
                _countryId = ((CityDto)CurrentEntity).CountryId;
            }
            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (CityDto)CurrentEntity;
            var txtCode = this.Controls.Find("txtCode", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtTitle = this.Controls.Find("txtName", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var tglActive = this.Controls.Find("tgsIsActive", true).FirstOrDefault() as DevExpress.XtraEditors.ToggleSwitch;

            if (txtCode != null) txtCode.Text = entity.Code;
            if (txtTitle != null) txtTitle.Text = entity.Title;
            if (tglActive != null) tglActive.IsOn = entity.IsActive;
        }

        protected override void GuncelNesneOlustur()
        {
            var txtCode = this.Controls.Find("txtCode", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtTitle = this.Controls.Find("txtName", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var tglActive = this.Controls.Find("tglDurum", true).FirstOrDefault() as DevExpress.XtraEditors.ToggleSwitch;

            CurrentEntity = new CityDto
            {
                Id = Id,
                Code = txtCode?.Text,
                Title = txtTitle?.Text,
                CountryId = _countryId,
                IsActive = tglActive?.IsOn ?? true
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            var dto = (CityDto)CurrentEntity;
            if (string.IsNullOrWhiteSpace(dto.Code))
            {
                Messages.HataBasligi("Kod alanı (Plaka Kodu) boş geçilemez!", "Doğrulama Hatası");
                return false;
            }

            try
            {
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _cityService.Insert(dto);
                return Id > 0;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            try
            {
                _cityService.Update((CityDto)CurrentEntity);
                return true;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Güncelleme Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Messages.SilMesaj("İl Kaydı") == DialogResult.Yes)
            {
                try
                {
                    _cityService.Delete(Id);
                    Close();
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
            }
        }
    }
}