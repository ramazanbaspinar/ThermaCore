using System.ComponentModel.DataAnnotations;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Domain.Enums;

namespace ThermaCore.Domain.Entities.System;

public class KodSablon : BaseEntity
{
    public ModulTuru Modul { get; set; }
    
    [MaxLength(10)]
    public string KodOnEk { get; set; } = string.Empty;
    
    [MaxLength(10)]
    public string KodSonEk { get; set; } = string.Empty;
    
    public int BaslangicSayisi { get; set; }
    public int SayisalUzunluk { get; set; }
    public TarihFormati TarihFormati { get; set; }
}
