using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BfkPortal.Web.Services
{
    public class AppointmentService : GenericService<Appointment, AppointmentViewModel, AppointmentDto>, IAppointmentService
    {
        public AppointmentService(ModelStateDictionary modelState) : base(modelState) { }

        public override IEnumerable<AppointmentDto> All() =>
            UnitOfWork.Appointments.All().Select(a => new AppointmentDto(a));

        public override async Task<Appointment> CastViewModelToModel(AppointmentViewModel viewModel)
        {
            var entity = new Appointment
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                From = DateTime.Parse(viewModel.From),
                To = DateTime.Parse(viewModel.To),
                Type = viewModel.Type ?? AppointmentTypes.Dienst,
                AreParticipantsOrganisations = viewModel.AreParticipantsOrganisations ?? false,
                MaxParticipants = viewModel.MaxParticipants ?? 0,
                ShowParticipants = viewModel.ShowParticipants ?? false,
                Deadline = string.IsNullOrEmpty(viewModel.Deadline)
                    ? (DateTime?) null
                    : DateTime.Parse(viewModel.Deadline),
                IsVisible = viewModel.IsVisible ?? true
            };
            
            var owner = await UnitOfWork.Users.FindAsync(viewModel.Owner.Value);
            entity.Owner = owner;

            foreach (var participationId in viewModel.Participations)
            {
                EntityObject participant;
                if (entity.AreParticipantsOrganisations)
                {
                    participant = await UnitOfWork.Organisations.FindAsync(participationId);
                    if (participant == null)
                        ModelState.AddModelError("Organisation Id", "An organisation with this id does not exist!");
                    else
                        entity.Participations.Add(new Participation
                        {
                            Appointment = entity,
                            Organisation = (Organisation) participant
                        });
                }
                else
                {
                    participant = await UnitOfWork.Users.FindAsync(participationId);
                    if (participant == null)
                        ModelState.AddModelError("User Id", "An user with this id does not exist!");
                    else
                        entity.Participations.Add(new Participation
                        {
                            Appointment = entity,
                            User = (User) participant
                        });
                }
            }

            return entity;
        }

        public IEnumerable<string> Types() => Enum.GetNames(typeof(AppointmentTypes));

        public async Task Participate(int appointmentId, int particpantId)
        {
            var appointment = await UnitOfWork.Appointments.FindAsync(appointmentId);
            if (appointment == null)
                ModelState.AddModelError("Appointment Id", "An appointment with this id does not exist");
            else
            {
                if (appointment.MaxParticipants >= 0)
            }
        }
    }
}
