using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Production;
using ThermaCore.Application.Interfaces.Production;
using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using ThermaCore.Application.Interfaces.Common;
using Microsoft.Extensions.DependencyInjection;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.CamForms
{
    public partial class CamEditForm : BaseEditForm
    {
        private readonly IOvenGlassService _ovenGlassService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;

        public CamEditForm()
        {
            InitializeComponent();
        }

        public CamEditForm(
            IOvenGlassService ovenGlassService,
            IItemBarcodeService itemBarcodeService,
            IUnitRepository unitRepository,
            ISpecialCodeService specialCodeService)
        {
            InitializeComponent();

            _ovenGlassService = ovenGlassService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = ModuleType.CamTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4, myDataLayoutControl5 };
            RequiresCodeTemplate = true;

            ucBarkodlar1.InitializeService(itemBarcodeService);
            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "OvenGlass");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            // Cam Tipi lookup
            var glassTypeService = Program.ServiceProvider.GetRequiredService<IGlassTypeService>();
            glufCamTipi.Properties.DataSource = glassTypeService.GetAll().Where(x => x.IsActive).ToList();
            glufCamTipi.Properties.DisplayMember = "Name";
            glufCamTipi.Properties.ValueMember = "Id";

            // Renk Özellik lookup
            var colorFeatureService = Program.ServiceProvider.GetRequiredService<IColorFeatureService>();
            glufRenkOzellik.Properties.DataSource = colorFeatureService.GetAll().Where(x => x.IsActive).ToList();
            glufRenkOzellik.Properties.DisplayMember = "Name";
            glufRenkOzellik.Properties.ValueMember = "Id";

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _ovenGlassService.GetById(Id);
            }
            else
            {
                CurrentEntity = new OvenGlassDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (OvenGlassDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtCamAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            glufCamTipi.EditValue = dto.GlassTypeId > 0 ? dto.GlassTypeId : null;
            glufRenkOzellik.EditValue = dto.ColorFeatureId > 0 ? dto.ColorFeatureId : null;

            txtKalinlik.Text = dto.ThicknessMm?.ToString("N2");
            if (dto.WidthMm.HasValue)
                txtGenislik.EditValue = dto.WidthMm.Value;
            else
                txtGenislik.EditValue = null;

            if (dto.HeightMm.HasValue)
                txtYukseklik.EditValue = dto.HeightMm.Value;
            else
                txtYukseklik.EditValue = null;

            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPictureAsync("OvenGlass", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.CamTanimlari);
        }

        protected override void GuncelNesneOlustur()
        {
            decimal? thickness = null;
            if (!string.IsNullOrEmpty(txtKalinlik.Text))
            {
                if (decimal.TryParse(txtKalinlik.Text, out decimal parsed))
                    thickness = parsed;
            }

            var dto = new OvenGlassDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtCamAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                GlassTypeId = glufCamTipi.EditValue != null ? Convert.ToInt64(glufCamTipi.EditValue) : null,
                ColorFeatureId = glufRenkOzellik.EditValue != null ? Convert.ToInt64(glufRenkOzellik.EditValue) : null,
                ThicknessMm = thickness,
                WidthMm = txtGenislik.EditValue != null && txtGenislik.EditValue != DBNull.Value ? Convert.ToDecimal(txtGenislik.EditValue) : (decimal?)null,
                HeightMm = txtYukseklik.EditValue != null && txtYukseklik.EditValue != DBNull.Value ? Convert.ToDecimal(txtYukseklik.EditValue) : (decimal?)null,
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
                var dto = (OvenGlassDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _ovenGlassService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    picResim.SavePictureAsync("OvenGlass", Id);
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
                var dto = (OvenGlassDto)CurrentEntity;
                _ovenGlassService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                picResim.SavePictureAsync("OvenGlass", Id);

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

            if (Messages.SilMesaj("Cam Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _ovenGlassService.Delete(Id);
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
                case "Name": txtCamAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _ovenGlassService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;
            glufCamTipi.SearchButtonClicked += GlufCamTipi_SearchButtonClicked;
            glufRenkOzellik.SearchButtonClicked += GlufRenkOzellik_SearchButtonClicked;
        }

        private void GlufCamTipi_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.CamForms.CamTipiForms.CamTipiListForm>();
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            var glassTypeService = Program.ServiceProvider.GetRequiredService<IGlassTypeService>();
            glufCamTipi.Properties.DataSource = glassTypeService.GetAll().Where(x => x.IsActive).ToList();

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufCamTipi.EditValue = selectedId;
            }
        }

        private void GlufRenkOzellik_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.CamForms.RenkOzellikForms.CamRenkListForm>();
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            var colorFeatureService = Program.ServiceProvider.GetRequiredService<IColorFeatureService>();
            glufRenkOzellik.Properties.DataSource = colorFeatureService.GetAll().Where(x => x.IsActive).ToList();

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufRenkOzellik.EditValue = selectedId;
            }
        }

        private void glufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new ThermaCore.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "OvenGlass");
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "OvenGlass");

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        private void glufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                {
                    dynamic secilenBirim = form.SelectedEntities[0];
                    var secilenAd = secilenBirim.Name;
                    glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
                    glufTemelBirim.EditValue = secilenAd;
                }
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            if (picResim.IsDirty() || ucBarkodlar1.IsDirty())
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