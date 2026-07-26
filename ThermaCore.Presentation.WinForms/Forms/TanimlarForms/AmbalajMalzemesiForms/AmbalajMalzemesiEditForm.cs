using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Domain.Extensions;
using ThermaCore.Domain.Helpers;
using ThermaCore.Presentation.WinForms.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.AmbalajMalzemesiForms
{
    public partial class AmbalajMalzemesiEditForm : BaseEditForm
    {
        private readonly IPackagingMaterialService _packagingMaterialService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;
        private readonly IItemBarcodeService _itemBarcodeService = default!;

        public AmbalajMalzemesiEditForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _packagingMaterialService = Program.ServiceProvider.GetRequiredService<IPackagingMaterialService>();
                _unitRepository = Program.ServiceProvider.GetRequiredService<IUnitRepository>();
                _specialCodeService = Program.ServiceProvider.GetRequiredService<ISpecialCodeService>();
                _itemBarcodeService = Program.ServiceProvider.GetRequiredService<IItemBarcodeService>();

                BaseKartTuru = ModuleType.AmbalajMalzemesiTanimlari;
                DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
                RequiresCodeTemplate = true;

                if (ucBarkodlar1 != null)
                {
                    ucBarkodlar1.InitializeService(_itemBarcodeService);
                    ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                }

                if (picResim != null)
                {
                    picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                }

                if (ucBirimCevrimleri1 != null)
                {
                    var unitConversionService = Program.ServiceProvider.GetRequiredService<ThermaCore.Application.Interfaces.Definitions.IUnitConversionService>();
                    ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);
                    ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                }
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
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "PackagingMaterial");
                glufOzelKod.Properties.DisplayMember = "Code";
                glufOzelKod.Properties.ValueMember = "Id";
            }

            if (cmbAmbalajTipi != null)
            {
                cmbAmbalajTipi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            }

            if (cmbMateryal != null)
            {
                cmbMateryal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            }

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _packagingMaterialService.GetById(Id);
            }
            else
            {
                CurrentEntity = new PackagingMaterialDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (PackagingMaterialDto)CurrentEntity;

            Id = dto.Id;
            if (txtKod != null) txtKod.Text = dto.Code;
            if (txtAmbalajAdi != null) txtAmbalajAdi.Text = dto.Name;

            if (glufTemelBirim != null) glufTemelBirim.EditValue = !string.IsNullOrEmpty(dto.BaseUnit) ? dto.BaseUnit : null;
            if (glufOzelKod != null) glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            
            if (cmbAmbalajTipi != null) cmbAmbalajTipi.SelectedItem = dto.PackagingType.HasValue ? dto.PackagingType.Value.GetDescription() : null;
            if (cmbMateryal != null) cmbMateryal.SelectedItem = dto.PackagingMaterialType.HasValue ? dto.PackagingMaterialType.Value.GetDescription() : null;

            if (txtKalinlik != null) txtKalinlik.EditValue = dto.ThicknessMm;
            if (txtAgirlik != null) txtAgirlik.EditValue = dto.WeightGr;
            
            if (txtAciklama != null) txtAciklama.Text = dto.Description;
            if (tglDurum != null) tglDurum.IsOn = dto.IsActive;

            if (picResim != null)
            {
                if (dto.Id > 0)
                {
                    picResim.LoadPicture("PackagingMaterial", dto.Id);
                }
                else
                {
                    picResim.ClearPicture();
                }
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                if (txtKod != null) txtKod.Text = "Yeni Kod";
            }

            if (ucBarkodlar1 != null && txtKod != null)
            {
                ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.AmbalajMalzemesiTanimlari);
            }

            if (ucBirimCevrimleri1 != null && glufTemelBirim != null)
            {
                ucBirimCevrimleri1.Yukle(Id, glufTemelBirim.Text);
            }
        }

        protected override void GuncelNesneOlustur()
        {
            decimal? thickness = null;
            if (txtKalinlik != null && txtKalinlik.EditValue != null && txtKalinlik.EditValue != DBNull.Value && decimal.TryParse(txtKalinlik.EditValue.ToString(), out decimal th))
            {
                thickness = th;
            }

            decimal? weight = null;
            if (txtAgirlik != null && txtAgirlik.EditValue != null && txtAgirlik.EditValue != DBNull.Value && decimal.TryParse(txtAgirlik.EditValue.ToString(), out decimal we))
            {
                weight = we;
            }

            var dto = new PackagingMaterialDto
            {
                Id = Id,
                Code = txtKod != null ? txtKod.Text : string.Empty,
                Name = txtAmbalajAdi != null ? txtAmbalajAdi.Text : string.Empty,
                BaseUnit = (glufTemelBirim != null && glufTemelBirim.EditValue != null) ? glufTemelBirim.EditValue.ToString()! : "",
                SpecialCodeId = (glufOzelKod != null && glufOzelKod.EditValue != null) ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                PackagingType = (cmbAmbalajTipi != null && !string.IsNullOrWhiteSpace(cmbAmbalajTipi.Text)) ? cmbAmbalajTipi.Text.GetEnum<PackagingType>() : (PackagingType?)null,
                PackagingMaterialType = (cmbMateryal != null && !string.IsNullOrWhiteSpace(cmbMateryal.Text)) ? cmbMateryal.Text.GetEnum<PackagingMaterialType>() : (PackagingMaterialType?)null,
                ThicknessMm = thickness,
                WeightGr = weight,
                Description = txtAciklama != null ? txtAciklama.Text : string.Empty,
                IsActive = tglDurum != null && tglDurum.IsOn
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            if (ucBarkodlar1 != null)
            {
                ucBarkodlar1.PostGridChanges();
            }

            if (ucBirimCevrimleri1 != null)
            {
                ucBirimCevrimleri1.PostGridChanges();
            }

            try
            {
                var dto = (PackagingMaterialDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                
                Id = _packagingMaterialService.Insert(dto);

                if (Id > 0)
                {
                    if (ucBarkodlar1 != null) ucBarkodlar1.Kaydet(Id);
                    if (ucBirimCevrimleri1 != null) ucBirimCevrimleri1.Kaydet(Id);
                    if (picResim != null) picResim.SavePicture("PackagingMaterial", Id);
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
            if (ucBarkodlar1 != null)
            {
                ucBarkodlar1.PostGridChanges();
            }

            if (ucBirimCevrimleri1 != null)
            {
                ucBirimCevrimleri1.PostGridChanges();
            }

            try
            {
                var dto = (PackagingMaterialDto)CurrentEntity;
                _packagingMaterialService.Update(dto);

                if (ucBarkodlar1 != null) ucBarkodlar1.Kaydet(Id);
                if (ucBirimCevrimleri1 != null) ucBirimCevrimleri1.Kaydet(Id);
                if (picResim != null) picResim.SavePicture("PackagingMaterial", Id);

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

            string itemName = txtAmbalajAdi != null ? txtAmbalajAdi.Text : "Kayıt";
            var result = Messages.SilMesaj(itemName);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _packagingMaterialService.Delete(Id);
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

            if (cmbAmbalajTipi != null)
            {
                cmbAmbalajTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<PackagingType>().ToArray());
            }
            
            if (cmbMateryal != null)
            {
                cmbMateryal.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<PackagingMaterialType>().ToArray());
            }

            if (glufOzelKod != null)
            {
                glufOzelKod.SearchButtonClicked += GlufOzelKod_SearchButtonClicked;
                glufOzelKod.EditValueChanged += (s, e) => ButonEnabledDurumu();
            }

            if (glufTemelBirim != null)
            {
                glufTemelBirim.SearchButtonClicked += GlufTemelBirim_SearchButtonClicked;
                glufTemelBirim.EditValueChanged += (s, e) => ButonEnabledDurumu();
            }

            if (txtAmbalajAdi != null) txtAmbalajAdi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbAmbalajTipi != null) cmbAmbalajTipi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbMateryal != null) cmbMateryal.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtKalinlik != null) txtKalinlik.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtAgirlik != null) txtAgirlik.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtAciklama != null) txtAciklama.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (tglDurum != null) tglDurum.EditValueChanged += (s, e) => ButonEnabledDurumu();
        }

        private void GlufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new ThermaCore.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "PackagingMaterial");
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            if (glufOzelKod != null)
            {
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "PackagingMaterial");

                if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
                {
                    var selectedId = form.SelectedEntities[0].Id;
                    glufOzelKod.EditValue = selectedId;
                }
            }
        }

        private void GlufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                
                if (glufTemelBirim != null)
                {
                    glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
                    if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                    {
                        dynamic secilenBirim = form.SelectedEntities[0];
                        var secilenAd = secilenBirim.Name;
                        glufTemelBirim.EditValue = secilenAd;
                    }
                }
            }
        }

        protected override void FocusControlByPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Code":
                    if (txtKod != null) txtKod.Focus();
                    break;
                case "Name":
                    if (txtAmbalajAdi != null) txtAmbalajAdi.Focus();
                    break;
                case "BaseUnit":
                case "UnitId":
                    if (glufTemelBirim != null) glufTemelBirim.Focus();
                    break;
                case "PackagingType":
                    if (cmbAmbalajTipi != null) cmbAmbalajTipi.Focus();
                    break;
                case "PackagingMaterialType":
                    if (cmbMateryal != null) cmbMateryal.Focus();
                    break;
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

        protected override void LockFormControls(Control.ControlCollection controls)
        {
            base.LockFormControls(controls);
            if (picResim != null) picResim.SetReadOnly(true);
        }
    }
}