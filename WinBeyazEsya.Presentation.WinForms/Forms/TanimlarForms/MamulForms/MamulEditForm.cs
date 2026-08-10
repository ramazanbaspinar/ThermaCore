using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.Interfaces.Common;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MamulForms
{
    public partial class MamulEditForm : BaseEditForm
    {
        private readonly IFinishedGoodService _finishedGoodService = default!;
        private readonly IRepository<Unit> _unitRepository = default!;
        private readonly IRepository<WinBeyazEsya.Domain.Entities.Management.SystemParameter> _systemParameterRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;
        private readonly IItemBarcodeService _itemBarcodeService = default!;
        private readonly IServiceProvider _serviceProvider = default!;

        public MamulEditForm()
        {
            InitializeComponent();
        }

        public MamulEditForm(
            IFinishedGoodService finishedGoodService,
            IRepository<Unit> unitRepository,
            IRepository<WinBeyazEsya.Domain.Entities.Management.SystemParameter> systemParameterRepository,
            ISpecialCodeService specialCodeService,
            IItemBarcodeService itemBarcodeService,
            IServiceProvider serviceProvider)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _finishedGoodService = finishedGoodService;
                _unitRepository = unitRepository;
                _systemParameterRepository = systemParameterRepository;
                _specialCodeService = specialCodeService;
                _itemBarcodeService = itemBarcodeService;
                _serviceProvider = serviceProvider;

                Bll = _finishedGoodService;
            }

            BaseKartTuru = ModuleType.FinishedGood;
            
            if (!DesignMode)
            {
                picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                if (ucBarkodlar1 != null) 
                {
                    ucBarkodlar1.InitializeService(_itemBarcodeService);
                    ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                }
            }
        }

        public override void Yukle()
        {
            InitLookups();

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                var newEntity = new Application.DTOs.Definitions.FinishedGoodDto 
                { 
                    IsActive = true
                };
                
                if (_unitRepository != null)
                {
                    var adetUnit = _unitRepository.Find(x => x.Code == "AD" || x.Name == "Adet" || x.Name == "ADET" || x.Name == "Ad.").FirstOrDefault();
                    if (adetUnit != null)
                    {
                        newEntity.UnitId = adetUnit.Id;
                    }
                }

                if (_systemParameterRepository != null)
                {
                    var sysParam = _systemParameterRepository.GetAll().FirstOrDefault();
                    if (sysParam != null && sysParam.DefaultSalesKdvId.HasValue)
                    {
                        newEntity.SalesVatRate = sysParam.DefaultSalesKdvId.Value; // As per user request, put default SalesKdvId to glufKdv (we assume SalesVatRate holds the ID or we map it to EditValue)
                    }
                }
                
                CurrentEntity = newEntity;
            }
            else
            {
                CurrentEntity = _finishedGoodService.GetById(Id);
            }

            NesneyiKontrollereBagla();
        }

        private void InitLookups()
        {
            if (_unitRepository != null)
            {
                var units = _unitRepository.Find(x => x.IsActive).ToList();
                if (glufTemelBirim != null)
                {
                    glufTemelBirim.Properties.DataSource = units;
                    glufTemelBirim.Properties.ValueMember = "Id";
                    glufTemelBirim.Properties.DisplayMember = "Name";
                }
            }

            if (_specialCodeService != null)
            {
                var specialCodes = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "FinishedGood");
                if (glufOzelKod != null)
                {
                    glufOzelKod.Properties.DataSource = specialCodes;
                    glufOzelKod.Properties.ValueMember = "Id";
                    glufOzelKod.Properties.DisplayMember = "Name";
                }
            }
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Application.DTOs.Definitions.FinishedGoodDto)CurrentEntity;

            if (txtKod != null) txtKod.Text = entity.Code;
            if (txtMamulAdi != null) txtMamulAdi.Text = entity.Name;
            if (glufMamulGrubu != null) glufMamulGrubu.EditValue = entity.GroupId;
            if (glufTemelBirim != null) glufTemelBirim.EditValue = entity.UnitId == 0 ? (long?)null : entity.UnitId;
            if (glufOzelKod != null) glufOzelKod.EditValue = entity.SpecialCodeId;
            if (txtSatisFiyati != null) txtSatisFiyati.Value = entity.SalesPrice;
            if (glufKdv != null) glufKdv.EditValue = entity.SalesVatRate;
            if (txtAciklama != null) txtAciklama.Text = entity.Description;
            if (tglDurum != null) tglDurum.IsOn = entity.IsActive;

            if (entity.Id > 0)
            {
                picResim?.LoadPicture("FinishedGood", entity.Id);
            }
            else
            {
                picResim?.ClearPicture();
            }

            if (ucBarkodlar1 != null)
            {
                ucBarkodlar1.Yukle(Id, txtKod?.Text, ModuleType.FinishedGood);
            }

            if (BaseIslemTuru == ActionType.EntityInsert && txtKod != null)
            {
                txtKod.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new Application.DTOs.Definitions.FinishedGoodDto
            {
                Id = Id,
                Code = txtKod?.Text ?? string.Empty,
                Name = txtMamulAdi?.Text ?? string.Empty,
                GroupId = glufMamulGrubu?.EditValue as long?,
                UnitId = (long)(glufTemelBirim?.EditValue ?? 0L),
                SpecialCodeId = glufOzelKod?.EditValue as long?,
                SalesPrice = Convert.ToDecimal(txtSatisFiyati?.EditValue ?? 0m),
                SalesVatRate = Convert.ToDecimal(glufKdv?.EditValue ?? 0m), // Convert EditValue to decimal (if it's a lookup, it might be an ID or value depending on implementation)
                Description = txtAciklama?.Text,
                IsActive = tglDurum?.IsOn ?? false
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            if (ucBarkodlar1 != null) ucBarkodlar1.PostGridChanges();
            
            try
            {
                var dto = (Application.DTOs.Definitions.FinishedGoodDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _finishedGoodService.Insert(dto);
                
                if (Id > 0)
                {
                    picResim?.SavePicture("FinishedGood", Id);
                    ucBarkodlar1?.Kaydet(Id);
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
            if (ucBarkodlar1 != null) ucBarkodlar1.PostGridChanges();
            
            try
            {
                _finishedGoodService.Update((Application.DTOs.Definitions.FinishedGoodDto)CurrentEntity);
                
                picResim?.SavePicture("FinishedGood", Id);
                ucBarkodlar1?.Kaydet(Id);

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

            if (Helpers.Messages.SilMesaj("Mamül Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _finishedGoodService.Delete(Id);
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

        protected override void LockFormControls(Control.ControlCollection controls)
        {
            base.LockFormControls(controls);
            picResim?.SetReadOnly(true);
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            if ((picResim != null && picResim.IsDirty()) || (ucBarkodlar1 != null && ucBarkodlar1.IsDirty()))
            {
                if (btnKaydet != null && !btnKaydet.Enabled) btnKaydet.Enabled = true;
                if (btnGerial != null && !btnGerial.Enabled) btnGerial.Enabled = true;
            }

            YetkiKontroluYap();
        }

        protected override bool IsCodeUnique(string code)
        {
            return _finishedGoodService.IsCodeUnique(this.Id, code);
        }
    }
}