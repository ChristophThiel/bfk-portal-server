using System.Threading.Tasks;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Services;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController()
        {
            _service = new UserService(ModelState);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.Add(body);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok(new {id});
        }

        [HttpGet("delete/{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            await _service.Remove(userId);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UserViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Update(body);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult All() => Ok(_service.All());

        [HttpGet("roles")]
        public IActionResult Roles() => Ok(_service.Roles());
    }
}