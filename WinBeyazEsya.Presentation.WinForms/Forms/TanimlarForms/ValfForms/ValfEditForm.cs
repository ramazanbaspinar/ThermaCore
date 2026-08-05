using System;
using System.Linq;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Extensions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ValfForms
{
    public partial class ValfEditForm : BaseEditForm
    {
        private readonly IValveService _valveService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository _unitRepository = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService _specialCodeService = default!;

        public ValfEditForm()
        {
            InitializeComponent();
        }

        public ValfEditForm(
            IValveService valveService,
            WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService itemBarcodeService,
            WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository unitRepository,
            WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService specialCodeService,
            WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService unitConversionService)
        {
            InitializeComponent();

            _valveService = valveService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.ValfTanimlari;
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

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Valve");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            cmbValfTipi.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<WinBeyazEsya.Domain.Enums.ValveType>().ToArray());
            cmbGazTipi.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<WinBeyazEsya.Domain.Enums.GasType>().ToArray());

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _valveService.GetById(Id);
            }
            else
            {
                CurrentEntity = new WinBeyazEsya.Application.DTOs.Production.ValveDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (WinBeyazEsya.Application.DTOs.Production.ValveDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtValfAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            cmbValfTipi.SelectedItem = dto.ValveType.HasValue ? WinBeyazEsya.Domain.Extensions.EnumExtensions.ToName(dto.ValveType.Value) : null;
            cmbGazTipi.SelectedItem = dto.GasType.HasValue ? WinBeyazEsya.Domain.Extensions.EnumExtensions.ToName(dto.GasType.Value) : null;
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

            ucBarkodlar1.Yukle(Id, txtKod.Text, WinBeyazEsya.Domain.Enums.ModuleType.ValfTanimlari);
            ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new WinBeyazEsya.Application.DTOs.Production.ValveDto
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
                var dto = (WinBeyazEsya.Application.DTOs.Production.ValveDto)CurrentEntity;
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
                var dto = (WinBeyazEsya.Application.DTOs.Production.ValveDto)CurrentEntity;
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
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj("Valf Tanımı") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    _valveService.Delete(Id);
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
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Valve");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Valve");

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
