namespace WinBeyazEsya.Application.DTOs.Base;

public abstract class BaseHareketDto : BaseDto
{
    
    // DevExpress GridView satır işlem durumları (Insert/Update/Delete tracker)
    public bool Insert { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
}

