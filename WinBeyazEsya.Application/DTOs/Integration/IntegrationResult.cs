namespace WinBeyazEsya.Application.DTOs.Integration;

public class IntegrationResult
{
    public int AddedCount { get; set; }
    public int UpdatedCount { get; set; }
    public int SkippedCount { get; set; }
    public int ErrorCount { get; set; }
    public int MissingReferenceCount { get; set; }
}
