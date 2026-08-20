using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MetalVeSacGrubuForms
{
    public partial class MetalVeSacGrubuEditForm : BaseEditForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IMetalSheetGroupService _metalSheetGroupService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.IRepository<WinBeyazEsya.Domain.Entities.Definitions.Unit> _unitRepository = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService _specialCodeService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService _unitConversionService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService _itemBarcodeService = default!;
        private readonly IServiceProvider _serviceProvider = default!;

        public MetalVeSacGrubuEditForm()
        {
            InitializeComponent();
        }

        public MetalVeSacGrubuEditForm(
            WinBeyazEsya.Application.Interfaces.Definitions.IMetalSheetGroupService metalSheetGroupService,
            WinBeyazEsya.Application.Interfaces.Repositories.IRepository<WinBeyazEsya.Domain.Entities.Definitions.Unit> unitRepository,
            WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService specialCodeService,
            WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService unitConversionService,
            WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService itemBarcodeService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _metalSheetGroupService = metalSheetGroupService;
                _unitRepository = unitRepository;
                _specialCodeService = specialCodeService;
                _unitConversionService = unitConversionService;
                _itemBarcodeService = itemBarcodeService;
                _serviceProvider = serviceProvider;

                Bll = _metalSheetGroupService;
            }

            BaseKartTuru = Domain.Enums.ModuleType.MetalVeSacGrubu;
            RequiresCodeTemplate = true;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4, myDataLayoutControl5 };

            if (!DesignMode && _unitConversionService != null && _unitRepository != null)
            {
                ucBirimCevrimleri1.InitializeDependencies(_unitConversionService, _unitRepository);
            }

            picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBirimCevrimleri1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            ucBarkodlar1.InitializeService(_itemBarcodeService);
            ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();

            if (txtAgirlik != null)
            {
                txtAgirlik.Properties.ReadOnly = true;
                txtAgirlik.Properties.Mask.EditMask = "n6";
                txtAgirlik.Properties.DisplayFormat.FormatString = "n6";
                txtAgirlik.Properties.EditFormat.FormatString = "n6";
            }
            if (txtOzkutle != null)
            {
                txtOzkutle.Properties.Mask.EditMask = "n6";
                txtOzkutle.Properties.DisplayFormat.FormatString = "n6";
                txtOzkutle.Properties.EditFormat.FormatString = "n6";
            }
            if (glufTemelBirim != null)
            {
                glufTemelBirim.Properties.ReadOnly = true;
                foreach (DevExpress.XtraEditors.Controls.EditorButton btn in glufTemelBirim.Properties.Buttons)
                {
                    btn.Enabled = false;
                }
            }
        }

        public override void Yukle()
        {
            InitLookups();

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                CurrentEntity = new Application.DTOs.Definitions.MetalSheetGroupDto
                {
                    IsActive = true,
                    Density = 7.85m,
                    SurfaceCoatingType = Domain.Enums.SurfaceCoatingType.Boya
                };

                if (_unitRepository != null)
                {
                    var kgUnit = _unitRepository.Find(x => x.Code == "KG" || x.Name == "Kg" || x.Name == "KG").FirstOrDefault();
                    if (kgUnit != null)
                    {
                        ((Application.DTOs.Definitions.MetalSheetGroupDto)CurrentEntity).BaseUnitId = kgUnit.Id;
                    }
                }
            }
            else
                CurrentEntity = _metalSheetGroupService.GetById(Id);

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
                var specialCodes = _specialCodeService.GetCodes(Domain.Enums.SpecialCodeType.SpecialCode, "MetalSheetGroup");
                glufOzelKod.Properties.DataSource = specialCodes;
                glufOzelKod.Properties.ValueMember = "Id";
                glufOzelKod.Properties.DisplayMember = "Name";
            }

            if (cmbYuzeyKaplamaTipi != null)
            {
                cmbYuzeyKaplamaTipi.Properties.Items.AddRange(WinBeyazEsya.Domain.Extensions.EnumExtensions.GetEnumDescriptionList<Domain.Enums.SurfaceCoatingType>().ToArray());
            }
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Application.DTOs.Definitions.MetalSheetGroupDto)CurrentEntity;

            txtKod.Text = entity.Code;
            tglDurum.IsOn = entity.IsActive;
            txtMalzemeAdi.Text = entity.Name;
            glufTemelBirim.EditValue = entity.BaseUnitId == 0 ? (long?)null : entity.BaseUnitId;
            glufOzelKod.EditValue = entity.SpecialCodeId;

            txtYuzeyTipi.Text = entity.SurfaceType;
            txtKaliteKodu.Text = entity.QualityCode;

            txtEn.Value = entity.Width;
            txtBoy.Value = entity.Length;
            txtKalinlik.Value = entity.Thickness;

            if (txtOzkutle != null) txtOzkutle.Value = entity.Density;
            if (txtAgirlik != null) txtAgirlik.Value = entity.Weight;

            if (cmbYuzeyKaplamaTipi != null)
            {
                cmbYuzeyKaplamaTipi.EditValue = WinBeyazEsya.Domain.Extensions.EnumExtensions.ToName(entity.SurfaceCoatingType);
            }

            txtAciklama.Text = entity.Description;

            if (entity.Id > 0)
            {
                picResim.LoadPicture("MetalVeSacGrubu", entity.Id);
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
            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.MetalVeSacGrubu);

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new Application.DTOs.Definitions.MetalSheetGroupDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtMalzemeAdi.Text,
                IsActive = tglDurum.IsOn,
                BaseUnitId = (long)(glufTemelBirim.EditValue ?? 0L),
                SpecialCodeId = (long?)glufOzelKod.EditValue,
                SurfaceType = txtYuzeyTipi.Text,
                QualityCode = txtKaliteKodu.Text,
                Width = Convert.ToDecimal(txtEn.EditValue ?? 0m),
                Length = Convert.ToDecimal(txtBoy.EditValue ?? 0m),
                Thickness = Convert.ToDecimal(txtKalinlik.EditValue ?? 0m),
                Density = Convert.ToDecimal(txtOzkutle?.EditValue ?? 0m),
                Weight = Convert.ToDecimal(txtAgirlik?.EditValue ?? 0m),
                Description = txtAciklama.Text
            };

            if (cmbYuzeyKaplamaTipi != null && cmbYuzeyKaplamaTipi.EditValue != null)
            {
                var parsedEnum = WinBeyazEsya.Domain.Extensions.EnumExtensions.ToEnum<Domain.Enums.SurfaceCoatingType>(cmbYuzeyKaplamaTipi.EditValue.ToString());
                if (parsedEnum.HasValue)
                    dto.SurfaceCoatingType = parsedEnum.Value;
            }

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            ucBirimCevrimleri1.PostGridChanges();
            ucBarkodlar1.PostGridChanges();

            try
            {
                var dto = (Application.DTOs.Definitions.MetalSheetGroupDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _metalSheetGroupService.Insert(dto);

                if (Id > 0)
                {
                    picResim.SavePicture("MetalVeSacGrubu", Id);
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
                _metalSheetGroupService.Update((Application.DTOs.Definitions.MetalSheetGroupDto)CurrentEntity);

                picResim.SavePicture("MetalVeSacGrubu", Id);
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

            if (Helpers.Messages.SilMesaj("Metal ve Sac Grubu Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _metalSheetGroupService.Delete(Id);
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

            if (txtEn != null) txtEn.EditValueChanged += (s, e) => HesaplaAgirlik();
            if (txtBoy != null) txtBoy.EditValueChanged += (s, e) => HesaplaAgirlik();
            if (txtKalinlik != null) txtKalinlik.EditValueChanged += (s, e) => HesaplaAgirlik();
            if (txtOzkutle != null) txtOzkutle.EditValueChanged += (s, e) => HesaplaAgirlik();
        }

        private void HesaplaAgirlik()
        {
            decimal en = Convert.ToDecimal(txtEn?.EditValue ?? 0m);
            decimal boy = Convert.ToDecimal(txtBoy?.EditValue ?? 0m);
            decimal kalinlik = Convert.ToDecimal(txtKalinlik?.EditValue ?? 0m);
            decimal ozkutle = Convert.ToDecimal(txtOzkutle?.EditValue ?? 0m);

            decimal agirlik = (en * boy * kalinlik * ozkutle) / 1000000m;
            if (txtAgirlik != null) txtAgirlik.Value = Math.Round(agirlik, 6);
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
            var form = new OzelKodForms.OzelKodListForm(Domain.Enums.SpecialCodeType.SpecialCode, "MetalSheetGroup");
            form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            if (_specialCodeService != null)
            {
                glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(Domain.Enums.SpecialCodeType.SpecialCode, "MetalSheetGroup");
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
                case "SurfaceType": txtYuzeyTipi.Focus(); break;
                case "QualityCode": txtKaliteKodu.Focus(); break;
                case "Width": txtEn.Focus(); break;
                case "Length": txtBoy.Focus(); break;
                case "Thickness": txtKalinlik.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _metalSheetGroupService.IsCodeUnique(this.Id, code);
        }
    }
}
