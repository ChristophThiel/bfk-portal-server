using System.Threading.Tasks;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Services;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Web.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController()
        {
            _service = new AppointmentService(ModelState);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AppointmentViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.Add(body);

            if (!_service.ModelState.IsValid)
                return BadRequest(_service.ModelState);

            return Ok(new {id});
        }

        [HttpGet("delete/{appointmentId:int}")]
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

        [HttpPost("participate/{appointmentId:int}")]
        public async Task<IActionResult> Participate(int appointmentId)
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("offer/{appointmentId:int}")]
        public async Task<IActionResult> Offer(int appointmentId)
        {
            return Ok();
        }
    }
}
