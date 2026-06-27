using System;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Application.Services.Management;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using System.Linq;

namespace ThermaCore.Presentation.WinForms.Forms.FabrikaForms
{
    public partial class FabrikaEditForm : BaseEditForm
    {
        private readonly IBranchService _branchService = default!;
        private readonly ICurrentTenantService _currentTenantService = default!;

        private long _sirketId;
        private string _sirketAdi = string.Empty;

        public FabrikaEditForm()
        {
            InitializeComponent();
        }

        public FabrikaEditForm(IBranchService branchService, ICurrentTenantService currentTenantService)
        {
            InitializeComponent();
            _branchService = branchService;
            _currentTenantService = currentTenantService;
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();

            txtKod.EditValueChanged += Control_EditValueChanged;
            txtFabrikaAdi.EditValueChanged += Control_EditValueChanged;
            txtAciklama.EditValueChanged += Control_EditValueChanged;
            tglDurum.EditValueChanged += Control_EditValueChanged;
        }

        public void SetSirketBilgisi(long sirketId, string sirketAdi)
        {
            _sirketId = sirketId;
            _sirketAdi = sirketAdi;
            this.FirmaId = sirketId;
            this.BaseKartTuru = ModuleType.Factory;
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == ActionType.EntityInsert ? new BranchDto() : _branchService.GetById(Id);
            
            Text = $"Fabrika Tanımı ({_sirketAdi})";

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var dto = (BranchDto)OldEntity;
                if (dto != null)
                {
                    if (dto.TenantDatabaseId != _sirketId)
                    {
                        Messages.HataBasligi("Farklı bir şirkete ait fabrikayı görüntüleyemezsiniz!", "Güvenlik İhlali");
                        Close();
                        return;
                    }

                    txtKod.Text = dto.Code;
                    txtFabrikaAdi.Text = dto.BranchName;
                    txtAciklama.Text = dto.Description;
                    tglDurum.IsOn = dto.IsActive;
                }
            }
            else
            {
                Id = BaseIslemTuru.IdOlustur(OldEntity);
                txtKod.Text = "";
                txtFabrikaAdi.Text = "";
                txtAciklama.Text = "";
                tglDurum.IsOn = true;
                txtKod.Enabled = true;
                txtFabrikaAdi.Focus();
            }
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new BranchDto
            {
                Id = this.Id,
                TenantDatabaseId = _sirketId,
                Code = txtKod.Text,
                BranchName = txtFabrikaAdi.Text,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };

            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var dto = (BranchDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(dto);
                this.Id = dto.Id;

                _branchService.Insert(dto);
                
                Messages.BilgiBasligi("Fabrika bilgileri başarıyla eklendi.", "Kayıt Başarılı");
                return true;
            }
            catch (FluentValidation.ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi($"Ekleme sırasında hata oluştu:\n{ex.Message}", "Hata");
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override bool EntityUpdate()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var dto = (BranchDto)CurrentEntity;
                if (dto.TenantDatabaseId != _sirketId)
                {
                    Messages.HataBasligi("Farklı bir şirkete ait fabrikayı güncelleyemezsiniz!", "Güvenlik İhlali");
                    return false;
                }
                
                var existingDto = _branchService.GetById(dto.Id);
                if (existingDto != null)
                {
                    if (existingDto.TenantDatabaseId != _sirketId)
                    {
                        Messages.HataBasligi("Farklı bir şirkete ait fabrikayı güncelleyemezsiniz!", "Güvenlik İhlali");
                        return false;
                    }

                    _branchService.Update(dto);
                    
                    Messages.BilgiBasligi("Fabrika bilgileri başarıyla güncellendi.", "Bilgi");
                    return true;
                }
                return false;
            }
            catch (FluentValidation.ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi($"Güncelleme sırasında hata oluştu:\n{ex.Message}", "Hata");
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Messages.SilMesaj("Fabrika") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var dto = _branchService.GetById(Id);
                    if (dto != null)
                    {
                        if (dto.TenantDatabaseId != _sirketId)
                        {
                            Messages.HataBasligi("Farklı bir şirkete ait fabrikayı silemezsiniz!", "Güvenlik İhlali");
                            return;
                        }

                        _branchService.Delete(dto.Id);
                        RefreshYapilacak = true;
                        Messages.SilindiMesaj();
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi($"Silme işlemi sırasında hata oluştu:\n{ex.Message}", "Hata");
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
                case "BranchName": txtFabrikaAdi.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return !_branchService.GetAll().Any(x => x.Code == code && x.TenantDatabaseId == _sirketId);
        }

        protected override void ApplyCodeTemplateLogic()
        {
            base.ApplyCodeTemplateLogic();

            var sablonRepo = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetService<ThermaCore.Application.Interfaces.Repositories.IMasterRepository<ThermaCore.Domain.Entities.Management.CodeTemplate>>(Program.ServiceProvider);
            ThermaCore.Domain.Entities.Management.CodeTemplate sablon = null;

            if (sablonRepo != null)
            {
                sablon = System.Linq.Enumerable.FirstOrDefault(sablonRepo.Find(x => x.Module == BaseKartTuru && !x.IsDeleted));
            }

            bool isReadOnly = true;
            if (sablon == null || !sablon.IsAutoCodeGenerationEnabled)
            {
                isReadOnly = false;
            }
            else if (sablon.IsUserInterventionAllowed)
            {
                isReadOnly = false;
            }

            txtKod.Properties.ReadOnly = isReadOnly;
        }
    }
}