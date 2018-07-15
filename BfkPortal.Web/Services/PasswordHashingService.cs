using System;
using System.Security.Cryptography;

namespace BfkPortal.Web.Services
{
    public class PasswordHashingService
    {
        private const int HashLength = 128;

        public static string GenerateSalt()
        {
            var salt = new byte[HashLength];
            using (var provider = new RNGCryptoServiceProvider())
                provider.GetBytes(salt);

            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string password, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt)).GetBytes(HashLength);

            return Convert.ToBase64String(pbkdf2);
        }
    }
}
