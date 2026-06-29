using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.SacCinsiForms
{
    public partial class SacCinsiEditForm : BaseEditForm
    {
        private readonly ISheetMetalTypeService _service;

        public SacCinsiEditForm(ISheetMetalTypeService service)
        {
            InitializeComponent();
            _service = service;
            
            BaseKartTuru = ModuleType.SacCinsiTanimlari;
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
                CurrentEntity = new SheetMetalTypeDto 
                { 
                    IsActive = true 
                };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (SheetMetalTypeDto)CurrentEntity;

            txtKod.Text = dto.Code;
            txtSacCinsiAdi.Text = dto.Name;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new SheetMetalTypeDto
            {
                Id = this.Id,
                Code = txtKod.Text,
                Name = txtSacCinsiAdi.Text,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            var dto = (SheetMetalTypeDto)CurrentEntity;
            dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
            
            Id = _service.Insert(dto);
            return Id > 0;
        }

        protected override bool EntityUpdate()
        {
            var dto = (SheetMetalTypeDto)CurrentEntity;
            _service.Update(dto);
            return true;
        }

        protected override bool IsCodeUnique(string code)
        {
            return _service.IsCodeUnique(this.Id, code);
        }
    }
}