using System.Security.Cryptography;
using System.Text;

namespace WinBeyazEsya.Domain.Helpers;

public static class PasswordHasher
{
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty or whitespace only string.", nameof(password));

        using (var hmac = new HMACSHA256())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty or whitespace only string.", nameof(password));
        if (storedHash.Length != 32) throw new ArgumentException("Invalid length of password hash (32 bytes expected).", nameof(storedHash));
        if (storedSalt.Length != 64) throw new ArgumentException("Invalid length of password salt (64 bytes expected).", nameof(storedSalt));

        using (var hmac = new HMACSHA256(storedSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != storedHash[i]) return false;
            }
        }

        return true;
    }
}

