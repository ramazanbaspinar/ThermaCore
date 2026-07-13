using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Domain.Extensions;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.FanForms
{
    public partial class FanEditForm : BaseEditForm
    {
        private readonly IOvenFanService _ovenFanService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;
        private readonly IServiceProvider _serviceProvider = default!;

        // DevExpress Designer için parametresiz kurucu
        public FanEditForm()
        {
            InitializeComponent();
        }

        // DI Constructor
        public FanEditForm(
            IOvenFanService ovenFanService,
            IUnitRepository unitRepository,
            ISpecialCodeService specialCodeService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _ovenFanService = ovenFanService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;
            _serviceProvider = serviceProvider;
            
            BaseKartTuru = ModuleType.FanTanimlari;
            DataLayoutControl = myDataLayoutControl1;
            RequiresCodeTemplate = true;
            
            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "OvenFan");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            cmbFanTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<FanType>().ToArray());

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                // Senkron DB İşlemi
                CurrentEntity = _ovenFanService.GetById(Id);
            }
            else
            {
                CurrentEntity = new OvenFanDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (OvenFanDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtFanPervaneAdi.Text = dto.Name;
            txtMateryal.Text = dto.Material;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            cmbFanTipi.SelectedItem = dto.FanType.HasValue ? ThermaCore.Domain.Extensions.EnumExtensions.ToName(dto.FanType.Value) : null;

            txtDisCap.EditValue = dto.DiameterMm;
            txtKanatSayisi.EditValue = dto.BladeCount;
            txtMilDelikCapi.EditValue = dto.ShaftHoleMm;

            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                // Sadece burada 1 kere çağrılacak
                picResim.LoadPictureAsync("OvenFan", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new OvenFanDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtFanPervaneAdi.Text,
                Material = txtMateryal.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                FanType = string.IsNullOrWhiteSpace(cmbFanTipi.Text) ? (FanType?)null : cmbFanTipi.Text.GetEnum<FanType>(),
                
                // Tip dönüşümleri (InvalidCastException KESİNLİKLE önlendi)
                DiameterMm = txtDisCap.EditValue != null && txtDisCap.EditValue != DBNull.Value ? Convert.ToDecimal(txtDisCap.EditValue) : (decimal?)null,
                BladeCount = txtKanatSayisi.EditValue != null && txtKanatSayisi.EditValue != DBNull.Value ? Convert.ToInt32(txtKanatSayisi.EditValue) : (int?)null,
                ShaftHoleMm = txtMilDelikCapi.EditValue != null && txtMilDelikCapi.EditValue != DBNull.Value ? Convert.ToDecimal(txtMilDelikCapi.EditValue) : (decimal?)null,
                
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
                var dto = (OvenFanDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _ovenFanService.Insert(dto);

                if (Id > 0)
                {
                    picResim.SavePictureAsync("OvenFan", Id);
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
                var dto = (OvenFanDto)CurrentEntity;
                _ovenFanService.Update(dto);

                picResim.SavePictureAsync("OvenFan", Id);

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

            if (Messages.SilMesaj("Fan / Pervane Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _ovenFanService.Delete(Id);
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
                case "Name": txtFanPervaneAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _ovenFanService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;
        }

        private void glufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new ThermaCore.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "OvenFan");
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "OvenFan");

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        private void glufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                {
                    dynamic secilenBirim = form.SelectedEntities[0];
                    var secilenAd = secilenBirim.Name;
                    glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
                    glufTemelBirim.EditValue = secilenAd;
                }
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            if (picResim.IsDirty())
            {
                if (btnKaydet != null && !btnKaydet.Enabled) btnKaydet.Enabled = true;
                if (btnGerial != null && !btnGerial.Enabled) btnGerial.Enabled = true;
            }
        }

        protected override void LockFormControls(Control.ControlCollection controls)
        {
            base.LockFormControls(controls);
            picResim.SetReadOnly(true);
        }
    }
}