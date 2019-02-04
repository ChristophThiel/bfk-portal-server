using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
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

        [AllowAnonymous]
        [HttpGet("[action]")]
        public IActionResult All()
        {
            var result = _service.AllUsersOfSameRoleGroup(User.Claims
                .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray());
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

        [HttpGet("[action]/{userId:int}")]
        public async Task<IActionResult> GetToken(int userId)
        {
            return Ok(new { Token = await _service.GetToken(userId) });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SetToken(NotificationTokenViewModel viewModel)
        {
            await _service.SetToken(viewModel.UserId, viewModel.Token);
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

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [HttpGet("[action]")]
        public IActionResult Roles()
        {
            var result = _service.RolesOfRoleGroup(User.Claims
                .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray());
            return Ok(result);
        }
    }
}
