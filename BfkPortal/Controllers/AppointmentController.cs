using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Controllers
{
    // TODO Authorization
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AppointmentController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        
        [HttpPost("add/{userId:int}")]
        public async Task<IActionResult> Add(int userId, [FromBody] AppointmentDto body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _unitOfWork.Users.GetById(userId);
            var appointment = new Appointment
            {
                Title = body.Title,
                Description = body.Description,
                From = DateTime.Parse(body.From, null, DateTimeStyles.RoundtripKind),
                To = DateTime.Parse(body.To, null, DateTimeStyles.RoundtripKind),
                Owner = user
            };
            await _unitOfWork.Appointments.Add(appointment);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new {appointment.Id});
        }

        [HttpGet("delete/{appointmentId:int}")]
        public async Task<IActionResult> Delete(int appointmentId)
        {
            // TODO Check if the user is the owner of the appointment or has the role "AdminBfk"

            await _unitOfWork.Appointments.Delete(appointmentId);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] AppointmentDto body)
        {
            // TODO Check if the user is the owner of the appointment or has the role "AdminBfk"

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _unitOfWork.Appointments.Update(body);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("all/{userId:int}")]
        public async Task<IActionResult> All(int userId)
        {
            // TODO Solution for appointments which go over a day

            var result = await _unitOfWork.Appointments.All(userId);
            return Ok(result.ToList());
        }
    }
}
