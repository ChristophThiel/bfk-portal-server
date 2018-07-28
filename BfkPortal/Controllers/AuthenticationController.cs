using System.Linq;
using BfkPortal.Communication.Requests;
using BfkPortal.Database.Interfaces;
using BfkPortal.Database.Repositories;
using BfkPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _repository;

        public AuthenticationController(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            foreach (var user in _repository.All())
                _repository.Remove(user);

            _repository.Add(new User());
            return Ok("Everything worked!");
        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] CredentialsRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isValidCredentials = _repository.Verify(body.Email, body.Password);
            if (isValidCredentials)
                return Ok(new {Token = "test"});

            return BadRequest(new { Credentials = "Invalid email or password!" });
        }
    }

    public class Value
    {
        public string Name { get; set; }
    }
}
