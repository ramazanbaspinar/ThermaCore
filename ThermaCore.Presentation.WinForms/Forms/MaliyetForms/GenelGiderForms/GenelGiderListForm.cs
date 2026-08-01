using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.Interfaces.Definitions;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Application.DTOs.Definitions;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.MaliyetForms.GenelGiderForms
{
    public partial class GenelGiderListForm : BaseListForm
    {
        private readonly IGeneralExpenseService _service;
        private readonly IServiceProvider _serviceProvider;
        private readonly IExchangeRateService _exchangeRateService;
        
        private Dictionary<string, decimal> _guncelKurlar = new Dictionary<string, decimal>();
        private decimal _dipToplamTL = 0;

        public GenelGiderListForm(
            IGeneralExpenseService service, 
            IServiceProvider serviceProvider,
            IExchangeRateService exchangeRateService)
        {
            InitializeComponent();
            _service = service;
            _serviceProvider = serviceProvider;
            _exchangeRateService = exchangeRateService;
            
            BaseKartTuru = ModuleType.GenelGiderTanimlari;
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            Navigator = longNavigator1.Navigator;
            BaseKartTuru = ModuleType.GenelGiderTanimlari;
            AktifPasifButonGoster = false;

            Tablo.OptionsView.ShowFooter = true;
            
            var colCost = Tablo.Columns["Cost"];
            if (colCost != null)
            {
                colCost.Summary.Clear();
                colCost.Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Cost", "Toplam: {0:n2} TL");
            }
            Tablo.CustomSummaryCalculate += Tablo_CustomSummaryCalculate;
        }

        protected override void Listele()
        {
            try
            {
                var rates = _exchangeRateService.GetAllRates();
                _guncelKurlar.Clear();
                foreach (var rate in rates)
                {
                    if (!string.IsNullOrEmpty(rate.CurrencyCode))
                    {
                        // SellingRate veya BuyingRate durumuna göre (Örnekte EffectiveSellingRate alınmıştır)
                        _guncelKurlar[rate.CurrencyCode] = rate.EffectiveSellingRate > 0 ? rate.EffectiveSellingRate : rate.EffectiveBuyingRate;
                    }
                }
            }
            catch
            {
                // Kur servisine erişilemezse boş bırakılır
            }

            var liste = _service.GetAll().Where(x => x.IsActive == AktifKartlariGoster).ToList();
            Tablo.GridControl.DataSource = liste;
        }

        private void Tablo_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            {
                _dipToplamTL = 0;
            }
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                var cost = Convert.ToDecimal(Tablo.GetRowCellValue(e.RowHandle, "Cost") ?? 0);
                var currencyCode = Tablo.GetRowCellValue(e.RowHandle, "CurrencyCode")?.ToString();

                if (string.IsNullOrEmpty(currencyCode) || currencyCode == "TRY" || currencyCode == "TL")
                {
                    _dipToplamTL += cost;
                }
                else
                {
                    if (_guncelKurlar.TryGetValue(currencyCode, out decimal rate) && rate > 0)
                    {
                        _dipToplamTL += (cost * rate);
                    }
                    else
                    {
                        // Kur bulunamazsa birebir eklenir
                        _dipToplamTL += cost;
                    }
                }
            }
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                e.TotalValue = _dipToplamTL;
            }
        }

        protected override void ShowEditForm(long id)
        {
            var form = _serviceProvider.GetRequiredService<GenelGiderEditForm>();
            if (form != null)
            {
                form.IdAtaVeAc(id);
                Listele();
                if (form.Id > 0)
                {
                    Tablo.RowFocus("Id", form.Id);
                }
            }
        }

        protected override void EntityDelete()
        {
            if (Tablo.FocusedRowHandle < 0) return;

            long entityId = 0;
            long.TryParse(Tablo.GetFocusedRowCellValue("Id")?.ToString(), out entityId);
            
            if (entityId <= 0) return;

            var result = Messages.SilMesaj(Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Name")?.ToString() ?? "");
            if (result == DialogResult.Yes)
            {
                try
                {
                    _service.Delete(entityId);
                    Listele();
                }
                catch (Exception ex)
                {
                    Messages.HataBasligi(ex.Message, "Silme Hatası");
                }
            }
        }
    }
}