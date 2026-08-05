using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Domain.Extensions;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using WinBeyazEsya.Application.Interfaces.Common;
using WinBeyazEsya.Domain.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MotorForms
{
    public partial class MotorEditForm : BaseEditForm
    {
        private readonly IOvenMotorService _ovenMotorService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;

        // DevExpress Designer için parametresiz kurucu
        public MotorEditForm()
        {
            InitializeComponent();
        }

        // DI Constructor
        public MotorEditForm(
            IOvenMotorService ovenMotorService,
            IItemBarcodeService itemBarcodeService,
            IUnitRepository unitRepository,
            ISpecialCodeService specialCodeService)
        {
            InitializeComponent();

            _ovenMotorService = ovenMotorService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = ModuleType.MotorTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
            RequiresCodeTemplate = true;

            ucBarkodlar1.InitializeService(itemBarcodeService);
            
            var unitConversionService = Program.ServiceProvider.GetRequiredService<WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService>();
            ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);

            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "OvenMotor");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            cmbMotorTipi.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<MotorType>().ToArray());

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                // Senkron olarak çağırdık, Task.Run KESİNLİKLE YASAK
                CurrentEntity = _ovenMotorService.GetById(Id);
            }
            else
            {
                CurrentEntity = new OvenMotorDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (OvenMotorDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtMotorAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            cmbMotorTipi.SelectedItem = dto.MotorType.HasValue ? WinBeyazEsya.Domain.Extensions.EnumExtensions.ToName(dto.MotorType.Value) : null;

            txtWatt.EditValue = dto.PowerWatt;
            txtVolt.EditValue = dto.Voltage;
            txtDevir.EditValue = dto.Rpm;
            txtMilUzunlugu.EditValue = dto.ShaftLengthMm;

            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                // Sadece burada 1 kere senkron bir şekilde resmi yüklüyoruz.
                picResim.LoadPictureAsync("OvenMotor", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.MotorTanimlari);
            ucBirimCevrimleri1.Yukle(Id, dto.BaseUnit ?? string.Empty);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new OvenMotorDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtMotorAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                MotorType = string.IsNullOrWhiteSpace(cmbMotorTipi.Text) ? (MotorType?)null : cmbMotorTipi.Text.GetEnum<MotorType>(),
                
                // Tip dönüşümleri doğrudan Convert kullanılarak InvalidCastException önlendi
                PowerWatt = txtWatt.EditValue != null && txtWatt.EditValue != DBNull.Value ? Convert.ToInt32(txtWatt.EditValue) : (int?)null,
                Voltage = txtVolt.EditValue != null && txtVolt.EditValue != DBNull.Value ? Convert.ToInt32(txtVolt.EditValue) : (int?)null,
                Rpm = txtDevir.EditValue != null && txtDevir.EditValue != DBNull.Value ? Convert.ToInt32(txtDevir.EditValue) : (int?)null,
                ShaftLengthMm = txtMilUzunlugu.EditValue != null && txtMilUzunlugu.EditValue != DBNull.Value ? Convert.ToDecimal(txtMilUzunlugu.EditValue) : (decimal?)null,
                
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
                var dto = (OvenMotorDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _ovenMotorService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    picResim.SavePictureAsync("OvenMotor", Id);
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
                var dto = (OvenMotorDto)CurrentEntity;
                _ovenMotorService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                picResim.SavePictureAsync("OvenMotor", Id);
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

            if (Messages.SilMesaj("Motor Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _ovenMotorService.Delete(Id);
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
                case "Name": txtMotorAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _ovenMotorService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;
        }

        private void glufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "OvenMotor");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "OvenMotor");

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

        protected override void LockFormControls(Control.ControlCollection controls)
        {
            base.LockFormControls(controls);
            picResim.SetReadOnly(true);
        }
    }
}
