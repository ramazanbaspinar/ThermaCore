using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using ThermaCore.Presentation.WinForms.UserControls.Controls;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Domain.Helpers;
using ThermaCore.Domain.Extensions;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.TelForms
{
    public partial class TelEditForm : BaseEditForm
    {
        private readonly IWireService _wireService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;

        public TelEditForm()
        {
            InitializeComponent();
        }

        public TelEditForm(
            IWireService wireService,
            IItemBarcodeService itemBarcodeService,
            IUnitRepository unitRepository,
            ISpecialCodeService specialCodeService)
        {
            InitializeComponent();

            _wireService = wireService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = ModuleType.TelTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
            RequiresCodeTemplate = true;

            ucBarkodlar1.InitializeService(itemBarcodeService);
            
            var unitConversionService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Definitions.IUnitConversionService>(Program.ServiceProvider);
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

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Wire");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            cmbTelTipi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _wireService.GetById(Id);
            }
            else
            {
                CurrentEntity = new WireDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (WireDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtTelAdi.Text = dto.Name;

            glufTemelBirim.EditValue = !string.IsNullOrEmpty(dto.BaseUnit) ? dto.BaseUnit : null;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            
            cmbTelTipi.SelectedItem = dto.WireType.HasValue ? dto.WireType.Value.GetDescription() : null;

            txtCap.Value = dto.DiameterMm ?? 0;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPicture("Wire", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.TelTanimlari);
            ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new WireDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtTelAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.Text : "",
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                DiameterMm = txtCap.Value,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn,
                WireType = string.IsNullOrWhiteSpace(cmbTelTipi.Text) ? (WireType?)null : cmbTelTipi.Text.GetEnum<WireType>()
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            ucBarkodlar1.PostGridChanges();

            try
            {
                var dto = (WireDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _wireService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    picResim.SavePicture("Wire", Id);
                    ucBirimCevrimleri1.PostGridChanges();
                    ucBirimCevrimleri1.Kaydet(Id);
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
            ucBarkodlar1.PostGridChanges();

            try
            {
                var dto = (WireDto)CurrentEntity;
                _wireService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                picResim.SavePicture("Wire", Id);
                ucBirimCevrimleri1.PostGridChanges();
                ucBirimCevrimleri1.Kaydet(Id);

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

            var result = Messages.SilMesaj(txtTelAdi.Text);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _wireService.Delete(Id);
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

        protected override void EventsLoad()
        {
            base.EventsLoad();

            cmbTelTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<WireType>().ToArray());

            txtTelAdi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            glufTemelBirim.EditValueChanged += (s, e) => ButonEnabledDurumu();
            glufOzelKod.EditValueChanged += (s, e) => ButonEnabledDurumu();
            cmbTelTipi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            txtCap.EditValueChanged += (s, e) => ButonEnabledDurumu();
            txtAciklama.EditValueChanged += (s, e) => ButonEnabledDurumu();
            tglDurum.EditValueChanged += (s, e) => ButonEnabledDurumu();
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            if (ucBarkodlar1.IsDirty() || picResim.IsDirty() || ucBirimCevrimleri1.IsDirty)
            {
                if (btnKaydet != null && !btnKaydet.Enabled) btnKaydet.Enabled = true;
                if (btnGerial != null && !btnGerial.Enabled) btnGerial.Enabled = true;
            }

            YetkiKontroluYap();
        }

        protected override void FocusControlByPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Code":
                    txtKod.Focus();
                    break;
                case "Name":
                    txtTelAdi.Focus();
                    break;
                case "BaseUnit":
                case "UnitId":
                    glufTemelBirim.Focus();
                    break;
                case "WireType":
                    cmbTelTipi.Focus();
                    break;
                case "DiameterMm":
                    txtCap.Focus();
                    break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _wireService.IsCodeUnique(this.Id, code);
        }
    }
}