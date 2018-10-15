using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;

        public AuthenticationController(IAuthenticationService service)
        {
            _service = service;
        }

        [Authorize(Roles = "AdminBfk, AdminBwst")]
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserViewModel model)
        {
            try
            {
                await _service.Register(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> LogIn([FromBody] CredentialsViewModel model)
        {
            try
            {
                var user = await _service.LogIn(model);
                var token = _service.GenerateJsonWebToken(user);
                return Ok(new
                {
                    token,
                    user
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        // TODO DELETE
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Initialize([FromServices] IUnitOfWork unitOfWork)
        {
            await unitOfWork.DeleteDatabaseAsync();
            await unitOfWork.CreateDatabaseAsync();

            unitOfWork.Roles.Add(new Role
            {
                Name = "UserBfk"
            });
            unitOfWork.Roles.Add(new Role
            {
                Name = "AdminBfk"
            });
            unitOfWork.Roles.Add(new Role
            {
                Name = "UserBwst"
            });
            unitOfWork.Roles.Add(new Role
            {
                Name = "ObserverBwst"
            });
            unitOfWork.Roles.Add(new Role
            {
                Name = "AdminBwst"
            });

            unitOfWork.Organisations.Add(new Organisation
            {
                Name = "Feuerwehr Marchtrenk",
                IsDeleted = false,
                Memberships = new List<Membership>(),
                Participations = new List<Participation>()
            });

            unitOfWork.Organisations.Add(new Organisation
            {
                Name = "Feuerwehr Kappern",
                IsDeleted = false,
                Memberships = new List<Membership>(),
                Participations = new List<Participation>()
            });

            await unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
