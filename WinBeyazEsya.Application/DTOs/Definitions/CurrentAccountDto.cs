using WinBeyazEsya.Application.DTOs.Base;

namespace WinBeyazEsya.Application.DTOs.Definitions;

public class CurrentAccountDto : BaseDto
{
    public long LogicalRef { get; set; }
    public int Active { get; set; }
    public int CardType { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? SpeCode { get; set; }
    public string? CyphCode { get; set; }
    public string? Addr1 { get; set; }
    public string? Addr2 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? PostCode { get; set; }
    public string? TelNrs1 { get; set; }
    public string? TelNrs2 { get; set; }
    public string? FaxNr { get; set; }
    public string? TaxNr { get; set; }
    public string? TaxOffice { get; set; }
    public string? InCharge { get; set; }
    public double DiscRate { get; set; }
    public long PaymentRef { get; set; }
    public string? EmailAddr { get; set; }
    public string? WebAddr { get; set; }
    public string? VatNr { get; set; }
    public string? BankBranchs1 { get; set; }
    public string? BankBranchs2 { get; set; }
    public string? BankBranchs3 { get; set; }
    public string? BankBranchs4 { get; set; }
    public string? BankBranchs5 { get; set; }
    public string? BankBranchs6 { get; set; }
    public string? BankBranchs7 { get; set; }
    public string? BankAccounts1 { get; set; }
    public string? BankAccounts2 { get; set; }
    public string? BankAccounts3 { get; set; }
    public string? BankAccounts4 { get; set; }
    public string? BankAccounts5 { get; set; }
    public string? BankAccounts6 { get; set; }
    public string? BankAccounts7 { get; set; }
    public string? DeliveryMethod { get; set; }
    public string? DeliveryFirm { get; set; }
    public int CCurrency { get; set; }
    public string? TaxOffCode { get; set; }
    public string? TownCode { get; set; }
    public string? TownName { get; set; }
    public string? DistrictCode { get; set; }
    public string? District { get; set; }
    public string? CityCode { get; set; }
    public string? CountryCode { get; set; }
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
