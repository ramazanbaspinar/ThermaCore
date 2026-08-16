using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.IlceTanimForms
{
    public partial class IlceTanimEditForm : BaseEditForm
    {
        private readonly ITownService _townService = default!;
        private long _cityId = 0;

        protected override string CodeControlName => "txtCode"; 

        public IlceTanimEditForm() { InitializeComponent(); }

        public IlceTanimEditForm(ITownService townService)
        {
            InitializeComponent();
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _townService = townService;
                Bll = _townService;
            }
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.Town;
            RequiresCodeTemplate = true;
        }

        public void SetIl(long cityId)
        {
            _cityId = cityId;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                CurrentEntity = new TownDto { IsActive = true, CityId = _cityId };
                Id = BaseIslemTuru.IdOlustur(OldEntity);
            }
            else
            {
                CurrentEntity = _townService.GetById(Id);
                _cityId = ((TownDto)CurrentEntity).CityId;
            }
            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (TownDto)CurrentEntity;
            var txtCode = this.Controls.Find("txtCode", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtTitle = this.Controls.Find("txtName", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var tglActive = this.Controls.Find("tgsIsActive", true).FirstOrDefault() as DevExpress.XtraEditors.ToggleSwitch;

            if (txtCode != null) txtCode.Text = entity.Code;
            if (txtTitle != null) txtTitle.Text = entity.Title;
            if (tglActive != null) tglActive.IsOn = entity.IsActive;

            if (BaseIslemTuru == ActionType.EntityInsert && txtCode != null)
            {
                txtCode.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var txtCode = this.Controls.Find("txtCode", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var txtTitle = this.Controls.Find("txtName", true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            var tglActive = this.Controls.Find("tglDurum", true).FirstOrDefault() as DevExpress.XtraEditors.ToggleSwitch;

            CurrentEntity = new TownDto
            {
                Id = Id,
                Code = txtCode?.Text,
                Title = txtTitle?.Text,
                CityId = _cityId,
                IsActive = tglActive?.IsOn ?? true
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            try
            {
                var dto = (TownDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _townService.Insert(dto);
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
                _townService.Update((TownDto)CurrentEntity);
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
            if (Messages.SilMesaj("İlçe Kaydı") == DialogResult.Yes)
            {
                try
                {
                    _townService.Delete(Id);
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