using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Database.Repositories;
using BfkPortal.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Controllers
{
    // TODO Authorization
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CredentialsDto body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.Add(body.Email, body.Password);
            return Ok();
        }

        [HttpPost("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }

        [HttpPost("update/{id:int}")]
        public async Task<IActionResult> Update(int id)
        {
            return Ok();
        }
    }
}
