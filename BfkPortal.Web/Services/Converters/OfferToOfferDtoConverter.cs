﻿using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services.Converters
{
    public class OfferToOfferDtoConverter : IConverter<Offer, OfferDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter<User, UserDto> _userToUserDtoConverter;
        private readonly IConverter<Appointment, AppointmentDto> _appointmentToAppointmentDtoConverter;

        public OfferToOfferDtoConverter(IUnitOfWork unitOfWork, IConverter<User, UserDto> userToUserDtoConverter,
            IConverter<Appointment, AppointmentDto> appointmentToAppointmentDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _userToUserDtoConverter = userToUserDtoConverter;
            _appointmentToAppointmentDtoConverter = appointmentToAppointmentDtoConverter;
        }

        public async Task<OfferDto> Convert(Offer source)
        {
            var destination = new OfferDto
            {
                Id = source.Id,
                Status = source.Status.ToString(),
                Sender = await _userToUserDtoConverter
                    .Convert(await _unitOfWork.Users
                        .FindAsync(source.SenderId, nameof(User.Entitlements), nameof(User.Memberships))),
                Receiver = await _userToUserDtoConverter
                    .Convert(await _unitOfWork.Users
                        .FindAsync(source.ReceiverId, nameof(User.Entitlements), nameof(User.Memberships))),
                SenderAppointment = await _appointmentToAppointmentDtoConverter
                    .Convert(await _unitOfWork.Appointments
                        .FindAsync(source.SenderAppointmentId, nameof(Appointment.Participations), nameof(Appointment.Owner))),
                ReceiverAppointment = await _appointmentToAppointmentDtoConverter
                    .Convert(await _unitOfWork.Appointments
                        .FindAsync(source.ReceiverAppointmentId, nameof(Appointment.Participations), nameof(Appointment.Owner))),
            };

            return destination;
        }
    }
}
