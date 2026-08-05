using System;
using System.Linq;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Production;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TermokuplForms
{
    public partial class TermokuplEditForm : BaseEditForm
    {
        private readonly IThermocoupleService _thermocoupleService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository _unitRepository = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService _specialCodeService = default!;
        private readonly IRepository<Thermocouple> _repository = default!;

        public TermokuplEditForm()
        {
            InitializeComponent();
        }

        public TermokuplEditForm(
            IThermocoupleService thermocoupleService,
            WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService itemBarcodeService,
            WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository unitRepository,
            WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService specialCodeService,
            IRepository<Thermocouple> repository,
            WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService unitConversionService)
        {
            InitializeComponent();

            _thermocoupleService = thermocoupleService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;
            _repository = repository;

            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.TermokuplTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3 };
            RequiresCodeTemplate = true;

            ucBarkodlar1.InitializeService(itemBarcodeService);
            ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);
            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Thermocouple");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _thermocoupleService.GetById(Id);
            }
            else
            {
                CurrentEntity = new WinBeyazEsya.Application.DTOs.Production.ThermocoupleDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (WinBeyazEsya.Application.DTOs.Production.ThermocoupleDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtTermokuplAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            txtUzunluk.EditValue = dto.LengthMm;
            txtKafaTipi.Text = dto.HeadType;
            txtUcTipi.Text = dto.TipType;

            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPictureAsync("Thermocouple", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, WinBeyazEsya.Domain.Enums.ModuleType.TermokuplTanimlari);
            ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new WinBeyazEsya.Application.DTOs.Production.ThermocoupleDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtTermokuplAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null && glufOzelKod.EditValue != DBNull.Value && !string.IsNullOrWhiteSpace(glufOzelKod.EditValue.ToString()) ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                LengthMm = txtUzunluk.EditValue != null && txtUzunluk.EditValue != DBNull.Value && !string.IsNullOrWhiteSpace(txtUzunluk.EditValue.ToString()) ? Convert.ToDecimal(txtUzunluk.EditValue) : (decimal?)null,
                HeadType = txtKafaTipi.Text,
                TipType = txtUcTipi.Text,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            ucBarkodlar1.PostGridChanges();
            ucBirimCevrimleri1.PostGridChanges();

            try
            {
                var dto = (WinBeyazEsya.Application.DTOs.Production.ThermocoupleDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                var newDto = _thermocoupleService.Add(dto);
                Id = newDto.Id;

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    ucBirimCevrimleri1.Kaydet(Id);
                    picResim.SavePicture("Thermocouple", Id);
                }

                return Id > 0;
            }
            catch (FluentValidation.ValidationException ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(string.Join("\n", ex.Errors.Select(e => e.ErrorMessage)), "Doğrulama Hatası", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
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
            ucBarkodlar1.PostGridChanges();
            ucBirimCevrimleri1.PostGridChanges();

            try
            {
                var dto = (WinBeyazEsya.Application.DTOs.Production.ThermocoupleDto)CurrentEntity;
                _thermocoupleService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                ucBirimCevrimleri1.Kaydet(Id);
                picResim.SavePicture("Thermocouple", Id);

                return true;
            }
            catch (FluentValidation.ValidationException ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(string.Join("\n", ex.Errors.Select(e => e.ErrorMessage)), "Doğrulama Hatası", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
            catch (System.Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj("Termokupl (Emniyet) Tanımı") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    _thermocoupleService.Delete(Id);
                    RefreshYapilacak = true;
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                    Close();
                }
                catch (System.Exception ex)
                {
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
            }
        }

        protected override void FocusControlByPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Code": txtKod.Focus(); break;
                case "Name": txtTermokuplAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            var existing = _repository.Find(x => x.Code == code).FirstOrDefault();
            return existing == null || existing.Id == this.Id;
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;
        }

        private void glufOzelKod_SearchButtonClicked(object? sender, System.EventArgs e)
        {
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Thermocouple");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Thermocouple");

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        private void glufTemelBirim_SearchButtonClicked(object? sender, System.EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            if (form != null)
            {
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                
                glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK && form.SelectedEntities?.Count > 0)
                {
                    dynamic secilenBirim = form.SelectedEntities[0];
                    var secilenAd = secilenBirim.Name;
                    glufTemelBirim.EditValue = secilenAd;
                }
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            if (ucBarkodlar1.IsDirty() || ucBirimCevrimleri1.IsDirty || picResim.IsDirty())
            {
                if (btnKaydet != null && !btnKaydet.Enabled) btnKaydet.Enabled = true;
                if (btnGerial != null && !btnGerial.Enabled) btnGerial.Enabled = true;
            }

            YetkiKontroluYap();
        }

        protected override void LockFormControls(System.Windows.Forms.Control.ControlCollection controls)
        {
            base.LockFormControls(controls);
            picResim.SetReadOnly(true);
        }
    }
}
