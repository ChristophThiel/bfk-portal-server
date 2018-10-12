using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Services.Converters
{
    public class AppointmentToAppointmentDtoConverter : IConverter<Appointment, AppointmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IConverter<User, UserDto> _userToUserDtoConverter;
        private readonly IConverter<Organisation, OrganisationDto> _organisationToOrganisationDtoConverter;

        public AppointmentToAppointmentDtoConverter(IUnitOfWork unitOfWork, UserManager<User> userManager, IConverter<User, UserDto> userToUserDtoConverter, IConverter<Organisation, OrganisationDto> organisationToOrganisationDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _userToUserDtoConverter = userToUserDtoConverter;
            _organisationToOrganisationDtoConverter = organisationToOrganisationDtoConverter;
        }

        public async Task<AppointmentDto> Convert(Appointment source)
        {
            var destination = new AppointmentDto
            {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                From = source.From.Value,
                To = source.To.Value,
                AreParticipantsOrganisations = source.AreParticipantsOrganisations.Value,
                Deadline = source.Deadline,
                IsVisible = source.IsVisible,
                MaxParticipants = source.MaxParticipants.Value,
                Owner = await _userToUserDtoConverter.Convert(
                    await _userManager.FindByIdAsync(source.OwnerId.ToString()))
            };
            var participants = new List<object>();
            foreach (var participant in source.Participations)
            {
                if (destination.AreParticipantsOrganisations)
                    participants.Add(await _organisationToOrganisationDtoConverter.Convert(await _unitOfWork.Organisations.FindAsync(participant.OrganisationId)));
                else
                    participants.Add(await _userToUserDtoConverter.Convert(await _userManager.FindByIdAsync(participant.UserId.ToString())));
            }
            destination.Participations = participants;

            return destination;
        }
    }
}
