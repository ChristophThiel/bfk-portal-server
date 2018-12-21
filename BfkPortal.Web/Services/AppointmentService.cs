using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter<AppointmentViewModel, Appointment> _viewModelToModelConverter;
        private readonly IConverter<Appointment, AppointmentDto> _modelToDtoConverter;

        public AppointmentService(IUnitOfWork unitOfWork,
            IConverter<AppointmentViewModel, Appointment> viewModelToModelConverter,
            IConverter<Appointment,
            AppointmentDto> modelToDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _viewModelToModelConverter = viewModelToModelConverter;
            _modelToDtoConverter = modelToDtoConverter;
        }

        public async Task<int> Add(AppointmentViewModel viewModel)
        {
            var model = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Appointments.Add(model);
            
            await _unitOfWork.SaveChangesAsync();
            return model.Id;
        }

        public IEnumerable<AppointmentDto> All()
        {
            var appointments = _unitOfWork.Appointments.All(nameof(Appointment.Participations), nameof(Appointment.Owner));
            return appointments.Select(a => _modelToDtoConverter.Convert(a).Result);
        }

        public async Task<AppointmentDto> Find(int id)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(id, nameof(Appointment.Participations), nameof(Appointment.Owner));
            return await _modelToDtoConverter.Convert(appointment);
        }

        public async Task OfferDuty(int appointmentId)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(appointmentId);
            appointment.Type = AppointmentTypes.MarktplatzDienst;
            _unitOfWork.Appointments.Update(appointment);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Participate(int appointmentId, int particpantId)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(appointmentId, nameof(Appointment.Participations));
            if (IsParticipant(appointment, particpantId))
                throw new Exception(Constants.AlreadyParticipantExceptionMessage);
            else if (appointment.Participations.Count() == appointment.MaxParticipants)
                throw new Exception(Constants.MaxPaticipantsExceptionMessage);
            else if (appointment.Deadline.HasValue && appointment.Deadline >= DateTime.Now)
                throw new Exception(Constants.ExceededDeadlineExcpetionMessage);
            else if (appointment.Type == AppointmentTypes.Dienst ||
                     appointment.Type == AppointmentTypes.FreierDienst ||
                     appointment.Type == AppointmentTypes.MarktplatzDienst)
                throw new Exception(Constants.UnableToParticipateExceptionMessage);

            if (appointment.AreParticipantsOrganisations)
            {
                var organisation = await _unitOfWork.Organisations.FindAsync(particpantId);
                appointment.Participations.Add(new Participation
                {
                    Appointment = appointment,
                    Organisation = organisation
                });
            }
            else
            {
                var user = await _unitOfWork.Users.FindAsync(particpantId);
                appointment.Participations.Add(new Participation
                {
                    Appointment = appointment,
                    User = user
                });
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            _unitOfWork.Appointments.Remove(await _unitOfWork.Appointments.FindAsync(id));

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task TakeDuty(int appointmentId, string email)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(appointmentId, nameof(Appointment.Owner),
                nameof(Appointment.Participations));

            var user = _unitOfWork.Users.All()
                .SingleOrDefault(u => u.Email == email);
            appointment.Owner = user;
            appointment.Type = AppointmentTypes.Dienst;
            _unitOfWork.Appointments.Update(appointment);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Unparticipate(int appointmentId, int participantId)
        {
            var appointment = await _unitOfWork.Appointments.FindAsync(appointmentId, nameof(Appointment.Participations));
            if (!IsParticipant(appointment, participantId))
                throw new Exception(Constants.AlreadyParticipantExceptionMessage);

            for (var i = 0; i < appointment.Participations.Count; i++)
            {
                var participant = appointment.Participations.ElementAt(i);
                if (participant.OrganisationId == participantId || participant.UserId == participantId)
                    appointment.Participations.Remove(participant);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Update(AppointmentViewModel viewModel)
        {
            var model = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Appointments.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return model.Id;
        }

        private bool IsParticipant(Appointment appointment, int participantId)
        {
            if (appointment.Participations == null)
                appointment.Participations = new List<Participation>();
            foreach (var participant in appointment.Participations)
            {
                if (appointment.AreParticipantsOrganisations)
                {
                    if (participant.OrganisationId == participantId)
                        return true;
                }
                else
                {
                    if (participant.UserId == participantId)
                        return true;
                }
            }
            return false;
        }
    }
}
