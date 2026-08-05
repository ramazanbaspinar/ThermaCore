using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Common;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Domain.Extensions;
using WinBeyazEsya.Domain.Helpers;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PlastikParcaForms
{
    public partial class PlastikParcaEditForm : BaseEditForm
    {
        private readonly IPlasticPartService _plasticPartService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;
        private readonly IItemBarcodeService _itemBarcodeService = default!;

        public PlastikParcaEditForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _plasticPartService = Program.ServiceProvider.GetRequiredService<IPlasticPartService>();
                _unitRepository = Program.ServiceProvider.GetRequiredService<IUnitRepository>();
                _specialCodeService = Program.ServiceProvider.GetRequiredService<ISpecialCodeService>();
                _itemBarcodeService = Program.ServiceProvider.GetRequiredService<IItemBarcodeService>();

                BaseKartTuru = ModuleType.PlastikParcaTanimlari;
                DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
                RequiresCodeTemplate = true;

                if (ucBarkodlar1 != null)
                {
                    ucBarkodlar1.InitializeService(_itemBarcodeService);
                    ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                }

                var unitConversionService = Program.ServiceProvider.GetRequiredService<IUnitConversionService>();
                ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);
                ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();

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
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "PlasticPart");
                glufOzelKod.Properties.DisplayMember = "Code";
                glufOzelKod.Properties.ValueMember = "Id";
            }

            if (cmbParcaKategorisi != null)
            {
                cmbParcaKategorisi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            }

            if (cmbPlastikHammadde != null)
            {
                cmbPlastikHammadde.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            }

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _plasticPartService.GetById(Id);
            }
            else
            {
                CurrentEntity = new PlasticPartDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (PlasticPartDto)CurrentEntity;

            Id = dto.Id;
            if (txtKod != null) txtKod.Text = dto.Code;
            if (txtPlastikParcaAdi != null) txtPlastikParcaAdi.Text = dto.Name;

            if (glufTemelBirim != null) glufTemelBirim.EditValue = !string.IsNullOrEmpty(dto.BaseUnit) ? dto.BaseUnit : null;
            if (glufOzelKod != null) glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            
            if (cmbParcaKategorisi != null) cmbParcaKategorisi.SelectedItem = dto.PlasticPartCategory.HasValue ? dto.PlasticPartCategory.Value.GetDescription() : null;
            if (cmbPlastikHammadde != null) cmbPlastikHammadde.SelectedItem = dto.PlasticMaterialType.HasValue ? dto.PlasticMaterialType.Value.GetDescription() : null;

            if (txtRenk != null) txtRenk.Text = dto.Color;
            if (txtAgirlik != null) txtAgirlik.EditValue = dto.WeightGr;
            
            if (txtAciklama != null) txtAciklama.Text = dto.Description;
            if (tglDurum != null) tglDurum.IsOn = dto.IsActive;

            if (picResim != null)
            {
                if (dto.Id > 0)
                {
                    picResim.LoadPicture("PlasticPart", dto.Id);
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
                ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.PlastikParcaTanimlari);
            }
            
            ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            decimal? weight = null;
            if (txtAgirlik != null && txtAgirlik.EditValue != null && txtAgirlik.EditValue != DBNull.Value && decimal.TryParse(txtAgirlik.EditValue.ToString(), out decimal we))
            {
                weight = we;
            }

            var dto = new PlasticPartDto
            {
                Id = Id,
                Code = txtKod != null ? txtKod.Text : string.Empty,
                Name = txtPlastikParcaAdi != null ? txtPlastikParcaAdi.Text : string.Empty,
                BaseUnit = (glufTemelBirim != null && glufTemelBirim.EditValue != null) ? glufTemelBirim.EditValue.ToString()! : "",
                SpecialCodeId = (glufOzelKod != null && glufOzelKod.EditValue != null) ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                PlasticPartCategory = (cmbParcaKategorisi != null && !string.IsNullOrWhiteSpace(cmbParcaKategorisi.Text)) ? cmbParcaKategorisi.Text.GetEnum<PlasticPartCategory>() : (PlasticPartCategory?)null,
                PlasticMaterialType = (cmbPlastikHammadde != null && !string.IsNullOrWhiteSpace(cmbPlastikHammadde.Text)) ? cmbPlastikHammadde.Text.GetEnum<PlasticMaterialType>() : (PlasticMaterialType?)null,
                Color = txtRenk != null ? txtRenk.Text : string.Empty,
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

            try
            {
                var dto = (PlasticPartDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _plasticPartService.Insert(dto);

                if (Id > 0)
                {
                    if (ucBarkodlar1 != null) ucBarkodlar1.Kaydet(Id);
                    if (picResim != null) picResim.SavePicture("PlasticPart", Id);
                    ucBirimCevrimleri1.PostGridChanges();
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
                var dto = (PlasticPartDto)CurrentEntity;
                _plasticPartService.Update(dto);

                if (ucBarkodlar1 != null) ucBarkodlar1.Kaydet(Id);
                if (picResim != null) picResim.SavePicture("PlasticPart", Id);
                ucBirimCevrimleri1.PostGridChanges();
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
                Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            string itemName = txtPlastikParcaAdi != null ? txtPlastikParcaAdi.Text : "Kayıt";
            var result = Messages.SilMesaj(itemName);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _plasticPartService.Delete(Id);
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

            if (cmbParcaKategorisi != null)
            {
                cmbParcaKategorisi.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<PlasticPartCategory>().ToArray());
            }
            
            if (cmbPlastikHammadde != null)
            {
                cmbPlastikHammadde.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<PlasticMaterialType>().ToArray());
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

            if (txtPlastikParcaAdi != null) txtPlastikParcaAdi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbParcaKategorisi != null) cmbParcaKategorisi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbPlastikHammadde != null) cmbPlastikHammadde.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtRenk != null) txtRenk.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtAgirlik != null) txtAgirlik.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtAciklama != null) txtAciklama.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (tglDurum != null) tglDurum.EditValueChanged += (s, e) => ButonEnabledDurumu();
        }

        private void GlufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "PlasticPart");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            if (glufOzelKod != null)
            {
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "PlasticPart");

                if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
                {
                    var selectedId = form.SelectedEntities[0].Id;
                    glufOzelKod.EditValue = selectedId;
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
                    if (txtPlastikParcaAdi != null) txtPlastikParcaAdi.Focus();
                    break;
                case "BaseUnit":
                case "UnitId":
                    if (glufTemelBirim != null) glufTemelBirim.Focus();
                    break;
                case "PlasticPartCategory":
                    if (cmbParcaKategorisi != null) cmbParcaKategorisi.Focus();
                    break;
                case "PlasticMaterialType":
                    if (cmbPlastikHammadde != null) cmbPlastikHammadde.Focus();
                    break;
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            bool isBarkodDirty = ucBarkodlar1 != null && ucBarkodlar1.IsDirty();
            bool isResimDirty = picResim != null && picResim.IsDirty();

            if (isBarkodDirty || isResimDirty || ucBirimCevrimleri1.IsDirty)
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

