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

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.EtiketForms
{
    public partial class EtiketEditForm : BaseEditForm
    {
        private readonly IProductLabelService _productLabelService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;
        private readonly IItemBarcodeService _itemBarcodeService = default!;

        public EtiketEditForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _productLabelService = Program.ServiceProvider.GetRequiredService<IProductLabelService>();
                _unitRepository = Program.ServiceProvider.GetRequiredService<IUnitRepository>();
                _specialCodeService = Program.ServiceProvider.GetRequiredService<ISpecialCodeService>();
                _itemBarcodeService = Program.ServiceProvider.GetRequiredService<IItemBarcodeService>();

                BaseKartTuru = ModuleType.EtiketTanimlari;
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
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "ProductLabel");
                glufOzelKod.Properties.DisplayMember = "Code";
                glufOzelKod.Properties.ValueMember = "Id";
            }

            if (cmbEtiketTipi != null) cmbEtiketTipi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            if (cmbMateryal != null) cmbMateryal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _productLabelService.GetById(Id);
            }
            else
            {
                CurrentEntity = new ProductLabelDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (ProductLabelDto)CurrentEntity;

            Id = dto.Id;
            if (txtKod != null) txtKod.Text = dto.Code;
            if (txtEtiketAdi != null) txtEtiketAdi.Text = dto.Name;

            if (glufTemelBirim != null) glufTemelBirim.EditValue = !string.IsNullOrEmpty(dto.BaseUnit) ? dto.BaseUnit : null;
            if (glufOzelKod != null) glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            
            if (cmbEtiketTipi != null) cmbEtiketTipi.SelectedItem = dto.LabelType.HasValue ? dto.LabelType.Value.GetDescription() : null;
            if (cmbMateryal != null) cmbMateryal.SelectedItem = dto.LabelMaterialType.HasValue ? dto.LabelMaterialType.Value.GetDescription() : null;

            if (txtEn != null) txtEn.EditValue = dto.WidthMm;
            if (txtBoy != null) txtBoy.EditValue = dto.HeightMm;
            
            if (txtAciklama != null) txtAciklama.Text = dto.Description;
            if (tglDurum != null) tglDurum.IsOn = dto.IsActive;

            if (picResim != null)
            {
                if (dto.Id > 0)
                {
                    picResim.LoadPicture("ProductLabel", dto.Id);
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
                ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.EtiketTanimlari);
            }
        }

        protected override void GuncelNesneOlustur()
        {
            decimal? width = null;
            if (txtEn != null && txtEn.EditValue != null && txtEn.EditValue != DBNull.Value && decimal.TryParse(txtEn.EditValue.ToString(), out decimal w))
            {
                width = w;
            }

            decimal? height = null;
            if (txtBoy != null && txtBoy.EditValue != null && txtBoy.EditValue != DBNull.Value && decimal.TryParse(txtBoy.EditValue.ToString(), out decimal h))
            {
                height = h;
            }

            var dto = new ProductLabelDto
            {
                Id = Id,
                Code = txtKod != null ? txtKod.Text : string.Empty,
                Name = txtEtiketAdi != null ? txtEtiketAdi.Text : string.Empty,
                BaseUnit = (glufTemelBirim != null && glufTemelBirim.EditValue != null) ? glufTemelBirim.EditValue.ToString()! : "",
                SpecialCodeId = (glufOzelKod != null && glufOzelKod.EditValue != null) ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                LabelType = (cmbEtiketTipi != null && !string.IsNullOrWhiteSpace(cmbEtiketTipi.Text)) ? cmbEtiketTipi.Text.GetEnum<LabelType>() : (LabelType?)null,
                LabelMaterialType = (cmbMateryal != null && !string.IsNullOrWhiteSpace(cmbMateryal.Text)) ? cmbMateryal.Text.GetEnum<LabelMaterialType>() : (LabelMaterialType?)null,
                WidthMm = width,
                HeightMm = height,
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

            try
            {
                var dto = (ProductLabelDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                
                Id = _productLabelService.Insert(dto);

                if (Id > 0)
                {
                    if (ucBarkodlar1 != null) ucBarkodlar1.Kaydet(Id);
                    if (picResim != null) picResim.SavePicture("ProductLabel", Id);
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

            try
            {
                var dto = (ProductLabelDto)CurrentEntity;
                _productLabelService.Update(dto);

                if (ucBarkodlar1 != null) ucBarkodlar1.Kaydet(Id);
                if (picResim != null) picResim.SavePicture("ProductLabel", Id);

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

            string itemName = txtEtiketAdi != null ? txtEtiketAdi.Text : "Kayıt";
            var result = Messages.SilMesaj(itemName);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _productLabelService.Delete(Id);
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

            if (cmbEtiketTipi != null)
            {
                cmbEtiketTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<LabelType>().ToArray());
            }
            
            if (cmbMateryal != null)
            {
                cmbMateryal.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<LabelMaterialType>().ToArray());
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

            if (txtEtiketAdi != null) txtEtiketAdi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbEtiketTipi != null) cmbEtiketTipi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbMateryal != null) cmbMateryal.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtEn != null) txtEn.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtBoy != null) txtBoy.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtAciklama != null) txtAciklama.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (tglDurum != null) tglDurum.EditValueChanged += (s, e) => ButonEnabledDurumu();
        }

        private void GlufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new ThermaCore.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "ProductLabel");
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            if (glufOzelKod != null)
            {
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "ProductLabel");

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
                    if (txtEtiketAdi != null) txtEtiketAdi.Focus();
                    break;
                case "BaseUnit":
                case "UnitId":
                    if (glufTemelBirim != null) glufTemelBirim.Focus();
                    break;
                case "LabelType":
                    if (cmbEtiketTipi != null) cmbEtiketTipi.Focus();
                    break;
                case "LabelMaterialType":
                    if (cmbMateryal != null) cmbMateryal.Focus();
                    break;
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            bool isBarkodDirty = ucBarkodlar1 != null && ucBarkodlar1.IsDirty();
            bool isResimDirty = picResim != null && picResim.IsDirty();

            if (isBarkodDirty || isResimDirty)
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