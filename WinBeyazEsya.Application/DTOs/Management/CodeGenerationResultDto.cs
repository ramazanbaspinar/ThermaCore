namespace WinBeyazEsya.Application.DTOs.Management;

public class CodeGenerationResultDto
{
    public string Code { get; set; } = string.Empty;
    public bool KullaniciMudahaleEdilebilir { get; set; }
    public bool FirmaKisaKodKullanildiMi { get; set; }
}

