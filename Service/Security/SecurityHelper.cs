using System.Security.Cryptography;

namespace coursework.Service.Security;

public static class SecurityHelper
{
    private const int _saltLenght = 32;
    private const int _hashIterations = 1024;

    public static string GenerateSalt()
    {
        var saltBytes = new byte[_saltLenght];

        using (var provider = RandomNumberGenerator.Create())
        {
            provider.GetNonZeroBytes(saltBytes);
        }

        return Convert.ToBase64String(saltBytes);
    }

    public static string HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);

        using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, _hashIterations, HashAlgorithmName.SHA256))
        {
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(_hashIterations));
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword, string salt)
    {
        var newHashed = HashPassword(password, salt);
        return newHashed.Equals(hashedPassword);
    }
}