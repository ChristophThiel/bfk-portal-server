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
                IsVisible = viewModel.IsVisible ?? true,
                Participations = new List<Participation>()
            };

            User value = null;
            if (viewModel.Owner.HasValue)
                value = await UnitOfWork.Users.FindAsync(viewModel.Owner.Value);
            entity.Owner = value;

            foreach (var participationId in viewModel.Participations)
            {
                EntityObject participant;
                if (entity.AreParticipantsOrganisations.Value)
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

        public async Task ParticipateAsync(int appointmentId, int participantId)
        {
            var appointment = await UnitOfWork.Appointments.FindAsync(appointmentId);

            if (appointment == null)
                ModelState.AddModelError("Appointment Id", "An appointment with this id does not exist!");

            else
            {
                if (appointment.MaxParticipants.Value == 0)
                    ModelState.AddModelError("MaxParticipants", "This appointment cannot have any particiapants!");

                else
                {
                    await UnitOfWork.Appointments.LoadCollectionAsync(appointment, nameof(appointment.Participations));

                    if (appointment.MaxParticipants.Value == appointment.Participations.Count())
                        ModelState.AddModelError("MaxParticipants", "The maximum of participants is reached!");

                    else
                    {
                        EntityObject participant;
                        if (appointment.AreParticipantsOrganisations.Value)
                            participant = await UnitOfWork.Organisations.FindAsync(participantId);
                        else
                            participant = await UnitOfWork.Users.FindAsync(participantId);

                        await UnitOfWork.Appointments.LoadReferenceAsync(appointment, nameof(appointment.Owner));

                        if (appointment.Owner.Id == participant.Id)
                            ModelState.AddModelError("Owner", "You are the owner of this appointment!");

                        else
                        {
                            var isAlreadyParticipant = false;
                            foreach (var participation in appointment.Participations)
                            {
                                if (participation.UserId == participant.Id)
                                    isAlreadyParticipant = true;
                            }

                            if (isAlreadyParticipant)
                                ModelState.AddModelError("Participants", "You are already a participant!");

                            else
                            {
                                appointment.Participations.Add(new Participation
                                {
                                    Appointment = appointment,
                                    User = !appointment.AreParticipantsOrganisations.Value ? participant as User : null,
                                    Organisation = appointment.AreParticipantsOrganisations.Value ? participant as Organisation : null
                                });
                                await UnitOfWork.SaveChangesAsync();
                            }
                        }
                    }

                }
            }
        }

        public async Task<bool> DutyToMarketplaceAsync(int appointmentId, int ownerId)
        {
            var appointment = await UnitOfWork.Appointments.FindAsync(appointmentId);
            if (appointment == null)
                ModelState.AddModelError("Appointment Id", $"An appointment with the id {appointmentId} does not exist!");

            await UnitOfWork.Appointments.LoadReferenceAsync(appointment, nameof(appointment.Owner));
            var owner = await UnitOfWork.Users.FindAsync(ownerId);
            if (owner == null)
                ModelState.AddModelError("Owner Id", $"An user with the id {ownerId} does not exist!");

            if (appointment.Owner.Id != ownerId)
                return false;

            appointment.Type = AppointmentTypes.MarktplatzDienst;
            UnitOfWork.Appointments.Update(appointment);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
