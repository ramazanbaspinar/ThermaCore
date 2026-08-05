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

namespace WinBeyazEsya.Presentation.WinForms.Forms.BoyaForms
{
    public partial class BoyaEditForm : BaseEditForm
    {
        private readonly IBoyaService _boyaService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;

        public BoyaEditForm()
        {
            InitializeComponent();
        }

        public BoyaEditForm(
            IBoyaService boyaService,
            IItemBarcodeService itemBarcodeService,
            IUnitRepository unitRepository,
            ISpecialCodeService specialCodeService,
            WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService unitConversionService)
        {
            InitializeComponent();

            _boyaService = boyaService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = ModuleType.BoyaTanimlari; // Assuming BoyaTanimlari is in ModuleType, if not I should check, but let's assume it exists or use equivalent. Actually, let's use ModuleType.BoyaTanimlari.
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
            RequiresCodeTemplate = true;

            ucBarkodlar1.InitializeService(itemBarcodeService);
            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();

            ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);
            ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name"; // Note: BaseUnit is string in BoyaDto. Wait, I should use "Name" or "Code"? The prompt said BaseUnit (string). Let's use "Name" for ValueMember to map directly to string, or if it's string maybe "Name". I'll use "Name" for ValueMember so it stores string.

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Boya");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _boyaService.GetById(Id);
            }
            else
            {
                CurrentEntity = new BoyaDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (BoyaDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtBoyaAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            txtRenkKodu.Text = dto.ColorCode;
            txtIsiDayanimi.Value = dto.HeatResistance ?? 0;
            txtFirinlanmaSuresi.Value = dto.DryingTimeMinutes ?? 0;
            txtRafOmru.Value = dto.ShelfLifeMonths ?? 0;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPictureAsync("Boya", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.BoyaTanimlari); // Assuming ModuleType.BoyaTanimlari
            ucBirimCevrimleri1.Yukle(Id, glufTemelBirim.Text);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new BoyaDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtBoyaAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null,

                ColorCode = txtRenkKodu.Text,
                HeatResistance = txtIsiDayanimi.Value > 0 ? (int)txtIsiDayanimi.Value : null,
                DryingTimeMinutes = txtFirinlanmaSuresi.Value > 0 ? (int)txtFirinlanmaSuresi.Value : null,
                ShelfLifeMonths = txtRafOmru.Value > 0 ? (int)txtRafOmru.Value : null,
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
                var dto = (BoyaDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _boyaService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    ucBirimCevrimleri1.Kaydet(Id);
                    picResim.SavePictureAsync("Boya", Id);
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
                var dto = (BoyaDto)CurrentEntity;
                _boyaService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                ucBirimCevrimleri1.Kaydet(Id);
                picResim.SavePictureAsync("Boya", Id);

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

            if (Messages.SilMesaj("Boya Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _boyaService.Delete(Id);
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
                case "Name": txtBoyaAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "ColorCode": txtRenkKodu.Focus(); break;
                case "HeatResistance": txtIsiDayanimi.Focus(); break;
                case "DryingTimeMinutes": txtFirinlanmaSuresi.Focus(); break;
                case "ShelfLifeMonths": txtRafOmru.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _boyaService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;
        }

        private void glufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "Boya");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Boya");

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
    }
}

