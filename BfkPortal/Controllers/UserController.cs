using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.Requests;
using BfkPortal.Database.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("add")]
        public IActionResult Add([FromHeader] string token, [FromBody] CredentialsRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _repository.Add(request.Email, request.Password);
            return Ok();
        }

        // TODO Remove this
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("This is a protected area");
        }
    }
}
