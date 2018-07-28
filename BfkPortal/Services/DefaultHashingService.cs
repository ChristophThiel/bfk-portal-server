using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Services
{
    public class DefaultHashingService
    {
        public const int LengthOfSalt = 16;

        private static readonly PasswordHasher<string> Hasher = new PasswordHasher<string>();

        public static string GenerateSalt()
        {
            var salt = new byte[LengthOfSalt];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public static string HashPassword(string email, string password, string salt, string pepper)
        {
            var fullPasswordString = BuildFullPasswordString(password, salt, pepper);
            return Hasher.HashPassword(email, fullPasswordString);
        }

        public static bool VerifyPassword(string email, string hashedPassword, string providedPassword, string salt, string pepper)
        {
            return Hasher.VerifyHashedPassword(email, hashedPassword,
                       BuildFullPasswordString(providedPassword, salt, pepper)) == PasswordVerificationResult.Success;
        }

        private static string BuildFullPasswordString(string password, string salt, string pepper)
        {
            var builder = new StringBuilder();
            builder.Append(password);
            builder.Append(salt);
            builder.Append(pepper);

            return builder.ToString();
        }
    }
}
