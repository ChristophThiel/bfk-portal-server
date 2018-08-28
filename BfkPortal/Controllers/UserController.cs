using System;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Database.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CredentialsDto body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _unitOfWork.Users.Add(body.Email, body.Password);
            return Ok();
        }

        [HttpGet("delete/{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            await _unitOfWork.Users.Remove(userId);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UserDto body)
        {
            await _unitOfWork.Users.Update(body);
            throw new NotImplementedException();
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            return Ok(await _unitOfWork.Users.All());
        }
    }
}
