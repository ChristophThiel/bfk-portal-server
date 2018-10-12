using BfkPortal.Web.ViewModels.DataTransferObjects;
using BfkPortal.Web.ViewModels;
using BfkPortal.Core.Models;
using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IAppointmentService : IGenericService<Appointment, AppointmentViewModel, AppointmentDto>
    {
        Task ParticipateAsync(int appointmentId, int particpantId);

        Task UnparticipateAsync(int appointmentId, int participantId);

        //Task<bool> DutyToMarketplaceAsync(int appointmentId, int ownerId); */
    }
}
