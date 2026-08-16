using WinBeyazEsya.Domain.Enums;

namespace WinBeyazEsya.Application.DTOs.Management;

public class CodeGenerationRequestDto
{
    public ModuleType Modul { get; set; }
    public long FirmaId { get; set; }
    public bool FirmaKisaKodKullanilsin { get; set; } = false;
    public bool TestModu { get; set; } = false;
    public long? BranchId { get; set; }
    public string? ShortCode { get; set; }
}

