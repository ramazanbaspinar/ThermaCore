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
using WinBeyazEsya.Application.Interfaces.Production;
using WinBeyazEsya.Application.Interfaces.System;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.DTOs.Production;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.BaseForms
{
    public partial class BaseMaliyetEditForm : BaseEditForm
    {
        protected readonly IMaterialCostService _materialCostService;
        protected readonly IExchangeRateService _exchangeRateService;

        public BaseMaliyetEditForm()
        {
            InitializeComponent();
            if (!IsDesignMode && Program.ServiceProvider != null)
            {
                _materialCostService = Program.ServiceProvider.GetService<IMaterialCostService>();
                _exchangeRateService = Program.ServiceProvider.GetService<IExchangeRateService>();
            }
        }

        protected virtual void MalzemeListesiniDoldur() { }

        public override void Yukle()
        {
            if (BaseIslemTuru == WinBeyazEsya.Domain.Enums.ActionType.EntityUpdate)
            {
                if (_materialCostService != null)
                {
                    CurrentEntity = _materialCostService.GetById(Id);
                }
            }
            else
            {
                CurrentEntity = new MaterialCostDto { IsActive = true, Cost = 0, CurrencyCode = "TRY" };
            }

            MalzemeListesiniDoldur();
            ParaBirimleriniDoldur();
            
            NesneyiKontrollereBagla();
            base.Yukle();
        }

        private void ParaBirimleriniDoldur()
        {
            if (_exchangeRateService != null && cmbParaBirimi != null)
            {
                var currencies = _exchangeRateService.GetAllRates().Select(x => x.CurrencyCode).Distinct().ToList();
                cmbParaBirimi.Properties.Items.Clear();
                foreach (var c in currencies)
                {
                    cmbParaBirimi.Properties.Items.Add(c);
                }
            }
        }

        protected override void NesneyiKontrollereBagla()
        {
            if (CurrentEntity is MaterialCostDto dto)
            {
                if (txtKod != null) txtKod.Text = dto.Code;
                if (glfMalzemeSecimi != null) glfMalzemeSecimi.EditValue = dto.MaterialId;
                if (txtMaliyet != null) txtMaliyet.EditValue = dto.Cost;
                if (cmbParaBirimi != null) cmbParaBirimi.EditValue = dto.CurrencyCode;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            if (CurrentEntity == null)
            {
                CurrentEntity = new MaterialCostDto();
            }

            if (CurrentEntity is MaterialCostDto dto)
            {
                if (txtKod != null) dto.Code = txtKod.Text;
                
                if (glfMalzemeSecimi != null && glfMalzemeSecimi.EditValue != null) 
                    dto.MaterialId = Convert.ToInt64(glfMalzemeSecimi.EditValue);
                else
                    dto.MaterialId = 0;

                if (txtMaliyet != null && txtMaliyet.EditValue != null) 
                    dto.Cost = Convert.ToDecimal(txtMaliyet.EditValue);
                else
                    dto.Cost = 0;

                if (cmbParaBirimi != null && cmbParaBirimi.EditValue != null) 
                    dto.CurrencyCode = cmbParaBirimi.EditValue.ToString();
                else
                    dto.CurrencyCode = string.Empty;
                
                dto.MaterialType = BaseKartTuru;
            }
        }

        protected override bool EntityInsert()
        {
            try
            {
                var dto = (MaterialCostDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                
                if (_materialCostService != null)
                {
                    Id = _materialCostService.Insert(dto);
                    return Id > 0;
                }
                return false;
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
            try
            {
                var dto = (MaterialCostDto)CurrentEntity;
                if (_materialCostService != null)
                {
                    _materialCostService.Update(dto);
                    return true;
                }
                return false;
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

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj("Maliyet Kaydı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (_materialCostService != null)
                    {
                        _materialCostService.Delete(Id);
                    }
                    RefreshYapilacak = true;
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilindiMesaj();
                    Close();
                }
                catch (FluentValidation.ValidationException ex)
                {
                    XtraMessageBox.Show(ex.Message, "Silme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
