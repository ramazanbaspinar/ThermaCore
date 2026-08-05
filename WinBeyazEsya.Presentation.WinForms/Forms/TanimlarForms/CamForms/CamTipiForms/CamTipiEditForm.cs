using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms.CamTipiForms
{
    public partial class CamTipiEditForm : BaseEditForm
    {
        private readonly IGlassTypeService _glassTypeService = default!;

        public CamTipiEditForm()
        {
            InitializeComponent();
        }

        public CamTipiEditForm(IGlassTypeService glassTypeService)
        {
            InitializeComponent();
            _glassTypeService = glassTypeService;

            BaseKartTuru = ModuleType.CamTipiTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1 };
            RequiresCodeTemplate = true;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _glassTypeService.GetById(Id);
            }
            else
            {
                CurrentEntity = new GlassTypeDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (GlassTypeDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtCamTipiAdi.Text = dto.Name;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new GlassTypeDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtCamTipiAdi.Text,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            try
            {
                var dto = (GlassTypeDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _glassTypeService.Insert(dto);
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
            try
            {
                var dto = (GlassTypeDto)CurrentEntity;
                _glassTypeService.Update(dto);
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

            if (Messages.SilMesaj("Cam Tipi") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _glassTypeService.Delete(Id);
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
                case "Name": txtCamTipiAdi.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _glassTypeService.IsCodeUnique(this.Id, code);
        }
    }
}
