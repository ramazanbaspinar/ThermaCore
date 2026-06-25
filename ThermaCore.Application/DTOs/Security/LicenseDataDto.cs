using System;

namespace ThermaCore.Application.DTOs.Security
{
    public class LicenseDataDto
    {
        public string MacAddress { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public int MaxTerminalCount { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public bool ResetTimeCheat { get; set; }
    }
}
