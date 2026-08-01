using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Application.Interfaces.System;

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.GenelGiderForms
{
    public partial class GenelGiderEditForm : BaseEditForm
    {
        private readonly IGeneralExpenseService _genelGiderService = default!;
        private readonly IExchangeRateService _exchangeRateService = default!;

        public GenelGiderEditForm()
        {
            InitializeComponent();
        }

        public GenelGiderEditForm(IGeneralExpenseService genelGiderService, IExchangeRateService exchangeRateService)
        {
            InitializeComponent();
            _genelGiderService = genelGiderService;
            _exchangeRateService = exchangeRateService;
            BaseKartTuru = ModuleType.GenelGiderTanimlari;
        }

        public override void Yukle()
        {
            // Populate cmbParaBirimi with distinct CurrencyCodes or fallback to defaults
            cmbParaBirimi.Properties.Items.Clear();
            try 
            {
                var currencies = _exchangeRateService.GetAllRates()
                    .Where(x => !string.IsNullOrEmpty(x.CurrencyCode))
                    .Select(x => x.CurrencyCode)
                    .Distinct()
                    .ToList();
                
                if (currencies.Count > 0)
                {
                    foreach (var c in currencies)
                    {
                        cmbParaBirimi.Properties.Items.Add(c);
                    }
                }
                else 
                {
                    cmbParaBirimi.Properties.Items.AddRange(new string[] { "TRY", "USD", "EUR" });
                }
            }
            catch 
            {
                cmbParaBirimi.Properties.Items.AddRange(new string[] { "TRY", "USD", "EUR" });
            }

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                CurrentEntity = _genelGiderService.GetById(Id);
            }
            else
            {
                CurrentEntity = new GeneralExpenseDto { IsActive = true, Cost = 0, CurrencyCode = "TRY" };
            }

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var dto = (GeneralExpenseDto)CurrentEntity;

            Id = dto.Id;
            txtKod.Text = dto.Code;
            txtGenelGider.Text = dto.Name;
            txtGenelGiderMaliyeti.Value = dto.Cost;
            
            cmbParaBirimi.EditValue = dto.CurrencyCode;
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new GeneralExpenseDto
            {
                Id = Id,
                Code = txtKod.Text,
                Name = txtGenelGider.Text,
                Cost = txtGenelGiderMaliyeti.Value,
                CurrencyCode = cmbParaBirimi.EditValue?.ToString() ?? string.Empty,
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            try
            {
                var dto = (GeneralExpenseDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _genelGiderService.Insert(dto);
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
                var dto = (GeneralExpenseDto)CurrentEntity;
                _genelGiderService.Update(dto);
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

            if (Messages.SilMesaj("Genel Gider Tanımı") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _genelGiderService.Delete(Id);
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
                case "Name": txtGenelGider.Focus(); break;
                case "Cost": txtGenelGiderMaliyeti.Focus(); break;
                case "CurrencyCode": cmbParaBirimi.Focus(); break;
            }
        }

        protected override bool IsCodeUnique(string code)
        {
            return _genelGiderService.IsCodeUnique(this.Id, code);
        }
    }
}