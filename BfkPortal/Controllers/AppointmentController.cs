using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.Requests;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using BfkPortal.Models.Enums;
using Microsoft.AspNetCore.Authorization;
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

            // TODO Check if the user is allowed to create a appointment

            var appointment = new Appointment
            {
                Title = body.Title,
                Description = body.Description,
                From = DateTime.Parse(body.From, null, DateTimeStyles.RoundtripKind),
                To = DateTime.Parse(body.To, null, DateTimeStyles.RoundtripKind),
                Type = Enum.IsDefined(typeof(AppointmentTypes), body.Type)
                    ? Enum.Parse<AppointmentTypes>(body.Type)
                    : AppointmentTypes.Termin,
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

            //await _unitOfWork.Appointments.Update(body);
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
            /*var allTypes = await _unitOfWork.Appointments.AllTypes();
            return Ok(allTypes.Where(t => t.Name != "Termin")
                .Select(t => t.Name));*/
            throw new NotImplementedException();
        }

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
