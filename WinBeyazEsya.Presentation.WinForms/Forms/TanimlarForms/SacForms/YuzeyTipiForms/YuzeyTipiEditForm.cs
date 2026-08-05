using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.YuzeyTipiForms
{
    public partial class YuzeyTipiEditForm : BaseEditForm
    {
        private readonly ISurfaceTypeService _service;

        public YuzeyTipiEditForm(ISurfaceTypeService service)
        {
            InitializeComponent();
            _service = service;
            
            BaseKartTuru = ModuleType.YuzeyTipiTanimlari;
            DataLayoutControl = myDataLayoutControl1;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _service.GetById(Id);
            }
            else
            {
                CurrentEntity = new SurfaceTypeDto 
                { 
                    IsActive = true 
                };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (SurfaceTypeDto)CurrentEntity;

            txtKod.Text = dto.Code;
            txtYuzeyTipiAdi.Text = dto.Name;
            myMemoEdit1.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new SurfaceTypeDto
            {
                Id = this.Id,
                Code = txtKod.Text,
                Name = txtYuzeyTipiAdi.Text,
                Description = myMemoEdit1.Text,
                IsActive = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            var dto = (SurfaceTypeDto)CurrentEntity;
            dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
            
            Id = _service.Insert(dto);
            return Id > 0;
        }

        protected override bool EntityUpdate()
        {
            var dto = (SurfaceTypeDto)CurrentEntity;
            _service.Update(dto);
            return true;
        }

        protected override bool IsCodeUnique(string code)
        {
            return _service.IsCodeUnique(this.Id, code);
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Messages.SilMesaj("Yüzey Tipi") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _service.Delete(Id);
                    RefreshYapilacak = true;
                    Messages.SilindiMesaj();
                    Close();
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi($"Hata oluştu:\n{ex.Message}", "Hata");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
