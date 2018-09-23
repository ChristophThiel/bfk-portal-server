﻿using System.Threading.Tasks;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Services;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
<<<<<<< HEAD
        private readonly IUserService _service;
=======
        private readonly IUserService<User, UserViewModel> _service;
>>>>>>> ff856af5104cd25be151dc5ec33a4689be8ce9d6

        public UserController(IUnitOfWork unitOfWork)
        {
<<<<<<< HEAD
            _service = new UserService(ModelState);
=======
            _service = new UserService(ModelState, unitOfWork);
>>>>>>> ff856af5104cd25be151dc5ec33a4689be8ce9d6
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.Add(body);
<<<<<<< HEAD

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

=======
>>>>>>> ff856af5104cd25be151dc5ec33a4689be8ce9d6
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