using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class CurrentAccountDto : BaseDto
{
    public long LogicalRef { get; set; }
    public int Active { get; set; }
    public int CardType { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? SpeCode { get; set; }
    public string? Addr1 { get; set; }
    public string? Addr2 { get; set; }
    public long? CountryId { get; set; }
    public long? CityId { get; set; }
    public long? TownId { get; set; }
    public string? TelNrs1 { get; set; }
    public string? TelNrs2 { get; set; }
    public string? TaxNr { get; set; }
    public string? TaxOffice { get; set; }
    public string? InCharge { get; set; }
    public long PaymentRef { get; set; }
    public int CCurrency { get; set; }
    public string? EmailAddr { get; set; }
    public string? WebAddr { get; set; }
    public string? CellPhone { get; set; }
    public string? ShortCode { get; set; }

    // Added Missing Properties from UI
    public bool IsEInvoiceUser { get; set; }
    public bool IsEDispatchUser { get; set; }
    public string? MailboxAlias { get; set; }
    public string? Description { get; set; }
    public int MaturityDays { get; set; }
    public int PaymentType { get; set; }
}
