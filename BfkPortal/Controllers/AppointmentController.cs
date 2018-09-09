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
using BfkPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BfkPortal.Controllers
{
    [Authorize]
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

            var allowed = DefaultRoleService.RequireRoles(new[] {Roles.AdminBfk, Roles.AdminBwst, Roles.UserBfk}, user);
            if (!allowed)
                return Forbid();

            var appointment = new Appointment
            {
                Title = body.Title,
                Description = body.Description,
                From = DateTime.Parse(body.From, null, DateTimeStyles.RoundtripKind),
                To = DateTime.Parse(body.To, null, DateTimeStyles.RoundtripKind),
                Type = Enum.Parse<AppointmentTypes>(body.Type),
                AreParticipantsOrganisations = body.AreParticipantsOrganisations,
                MaxParticipants = body.MaxParticipants,
                ShowParticipants = body.ShowParticipants,
                Deadline = string.IsNullOrEmpty(body.Deadline) ? (DateTime?) null : DateTime.Parse(body.Deadline, null, DateTimeStyles.RoundtripKind),
                IsVisible = body.IsVisible,
                Owner = user,
                UserParticipants = new List<AppointmentUser>(),
                OrganisationParticipants = new List<AppointmentOrganisation>()
            };

            var result = _unitOfWork.Appointments.Add(appointment);
            if (!result)
            {
                ModelState.AddModelError("Add", "Failed to add the new entity.");
                return BadRequest(ModelState);
            }
            
            foreach (var participantId in body.Participants)
            {
                if (body.AreParticipantsOrganisations)
                {
                    var participant = await _unitOfWork.Organisations.Find(participantId);
                    if (participant == null) continue;

                    appointment.OrganisationParticipants.Add(new AppointmentOrganisation
                    {
                        Appointment = appointment,
                        Organisation = participant
                    });
                }
                else
                {
                    var participant = await _unitOfWork.Users.Find(participantId);
                    if (participant == null) continue;

                    appointment.UserParticipants.Add(new AppointmentUser
                    {
                        Appointment = appointment,
                        User = participant
                    });
                }
            }

            await _unitOfWork.SaveChangesAsync();
            return Ok(new {appointment.Id});
        }

        [HttpGet("delete/{appointmentId:int}")]
        public async Task<IActionResult> Delete(int appointmentId, [FromHeader] string authorization)
        {
            var user = await GetUserFromToken(authorization);
            if (user == null)
            {
                ModelState.AddModelError("Token", "An error occurred with the token!");
                return BadRequest(ModelState);
            }

            var allowed = DefaultRoleService.RequireRoles(new[] {Roles.AdminBfk, Roles.AdminBwst, Roles.UserBfk}, user);
            if (!allowed)
                return Forbid();

            var appointment = await _unitOfWork.Appointments.Find(appointmentId);
            if (appointment == null)
            {
                ModelState.AddModelError("Id", "An appointment with this id does not exists!");
                return BadRequest(ModelState);
            }

            if (DefaultRoleService.HasRole(Roles.UserBfk, user) && appointment.Owner.Id != user.Id)
                return Forbid();

            await _unitOfWork.Appointments.Delete(appointmentId);

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromHeader] string authorization, [FromBody] AppointmentUpdateRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var owner = await GetUserFromToken(authorization);
            if (owner == null)
            {
                ModelState.AddModelError("Token", "An error occurred with the token!");
                return BadRequest(ModelState);
            }

            var allowed = DefaultRoleService.RequireRoles(new[] { Roles.AdminBfk, Roles.AdminBwst, Roles.UserBfk }, owner);
            if (!allowed)
                return Forbid();

            var appointment = await _unitOfWork.Appointments.Find(body.Id);
            if (appointment == null)
            {
                ModelState.AddModelError("Id", "An appointment with this id does not exist!");
                return BadRequest(ModelState);
            }

            if (DefaultRoleService.HasRole(Roles.UserBfk, owner) && appointment.Owner.Id != owner.Id)
                return Forbid();

            appointment.Title = body.Title;
            appointment.Description = body.Description;
            appointment.From = DateTime.Parse(body.From, null, DateTimeStyles.RoundtripKind);
            appointment.To = DateTime.Parse(body.To, null, DateTimeStyles.RoundtripKind);
            appointment.AreParticipantsOrganisations = body.AreParticipantsOrganisations;
            appointment.MaxParticipants = body.MaxParticipants;
            appointment.ShowParticipants = body.ShowParticipants;
            appointment.Deadline = !string.IsNullOrEmpty(body.Deadline)
                ? DateTime.Parse(body.Deadline, null, DateTimeStyles.RoundtripKind)
                : (DateTime?) null;
            appointment.IsVisible = body.IsVisible;
            appointment.UserParticipants = new List<AppointmentUser>();
            appointment.OrganisationParticipants = new List<AppointmentOrganisation>();

            foreach (var participantId in body.Participants)
            {
                if (body.AreParticipantsOrganisations)
                {
                    var participant = await _unitOfWork.Organisations.Find(participantId);
                    if (participant == null) continue;

                    appointment.OrganisationParticipants.Add(new AppointmentOrganisation
                    {
                        Appointment = appointment,
                        Organisation = participant
                    });
                }
                else
                {
                    var participant = await _unitOfWork.Users.Find(participantId);
                    if (participant == null) continue;

                    appointment.UserParticipants.Add(new AppointmentUser
                    {
                        Appointment = appointment,
                        User = participant
                    });
                }
            }

            var result = _unitOfWork.Appointments.Update(appointment);
            if (!result)
            {
                ModelState.AddModelError("Update", "An error occured during the update!");
                return BadRequest(ModelState);
            }

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> All([FromHeader] string authorization)
        {
            var user = await GetUserFromToken(authorization);
            if (user == null)
            {
                ModelState.AddModelError("Token", "An error occurred with the token!");
                return BadRequest(ModelState);
            }


            var appointments = await _unitOfWork.Appointments.All();
            var result = new List<AppointmentDto>();
            
            if (DefaultRoleService.RequireRoles(DefaultRoleService.BfkRoles, user))
                result.AddRange(appointments.Where(a => a.Type != AppointmentTypes.Dienst).Select(a => new AppointmentDto(a)));
            if (DefaultRoleService.RequireRoles(DefaultRoleService.BwstRoles, user))
                result.AddRange(appointments.Where(a => a.Type == AppointmentTypes.Dienst).Select(a => new AppointmentDto(a)));

            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<IActionResult> AllTypes([FromHeader] string authorization)
        {
            var user = await GetUserFromToken(authorization);
            if (user == null)
            {
                ModelState.AddModelError("Token", "An error occurred with the token!");
                return BadRequest(ModelState);
            }

            var types = _unitOfWork.Appointments.Types();
            var result = new List<string>();

            if (DefaultRoleService.RequireRoles(DefaultRoleService.BfkRoles, user))
                result.AddRange(types.Where(t => t != AppointmentTypes.Dienst.ToString()).Select(t => t));
            if (DefaultRoleService.RequireRoles(DefaultRoleService.BwstRoles, user))
                result.AddRange(types.Where(t => t == AppointmentTypes.Dienst.ToString()).Select(t => t));

            return Ok(result);
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
