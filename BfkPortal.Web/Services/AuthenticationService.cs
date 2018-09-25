using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BfkPortal.Persistence;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Security;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BfkPortal.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public IConfiguration Configuration { get; }

        public IUnitOfWork UnitOfWork { get; }

        public ModelStateDictionary ModelState { get; }

        public AuthenticationService(IConfiguration configuration, ModelStateDictionary modelState)
        {
            UnitOfWork = new UnitOfWork();
            Configuration = configuration;
            ModelState = modelState;
        }

        public async Task<string> CreateJsonWebTokenAsync(int id)
        {
            var validUser = await UnitOfWork.Users.FindAsync(id);

            var claims = new[] { new Claim(ClaimTypes.Sid, validUser.Id.ToString()), new Claim(ClaimTypes.Email, validUser.Email) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(Configuration["Issuer"], Configuration["Issuer"], claims, null, null, credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public int VerifyPassword(string email, string password)
        {
            var possibleUsers = UnitOfWork.Users.All()
                .Where(u => u.Email == email)
                .ToList();

            if (!possibleUsers.Any())
            {
                ModelState.AddModelError("Email or Password", "Email or Password invalid!");
                return -1;
            }

            var hasher = new Pbkdf2PasswordHasher();
            foreach (var user in possibleUsers)
            {
                if (hasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success)
                    return user.Id;
            }

            ModelState.AddModelError("Email or Password", "Email or Password invalid!");
            return -1;
        }
    }
}
