using System.Threading.Tasks;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Services;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IConfiguration configuration)
        {
            _service = new AuthenticationService(configuration);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn([FromBody] LogInViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = _service.VerifyPassword(body.Email, body.Password);
            if (!result)
                ModelState.AddModelError("Email or Password", "Invalid email or password");
            else
            {
                var user = await _service.FindByCredentialsAsync(body.Email, body.Password);

                /*await _service.UnitOfWork.Users.LoadCollectionAsync(user, nameof(user.Memberships));
                foreach (var membership in user.Memberships)
                    await _service.UnitOfWork.Memberships.LoadReferenceAsync(membership, nameof(membership.Organisation));
                var result = new
                {
                    Token = await _service.CreateJsonWebTokenAsync(userId),
                    User = new UserDto(await _service.UnitOfWork.Users.FindAsync(userId))
                };

                return Ok(result);*/
            }

            return BadRequest(ModelState);
        }
    }
}
