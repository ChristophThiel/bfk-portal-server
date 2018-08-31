using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Communication.Requests;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using BfkPortal.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private const string JwtTokenPrefix = "Bearer ";

        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromHeader] string authorization, [FromBody] AppointmentAddRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await GetUserFromToken(authorization);
            if (user == null)
            {
                ModelState.AddModelError("Token", "An error occurred with the token!");
                return BadRequest(ModelState);
            }

            var appointment = new Appointment
            {
                Title = body.Title,
                Description = body.Description,
                From = DateTime.Parse(body.From, null, DateTimeStyles.RoundtripKind),
                To = DateTime.Parse(body.To, null, DateTimeStyles.RoundtripKind),
                Type = Enum.IsDefined(typeof(AppointmentTypes), body.Type)
                    ? Enum.Parse<AppointmentTypes>(body.Type)
                    : AppointmentTypes.Termin,
                AreParticipantsOrganisations = body.AreParticipantsOrganisations,
                MaxParticipants = body.MaxParticipants,
                ShowParticipants = body.ShowParticipants,
                Deadline = string.IsNullOrEmpty(body.Deadline) ? (DateTime?) null : DateTime.Parse(body.Deadline, null, DateTimeStyles.RoundtripKind),
                IsVisible = body.IsVisible,
                Owner = user,
                Participants = new List<UserAppointment>()
            };

            var result = _unitOfWork.Appointments.Add(appointment);
            if (!result)
            {
                ModelState.AddModelError("Add", "Failed to add the new entity.");
                return BadRequest(ModelState);
            }
            
            foreach (var userId in body.Participants)
            {
                var participant = await _unitOfWork.Users.Find(userId);
                if (participant == null) continue;

                appointment.Participants.Add(new UserAppointment
                {
                    User = participant,
                    Appointment = appointment
                });
            }

            await _unitOfWork.SaveChangesAsync();
            return Ok(new {appointment.Id});
        }

        [HttpGet("delete/{appointmentId:int}")]
        public async Task<IActionResult> Delete(int appointmentId, [FromHeader] string authorization)
        {
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

            var appointment = await _unitOfWork.Appointments.Find(body.Id);
            if (appointment == null)
            {
                ModelState.AddModelError("Id", "An appointment with this id does not exist!");
                return BadRequest(ModelState);
            }

            appointment.Title = body.Title;
            appointment.Description = body.Description;
            appointment.From = DateTime.Parse(body.From, null, DateTimeStyles.RoundtripKind);
            appointment.To = DateTime.Parse(body.To, null, DateTimeStyles.RoundtripKind);
            appointment.AreParticipantsOrganisations = body.AreParticipantsOrganisations;
            appointment.MaxParticipants = body.MaxParticipants;
            appointment.ShowParticipants = body.ShowParticipants;
            appointment.Deadline = string.IsNullOrEmpty(body.Deadline)
                ? DateTime.Parse(body.Deadline, null, DateTimeStyles.RoundtripKind)
                : (DateTime?) null;
            appointment.IsVisible = body.IsVisible;

            appointment.Participants = new List<UserAppointment>();

            foreach (var userId in body.Participants)
            {
                var user = await _unitOfWork.Users.Find(userId);
                if (user == null) continue;

                appointment.Participants.Add(new UserAppointment
                {
                    User = user,
                    Appointment = appointment
                });
            }
            
            var result = _unitOfWork.Appointments.Update(appointment);

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> All()
        {
            var appointments = await _unitOfWork.Appointments.All();
            foreach (var appointment in appointments)
            {
                var help = new AppointmentDto(appointment);
            }
            return Ok(appointments.Select(a => new AppointmentDto(a)));
        }

        [HttpGet("types")]
        public IActionResult AllTypes() => Ok(_unitOfWork.Appointments.Types());

        #region Private Methods

        private async Task<User> GetUserFromToken(string token)
        {
            try
            {
                var jwt = new JwtSecurityToken(token.Substring(JwtTokenPrefix.Length));
                var id = int.Parse(jwt.Claims.First().Value);
                return await _unitOfWork.Users.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion
    }
}
