using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] AppointmentViewModel viewModel)
        {
            try
            {
                if (viewModel.From > viewModel.To)
                    return BadRequest();
                var id = await _service.AddAsync(viewModel);
                return Ok(new { id });
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [Authorize(Policy = Constants.OwnerOfAppointmentPolicy)]
        [HttpGet("[action]/{appointmentId:int}")]
        public async Task<IActionResult> Delete([FromHeader] int appointmentId)
        {
            try
            {
                await _service.RemoveAsync(appointmentId);
                return Ok();
            }
            catch
            {
               return BadRequest();
            }
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [Authorize(Policy = Constants.OwnerOfAppointmentPolicy)]
        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] AppointmentViewModel viewModel)
        {
            try
            {
                var id = await _service.UpdateAsync(viewModel);
                return Ok(new { id });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("[action]/{appointmentId:int}")]
        public async Task<IActionResult> Find([FromHeader] int appointmentId)
        {
            try
            {
                var dto = await _service.FindAsync(appointmentId);
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

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [HttpGet("[action]")]
        public IActionResult Types()
        {
            return Ok(Enum.GetNames(typeof(AppointmentTypes)));
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Participate([FromBody] ParticipationViewModel viewModel)
        {
            try
            {
                await _service.ParticipateAsync(viewModel.AppointmentId.Value, viewModel.ParticipantId.Value);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Unparticipate([FromBody] ParticipationViewModel viewModel)
        {
            try
            {
                await _service.UnparticipateAsync(viewModel.AppointmentId.Value, viewModel.ParticipantId.Value);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "UserBwst, AdminBwst")]
        [Authorize(Policy = Constants.OwnerOfAppointmentPolicy)]
        [HttpGet("[action]/{appointmentId:int}")]
        public async Task<IActionResult> Offer([FromHeader] int appointmentId)
        {
            try
            {
                await _service.OfferDuty(appointmentId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "UserBwst, AdminBwst")]
        [Authorize(Policy = Constants.FreeAppointmentPolicy)]
        [HttpGet("[action]/{appointmentId:int}")]
        public async Task<IActionResult> Take([FromHeader] int appointmentId)
        {
            try
            {
                var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
                await _service.TakeDuty(appointmentId, email);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
