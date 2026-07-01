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
using ThermaCore.Presentation.WinForms.UserControls.Controls;
using ThermaCore.Application.Interfaces.Common;

namespace ThermaCore.Presentation.WinForms.Forms.SacForms
{
    public partial class SacEditForm : BaseEditForm
    {
        private readonly ISheetMetalService _sheetMetalService = default!;

        private readonly IQualityStandardService _qualityStandardService = default!;
        private readonly ISurfaceTypeService _surfaceTypeService = default!;
        private readonly IUnitRepository _unitRepository = default!;

        public SacEditForm()
        {
            InitializeComponent();
        }

        public SacEditForm(
            ISheetMetalService sheetMetalService,
            IItemBarcodeService itemBarcodeService,
            IQualityStandardService qualityStandardService,
            ISurfaceTypeService surfaceTypeService,
            IUnitRepository unitRepository)
        {
            InitializeComponent();

            _sheetMetalService = sheetMetalService;
            
            _qualityStandardService = qualityStandardService;
            _surfaceTypeService = surfaceTypeService;
            _unitRepository = unitRepository;

            BaseKartTuru = ModuleType.SacTanimlari;
            DataLayoutControl = myDataLayoutControl1;
            RequiresCodeTemplate = true;

            picResim.Tag = "Image";
            
            ucBarkodlar1.InitializeService(itemBarcodeService);
            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
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
            calcKalinlik.Value = dto.Thickness;
            calcOzkutle.Value = dto.Density == 0 ? 7.85m : dto.Density;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;
            picResim.EditValue = dto.Image;

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
            
            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.SacTanimlari);
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
                Thickness = calcKalinlik.Value,
                Density = calcOzkutle.Value,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn,
                Image = (byte[]?)picResim.EditValue
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
        }



        private void glupKaliteStandart_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.KaliteStandartForms.KaliteStandartListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                {
                    var secilenId = form.SelectedEntities[0].Id;
                    glupKaliteStandart.Properties.DataSource = _qualityStandardService.GetAll().Where(x => x.IsActive).ToList();
                    glupKaliteStandart.EditValue = secilenId;
                }
            }
        }

        private void glupYuzeyTip_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.YuzeyTipiForms.YuzeyTipiListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                {
                    var secilenId = form.SelectedEntities[0].Id;
                    glupYuzeyTip.Properties.DataSource = _surfaceTypeService.GetAll().Where(x => x.IsActive).ToList();
                    glupYuzeyTip.EditValue = secilenId;
                }
            }
        }

        private void glupBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>(Program.ServiceProvider);
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                {
                    var secilenId = form.SelectedEntities[0].Id;
                    glupBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
                    glupBirim.EditValue = secilenId;
                }
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();
            
            // Eğer BaseEditForm kaydet butonunu açmadıysa ancak barkodlarda değişiklik varsa Kaydet ve Geri Al butonlarını aktifleştir
            if (ucBarkodlar1.IsDirty())
            {
                if (btnKaydet != null && !btnKaydet.Enabled) btnKaydet.Enabled = true;
                if (btnGerial != null && !btnGerial.Enabled) btnGerial.Enabled = true;
            }
        }
    }
}