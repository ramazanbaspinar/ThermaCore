using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Common;
using ThermaCore.Application.Interfaces.Common;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.OzelKodForms
{
    public partial class OzelKodEditForm : BaseEditForm
    {
        private readonly ISpecialCodeService _specialCodeService;
        private readonly SpecialCodeType _codeType;
        private readonly string _entityType;

        public OzelKodEditForm(params object[] prm)
        {
            InitializeComponent();
            _specialCodeService = Program.ServiceProvider.GetRequiredService<ISpecialCodeService>();

            if (prm != null && prm.Length >= 2)
            {
                _codeType = (SpecialCodeType)prm[0];
                _entityType = (string)prm[1];
            }
            else
            {
                throw new ArgumentException("OzelKodEditForm params object[] prm eksik! (SpecialCodeType ve EntityType gerekli)");
            }

            BaseKartTuru = ModuleType.KodYonetimi;
            DataLayoutControl = myDataLayoutControl1;

            string titlePrefix = _codeType == SpecialCodeType.SpecialCode ? "Özel Kod Kaydı" : "Grup Kodu Kaydı";
            
            string entityNameTr = _entityType switch
            {
                "Screw" => "Vida",
                "HeatingElement" => "Rezistans",
                "GasValve" => "Gaz Musluğu",
                "Burner" => "Bek Grubu",
                "RotarySwitch" => "Anahtar / Rotary",
                "Thermostat" => "Termostat",
                "OvenTimer" => "Timer",
                "Knob" => "Düğme",
                "OvenGlass" => "Cam",
                "GlassType" => "Cam Tipi",
                "ColorFeature" => "Cam Renk Özellik",
                "Cable" => "Kablo",
                "Hotplate" => "Pleyt Isıtıcı",
                "OvenLamp" => "Lamba",
                "OvenMotor" => "Motor",
                "OvenFan" => "Fan / Pervane",
                _ => _entityType
            };
            
            this.Text = $"{titlePrefix} ({entityNameTr})";
            layoutControlItem2.Text = _codeType == SpecialCodeType.SpecialCode ? "Özel Kod Adı" : "Grup Kodu Adı";
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _specialCodeService.GetById(Id);
            }
            else
            {
                CurrentEntity = new SpecialCodeDto 
                { 
                    CodeType = _codeType,
                    EntityType = _entityType,
                    IsActive = true 
                };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (SpecialCodeDto)CurrentEntity;

            txtKod.Text = dto.Code;
            txtOzelKodAdi.Text = dto.Name;
            txtAciklama.Text = dto.Description; 
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new SpecialCodeDto
            {
                Id = this.Id,
                CodeType = _codeType,
                EntityType = _entityType,
                Code = txtKod.Text,
                Name = txtOzelKodAdi.Text,
                Description = txtAciklama.Text,
                IsActive = true
            };
            
            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            var dto = (SpecialCodeDto)CurrentEntity;
            dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
            
            try
            {
                Id = _specialCodeService.Insert(dto);
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
            var dto = (SpecialCodeDto)CurrentEntity;
            
            try
            {
                _specialCodeService.Update(dto);
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

        protected override bool IsCodeUnique(string code)
        {
            return _specialCodeService.IsCodeUnique(this.Id, _codeType, _entityType, code);
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            string msgName = _codeType == SpecialCodeType.SpecialCode ? "Özel Kod" : "Grup Kodu";

            if (Messages.SilMesaj(msgName) == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _specialCodeService.Delete(Id);
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