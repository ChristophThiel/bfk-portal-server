using System;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Services.Converters
{
    public class OfferToOfferDtoConverter : IConverter<Offer, OfferDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IConverter<User, UserDto> _userToUserDtoConverter;
        private readonly IConverter<Appointment, AppointmentDto> _appointmentToAppointmentDtoConverter;

        public OfferToOfferDtoConverter(IUnitOfWork unitOfWork, UserManager<User> userManager, IConverter<User, UserDto> userToUserDtoConverter,
            IConverter<Appointment, AppointmentDto> appointmentToAppointmentDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _userToUserDtoConverter = userToUserDtoConverter;
            _appointmentToAppointmentDtoConverter = appointmentToAppointmentDtoConverter;
        }

        public async Task<OfferDto> Convert(Offer source)
        {
            var destination = new OfferDto
            {
                Id = source.Id,
                Status = source.Status.ToString(),
                Sender = await _userToUserDtoConverter.Convert(await _userManager.FindByIdAsync(source.SenderId.ToString())),
                Receiver = await _userToUserDtoConverter.Convert(await _userManager.FindByIdAsync(source.ReceiverId.ToString())),
                SenderAppointment = await _appointmentToAppointmentDtoConverter.Convert(await _unitOfWork.Appointments.FindAsync(source.SenderAppointmentId)),
                ReceiverAppointment = await _appointmentToAppointmentDtoConverter.Convert(await _unitOfWork.Appointments.FindAsync(source.ReceiverAppointmentId)),
            };

            return destination;
        }
    }
}
