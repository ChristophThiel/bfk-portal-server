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

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserViewModel model)
        {
            try
            {
                await _service.Register(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn([FromBody] CredentialsViewModel model)
        {
            try
            {
                var user = await _service.LogIn(model);
                var token = _service.GenerateJsonWebToken(user);
                return Ok(new
                {
                    token,
                    user
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
