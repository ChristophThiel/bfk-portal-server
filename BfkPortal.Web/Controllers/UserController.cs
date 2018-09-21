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
        private readonly IUserService<User, UserViewModel> _service;

        public UserController(IUnitOfWork unitOfWork)
        {
            _service = new UserService(ModelState, unitOfWork);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.Add(body);
            return Ok(new {id});
        }
    }
}
