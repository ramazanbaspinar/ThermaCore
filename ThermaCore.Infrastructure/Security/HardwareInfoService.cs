using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using ThermaCore.Application.Interfaces.Security;

namespace ThermaCore.Infrastructure.Security;

public class HardwareInfoService : IHardwareInfoService
{
    public string GetMachineFingerprint()
    {
        try
        {
            string cpuInfo = GetCpuId();
            string biosInfo = GetBiosId();
            string baseBoardInfo = GetBaseBoardId();

            string rawFingerprint = $"{cpuInfo}-{biosInfo}-{baseBoardInfo}";
            return ComputeSha256Hash(rawFingerprint);
        }
        catch (Exception)
        {
            return "UNKNOWN_FINGERPRINT_" + Environment.MachineName;
        }
    }

    private string GetCpuId()
    {
        string cpuInfo = string.Empty;
#pragma warning disable CA1416
        using (ManagementClass mc = new ManagementClass("win32_processor"))
        {
            using (ManagementObjectCollection moc = mc.GetInstances())
            {
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["processorID"].Value?.ToString() ?? "";
                    break;
                }
            }
        }
#pragma warning restore CA1416
        return cpuInfo;
    }

    private string GetBiosId()
    {
        string biosInfo = string.Empty;
#pragma warning disable CA1416
        using (ManagementClass mc = new ManagementClass("win32_bios"))
        {
            using (ManagementObjectCollection moc = mc.GetInstances())
            {
                foreach (ManagementObject mo in moc)
                {
                    biosInfo = mo.Properties["SerialNumber"].Value?.ToString() ?? "";
                    break;
                }
            }
        }
#pragma warning restore CA1416
        return biosInfo;
    }

    private string GetBaseBoardId()
    {
        string baseBoardInfo = string.Empty;
#pragma warning disable CA1416
        using (ManagementClass mc = new ManagementClass("Win32_BaseBoard"))
        {
            using (ManagementObjectCollection moc = mc.GetInstances())
            {
                foreach (ManagementObject mo in moc)
                {
                    baseBoardInfo = mo.Properties["SerialNumber"].Value?.ToString() ?? "";
                    break;
                }
            }
        }
#pragma warning restore CA1416
        return baseBoardInfo;
    }

    private string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
