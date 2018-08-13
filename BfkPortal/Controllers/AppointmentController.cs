using System;
using System.Collections;
using System.Collections.Generic;
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
        private const string AdminRoleName = "AdminBfk";

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
            // TODO Check the role of the user

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
            // TODO Check the role of the user

            await _unitOfWork.Appointments.Delete(appointmentId);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("update/{userId:int}")]
        public async Task<IActionResult> Update(int userId, [FromBody] AppointmentDto body)
        {
            // TODO Check the role of the user

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
            // TODO Get id from JWT

            // TODO Replace with ASP.NET Identity
            var user = await _unitOfWork.Users.GetById(userId);
            if (user.Roles.Any(ur => ur.Role.Name == AdminRoleName))
            {
                var allAppointments = await _unitOfWork.Appointments.All();
                return Ok(allAppointments.ToList());
            }

            var userAppointments = await _unitOfWork.Appointments.All(userId);
            return Ok(userAppointments.ToList());
        }


    }
}
