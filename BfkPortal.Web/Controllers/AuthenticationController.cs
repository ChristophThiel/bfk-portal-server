using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BfkPortal.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IConverter<User, UserDto> _modelToDtoConveter;

        public AuthenticationController(IConfiguration configuration, UserManager<User> userManager, IConverter<User, UserDto> modelToDtoConveter)
        {
            _configuration = configuration;
            _userManager = userManager;
            _modelToDtoConveter = modelToDtoConveter;
        }

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserViewModel model)
        {
            var user = new User
            {
                UserName = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                IsDeleted = model.IsDeleted ?? false,
                Participations = new List<Participation>(),
                Memberships = new List<Membership>()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result != IdentityResult.Success)
                return BadRequest(Constants.RegisterFailed);

            await _userManager.AddToRolesAsync(user,model.Entitlements);

            foreach (var organisationId in model.Memberships)
                user.Memberships.Add(new Membership
                {
                    UserId = user.Id,
                    OrganisationId = organisationId
                });

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn([FromBody] CredentialsViewModel model, [FromServices] IUnitOfWork unitOfWork)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            // var test = await unitOfWork.Users.FindAsync(user.Id);
            if (user == null)
                return BadRequest(Constants.InvalidEmailOrPassword);

            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (result == PasswordVerificationResult.Failed)
                return BadRequest(Constants.InvalidEmailOrPassword);

            var token = GenerateJsonWebToken(user);
            var userDto = await _modelToDtoConveter.Convert(user);

            return Ok(new
            {
                Token = token.Result,
                User = userDto
            });
        }

        private async Task<object> GenerateJsonWebToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Lastname),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            claims.AddRange(await _userManager.GetClaimsAsync(user));

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Issuer"], _configuration["Issuer"], claims,
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // TODO DELETE
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Initialize([FromServices] IUnitOfWork unitOfWork, [FromServices] RoleManager<Role> roleManager)
        {
            await unitOfWork.DeleteDatabaseAsync();
            await unitOfWork.CreatDatabaseAsync();

            await roleManager.CreateAsync(new Role
            {
                Name = "UserBfk"
            });
            await roleManager.CreateAsync(new Role
            {
                Name = "UserBwst"
            });
            await roleManager.CreateAsync(new Role
            {
                Name = "ObserverBwst"
            });
            await roleManager.CreateAsync(new Role
            {
                Name = "AdminBfk"
            });
            await roleManager.CreateAsync(new Role
            {
                Name = "AdminBwst"
            });

            return Ok();
        }
    }
}
