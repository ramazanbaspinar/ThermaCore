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

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CamForms.RenkOzellikForms
{
    public partial class CamRenkEditForm : BaseEditForm
    {
        private readonly IColorFeatureService _colorFeatureService = default!;

        public CamRenkEditForm()
        {
            InitializeComponent();
        }

        public CamRenkEditForm(IColorFeatureService colorFeatureService)
        {
            InitializeComponent();
            _colorFeatureService = colorFeatureService;

            BaseKartTuru = ModuleType.RenkTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1 };
            RequiresCodeTemplate = true;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _colorFeatureService.GetById(Id);
            }
            else
            {
                CurrentEntity = new ColorFeatureDto { IsActive = true };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (ColorFeatureDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtRenkOzellikAdi.Text = dto.Name;
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;

            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                txtKod.Text = "Yeni Kod";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new ColorFeatureDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtRenkOzellikAdi.Text,
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
                var dto = (ColorFeatureDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);

                Id = _colorFeatureService.Insert(dto);
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
                var dto = (ColorFeatureDto)CurrentEntity;
                _colorFeatureService.Update(dto);
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

            if (Messages.SilMesaj("Renk / Özellik") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _colorFeatureService.Delete(Id);
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
                case "Name": txtRenkOzellikAdi.Focus(); break;
                case "Description": txtAciklama.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _colorFeatureService.IsCodeUnique(this.Id, code);
        }
    }
}
