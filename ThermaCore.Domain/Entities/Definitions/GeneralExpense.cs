using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;

namespace ThermaCore.Domain.Entities.Definitions;

public class GeneralExpense : FullAuditableEntity
{
    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public decimal Cost { get; set; }

    [MaxLength(5)]
    public string CurrencyCode { get; set; } = string.Empty;
}
