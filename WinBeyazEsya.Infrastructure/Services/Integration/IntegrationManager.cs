using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WinBeyazEsya.Application.DTOs.Integration;
using WinBeyazEsya.Application.Interfaces.Integration;
using WinBeyazEsya.Application.Interfaces.System;
using WinBeyazEsya.Domain.Entities.Definitions;
using WinBeyazEsya.Domain.Helpers;
using WinBeyazEsya.Infrastructure.Persistence;

namespace WinBeyazEsya.Infrastructure.Services.Integration;

public class IntegrationManager : IIntegrationService
{
    private readonly WinBeyazEsyaTenantContext _context;
    private readonly ICodeGenerationService _codeGenerationService;

    public IntegrationManager(WinBeyazEsyaTenantContext context, ICodeGenerationService codeGenerationService)
    {
        _context = context;
        _codeGenerationService = codeGenerationService;
    }

    private string GetConnectionString(string ip, string db, string user, string pass)
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = ip,
            InitialCatalog = db,
            UserID = user,
            Password = pass,
            TrustServerCertificate = true
        };
        return builder.ConnectionString;
    }

    public async Task<IntegrationResult> SyncCountriesAsync(string ip, string db, string user, string pass, int entType, string customQuery)
    {
        var result = new IntegrationResult();
        string query = entType == 0 ? "SELECT LOGICALREF, CODE, NAME FROM L_COUNTRY" : customQuery;
        string connStr = GetConnectionString(ip, db, user, pass);

        var existingCountries = await _context.Countries.ToDictionaryAsync(c => c.LogicalRef, c => c);

        using var conn = new SqlConnection(connStr);
        await conn.OpenAsync();
        using var cmd = new SqlCommand(query, conn);
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            long logicalRef = Convert.ToInt64(reader["LOGICALREF"]);
            string code = reader["CODE"]?.ToString() ?? "";
            string title = reader["NAME"]?.ToString() ?? "";

            if (existingCountries.TryGetValue(logicalRef, out var existingCountry))
            {
                bool isChanged = false;
                if (existingCountry.Code != code) { existingCountry.Code = code; isChanged = true; }
                if (existingCountry.Title != title) { existingCountry.Title = title; isChanged = true; }
                if (!existingCountry.IsActive) { existingCountry.IsActive = true; isChanged = true; }

                if (isChanged)
                {
                    _context.Countries.Update(existingCountry);
                    result.UpdatedCount++;
                }
                else
                {
                    result.SkippedCount++;
                }
            }
            else
            {
                var country = new Country
                {
                    Id = IdGenerator.GenerateId(),
                    LogicalRef = logicalRef,
                    Code = code,
                    Title = title,
                    IsActive = true
                };
                _context.Countries.Add(country);
                result.AddedCount++;
            }
        }
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<IntegrationResult> SyncCitiesAsync(string ip, string db, string user, string pass, int entType, string customQuery)
    {
        var result = new IntegrationResult();
        string query = entType == 0 ? "SELECT LOGICALREF, CODE, NAME, COUNTRY FROM L_CITY" : customQuery;
        string connStr = GetConnectionString(ip, db, user, pass);

        var existingCountries = await _context.Countries.ToDictionaryAsync(c => c.LogicalRef, c => c);
        var existingCities = await _context.Cities.ToDictionaryAsync(c => c.LogicalRef, c => c);

        using var conn = new SqlConnection(connStr);
        await conn.OpenAsync();
        using var cmd = new SqlCommand(query, conn);
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            long logicalRef = Convert.ToInt64(reader["LOGICALREF"]);
            string code = reader["CODE"]?.ToString() ?? "";
            string title = reader["NAME"]?.ToString() ?? "";
            long countryLogicalRef = reader["COUNTRY"] != DBNull.Value ? Convert.ToInt64(reader["COUNTRY"]) : 0;

            if (!existingCountries.TryGetValue(countryLogicalRef, out var matchCountry))
            {
                result.MissingReferenceCount++;
                continue;
            }

            if (existingCities.TryGetValue(logicalRef, out var existingCity))
            {
                bool isChanged = false;
                if (existingCity.Code != code) { existingCity.Code = code; isChanged = true; }
                if (existingCity.Title != title) { existingCity.Title = title; isChanged = true; }
                if (existingCity.CountryId != matchCountry.Id) { existingCity.CountryId = matchCountry.Id; isChanged = true; }
                if (existingCity.CountryCode != matchCountry.Code) { existingCity.CountryCode = matchCountry.Code; isChanged = true; }
                if (!existingCity.IsActive) { existingCity.IsActive = true; isChanged = true; }

                if (isChanged)
                {
                    _context.Cities.Update(existingCity);
                    result.UpdatedCount++;
                }
                else
                {
                    result.SkippedCount++;
                }
            }
            else
            {
                var city = new City
                {
                    Id = IdGenerator.GenerateId(),
                    LogicalRef = logicalRef,
                    Code = code,
                    Title = title,
                    CountryId = matchCountry.Id,
                    CountryCode = matchCountry.Code,
                    IsActive = true
                };
                _context.Cities.Add(city);
                result.AddedCount++;
            }
        }
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<IntegrationResult> SyncTownsAsync(string ip, string db, string user, string pass, int entType, string customQuery)
    {
        var result = new IntegrationResult();
        string query = entType == 0 ? "SELECT LOGICALREF, CODE, NAME, CTYREF FROM L_TOWN" : customQuery;
        string connStr = GetConnectionString(ip, db, user, pass);

        var existingCities = await _context.Cities.ToDictionaryAsync(c => c.LogicalRef, c => c);
        var existingTowns = await _context.Towns.ToDictionaryAsync(t => t.LogicalRef, t => t);

        using var conn = new SqlConnection(connStr);
        await conn.OpenAsync();
        using var cmd = new SqlCommand(query, conn);
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            long logicalRef = Convert.ToInt64(reader["LOGICALREF"]);
            string code = reader["CODE"]?.ToString() ?? "";
            string title = reader["NAME"]?.ToString() ?? "";
            long cityLogicalRef = reader["CTYREF"] != DBNull.Value ? Convert.ToInt64(reader["CTYREF"]) : 0;

            if (!existingCities.TryGetValue(cityLogicalRef, out var matchCity))
            {
                result.MissingReferenceCount++;
                continue;
            }

            if (existingTowns.TryGetValue(logicalRef, out var existingTown))
            {
                bool isChanged = false;
                if (existingTown.Code != code) { existingTown.Code = code; isChanged = true; }
                if (existingTown.Title != title) { existingTown.Title = title; isChanged = true; }
                if (existingTown.CityId != matchCity.Id) { existingTown.CityId = matchCity.Id; isChanged = true; }
                if (existingTown.CityCode != matchCity.Code) { existingTown.CityCode = matchCity.Code; isChanged = true; }
                if (!existingTown.IsActive) { existingTown.IsActive = true; isChanged = true; }

                if (isChanged)
                {
                    _context.Towns.Update(existingTown);
                    result.UpdatedCount++;
                }
                else
                {
                    result.SkippedCount++;
                }
            }
            else
            {
                var town = new Town
                {
                    Id = IdGenerator.GenerateId(),
                    LogicalRef = logicalRef,
                    Code = code,
                    Title = title,
                    CityId = matchCity.Id,
                    CityCode = matchCity.Code,
                    IsActive = true
                };
                _context.Towns.Add(town);
                result.AddedCount++;
            }
        }
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<IntegrationResult> SyncCurrentAccountsAsync(string ip, string db, string user, string pass, string firmaNo, int entType, string customQuery)
    {
        var result = new IntegrationResult();
        string paddedFirmaNo = (firmaNo ?? "001").PadLeft(3, '0');
        // Country bilgisi için L_COUNTRY join de eklenebilir veya LOGICALREF vs, ama genelde Logo'da COUNTRY, CITY, TOWN metin olarak kart üzerindedir (veya CODE olarak).
        // Örnekte metin kolonlarını okuyacağız (CITY, TOWN, COUNTRY)
        string query = entType == 0 ? $"SELECT LOGICALREF, CODE, DEFINITION_ as TITLE, ACTIVE, TAXNR, TAXOFFICE, COUNTRY, TOWN, CITY, TELNRS1, TELNRS2, CELLPHONE FROM LG_{paddedFirmaNo}_CLCARD WHERE CARDTYPE = 3" : customQuery;
        string connStr = GetConnectionString(ip, db, user, pass);

        using var conn = new SqlConnection(connStr);
        await conn.OpenAsync();
        using var cmd = new SqlCommand(query, conn);
        using var reader = await cmd.ExecuteReaderAsync();

        // Memory Cache for lookups
        var allCountries = await _context.Countries.ToListAsync();
        var allCities = await _context.Cities.ToListAsync();
        var allTowns = await _context.Towns.ToListAsync();

        string NormalizeStr(string? val) => (val ?? "").Trim().ToLowerInvariant().Replace("i̇", "i").Replace("ı", "i");

        while (await reader.ReadAsync())
        {
            long logicalRef = Convert.ToInt64(reader["LOGICALREF"]);
            
            string logoCountry = GetString(reader, "COUNTRY");
            string logoCity = GetString(reader, "CITY");
            string logoTown = GetString(reader, "TOWN");

            long? matchCountryId = null;
            long? matchCityId = null;
            long? matchTownId = null;

            bool isMappingError = false;

            // Country Match
            if (!string.IsNullOrWhiteSpace(logoCountry))
            {
                var normCountry = NormalizeStr(logoCountry);
                var c = allCountries.FirstOrDefault(x => NormalizeStr(x.Title) == normCountry || NormalizeStr(x.Code) == normCountry);
                if (c != null) matchCountryId = c.Id;
                else isMappingError = true;
            }

            // City Match
            if (!string.IsNullOrWhiteSpace(logoCity))
            {
                var normCity = NormalizeStr(logoCity);
                var c = allCities.FirstOrDefault(x => NormalizeStr(x.Title) == normCity || NormalizeStr(x.Code) == normCity);
                if (c != null) matchCityId = c.Id;
                else isMappingError = true;
            }

            // Town Match
            if (!string.IsNullOrWhiteSpace(logoTown))
            {
                var normTown = NormalizeStr(logoTown);
                var t = allTowns.FirstOrDefault(x => NormalizeStr(x.Title) == normTown || NormalizeStr(x.Code) == normTown);
                if (t != null) matchTownId = t.Id;
                else isMappingError = true;
            }

            if (isMappingError)
            {
                result.MissingReferenceCount++;
                continue; // Skip bu kaydı kurala göre
            }

            string code = reader["CODE"]?.ToString() ?? "";
            
            var existingAccount = await _context.CurrentAccounts.FirstOrDefaultAsync(x => x.LogicalRef == logicalRef);
            bool isNew = false;
            if (existingAccount == null)
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    code = await _codeGenerationService.GetNewCodeAsync(WinBeyazEsya.Domain.Enums.ModuleType.CurrentAccount);
                }
                existingAccount = new CurrentAccount
                {
                    Id = IdGenerator.GenerateId(),
                    LogicalRef = logicalRef,
                    Code = code.SafeSubstring(50)!
                };
                isNew = true;
            }
            
            existingAccount.Title = (reader["TITLE"]?.ToString() ?? "").SafeSubstring(250)!;
            existingAccount.Active = Convert.ToInt32(reader["ACTIVE"]);
            existingAccount.IsActive = Convert.ToInt32(reader["ACTIVE"]) == 0;
            existingAccount.TaxNr = GetString(reader, "TAXNR").SafeSubstring(16);
            existingAccount.TaxOffice = GetString(reader, "TAXOFFICE").SafeSubstring(50);
            
            existingAccount.CountryId = matchCountryId;
            existingAccount.CityId = matchCityId;
            existingAccount.TownId = matchTownId;
            existingAccount.CardType = 3; // Müşteri/Tedarikçi

            // Telefon ayıklama ve kirli veriyi Description'a atma işlemleri
            string descriptionAppends = "";

            var tel1Raw = GetString(reader, "TELNRS1");
            var tel1Parsed = PhoneDataParser.Parse(tel1Raw);
            existingAccount.TelNrs1 = tel1Parsed.CleanPhone.SafeSubstring(60);
            if (tel1Parsed.HasExtraData) descriptionAppends += $" | Tel1 Orijinal: {tel1Raw}";

            var tel2Raw = GetString(reader, "TELNRS2");
            var tel2Parsed = PhoneDataParser.Parse(tel2Raw);
            existingAccount.TelNrs2 = tel2Parsed.CleanPhone.SafeSubstring(60);
            if (tel2Parsed.HasExtraData) descriptionAppends += $" | Tel2 Orijinal: {tel2Raw}";

            var cellRaw = GetString(reader, "CELLPHONE");
            var cellParsed = PhoneDataParser.Parse(cellRaw);
            existingAccount.CellPhone = cellParsed.CleanPhone.SafeSubstring(60);
            if (cellParsed.HasExtraData) descriptionAppends += $" | Cep Orijinal: {cellRaw}";

            if (!string.IsNullOrEmpty(descriptionAppends))
            {
                existingAccount.Description = (existingAccount.Description ?? "") + descriptionAppends;
                existingAccount.Description = existingAccount.Description.SafeSubstring(500);
            }

            if (isNew)
            {
                _context.CurrentAccounts.Add(existingAccount);
                result.AddedCount++;
            }
            else
            {
                _context.CurrentAccounts.Update(existingAccount);
                result.UpdatedCount++;
            }
        }
        await _context.SaveChangesAsync();
        return result;
    }

    private string? GetString(SqlDataReader reader, string columnName)
    {
        try
        {
            int ordinal = reader.GetOrdinal(columnName);
            if (!reader.IsDBNull(ordinal))
            {
                return reader.GetString(ordinal);
            }
        }
        catch (IndexOutOfRangeException)
        {
            // If column doesn't exist, ignore
        }
        return null;
    }
}
