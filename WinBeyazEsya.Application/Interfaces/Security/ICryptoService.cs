namespace WinBeyazEsya.Application.Interfaces.Security;

public interface ICryptoService
{
    string EncryptMd5(string value);
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}

