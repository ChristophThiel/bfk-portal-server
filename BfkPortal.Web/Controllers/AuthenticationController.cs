using System.Threading.Tasks;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn([FromBody] CredentialsViewModel model)
        {
            var user = await _service.LogIn(model);
            var token = _service.GenerateJsonWebToken(user);
            return Ok(new
            {
                token,
                user
            });
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Send([FromBody] EmailViewModel model)
        {
            await _service.SendResetPasswordLink(model);
            return Ok();
        }

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserViewModel model)
        {
            await _service.Register(model);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Reset([FromBody] CredentialsViewModel model)
        {
            _service.ResetPassword(model);
            return Ok();
        }
    }
}
