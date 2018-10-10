using System.Threading.Tasks;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Services;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add()//[FromBody] AppointmentViewModel model)
        {
            var id = await _service.Add(new AppointmentViewModel());

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok(new {id});
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
