using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.Management;

public class KodLog : Entity
{
    [Required]
    public ModuleType Modul { get; set; }

    [StringLength(100)]
    public string FirmaKodu { get; set; } = string.Empty;

    [StringLength(100)]
    public string TarihKey { get; set; } = string.Empty;

    public int SonKodDegeri { get; set; }
    
    public long? BranchId { get; set; }
}
