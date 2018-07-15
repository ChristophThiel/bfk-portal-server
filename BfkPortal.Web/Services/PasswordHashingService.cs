using System;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace BfkPortal.Web.Services
{
    public class PasswordHashingService
    {
        private const string WwwRoot = "wwwroot";
        private const string PepperFilename = "peppers.json";
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
