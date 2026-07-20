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

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.MatbaaKilavuzForms
{
    public partial class MatbaaKilavuzEditForm : BaseEditForm
    {
        private readonly IManualService _manualService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;
        private readonly IItemBarcodeService _itemBarcodeService = default!;

        public MatbaaKilavuzEditForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _manualService = Program.ServiceProvider.GetRequiredService<IManualService>();
                _unitRepository = Program.ServiceProvider.GetRequiredService<IUnitRepository>();
                _specialCodeService = Program.ServiceProvider.GetRequiredService<ISpecialCodeService>();
                _itemBarcodeService = Program.ServiceProvider.GetRequiredService<IItemBarcodeService>();

                BaseKartTuru = ModuleType.MatbaaTanimlari;
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
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Manual");
                glufOzelKod.Properties.DisplayMember = "Code";
                glufOzelKod.Properties.ValueMember = "Id";
            }

            if (cmbDokumanTipi != null)
            {
                cmbDokumanTipi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            }

            if (cmbKagitCinsi != null)
            {
                cmbKagitCinsi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            }

            if (cmbDil != null)
            {
                cmbDil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            }

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _manualService.GetById(Id);
            }
            else
            {
                CurrentEntity = new ManualDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (ManualDto)CurrentEntity;

            Id = dto.Id;
            if (txtKod != null) txtKod.Text = dto.Code;
            if (txtDokumanAdi != null) txtDokumanAdi.Text = dto.Name;

            if (glufTemelBirim != null) glufTemelBirim.EditValue = !string.IsNullOrEmpty(dto.BaseUnit) ? dto.BaseUnit : null;
            if (glufOzelKod != null) glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            
            if (cmbDokumanTipi != null) cmbDokumanTipi.SelectedItem = dto.ManualType.HasValue ? dto.ManualType.Value.GetDescription() : null;
            if (cmbKagitCinsi != null) cmbKagitCinsi.SelectedItem = dto.PaperType.HasValue ? dto.PaperType.Value.GetDescription() : null;
            if (cmbDil != null) cmbDil.SelectedItem = dto.LanguageCode.HasValue ? dto.LanguageCode.Value.GetDescription() : null;

            if (txtSayfaSayisi != null) txtSayfaSayisi.EditValue = dto.PageCount;
            
            if (txtAciklama != null) txtAciklama.Text = dto.Description;
            if (tglDurum != null) tglDurum.IsOn = dto.IsActive;

            if (picResim != null)
            {
                if (dto.Id > 0)
                {
                    picResim.LoadPicture("Manual", dto.Id);
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
                ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.MatbaaTanimlari);
            }
        }

        protected override void GuncelNesneOlustur()
        {
            int? pageCount = null;
            if (txtSayfaSayisi != null && txtSayfaSayisi.EditValue != null && txtSayfaSayisi.EditValue != DBNull.Value && int.TryParse(txtSayfaSayisi.EditValue.ToString(), out int pc))
            {
                pageCount = pc;
            }

            var dto = new ManualDto
            {
                Id = Id,
                Code = txtKod != null ? txtKod.Text : string.Empty,
                Name = txtDokumanAdi != null ? txtDokumanAdi.Text : string.Empty,
                BaseUnit = (glufTemelBirim != null && glufTemelBirim.EditValue != null) ? glufTemelBirim.EditValue.ToString()! : "",
                SpecialCodeId = (glufOzelKod != null && glufOzelKod.EditValue != null) ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                ManualType = (cmbDokumanTipi != null && !string.IsNullOrWhiteSpace(cmbDokumanTipi.Text)) ? cmbDokumanTipi.Text.GetEnum<ManualType>() : (ManualType?)null,
                PaperType = (cmbKagitCinsi != null && !string.IsNullOrWhiteSpace(cmbKagitCinsi.Text)) ? cmbKagitCinsi.Text.GetEnum<PaperType>() : (PaperType?)null,
                LanguageCode = (cmbDil != null && !string.IsNullOrWhiteSpace(cmbDil.Text)) ? cmbDil.Text.GetEnum<LanguageCode>() : (LanguageCode?)null,
                PageCount = pageCount,
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
                var dto = (ManualDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                
                Id = _manualService.Insert(dto);

                if (Id > 0)
                {
                    if (ucBarkodlar1 != null) ucBarkodlar1.Kaydet(Id);
                    if (picResim != null) picResim.SavePicture("Manual", Id);
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
                var dto = (ManualDto)CurrentEntity;
                _manualService.Update(dto);

                if (ucBarkodlar1 != null) ucBarkodlar1.Kaydet(Id);
                if (picResim != null) picResim.SavePicture("Manual", Id);

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

            string itemName = txtDokumanAdi != null ? txtDokumanAdi.Text : "Kayıt";
            var result = Messages.SilMesaj(itemName);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _manualService.Delete(Id);
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

            if (cmbDokumanTipi != null)
            {
                cmbDokumanTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<ManualType>().ToArray());
            }
            
            if (cmbKagitCinsi != null)
            {
                cmbKagitCinsi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<PaperType>().ToArray());
            }

            if (cmbDil != null)
            {
                cmbDil.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<LanguageCode>().ToArray());
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

            if (txtDokumanAdi != null) txtDokumanAdi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbDokumanTipi != null) cmbDokumanTipi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbKagitCinsi != null) cmbKagitCinsi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbDil != null) cmbDil.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtSayfaSayisi != null) txtSayfaSayisi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtAciklama != null) txtAciklama.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (tglDurum != null) tglDurum.EditValueChanged += (s, e) => ButonEnabledDurumu();
        }

        private void GlufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new ThermaCore.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "Manual");
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            if (glufOzelKod != null)
            {
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Manual");

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
                    if (txtDokumanAdi != null) txtDokumanAdi.Focus();
                    break;
                case "BaseUnit":
                case "UnitId":
                    if (glufTemelBirim != null) glufTemelBirim.Focus();
                    break;
                case "ManualType":
                    if (cmbDokumanTipi != null) cmbDokumanTipi.Focus();
                    break;
                case "PaperType":
                    if (cmbKagitCinsi != null) cmbKagitCinsi.Focus();
                    break;
                case "LanguageCode":
                    if (cmbDil != null) cmbDil.Focus();
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