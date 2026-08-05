using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinBeyazEsya.Domain.Helpers;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.ContaForms
{
    public partial class ContaEditForm : BaseEditForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IGasketService _gasketService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository _unitRepository = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService _specialCodeService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService _itemBarcodeService = default!;

        public ContaEditForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _gasketService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Application.Interfaces.Definitions.IGasketService>(Program.ServiceProvider);
                _unitRepository = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository>(Program.ServiceProvider);
                _specialCodeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService>(Program.ServiceProvider);
                _itemBarcodeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService>(Program.ServiceProvider);

                BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.ContaTanimlari;
                DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
                RequiresCodeTemplate = true;

                ucBarkodlar1.InitializeService(_itemBarcodeService);
                ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();

                var unitConversionService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService>(Program.ServiceProvider);
                ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);
                ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            }
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Gasket");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            cmbContaMalzemesi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            cmbContaMalzemesi.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<WinBeyazEsya.Domain.Enums.GasketMaterialType>().ToArray());

            if (BaseIslemTuru == WinBeyazEsya.Domain.Enums.ActionType.EntityUpdate)
            {
                CurrentEntity = _gasketService.GetById(Id);
            }
            else
            {
                CurrentEntity = new WinBeyazEsya.Application.DTOs.Definitions.GasketDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (WinBeyazEsya.Application.DTOs.Definitions.GasketDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtContaAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            
            cmbContaMalzemesi.SelectedItem = dto.MaterialType.HasValue ? dto.MaterialType.Value.GetDescription() : null;
            
            txtIsiDayanimi.EditValue = dto.HeatResistance;
            txtUzunluk.EditValue = dto.LengthMm;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPicture("Gasket", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == WinBeyazEsya.Domain.Enums.ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, WinBeyazEsya.Domain.Enums.ModuleType.ContaTanimlari);
            ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            long? specialCodeId = null;
            if (glufOzelKod.EditValue != null && long.TryParse(glufOzelKod.EditValue.ToString(), out long scId))
            {
                specialCodeId = scId;
            }

            int? heatResistance = null;
            if (txtIsiDayanimi.EditValue != null && txtIsiDayanimi.EditValue != DBNull.Value && int.TryParse(txtIsiDayanimi.EditValue.ToString(), out int hr))
            {
                heatResistance = hr;
            }

            decimal? lengthMm = null;
            if (txtUzunluk.EditValue != null && txtUzunluk.EditValue != DBNull.Value && decimal.TryParse(txtUzunluk.EditValue.ToString(), out decimal len))
            {
                lengthMm = len;
            }

            var dto = new WinBeyazEsya.Application.DTOs.Definitions.GasketDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtContaAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                MaterialType = string.IsNullOrWhiteSpace(cmbContaMalzemesi.Text) ? (WinBeyazEsya.Domain.Enums.GasketMaterialType?)null : WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnum<WinBeyazEsya.Domain.Enums.GasketMaterialType>(cmbContaMalzemesi.Text),
                HeatResistance = heatResistance,
                LengthMm = lengthMm,
                Description = txtAciklama.Text,
                SpecialCodeId = specialCodeId,
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
                var dto = (WinBeyazEsya.Application.DTOs.Definitions.GasketDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _gasketService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    picResim.SavePicture("Gasket", Id);
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
                var dto = (WinBeyazEsya.Application.DTOs.Definitions.GasketDto)CurrentEntity;
                _gasketService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                picResim.SavePicture("Gasket", Id);
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
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj("Conta Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _gasketService.Delete(Id);
                    RefreshYapilacak = true;
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                    Close();
                }
                catch (Exception ex)
                {
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
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
                case "Name": txtContaAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _gasketService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            if (glufOzelKod != null)
                glufOzelKod.SearchButtonClicked += GlufOzelKod_SearchButtonClicked;

            if (glufTemelBirim != null)
                glufTemelBirim.SearchButtonClicked += GlufTemelBirim_SearchButtonClicked;
        }

        private void GlufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Gasket");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Gasket");

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        private void GlufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>(Program.ServiceProvider);
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

            if (ucBarkodlar1.IsDirty() || picResim.IsDirty() || ucBirimCevrimleri1.IsDirty)
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
