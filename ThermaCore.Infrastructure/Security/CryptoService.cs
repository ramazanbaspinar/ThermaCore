using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ThermaCore.Infrastructure.Security;

public class CryptoService : ICryptoService
{
    // Kurumsal standartlar için güvenli anahtarlar (Production'da appsettings.json'dan alınması önerilir)
    private readonly string _aesKey = "ThermaCoreAES256Key_2026!Secret#"; // 32 bytes (256 bits)
    private readonly string _aesIV = "ThermaCoreIV2026"; // 16 bytes (128 bits)

    public string EncryptMd5(string value)
    {
        if (string.IsNullOrEmpty(value)) return value;

        using var md5 = MD5.Create();
        var inputBytes = Encoding.UTF8.GetBytes(value);
        var hashBytes = md5.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes).ToLowerInvariant();
    }

    public string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_aesKey);
        aes.IV = Encoding.UTF8.GetBytes(_aesIV);

        var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(plainText);
        }

        return Convert.ToBase64String(ms.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText)) return cipherText;

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_aesKey);
        aes.IV = Encoding.UTF8.GetBytes(_aesIV);

        var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
        using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);

        return sr.ReadToEnd();
    }
}
