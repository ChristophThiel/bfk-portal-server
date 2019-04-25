using System;
using System.Security.Cryptography;
using System.Text;
using BfkPortal.Core.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Security
{
    public class Pbkdf2PasswordHasher : IPasswordHasher<User>
    {
        public const int Iterations = 10000;
        public const int SaltLength = 16;
        public const int HashLength = 32;

        public string HashPassword(User user, string password)
        {
            var salt = Convert.FromBase64String(user.Salt);

            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA1,
                Iterations, HashLength));
            return hash;
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

        public string GeneratePassword()
        {
            var builder = new StringBuilder(); 
            var random = new Random();
            while (builder.Length < 16)
            {
                var letter = (char)random.Next(0, 127);
                if (char.IsLetterOrDigit(letter))
                    builder.Append(letter);
            }

            return builder.ToString();
        }
    }
}
