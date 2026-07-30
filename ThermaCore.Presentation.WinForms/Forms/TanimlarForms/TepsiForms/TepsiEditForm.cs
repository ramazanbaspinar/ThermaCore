using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Domain.Extensions;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.TepsiForms
{
    public partial class TepsiEditForm : BaseEditForm
    {
        private readonly ITrayService _trayService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;
        private readonly IItemBarcodeService _itemBarcodeService = default!;

        public TepsiEditForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _trayService = Program.ServiceProvider.GetRequiredService<ITrayService>();
                _unitRepository = Program.ServiceProvider.GetRequiredService<IUnitRepository>();
                _specialCodeService = Program.ServiceProvider.GetRequiredService<ISpecialCodeService>();
                _itemBarcodeService = Program.ServiceProvider.GetRequiredService<IItemBarcodeService>();
                var unitConversionService = Program.ServiceProvider.GetRequiredService<IUnitConversionService>();

                BaseKartTuru = ModuleType.TepsiTanimlari;
                DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
                RequiresCodeTemplate = true;

                ucBarkodlar1.InitializeService(_itemBarcodeService);
                ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);
                ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            }
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Tray");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            cmbTepsiTipi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            cmbKaplamaTipi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _trayService.GetById(Id);
            }
            else
            {
                CurrentEntity = new TrayDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (TrayDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtTepsiAdi.Text = dto.Name;

            glufTemelBirim.EditValue = !string.IsNullOrEmpty(dto.BaseUnit) ? dto.BaseUnit : null;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            
            cmbTepsiTipi.SelectedItem = dto.TrayType.HasValue ? dto.TrayType.Value.GetDescription() : null;
            cmbKaplamaTipi.SelectedItem = dto.CoatingType.HasValue ? dto.CoatingType.Value.GetDescription() : null;

            txtGenislik.EditValue = dto.WidthMm;
            txtDerinlik.EditValue = dto.DepthMm;
            txtKalinlik.EditValue = dto.ThicknessMm;
            txtAgirlik.EditValue = dto.WeightGr;
            
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPicture("Tray", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.TepsiTanimlari);
            ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            decimal? width = null;
            if (txtGenislik.EditValue != null && txtGenislik.EditValue != DBNull.Value && decimal.TryParse(txtGenislik.EditValue.ToString(), out decimal w))
            {
                width = w;
            }

            decimal? depth = null;
            if (txtDerinlik.EditValue != null && txtDerinlik.EditValue != DBNull.Value && decimal.TryParse(txtDerinlik.EditValue.ToString(), out decimal d))
            {
                depth = d;
            }

            decimal? thickness = null;
            if (txtKalinlik.EditValue != null && txtKalinlik.EditValue != DBNull.Value && decimal.TryParse(txtKalinlik.EditValue.ToString(), out decimal t))
            {
                thickness = t;
            }

            decimal? weight = null;
            if (txtAgirlik.EditValue != null && txtAgirlik.EditValue != DBNull.Value && decimal.TryParse(txtAgirlik.EditValue.ToString(), out decimal we))
            {
                weight = we;
            }

            var dto = new TrayDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtTepsiAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : "",
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                TrayType = string.IsNullOrWhiteSpace(cmbTepsiTipi.Text) ? (TrayType?)null : cmbTepsiTipi.Text.GetEnum<TrayType>(),
                CoatingType = string.IsNullOrWhiteSpace(cmbKaplamaTipi.Text) ? (CoatingType?)null : cmbKaplamaTipi.Text.GetEnum<CoatingType>(),
                WidthMm = width,
                DepthMm = depth,
                ThicknessMm = thickness,
                WeightGr = weight,
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
                var dto = (TrayDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _trayService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    ucBirimCevrimleri1.Kaydet(Id);
                    picResim.SavePicture("Tray", Id);
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
            ucBirimCevrimleri1.PostGridChanges();

            try
            {
                var dto = (TrayDto)CurrentEntity;
                _trayService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                ucBirimCevrimleri1.Kaydet(Id);
                picResim.SavePicture("Tray", Id);

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

            var result = Messages.SilMesaj(txtTepsiAdi.Text);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _trayService.Delete(Id);
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

            cmbTepsiTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<TrayType>().ToArray());
            cmbKaplamaTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<CoatingType>().ToArray());

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

            if (txtTepsiAdi != null) txtTepsiAdi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbTepsiTipi != null) cmbTepsiTipi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (cmbKaplamaTipi != null) cmbKaplamaTipi.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtGenislik != null) txtGenislik.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtDerinlik != null) txtDerinlik.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtKalinlik != null) txtKalinlik.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtAgirlik != null) txtAgirlik.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (txtAciklama != null) txtAciklama.EditValueChanged += (s, e) => ButonEnabledDurumu();
            if (tglDurum != null) tglDurum.EditValueChanged += (s, e) => ButonEnabledDurumu();
        }

        private void GlufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new ThermaCore.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "Tray");
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Tray");

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        private void GlufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
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

        protected override void FocusControlByPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Code":
                    txtKod.Focus();
                    break;
                case "Name":
                    txtTepsiAdi.Focus();
                    break;
                case "BaseUnit":
                case "UnitId":
                    glufTemelBirim.Focus();
                    break;
                case "TrayType":
                    cmbTepsiTipi.Focus();
                    break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _trayService.IsCodeUnique(this.Id, code);
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

        protected override void LockFormControls(Control.ControlCollection controls)
        {
            base.LockFormControls(controls);
            picResim.SetReadOnly(true);
        }
    }
}