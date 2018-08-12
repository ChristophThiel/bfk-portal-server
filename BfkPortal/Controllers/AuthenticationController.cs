using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BfkPortal.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IAuthenticationRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] CredentialsDto body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var validUser = await _repository.Verify(body.Email, body.Password);
            if (validUser == null)
            {
                ModelState.AddModelError("Credentials", "Invalid email or password!");
                return BadRequest(ModelState);
            }

            var claims = new[] {new Claim(ClaimTypes.Email, body.Email)};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(_configuration["Issuer"], _configuration["Issuer"], claims, null, null, credentials);

            var dto = new AuthenticationDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                User = new UserDto
                {
                    Id = validUser.Id,
                    Email = body.Email,
                    Roles = validUser.Roles.Select(ur => ur.Role.Name).ToList()
                }
            };
            return Ok(dto);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> LogOut([FromBody] EmailDto body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // TODO Send Email

            return Ok();
        }
    }
}
