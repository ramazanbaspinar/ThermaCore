using System;
using System.Linq;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Domain.Extensions;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.ValfForms
{
    public partial class ValfEditForm : BaseEditForm
    {
        private readonly IValveService _valveService = default!;
        private readonly ThermaCore.Application.Interfaces.Repositories.Definitions.IUnitRepository _unitRepository = default!;
        private readonly ThermaCore.Application.Interfaces.Common.ISpecialCodeService _specialCodeService = default!;

        public ValfEditForm()
        {
            InitializeComponent();
        }

        public ValfEditForm(
            IValveService valveService,
            ThermaCore.Application.Interfaces.Common.IItemBarcodeService itemBarcodeService,
            ThermaCore.Application.Interfaces.Repositories.Definitions.IUnitRepository unitRepository,
            ThermaCore.Application.Interfaces.Common.ISpecialCodeService specialCodeService,
            ThermaCore.Application.Interfaces.Definitions.IUnitConversionService unitConversionService)
        {
            InitializeComponent();

            _valveService = valveService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.ValfTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
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

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(ThermaCore.Domain.Enums.SpecialCodeType.SpecialCode, "Valve");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            cmbValfTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<ThermaCore.Domain.Enums.ValveType>().ToArray());
            cmbGazTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<ThermaCore.Domain.Enums.GasType>().ToArray());

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _valveService.GetById(Id);
            }
            else
            {
                CurrentEntity = new ThermaCore.Application.DTOs.Production.ValveDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (ThermaCore.Application.DTOs.Production.ValveDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtValfAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            cmbValfTipi.SelectedItem = dto.ValveType.HasValue ? ThermaCore.Domain.Extensions.EnumExtensions.ToName(dto.ValveType.Value) : null;
            cmbGazTipi.SelectedItem = dto.GasType.HasValue ? ThermaCore.Domain.Extensions.EnumExtensions.ToName(dto.GasType.Value) : null;
            txtMaksimumBasinc.EditValue = dto.MaxPressureMbar;
            txtBaglantiOlcusu.Text = dto.ConnectionSize;
            txtCalismaSicaklikAraligi.Text = dto.TemperatureRange;

            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPictureAsync("Valve", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ThermaCore.Domain.Enums.ModuleType.ValfTanimlari);
            ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new ThermaCore.Application.DTOs.Production.ValveDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtValfAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null && glufOzelKod.EditValue != DBNull.Value && !string.IsNullOrWhiteSpace(glufOzelKod.EditValue.ToString()) ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                ValveType = string.IsNullOrWhiteSpace(cmbValfTipi.Text) ? (ValveType?)null : cmbValfTipi.Text.GetEnum<ValveType>(),
                GasType = string.IsNullOrWhiteSpace(cmbGazTipi.Text) ? (GasType?)null : cmbGazTipi.Text.GetEnum<GasType>(),
                MaxPressureMbar = txtMaksimumBasinc.EditValue != null && txtMaksimumBasinc.EditValue != DBNull.Value && !string.IsNullOrWhiteSpace(txtMaksimumBasinc.EditValue.ToString()) ? Convert.ToDecimal(txtMaksimumBasinc.EditValue) : (decimal?)null,
                ConnectionSize = txtBaglantiOlcusu.Text,
                TemperatureRange = txtCalismaSicaklikAraligi.Text,
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
                var dto = (ThermaCore.Application.DTOs.Production.ValveDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _valveService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    ucBirimCevrimleri1.Kaydet(Id);
                    picResim.SavePicture("Valve", Id);
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
                ThermaCore.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            ucBarkodlar1.PostGridChanges();
            ucBirimCevrimleri1.PostGridChanges();

            try
            {
                var dto = (ThermaCore.Application.DTOs.Production.ValveDto)CurrentEntity;
                _valveService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                ucBirimCevrimleri1.Kaydet(Id);
                picResim.SavePicture("Valve", Id);

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
                ThermaCore.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (ThermaCore.Presentation.WinForms.Helpers.Messages.SilMesaj("Valf Tanımı") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    _valveService.Delete(Id);
                    RefreshYapilacak = true;
                    ThermaCore.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                    Close();
                }
                catch (System.Exception ex)
                {
                    ThermaCore.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
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
                case "Name": txtValfAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _valveService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;
        }

        private void glufOzelKod_SearchButtonClicked(object? sender, System.EventArgs e)
        {
            var form = new ThermaCore.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(ThermaCore.Domain.Enums.SpecialCodeType.SpecialCode, "Valve");
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(ThermaCore.Domain.Enums.SpecialCodeType.SpecialCode, "Valve");

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        private void glufTemelBirim_SearchButtonClicked(object? sender, System.EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
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