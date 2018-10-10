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
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BfkPortal.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;

        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _unitOfWork = new UnitOfWork();
        }

        public async Task<string> CreateJsonWebTokenAsync(int id)
        {
            var validUser = await _unitOfWork.Users.FindAsync(id);

            var claims = new[] { new Claim(ClaimTypes.Sid, validUser.Id.ToString()), new Claim(ClaimTypes.Email, validUser.Email) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(_configuration["Issuer"], _configuration["Issuer"], claims, null, null, credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<UserDto> FindByCredentialsAsync(string email, string password)
        {

        }

        public bool VerifyPassword(string email, string password)
        {
            var possibleUsers = _unitOfWork.Users.All()
                .Where(u => u.Email == email)
                .ToList();

            if (!possibleUsers.Any())
                return false;
            
            var hasher = new Pbkdf2PasswordHasher();
            foreach (var user in possibleUsers)
            {
                if (hasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success)
                    return true;
            }

            return false;
        }
    }
}
