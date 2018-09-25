using System.Threading.Tasks;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Services;
using BfkPortal.Web.ViewModels;
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
            _service = new AuthenticationService(configuration, ModelState);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn([FromBody] LogInViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = _service.VerifyPassword(body.Email, body.Password);
            if (!_service.ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(new {Token = await _service.CreateJsonWebTokenAsync(userId)});
        }
    }
}
