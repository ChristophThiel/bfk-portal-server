using System;
using System.Security.Cryptography;
using BfkPortal.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Security
{
    public class Pbkdf2PasswordHasher : IPasswordHasher<User>
    {
        public const int Iterations = 10000;
        public const int SaltLength = 16;
        public const int HashLength = 20;

        public string HashPassword(User user, string password)
        {
            var salt = Convert.FromBase64String(user.Salt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);

            var hashedPassword = pbkdf2.GetBytes(HashLength);
            var hash = new byte[HashLength + SaltLength];

            Array.Copy(hashedPassword, 0, hash, 0, HashLength);
            Array.Copy(salt, 0, hash, HashLength, SaltLength);

            return Convert.ToBase64String(hash);
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            var hash = HashPassword(user, providedPassword);
            return hash == hashedPassword 
                ? PasswordVerificationResult.Success 
                : PasswordVerificationResult.Failed;
        }

        public string GenerateSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltLength]);
            return Convert.ToBase64String(salt);
        }
    }
}
