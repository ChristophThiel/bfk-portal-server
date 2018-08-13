using System;
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
    public class ShiftController : ControllerBase
    {
        private const string UserRoleName = "UserBwst";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public ShiftController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpPost("add/{userId:int}")]
        public async Task<IActionResult> Add(int userId, [FromBody] ShiftDto body)
        {
            // TODO Check if user owns the role "AdminBwst"

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _unitOfWork.Users.GetById(userId);
            var shift = new Shift
            {
                Title = body.Title,
                From = DateTime.Parse(body.From, null, DateTimeStyles.RoundtripKind),
                To = DateTime.Parse(body.To, null, DateTimeStyles.RoundtripKind),
                User = user
            };
            await _unitOfWork.Shifts.Add(shift);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new {shift.Id});
        }

        [HttpGet("delete/{shiftId:int}")]
        public async Task<IActionResult> Delete(int shiftId)
        {
            // TODO Check if the user owns the role "AdminBwst"

            await _unitOfWork.Shifts.Delete(shiftId);
            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update()
        {
            // TODO Sprint 2
            throw new NotImplementedException();
        }

        [HttpGet("all/{userId:int}")]
        public async Task<IActionResult> All(int userId)
        {
            // TODO Solution for shifts which go over a day

            // TODO Replace with ASP.NET Identity
            var user = await _unitOfWork.Users.GetById(userId);
            if (user.Roles.Any(ur => ur.Role.Name != UserRoleName))
            {
                var allShifts = await _unitOfWork.Shifts.All();
                return Ok(allShifts.ToList());
            }

            var userShifts = await _unitOfWork.Shifts.All(userId);
            return Ok(userShifts.ToList());
        }

    }
}
