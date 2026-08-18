using System.Xml;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Application.Services.Management;

public class ExchangeRateManager : IExchangeRateService
{
    private readonly IRepository<ExchangeRate> _exchangeRateRepository;
    private readonly IUnitOfWork _uow;

    public ExchangeRateManager(IRepository<ExchangeRate> exchangeRateRepository, IUnitOfWork uow)
    {
        _exchangeRateRepository = exchangeRateRepository;
        _uow = uow;
    }

    public async Task<bool> SyncTcmbRatesAsync()
    {
        try
        {
            using var client = new HttpClient();
            string xmlData = await client.GetStringAsync("https://www.tcmb.gov.tr/kurlar/today.xml");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);

            var rootNode = doc.SelectSingleNode("Tarih_Date");
            if (rootNode?.Attributes?["Date"] == null) return false;

            string dateStr = rootNode.Attributes["Date"]!.Value;
            if (!DateTime.TryParseExact(dateStr, "MM/dd/yyyy", null, global::System.Globalization.DateTimeStyles.None, out DateTime rateDate))
            {
                if (!DateTime.TryParse(dateStr, out rateDate))
                {
                    rateDate = DateTime.Today; // Fallback
                }
            }

            // Saat bilgisini kırp
            rateDate = rateDate.Date;

            // USD ve EUR için kayıt var mı kontrol et
            var existingRates = _exchangeRateRepository.Find(x => x.RateDate.Date == rateDate).ToList();
            bool usdExists = existingRates.Any(x => x.CurrencyCode == "USD");
            bool eurExists = existingRates.Any(x => x.CurrencyCode == "EUR");
            bool tryExists = existingRates.Any(x => x.CurrencyCode == "TRY");

            if (usdExists && eurExists && tryExists) return false;

            bool addedAny = false;
            var currencyNodes = doc.SelectNodes("Tarih_Date/Currency");
            if (currencyNodes != null)
            {
                foreach (XmlNode node in currencyNodes)
                {
                    string currencyCode = node.Attributes?["Kod"]?.Value ?? string.Empty;
                    if (currencyCode == "USD" && !usdExists || currencyCode == "EUR" && !eurExists)
                    {
                        var buyingNode = node.SelectSingleNode("ForexBuying");
                        var sellingNode = node.SelectSingleNode("ForexSelling");
                        var effBuyingNode = node.SelectSingleNode("BanknoteBuying");
                        var effSellingNode = node.SelectSingleNode("BanknoteSelling");

                        decimal.TryParse(buyingNode?.InnerText?.Replace(".", ","), out decimal tcmbBuying);
                        decimal.TryParse(sellingNode?.InnerText?.Replace(".", ","), out decimal tcmbSelling);

                        // İlgili gün için BİREBİR TCMB kurlarını "Geçerli Kur" olarak varsayılan atıyoruz
                        decimal effBuying = tcmbBuying;
                        decimal effSelling = tcmbSelling;

                        var exchangeRate = new ExchangeRate
                        {
                            Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(),
                            RateDate = rateDate,
                            CurrencyCode = currencyCode,
                            TcmbBuyingRate = tcmbBuying,
                            TcmbSellingRate = tcmbSelling,
                            EffectiveBuyingRate = effBuying,
                            EffectiveSellingRate = effSelling,
                            CreatedDate = DateTime.Now
                        };

                        _exchangeRateRepository.Add(exchangeRate);
                        addedAny = true;
                    }
                }

                if (!tryExists)
                {
                    var exchangeRateTry = new ExchangeRate
                    {
                        Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(),
                        RateDate = rateDate,
                        CurrencyCode = "TRY",
                        TcmbBuyingRate = 1.0000m,
                        TcmbSellingRate = 1.0000m,
                        EffectiveBuyingRate = 1.0000m,
                        EffectiveSellingRate = 1.0000m,
                        CreatedDate = DateTime.Now
                    };

                    _exchangeRateRepository.Add(exchangeRateTry);
                    addedAny = true;
                }

                if (addedAny)
                {
                    _uow.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        catch (Exception ex)
        {
            // Hatayı fırlat ki KurListForm'daki Yenile butonu yakalayıp kullanıcıya gösterebilsin.
            // AnaForm_Load (Arka plan) zaten kendi catch bloğunda bu hatayı yutacak.
            Console.WriteLine($"[ExchangeRateManager] Hata: {ex.Message}");
            throw;
        }
    }

    public List<ExchangeRateDto> GetAllRates()
    {
        return _exchangeRateRepository.GetAll()
            .OrderByDescending(x => x.RateDate)
            .Select(x => new ExchangeRateDto
            {
                Id = x.Id,
                RateDate = x.RateDate,
                CurrencyCode = x.CurrencyCode,
                TcmbBuyingRate = x.TcmbBuyingRate,
                TcmbSellingRate = x.TcmbSellingRate,
                EffectiveBuyingRate = x.EffectiveBuyingRate,
                EffectiveSellingRate = x.EffectiveSellingRate
            }).ToList();
    }

    public ExchangeRateDto GetRateById(long id)
    {
        var rate = _exchangeRateRepository.GetById(id);
        if (rate == null) throw new Exception("Kayıt bulunamadı.");

        return new ExchangeRateDto
        {
            Id = rate.Id,
            RateDate = rate.RateDate,
            CurrencyCode = rate.CurrencyCode,
            TcmbBuyingRate = rate.TcmbBuyingRate,
            TcmbSellingRate = rate.TcmbSellingRate,
            EffectiveBuyingRate = rate.EffectiveBuyingRate,
            EffectiveSellingRate = rate.EffectiveSellingRate
        };
    }

    public void UpdateEffectiveRates(long id, decimal effectiveBuying, decimal effectiveSelling)
    {
        var rate = _exchangeRateRepository.GetById(id);
        if (rate == null) throw new Exception("Kayıt bulunamadı.");

        rate.EffectiveBuyingRate = effectiveBuying;
        rate.EffectiveSellingRate = effectiveSelling;
        rate.ModifiedDate = DateTime.Now;
        // Düzeltme için User bilgisi alınabilir (gerekirse ICurrentTenantService üzerinden) ama şimdilik ModifiedDate yeterli

        _exchangeRateRepository.Update(rate);
        _uow.SaveChanges();
    }
}

