using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;
using BfkPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Add([FromHeader] string authorization, [FromBody] AppointmentDto body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = GetUserIdFromToken(authorization.Substring(JwtTokenPrefix.Length - 1));

            var user = await _unitOfWork.Users.Find(userId);
            if (!DefaultRoleService.ContainsRole(user, new[] {DefaultRoleService.UserBfk, DefaultRoleService.AdminBfk}))
                return Forbid();

            var appointment = new Appointment
            {
                Title = body.Title,
                Description = body.Description,
                From = DateTime.Parse(body.From, null, DateTimeStyles.RoundtripKind),
                To = DateTime.Parse(body.To, null, DateTimeStyles.RoundtripKind),
                Type = await _unitOfWork.Appointments.FindType(body.Type),
                MaxParticipants = body.MaxParticipants,
                ShowParticipants = body.ShowParticipants ?? false,
                Deadline = body.Deadline,
                IsVisible = body.IsVisible ?? false,
                Owner = user
            };
            await _unitOfWork.Appointments.Add(appointment);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new {appointment.Id});
        }

        [HttpGet("delete/{appointmentId:int}")]
        public async Task<IActionResult> Delete(int appointmentId, [FromHeader] string authorization)
        {
            var userId = GetUserIdFromToken(authorization);
            var user = await _unitOfWork.Users.Find(userId);
            var appointment = await _unitOfWork.Appointments.Find(appointmentId);

            if (!DefaultRoleService.ContainsRole(user, new [] {DefaultRoleService.AdminBfk, DefaultRoleService.AdminBwst}))
                return Forbid();
            if (appointment.Owner != user)
                return Forbid();

            await _unitOfWork.Appointments.Delete(appointmentId);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromHeader] string authorization, [FromBody] AppointmentDto body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = GetUserIdFromToken(authorization);
            var user = await _unitOfWork.Users.Find(userId);
            var appointment = await _unitOfWork.Appointments.Find(body.Id);

            if (!DefaultRoleService.ContainsRole(user, new[] { DefaultRoleService.AdminBfk, DefaultRoleService.AdminBwst }))
                return Forbid();
            if (appointment.Owner != user)
                return Forbid();

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

        private int GetUserIdFromToken(string token)
        {
            var jwt = new JwtSecurityToken(token);
            return int.Parse(jwt.Claims.First().Value);
        }

    }
}
