using System;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Communication.Requests;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UserController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserAddRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var salt = DefaultHashingService.GenerateSalt();
            var pepper = _configuration["Pepper"];

            var hashedPassword = DefaultHashingService.HashPassword(body.Email, body.Password, salt, pepper);
            var user = new User
            {
                Firstname = body.Firstname,
                Lastname = body.Lastname,
                Email = body.Email,
                Password = hashedPassword,
                Salt = salt,
                IsDeleted = false
            };

            await _unitOfWork.Users.Add(user);

            foreach (var roleId in body.Roles)
            {
                var role = await _unitOfWork.Roles.Find(roleId);
                if (role == null) continue;
                var userRole = new UserRole
                {
                    User = user,
                    Role = role
                };
                await _unitOfWork.UserRoles.Add(userRole);
            }

            foreach (var organisationId in body.Organisations)
            {
                var organisation = await _unitOfWork.Organisations.Find(organisationId);
                if (organisation == null) continue;
                var userOrganisation = new UserOrganisation
                {
                    User = user,
                    Organisation = organisation
                };
                await _unitOfWork.UserOrganisations.Add(userOrganisation);
            }

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("delete/{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await _unitOfWork.Users.Delete(userId);
            await _unitOfWork.SaveChangesAsync();
            if (result)
                return Ok();

            ModelState.AddModelError("Id", "A user with this id does not exists!");
            return BadRequest(ModelState);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _unitOfWork.Users.Find(body.Id);
            if (user == null)
            {
                ModelState.AddModelError("Id", "A user with this id does not exists!");
                return BadRequest(ModelState);
            }

            var result = await _unitOfWork.Users.Update(body);
            await _unitOfWork.SaveChangesAsync();

            if (result)
                return Ok();
            ModelState.AddModelError("Id", "A user with this id does not exists!");
            return BadRequest(ModelState);
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            return Ok(await _unitOfWork.Users.All());
        }
    }
}
