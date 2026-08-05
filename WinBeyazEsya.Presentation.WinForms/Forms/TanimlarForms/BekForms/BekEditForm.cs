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
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Extensions;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.BekForms
{
    public partial class BekEditForm : BaseEditForm
    {
        private readonly IBurnerService _burnerService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository _unitRepository = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService _specialCodeService = default!;

        // DevExpress Designer için parametresiz kurucu
        public BekEditForm()
        {
            InitializeComponent();
        }

        // DI Constructor
        public BekEditForm(
            IBurnerService burnerService,
            WinBeyazEsya.Application.Interfaces.Common.IItemBarcodeService itemBarcodeService,
            WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository unitRepository,
            WinBeyazEsya.Application.Interfaces.Common.ISpecialCodeService specialCodeService,
            WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService unitConversionService)
        {
            InitializeComponent();

            _burnerService = burnerService;
            _unitRepository = unitRepository;
            _specialCodeService = specialCodeService;

            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.BekGrubuTanimlari;
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
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(WinBeyazEsya.Domain.Enums.SpecialCodeType.SpecialCode, "Burner");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            cmbBekTipi.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<WinBeyazEsya.Domain.Enums.BurnerType>().ToArray());

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _burnerService.GetById(Id);
            }
            else
            {
                CurrentEntity = new WinBeyazEsya.Application.DTOs.Production.BurnerDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (WinBeyazEsya.Application.DTOs.Production.BurnerDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtBekAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;

            cmbBekTipi.SelectedItem = dto.BurnerType.HasValue ? WinBeyazEsya.Domain.Extensions.EnumExtensions.ToName(dto.BurnerType.Value) : null;
            
            txtBekBoyutu.EditValue = dto.SizeMm;
            txtGucKapasitesi.EditValue = dto.PowerKw;
            txtKapakTipi.Text = dto.CapType;

            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPictureAsync("Burner", dto.Id);
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, WinBeyazEsya.Domain.Enums.ModuleType.BekGrubuTanimlari);
            ucBirimCevrimleri1.Yukle(Id, glufTemelBirim.Text);
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new WinBeyazEsya.Application.DTOs.Production.BurnerDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtBekAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null,
                BurnerType = string.IsNullOrWhiteSpace(cmbBekTipi.Text) ? (BurnerType?)null : cmbBekTipi.Text.GetEnum<BurnerType>(),
                SizeMm = txtBekBoyutu.EditValue != null && txtBekBoyutu.EditValue != DBNull.Value ? Convert.ToDecimal(txtBekBoyutu.EditValue) : (decimal?)null,
                PowerKw = txtGucKapasitesi.EditValue != null && txtGucKapasitesi.EditValue != DBNull.Value ? Convert.ToDecimal(txtGucKapasitesi.EditValue) : (decimal?)null,
                CapType = txtKapakTipi.Text,
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
                var dto = (WinBeyazEsya.Application.DTOs.Production.BurnerDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                
                Id = _burnerService.Insert(dto);
                
                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id);
                    ucBirimCevrimleri1.Kaydet(Id);
                    picResim.SavePicture("Burner", Id);
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
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            ucBarkodlar1.PostGridChanges();
            ucBirimCevrimleri1.PostGridChanges();

            try
            {
                var dto = (WinBeyazEsya.Application.DTOs.Production.BurnerDto)CurrentEntity;
                _burnerService.Update(dto);
                
                ucBarkodlar1.Kaydet(Id);
                ucBirimCevrimleri1.Kaydet(Id);
                picResim.SavePicture("Burner", Id);

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
                WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected internal override void ButonEnabledDurumu()
        {
            base.ButonEnabledDurumu();

            bool isBarkodDirty = ucBarkodlar1 != null && ucBarkodlar1.IsDirty();
            bool isResimDirty = picResim != null && picResim.IsDirty();
            bool isBirimCevrimDirty = ucBirimCevrimleri1 != null && ucBirimCevrimleri1.IsDirty;

            if (isBarkodDirty || isResimDirty || isBirimCevrimDirty)
            {
                if (btnKaydet != null && !btnKaydet.Enabled) btnKaydet.Enabled = true;
                if (btnGerial != null && !btnGerial.Enabled) btnGerial.Enabled = true;
            }

            YetkiKontroluYap();
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj("Bek Grubu Tanımı") == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    _burnerService.Delete(Id);
                    RefreshYapilacak = true;
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                    Close();
                }
                catch (System.Exception ex)
                {
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
                finally
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                }
            }
        }
    }
}
