using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Common;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Domain.Extensions;
using WinBeyazEsya.Domain.Helpers;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BaglantiElemaniForms
{
    public partial class BaglantiElemaniEditForm : BaseEditForm
    {
        private readonly IFastenerService _fastenerService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;
        private readonly IItemBarcodeService _itemBarcodeService = default!;
        private readonly IQualityStandardService _qualityStandardService = default!;

        public BaglantiElemaniEditForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _fastenerService = Program.ServiceProvider.GetRequiredService<IFastenerService>();
                _unitRepository = Program.ServiceProvider.GetRequiredService<IUnitRepository>();
                _specialCodeService = Program.ServiceProvider.GetRequiredService<ISpecialCodeService>();
                _itemBarcodeService = Program.ServiceProvider.GetRequiredService<IItemBarcodeService>();
                _qualityStandardService = Program.ServiceProvider.GetRequiredService<IQualityStandardService>();

                BaseKartTuru = ModuleType.BaglantiElemaniTanimlari;
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
                    var unitConversionService = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService>();
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
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Fastener");
                glufOzelKod.Properties.DisplayMember = "Code";
                glufOzelKod.Properties.ValueMember = "Id";
            }
            
            if (glufKaliteStandarti != null)
            {
                glufKaliteStandarti.Properties.DataSource = _qualityStandardService.GetAll().Where(x => x.IsActive).ToList();
                glufKaliteStandarti.Properties.DisplayMember = "Name";
                glufKaliteStandarti.Properties.ValueMember = "Id";
            }

            if (cmbElemanTipi != null)
            {
                cmbElemanTipi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            }

            if (cmbMateryal != null)
            {
                cmbMateryal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            }

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _fastenerService.GetById(Id);
            }
            else
            {
                CurrentEntity = new FastenerDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (FastenerDto)CurrentEntity;

            Id = dto.Id;
            if (txtKod != null) txtKod.Text = dto.Code;
            if (txtBaglantiElemaniAdi != null) txtBaglantiElemaniAdi.Text = dto.Name;

            if (glufTemelBirim != null) glufTemelBirim.EditValue = !string.IsNullOrEmpty(dto.BaseUnit) ? dto.BaseUnit : null;
            if (glufOzelKod != null) glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            if (glufKaliteStandarti != null) glufKaliteStandarti.EditValue = dto.QualityStandardId > 0 ? dto.QualityStandardId : null;
            
            if (cmbElemanTipi != null) cmbElemanTipi.SelectedItem = dto.FastenerType.HasValue ? dto.FastenerType.Value.GetDescription() : null;
            if (cmbMateryal != null) cmbMateryal.SelectedItem = dto.MaterialType.HasValue ? dto.MaterialType.Value.GetDescription() : null;

            if (txtAgirlik != null) txtAgirlik.EditValue = dto.WeightGr;
            
            if (txtAciklama != null) txtAciklama.Text = dto.Description;
            if (tglDurum != null) tglDurum.IsOn = dto.IsActive;

            if (picResim != null)
            {
                if (dto.Id > 0)
                {
                    picResim.LoadPicture("Fastener", dto.Id);
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
                ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.BaglantiElemaniTanimlari);
            }

            if (ucBirimCevrimleri1 != null && glufTemelBirim != null)
            {
                ucBirimCevrimleri1.Yukle(Id, glufTemelBirim.Text);
            }
        }

        protected override void GuncelNesneOlustur()
        {
            decimal? weight = null;
            if (txtAgirlik != null && txtAgirlik.EditValue != null && txtAgirlik.EditValue != DBNull.Value && decimal.TryParse(txtAgirlik.EditValue.ToString(), out decimal we))
            {
                weight = we;
            }

            var dto = new FastenerDto
            {
                Id = Id,
                Code = txtKod != null ? txtKod.Text : string.Empty,
                Name = txtBaglantiElemaniAdi != null ? txtBaglantiElemaniAdi.Text : string.Empty,
                BaseUnit = (glufTemelBirim != null && glufTemelBirim.EditValue != null) ? glufTemelBirim.EditValue.ToString()! : "",
                SpecialCodeId = (glufOzelKod != null && glufOzelKod.EditValue != null) ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                QualityStandardId = (glufKaliteStandarti != null && glufKaliteStandarti.EditValue != null) ? Convert.ToInt64(glufKaliteStandarti.EditValue) : null,
                FastenerType = (cmbElemanTipi != null && !string.IsNullOrWhiteSpace(cmbElemanTipi.Text)) ? cmbElemanTipi.Text.GetEnum<FastenerType>() : (FastenerType?)null,
                MaterialType = (cmbMateryal != null && !string.IsNullOrWhiteSpace(cmbMateryal.Text)) ? cmbMateryal.Text.GetEnum<MaterialType>() : (MaterialType?)null,
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
                var dto = (FastenerDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                
                Id = _fastenerService.Insert(dto);

                if (Id > 0)
                {
                    if (ucBarkodlar1 != null) ucBarkodlar1.Kaydet(Id);
                    if (ucBirimCevrimleri1 != null) ucBirimCevrimleri1.Kaydet(Id);
                    if (picResim != null) picResim.SavePicture("Fastener", Id);
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
                var dto = (FastenerDto)CurrentEntity;
                _fastenerService.Update(dto);

                if (ucBarkodlar1 != null) ucBarkodlar1.Kaydet(Id);
                if (ucBirimCevrimleri1 != null) ucBirimCevrimleri1.Kaydet(Id);
                if (picResim != null) picResim.SavePicture("Fastener", Id);

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

            string itemName = txtBaglantiElemaniAdi != null ? txtBaglantiElemaniAdi.Text : "Kayıt";
            var result = Messages.SilMesaj(itemName);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _fastenerService.Delete(Id);
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

            if (cmbElemanTipi != null)
            {
                cmbElemanTipi.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<FastenerType>().ToArray());
            }
            
            if (cmbMateryal != null)
            {
                cmbMateryal.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<MaterialType>().ToArray());
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
            
            if (glufKaliteStandarti != null)
            {
                glufKaliteStandarti.SearchButtonClicked += GlufKaliteStandarti_SearchButtonClicked;
                glufKaliteStandarti.EditValueChanged += (s, e) => ButonEnabledDurumu();
            }

            if (txtBaglantiElemaniAdi != null) txtBaglantiElemaniAdi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbElemanTipi != null) cmbElemanTipi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbMateryal != null) cmbMateryal.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtAgirlik != null) txtAgirlik.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtAciklama != null) txtAciklama.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (tglDurum != null) tglDurum.EditValueChanged += (s, e) => ButonEnabledDurumu();
        }

        private void GlufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "Fastener");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            if (glufOzelKod != null)
            {
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Fastener");

                if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
                {
                    var selectedId = form.SelectedEntities[0].Id;
                    glufOzelKod.EditValue = selectedId;
                }
            }
        }

        private void GlufKaliteStandarti_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.KaliteStandartForms.KaliteStandartListForm>();
            if (form != null)
            {
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                
                if (glufKaliteStandarti != null)
                {
                    glufKaliteStandarti.Properties.DataSource = _qualityStandardService.GetAll().Where(x => x.IsActive).ToList();
                    if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                    {
                        dynamic secilenKalite = form.SelectedEntities[0];
                        var secilenId = secilenKalite.Id;
                        glufKaliteStandarti.EditValue = secilenId;
                    }
                }
            }
        }

        private void GlufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            if (form != null)
            {
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
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
                    if (txtBaglantiElemaniAdi != null) txtBaglantiElemaniAdi.Focus();
                    break;
                case "BaseUnit":
                case "UnitId":
                    if (glufTemelBirim != null) glufTemelBirim.Focus();
                    break;
                case "FastenerType":
                    if (cmbElemanTipi != null) cmbElemanTipi.Focus();
                    break;
                case "MaterialType":
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
