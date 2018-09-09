using System;
using System.Collections.Generic;
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
    public class OfferController : ControllerBase
    {
        private const string JwtTokenPrefix = "Bearer ";

        private readonly IUnitOfWork _unitOfWork;

        public OfferController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromHeader] string authorization, [FromBody] OfferAddRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await GetUserFromToken(authorization);
            if (user == null)
            {
                ModelState.AddModelError("Token", "An error occurred with the token!");
                return BadRequest(ModelState);
            }

            if (!DefaultRoleService.RequireRoles(new[] {Roles.UserBwst, Roles.AdminBwst}, user))
                return Forbid();

            var receiverAppointment = await _unitOfWork.Appointments.Find(body.ReceiverAppointmentId);
            if (receiverAppointment == null)
            {
                ModelState.AddModelError("ReceiverAppointmentId", "An appointment with this id does not exist!");
                return BadRequest(ModelState);
            }

            var senderAppointment = await _unitOfWork.Appointments.Find(body.SenderAppointmentId);
            if (senderAppointment == null)
            {
                ModelState.AddModelError("SenderAppointmentId", "An appointment with this id does not exist!");
                return BadRequest(ModelState);
            }

            var offer = new Offer
            {
                Status = Enum.Parse<OfferStatus>(body.Status),
                SenderAppointment = senderAppointment,
                ReceiverAppointment = receiverAppointment,
                Sender = senderAppointment.Owner,
                Receiver = receiverAppointment.Owner
            };

            var result = _unitOfWork.Offers.Add(offer);
            if (!result)
            {
                ModelState.AddModelError("Add", "Failed to add the new entity.");
                return BadRequest(ModelState);
            }

            await _unitOfWork.SaveChangesAsync();
            return Ok(new {offer.Id});
        }

        [HttpGet("delete/{offerId:int}")]
        public async Task<IActionResult> Delete(int offerId, [FromHeader] string authorization)
        {
            var offer = await _unitOfWork.Offers.Find(offerId);
            if (offer == null)
            {
                ModelState.AddModelError("Id", "An offer with this id does not exist!");
                return BadRequest(ModelState);
            }

            await _unitOfWork.Offers.Delete(offerId);

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromHeader] string authorization, [FromBody] OfferUpdateRequest body)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await GetUserFromToken(authorization);
            if (user == null)
            {
                ModelState.AddModelError("Token", "An error occurred with the token!");
                return BadRequest(ModelState);
            }

            var offer = await _unitOfWork.Offers.Find(body.Id);
            if (offer == null)
            {
                ModelState.AddModelError("Id", "An offer with this id does not exist!");
                return BadRequest(ModelState);
            }

            var receiverAppointment = await _unitOfWork.Appointments.Find(body.ReceiverAppointmentId);
            if (receiverAppointment == null)
            {
                ModelState.AddModelError("ReceiverAppointmentId", "An appointment with this id does not exist!");
                return BadRequest(ModelState);
            }

            var senderAppointment = await _unitOfWork.Appointments.Find(body.SenderAppointmentId);
            if (senderAppointment == null)
            {
                ModelState.AddModelError("SenderAppointmentId", "An appointment with this id does not exist!");
                return BadRequest(ModelState);
            }

            offer.ReceiverAppointment = receiverAppointment;
            offer.Receiver = receiverAppointment.Owner;
            offer.SenderAppointment = senderAppointment;
            offer.Sender = senderAppointment.Owner;

            var result = _unitOfWork.Offers.Update(offer);
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
                ModelState.AddModelError("Token", "An error occured with the token!");
                return BadRequest(ModelState);
            }

            var offers = await _unitOfWork.Offers.All();
            var result = offers.Where(o => o.Receiver == user || o.Sender == user)
                .Select(o => new OfferDto(o));

            return Ok(result);
        }

        [HttpGet("status")]
        public IActionResult AllStatus()
        {
            return Ok(_unitOfWork.Offers.Status());
        }

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
    }
}
