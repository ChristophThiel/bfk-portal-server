using BfkPortal.Web.ViewModels.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentDto> All();

        IEnumerable<string> Types();

        Task ParticipateAsync(int appointmentId, int particpantId);

        Task UnparticipateAsync(int appointmentId, int participantId);

        Task<bool> DutyToMarketplaceAsync(int appointmentId, int ownerId);
    }
}
