using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
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
            Appointment destination;
            if (source.Id.HasValue)
            {
                destination = await _unitOfWork.Appointments.FindAsync(source.Id.Value) ?? new Appointment();
                _unitOfWork.Participations.RemoveRange(_unitOfWork.Participations.All().Where(p => p.AppointmentId == source.Id.Value));
            }
            else
                destination = new Appointment();
            destination.Title = source.Title;
            destination.Description = source.Description;

            // Nullable but required
            destination.From = source.From.Value;
            destination.To = source.To.Value;
            destination.Type = source.Type.Value;

            destination.AreParticipantsOrganisations = source.AreParticipantsOrganisations ?? false;
            destination.MaxParticipants = source.MaxParticipants ?? 0;
            destination.ShowParticipants = source.ShowParticipants ?? false;
            destination.Deadline = source.Deadline;
            destination.IsVisible = source.IsVisible ?? true;

            if (source.Owner.HasValue)
                destination.Owner = await _unitOfWork.Users.FindAsync(source.Owner.Value);

            if (source.Participations == null)
                return destination;
            else if (source.Participations.Count() == 0)
                return destination;

            IEnumerable<EntityObject> participants;
            if (destination.AreParticipantsOrganisations)
                participants = source.Participations.Select(id => _unitOfWork.Organisations.FindAsync(id).Result);
            
            destination.Participations.Clear();
            foreach (var id in source.Participations)
            {
                if (destination.AreParticipantsOrganisations)
                {
                    destination.Participations.Add(new Participation
                    {
                        Appointment = destination,
                        Organisation = await _unitOfWork.Organisations.FindAsync(id)
                    });
                }
                else
                {
                    destination.Participations.Add(new Participation
                    {
                        Appointment = destination,
                        User = await _unitOfWork.Users.FindAsync(id)
                    });
                }
            }

            return destination;
        }
    }
}
