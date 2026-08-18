using System.Net.NetworkInformation;

namespace WinBeyazEsya.Domain.Helpers;

public class TerminalHardwareInfo
{
    public List<string> EthernetMacs { get; set; } = new();
    public List<string> WifiMacs { get; set; } = new();
    public List<string> VpnMacs { get; set; } = new();

    public List<string> AllMacs => EthernetMacs.Concat(WifiMacs).Concat(VpnMacs).ToList();
}

public static class NetworkHelper
{
    public static string FormatMacAddress(string mac)
    {
        if (!string.IsNullOrEmpty(mac) && mac.Length == 12)
        {
            return string.Join(":", Enumerable.Range(0, 6).Select(i => mac.Substring(i * 2, 2))).ToUpper();
        }
        return mac?.ToUpper() ?? string.Empty;
    }

    public static TerminalHardwareInfo GetHardwareFingerprints()
    {
        var info = new TerminalHardwareInfo();
        var nics = NetworkInterface.GetAllNetworkInterfaces();

        foreach (var adapter in nics)
        {
            string mac = adapter.GetPhysicalAddress().ToString();
            if (string.IsNullOrEmpty(mac)) continue;

            string formattedMac = FormatMacAddress(mac);
            string desc = adapter.Description.ToLowerInvariant();

            bool isVpn = desc.Contains("vpn") || desc.Contains("tap") || desc.Contains("virtual") || desc.Contains("hyper-v");

            if (isVpn)
            {
                info.VpnMacs.Add(formattedMac);
            }
            else if (adapter.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
                info.EthernetMacs.Add(formattedMac);
            }
            else if (adapter.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
            {
                info.WifiMacs.Add(formattedMac);
            }
        }

        return info;
    }

    public static string GetMacAddress()
    {
        var info = GetHardwareFingerprints();
        return info.EthernetMacs.FirstOrDefault() ?? info.WifiMacs.FirstOrDefault() ?? info.VpnMacs.FirstOrDefault() ?? string.Empty;
    }

    public static string GetLocalIpAddress()
    {
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return "127.0.0.1";
    }
}

