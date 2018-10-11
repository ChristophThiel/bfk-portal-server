using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services
{
    public class AppointmentService : IAppointmentService
    {
        public IUnitOfWork UnitOfWork { get; }

        public IConverter<AppointmentViewModel, Appointment> ViewModelToModelConverter { get; }

        public IConverter<Appointment, AppointmentDto> ModelToDtoConverter { get; }

        public AppointmentService(IUnitOfWork unitOfWork,
            IConverter<AppointmentViewModel, Appointment> viewModelToModelConverter,
            IConverter<Appointment, AppointmentDto> modelToDtoConverter)
        {
            UnitOfWork = unitOfWork;
            ViewModelToModelConverter = viewModelToModelConverter;
            ModelToDtoConverter = modelToDtoConverter;
        }

        public async Task<int> AddAsync(AppointmentViewModel viewModel)
        {
            var model = await ViewModelToModelConverter.Convert(viewModel);
            UnitOfWork.Appointments.Add(model);

            return model.Id;
        }

        public IEnumerable<AppointmentDto> All()
        {
            return UnitOfWork.Appointments.All().Select(a => ModelToDtoConverter.Convert(a).Result);
        }

        public async Task<AppointmentDto> FindAsync(int id)
        {
            return await ModelToDtoConverter.Convert(await UnitOfWork.Appointments.FindAsync(id));
        }

        public async Task RemoveAsync(int id)
        {
            UnitOfWork.Appointments.Remove(await UnitOfWork.Appointments.FindAsync(id));
        }

        public async Task UpdateAsync(AppointmentViewModel viewModel)
        {
            var model = await ViewModelToModelConverter.Convert(viewModel);
            UnitOfWork.Appointments.Update(model);
        }

        /* public AppointmentService(ModelStateDictionary modelState) : base(modelState) { }

        public override IEnumerable<AppointmentDto> All()
        {
            var appointments = UnitOfWork.Appointments.All();
            foreach (var appointment in appointments)
            {
                UnitOfWork.Appointments.LoadCollectionAsync(appointment, nameof(appointment.Participations)).Wait();
                foreach (var participation in appointment.Participations)
                {
                    if (appointment.AreParticipantsOrganisations.Value)
                        UnitOfWork.Participations.LoadReferenceAsync(participation, nameof(participation.Organisation)).Wait();
                    else
                    {
                        UnitOfWork.Participations.LoadReferenceAsync(participation, nameof(participation.User));
                        UnitOfWork.Users.LoadCollectionAsync(participation.User,
                            nameof(participation.User.Entitlements)).Wait();
                        foreach (var entitlement in participation.User.Entitlements)
                            UnitOfWork.Entitlements.LoadReferenceAsync(entitlement, nameof(entitlement.Role));
                        UnitOfWork.Users.LoadCollectionAsync(participation.User,
                            nameof(participation.User.Memberships)).Wait();
                        foreach (var membership in participation.User.Memberships)
                            UnitOfWork.Memberships.LoadReferenceAsync(membership, nameof(membership.Organisation));
                    }
                }
                UnitOfWork.Appointments.LoadReferenceAsync(appointment, nameof(appointment.Owner)).Wait();
                if (appointment.Owner == null)
                    continue;
                UnitOfWork.Users.LoadCollectionAsync(appointment.Owner, nameof(appointment.Owner.Entitlements)).Wait();
                foreach (var entitlement in appointment.Owner.Entitlements)
                    UnitOfWork.Entitlements.LoadReferenceAsync(entitlement, nameof(entitlement.Role));
                UnitOfWork.Users.LoadCollectionAsync(appointment.Owner, nameof(appointment.Owner.Memberships)).Wait();
                foreach (var membership in appointment.Owner.Memberships)
                    UnitOfWork.Memberships.LoadReferenceAsync(membership, nameof(membership.Organisation));
            }
            return appointments.Select(a => new AppointmentDto(a));
        }

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

        public async Task UnparticipateAsync(int appointmentId, int participantId)
        {
            var appointment = await UnitOfWork.Appointments.FindAsync(appointmentId);
            if (appointment == null)
                ModelState.AddModelError("Appointment Id", "An appointment with this id does not exist!");

            await UnitOfWork.Appointments.LoadCollectionAsync(appointment, nameof(appointment.Participations));

            Func<int, bool> expression;
            if (appointment.AreParticipantsOrganisations.Value)
                expression = (organisationId) => organisationId == participantId;
            else
                expression = (userId) => userId == participantId;

            var participant = appointment.Participations.FirstOrDefault(p =>
                expression(appointment.AreParticipantsOrganisations.Value
                    ? p.OrganisationId.Value
                    : p.UserId.Value));

            if (participant != null)
                appointment.Participations.Remove(participant);
            else 
                ModelState.AddModelError("Participant Id", "You are not a participant of this appointment!");

            await UnitOfWork.SaveChangesAsync();
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
        } */
    }
}
