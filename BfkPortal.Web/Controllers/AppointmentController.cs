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
            if (viewModel.From > viewModel.To)
                throw new Exception(Constants.InvalidTimeLineExceptionMessage);
            var id = await _service.Add(viewModel);
            return Ok(new { id });
        }

        [HttpGet("[action]")]
        public IActionResult All()
        {
            var appointmenDtos = _service.All();
            return Ok(appointmenDtos);
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [Authorize(Policy = Constants.OwnerOfAppointmentPolicy)]
        [HttpGet("[action]/{appointmentId:int}")]
        public async Task<IActionResult> Delete(int appointmentId)
        {
            await _service.Remove(appointmentId);
            return Ok();
        }

        [Authorize(Roles = "AdminBwst")]
        [HttpGet("[action]/{month:int}")]
        public async Task<IActionResult> Distribute(int month)
        {
            var shifts = await _service.Distribute(month);
            return Ok(shifts.Select(s => s.Value).ToList());
        }

        [HttpGet("[action]/{appointmentId:int}")]
        public async Task<IActionResult> Find(int appointmentId)
        {
            var dto = await _service.Find(appointmentId);
            return Ok(dto);
        }

        [Authorize(Roles = "UserBwst, AdminBwst")]
        [Authorize(Policy = Constants.OwnerOfAppointmentPolicy)]
        [HttpGet("[action]/{appointmentId:int}")]
        public async Task<IActionResult> Offer(int appointmentId)
        {
            await _service.OfferDuty(appointmentId);
            return Ok();
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Participate([FromBody] ParticipationViewModel viewModel)
        {
            await _service.Participate(viewModel.AppointmentId.Value, viewModel.ParticipantId.Value);
            return Ok();
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [Authorize(Policy = Constants.OwnerOfAppointmentPolicy)]
        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] AppointmentViewModel viewModel)
        {
            var id = await _service.Update(viewModel);
            return Ok(new { id });
        }

        [Authorize(Roles = "UserBwst, AdminBwst")]
        [Authorize(Policy = Constants.FreeAppointmentPolicy)]
        [HttpGet("[action]/{appointmentId:int}")]
        public async Task<IActionResult> Take(int appointmentId)
        {
            var email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            await _service.TakeDuty(appointmentId, email);
            return Ok();
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [HttpGet("[action]")]
        public IActionResult Types()
        {
            return Ok(Enum.GetNames(typeof(AppointmentTypes)));
        }

        [Authorize(Roles = "UserBfk, AdminBfk, AdminBwst")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Unparticipate([FromBody] ParticipationViewModel viewModel)
        {
            await _service.Unparticipate(viewModel.AppointmentId.Value, viewModel.ParticipantId.Value);
            return Ok();
        }
    }
}
