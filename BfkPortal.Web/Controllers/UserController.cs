using BfkPortal.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [HttpGet("[action]")]
        public IActionResult All()
        {
            try
            {
                var result = _service.All();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [HttpGet("[action]")]
        public IActionResult Roles()
        {
            try
            {
                var result = _service.Roles();
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
