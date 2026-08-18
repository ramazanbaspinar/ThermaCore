using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace WinBeyazEsya.Domain.Helpers;

public static class HardwareInfoHelper
{
    public static string GetHWID()
    {
        string processorId = GetWmiValue("Win32_Processor", "ProcessorId");
        string baseBoardSerial = GetWmiValue("Win32_BaseBoard", "SerialNumber");
        string volumeSerial = GetVolumeSerialNumber("C:");

        string rawHwid = $"{processorId}|{baseBoardSerial}|{volumeSerial}";

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawHwid));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("X2"));
            }

            string hashString = builder.ToString();
            // Take first 16 chars
            if (hashString.Length > 16)
            {
                hashString = hashString.Substring(0, 16);
            }

            // Format as XXXX-XXXX-XXXX-XXXX
            return FormatHwid(hashString);
        }
    }

    private static string GetWmiValue(string wmiClass, string wmiProperty)
    {
        try
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT {wmiProperty} FROM {wmiClass}"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    object propertyValue = obj[wmiProperty];
                    if (propertyValue != null)
                    {
                        return propertyValue.ToString().Trim();
                    }
                }
            }
        }
        catch
        {
            // Ignore exceptions to not break HWID generation, just return empty string
        }
        return string.Empty;
    }

    private static string GetVolumeSerialNumber(string driveLetter)
    {
        try
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT VolumeSerialNumber FROM Win32_LogicalDisk WHERE DeviceID='{driveLetter}'"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    object propertyValue = obj["VolumeSerialNumber"];
                    if (propertyValue != null)
                    {
                        return propertyValue.ToString().Trim();
                    }
                }
            }
        }
        catch
        {
        }
        return string.Empty;
    }

    private static string FormatHwid(string hwid)
    {
        if (string.IsNullOrEmpty(hwid) || hwid.Length != 16)
            return hwid;

        return $"{hwid.Substring(0, 4)}-{hwid.Substring(4, 4)}-{hwid.Substring(8, 4)}-{hwid.Substring(12, 4)}";
    }
}

