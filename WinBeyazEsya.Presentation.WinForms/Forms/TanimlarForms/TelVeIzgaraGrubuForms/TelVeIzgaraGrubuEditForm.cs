using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.TelVeIzgaraForms
{
    public partial class TelVeIzgaraGrubuEditForm : BaseEditForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IWireAndGridGroupService _wireAndGridGroupService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.IRepository<WinBeyazEsya.Domain.Entities.Definitions.Unit> _unitRepository = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService _specialCodeService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService _unitConversionService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService _itemBarcodeService = default!;
        private readonly IServiceProvider _serviceProvider = default!;

        public TelVeIzgaraGrubuEditForm()
        {
            InitializeComponent();
        }

        public TelVeIzgaraGrubuEditForm(
            WinBeyazEsya.Application.Interfaces.Definitions.IWireAndGridGroupService wireAndGridGroupService,
            WinBeyazEsya.Application.Interfaces.Repositories.IRepository<WinBeyazEsya.Domain.Entities.Definitions.Unit> unitRepository,
            WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService specialCodeService,
            WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService unitConversionService,
            WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService itemBarcodeService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _wireAndGridGroupService = wireAndGridGroupService;
                _unitRepository = unitRepository;
                _specialCodeService = specialCodeService;
                _unitConversionService = unitConversionService;
                _itemBarcodeService = itemBarcodeService;
                _serviceProvider = serviceProvider;

                Bll = _wireAndGridGroupService;
            }

            BaseKartTuru = Domain.Enums.ModuleType.TelVeIzgaraGrubu;
            RequiresCodeTemplate = true;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2 };

            if (!DesignMode && _unitConversionService != null && _unitRepository != null)
            {
                ucBirimCevrimleri1.InitializeDependencies(_unitConversionService, _unitRepository);
            }

            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBarkodlar1.InitializeService(_itemBarcodeService);
            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
        }

        public override void Yukle()
        {
            InitLookups();

            if (BaseIslemTuru == ActionType.EntityInsert)
                CurrentEntity = new Application.DTOs.Definitions.WireAndGridGroupDto { IsActive = true };
            else
                CurrentEntity = _wireAndGridGroupService.GetById(Id);

            NesneyiKontrollereBagla();
        }

        private void InitLookups()
        {
            if (_unitRepository != null)
            {
                var units = _unitRepository.Find(x => x.IsActive).ToList();
                glufTemelBirim.Properties.DataSource = units;
                glufTemelBirim.Properties.ValueMember = "Id";
                glufTemelBirim.Properties.DisplayMember = "Name";
            }

            if (_specialCodeService != null)
            {
                var specialCodes = _specialCodeService.GetCodes(Domain.Enums.SpecialCodeType.SpecialCode, "WireAndGridGroup");
                glufOzelKod.Properties.DataSource = specialCodes;
                glufOzelKod.Properties.ValueMember = "Id";
                glufOzelKod.Properties.DisplayMember = "Name";
            }
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Application.DTOs.Definitions.WireAndGridGroupDto)CurrentEntity;

            txtKod.Text = entity.Code;
            tglDurum.IsOn = entity.IsActive;
            txtMalzemeAdi.Text = entity.Name;
            glufTemelBirim.EditValue = entity.BaseUnitId == 0 ? (long?)null : entity.BaseUnitId;
            glufOzelKod.EditValue = entity.SpecialCodeId;
            
            txtAciklama.Text = entity.Description;
            if (txtKaplamaTipi != null) txtKaplamaTipi.Text = entity.CoatingType;
            if (txtMalzemeTipi != null) txtMalzemeTipi.Text = entity.MaterialType;

            if (entity.Id > 0)
            {
                picResim.LoadPicture("TelVeIzgaraGrubu", entity.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            string baseUnit = string.Empty;
            if (entity.BaseUnitId > 0)
            {
                var unit = _unitRepository?.GetById(entity.BaseUnitId);
                baseUnit = unit != null ? unit.Name : string.Empty;
            }
            ucBirimCevrimleri1.Yukle(Id, baseUnit);
            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.TelVeIzgaraGrubu);

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new Application.DTOs.Definitions.WireAndGridGroupDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtMalzemeAdi.Text,
                IsActive = tglDurum.IsOn,
                BaseUnitId = (long)(glufTemelBirim.EditValue ?? 0L),
                SpecialCodeId = (long?)glufOzelKod.EditValue,
                Description = txtAciklama.Text
            };

            if (txtKaplamaTipi != null) dto.CoatingType = txtKaplamaTipi.Text;
            if (txtMalzemeTipi != null) dto.MaterialType = txtMalzemeTipi.Text;
            
            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            ucBirimCevrimleri1.PostGridChanges();
            ucBarkodlar1.PostGridChanges();
            
            try
            {
                var dto = (Application.DTOs.Definitions.WireAndGridGroupDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _wireAndGridGroupService.Insert(dto);
                
                if (Id > 0)
                {
                    picResim.SavePicture("TelVeIzgaraGrubu", Id);
                    ucBirimCevrimleri1.Kaydet(Id);
                    ucBarkodlar1.Kaydet(Id);
                }

                return Id > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            ucBirimCevrimleri1.PostGridChanges();
            ucBarkodlar1.PostGridChanges();
            
            try
            {
                _wireAndGridGroupService.Update((Application.DTOs.Definitions.WireAndGridGroupDto)CurrentEntity);
                
                picResim.SavePicture("TelVeIzgaraGrubu", Id);
                ucBirimCevrimleri1.Kaydet(Id);
                ucBarkodlar1.Kaydet(Id);

                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Helpers.Messages.HataBasligi(msg, "Güncelleme Hatası");
                return false;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Helpers.Messages.SilMesaj("Tel ve Izgara Grubu Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _wireAndGridGroupService.Delete(Id);
                    RefreshYapilacak = true;
                    Helpers.Messages.SilindiMesaj();
                    Close();
                }
                catch (Exception ex)
                {
                    Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
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

            glufTemelBirim.SearchButtonClicked += glufTemelBirim_SearchButtonClicked;
            glufOzelKod.SearchButtonClicked += glufOzelKod_SearchButtonClicked;
        }

        private void glufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            if (_serviceProvider != null)
            {
                var form = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<BirimForms.BirimListForm>(_serviceProvider);
                if (form != null)
                {
                    form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                    form.ShowDialog();
                    
                    if (_unitRepository != null)
                    {
                        glufTemelBirim.Properties.DataSource = _unitRepository.Find(x => x.IsActive).ToList();
                    }
                    
                    if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0)
                    {
                        var secilenId = form.SelectedEntities[0].Id;
                        glufTemelBirim.EditValue = secilenId;
                    }
                }
            }
        }

        private void glufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new OzelKodForms.OzelKodListForm(Domain.Enums.SpecialCodeType.SpecialCode, "WireAndGridGroup");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            if (_specialCodeService != null)
            {
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(Domain.Enums.SpecialCodeType.SpecialCode, "WireAndGridGroup");
            }

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        protected override void LockFormControls(Control.ControlCollection controls)
        {
            base.LockFormControls(controls);
            picResim.SetReadOnly(true);
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            if (picResim.IsDirty() || ucBirimCevrimleri1.IsDirty || ucBarkodlar1.IsDirty())
            {
                if (btnKaydet != null && !btnKaydet.Enabled) btnKaydet.Enabled = true;
                if (btnGerial != null && !btnGerial.Enabled) btnGerial.Enabled = true;
            }

            YetkiKontroluYap();
        }

        protected override void FocusControlByPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Code": txtKod.Focus(); break;
                case "Name": txtMalzemeAdi.Focus(); break;
                case "BaseUnitId": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _wireAndGridGroupService.IsCodeUnique(this.Id, code);
        }
    }
}
