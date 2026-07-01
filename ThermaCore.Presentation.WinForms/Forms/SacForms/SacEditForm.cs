using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using ThermaCore.Presentation.WinForms.UserControls.Controls;

namespace ThermaCore.Presentation.WinForms.Forms.SacForms
{
    public partial class SacEditForm : BaseEditForm
    {
        private readonly ISheetMetalService _sheetMetalService = default!;
        private readonly ISheetMetalTypeService _sheetMetalTypeService = default!;
        private readonly IQualityStandardService _qualityStandardService = default!;
        private readonly ISurfaceTypeService _surfaceTypeService = default!;
        private readonly IUnitRepository _unitRepository = default!;

        public SacEditForm()
        {
            InitializeComponent();
        }

        public SacEditForm(
            ISheetMetalService sheetMetalService,
            ISheetMetalTypeService sheetMetalTypeService,
            IQualityStandardService qualityStandardService,
            ISurfaceTypeService surfaceTypeService,
            IUnitRepository unitRepository)
        {
            InitializeComponent();

            _sheetMetalService = sheetMetalService;
            _sheetMetalTypeService = sheetMetalTypeService;
            _qualityStandardService = qualityStandardService;
            _surfaceTypeService = surfaceTypeService;
            _unitRepository = unitRepository;

            BaseKartTuru = ModuleType.SacTanimlari;
            DataLayoutControl = myDataLayoutControl1;
            RequiresCodeTemplate = true;

            picResim.Tag = "Image";
        }

        public override void Yukle()
        {
            glupSacCinsi.Properties.DataSource = _sheetMetalTypeService.GetAll().Where(x => x.IsActive).ToList();
            glupSacCinsi.Properties.DisplayMember = "Name";
            glupSacCinsi.Properties.ValueMember = "Id";

            glupKaliteStandart.Properties.DataSource = _qualityStandardService.GetAll().Where(x => x.IsActive).ToList();
            glupKaliteStandart.Properties.DisplayMember = "Name";
            glupKaliteStandart.Properties.ValueMember = "Id";

            glupYuzeyTip.Properties.DataSource = _surfaceTypeService.GetAll().Where(x => x.IsActive).ToList();
            glupYuzeyTip.Properties.DisplayMember = "Name";
            glupYuzeyTip.Properties.ValueMember = "Id";

            glupBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glupBirim.Properties.DisplayMember = "Name";
            glupBirim.Properties.ValueMember = "Id";

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _sheetMetalService.GetById(Id);
            }
            else
            {
                CurrentEntity = new SheetMetalDto { IsActive = true, Density = 7.85m };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (SheetMetalDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtSacAdi.Text = dto.Name;
            glupSacCinsi.EditValue = dto.SheetMetalTypeId > 0 ? dto.SheetMetalTypeId : null;
            glupKaliteStandart.EditValue = dto.QualityStandardId > 0 ? dto.QualityStandardId : null;
            glupYuzeyTip.EditValue = dto.SurfaceTypeId > 0 ? dto.SurfaceTypeId : null;
            glupBirim.EditValue = dto.UnitId > 0 ? dto.UnitId : null;
            calcKalinlik.Value = dto.Thickness;
            calcOzkutle.Value = dto.Density == 0 ? 7.85m : dto.Density;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;
            picResim.EditValue = dto.Image;

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new SheetMetalDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtSacAdi.Text,
                SheetMetalTypeId = glupSacCinsi.EditValue != null ? Convert.ToInt64(glupSacCinsi.EditValue) : 0,
                QualityStandardId = glupKaliteStandart.EditValue != null ? Convert.ToInt64(glupKaliteStandart.EditValue) : 0,
                SurfaceTypeId = glupYuzeyTip.EditValue != null ? Convert.ToInt64(glupYuzeyTip.EditValue) : 0,
                UnitId = glupBirim.EditValue != null ? Convert.ToInt64(glupBirim.EditValue) : 0,
                Thickness = calcKalinlik.Value,
                Density = calcOzkutle.Value,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn,
                Image = (byte[]?)picResim.EditValue
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            try
            {
                var dto = (SheetMetalDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _sheetMetalService.Insert(dto);
                return Id > 0;
            }
            catch (FluentValidation.ValidationException ex)
            {
                XtraMessageBox.Show(string.Join("\n", ex.Errors.Select(e => e.ErrorMessage)), "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
                var dto = (SheetMetalDto)CurrentEntity;
                _sheetMetalService.Update(dto);
                return true;
            }
            catch (FluentValidation.ValidationException ex)
            {
                XtraMessageBox.Show(string.Join("\n", ex.Errors.Select(e => e.ErrorMessage)), "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _sheetMetalService.IsCodeUnique(this.Id, code);
        }
    }
}