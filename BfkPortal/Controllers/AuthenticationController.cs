using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Communication.Requests;
using BfkPortal.Database.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BfkPortal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LogInRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var validUser = await _unitOfWork.Authentications.Verify(body.Email, body.Password);
            if (validUser == null)
            {
                ModelState.AddModelError("Credentials", "Invalid email or password!");
                return BadRequest(ModelState);
            }

            var claims = new[] {new Claim(ClaimTypes.Sid, validUser.Id.ToString()), new Claim(ClaimTypes.Email, body.Email)};
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(_configuration["Issuer"], _configuration["Issuer"], claims, null, null, credentials);

            var userDto = new UserDto(validUser);
            return Ok(new {Token = new JwtSecurityTokenHandler().WriteToken(token), User = userDto});
        }

        /*[HttpPost("logout")]
        public async Task<IActionResult> LogOut()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // TODO Send Email

            return Ok();
        }*/
    }
}
