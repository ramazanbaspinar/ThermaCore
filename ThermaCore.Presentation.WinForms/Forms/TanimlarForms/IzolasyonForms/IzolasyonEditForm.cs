using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.IzolasyonForms
{
    public partial class IzolasyonEditForm : BaseEditForm
    {
        private readonly IInsulationService _insulationService = default!;
        private readonly IItemBarcodeService _itemBarcodeService = default!;

        public IzolasyonEditForm()
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _insulationService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<IInsulationService>(Program.ServiceProvider);
                _itemBarcodeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<IItemBarcodeService>(Program.ServiceProvider);
            }

            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
            RequiresCodeTemplate = true;
            BaseKartTuru = ModuleType.IzolasyonTanimlari;

            ucBarkodlar1.InitializeService(_itemBarcodeService);
            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();

            if (ucBirimCevrimleri1 != null && Program.ServiceProvider != null)
            {
                var unitConversionService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Definitions.IUnitConversionService>(Program.ServiceProvider);
                var _unitRepository = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Repositories.Definitions.IUnitRepository>(Program.ServiceProvider);
                ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);
                ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            }
        }

        public override void Yukle()
        {
            var unitRepo = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Repositories.Definitions.IUnitRepository>(Program.ServiceProvider);
            glufTemelBirim.Properties.DataSource = unitRepo.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            var specialCodeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Common.ISpecialCodeService>(Program.ServiceProvider);
            glufOzelKod.Properties.DataSource = specialCodeService.GetCodes(ThermaCore.Domain.Enums.SpecialCodeType.SpecialCode, "Insulation");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            cmbYalitimTipi.Properties.Items.Clear();
            foreach (InsulationType item in Enum.GetValues(typeof(InsulationType)))
            {
                cmbYalitimTipi.Properties.Items.Add(ThermaCore.Domain.Helpers.EnumFunctions.GetDescription(item));
            }

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _insulationService.GetById(Id);
            }
            else
            {
                CurrentEntity = new InsulationDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (InsulationDto)CurrentEntity;
            if (dto == null) return;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtYalitimAdi.Text = dto.Name;
            glufTemelBirim.EditValue = dto.BaseUnit;

            if (dto.InsulationType.HasValue)
                cmbYalitimTipi.EditValue = ThermaCore.Domain.Helpers.EnumFunctions.GetDescription(dto.InsulationType.Value);
            else
                cmbYalitimTipi.EditValue = null;

            txtKalinlik.EditValue = dto.ThicknessMm;
            txtYogunluk.EditValue = dto.Density;
            txtAciklama.Text = dto.Description;
            glufOzelKod.EditValue = dto.SpecialCodeId;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPicture("Insulation", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.IzolasyonTanimlari);

            if (ucBirimCevrimleri1 != null)
            {
                ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new InsulationDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtYalitimAdi.Text,
                BaseUnit = glufTemelBirim.EditValue?.ToString() ?? "",
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };

            if (cmbYalitimTipi.EditValue != null && !string.IsNullOrWhiteSpace(cmbYalitimTipi.EditValue.ToString()))
            {
                string desc = cmbYalitimTipi.EditValue.ToString() ?? "";
                foreach (InsulationType item in Enum.GetValues(typeof(InsulationType)))
                {
                    if (ThermaCore.Domain.Helpers.EnumFunctions.GetDescription(item) == desc)
                    {
                        dto.InsulationType = item;
                        break;
                    }
                }
            }

            if (txtKalinlik.EditValue != null && decimal.TryParse(txtKalinlik.EditValue.ToString(), out decimal thickness))
            {
                dto.ThicknessMm = thickness;
            }

            if (txtYogunluk.EditValue != null && int.TryParse(txtYogunluk.EditValue.ToString(), out int density))
            {
                dto.Density = density;
            }

            if (glufOzelKod.EditValue != null && long.TryParse(glufOzelKod.EditValue.ToString(), out long ozelKodId))
            {
                dto.SpecialCodeId = ozelKodId;
            }

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            ucBarkodlar1.PostGridChanges();

            try
            {
                var dto = (InsulationDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _insulationService.Insert(dto);
                if (Id > 0)
                {
                    txtKod.Text = dto.Code;
                    picResim.SavePicture("Insulation", Id);
                    ucBarkodlar1.Kaydet(Id);
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
            ucBarkodlar1.PostGridChanges();

            try
            {
                var dto = (InsulationDto)CurrentEntity;
                _insulationService.Update(dto);
                picResim.SavePicture("Insulation", Id);
                ucBarkodlar1.Kaydet(Id);
                
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

            if (Messages.SilMesaj("İzolasyon Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _insulationService.Delete(Id);
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
                case "Name": txtYalitimAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _insulationService.IsCodeUnique(this.Id, code);
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
            var form = new ThermaCore.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(ThermaCore.Domain.Enums.SpecialCodeType.SpecialCode, "Insulation");
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            var specialCodeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Common.ISpecialCodeService>(Program.ServiceProvider);
            glufOzelKod.Properties.DataSource = specialCodeService.GetCodes(ThermaCore.Domain.Enums.SpecialCodeType.SpecialCode, "Insulation");
            
            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        private void GlufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                
                var unitRepo = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Repositories.Definitions.IUnitRepository>(Program.ServiceProvider);
                glufTemelBirim.Properties.DataSource = unitRepo.GetAll().Where(x => x.IsActive).ToList();
                
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

            bool isBarkodDirty = ucBarkodlar1 != null && ucBarkodlar1.IsDirty();
            bool isResimDirty = picResim != null && picResim.IsDirty();
            bool isBirimCevrimDirty = ucBirimCevrimleri1 != null && ucBirimCevrimleri1.IsDirty;

            if (isBarkodDirty || isResimDirty || isBirimCevrimDirty)
            {
                if (btnKaydet != null && !btnKaydet.Enabled) btnKaydet.Enabled = true;
                if (btnGerial != null && !btnGerial.Enabled) btnGerial.Enabled = true;
            }

            YetkiKontroluYap();
        }
    }
}