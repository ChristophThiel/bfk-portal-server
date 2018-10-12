using System.Threading.Tasks;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /*private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] UserViewModel body)
        {
            return BadRequest();
            /* if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.Add(body);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok(new {id}); 
        }

        [HttpGet("[action]/{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            /*await _service.Remove(userId);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
            return BadRequest();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] UserViewModel body)
        {
            /*if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.Update(body);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
            return BadRequest();
        }

        //[HttpGet("[action]")]
        //public IActionResult All() => Ok(_service.All());

        [HttpGet("[action]")]
        public IActionResult Roles() => Ok(_service.Roles());*/
    }
}