using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Validations.Definitions;
using ThermaCore.Domain.Entities.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms
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
            
            BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.BirimTanimlari;
            DataLayoutControl = myDataLayoutControl1;
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

            // Benzersiz Kod Kontrolü
            if (_unitRepository.Find(x => x.Code == dto.Code).Any())
            {
                XtraMessageBox.Show($"'{dto.Code}' kodlu birim zaten sistemde kayıtlı. Lütfen farklı bir kod giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                XtraMessageBox.Show(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)), "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var entity = new Unit
            {
                Id = BaseIslemTuru.IdOlustur(OldEntity), // ThermaCore ID generator
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

            // Benzersiz Kod Kontrolü (Kendisi hariç)
            if (_unitRepository.Find(x => x.Code == dto.Code && x.Id != dto.Id).Any())
            {
                XtraMessageBox.Show($"'{dto.Code}' kodlu birim zaten sistemde kayıtlı. Lütfen farklı bir kod giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var validationResult = _validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                XtraMessageBox.Show(string.Join("\n", validationResult.Errors.Select(e => e.ErrorMessage)), "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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