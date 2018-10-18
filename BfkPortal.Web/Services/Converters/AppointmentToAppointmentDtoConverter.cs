using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services.Converters
{
    public class AppointmentToAppointmentDtoConverter : IConverter<Appointment, AppointmentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter<User, UserDto> _userToUserDtoConverter;
        private readonly IConverter<Organisation, OrganisationDto> _organisationToOrganisationDtoConverter;

        public AppointmentToAppointmentDtoConverter(IUnitOfWork unitOfWork, IConverter<User, UserDto> userToUserDtoConverter, IConverter<Organisation, OrganisationDto> organisationToOrganisationDtoConverter)
        {
            _unitOfWork = unitOfWork;
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
                From = source.From,
                To = source.To,
                Type = source.Type.ToString(),
                AreParticipantsOrganisations = source.AreParticipantsOrganisations,
                Deadline = source.Deadline,
                IsVisible = source.IsVisible,
                MaxParticipants = source.MaxParticipants
            };
            if (source.OwnerId.HasValue)
                destination.Owner = await _userToUserDtoConverter.Convert(
                    await _unitOfWork.Users.FindAsync(source.OwnerId.Value, nameof(User.Entitlements), nameof(User.Memberships)));

            if (source.Participations != null)
            {
                var participants = new List<object>();
                foreach (var participant in source.Participations)
                {
                    if (destination.AreParticipantsOrganisations)
                        participants.Add(await _organisationToOrganisationDtoConverter.Convert(await _unitOfWork.Organisations.FindAsync(participant.OrganisationId.Value)));
                    else
                        participants.Add(await _userToUserDtoConverter.Convert(await _unitOfWork.Users.FindAsync(participant.UserId.Value, nameof(User.Entitlements), nameof(User.Memberships))));
                }
                destination.Participations = participants;
            }

            return destination;
        }
    }
}
