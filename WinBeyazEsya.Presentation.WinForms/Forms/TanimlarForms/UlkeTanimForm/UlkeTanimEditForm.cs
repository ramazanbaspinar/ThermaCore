using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.UlkeTanimForm
{
    public partial class UlkeTanimEditForm : BaseEditForm
    {
        private readonly ICountryService _countryService = default!;

        public UlkeTanimEditForm()
        {
            InitializeComponent();
        }

        public UlkeTanimEditForm(ICountryService countryService)
        {
            InitializeComponent();
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _countryService = countryService;
                Bll = _countryService;
            }

            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.Country;
            RequiresCodeTemplate = true;
            DataLayoutControls = new object[] { myDataLayoutControl1 };
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                CurrentEntity = new CountryDto { IsActive = true };
            }
            else
            {
                CurrentEntity = _countryService.GetById(Id);
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (CountryDto)CurrentEntity;

            txtKod.Text = entity.Code;
            txtUlkeAdi.Text = entity.Title;
            tglDurum.IsOn = entity.IsActive;

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new CountryDto
            {
                Id = Id,
                Code = txtKod.Text,
                Title = txtUlkeAdi.Text,
                IsActive = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            try
            {
                var dto = (CountryDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _countryService.Insert(dto);
                return Id > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            try
            {
                _countryService.Update((CountryDto)CurrentEntity);
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Helpers.Messages.HataBasligi(msg, "Güncelleme Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Helpers.Messages.SilMesaj("Ülke Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _countryService.Delete(Id);
                    RefreshYapilacak = true;
                    Helpers.Messages.SilindiMesaj();
                    Close();
                }
                catch (Exception ex)
                {
                    Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
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
                case "Code": txtKod.Focus(); break;
                case "Title": txtUlkeAdi.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _countryService.IsCodeUnique(this.Id, code);
        }
    }
}