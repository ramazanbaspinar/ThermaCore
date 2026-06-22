using System.Linq;
using System.Net.NetworkInformation;

namespace ThermaCore.Domain.Helpers;

public static class NetworkHelper
{
    public static string GetMacAddress()
    {
        var nics = NetworkInterface.GetAllNetworkInterfaces();
        var sMacAddress = string.Empty;

        foreach (var adapter in nics)
        {
            if (sMacAddress == string.Empty) 
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                sMacAddress = adapter.GetPhysicalAddress().ToString();
            }
        }
        
        // Return first found MAC address formatted with hyphens (e.g., 00-11-22-33-44-55)
        if (!string.IsNullOrEmpty(sMacAddress) && sMacAddress.Length == 12)
        {
            sMacAddress = string.Join("-", Enumerable.Range(0, 6).Select(i => sMacAddress.Substring(i * 2, 2)));
        }

        return sMacAddress;
    }
}
