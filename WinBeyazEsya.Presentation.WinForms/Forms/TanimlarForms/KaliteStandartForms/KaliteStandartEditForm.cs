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
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Domain.Helpers;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.KaliteStandartForms
{
    public partial class KaliteStandartEditForm : BaseEditForm
    {
        private readonly IQualityStandardService _service;

        public KaliteStandartEditForm(IQualityStandardService service)
        {
            InitializeComponent();
            _service = service;
            
            DataLayoutControl = myDataLayoutControl1;
            
            cmbMalzemeTuru.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<MaterialGroup>().ToArray());
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _service.GetById(Id);
            }
            else
            {
                CurrentEntity = new QualityStandardDto 
                { 
                    IsActive = true 
                };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (QualityStandardDto)CurrentEntity;

            txtKod.Text = dto.Code;
            txtStandartAdi.Text = dto.Name;
            
            if (dto.MaterialGroup != 0)
                cmbMalzemeTuru.SelectedItem = dto.MaterialGroup.GetDescription();
                
            txtAciklama.Text = dto.Description;
            tglDurum.IsOn = dto.IsActive;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new QualityStandardDto
            {
                Id = this.Id,
                Code = txtKod.Text,
                Name = txtStandartAdi.Text,
                MaterialGroup = string.IsNullOrWhiteSpace(cmbMalzemeTuru.Text) ? (MaterialGroup)0 : cmbMalzemeTuru.Text.GetEnum<MaterialGroup>(),
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            var dto = (QualityStandardDto)CurrentEntity;
            dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
            
            Id = _service.Insert(dto);
            return Id > 0;
        }

        protected override bool EntityUpdate()
        {
            var dto = (QualityStandardDto)CurrentEntity;
            _service.Update(dto);
            return true;
        }
        
        protected override bool IsCodeUnique(string code)
        {
            return _service.IsCodeUnique(this.Id, code);
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Messages.SilMesaj("Kalite Standart") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _service.Delete(Id);
                    RefreshYapilacak = true;
                    Messages.SilindiMesaj();
                    Close();
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi($"Hata oluştu:\n{ex.Message}", "Hata");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
