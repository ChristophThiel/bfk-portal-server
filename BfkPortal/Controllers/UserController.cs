using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Communication.Requests;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using BfkPortal.Services;
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

        // DONE
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserAddRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var salt = DefaultHashingService.GenerateSalt();
            var password = DefaultHashingService.HashPassword(body.Email, body.Password, salt, _configuration["Pepper"]);
            var user = new User
            {
                Firstname = body.Firstname,
                Lastname = body.Lastname,
                Email = body.Email,
                Password = password,
                Salt = salt,
                IsDeleted = false,
                Roles = new List<UserRole>(),
                Appointments = new List<UserAppointment>(),
                Organisations = new List<UserOrganisation>()
            };

            AddRolesAndOrganisations(ref user, body.Roles, body.Organisations);

            _unitOfWork.Users.Add(user);

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        // DONE
        [HttpGet("delete/{userId:int}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await _unitOfWork.Users.Delete(userId);
            if (!result)
            {
                ModelState.AddModelError("Delete", "An error occurred during the delete!");
                return BadRequest(ModelState);
            }

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        // DONE
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _unitOfWork.Users.Find(body.Id);
            if (user == null)
            {
                ModelState.AddModelError("Id", "A user with this id does not exist!");
                return BadRequest(ModelState);
            }

            var salt = DefaultHashingService.GenerateSalt();
            var password = DefaultHashingService.HashPassword(body.Email, body.Password, salt, _configuration["Pepper"]);

            user.Firstname = body.Firstname;
            user.Lastname = body.Lastname;
            user.Email = body.Email;
            user.Password = password;
            user.Salt = salt;

            user.Roles = new List<UserRole>();
            user.Organisations = new List<UserOrganisation>();

            AddRolesAndOrganisations(ref user, body.Roles, body.Organisations);

            _unitOfWork.Users.Update(user);

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        // DONE
        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var users = await _unitOfWork.Users.All();
            return Ok(users.Select(u => new UserDto(u)));
        }

        // DONE
        [HttpGet("roles")]
        public async Task<IActionResult> AllRoles()
        {
            var roles = await _unitOfWork.Roles.All();
            return Ok(roles.Where(r => !r.Name.StartsWith("Admin"))
                .Select(r => r.Name));
        }

        #region Private methods

        private void AddRolesAndOrganisations(ref User user, IEnumerable<string> roleNames, IEnumerable<string> organsationNames)
        {
            var roles = _unitOfWork.Roles.All().Result.ToList();
            foreach (var roleName in roleNames)
            {
                var role = roles.FirstOrDefault(r => r.Name == roleName);
                if (role == null) continue;

                user.Roles.Add(new UserRole
                {
                    User = user,
                    Role = role
                });
            }

            var organisations = _unitOfWork.Organisations.All().Result.ToList();
            foreach (var organisatioName in organsationNames)
            {
                var organisation = organisations.FirstOrDefault(o => o.Name == organisatioName);
                if (organisation == null) continue;

                user.Organisations.Add(new UserOrganisation
                {
                    User = user,
                    Organisation = organisation
                });
            }
        }

        #endregion
    }
}
