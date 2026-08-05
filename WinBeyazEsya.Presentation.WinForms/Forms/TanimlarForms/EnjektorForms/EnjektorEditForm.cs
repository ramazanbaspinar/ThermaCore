using System;
using System.Linq;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Extensions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.EnjektorForms
{
    public partial class EnjektorEditForm : BaseEditForm
    {
        private readonly IInjectorService _injectorService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository _unitRepository = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService _specialCodeService = default!;

        public EnjektorEditForm()
        {
            InitializeComponent();
        }

        public EnjektorEditForm(
            IInjectorService injectorService,
            WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService itemBarcodeService,
            WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository unitRepository,
            WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService specialCodeService,
            WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService unitConversionService)
        {
            InitializeComponent();

            _injectorService = injectorService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.EnjektorTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
            RequiresCodeTemplate = true;

            ucBarkodlar1.InitializeService(itemBarcodeService);
            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);
            ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Injector");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            cmbGazTipi.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<WinBeyazEsya.Domain.Enums.GasType>().ToArray());

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _injectorService.GetById(Id);
            }
            else
            {
                CurrentEntity = new WinBeyazEsya.Application.DTOs.Production.InjectorDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (WinBeyazEsya.Application.DTOs.Production.InjectorDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtEnjektorAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            cmbGazTipi.SelectedItem = dto.GasType.HasValue ? WinBeyazEsya.Domain.Extensions.EnumExtensions.ToName(dto.GasType.Value) : null;
            txtUygunlukBekTipi.Text = dto.TargetBurner;
            txtDisOlcusu.Text = dto.ThreadSize;
            txtDelikCapi.EditValue = dto.HoleDiameterMm;

            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPictureAsync("Injector", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, WinBeyazEsya.Domain.Enums.ModuleType.EnjektorTanimlari);
            ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new WinBeyazEsya.Application.DTOs.Production.InjectorDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtEnjektorAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null && glufOzelKod.EditValue != DBNull.Value && !string.IsNullOrWhiteSpace(glufOzelKod.EditValue.ToString()) ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                GasType = string.IsNullOrWhiteSpace(cmbGazTipi.Text) ? (GasType?)null : cmbGazTipi.Text.GetEnum<GasType>(),
                TargetBurner = txtUygunlukBekTipi.Text,
                ThreadSize = txtDisOlcusu.Text,
                HoleDiameterMm = txtDelikCapi.EditValue != null && txtDelikCapi.EditValue != DBNull.Value && !string.IsNullOrWhiteSpace(txtDelikCapi.EditValue.ToString()) ? Convert.ToDecimal(txtDelikCapi.EditValue) : (decimal?)null,
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
                var dto = (WinBeyazEsya.Application.DTOs.Production.InjectorDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _injectorService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    ucBirimCevrimleri1.Kaydet(Id);
                    picResim.SavePicture("Injector", Id);
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
                var dto = (WinBeyazEsya.Application.DTOs.Production.InjectorDto)CurrentEntity;
                _injectorService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                ucBirimCevrimleri1.Kaydet(Id);
                picResim.SavePicture("Injector", Id);

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

            if (WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj("Enjektör Tanımı") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    _injectorService.Delete(Id);
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
                case "Name": txtEnjektorAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _injectorService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;
        }

        private void glufOzelKod_SearchButtonClicked(object? sender, System.EventArgs e)
        {
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Injector");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Injector");

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

            if (ucBarkodlar1.IsDirty() || picResim.IsDirty() || ucBirimCevrimleri1.IsDirty)
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
