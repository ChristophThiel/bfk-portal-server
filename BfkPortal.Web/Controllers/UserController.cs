using System.Threading.Tasks;
using BfkPortal.Core.Contracts;
using BfkPortal.Core.Models;
using BfkPortal.Web.Services;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        internal IUserService<User, UserViewModel> Service;

        public UserController()
        {
            Service = new UserService(ModelState);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await Service.Add(body);
            return Ok(new {id});
        }
    }
}
