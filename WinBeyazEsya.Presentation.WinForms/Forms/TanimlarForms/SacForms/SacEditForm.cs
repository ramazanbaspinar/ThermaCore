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
using WinBeyazEsya.Presentation.WinForms.UserControls.Controls;
using WinBeyazEsya.Application.Interfaces.Common;

namespace WinBeyazEsya.Presentation.WinForms.Forms.SacForms
{
    public partial class SacEditForm : BaseEditForm
    {
        private readonly ISheetMetalService _sheetMetalService = default!;

        private readonly IQualityStandardService _qualityStandardService = default!;
        private readonly ISurfaceTypeService _surfaceTypeService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;



        public SacEditForm()
        {
            InitializeComponent();
        }

        public SacEditForm(
            ISheetMetalService sheetMetalService,
            IItemBarcodeService itemBarcodeService,
            IQualityStandardService qualityStandardService,
            ISurfaceTypeService surfaceTypeService,
            IUnitRepository unitRepository,
            ISpecialCodeService specialCodeService)
        {
            InitializeComponent();

            _sheetMetalService = sheetMetalService;

            _qualityStandardService = qualityStandardService;
            _surfaceTypeService = surfaceTypeService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = ModuleType.SacTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
            RequiresCodeTemplate = true;



            ucBarkodlar1.InitializeService(itemBarcodeService);
            
            var unitConversionService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService>(Program.ServiceProvider);
            ucBirimCevrimleri1.InitializeDependencies(unitConversionService, _unitRepository);

            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucEntityPicture1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
        }

        public override void Yukle()
        {


            glupKaliteStandart.Properties.DataSource = _qualityStandardService.GetAll().Where(x => x.IsActive).ToList();
            glupKaliteStandart.Properties.DisplayMember = "Name";
            glupKaliteStandart.Properties.ValueMember = "Id";

            glupYuzeyTip.Properties.DataSource = _surfaceTypeService.GetAll().Where(x => x.IsActive).ToList();
            glupYuzeyTip.Properties.DisplayMember = "Name";
            glupYuzeyTip.Properties.ValueMember = "Id";

            glupBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glupBirim.Properties.DisplayMember = "Name";
            glupBirim.Properties.ValueMember = "Id";

            glufOzelKod1.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Sac");
            glufOzelKod1.Properties.DisplayMember = "Code";
            glufOzelKod1.Properties.ValueMember = "Id";
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _sheetMetalService.GetById(Id);
            }
            else
            {
                CurrentEntity = new SheetMetalDto { IsActive = true, Density = 7.85m };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (SheetMetalDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtSacAdi.Text = dto.Name;

            glupKaliteStandart.EditValue = dto.QualityStandardId > 0 ? dto.QualityStandardId : null;
            glupYuzeyTip.EditValue = dto.SurfaceTypeId > 0 ? dto.SurfaceTypeId : null;
            glupBirim.EditValue = dto.UnitId > 0 ? dto.UnitId : null;
            glufOzelKod1.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            calcKalinlik.Value = dto.Thickness;
            calcOzkutle.Value = dto.Density == 0 ? 7.85m : dto.Density;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                ucEntityPicture1.LoadPicture("Sac", dto.Id);
            }
            else
            {
                ucEntityPicture1.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.SacTanimlari);
            
            string baseUnit = string.Empty;
            if (dto.UnitId > 0)
            {
                var unit = _unitRepository.GetById(dto.UnitId);
                baseUnit = unit != null ? unit.Name : string.Empty;
            }
            ucBirimCevrimleri1.Yukle(Id, baseUnit);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new SheetMetalDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtSacAdi.Text,

                QualityStandardId = glupKaliteStandart.EditValue != null ? Convert.ToInt64(glupKaliteStandart.EditValue) : 0,
                SurfaceTypeId = glupYuzeyTip.EditValue != null ? Convert.ToInt64(glupYuzeyTip.EditValue) : 0,
                UnitId = glupBirim.EditValue != null ? Convert.ToInt64(glupBirim.EditValue) : 0,
                SpecialCodeId = glufOzelKod1.EditValue != null ? Convert.ToInt64(glufOzelKod1.EditValue) : null,
                Thickness = calcKalinlik.Value,
                Density = calcOzkutle.Value,
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
                var dto = (SheetMetalDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _sheetMetalService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    ucEntityPicture1.SavePicture("Sac", Id);
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
                var dto = (SheetMetalDto)CurrentEntity;
                _sheetMetalService.Update(dto);

                ucBarkodlar1.Kaydet(Id);
                ucEntityPicture1.SavePicture("Sac", Id);
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

            if (Messages.SilMesaj("Sac Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _sheetMetalService.Delete(Id);
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
                case "Name": txtSacAdi.Focus(); break;
                case "QualityStandardId": glupKaliteStandart.Focus(); break;
                case "SurfaceTypeId": glupYuzeyTip.Focus(); break;
                case "UnitId": glupBirim.Focus(); break;
                case "Thickness": calcKalinlik.Focus(); break;
                case "Density": calcOzkutle.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _sheetMetalService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();


            glupKaliteStandart.SearchButtonClicked += glupKaliteStandart_SearchButtonClicked;
            glupYuzeyTip.SearchButtonClicked += glupYuzeyTip_SearchButtonClicked;
            glupBirim.SearchButtonClicked += glupBirim_SearchButtonClicked;
            glufOzelKod1.SearchButtonClicked += glufOzelKod1_SearchButtonClicked;
        }

        private void glufOzelKod1_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new WinBeyazEsya.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "Sac");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            // Kullanıcı liste ekranında yeni bir kod eklemiş olabilir, bu yüzden LookUp'ı yenile
            glufOzelKod1.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Sac");

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod1.EditValue = selectedId;
            }
        }

        private void glupKaliteStandart_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.KaliteStandartForms.KaliteStandartListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                
                    glupKaliteStandart.Properties.DataSource = _qualityStandardService.GetAll().Where(x => x.IsActive).ToList();
            if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                {
                    var secilenId = form.SelectedEntities[0].Id;
                    glupKaliteStandart.EditValue = secilenId;
                }
            }
        }

        private void glupYuzeyTip_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.YuzeyTipiForms.YuzeyTipiListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                
                    glupYuzeyTip.Properties.DataSource = _surfaceTypeService.GetAll().Where(x => x.IsActive).ToList();
            if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                {
                    var secilenId = form.SelectedEntities[0].Id;
                    glupYuzeyTip.EditValue = secilenId;
                }
            }
        }

        private void glupBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                
                    glupBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                {
                    var secilenId = form.SelectedEntities[0].Id;
                    glupBirim.EditValue = secilenId;
                }
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            // Eğer BaseEditForm kaydet butonunu açmadıysa ancak barkodlarda veya resimde değişiklik varsa Kaydet ve Geri Al butonlarını aktifleştir
            if (ucBarkodlar1.IsDirty() || ucEntityPicture1.IsDirty() || ucBirimCevrimleri1.IsDirty)
            {
                if (btnKaydet != null && !btnKaydet.Enabled) btnKaydet.Enabled = true;
                if (btnGerial != null && !btnGerial.Enabled) btnGerial.Enabled = true;
            }

            YetkiKontroluYap();
        }
    }
}
