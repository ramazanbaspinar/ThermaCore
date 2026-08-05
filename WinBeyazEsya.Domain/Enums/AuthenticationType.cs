using System.ComponentModel;

namespace WinBeyazEsya.Domain.Enums;

public enum AuthenticationType
{
    [Description("Windows Authentication")]
    Windows = 0,
    
    [Description("SQL Server Authentication")]
    SqlServer = 1
}

