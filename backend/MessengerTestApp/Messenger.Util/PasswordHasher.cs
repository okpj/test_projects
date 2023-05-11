using System.Security.Cryptography;
using System.Text;

namespace Messenger.Util;

public class PasswordHasher
{
    public static string CreateHash(string password)
    {
        using (SHA256 hash = SHA256.Create())
        {
            var resultHash = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(resultHash);
        }
    }

    public static bool VerifyPassword(string password, string hash)
    {
        var hashString = CreateHash(password);
        return hashString.Equals(hash);
    }
}