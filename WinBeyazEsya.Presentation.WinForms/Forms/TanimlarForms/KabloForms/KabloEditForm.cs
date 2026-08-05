using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using WinBeyazEsya.Application.Interfaces.Common;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KabloForms
{
    public partial class KabloEditForm : BaseEditForm
    {
        private readonly ICableService _cableService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;

        public KabloEditForm()
        {
            InitializeComponent();
        }

        public KabloEditForm(
            ICableService cableService,
            IUnitRepository unitRepository,
            ISpecialCodeService specialCodeService)
        {
            InitializeComponent();

            _cableService = cableService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = ModuleType.KabloTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
            RequiresCodeTemplate = true;

            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();

            if (ucBirimCevrimleri1 != null && Program.ServiceProvider != null)
            {
                var unitConversionService = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService>();
                ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);
                ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            }
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Cable");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            // Kablo Tipleri
            cmbKabloTipi.Properties.Items.Clear();
            cmbKabloTipi.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<CableType>().ToArray());

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _cableService.GetById(Id);
            }
            else
            {
                CurrentEntity = new CableDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (CableDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtKabloAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            
            if (dto.CableType.HasValue)
                cmbKabloTipi.SelectedItem = dto.CableType.Value.ToName();
            else
                cmbKabloTipi.SelectedItem = null;

            txtKesitAlani.Text = dto.CrossSection;
            
            if (dto.LengthMm.HasValue)
                txtUzunluk.EditValue = dto.LengthMm.Value;
            else
                txtUzunluk.EditValue = null;

            if (dto.MaxTemperature.HasValue)
                txtIsiDayanimi.EditValue = dto.MaxTemperature.Value;
            else
                txtIsiDayanimi.EditValue = null;

            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPictureAsync("Cable", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            if (ucBirimCevrimleri1 != null)
            {
                ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new CableDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtKabloAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                CableType = string.IsNullOrWhiteSpace(cmbKabloTipi.Text) ? (CableType?)null : cmbKabloTipi.Text.GetEnum<CableType>(),
                CrossSection = txtKesitAlani.Text,
                LengthMm = txtUzunluk.EditValue != null && txtUzunluk.EditValue != DBNull.Value ? Convert.ToDecimal(txtUzunluk.EditValue) : (decimal?)null,
                MaxTemperature = txtIsiDayanimi.EditValue != null && txtIsiDayanimi.EditValue != DBNull.Value ? Convert.ToInt32(txtIsiDayanimi.EditValue) : (int?)null,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            try
            {
                var dto = (CableDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _cableService.Insert(dto);

                if (Id > 0)
                {
                    picResim.SavePictureAsync("Cable", Id);
                    if (ucBirimCevrimleri1 != null)
                    {
                        ucBirimCevrimleri1.PostGridChanges();
                        ucBirimCevrimleri1.Kaydet(Id);
                    }
                }

                return Id > 0;
            }
            catch (FluentValidation.ValidationException ex)
            {
                XtraMessageBox.Show(string.Join("\n", ex.Errors.Select(e => e.ErrorMessage)), "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            try
            {
                var dto = (CableDto)CurrentEntity;
                _cableService.Update(dto);

                picResim.SavePictureAsync("Cable", Id);

                if (ucBirimCevrimleri1 != null)
                {
                    ucBirimCevrimleri1.PostGridChanges();
                    ucBirimCevrimleri1.Kaydet(Id);
                }

                return true;
            }
            catch (FluentValidation.ValidationException ex)
            {
                XtraMessageBox.Show(string.Join("\n", ex.Errors.Select(e => e.ErrorMessage)), "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Messages.SilMesaj("Kablo Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _cableService.Delete(Id);
                    RefreshYapilacak = true;
                    Messages.SilindiMesaj();
                    Close();
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi(ex.Message, "Silme Hatası");
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
                case "Name": txtKabloAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _cableService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;
        }

        private void glufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "Cable");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Cable");

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        private void glufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            if (form != null)
            {
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                
                    glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
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

            bool isResimDirty = picResim != null && picResim.IsDirty();
            bool isBirimCevrimDirty = ucBirimCevrimleri1 != null && ucBirimCevrimleri1.IsDirty;

            if (isResimDirty || isBirimCevrimDirty)
            {
                if (btnKaydet != null && !btnKaydet.Enabled) btnKaydet.Enabled = true;
                if (btnGerial != null && !btnGerial.Enabled) btnGerial.Enabled = true;
            }

            YetkiKontroluYap();
        }

        protected override void LockFormControls(Control.ControlCollection controls)
        {
            base.LockFormControls(controls);
            picResim.SetReadOnly(true);
        }
    }
}
