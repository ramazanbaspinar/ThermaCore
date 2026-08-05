using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Domain.Extensions;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using WinBeyazEsya.Application.Interfaces.Common;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.PleytForms
{
    public partial class PleytEditForm : BaseEditForm
    {
        private readonly IHotplateService _hotplateService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;

        public PleytEditForm()
        {
            InitializeComponent();
        }

        public PleytEditForm(
            IHotplateService hotplateService,
            IItemBarcodeService itemBarcodeService,
            IUnitRepository unitRepository,
            ISpecialCodeService specialCodeService)
        {
            InitializeComponent();

            _hotplateService = hotplateService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            DataLayoutControl = myDataLayoutControl1;
            BaseKartTuru = ModuleType.PleytIsiticiTanimlari;
            RequiresCodeTemplate = true;

            ucBarkodlar1.InitializeService(itemBarcodeService);

            var unitConversionService = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService>();
            ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);

            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();
            txtKod.Enter += (s, e) => txtKod.SelectAll();
            txtPleytAdi.Enter += (s, e) => txtPleytAdi.SelectAll();

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;

            cmbPleytTipi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<HotplateType>().ToArray());
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Hotplate");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _hotplateService.GetById(Id);
            }
            else
            {
                CurrentEntity = new HotplateDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (HotplateDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtPleytAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            cmbPleytTipi.SelectedItem = dto.HotplateType.HasValue ? WinBeyazEsya.Domain.Extensions.EnumExtensions.ToName(dto.HotplateType.Value) : null;
            txtCap.EditValue = dto.DiameterMm;
            txtWatt.EditValue = dto.PowerWatt;
            txtVolt.EditValue = dto.Voltage;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPictureAsync("Hotplate", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.PleytIsiticiTanimlari);
            ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new HotplateDto
            {
                Id = this.Id,
                Code = txtKod.Text,
                Name = txtPleytAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                HotplateType = string.IsNullOrWhiteSpace(cmbPleytTipi.Text) ? (HotplateType?)null : cmbPleytTipi.Text.GetEnum<HotplateType>(),
                DiameterMm = txtCap.EditValue != null && txtCap.EditValue != DBNull.Value ? Convert.ToDecimal(txtCap.EditValue) : (decimal?)null,
                PowerWatt = txtWatt.EditValue != null && txtWatt.EditValue != DBNull.Value ? Convert.ToInt32(txtWatt.EditValue) : (int?)null,
                Voltage = txtVolt.EditValue != null && txtVolt.EditValue != DBNull.Value ? Convert.ToInt32(txtVolt.EditValue) : (int?)null,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn,
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            ucBarkodlar1.PostGridChanges();

            try
            {
                var dto = (HotplateDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _hotplateService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    picResim.SavePictureAsync("Hotplate", Id);
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
            ucBarkodlar1.PostGridChanges();

            try
            {
                var dto = (HotplateDto)CurrentEntity;
                _hotplateService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                picResim.SavePictureAsync("Hotplate", Id);
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

            if (Messages.SilMesaj("Pleyt Isıtıcı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _hotplateService.Delete(Id);
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
                case "Name": txtPleytAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _hotplateService.IsCodeUnique(this.Id, code);
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

        private void glufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new OzelKodListForm(SpecialCodeType.SpecialCode, "Hotplate");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Hotplate");

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        private void glufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
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

        protected override void LockFormControls(Control.ControlCollection controls)
        {
            base.LockFormControls(controls);
            picResim.SetReadOnly(true);
        }

        private void ucBirimCevrimleri1_Load(object sender, EventArgs e)
        {

        }
    }
}
