using System.Security.Cryptography;
using System.Text;

namespace Repositories.User;

public class PasswordHasher : IPasswordHasher
{
    public string GenerateHash(string password)
    {
        var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password),
            Encoding.UTF8.GetBytes(GenerateSalt()),
            350000, // Iterations
            HashAlgorithmName.SHA512,  // Algorithm
            64); // keysize

        var hashedStr = Convert.ToBase64String(hash);

        return hashedStr;
    }

    private static string GenerateSalt()
    {
        var rng = RandomNumberGenerator.Create();

        byte[] salt = new byte[64];

        rng.GetBytes(salt);

        string cryptSalt = Convert.ToBase64String(salt);

        return cryptSalt;
    }
}