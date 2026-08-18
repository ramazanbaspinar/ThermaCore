using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DepoTanimForms
{
    public partial class DepoTanimEditForm : BaseEditForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IWarehouseService? _warehouseService;
        private WinBeyazEsya.Application.DTOs.Definitions.WarehouseDto _currentDto = new WinBeyazEsya.Application.DTOs.Definitions.WarehouseDto();

        public DepoTanimEditForm(WinBeyazEsya.Application.Interfaces.Definitions.IWarehouseService? warehouseService = null)
        {
            InitializeComponent();
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.Warehouse;
            RequiresCodeTemplate = true;
            _warehouseService = warehouseService;
            Bll = _warehouseService;
            DataLayoutControl = myDataLayoutControl1;

            EventsLoad();
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == WinBeyazEsya.Domain.Enums.ActionType.EntityInsert)
                CurrentEntity = new WinBeyazEsya.Application.DTOs.Definitions.WarehouseDto { IsActive = true };
            else
                CurrentEntity = _warehouseService?.GetById(Id);

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (WinBeyazEsya.Application.DTOs.Definitions.WarehouseDto)CurrentEntity;
            if (entity == null) return;

            txtKod.Text = entity.Code;
            txtDepoAdi.Text = entity.Name;
            txtYetkili.Text = entity.AuthorizedPerson;
            txtAciklama.Text = entity.Description;
            tglDurum.IsOn = entity.IsActive;

            if (BaseIslemTuru == WinBeyazEsya.Domain.Enums.ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new WinBeyazEsya.Application.DTOs.Definitions.WarehouseDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtDepoAdi.Text,
                AuthorizedPerson = txtYetkili.Text,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            if (_warehouseService == null) return false;
            try
            {
                var dto = (WinBeyazEsya.Application.DTOs.Definitions.WarehouseDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _warehouseService.Insert(dto);
                return Id > 0;
            }
            catch (System.Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            if (_warehouseService == null) return false;
            try
            {
                var dto = (WinBeyazEsya.Application.DTOs.Definitions.WarehouseDto)CurrentEntity;
                _warehouseService.Update(dto);
                return true;
            }
            catch (System.Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Güncelleme Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0 || _warehouseService == null) return;

            if (WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj("Depo Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _warehouseService.Delete(Id);
                    RefreshYapilacak = true;
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                    Close();
                }
                catch (System.Exception ex)
                {
                    string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Silme Hatası");
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
                case "Name": txtDepoAdi.Focus(); break;
                case "AuthorizedPerson": txtYetkili.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            if (_warehouseService == null) return true;
            return _warehouseService.IsCodeUnique(this.Id, code);
        }
    }
}