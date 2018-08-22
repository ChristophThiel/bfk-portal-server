using System;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Database.Repositories;
using BfkPortal.DataTransferObjects;
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

        [HttpPost("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("update/{id:int}")]
        public async Task<IActionResult> Update(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            return Ok(await _unitOfWork.Users.All());
        }
    }
}
