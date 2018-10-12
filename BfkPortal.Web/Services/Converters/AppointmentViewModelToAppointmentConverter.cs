using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Services.Converters
{
    public class AppointmentViewModelToAppointmentConverter : IConverter<AppointmentViewModel, Appointment>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public AppointmentViewModelToAppointmentConverter(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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
            destination.Type = source.Type ?? AppointmentTypes.Übung;
            destination.AreParticipantsOrganisations = source.AreParticipantsOrganisations ?? false;
            destination.MaxParticipants = source.MaxParticipants ?? 0;
            destination.ShowParticipants = source.ShowParticipants ?? false;
            if (DateTime.TryParse(source.Deadline, null, DateTimeStyles.RoundtripKind, out var deadline))
                destination.Deadline = deadline;
            destination.IsVisible = source.IsVisible ?? false;
            destination.Owner = await _userManager.FindByIdAsync(source.Owner.ToString());
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
