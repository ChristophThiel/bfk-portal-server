using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            var result = _service.All();
            return Ok(result);
        }

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [Authorize(Policy = Constants.UserOfSameRoleGroupPolicy)]
        [HttpGet("[action]/{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            await _service.Remove(userId);
            return Ok();
        }

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [Authorize(Policy = Constants.UserOfSameRoleGroupPolicy)]
        [HttpPost("[action]")]
        public async Task<IActionResult> Update(UserViewModel viewModel)
        {
            await _service.Update(viewModel);
            return Ok();
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [HttpGet("[action]")]
        public IActionResult Roles()
        {
            var result = _service.Roles();
            return Ok(result);
        }
    }
}
