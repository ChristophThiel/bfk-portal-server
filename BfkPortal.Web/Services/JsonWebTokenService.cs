using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace BfkPortal.Web.Services
{
    public class JsonWebTokenService
    {
        // TODO Store this key in another file
        private const string Secret = "VGhpcyBpcyBhIHRlc3Qga2V5IQ=="; // This is a test key! => the decoded value

        public static string GenerateToken(string email, int expire = 20)
        {
            var key = Convert.FromBase64String(Secret);
            var handler = new JwtSecurityTokenHandler();

            var timestamp = DateTime.UtcNow;
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                }),
                Expires = timestamp.AddMinutes(expire),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = handler.CreateToken(descriptor);
            var token = handler.WriteToken(stoken);

            return token;
        }
    }
}
