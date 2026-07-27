using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Domain.Helpers;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.GazBorusuForms
{
    public partial class GazBorusuEditForm : BaseEditForm
    {
        private readonly IGasPipeService _service;
        private readonly ThermaCore.Application.Interfaces.Repositories.Definitions.IUnitRepository _unitRepository;
        private readonly ThermaCore.Application.Interfaces.Common.ISpecialCodeService _specialCodeService;
        private readonly ThermaCore.Application.Interfaces.Common.IItemBarcodeService _itemBarcodeService;

        public GazBorusuEditForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _service = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<IGasPipeService>(Program.ServiceProvider);
                _unitRepository = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Repositories.Definitions.IUnitRepository>(Program.ServiceProvider);
                _specialCodeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Common.ISpecialCodeService>(Program.ServiceProvider);
                _itemBarcodeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Common.IItemBarcodeService>(Program.ServiceProvider);
                
                BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.GazBorusuTanimlari;
                RequiresCodeTemplate = true;
                
                DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };

                ucBarkodlar1.InitializeService(_itemBarcodeService);
                ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();

                if (ucBirimCevrimleri1 != null)
                {
                    var unitConversionService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Application.Interfaces.Definitions.IUnitConversionService>(Program.ServiceProvider);
                    ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);
                    ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                }
            }
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            if (glufOzelKod != null)
                glufOzelKod.SearchButtonClicked += GlufOzelKod_SearchButtonClicked;
            
            if (glufTemelBirim != null)
                glufTemelBirim.SearchButtonClicked += GlufTemelBirim_SearchButtonClicked;
                
            cmbBoruTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<ThermaCore.Domain.Enums.PipeType>().ToArray());
            cmbGazTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<ThermaCore.Domain.Enums.GasType>().ToArray());
        }

        private void GlufTemelBirim_SearchButtonClicked(object sender, EventArgs e)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>(Program.ServiceProvider);
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

        private void GlufOzelKod_SearchButtonClicked(object sender, EventArgs e)
        {
            var form = new Forms.OzelKodForms.OzelKodListForm(ThermaCore.Domain.Enums.SpecialCodeType.SpecialCode, "GasPipe");
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();
            
            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(ThermaCore.Domain.Enums.SpecialCodeType.SpecialCode, "GasPipe");

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        public override void Yukle()
        {
            if (glufTemelBirim != null)
            {
                glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
                glufTemelBirim.Properties.DisplayMember = "Name";
                glufTemelBirim.Properties.ValueMember = "Name";
            }

            if (glufOzelKod != null)
            {
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(ThermaCore.Domain.Enums.SpecialCodeType.SpecialCode, "GasPipe");
                glufOzelKod.Properties.DisplayMember = "Code";
                glufOzelKod.Properties.ValueMember = "Id";
            }

            if (BaseIslemTuru == ThermaCore.Domain.Enums.ActionType.EntityUpdate)
            {
                var dto = _service.GetById(Id);
                CurrentEntity = dto ?? new ThermaCore.Application.DTOs.Production.GasPipeDto { IsActive = true };
            }
            else
            {
                CurrentEntity = new ThermaCore.Application.DTOs.Production.GasPipeDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (ThermaCore.Application.DTOs.Production.GasPipeDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtGazBorusuAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            txtBoruCapi.Text = dto.Diameter;
            txtUzunluk.EditValue = dto.LengthMm;
            txtBransmanCikisSayisi.EditValue = dto.BranchCount;
            
            cmbBoruTipi.SelectedItem = dto.PipeType.HasValue ? dto.PipeType.Value.GetDescription() : null;
            cmbGazTipi.SelectedItem = dto.GasType.HasValue ? dto.GasType.Value.GetDescription() : null;
            
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPicture("GasPipe", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ThermaCore.Domain.Enums.ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
            
            ucBarkodlar1.Yukle(Id, txtKod.Text, ThermaCore.Domain.Enums.ModuleType.GazBorusuTanimlari);

            if (ucBirimCevrimleri1 != null)
            {
                ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new ThermaCore.Application.DTOs.Production.GasPipeDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtGazBorusuAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null && glufOzelKod.EditValue != DBNull.Value && !string.IsNullOrWhiteSpace(glufOzelKod.EditValue.ToString()) ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                Diameter = txtBoruCapi.Text,
                LengthMm = txtUzunluk.EditValue != null && txtUzunluk.EditValue != DBNull.Value ? Convert.ToDecimal(txtUzunluk.EditValue) : null,
                BranchCount = txtBransmanCikisSayisi.EditValue != null && txtBransmanCikisSayisi.EditValue != DBNull.Value ? Convert.ToInt32(txtBransmanCikisSayisi.EditValue) : null,
                PipeType = string.IsNullOrWhiteSpace(cmbBoruTipi.Text) ? (ThermaCore.Domain.Enums.PipeType?)null : cmbBoruTipi.Text.GetEnum<ThermaCore.Domain.Enums.PipeType>(),
                GasType = string.IsNullOrWhiteSpace(cmbGazTipi.Text) ? (ThermaCore.Domain.Enums.GasType?)null : cmbGazTipi.Text.GetEnum<ThermaCore.Domain.Enums.GasType>(),
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            ucBarkodlar1.PostGridChanges();

            try
            {
                var dto = (ThermaCore.Application.DTOs.Production.GasPipeDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _service.Insert(dto);
                
                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    picResim.SavePicture("GasPipe", Id);
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
                DevExpress.XtraEditors.XtraMessageBox.Show(string.Join("\n", ex.Errors.Select(e => e.ErrorMessage)), "Doğrulama Hatası", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ThermaCore.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            ucBarkodlar1.PostGridChanges();

            try
            {
                var dto = (ThermaCore.Application.DTOs.Production.GasPipeDto)CurrentEntity;
                _service.Update(dto);
                
                ucBarkodlar1.Kaydet(Id);
                picResim.SavePicture("GasPipe", Id);
                
                if (ucBirimCevrimleri1 != null)
                {
                    ucBirimCevrimleri1.PostGridChanges();
                    ucBirimCevrimleri1.Kaydet(Id);
                }

                return true;
            }
            catch (FluentValidation.ValidationException ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(string.Join("\n", ex.Errors.Select(e => e.ErrorMessage)), "Doğrulama Hatası", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                ThermaCore.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (ThermaCore.Presentation.WinForms.Helpers.Messages.SilMesaj("Gaz Borusu") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _service.Delete(Id);
                    RefreshYapilacak = true;
                    ThermaCore.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                    Close();
                }
                catch (Exception ex)
                {
                    ThermaCore.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
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
                case "Name": txtGazBorusuAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _service.IsCodeUnique(this.Id, code);
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

        protected override void LockFormControls(System.Windows.Forms.Control.ControlCollection controls)
        {
            base.LockFormControls(controls);
            picResim.SetReadOnly(true);
        }
    }
}