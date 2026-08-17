using System.ComponentModel.DataAnnotations;
using WinBeyazEsya.Domain.Entities.Base;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class CurrentAccount : FullAuditableEntity
{
    public long LogicalRef { get; set; }
    public int Active { get; set; } = 0;
    public int CardType { get; set; }
    public string Code { get; set; } = string.Empty;

    
     // KESİNLİKLE 250
    public string Title { get; set; } = string.Empty;

    public string? SpeCode { get; set; }

    public string? Addr1 { get; set; }

    public string? Addr2 { get; set; }

    public long? CountryId { get; set; }
    public Country? Country { get; set; }

    public long? CityId { get; set; }
    public City? City { get; set; }

    public long? TownId { get; set; }
    public Town? Town { get; set; }

    public string? TelNrs1 { get; set; }

    public string? TelNrs2 { get; set; }

    
    public string? TaxNr { get; set; }

    
    public string? TaxOffice { get; set; }

    public string? InCharge { get; set; }

    public long PaymentRef { get; set; }

    public string? EmailAddr { get; set; }

    public string? WebAddr { get; set; }

    public string? CellPhone { get; set; }

    public string? ShortCode { get; set; }

    public bool IsEInvoiceUser { get; set; }

    public bool IsEDispatchUser { get; set; }

    public string? MailboxAlias { get; set; }

    public string? Description { get; set; }

    public int MaturityDays { get; set; }

    [global::System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public int PaymentType { get; set; }

    public bool IsActive { get; set; } = true;
}
