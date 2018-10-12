using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [Authorize(Roles = "UserBFK, AdminBFK, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] AppointmentViewModel viewModel)
        {
            try
            {
                var id = await _service.AddAsync(viewModel);
                return Ok(new { id });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "UserBFK, AdminBFK, AdminBwst")]
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Delete([FromHeader] int id, [FromServices] IAuthorizeService authorizationService)
        {
            try
            {
                var email = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Email).Value;
                if (!(await authorizationService.IsAdminBfk(email)) && !(await authorizationService.IsAdminBwst(email)))
                {
                    if (!(await authorizationService.IsOwner(id, email)))
                        return Unauthorized();
                }

                await _service.RemoveAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "UserBFK, AdminBFK, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] AppointmentViewModel viewModel, [FromServices] IAuthorizeService authorizationService)
        {
            try
            {
                var email = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Email).Value;
                if (!(await authorizationService.IsAdminBfk(email)) && !(await authorizationService.IsAdminBwst(email)))
                {
                    if (!(await authorizationService.IsOwner(viewModel.Id, email)))
                        return Unauthorized();
                }

                await _service.UpdateAsync(viewModel);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Find([FromHeader] int id)
        {
            try
            {
                var dto = await _service.FindAsync(id);
                return Ok(dto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]")]
        public IActionResult All()
        {
            try
            {
                var appointmenDtos = _service.All();
                return Ok(appointmenDtos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]")]
        public IActionResult Types()
        {
            return Ok(Enum.GetNames(typeof(AppointmentTypes)));
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Participate([FromBody] ParticipationViewModel viewModel, [FromServices] UserManager<User> userManager)
        {
            try
            {
                var email = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Email).Value;
                var user = await userManager.FindByEmailAsync(email);

                await _service.ParticipateAsync(viewModel.AppointmentId.Value, viewModel.ParticipantId.Value);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Unparticipate([FromBody] ParticipationViewModel viewModel, [FromServices] UserManager<User> userManager)
        {
            try
            {
                var email = HttpContext.User.FindFirst(JwtRegisteredClaimNames.Email).Value;
                var user = await userManager.FindByEmailAsync(email);

                await _service.ParticipateAsync(viewModel.AppointmentId.Value, viewModel.ParticipantId.Value);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /*[HttpGet("delete/{appointmentId:int}")]
        public async Task<IActionResult> Delete(int appointmentId)
        {
            await _service.Remove(appointmentId);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] AppointmentViewModel body)
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

        [HttpGet("types")]
        public IActionResult Roles() => Ok(_service.Types());

        [HttpPost("[action]")]
        public async Task<IActionResult> Participate([FromBody] ParticipateViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.ParticipateAsync(body.AppointmentId.Value, body.ParticipantId.Value);
            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Unparticipate([FromBody] ParticipateViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UnparticipateAsync(body.AppointmentId.Value, body.ParticipantId.Value);
            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok();
        }

        [HttpPost("offer")]
        public async Task<IActionResult> Offer([FromBody] AppointmentToMarketplaceViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.DutyToMarketplaceAsync(body.AppointmentId.Value, body.OwnerId.Value);
            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            if (!result)
                return Unauthorized();

            return Ok();
        } */
    }
}
