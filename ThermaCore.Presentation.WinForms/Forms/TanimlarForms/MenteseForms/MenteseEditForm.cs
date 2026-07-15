using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.Repositories.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Domain.Extensions;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Domain.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TanimlarForms.MenteseForms
{
    public partial class MenteseEditForm : BaseEditForm
    {
        private readonly IHingeService _hingeService = default!;
        private readonly IUnitRepository _unitRepository = default!;
        private readonly ISpecialCodeService _specialCodeService = default!;
        private readonly IItemBarcodeService _itemBarcodeService = default!;

        public MenteseEditForm()
        {
            InitializeComponent();
            
            if (!DesignMode && Program.ServiceProvider != null)
            {
                _hingeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<IHingeService>(Program.ServiceProvider);
                _unitRepository = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<IUnitRepository>(Program.ServiceProvider);
                _specialCodeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<ISpecialCodeService>(Program.ServiceProvider);
                _itemBarcodeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<IItemBarcodeService>(Program.ServiceProvider);

                BaseKartTuru = ModuleType.MenteseTanimlari;
                DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 }; // Zırhlı Kural
                RequiresCodeTemplate = true;

                ucBarkodlar1.InitializeService(_itemBarcodeService); // Zırhlı Kural
                ucBarkodlar1.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
                picResim.OnDirtyChanged += (s, e) => ButonEnabledDurumu();
            }
        }

        public override void Yukle()
        {
            glufTemelBirim.Properties.DataSource = _unitRepository.GetAll().Where(x => x.IsActive).ToList();
            glufTemelBirim.Properties.DisplayMember = "Name";
            glufTemelBirim.Properties.ValueMember = "Name";

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Hinge");
            glufOzelKod.Properties.DisplayMember = "Code";
            glufOzelKod.Properties.ValueMember = "Id";

            // Nullable ComboBox'lar
            cmbMenteseTipi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            cmbMontajYonu.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _hingeService.GetById(Id);
            }
            else
            {
                CurrentEntity = new HingeDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (HingeDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtMenteseAdi.Text = dto.Name;

            glufTemelBirim.EditValue = string.IsNullOrWhiteSpace(dto.BaseUnit) ? null : dto.BaseUnit;
            glufOzelKod.EditValue = dto.SpecialCodeId > 0 ? dto.SpecialCodeId : null;
            
            cmbMenteseTipi.SelectedItem = dto.HingeType.HasValue ? dto.HingeType.Value.GetDescription() : null;
            cmbMontajYonu.SelectedItem = dto.MountingDirection.HasValue ? dto.MountingDirection.Value.GetDescription() : null;
            
            txtTasimaKapasitesi.EditValue = dto.LoadCapacityKg;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (dto.Id > 0)
            {
                picResim.LoadPicture("Hinge", dto.Id); // Zırhlı Kural: Senkron Resim Yükleme
            }
            else
            {
                picResim.ClearPicture();
            }

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }

            ucBarkodlar1.Yukle(Id, txtKod.Text, ModuleType.MenteseTanimlari); // Barkod Yükleme
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new HingeDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtMenteseAdi.Text,
                BaseUnit = glufTemelBirim.EditValue != null ? glufTemelBirim.EditValue.ToString() : string.Empty,
                HingeType = string.IsNullOrWhiteSpace(cmbMenteseTipi.Text) ? (HingeType?)null : cmbMenteseTipi.Text.GetEnum<HingeType>(),
                MountingDirection = string.IsNullOrWhiteSpace(cmbMontajYonu.Text) ? (MountingDirection?)null : cmbMontajYonu.Text.GetEnum<MountingDirection>(),
                LoadCapacityKg = txtTasimaKapasitesi.EditValue != null && txtTasimaKapasitesi.EditValue != DBNull.Value ? Convert.ToDecimal(txtTasimaKapasitesi.EditValue) : (decimal?)null,
                Description = txtAciklama.Text,
                SpecialCodeId = glufOzelKod.EditValue != null ? Convert.ToInt64(glufOzelKod.EditValue) : null,
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
                var dto = (HingeDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _hingeService.Insert(dto);

                if (Id > 0)
                {
                    ucBarkodlar1.Kaydet(Id); // Zırhlı Kural: Senkron Kayıt
                    picResim.SavePicture("Hinge", Id); // Zırhlı Kural: Senkron Kayıt
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
                var dto = (HingeDto)CurrentEntity;
                _hingeService.Update(dto);

                ucBarkodlar1.Kaydet(Id); // Zırhlı Kural: Senkron Kayıt
                picResim.SavePicture("Hinge", Id); // Zırhlı Kural: Senkron Kayıt

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

            if (Messages.SilMesaj("Menteşe Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _hingeService.Delete(Id);
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
                case "Name": txtMenteseAdi.Focus(); break;
                case "BaseUnit": glufTemelBirim.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _hingeService.IsCodeUnique(this.Id, code);
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            if (glufOzelKod != null)
                glufOzelKod.SearchButtonClicked += GlufOzelKod_SearchButtonClicked;

            if (glufTemelBirim != null)
                glufTemelBirim.SearchButtonClicked += GlufTemelBirim_SearchButtonClicked;
                
            cmbMenteseTipi.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<HingeType>().ToArray());
            cmbMontajYonu.Properties.Items.AddRange(ThermaCore.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<MountingDirection>().ToArray());
        }

        private void GlufOzelKod_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = new ThermaCore.Presentation.WinForms.Forms.OzelKodForms.OzelKodListForm(SpecialCodeType.SpecialCode, "Hinge");
            form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
            form.ShowDialog();

            glufOzelKod.Properties.DataSource = _specialCodeService.GetCodes(SpecialCodeType.SpecialCode, "Hinge");

            if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
            {
                var selectedId = form.SelectedEntities[0].Id;
                glufOzelKod.EditValue = selectedId;
            }
        }

        private void GlufTemelBirim_SearchButtonClicked(object? sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<ThermaCore.Presentation.WinForms.Forms.TanimlarForms.BirimForms.BirimListForm>();
            if (form != null)
            {
                form.FormAcilisTuru = ThermaCore.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
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

        protected internal override void ButonEnabledDurumu() // Zırhlı Kural
        {
            base.ButonEnabledDurumu();

            if (ucBarkodlar1.IsDirty() || picResim.IsDirty())
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