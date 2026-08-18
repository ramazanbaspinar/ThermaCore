using DevExpress.XtraEditors;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms
{
    public partial class BirimEditForm : BaseEditForm
    {
        private readonly IUnitRepository _unitRepository = default!;
        private readonly IUnitOfWork _uow = default!;
        private readonly FluentValidation.IValidator<UnitDto> _validator = default!;

        public BirimEditForm()
        {
            InitializeComponent();
        }

        public BirimEditForm(IUnitRepository unitRepository, IUnitOfWork uow, FluentValidation.IValidator<UnitDto> validator)
        {
            InitializeComponent();
            _unitRepository = unitRepository;
            _uow = uow;
            _validator = validator;

            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.BirimTanimlari;
            DataLayoutControl = myDataLayoutControlPro1;
            RequiresCodeTemplate = false;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var unit = _unitRepository.GetById(Id);
                if (unit != null)
                {
                    txtKod.Text = unit.Code;
                    txtBirimAdi.Text = unit.Name;
                    txtAciklama.Text = unit.Description;
                    tglDurum.IsOn = unit.IsActive;
                }
            }
            else
            {
                txtKod.Text = "";
                txtBirimAdi.Text = "";
                txtAciklama.Text = "";
                tglDurum.IsOn = true;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new UnitDto
            {
                Id = this.Id,
                Code = txtKod.Text,
                Name = txtBirimAdi.Text,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            var dto = (UnitDto)CurrentEntity;

            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                XtraMessageBox.Show(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)), "Doðrulama Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var entity = new Unit
            {
                Id = BaseIslemTuru.IdOlustur(OldEntity), // WinBeyazEsya ID generator
                Code = dto.Code,
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.IsActive
            };

            _unitRepository.Add(entity);
            _uow.SaveChanges();
            Id = entity.Id;

            return true;
        }

        protected override bool EntityUpdate()
        {
            var dto = (UnitDto)CurrentEntity;

            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                XtraMessageBox.Show(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)), "Doðrulama Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var entity = _unitRepository.GetById(Id);
            if (entity != null)
            {
                entity.Code = dto.Code;
                entity.Name = dto.Name;
                entity.Description = dto.Description;
                entity.IsActive = dto.IsActive;

                _unitRepository.Update(entity);
                _uow.SaveChanges();
            }

            return true;
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Messages.SilMesaj("Birim") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var entity = _unitRepository.GetById(Id);
                    if (entity != null)
                    {
                        _unitRepository.Remove(entity);
                        _uow.SaveChanges();
                        RefreshYapilacak = true;
                        Messages.SilindiMesaj();
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi($"Hata oluþtu:\n{ex.Message}", "Hata");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}

