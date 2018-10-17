using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;

namespace BfkPortal.Web.Services.Converters
{
    public class AppointmentViewModelToAppointmentConverter : IConverter<AppointmentViewModel, Appointment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentViewModelToAppointmentConverter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Appointment> Convert(AppointmentViewModel source)
        {
            var destination = await _unitOfWork.Appointments.FindAsync(source.Id);
            if (destination == null)
                destination = new Appointment();

            destination.Title = source.Title;
            destination.Description = source.Description;
            destination.From = DateTime.Parse(source.From, null, DateTimeStyles.RoundtripKind);
            destination.To = DateTime.Parse(source.To, null, DateTimeStyles.RoundtripKind);
            if (destination.From > destination.To)
                throw new Exception();
            destination.Type = source.Type ?? AppointmentTypes.Vollversammlung;
            destination.AreParticipantsOrganisations = source.AreParticipantsOrganisations ?? false;
            destination.MaxParticipants = source.MaxParticipants ?? 0;
            destination.ShowParticipants = source.ShowParticipants ?? false;
            if (DateTime.TryParse(source.Deadline, null, DateTimeStyles.RoundtripKind, out var deadline))
                destination.Deadline = deadline;
            destination.IsVisible = source.IsVisible ?? false;
            if (source.Owner.HasValue)
                destination.Owner = await _unitOfWork.Users.FindAsync(source.Owner.Value, nameof(User.Entitlements), nameof(User.Memberships));
            destination.Participations = new List<Participation>();

            foreach (var participant in source.Participations)
            {
                if (destination.AreParticipantsOrganisations.Value)
                {
                    destination.Participations.Add(new Participation
                    {
                        Appointment = destination,
                        Organisation = await _unitOfWork.Organisations.FindAsync(participant)
                    });
                }
                else
                {
                    destination.Participations.Add(new Participation
                    {
                        Appointment = destination,
                        User = await _unitOfWork.Users.FindAsync(participant)
                    });
                }
            }

            return destination;
        }
    }
}
