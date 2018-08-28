using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.Requests;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private const string JwtTokenPrefix = "Bearer ";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public AppointmentController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromHeader] string authorization, [FromBody] AppointmentAddRequest body)
        {
            // ModelState
            // User
            // Roles
            // Create Appointment
            // Create UserAppointments

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await GetUserFromToken(authorization);
            if (user == null)
            {
                ModelState.AddModelError("Token", "An error occurred with the token!");
                return BadRequest(ModelState);
            }

            if (!DefaultRoleService.ContainsRole(user, new []{ DefaultRoleService.UserBfk, DefaultRoleService.AdminBfk}))
                return Forbid();

            var appointment = new Appointment
            {
                Title = body.Title,
                Description = body.Description,
                From = DateTime.Parse(body.From, null, DateTimeStyles.RoundtripKind),
                To = DateTime.Parse(body.To, null, DateTimeStyles.RoundtripKind),
                Type = await _unitOfWork.Appointments.FindType(body.Type),
                MaxParticipants = body.MaxParticipants,
                ShowParticipants = body.ShowParticipants,
                Deadline = string.IsNullOrEmpty(body.Deadline) ? (DateTime?) null : DateTime.Parse(body.Deadline, null, DateTimeStyles.RoundtripKind),
                IsVisible = body.IsVisible,
                Owner = user
            };
            await _unitOfWork.Appointments.Add(appointment);

            var participants = body.Participants.Select(p => _unitOfWork.Users.Find(p));
            foreach (var participant in participants)
            {
                var userAppointment = new UserAppointment
                {
                    Appointment = appointment,
                    User = await participant
                };
                await _unitOfWork.UserAppointments.Add(userAppointment);
            }
            await _unitOfWork.SaveChangesAsync();

            return Ok(new {appointment.Id});
        }

        [HttpGet("delete/{appointmentId:int}")]
        public async Task<IActionResult> Delete(int appointmentId, [FromHeader] string authorization)
        {
            var user = await GetUserFromToken(authorization);
            var appointment = await _unitOfWork.Appointments.Find(appointmentId);

            // TODO Check, if the user is allowed to delete this appointment

            var result = await _unitOfWork.Appointments.Delete(appointmentId);
            if (!result)
            {
                ModelState.AddModelError("Id", "An appointment with this id does not exists!");
                return BadRequest(ModelState);
            }
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromHeader] string authorization, [FromBody] AppointmentUpdateRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await GetUserFromToken(authorization);
            var appointment = await _unitOfWork.Appointments.Find(body.Id);

            // TODO Check if the user is allowed to update this appointment

            await _unitOfWork.Appointments.Update(body);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var allAppointments = await _unitOfWork.Appointments.All();
            return Ok(allAppointments.ToList());
        }

        [HttpGet("types")]
        public async Task<IActionResult> AllTypes()
        {
            var allTypes = await _unitOfWork.Appointments.AllTypes();
            return Ok(allTypes.ToList());
        }

        private async Task<User> GetUserFromToken(string token)
        {
            var jwt = new JwtSecurityToken(token.Substring(JwtTokenPrefix.Length));
            var id = int.Parse(jwt.Claims.First().Value);
            return await _unitOfWork.Users.Find(id);
        }

    }
}
