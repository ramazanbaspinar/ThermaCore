using System;
using WinBeyazEsya.Domain.Entities.Base;
using WinBeyazEsya.Domain.Entities.Common;
using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Domain.Entities.Definitions;

public class Lock : FullAuditableEntity
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string BaseUnit { get; set; } = default!;

    public LockType? LockType { get; set; }
    public MaterialType? MaterialType { get; set; }
    public decimal? WeightGr { get; set; }
    public string? Description { get; set; }
    
    public long? SpecialCodeId { get; set; }
    public SpecialCode? SpecialCode { get; set; }

    public bool IsActive { get; set; } = true;
}

