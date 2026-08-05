using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using WinBeyazEsya.Application.Interfaces.Security;

namespace WinBeyazEsya.Infrastructure.Security;

public class CryptoService : ICryptoService
{
    // Kötü niyetli okumalara karşı Base64 olarak gizlenmiş (Obfuscated) Master Secret ve Salt
    // Düz metin: "WinBeyazEsya_Ultimate_Corporate_Secret_2026!#"
    private static readonly byte[] MasterSecretBytes = Convert.FromBase64String("V2luQmV5YXpFc3lhX1VsdGltYXRlX0NvcnBvcmF0ZV9TZWNyZXRfMjAyNiEj"); 
    
    // Düz metin: "WinBeyazEsya_Corporate_Salt_2026_Secure"
    private static readonly byte[] SaltBytes = Convert.FromBase64String("V2luQmV5YXpFc3lhX0NvcnBvcmF0ZV9TYWx0XzIwMjZfU2VjdXJl");

    private readonly byte[] _aesKey;
    private readonly byte[] _aesIV;

    public CryptoService()
    {
        // PBKDF2 (Rfc2898DeriveBytes) ile HMAC-SHA256 kullanarak Master Secret'tan güvenli Key ve IV türetimi (100.000 iterasyon)
        using var rfc2898 = new Rfc2898DeriveBytes(MasterSecretBytes, SaltBytes, 100000, HashAlgorithmName.SHA256);
        
        _aesKey = rfc2898.GetBytes(32); // AES-256 için tam 32 byte Key
        _aesIV = rfc2898.GetBytes(16);  // AES için tam 16 byte IV
    }

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
        aes.Key = _aesKey;
        aes.IV = _aesIV;

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

        try
        {
            using var aes = Aes.Create();
            aes.Key = _aesKey;
            aes.IV = _aesIV;

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using var ms = new MemoryStream(Convert.FromBase64String(cipherText));
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }
        catch (CryptographicException)
        {
            // Eski anahtarla şifrelenmiş veri veya bozuk şifre varsa çökmesini engelle
            return string.Empty;
        }
        catch (FormatException)
        {
            // Base64 string bozuksa
            return string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }
}

