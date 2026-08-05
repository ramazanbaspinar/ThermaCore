using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using WinBeyazEsya.Application.Interfaces.Common;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.Interfaces.Definitions;

namespace WinBeyazEsya.Presentation.WinForms.Forms.VidaForms
{
    public partial class VidaEditForm : BaseEditForm
    {
        private readonly IScrewService _screwService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;

        public VidaEditForm()
        {
            InitializeComponent();
        }

        public VidaEditForm(
            IScrewService screwService,
            IItemBarcodeService itemBarcodeService,
            IUnitRepository unitRepository,
            ISpecialCodeService specialCodeService,
            IUnitConversionService unitConversionService)
        {
            InitializeComponent();

            _screwService = screwService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = ModuleType.VidaTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
            RequiresCodeTemplate = true;

            ucBarkodlar1.InitializeService(itemBarcodeService);
            ucBirimCevrimleri1.InitializeDependencies(unitConversionService, unitRepository);
            
            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Screw");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _screwService.GetById(Id);
            }
            else
            {
                CurrentEntity = new ScrewDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (ScrewDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtScrewAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            txtCap.Text = dto.Diameter;
            if (dto.LengthMm.HasValue)
                txtBoy.EditValue = dto.LengthMm.Value;
            else
                txtBoy.EditValue = null;

            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPictureAsync("Screw", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.VidaTanimlari);
            ucBirimCevrimleri1.Yukle(Id, glufTemelBirim.Text);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new ScrewDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtScrewAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                Diameter = txtCap.Text,
                LengthMm = txtBoy.EditValue != null && txtBoy.EditValue != DBNull.Value ? Convert.ToDecimal(txtBoy.EditValue) : (decimal?)null,
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
                var dto = (ScrewDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _screwService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    ucBirimCevrimleri1.Kaydet(Id);
                    picResim.SavePictureAsync("Screw", Id);
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
                var dto = (ScrewDto)CurrentEntity;
                _screwService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                ucBirimCevrimleri1.Kaydet(Id);
                picResim.SavePictureAsync("Screw", Id);

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

            if (Messages.SilMesaj("Vida Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _screwService.Delete(Id);
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
                case "Name": txtScrewAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _screwService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;
        }

        private void glufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "Screw");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Screw");

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
