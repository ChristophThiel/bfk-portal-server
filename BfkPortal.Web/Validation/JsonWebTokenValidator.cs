using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace BfkPortal.Web.Validation
{
    public class JsonWebTokenValidator
    {
        // TODO Store this key in another file
        private const string Secret = "VGhpcyBpcyBhIHRlc3Qga2V5IQ=="; // This is a test key! => the decoded value

        public static bool ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrWhiteSpace(token))
                return false;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token);

            if (jwtToken == null)
                return false;

            var key = Convert.FromBase64String(Secret);
            var validationParameters = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            ClaimsPrincipal principal;
            try
            {
                principal = handler.ValidateToken(token, validationParameters, out var stoken);
            }
            catch (Exception)
            {
                return false;
            }

            if (!(principal.Identity is ClaimsIdentity identity))
                return false;

            var emailClaim = identity.FindFirst(ClaimTypes.Email);
            var email = emailClaim?.Value;

            return !string.IsNullOrEmpty(email);
        }
    }
}
